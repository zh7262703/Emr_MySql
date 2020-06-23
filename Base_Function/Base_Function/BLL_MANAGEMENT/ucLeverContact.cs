using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Bifrost;

namespace Base_Function.BLL_MANAGEMENT
{
    public partial class ucLeverContact : UserControl
    {
        public ucLeverContact()
        {
            InitializeComponent();
        }

        public ucLeverContact(string LeverStr)
        {
            InitializeComponent();
            lblLever.Text = LeverStr;
        }
        /// <summary>
        /// 用户控件上有些地方不同要进行传值改动
        /// </summary>
        /// <param name="LeverStr">手术名称</param>
        /// <param name="typeOPS">特殊手术标志</param>
        /// <param name="size">字体大小</param>
        public ucLeverContact(string LeverStr, string typeOPS, int size) 
        {
            InitializeComponent();
            lblLever.Text = LeverStr;
            labTypeOPS.Text = typeOPS;
            this.lblLever.Font = new Font("宋体", size);
        }
        //与医生等级关联住院医师
        private void cboxInfrominhospitalPhysician_click(object sender, EventArgs e)
        {
            //定义点击时的CheckBox
            CheckBox tempchkbox = (CheckBox)sender;
            #region 与医生通知等级关联
            //如果这个CheckBox是cbox_noticeLever_1
            if (tempchkbox.Name.Contains("cbox_noticeLever_1"))
            {
                //如果这个CheckBox是住院医师
                if (tempchkbox.Name == "cbox_noticeLever_1")
                {
                    //那么他的两个子项都要选中
                    cbox_noticeLever_1_l.Checked = tempchkbox.Checked;
                    cbox_noticeLever_1_h.Checked = tempchkbox.Checked;
                }
                else
                {
                    //如果两个子项都不选中
                    if (cbox_noticeLever_1_l.Checked == false && cbox_noticeLever_1_h.Checked == false)
                    {
                        //父项也不选中
                        cbox_noticeLever_1.Checked = false;
                    }
                    else
                    {
                        //子项有一个选中，父项都要选中
                        cbox_noticeLever_1.Checked = true;
                    }
                }
            }
            else if (tempchkbox.Name.Contains("cbox_noticeLever_2")) //如果这个CheckBox是cbox_noticeLever_2
            {
                //如果这个CheckBox是主治医师
                if (tempchkbox.Name == "cbox_noticeLever_2")
                {
                    //那么他的两个子项都要选中
                    cbox_noticeLever_2_l.Checked = tempchkbox.Checked;
                    cbox_noticeLever_2_h.Checked = tempchkbox.Checked;
                }
                else
                {
                    //如果两个子项都不选中
                    if (cbox_noticeLever_2_l.Checked == false && cbox_noticeLever_2_h.Checked == false)
                    {
                        //父项也不选中
                        cbox_noticeLever_2.Checked = false;
                    }
                    else
                    {
                        //子项有一个选中，父项都要选中
                        cbox_noticeLever_2.Checked = true;
                    }
                }
            }
            else if (tempchkbox.Name.Contains("cbox_noticeLever_3"))
            {
                if (tempchkbox.Name == "cbox_noticeLever_3")
                {
                    cbox_noticeLever_3_l.Checked = tempchkbox.Checked;
                    cbox_noticeLever_3_h.Checked = tempchkbox.Checked;
                }
                else
                {
                    if (cbox_noticeLever_3_l.Checked == false && cbox_noticeLever_3_h.Checked == false)
                    {
                        cbox_noticeLever_3.Checked = false;
                    }
                    else
                    {
                        cbox_noticeLever_3.Checked = true;
                    }
                }
            }
            else if (tempchkbox.Name.Contains("cbox_noticeLever_4"))
            {
                if (tempchkbox.Name == "cbox_noticeLever_4")
                {
                    cbox_noticeLever_4_l.Checked = tempchkbox.Checked;
                    cbox_noticeLever_4_h.Checked = tempchkbox.Checked;
                }
                else
                {
                    if (cbox_noticeLever_4_l.Checked == false && cbox_noticeLever_4_h.Checked == false)
                    {
                        cbox_noticeLever_4.Checked = false;
                    }
                    else
                    {
                        cbox_noticeLever_4.Checked = true;
                    }
                }
            }
            #endregion
            #region 与医生等级关联
            if (tempchkbox.Name.Contains("cbox_GradeLever_1"))
            {
                if (tempchkbox.Name == "cbox_GradeLever_1")
                {

                    cbox_GradeLever_1_l.Checked = tempchkbox.Checked;
                    cbox_GradeLever_1_h.Checked = tempchkbox.Checked;
                }
                else
                {
                    if (cbox_GradeLever_1_l.Checked == false && cbox_GradeLever_1_h.Checked == false)
                    {
                        cbox_GradeLever_1.Checked = false;
                    }
                    else
                    {
                        cbox_GradeLever_1.Checked = true;
                    }
                }
            }
            else if (tempchkbox.Name.Contains("cbox_GradeLever_2"))
            {
                if (tempchkbox.Name == "cbox_GradeLever_2")
                {
                    cbox_GradeLever_2_l.Checked = tempchkbox.Checked;
                    cbox_GradeLever_2_h.Checked = tempchkbox.Checked;
                }
                else
                {
                    if (cbox_GradeLever_2_l.Checked == false && cbox_GradeLever_2_h.Checked == false)
                    {
                        cbox_GradeLever_2.Checked = false;
                    }
                    else
                    {
                        cbox_GradeLever_2.Checked = true;
                    }
                }
            }
            else if (tempchkbox.Name.Contains("cbox_GradeLever_3"))
            {
                if (tempchkbox.Name == "cbox_GradeLever_3")
                {
                    cbox_GradeLever_3_l.Checked = tempchkbox.Checked;
                    cbox_GradeLever_3_h.Checked = tempchkbox.Checked;
                }
                else
                {
                    if (cbox_GradeLever_3_l.Checked == false && cbox_GradeLever_3_h.Checked == false)
                    {
                        cbox_GradeLever_3.Checked = false;
                    }
                    else
                    {
                        cbox_GradeLever_3.Checked = true;
                    }
                }
            }
            else if (tempchkbox.Name.Contains("cbox_GradeLever_4"))
            {
                if (tempchkbox.Name == "cbox_GradeLever_4")
                {
                    cbox_GradeLever_4_l.Checked = tempchkbox.Checked;
                    cbox_GradeLever_4_h.Checked = tempchkbox.Checked;
                }
                else
                {
                    if (cbox_GradeLever_4_l.Checked == false && cbox_GradeLever_4_h.Checked == false)
                    {
                        cbox_GradeLever_4.Checked = false;
                    }
                    else
                    {
                        cbox_GradeLever_4.Checked = true;
                    }
                }
            }
        }
            #endregion
        //}
        //Dictionary<int, bool[]> Checks = new Dictionary<int, bool[]>();

        //public Dictionary<int, bool[]> GetCheckedValues() 
        //{
        //    Checks.Clear();
        //    Checks.Add(1, new bool[] { this.cbox_noticeLever_1.Checked, this.cbox_noticeLever_1_l.Checked, this.cbox_noticeLever_1_h.Checked });
        //    Checks.Add(2, new bool[] { this.cbox_noticeLever_2.Checked, this.cbox_noticeLever_2_l.Checked, this.cbox_noticeLever_2_h.Checked });
        //    Checks.Add(3, new bool[] { this.cbox_noticeLever_3.Checked, this.cbox_noticeLever_3_l.Checked, this.cbox_noticeLever_3_h.Checked });
        //    Checks.Add(4, new bool[] { this.cbox_noticeLever_4.Checked, this.cbox_noticeLever_4_l.Checked, this.cbox_noticeLever_4_h.Checked });
        //    Checks.Add(5, new bool[] { this.cbox_GradeLever_1.Checked, this.cbox_GradeLever_1_l.Checked, this.cbox_GradeLever_1_h.Checked });
        //    Checks.Add(6, new bool[] { this.cbox_GradeLever_2.Checked, this.cbox_GradeLever_2_l.Checked, this.cbox_GradeLever_2_h.Checked });
        //    Checks.Add(7, new bool[] { this.cbox_GradeLever_3.Checked, this.cbox_GradeLever_3_l.Checked, this.cbox_GradeLever_3_h.Checked });
        //    Checks.Add(8, new bool[] { this.cbox_GradeLever_4.Checked, this.cbox_GradeLever_4_l.Checked, this.cbox_GradeLever_4_h.Checked });

        //    Checks.Add(9, new bool[] { this.cbo_ZhiCheng_zhuZhiyisheng.Checked, this.cbox_ZhiCheng_fuZhuRen.Checked, this.cbox_ZhiCheng_ZhuRen.Checked });
        //    Checks.Add(10, new bool[] { this.cbox_zhiWu_kefuZhuren.Checked, this.cbox_ZhiWu_KeZhuRen.Checked, this.cbox_Zhiwu_YiWuKeZhuRen.Checked, this.cbox_zhiwu_YeWuFuYuanZhang.Checked, this.cbox_zhiwu_Yuanzhang.Checked });
        //    return Checks;

        //} 

        /// <summary>
        /// 设置数据库操作语句 手术等级 甲乙丙丁设定
        /// </summary>
        /// <param name="Sqllist">存储增加插入语句和删除语句</param>
        public void getInsertSql(ref ArrayList Sqllist)
        {
            string Sql = "";//要执行的sql语句
            string notice = "";//与医生通知等级关联
            string lever = "";//与医生等级关联
            string shenpi_zhichen = "";//审批职称
            string shenpi_zhiwu = "";//审批职务

            #region 与医生通知等级关联
            if (this.cbox_noticeLever_1_l.Checked)
            {
                notice = "1_l" + ";";
            }
            if (this.cbox_noticeLever_1_h.Checked)
            {
                notice = notice + "1_h" + ";";
            }
            if (this.cbox_noticeLever_2_l.Checked)
            {
                notice = notice + "2_l" + ";";
            }
            if (this.cbox_noticeLever_2_h.Checked)
            {
                notice = notice + "2_h" + ";";
            }
            if (this.cbox_noticeLever_3_l.Checked)
            {
                notice = notice + "3_l" + ";";
            }
            if (this.cbox_noticeLever_3_h.Checked)
            {
                notice = notice + "3_h" + ";";
            }
            if (this.cbox_noticeLever_4_l.Checked)
            {
                notice = notice + "4_l" + ";";
            }
            if (this.cbox_noticeLever_4_h.Checked)
            {
                notice = notice + "4_h" + ";";
            }
            #endregion

            #region 与医生等级关联
            if (this.cbox_GradeLever_1_l.Checked)
            {
                lever = "1_l" + ";";
            }
            if (this.cbox_GradeLever_1_h.Checked)
            {
                lever = lever + "1_h" + ";";
            }
            if (this.cbox_GradeLever_2_l.Checked)
            {
                lever = lever + "2_l" + ";";
            }
            if (this.cbox_GradeLever_2_h.Checked)
            {
                lever = lever + "2_h" + ";";
            }
            if (this.cbox_GradeLever_3_l.Checked)
            {
                lever = lever + "3_l" + ";";
            }
            if (this.cbox_GradeLever_3_h.Checked)
            {
                lever = lever + "3_h" + ";";
            }
            if (this.cbox_GradeLever_4_l.Checked)
            {
                lever = lever + "4_l" + ";";
            }
            if (this.cbox_GradeLever_4_h.Checked)
            {
                lever = lever + "4_h" + ";";
            }
            #endregion

            #region 与审批等级关联
            /*
             * 职称
             */
            if (cbox_shenpi_1_2.Checked)
            {
                shenpi_zhichen = "2" + ";";
            }
            if (cbox_shenpi_1_3.Checked)
            {
                shenpi_zhichen = shenpi_zhichen + "3" + ";";
            }
            if (cbox_shenpi_1_4.Checked)
            {
                shenpi_zhichen = shenpi_zhichen + "4" + ";";
            }

            /*
             * 职务
             */
            if (cbox_shenpi_2_23.Checked)
            {
                shenpi_zhiwu = "23" + ";";
            }
            if (cbox_shenpi_2_22.Checked)
            {
                shenpi_zhiwu = shenpi_zhiwu + "22" + ";";
            }
            if (cbox_shenpi_2_217.Checked)
            {
                shenpi_zhiwu = shenpi_zhiwu + "217" + ";";
            }
            if (cbox_shenpi_2_32.Checked)
            {
                shenpi_zhiwu = shenpi_zhiwu + "32" + ";";
            }
            if (cbox_shenpi_2_31.Checked)
            {
                shenpi_zhiwu = shenpi_zhiwu + "31" + ";";
            }
            #endregion

            Sql = "insert into T_OPER_LEVEL_RELA(OPER_LEVEL,RELA_TOSENDDOC_LEVEL,RELA_DOC_LEVEL,RELA_APPR_TITLE,RELA_APPR_POSITION,RECORD_TIME,RECORD_BY_ID,RECORDBY_NAME)values('" + lblLever.Text + "','" +
                notice + "','" + lever + "','" + shenpi_zhichen + "','" + shenpi_zhiwu + "',sysdate,'" + App.UserAccount.UserInfo.User_id + "','" + App.UserAccount.UserInfo.User_name + "')";
            //手术等级设定
            Sqllist.Add(Sql);
        }

        //ref ArrayList Sqllist, 
        /// <summary>
        /// 插入特殊手术关联的医生
        /// </summary>
        public void getInsertTeShuSql()
        {
            string Sql = "";//要执行的sql语句
            string notice = "";//与医生通知等级关联
            string lever = "";//与医生等级关联
            string shenpi_zhichen = "";//审批职称
            string shenpi_zhiwu = "";//审批职务

            //等级
            //lblLever.Text;

            #region 与医生通知等级关联
            if (this.cbox_noticeLever_1_l.Checked)
            {
                notice = "1_l" + ";";
            }
            if (this.cbox_noticeLever_1_h.Checked)
            {
                notice = notice + "1_h" + ";";
            }
            if (this.cbox_noticeLever_2_l.Checked)
            {
                notice = notice + "2_l" + ";";
            }
            if (this.cbox_noticeLever_2_h.Checked)
            {
                notice = notice + "2_h" + ";";
            }
            if (this.cbox_noticeLever_3_l.Checked)
            {
                notice = notice + "3_l" + ";";
            }
            if (this.cbox_noticeLever_3_h.Checked)
            {
                notice = notice + "3_h" + ";";
            }
            if (this.cbox_noticeLever_4_l.Checked)
            {
                notice = notice + "4_l" + ";";
            }
            if (this.cbox_noticeLever_4_h.Checked)
            {
                notice = notice + "4_h" + ";";
            }
            #endregion

            #region 与医生等级关联
            if (this.cbox_GradeLever_1_l.Checked)
            {
                lever = "1_l" + ";";
            }
            if (this.cbox_GradeLever_1_h.Checked)
            {
                lever = lever + "1_h" + ";";
            }
            if (this.cbox_GradeLever_2_l.Checked)
            {
                lever = lever + "2_l" + ";";
            }
            if (this.cbox_GradeLever_2_h.Checked)
            {
                lever = lever + "2_h" + ";";
            }
            if (this.cbox_GradeLever_3_l.Checked)
            {
                lever = lever + "3_l" + ";";
            }
            if (this.cbox_GradeLever_3_h.Checked)
            {
                lever = lever + "3_h" + ";";
            }
            if (this.cbox_GradeLever_4_l.Checked)
            {
                lever = lever + "4_l" + ";";
            }
            if (this.cbox_GradeLever_4_h.Checked)
            {
                lever = lever + "4_h" + ";";
            }
            #endregion

            #region 与审批等级关联
            /*
             * 职称
             */
            if (cbox_shenpi_1_2.Checked)
            {
                shenpi_zhichen = "2" + ";";
            }
            if (cbox_shenpi_1_3.Checked)
            {
                shenpi_zhichen = shenpi_zhichen + "3" + ";";
            }
            if (cbox_shenpi_1_4.Checked)
            {
                shenpi_zhichen = shenpi_zhichen + "4" + ";";
            }

            /*
             * 职务
             */
            if (cbox_shenpi_2_23.Checked)
            {
                shenpi_zhiwu = "23" + ";";
            }
            if (cbox_shenpi_2_22.Checked)
            {
                shenpi_zhiwu = shenpi_zhiwu + "22" + ";";
            }
            if (cbox_shenpi_2_217.Checked)
            {
                shenpi_zhiwu = shenpi_zhiwu + "217" + ";";
            }
            if (cbox_shenpi_2_32.Checked)
            {
                shenpi_zhiwu = shenpi_zhiwu + "32" + ";";
            }
            if (cbox_shenpi_2_31.Checked)
            {
                shenpi_zhiwu = shenpi_zhiwu + "31" + ";";
            }
            #endregion

            Sql = "insert into T_SPECIALOPER_LEVEL_RELA(oper_levelid, rela_tosenddoc_level, rela_doc_level," +
                " rela_appr_title, rela_appr_position, record_by_id, recordby_name, record_time) " +
                "values('" + this.Tag.ToString() + "','" + notice + "','" + lever + "','" + shenpi_zhichen +
                "','" + shenpi_zhiwu + "','" + App.UserAccount.UserInfo.User_id +
                "','" + App.UserAccount.UserInfo.User_name + "',sysdate)";

            App.ExecuteSQL(Sql);
        }
        /// <summary>
        /// 加载出来的时候看那些是被选中了的，就Checked 让他为true
        /// </summary>
        public void SetChecked()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string querySQL = "select rela_tosenddoc_level as 医生通知,rela_doc_level as 医生等级,rela_appr_title as 职称,rela_appr_position as 职务 from T_OPER_LEVEL_RELA WHERE oper_level = '" + this.lblLever.Text.Trim() + "'";
            ds = App.GetDataSet(querySQL);
            dt = ds.Tables[0];

            string notice = "";//与医生通知有关
            string lever = "";//医生等级
            string shenpi_zhichen = "";//职称
            string shnpi_zhiwu = "";//职务
            string noteceChecked = "";//医生通知选中
            string leverChecked = "";//医生等级选中
            string shenpi_zhichenChecked = "";//职称选中
            string shenpi_wuChecked = "";//职务选中 
            if (ds.Tables[0].Rows.Count > 0)
            {
                notice = dt.Rows[0]["医生通知"].ToString();
                lever = dt.Rows[0]["医生等级"].ToString();
                shenpi_zhichen = dt.Rows[0]["职称"].ToString();
                shnpi_zhiwu = dt.Rows[0]["职务"].ToString();
                #region 与医生通知有关
                for (int j = 0; j < notice.Split(';').Length; j++)
                {

                    noteceChecked = notice.Split(';')[j];
                    if (noteceChecked == "1_l")
                    {
                        cbox_noticeLever_1_l.Checked = true;
                    }
                    if (noteceChecked == "1_h")
                    {
                        cbox_noticeLever_1_h.Checked = true;
                    }
                    if (cbox_noticeLever_1_l.Checked == true || cbox_noticeLever_1_h.Checked == true)
                    {
                        cbox_noticeLever_1.Checked = true;
                    }

                    if (noteceChecked == "2_l")
                    {
                        cbox_noticeLever_2_l.Checked = true;
                    }
                    if (noteceChecked == "2_h")
                    {
                        cbox_noticeLever_2_h.Checked = true;
                    }
                    if (cbox_noticeLever_2_l.Checked == true || cbox_noticeLever_2_h.Checked == true)
                    {
                        cbox_noticeLever_2.Checked = true;
                    }
                    if (noteceChecked == "3_l")
                    {
                        cbox_noticeLever_3_l.Checked = true;
                    }
                    if (noteceChecked == "3_h")
                    {
                        cbox_noticeLever_3_h.Checked = true;
                    }
                    if (cbox_noticeLever_3_l.Checked == true || cbox_noticeLever_3_h.Checked == true)
                    {
                        cbox_noticeLever_3.Checked = true;
                    }
                    if (noteceChecked == "4_l")
                    {
                        cbox_noticeLever_4_l.Checked = true;
                    }
                    if (noteceChecked == "4_h")
                    {
                        cbox_noticeLever_4_h.Checked = true;
                    }
                    if (cbox_noticeLever_4_l.Checked == true || cbox_noticeLever_4_h.Checked == true)
                    {
                        cbox_noticeLever_4.Checked = true;
                    }
                }
                #endregion
                #region 与医生等级有关
                for (int k = 0; k < lever.Split(';').Length; k++)
                {

                    leverChecked = lever.Split(';')[k];
                    if (leverChecked == "1_l")
                    {
                        cbox_GradeLever_1_l.Checked = true;
                    }
                    if (leverChecked == "1_h")
                    {
                        cbox_GradeLever_1_h.Checked = true;
                    }
                    if (cbox_GradeLever_1_l.Checked == true || cbox_GradeLever_1_h.Checked == true)
                    {
                        cbox_GradeLever_1.Checked = true;
                    }
                    if (leverChecked == "2_l")
                    {
                        cbox_GradeLever_2_l.Checked = true;
                    }
                    if (leverChecked == "2_h")
                    {
                        cbox_GradeLever_2_h.Checked = true;
                    }
                    if (cbox_GradeLever_2_l.Checked == true || cbox_GradeLever_2_h.Checked == true)
                    {
                        cbox_GradeLever_2.Checked = true;
                    }
                    if (leverChecked == "3_l")
                    {
                        cbox_GradeLever_3_l.Checked = true;
                    }
                    if (leverChecked == "3_h")
                    {
                        cbox_GradeLever_3_h.Checked = true;
                    }
                    if (cbox_GradeLever_3_l.Checked == true || cbox_GradeLever_3_h.Checked == true)
                    {
                        cbox_GradeLever_3.Checked = true;
                    }
                    if (leverChecked == "4_l")
                    {
                        cbox_GradeLever_4_l.Checked = true;
                    }
                    if (leverChecked == "4_h")
                    {
                        cbox_GradeLever_4_h.Checked = true;
                    }
                    if (cbox_GradeLever_4_l.Checked == true || cbox_GradeLever_4_h.Checked == true)
                    {
                        cbox_GradeLever_4.Checked = true;
                    }
                }
                #endregion
                #region 与审批职称有关
                for (int h = 0; h < shenpi_zhichen.Split(';').Length; h++)
                {
                    shenpi_zhichenChecked = shenpi_zhichen.Split(';')[h];
                    if (shenpi_zhichenChecked == "2")
                    {
                        cbox_shenpi_1_2.Checked = true;
                    }
                    if (shenpi_zhichenChecked == "3")
                    {
                        cbox_shenpi_1_3.Checked = true;
                    }
                    if (shenpi_zhichenChecked == "4")
                    {
                        cbox_shenpi_1_4.Checked = true;
                    }
                }
                #endregion
                #region 与审批职务有关
                for (int l = 0; l < shnpi_zhiwu.Split(';').Length; l++)
                {
                    shenpi_wuChecked = shnpi_zhiwu.Split(';')[l];
                    if (shenpi_wuChecked == "23")
                    {
                        cbox_shenpi_2_23.Checked = true;
                    }
                    if (shenpi_wuChecked == "22")
                    {
                        cbox_shenpi_2_22.Checked = true;
                    }
                    if (shenpi_wuChecked == "217")
                    {
                        cbox_shenpi_2_217.Checked = true;
                    }
                    if (shenpi_wuChecked == "32")
                    {
                        cbox_shenpi_2_32.Checked = true;
                    }
                    if (shenpi_wuChecked == "31")
                    {
                        cbox_shenpi_2_31.Checked = true;
                    }
                }
                #endregion
            }
        }

        /// <summary>
        /// 设置特殊手术关联的医生加载时选中
        /// </summary>
        /// <param name="id">主键</param>
        public void SetTeShuChecked(string id)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string querySQL = "select rela_tosenddoc_level as 医生通知,rela_doc_level as 医生等级,rela_appr_title as 职称,rela_appr_position as 职务 from T_SPECIALOPER_LEVEL_RELA WHERE oper_levelid = '" + id + "'";
            ds = App.GetDataSet(querySQL);
            dt = ds.Tables[0];

            string notice = "";//与医生通知有关
            string lever = "";//医生等级
            string shenpi_zhichen = "";//职称
            string shnpi_zhiwu = "";//职务
            string noteceChecked = "";//医生通知选中
            string leverChecked = "";//医生等级选中
            string shenpi_zhichenChecked = "";//职称选中
            string shenpi_wuChecked = "";//职务选中 
            if (ds.Tables[0].Rows.Count > 0)
            {
                notice = dt.Rows[0]["医生通知"].ToString();
                lever = dt.Rows[0]["医生等级"].ToString();
                shenpi_zhichen = dt.Rows[0]["职称"].ToString();
                shnpi_zhiwu = dt.Rows[0]["职务"].ToString();
                #region 与医生通知有关
                for (int j = 0; j < notice.Split(';').Length; j++)
                {

                    noteceChecked = notice.Split(';')[j];
                    if (noteceChecked == "1_l")
                    {
                        cbox_noticeLever_1_l.Checked = true;
                    }
                    if (noteceChecked == "1_h")
                    {
                        cbox_noticeLever_1_h.Checked = true;
                    }
                    if (cbox_noticeLever_1_l.Checked == true || cbox_noticeLever_1_h.Checked == true)
                    {
                        cbox_noticeLever_1.Checked = true;
                    }

                    if (noteceChecked == "2_l")
                    {
                        cbox_noticeLever_2_l.Checked = true;
                    }
                    if (noteceChecked == "2_h")
                    {
                        cbox_noticeLever_2_h.Checked = true;
                    }
                    if (cbox_noticeLever_2_l.Checked == true || cbox_noticeLever_2_h.Checked == true)
                    {
                        cbox_noticeLever_2.Checked = true;
                    }
                    if (noteceChecked == "3_l")
                    {
                        cbox_noticeLever_3_l.Checked = true;
                    }
                    if (noteceChecked == "3_h")
                    {
                        cbox_noticeLever_3_h.Checked = true;
                    }
                    if (cbox_noticeLever_3_l.Checked == true || cbox_noticeLever_3_h.Checked == true)
                    {
                        cbox_noticeLever_3.Checked = true;
                    }
                    if (noteceChecked == "4_l")
                    {
                        cbox_noticeLever_4_l.Checked = true;
                    }
                    if (noteceChecked == "4_h")
                    {
                        cbox_noticeLever_4_h.Checked = true;
                    }
                    if (cbox_noticeLever_4_l.Checked == true || cbox_noticeLever_4_h.Checked == true)
                    {
                        cbox_noticeLever_4.Checked = true;
                    }
                }
                #endregion
                #region 与医生等级有关
                for (int k = 0; k < lever.Split(';').Length; k++)
                {

                    leverChecked = lever.Split(';')[k];
                    if (leverChecked == "1_l")
                    {
                        cbox_GradeLever_1_l.Checked = true;
                    }
                    if (leverChecked == "1_h")
                    {
                        cbox_GradeLever_1_h.Checked = true;
                    }
                    if (cbox_GradeLever_1_l.Checked == true || cbox_GradeLever_1_h.Checked == true)
                    {
                        cbox_GradeLever_1.Checked = true;
                    }
                    if (leverChecked == "2_l")
                    {
                        cbox_GradeLever_2_l.Checked = true;
                    }
                    if (leverChecked == "2_h")
                    {
                        cbox_GradeLever_2_h.Checked = true;
                    }
                    if (cbox_GradeLever_2_l.Checked == true || cbox_GradeLever_2_h.Checked == true)
                    {
                        cbox_GradeLever_2.Checked = true;
                    }
                    if (leverChecked == "3_l")
                    {
                        cbox_GradeLever_3_l.Checked = true;
                    }
                    if (leverChecked == "3_h")
                    {
                        cbox_GradeLever_3_h.Checked = true;
                    }
                    if (cbox_GradeLever_3_l.Checked == true || cbox_GradeLever_3_h.Checked == true)
                    {
                        cbox_GradeLever_3.Checked = true;
                    }
                    if (leverChecked == "4_l")
                    {
                        cbox_GradeLever_4_l.Checked = true;
                    }
                    if (leverChecked == "4_h")
                    {
                        cbox_GradeLever_4_h.Checked = true;
                    }
                    if (cbox_GradeLever_4_l.Checked == true || cbox_GradeLever_4_h.Checked == true)
                    {
                        cbox_GradeLever_4.Checked = true;
                    }
                }
                #endregion
                #region 与审批职称有关
                for (int h = 0; h < shenpi_zhichen.Split(';').Length; h++)
                {
                    shenpi_zhichenChecked = shenpi_zhichen.Split(';')[h];
                    if (shenpi_zhichenChecked == "2")
                    {
                        cbox_shenpi_1_2.Checked = true;
                    }
                    if (shenpi_zhichenChecked == "3")
                    {
                        cbox_shenpi_1_3.Checked = true;
                    }
                    if (shenpi_zhichenChecked == "4")
                    {
                        cbox_shenpi_1_4.Checked = true;
                    }
                }
                #endregion
                #region 与审批职务有关
                for (int l = 0; l < shnpi_zhiwu.Split(';').Length; l++)
                {
                    shenpi_wuChecked = shnpi_zhiwu.Split(';')[l];
                    if (shenpi_wuChecked == "23")
                    {
                        cbox_shenpi_2_23.Checked = true;
                    }
                    if (shenpi_wuChecked == "22")
                    {
                        cbox_shenpi_2_22.Checked = true;
                    }
                    if (shenpi_wuChecked == "217")
                    {
                        cbox_shenpi_2_217.Checked = true;
                    }
                    if (shenpi_wuChecked == "32")
                    {
                        cbox_shenpi_2_32.Checked = true;
                    }
                    if (shenpi_wuChecked == "31")
                    {
                        cbox_shenpi_2_31.Checked = true;
                    }
                }
                #endregion
            }
        }
    }
}

