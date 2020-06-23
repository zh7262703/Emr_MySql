using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using System.Collections;

namespace Base_Function.BLL_MANAGEMENT.DOCTOR_MANAGE
{
    /// <summary>
    /// 主观评分
    /// </summary>
    /// 修改 李文明
    /// 修改时间 2013年12月25号
    public partial class frmGrade : DevComponents.DotNetBar.Office2007Form
    {
        ucfrmMainGradeRepart fmgr;
        frmMainSelectHistoryRepart fmshr;
        string id = "";
        string pid = "";
        string suffName = "";

        string pingfenId = "";//获取他的评分ID
        string pingfenTime = "";//获取他的评分时间
        //string item_Id = "";//获取他每一项的ID

        string doctorID = App.UserAccount.UserInfo.User_id;
        string doctorName = App.UserAccount.UserInfo.User_name;
        public frmGrade(ucfrmMainGradeRepart _fmgr)
        {
            InitializeComponent();
            this.fmgr = _fmgr;
            pid = fmgr.SetPingfen();
            id = fmgr.gid;
            suffName = fmgr.SetSuffererName();
            this.Text = "给 " + suffName + " 主观评分";

            SetBingAnShouYe();
            SetRuYuanJiLu();
            SetBingChengJiLu();
            SetJiBenYaoqiuyiZhuDan();
            SetChuyuanSiwangJilu();
            SetfuZhuJianCha();
            SetTongyiShu();
        }
        public frmGrade(frmMainSelectHistoryRepart _fmshr)
        {
            InitializeComponent();
            this.fmshr = _fmshr;
            id = fmshr.SetPingFenID();
            pingfenId = fmshr.SetPingFenPID();//获取他的评分ID
            pingfenTime = fmshr.SetPingFenTime();//获取他的评分时间
            //item_Id = fmshr.SetPingFenItem_ID();//获取他每一项的ID
            suffName = _fmshr.SetSuffererName();
            this.Text = "给 " + suffName + " 主观评分修改";

            SetBingAnShouYe();
            SetRuYuanJiLu();
            SetBingChengJiLu();
            SetJiBenYaoqiuyiZhuDan();
            SetChuyuanSiwangJilu();
            SetfuZhuJianCha();
            SetTongyiShu();
            SetKouFen();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fgid"></param>
        /// <param name="fgpfid"></param>
        /// <param name="fgpfTime"></param>
        public frmGrade(string fgid,string fgpfid,string fgpfTime)
        {
            InitializeComponent();
            id = fgid;
            pingfenId = fgpfid;//获取他的评分ID
            pingfenTime = fgpfTime;//获取他的评分时间
            //suffName = _fmshr.SetSuffererName();
            this.Text = "查看 " + suffName + " 主观评分详细";
            this.btnConfirm.Visible = false;

            SetBingAnShouYe();
            SetRuYuanJiLu();
            SetBingChengJiLu();
            SetJiBenYaoqiuyiZhuDan();
            SetChuyuanSiwangJilu();
            SetfuZhuJianCha();
            SetTongyiShu();
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
            string selectItemIDSQL = "select item_id,down_point,DOWN_REASON from t_doc_grade where pid='" + pingfenId + "' and to_char(grade_time,'yyyy-MM-dd HH24:mi:ss')='" + pingfenTime + "'";
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
                        c1FlexGrid1_BingAnShouYe[j, "理由"] = dtitem_Id.Rows[i]["DOWN_REASON"].ToString();
                    }
                }
                //第二次循环是循环c1控件如果他们的ID相同就是扣分的项 把扣分值赋给c1控件的扣分列
                for (int j = 1; j < c1FlexGrid1_ruYuanJilu.Rows.Count; j++)
                {
                    if (dtitem_Id.Rows[i]["item_id"].ToString() == c1FlexGrid1_ruYuanJilu[j, "ID"].ToString())
                    {
                        c1FlexGrid1_ruYuanJilu[j, "扣分"] = dtitem_Id.Rows[i]["down_point"].ToString();
                        c1FlexGrid1_ruYuanJilu[j, "理由"] = dtitem_Id.Rows[i]["DOWN_REASON"].ToString();
                    }
                }
                //第二次循环是循环c1控件如果他们的ID相同就是扣分的项 把扣分值赋给c1控件的扣分列
                for (int j = 1; j < c1FlexGrid1_bingchengjilu.Rows.Count; j++)
                {
                    if (dtitem_Id.Rows[i]["item_id"].ToString() == c1FlexGrid1_bingchengjilu[j, "ID"].ToString())
                    {
                        c1FlexGrid1_bingchengjilu[j, "扣分"] = dtitem_Id.Rows[i]["down_point"].ToString();
                        c1FlexGrid1_bingchengjilu[j, "理由"] = dtitem_Id.Rows[i]["DOWN_REASON"].ToString();
                    }
                }
                //第二次循环是循环c1控件如果他们的ID相同就是扣分的项 把扣分值赋给c1控件的扣分列
                for (int j = 1; j < c1FlexGrid1_jibenyaoqiu.Rows.Count; j++)
                {
                    if (dtitem_Id.Rows[i]["item_id"].ToString() == c1FlexGrid1_jibenyaoqiu[j, "ID"].ToString())
                    {
                        c1FlexGrid1_jibenyaoqiu[j, "扣分"] = dtitem_Id.Rows[i]["down_point"].ToString();
                        c1FlexGrid1_jibenyaoqiu[j, "理由"] = dtitem_Id.Rows[i]["DOWN_REASON"].ToString();
                    }
                }
                //第二次循环是循环c1控件如果他们的ID相同就是扣分的项 把扣分值赋给c1控件的扣分列
                for (int j = 1; j < c1FlexGrid1_chuyuansiwang.Rows.Count; j++)
                {
                    if (dtitem_Id.Rows[i]["item_id"].ToString() == c1FlexGrid1_chuyuansiwang[j, "ID"].ToString())
                    {
                        c1FlexGrid1_chuyuansiwang[j, "扣分"] = dtitem_Id.Rows[i]["down_point"].ToString();
                        c1FlexGrid1_chuyuansiwang[j, "理由"] = dtitem_Id.Rows[i]["DOWN_REASON"].ToString();
                    }
                }
                //第二次循环是循环c1控件如果他们的ID相同就是扣分的项 把扣分值赋给c1控件的扣分列
                for (int j = 1; j < c1FlexGrid1_fuzhujiancha.Rows.Count; j++)
                {
                    if (dtitem_Id.Rows[i]["item_id"].ToString() == c1FlexGrid1_fuzhujiancha[j, "ID"].ToString())
                    {
                        c1FlexGrid1_fuzhujiancha[j, "扣分"] = dtitem_Id.Rows[i]["down_point"].ToString();
                        c1FlexGrid1_fuzhujiancha[j, "理由"] = dtitem_Id.Rows[i]["DOWN_REASON"].ToString();
                    }
                }
                //第二次循环是循环c1控件如果他们的ID相同就是扣分的项 把扣分值赋给c1控件的扣分列
                for (int j = 1; j < c1FlexGrid1_zhiqingtongyi.Rows.Count; j++)
                {
                    if (dtitem_Id.Rows[i]["item_id"].ToString() == c1FlexGrid1_zhiqingtongyi[j, "ID"].ToString())
                    {
                        c1FlexGrid1_zhiqingtongyi[j, "扣分"] = dtitem_Id.Rows[i]["down_point"].ToString();
                        c1FlexGrid1_zhiqingtongyi[j, "理由"] = dtitem_Id.Rows[i]["DOWN_REASON"].ToString();
                    }
                }
            }
        }
        /// <summary>
        /// 设置病案首页类容
        /// </summary>
        private void SetBingAnShouYe()
        {
            string bingAn = "select ID as ID,code as 序号,name as 项目 from t_data_code where type=57 order by length(code),code";
            DataSet ds = App.GetDataSet(bingAn);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            //添加一行扣分列
            DataColumn dc1 = new DataColumn("扣分", typeof(double));
            dt.Columns.Add(dc1);
            //添加一行理由列
            DataColumn dc2 = new DataColumn("理由", typeof(string));
            dt.Columns.Add(dc2);
            this.c1FlexGrid1_BingAnShouYe.DataSource = dt.DefaultView;
            this.c1FlexGrid1_BingAnShouYe.Cols["ID"].Visible = false;
            this.c1FlexGrid1_BingAnShouYe.Cols["项目"].Width = 350;
            this.c1FlexGrid1_BingAnShouYe.Cols["扣分"].Width = 100;
            this.c1FlexGrid1_BingAnShouYe.Cols["理由"].Width = 222;
        }
        /// <summary>
        ///设置入院记录
        /// </summary>
        private void SetRuYuanJiLu()
        {
            string ruyuan = "select ID as ID,code as 序号,name as 项目 from t_data_code where type=58 order by length(code),code";
            DataSet ds = App.GetDataSet(ruyuan);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            DataColumn dc1 = new DataColumn("扣分", typeof(double));
            dt.Columns.Add(dc1);
            DataColumn dc2 = new DataColumn("理由", typeof(string));
            dt.Columns.Add(dc2);
            this.c1FlexGrid1_ruYuanJilu.DataSource = dt.DefaultView;
            this.c1FlexGrid1_ruYuanJilu.Cols["ID"].Visible = false;
            this.c1FlexGrid1_ruYuanJilu.Cols["项目"].Width = 280;
            //this.c1FlexGrid1_ruYuanJilu.Cols["扣分"].Width = 100;
            this.c1FlexGrid1_ruYuanJilu.Cols["理由"].Width = 171;

        }
        /// <summary>
        ///设置病程记录
        /// </summary>
        private void SetBingChengJiLu()
        {
            string bingcheng = "select ID as ID,code as 序号,name as 项目 from t_data_code where type=59 order by length(code),code";
            DataSet ds = App.GetDataSet(bingcheng);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            DataColumn dc1 = new DataColumn("扣分", typeof(double));
            dt.Columns.Add(dc1);
            DataColumn dc2 = new DataColumn("理由", typeof(string));
            dt.Columns.Add(dc2);
            this.c1FlexGrid1_bingchengjilu.DataSource = dt.DefaultView;
            this.c1FlexGrid1_bingchengjilu.Cols["ID"].Visible = false;
            this.c1FlexGrid1_bingchengjilu.Cols["项目"].Width = 313;
            //this.c1FlexGrid1_bingchengjilu.Cols["扣分"].Width = 100;
            this.c1FlexGrid1_bingchengjilu.Cols["理由"].Width = 138;

        }
        /// <summary>
        ///设置基本要求及医嘱单
        /// 郧西妇幼修改成:书写基本原则
        /// </summary>
        private void SetJiBenYaoqiuyiZhuDan()
        {
            string jibenyaoqiu = "select ID as ID,code as 序号,name as 项目 from t_data_code where type=60 order by length(code),code";
            DataSet ds = App.GetDataSet(jibenyaoqiu);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            DataColumn dc1 = new DataColumn("扣分", typeof(double));
            dt.Columns.Add(dc1);
            DataColumn dc2 = new DataColumn("理由", typeof(string));
            dt.Columns.Add(dc2);
            this.c1FlexGrid1_jibenyaoqiu.DataSource = dt.DefaultView;
            this.c1FlexGrid1_jibenyaoqiu.Cols["ID"].Visible = false;
            this.c1FlexGrid1_jibenyaoqiu.Cols["项目"].Width = 353;
            //this.c1FlexGrid1_jibenyaoqiu.Cols["扣分"].Width = 100;
            this.c1FlexGrid1_jibenyaoqiu.Cols["理由"].Width = 67;

        }
        /// <summary>
        ///设置出院（死亡）记录
        /// </summary>
        private void SetChuyuanSiwangJilu()
        {
            string chuyuan = "select ID as ID,code as 序号,name as 项目 from t_data_code where type=61 order by length(code),code";
            DataSet ds = App.GetDataSet(chuyuan);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            DataColumn dc1 = new DataColumn("扣分", typeof(double));
            dt.Columns.Add(dc1);
            DataColumn dc2 = new DataColumn("理由", typeof(string));
            dt.Columns.Add(dc2);
            this.c1FlexGrid1_chuyuansiwang.DataSource = dt.DefaultView;
            this.c1FlexGrid1_chuyuansiwang.Cols["ID"].Visible = false;
            this.c1FlexGrid1_chuyuansiwang.Cols["项目"].Width = 307;
            this.c1FlexGrid1_chuyuansiwang.Cols["扣分"].Width = 90;
            this.c1FlexGrid1_chuyuansiwang.Cols["理由"].Width = 220;

        }
        /// <summary>
        ///设置辅助检查
        /// 郧西妇幼修改成:医嘱单及辅助检测单
        /// </summary>
        private void SetfuZhuJianCha()
        {
            string fuzhujianche = "select ID as ID,code as 序号,name as 项目 from t_data_code where type=62 order by length(code),code";
            DataSet ds = App.GetDataSet(fuzhujianche);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            DataColumn dc1 = new DataColumn("扣分", typeof(double));
            dt.Columns.Add(dc1);
            DataColumn dc2 = new DataColumn("理由", typeof(string));
            dt.Columns.Add(dc2);
            this.c1FlexGrid1_fuzhujiancha.DataSource = dt.DefaultView;
            this.c1FlexGrid1_fuzhujiancha.Cols["ID"].Visible = false;
            this.c1FlexGrid1_fuzhujiancha.Cols["项目"].Width = 427;
            this.c1FlexGrid1_fuzhujiancha.Cols["扣分"].Width = 50;
            this.c1FlexGrid1_fuzhujiancha.Cols["理由"].Width = 188;

        }
        /// <summary>
        ///设置知情同意
        /// </summary>
        private void SetTongyiShu()
        {
            string zhiqingtongyi = "select ID as ID,code as 序号,name as 项目 from t_data_code where type=63 order by length(code),code";
            DataSet ds = App.GetDataSet(zhiqingtongyi);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            DataColumn dc1 = new DataColumn("扣分", typeof(double));
            dt.Columns.Add(dc1);

            DataColumn dc2 = new DataColumn("理由", typeof(string));
            dt.Columns.Add(dc2);
            this.c1FlexGrid1_zhiqingtongyi.DataSource = dt.DefaultView;
            this.c1FlexGrid1_zhiqingtongyi.Cols["ID"].Visible = false;
            //this.c1FlexGrid1_zhiqingtongyi.Cols["项目"].Width = 440;
            //this.c1FlexGrid1_zhiqingtongyi.Cols["扣分"].Width = 100;
            this.c1FlexGrid1_zhiqingtongyi.Cols["理由"].Width = 65;

        }

        private void label99_Click(object sender, EventArgs e)
        {

        }

        private void frmGrade_Load(object sender, EventArgs e)
        {
            ////string kouFen1 = this.txtDOWN_POINT_1.Text;
            //string liYou1 = this.txtDOWN_REASON_1.Text;
            //string kouFen2 = this.txtDOWN_POINT_2.Text;
            //string liYou2 = this.txtDOWN_REASON_2.Text;
            //string kouFen3 = this.txtDOWN_POINT_3.Text;
            //string liYou3 = this.txtDOWN_REASON_3.Text;
            //string kouFen4 = this.txtDOWN_POINT_4.Text;
            //string liYou4 = this.txtDOWN_REASON_4.Text;
            //string kouFen5 = this.txtDOWN_POINT_5.Text;
            //string liYou5 = this.txtDOWN_REASON_5.Text;
            //string kouFen6 = this.txtDOWN_POINT_6.Text;
            //string liYou6 = this.txtDOWN_REASON_6.Text;
            //string kouFen7 = this.txtDOWN_POINT_7.Text;
            //string liYou7 = this.txtDOWN_REASON_7.Text;

            //string querySQL = "select * from T_DOC_GRADE where PID='" + pid + "'";
            //DataSet ds = App.GetDataSet(querySQL);
            ////txtDOWN_POINT_1.Text = ds.Tables[0].Rows[0]["DOWN_POINT_1"].ToString();
            //txtDOWN_REASON_1.Text = ds.Tables[0].Rows[0]["DOWN_REASON_1"].ToString();
            //txtDOWN_POINT_2.Text = ds.Tables[0].Rows[0]["DOWN_POINT_2"].ToString();
            //txtDOWN_REASON_2.Text = ds.Tables[0].Rows[0]["DOWN_REASON_2"].ToString();
            //txtDOWN_POINT_3.Text = ds.Tables[0].Rows[0]["DOWN_POINT_3"].ToString();
            //txtDOWN_REASON_3.Text = ds.Tables[0].Rows[0]["DOWN_REASON_3"].ToString();
            //txtDOWN_POINT_4.Text = ds.Tables[0].Rows[0]["DOWN_POINT_4"].ToString();
            //txtDOWN_REASON_4.Text = ds.Tables[0].Rows[0]["DOWN_REASON_4"].ToString();
            //txtDOWN_POINT_5.Text = ds.Tables[0].Rows[0]["DOWN_POINT_5"].ToString();
            //txtDOWN_REASON_5.Text = ds.Tables[0].Rows[0]["DOWN_REASON_5"].ToString();
            //txtDOWN_POINT_6.Text = ds.Tables[0].Rows[0]["DOWN_POINT_6"].ToString();
            //txtDOWN_REASON_6.Text = ds.Tables[0].Rows[0]["DOWN_REASON_6"].ToString();
            //txtDOWN_POINT_7.Text = ds.Tables[0].Rows[0]["DOWN_POINT_7"].ToString();
            //txtDOWN_REASON_7.Text = ds.Tables[0].Rows[0]["DOWN_REASON_7"].ToString();
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
                if (this.c1FlexGrid1_BingAnShouYe[i, 3].ToString() != "")
                {
                    bingansum += Convert.ToDouble(c1FlexGrid1_BingAnShouYe[i, 3].ToString());//扣分项分值
                }
            }
            double ruyuanSum = 0;
            //把入院记录扣的总分算出来
            for (int i = 1; i < this.c1FlexGrid1_ruYuanJilu.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_ruYuanJilu[i, 3].ToString() != "")
                {
                    ruyuanSum += Convert.ToDouble(c1FlexGrid1_ruYuanJilu[i, 3].ToString());//扣分项分值
                }
            }
            double bingchengSum = 0;
            //把病程记录扣的总分算出来
            for (int i = 1; i < this.c1FlexGrid1_bingchengjilu.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_bingchengjilu[i, 3].ToString() != "")
                {
                    bingchengSum += Convert.ToDouble(c1FlexGrid1_bingchengjilu[i, 3].ToString());//扣分项分值
                }
            }
            double jibenyaojiuSum = 0;
            //把基本要求及医嘱单扣的总分算出来
            for (int i = 1; i < this.c1FlexGrid1_jibenyaoqiu.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_jibenyaoqiu[i, 3].ToString() != "")
                {
                    jibenyaojiuSum += Convert.ToDouble(c1FlexGrid1_jibenyaoqiu[i, 3].ToString());//扣分项分值
                }
            }
            double chuyuanSiwangSum = 0;
            //把出院（死亡）记录扣的总分算出来
            for (int i = 1; i < this.c1FlexGrid1_chuyuansiwang.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_chuyuansiwang[i, 3].ToString() != "")
                {
                    chuyuanSiwangSum += Convert.ToDouble(c1FlexGrid1_chuyuansiwang[i, 3].ToString());//扣分项分值
                }
            }
            double fuzhujianchaSum = 0;
            //把辅助检查扣的总分算出来
            for (int i = 1; i < this.c1FlexGrid1_fuzhujiancha.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_fuzhujiancha[i, 3].ToString() != "")
                {
                    fuzhujianchaSum += Convert.ToDouble(c1FlexGrid1_fuzhujiancha[i, 3].ToString());//扣分项分值
                }
            }
            double zhiqingtongyiSum = 0;
            //把知情同意扣的总分算出来
            for (int i = 1; i < this.c1FlexGrid1_zhiqingtongyi.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_zhiqingtongyi[i, 3].ToString() != "")
                {
                    zhiqingtongyiSum += Convert.ToDouble(c1FlexGrid1_zhiqingtongyi[i, 3].ToString());//扣分项分值
                }
            }
            double zongSum = 100 - (bingansum + ruyuanSum + bingchengSum + jibenyaojiuSum + chuyuanSiwangSum + fuzhujianchaSum + zhiqingtongyiSum);
            if (fmshr == null)
            {
                fmgr.SetFenzhi(zongSum);
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
            //循环病案首页的每一项添加到表里面
            for (int i = 1; i < this.c1FlexGrid1_BingAnShouYe.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_BingAnShouYe[i, 3].ToString() != "")
                {
                    string binganID = c1FlexGrid1_BingAnShouYe[i, 1].ToString();//扣分项的ID
                    string binganKoufen = c1FlexGrid1_BingAnShouYe[i, 3].ToString();//扣分项分值
                    string binganLiyou = c1FlexGrid1_BingAnShouYe[i, 4].ToString();//扣分原因
                    string dosID = App.UserAccount.UserInfo.User_id;//医生ID
                    string dosName = App.UserAccount.UserInfo.User_name;//医生姓名 
                    string operateSection = App.UserAccount.CurrentSelectRole.Section_name == null ? "" : App.UserAccount.CurrentSelectRole.Section_name;
                    if (App.UserAccount.CurrentSelectRole.Role_type.Trim() == "Z" && App.UserAccount.CurrentSelectRole.Role_name.Contains("质控科"))
                    {//是否是质控科室
                        operateSection = "质控科";
                    }
                    else if (App.UserAccount.CurrentSelectRole.Role_type.Trim() == "Y" && App.UserAccount.CurrentSelectRole.Role_name.Contains("医务科"))
                    {//是否是医务科室
                        operateSection = "医务科";
                    }
                    string insertupdateSQL = "";//定义要执行的sql语句
                    if (pingfenId == "" && pid != "")
                    {
                        insertupdateSQL = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                            "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,PATIENT_ID,OPERATE_SECTION) values('" + pid + "','" + binganID +
                        "','" + binganKoufen + "','" + binganLiyou + "',57,'" + dosID +
                        "','" + dosName + "','" + zongSum + "'," + time + ",'" + id + "','" + operateSection + "')";
                        list.Add(insertupdateSQL);
                    }
                    else
                    {
                        string insert = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                        "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,PATIENT_ID,OPERATE_SECTION) values('" + pingfenId + "','" + binganID +
                    "','" + binganKoufen + "','" + binganLiyou + "',57,'" + dosID +
                    "','" + dosName + "','" + zongSum + "',to_timestamp('" + pingfenTime + "','yyyy-MM-dd HH24:mi:ss'),'" + id + "','" + operateSection + "') ";
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
                if (this.c1FlexGrid1_ruYuanJilu[i, 3].ToString() != "")
                {
                    string binganID = c1FlexGrid1_ruYuanJilu[i, 1].ToString();//扣分项的ID
                    string binganKoufen = c1FlexGrid1_ruYuanJilu[i, 3].ToString();//扣分项分值
                    string binganLiyou = c1FlexGrid1_ruYuanJilu[i, 4].ToString();//扣分原因
                    string dosID = App.UserAccount.UserInfo.User_id;//医生ID
                    string dosName = App.UserAccount.UserInfo.User_name;//医生姓名
                    string operateSection = App.UserAccount.CurrentSelectRole.Section_name == null ? "" : App.UserAccount.CurrentSelectRole.Section_name;
                    if (App.UserAccount.CurrentSelectRole.Role_type.Trim() == "Z" && App.UserAccount.CurrentSelectRole.Role_name.Contains("质控科"))
                    {//是否是质控科室
                        operateSection = "质控科";
                    }
                    else if (App.UserAccount.CurrentSelectRole.Role_type.Trim() == "Y" && App.UserAccount.CurrentSelectRole.Role_name.Contains("医务科"))
                    {//是否是医务科室
                        operateSection = "医务科";
                    }
                    string insertupdateSQL = "";//定义要执行的sql语句
                    if (pingfenId == "" && pid != "")
                    {
                        insertupdateSQL = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                            "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,PATIENT_ID,OPERATE_SECTION) values('" + pid + "','" + binganID +
                        "','" + binganKoufen + "','" + binganLiyou + "',58,'" + dosID +
                        "','" + dosName + "','" + zongSum + "'," + time + ",'" + id + "','" + operateSection + "')";
                        list.Add(insertupdateSQL);
                    }
                    else
                    {
                        string insert = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                        "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,PATIENT_ID,OPERATE_SECTION) values('" + pingfenId + "','" + binganID +
                    "','" + binganKoufen + "','" + binganLiyou + "',58,'" + dosID +
                    "','" + dosName + "','" + zongSum + "',to_timestamp('" + pingfenTime + "','yyyy-MM-dd HH24:mi:ss'),'" + id + "','" + operateSection + "') ";
                        if (App.ExecuteSQL(insert) > 0)
                            this.Close();
                    }
                }
            }



            //循环病程记录的每一项添加到表里面
            for (int i = 1; i < this.c1FlexGrid1_bingchengjilu.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_bingchengjilu[i, 3].ToString() != "")
                {
                    string binganID = c1FlexGrid1_bingchengjilu[i, 1].ToString();//扣分项的ID
                    string binganKoufen = c1FlexGrid1_bingchengjilu[i, 3].ToString();//扣分项分值
                    string binganLiyou = c1FlexGrid1_bingchengjilu[i, 4].ToString();//扣分原因
                    string dosID = App.UserAccount.UserInfo.User_id;//医生ID
                    string dosName = App.UserAccount.UserInfo.User_name;//医生姓名
                    string operateSection = App.UserAccount.CurrentSelectRole.Section_name == null ? "" : App.UserAccount.CurrentSelectRole.Section_name;
                    if (App.UserAccount.CurrentSelectRole.Role_type.Trim() == "Z" && App.UserAccount.CurrentSelectRole.Role_name.Contains("质控科"))
                    {//是否是质控科室
                        operateSection = "质控科";
                    }
                    else if (App.UserAccount.CurrentSelectRole.Role_type.Trim() == "Y" && App.UserAccount.CurrentSelectRole.Role_name.Contains("医务科"))
                    {//是否是医务科室
                        operateSection = "医务科";
                    }
                    string insertupdateSQL = "";//定义要执行的sql语句
                    if (pingfenId == "" && pid != "")
                    {
                        insertupdateSQL = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                            "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,PATIENT_ID,OPERATE_SECTION) values('" + pid + "','" + binganID +
                        "','" + binganKoufen + "','" + binganLiyou + "',59,'" + dosID +
                        "','" + dosName + "','" + zongSum + "'," + time + ",'" + id + "','" + operateSection + "')";
                        list.Add(insertupdateSQL);
                    }
                    else
                    {
                        string insert = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                        "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,PATIENT_ID,OPERATE_SECTION) values('" + pingfenId + "','" + binganID +
                    "','" + binganKoufen + "','" + binganLiyou + "',59,'" + dosID +
                    "','" + dosName + "','" + zongSum + "',to_timestamp('" + pingfenTime + "','yyyy-MM-dd HH24:mi:ss'),'" + id + "','" + operateSection + "') ";
                        if (App.ExecuteSQL(insert) > 0)
                            this.Close();
                    }
                }
            }



            //循环基本要求及医嘱单的每一项添加到表里面
            for (int i = 1; i < this.c1FlexGrid1_jibenyaoqiu.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_jibenyaoqiu[i, 3].ToString() != "")
                {
                    string binganID = c1FlexGrid1_jibenyaoqiu[i, 1].ToString();//扣分项的ID
                    string binganKoufen = c1FlexGrid1_jibenyaoqiu[i, 3].ToString();//扣分项分值
                    string binganLiyou = c1FlexGrid1_jibenyaoqiu[i, 4].ToString();//扣分原因
                    string dosID = App.UserAccount.UserInfo.User_id;//医生ID
                    string dosName = App.UserAccount.UserInfo.User_name;//医生姓名
                    string operateSection = App.UserAccount.CurrentSelectRole.Section_name == null ? "" : App.UserAccount.CurrentSelectRole.Section_name;
                    if (App.UserAccount.CurrentSelectRole.Role_type.Trim() == "Z" && App.UserAccount.CurrentSelectRole.Role_name.Contains("质控科"))
                    {//是否是质控科室
                        operateSection = "质控科";
                    }
                    else if (App.UserAccount.CurrentSelectRole.Role_type.Trim() == "Y" && App.UserAccount.CurrentSelectRole.Role_name.Contains("医务科"))
                    {//是否是医务科室
                        operateSection = "医务科";
                    }
                    string insertupdateSQL = "";//定义要执行的sql语句
                    if (pingfenId == "" && pid != "")
                    {
                        insertupdateSQL = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                            "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,PATIENT_ID,OPERATE_SECTION) values('" + pid + "','" + binganID +
                        "','" + binganKoufen + "','" + binganLiyou + "',60,'" + dosID +
                        "','" + dosName + "','" + zongSum + "'," + time + ",'" + id + "','" + operateSection + "')";
                        list.Add(insertupdateSQL);
                    }
                    else
                    {
                        string insert = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                        "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,PATIENT_ID,OPERATE_SECTION) values('" + pingfenId + "','" + binganID +
                    "','" + binganKoufen + "','" + binganLiyou + "',60,'" + dosID +
                    "','" + dosName + "','" + zongSum + "',to_timestamp('" + pingfenTime + "','yyyy-MM-dd HH24:mi:ss'),'" + id + "','" + operateSection + "') ";
                        if (App.ExecuteSQL(insert) > 0)
                            this.Close();
                    }
                }
            }



            //循环出院（死亡）记录的每一项添加到表里面
            for (int i = 1; i < this.c1FlexGrid1_chuyuansiwang.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_chuyuansiwang[i, 3].ToString() != "")
                {
                    string binganID = c1FlexGrid1_chuyuansiwang[i, 1].ToString();//扣分项的ID
                    string binganKoufen = c1FlexGrid1_chuyuansiwang[i, 3].ToString();//扣分项分值
                    string binganLiyou = c1FlexGrid1_chuyuansiwang[i, 4].ToString();//扣分原因
                    string dosID = App.UserAccount.UserInfo.User_id;//医生ID
                    string dosName = App.UserAccount.UserInfo.User_name;//医生姓名
                    string operateSection = App.UserAccount.CurrentSelectRole.Section_name == null ? "" : App.UserAccount.CurrentSelectRole.Section_name;
                    if (App.UserAccount.CurrentSelectRole.Role_type.Trim() == "Z" && App.UserAccount.CurrentSelectRole.Role_name.Contains("质控科"))
                    {//是否是质控科室
                        operateSection = "质控科";
                    }
                    else if (App.UserAccount.CurrentSelectRole.Role_type.Trim() == "Y" && App.UserAccount.CurrentSelectRole.Role_name.Contains("医务科"))
                    {//是否是医务科室
                        operateSection = "医务科";
                    }
                    string insertupdateSQL = "";//定义要执行的sql语句
                    if (pingfenId == "" && pid != "")
                    {
                        insertupdateSQL = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                            "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,PATIENT_ID,OPERATE_SECTION) values('" + pid + "','" + binganID +
                        "','" + binganKoufen + "','" + binganLiyou + "',61,'" + dosID +
                        "','" + dosName + "','" + zongSum + "'," + time + ",'" + id + "','" + operateSection + "')";
                        list.Add(insertupdateSQL);
                    }
                    else
                    {
                        string insert = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                        "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,PATIENT_ID,OPERATE_SECTION) values('" + pingfenId + "','" + binganID +
                    "','" + binganKoufen + "','" + binganLiyou + "',61,'" + dosID +
                    "','" + dosName + "','" + zongSum + "',to_timestamp('" + pingfenTime + "','yyyy-MM-dd HH24:mi:ss'),'" + id + "','" + operateSection + "') ";
                        if (App.ExecuteSQL(insert) > 0)
                            this.Close();
                    }
                }
            }



            //循环辅助检查的每一项添加到表里面
            for (int i = 1; i < this.c1FlexGrid1_fuzhujiancha.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_fuzhujiancha[i, 3].ToString() != "")
                {
                    string binganID = c1FlexGrid1_fuzhujiancha[i, 1].ToString();//扣分项的ID
                    string binganKoufen = c1FlexGrid1_fuzhujiancha[i, 3].ToString();//扣分项分值
                    string binganLiyou = c1FlexGrid1_fuzhujiancha[i, 4].ToString();//扣分原因
                    string dosID = App.UserAccount.UserInfo.User_id;//医生ID
                    string dosName = App.UserAccount.UserInfo.User_name;//医生姓名
                    string operateSection = App.UserAccount.CurrentSelectRole.Section_name == null ? "" : App.UserAccount.CurrentSelectRole.Section_name;
                    if (App.UserAccount.CurrentSelectRole.Role_type.Trim() == "Z" && App.UserAccount.CurrentSelectRole.Role_name.Contains("质控科"))
                    {//是否是质控科室
                        operateSection = "质控科";
                    }
                    else if (App.UserAccount.CurrentSelectRole.Role_type.Trim() == "Y" && App.UserAccount.CurrentSelectRole.Role_name.Contains("医务科"))
                    {//是否是医务科室
                        operateSection = "医务科";
                    }
                    string insertupdateSQL = "";//定义要执行的sql语句
                    if (pingfenId == "" && pid != "")
                    {
                        insertupdateSQL = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                            "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,PATIENT_ID,OPERATE_SECTION) values('" + pid + "','" + binganID +
                        "','" + binganKoufen + "','" + binganLiyou + "',62,'" + dosID +
                        "','" + dosName + "','" + zongSum + "'," + time + ",'" + id + "','" + operateSection + "')";
                        list.Add(insertupdateSQL);
                    }
                    else
                    {
                        string insert = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                        "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,PATIENT_ID,OPERATE_SECTION) values('" + pingfenId + "','" + binganID +
                    "','" + binganKoufen + "','" + binganLiyou + "',62,'" + dosID +
                    "','" + dosName + "','" + zongSum + "',to_timestamp('" + pingfenTime + "','yyyy-MM-dd HH24:mi:ss'),'" + id + "','" + operateSection + "') ";
                        if (App.ExecuteSQL(insert) > 0)
                            this.Close();
                    }
                }
            }



            //循环知情同意的每一项添加到表里面
            for (int i = 1; i < this.c1FlexGrid1_zhiqingtongyi.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_zhiqingtongyi[i, 3].ToString() != "")
                {
                    string binganID = c1FlexGrid1_zhiqingtongyi[i, 1].ToString();//扣分项的ID
                    string binganKoufen = c1FlexGrid1_zhiqingtongyi[i, 3].ToString();//扣分项分值
                    string binganLiyou = c1FlexGrid1_zhiqingtongyi[i, 4].ToString();//扣分原因
                    string dosID = App.UserAccount.UserInfo.User_id;//医生ID
                    string dosName = App.UserAccount.UserInfo.User_name;//医生姓名
                    string operateSection = App.UserAccount.CurrentSelectRole.Section_name == null ? "" : App.UserAccount.CurrentSelectRole.Section_name;
                    if (App.UserAccount.CurrentSelectRole.Role_type.Trim() == "Z" && App.UserAccount.CurrentSelectRole.Role_name.Contains("质控科"))
                    {//是否是质控科室
                        operateSection = "质控科";
                    }
                    else if (App.UserAccount.CurrentSelectRole.Role_type.Trim() == "Y" && App.UserAccount.CurrentSelectRole.Role_name.Contains("医务科"))
                    {//是否是医务科室
                        operateSection = "医务科";
                    }
                    string insertupdateSQL = "";//定义要执行的sql语句
                    if (pingfenId == "" && pid != "")
                    {
                        insertupdateSQL = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                            "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,PATIENT_ID,OPERATE_SECTION) values('" + pid + "','" + binganID +
                        "','" + binganKoufen + "','" + binganLiyou + "',63,'" + dosID +
                        "','" + dosName + "','" + zongSum + "'," + time + ",'" + id + "','" + operateSection + "')";
                        list.Add(insertupdateSQL);
                    }
                    else
                    {
                        string insert = "insert into t_doc_grade(pid,item_id,down_point,down_reason," +
                        "item_big,grade_doc_id,grade_doc_name,sum_point,grade_time,PATIENT_ID,OPERATE_SECTION) values('" + pingfenId + "','" + binganID +
                    "','" + binganKoufen + "','" + binganLiyou + "',63,'" + dosID +
                    "','" + dosName + "','" + zongSum + "',to_timestamp('" + pingfenTime + "','yyyy-MM-dd HH24:mi:ss'),'" + id + "','" + operateSection + "') ";
                        if (App.ExecuteSQL(insert) > 0)
                            this.Close();
                    }
                }
            }

            //当没扣分时
            if (list.Count == 0)
            {
                string dosID = App.UserAccount.UserInfo.User_id;//医生ID
                string dosName = App.UserAccount.UserInfo.User_name;//医生姓名
                string operateSection = App.UserAccount.CurrentSelectRole.Section_name == null ? "" : App.UserAccount.CurrentSelectRole.Section_name;
                if (App.UserAccount.CurrentSelectRole.Role_type.Trim() == "Z" && App.UserAccount.CurrentSelectRole.Role_name.Contains("质控科"))
                {//是否是质控科室
                    operateSection = "质控科";
                }
                else if (App.UserAccount.CurrentSelectRole.Role_type.Trim() == "Y" && App.UserAccount.CurrentSelectRole.Role_name.Contains("医务科"))
                {//是否是医务科室
                    operateSection = "医务科";
                }
                string insertupdateSQL = "";//定义要执行的sql语句
                if (pingfenId == "" && pid != "")
                {
                    insertupdateSQL = "insert into t_doc_grade(pid," +
                        "grade_doc_id,grade_doc_name,sum_point,grade_time,PATIENT_ID,OPERATE_SECTION) values('" + pid + "','" + dosID +
                    "','" + dosName + "','" + zongSum + "'," + time + ",'" + id + "','" + operateSection + "')";
                    list.Add(insertupdateSQL);
                }
                else
                {
                    string insert = "insert into t_doc_grade(pid," +
                    "grade_doc_id,grade_doc_name,sum_point,grade_time,PATIENT_ID,OPERATE_SECTION) values('" + pingfenId + "','" + dosID +
                "','" + dosName + "','" + zongSum + "',to_timestamp('" + pingfenTime + "','yyyy-MM-dd HH24:mi:ss'),'" + id + "','" + operateSection + "') ";
                    if (App.ExecuteSQL(insert) > 0)
                        this.Close();
                }
            }
            if (fmgr == null)
            {
                return;
            }
            else
            {
                //把所有的评分项目的插入语句用list保存起来
                
                fmgr.addPingFen(list);
            }
            this.Close();
            #endregion
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}