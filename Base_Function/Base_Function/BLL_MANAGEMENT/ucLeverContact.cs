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
        /// �û��ؼ�����Щ�ط���ͬҪ���д�ֵ�Ķ�
        /// </summary>
        /// <param name="LeverStr">��������</param>
        /// <param name="typeOPS">����������־</param>
        /// <param name="size">�����С</param>
        public ucLeverContact(string LeverStr, string typeOPS, int size) 
        {
            InitializeComponent();
            lblLever.Text = LeverStr;
            labTypeOPS.Text = typeOPS;
            this.lblLever.Font = new Font("����", size);
        }
        //��ҽ���ȼ�����סԺҽʦ
        private void cboxInfrominhospitalPhysician_click(object sender, EventArgs e)
        {
            //������ʱ��CheckBox
            CheckBox tempchkbox = (CheckBox)sender;
            #region ��ҽ��֪ͨ�ȼ�����
            //������CheckBox��cbox_noticeLever_1
            if (tempchkbox.Name.Contains("cbox_noticeLever_1"))
            {
                //������CheckBox��סԺҽʦ
                if (tempchkbox.Name == "cbox_noticeLever_1")
                {
                    //��ô�����������Ҫѡ��
                    cbox_noticeLever_1_l.Checked = tempchkbox.Checked;
                    cbox_noticeLever_1_h.Checked = tempchkbox.Checked;
                }
                else
                {
                    //������������ѡ��
                    if (cbox_noticeLever_1_l.Checked == false && cbox_noticeLever_1_h.Checked == false)
                    {
                        //����Ҳ��ѡ��
                        cbox_noticeLever_1.Checked = false;
                    }
                    else
                    {
                        //������һ��ѡ�У����Ҫѡ��
                        cbox_noticeLever_1.Checked = true;
                    }
                }
            }
            else if (tempchkbox.Name.Contains("cbox_noticeLever_2")) //������CheckBox��cbox_noticeLever_2
            {
                //������CheckBox������ҽʦ
                if (tempchkbox.Name == "cbox_noticeLever_2")
                {
                    //��ô�����������Ҫѡ��
                    cbox_noticeLever_2_l.Checked = tempchkbox.Checked;
                    cbox_noticeLever_2_h.Checked = tempchkbox.Checked;
                }
                else
                {
                    //������������ѡ��
                    if (cbox_noticeLever_2_l.Checked == false && cbox_noticeLever_2_h.Checked == false)
                    {
                        //����Ҳ��ѡ��
                        cbox_noticeLever_2.Checked = false;
                    }
                    else
                    {
                        //������һ��ѡ�У����Ҫѡ��
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
            #region ��ҽ���ȼ�����
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
        /// �������ݿ������� �����ȼ� ���ұ����趨
        /// </summary>
        /// <param name="Sqllist">�洢���Ӳ�������ɾ�����</param>
        public void getInsertSql(ref ArrayList Sqllist)
        {
            string Sql = "";//Ҫִ�е�sql���
            string notice = "";//��ҽ��֪ͨ�ȼ�����
            string lever = "";//��ҽ���ȼ�����
            string shenpi_zhichen = "";//����ְ��
            string shenpi_zhiwu = "";//����ְ��

            #region ��ҽ��֪ͨ�ȼ�����
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

            #region ��ҽ���ȼ�����
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

            #region �������ȼ�����
            /*
             * ְ��
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
             * ְ��
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
            //�����ȼ��趨
            Sqllist.Add(Sql);
        }

        //ref ArrayList Sqllist, 
        /// <summary>
        /// ������������������ҽ��
        /// </summary>
        public void getInsertTeShuSql()
        {
            string Sql = "";//Ҫִ�е�sql���
            string notice = "";//��ҽ��֪ͨ�ȼ�����
            string lever = "";//��ҽ���ȼ�����
            string shenpi_zhichen = "";//����ְ��
            string shenpi_zhiwu = "";//����ְ��

            //�ȼ�
            //lblLever.Text;

            #region ��ҽ��֪ͨ�ȼ�����
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

            #region ��ҽ���ȼ�����
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

            #region �������ȼ�����
            /*
             * ְ��
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
             * ְ��
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
        /// ���س�����ʱ����Щ�Ǳ�ѡ���˵ģ���Checked ����Ϊtrue
        /// </summary>
        public void SetChecked()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string querySQL = "select rela_tosenddoc_level as ҽ��֪ͨ,rela_doc_level as ҽ���ȼ�,rela_appr_title as ְ��,rela_appr_position as ְ�� from T_OPER_LEVEL_RELA WHERE oper_level = '" + this.lblLever.Text.Trim() + "'";
            ds = App.GetDataSet(querySQL);
            dt = ds.Tables[0];

            string notice = "";//��ҽ��֪ͨ�й�
            string lever = "";//ҽ���ȼ�
            string shenpi_zhichen = "";//ְ��
            string shnpi_zhiwu = "";//ְ��
            string noteceChecked = "";//ҽ��֪ͨѡ��
            string leverChecked = "";//ҽ���ȼ�ѡ��
            string shenpi_zhichenChecked = "";//ְ��ѡ��
            string shenpi_wuChecked = "";//ְ��ѡ�� 
            if (ds.Tables[0].Rows.Count > 0)
            {
                notice = dt.Rows[0]["ҽ��֪ͨ"].ToString();
                lever = dt.Rows[0]["ҽ���ȼ�"].ToString();
                shenpi_zhichen = dt.Rows[0]["ְ��"].ToString();
                shnpi_zhiwu = dt.Rows[0]["ְ��"].ToString();
                #region ��ҽ��֪ͨ�й�
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
                #region ��ҽ���ȼ��й�
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
                #region ������ְ���й�
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
                #region ������ְ���й�
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
        /// ������������������ҽ������ʱѡ��
        /// </summary>
        /// <param name="id">����</param>
        public void SetTeShuChecked(string id)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string querySQL = "select rela_tosenddoc_level as ҽ��֪ͨ,rela_doc_level as ҽ���ȼ�,rela_appr_title as ְ��,rela_appr_position as ְ�� from T_SPECIALOPER_LEVEL_RELA WHERE oper_levelid = '" + id + "'";
            ds = App.GetDataSet(querySQL);
            dt = ds.Tables[0];

            string notice = "";//��ҽ��֪ͨ�й�
            string lever = "";//ҽ���ȼ�
            string shenpi_zhichen = "";//ְ��
            string shnpi_zhiwu = "";//ְ��
            string noteceChecked = "";//ҽ��֪ͨѡ��
            string leverChecked = "";//ҽ���ȼ�ѡ��
            string shenpi_zhichenChecked = "";//ְ��ѡ��
            string shenpi_wuChecked = "";//ְ��ѡ�� 
            if (ds.Tables[0].Rows.Count > 0)
            {
                notice = dt.Rows[0]["ҽ��֪ͨ"].ToString();
                lever = dt.Rows[0]["ҽ���ȼ�"].ToString();
                shenpi_zhichen = dt.Rows[0]["ְ��"].ToString();
                shnpi_zhiwu = dt.Rows[0]["ְ��"].ToString();
                #region ��ҽ��֪ͨ�й�
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
                #region ��ҽ���ȼ��й�
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
                #region ������ְ���й�
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
                #region ������ְ���й�
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

