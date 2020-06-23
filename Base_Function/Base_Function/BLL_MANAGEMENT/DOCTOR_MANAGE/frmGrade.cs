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
    /// ��������
    /// </summary>
    /// �޸� ������
    /// �޸�ʱ�� 2013��12��25��
    public partial class frmGrade : DevComponents.DotNetBar.Office2007Form
    {
        ucfrmMainGradeRepart fmgr;
        frmMainSelectHistoryRepart fmshr;
        string id = "";
        string pid = "";
        string suffName = "";

        string pingfenId = "";//��ȡ��������ID
        string pingfenTime = "";//��ȡ��������ʱ��
        //string item_Id = "";//��ȡ��ÿһ���ID

        string doctorID = App.UserAccount.UserInfo.User_id;
        string doctorName = App.UserAccount.UserInfo.User_name;
        public frmGrade(ucfrmMainGradeRepart _fmgr)
        {
            InitializeComponent();
            this.fmgr = _fmgr;
            pid = fmgr.SetPingfen();
            id = fmgr.gid;
            suffName = fmgr.SetSuffererName();
            this.Text = "�� " + suffName + " ��������";

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
            pingfenId = fmshr.SetPingFenPID();//��ȡ��������ID
            pingfenTime = fmshr.SetPingFenTime();//��ȡ��������ʱ��
            //item_Id = fmshr.SetPingFenItem_ID();//��ȡ��ÿһ���ID
            suffName = _fmshr.SetSuffererName();
            this.Text = "�� " + suffName + " ���������޸�";

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
            pingfenId = fgpfid;//��ȡ��������ID
            pingfenTime = fgpfTime;//��ȡ��������ʱ��
            //suffName = _fmshr.SetSuffererName();
            this.Text = "�鿴 " + suffName + " ����������ϸ";
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

        DataTable dtitem_Id;//���ҿ۹��ֵ���Ŀ����
        /// <summary>
        /// ���������鿴�۷������ʾ����
        /// </summary>
        private void SetKouFen()
        {
            /*�ȸ��ݲ���סԺ��������ʱ���ȫ�������ֵ���Ŀ�ҳ���Ȼ����ѭ��ÿһ��c1�ؼ� ���c1�ؼ��������ĿID��
             * item_id��ͬ�Ļ������ǿ۹��ֵģ�����ʾ����Ӧ�ĵ�Ԫ������
             */
            string selectItemIDSQL = "select item_id,down_point,DOWN_REASON from t_doc_grade where pid='" + pingfenId + "' and to_char(grade_time,'yyyy-MM-dd HH24:mi:ss')='" + pingfenTime + "'";
            dtitem_Id = App.GetDataSet(selectItemIDSQL).Tables[0];
            //��һ��ѭ����ѭ����С��Ŀ�۷ֵ�����
            for (int i = 0; i < dtitem_Id.Rows.Count; i++)
            {
                //�ڶ���ѭ����ѭ��c1�ؼ�������ǵ�ID��ͬ���ǿ۷ֵ��� �ѿ۷�ֵ����c1�ؼ��Ŀ۷���
                for (int j = 1; j < c1FlexGrid1_BingAnShouYe.Rows.Count; j++)
                {
                    if (dtitem_Id.Rows[i]["item_id"].ToString() == c1FlexGrid1_BingAnShouYe[j, "ID"].ToString())
                    {
                        c1FlexGrid1_BingAnShouYe[j, "�۷�"] = dtitem_Id.Rows[i]["down_point"].ToString();
                        c1FlexGrid1_BingAnShouYe[j, "����"] = dtitem_Id.Rows[i]["DOWN_REASON"].ToString();
                    }
                }
                //�ڶ���ѭ����ѭ��c1�ؼ�������ǵ�ID��ͬ���ǿ۷ֵ��� �ѿ۷�ֵ����c1�ؼ��Ŀ۷���
                for (int j = 1; j < c1FlexGrid1_ruYuanJilu.Rows.Count; j++)
                {
                    if (dtitem_Id.Rows[i]["item_id"].ToString() == c1FlexGrid1_ruYuanJilu[j, "ID"].ToString())
                    {
                        c1FlexGrid1_ruYuanJilu[j, "�۷�"] = dtitem_Id.Rows[i]["down_point"].ToString();
                        c1FlexGrid1_ruYuanJilu[j, "����"] = dtitem_Id.Rows[i]["DOWN_REASON"].ToString();
                    }
                }
                //�ڶ���ѭ����ѭ��c1�ؼ�������ǵ�ID��ͬ���ǿ۷ֵ��� �ѿ۷�ֵ����c1�ؼ��Ŀ۷���
                for (int j = 1; j < c1FlexGrid1_bingchengjilu.Rows.Count; j++)
                {
                    if (dtitem_Id.Rows[i]["item_id"].ToString() == c1FlexGrid1_bingchengjilu[j, "ID"].ToString())
                    {
                        c1FlexGrid1_bingchengjilu[j, "�۷�"] = dtitem_Id.Rows[i]["down_point"].ToString();
                        c1FlexGrid1_bingchengjilu[j, "����"] = dtitem_Id.Rows[i]["DOWN_REASON"].ToString();
                    }
                }
                //�ڶ���ѭ����ѭ��c1�ؼ�������ǵ�ID��ͬ���ǿ۷ֵ��� �ѿ۷�ֵ����c1�ؼ��Ŀ۷���
                for (int j = 1; j < c1FlexGrid1_jibenyaoqiu.Rows.Count; j++)
                {
                    if (dtitem_Id.Rows[i]["item_id"].ToString() == c1FlexGrid1_jibenyaoqiu[j, "ID"].ToString())
                    {
                        c1FlexGrid1_jibenyaoqiu[j, "�۷�"] = dtitem_Id.Rows[i]["down_point"].ToString();
                        c1FlexGrid1_jibenyaoqiu[j, "����"] = dtitem_Id.Rows[i]["DOWN_REASON"].ToString();
                    }
                }
                //�ڶ���ѭ����ѭ��c1�ؼ�������ǵ�ID��ͬ���ǿ۷ֵ��� �ѿ۷�ֵ����c1�ؼ��Ŀ۷���
                for (int j = 1; j < c1FlexGrid1_chuyuansiwang.Rows.Count; j++)
                {
                    if (dtitem_Id.Rows[i]["item_id"].ToString() == c1FlexGrid1_chuyuansiwang[j, "ID"].ToString())
                    {
                        c1FlexGrid1_chuyuansiwang[j, "�۷�"] = dtitem_Id.Rows[i]["down_point"].ToString();
                        c1FlexGrid1_chuyuansiwang[j, "����"] = dtitem_Id.Rows[i]["DOWN_REASON"].ToString();
                    }
                }
                //�ڶ���ѭ����ѭ��c1�ؼ�������ǵ�ID��ͬ���ǿ۷ֵ��� �ѿ۷�ֵ����c1�ؼ��Ŀ۷���
                for (int j = 1; j < c1FlexGrid1_fuzhujiancha.Rows.Count; j++)
                {
                    if (dtitem_Id.Rows[i]["item_id"].ToString() == c1FlexGrid1_fuzhujiancha[j, "ID"].ToString())
                    {
                        c1FlexGrid1_fuzhujiancha[j, "�۷�"] = dtitem_Id.Rows[i]["down_point"].ToString();
                        c1FlexGrid1_fuzhujiancha[j, "����"] = dtitem_Id.Rows[i]["DOWN_REASON"].ToString();
                    }
                }
                //�ڶ���ѭ����ѭ��c1�ؼ�������ǵ�ID��ͬ���ǿ۷ֵ��� �ѿ۷�ֵ����c1�ؼ��Ŀ۷���
                for (int j = 1; j < c1FlexGrid1_zhiqingtongyi.Rows.Count; j++)
                {
                    if (dtitem_Id.Rows[i]["item_id"].ToString() == c1FlexGrid1_zhiqingtongyi[j, "ID"].ToString())
                    {
                        c1FlexGrid1_zhiqingtongyi[j, "�۷�"] = dtitem_Id.Rows[i]["down_point"].ToString();
                        c1FlexGrid1_zhiqingtongyi[j, "����"] = dtitem_Id.Rows[i]["DOWN_REASON"].ToString();
                    }
                }
            }
        }
        /// <summary>
        /// ���ò�����ҳ����
        /// </summary>
        private void SetBingAnShouYe()
        {
            string bingAn = "select ID as ID,code as ���,name as ��Ŀ from t_data_code where type=57 order by length(code),code";
            DataSet ds = App.GetDataSet(bingAn);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            //���һ�п۷���
            DataColumn dc1 = new DataColumn("�۷�", typeof(double));
            dt.Columns.Add(dc1);
            //���һ��������
            DataColumn dc2 = new DataColumn("����", typeof(string));
            dt.Columns.Add(dc2);
            this.c1FlexGrid1_BingAnShouYe.DataSource = dt.DefaultView;
            this.c1FlexGrid1_BingAnShouYe.Cols["ID"].Visible = false;
            this.c1FlexGrid1_BingAnShouYe.Cols["��Ŀ"].Width = 350;
            this.c1FlexGrid1_BingAnShouYe.Cols["�۷�"].Width = 100;
            this.c1FlexGrid1_BingAnShouYe.Cols["����"].Width = 222;
        }
        /// <summary>
        ///������Ժ��¼
        /// </summary>
        private void SetRuYuanJiLu()
        {
            string ruyuan = "select ID as ID,code as ���,name as ��Ŀ from t_data_code where type=58 order by length(code),code";
            DataSet ds = App.GetDataSet(ruyuan);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            DataColumn dc1 = new DataColumn("�۷�", typeof(double));
            dt.Columns.Add(dc1);
            DataColumn dc2 = new DataColumn("����", typeof(string));
            dt.Columns.Add(dc2);
            this.c1FlexGrid1_ruYuanJilu.DataSource = dt.DefaultView;
            this.c1FlexGrid1_ruYuanJilu.Cols["ID"].Visible = false;
            this.c1FlexGrid1_ruYuanJilu.Cols["��Ŀ"].Width = 280;
            //this.c1FlexGrid1_ruYuanJilu.Cols["�۷�"].Width = 100;
            this.c1FlexGrid1_ruYuanJilu.Cols["����"].Width = 171;

        }
        /// <summary>
        ///���ò��̼�¼
        /// </summary>
        private void SetBingChengJiLu()
        {
            string bingcheng = "select ID as ID,code as ���,name as ��Ŀ from t_data_code where type=59 order by length(code),code";
            DataSet ds = App.GetDataSet(bingcheng);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            DataColumn dc1 = new DataColumn("�۷�", typeof(double));
            dt.Columns.Add(dc1);
            DataColumn dc2 = new DataColumn("����", typeof(string));
            dt.Columns.Add(dc2);
            this.c1FlexGrid1_bingchengjilu.DataSource = dt.DefaultView;
            this.c1FlexGrid1_bingchengjilu.Cols["ID"].Visible = false;
            this.c1FlexGrid1_bingchengjilu.Cols["��Ŀ"].Width = 313;
            //this.c1FlexGrid1_bingchengjilu.Cols["�۷�"].Width = 100;
            this.c1FlexGrid1_bingchengjilu.Cols["����"].Width = 138;

        }
        /// <summary>
        ///���û���Ҫ��ҽ����
        /// ���������޸ĳ�:��д����ԭ��
        /// </summary>
        private void SetJiBenYaoqiuyiZhuDan()
        {
            string jibenyaoqiu = "select ID as ID,code as ���,name as ��Ŀ from t_data_code where type=60 order by length(code),code";
            DataSet ds = App.GetDataSet(jibenyaoqiu);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            DataColumn dc1 = new DataColumn("�۷�", typeof(double));
            dt.Columns.Add(dc1);
            DataColumn dc2 = new DataColumn("����", typeof(string));
            dt.Columns.Add(dc2);
            this.c1FlexGrid1_jibenyaoqiu.DataSource = dt.DefaultView;
            this.c1FlexGrid1_jibenyaoqiu.Cols["ID"].Visible = false;
            this.c1FlexGrid1_jibenyaoqiu.Cols["��Ŀ"].Width = 353;
            //this.c1FlexGrid1_jibenyaoqiu.Cols["�۷�"].Width = 100;
            this.c1FlexGrid1_jibenyaoqiu.Cols["����"].Width = 67;

        }
        /// <summary>
        ///���ó�Ժ����������¼
        /// </summary>
        private void SetChuyuanSiwangJilu()
        {
            string chuyuan = "select ID as ID,code as ���,name as ��Ŀ from t_data_code where type=61 order by length(code),code";
            DataSet ds = App.GetDataSet(chuyuan);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            DataColumn dc1 = new DataColumn("�۷�", typeof(double));
            dt.Columns.Add(dc1);
            DataColumn dc2 = new DataColumn("����", typeof(string));
            dt.Columns.Add(dc2);
            this.c1FlexGrid1_chuyuansiwang.DataSource = dt.DefaultView;
            this.c1FlexGrid1_chuyuansiwang.Cols["ID"].Visible = false;
            this.c1FlexGrid1_chuyuansiwang.Cols["��Ŀ"].Width = 307;
            this.c1FlexGrid1_chuyuansiwang.Cols["�۷�"].Width = 90;
            this.c1FlexGrid1_chuyuansiwang.Cols["����"].Width = 220;

        }
        /// <summary>
        ///���ø������
        /// ���������޸ĳ�:ҽ������������ⵥ
        /// </summary>
        private void SetfuZhuJianCha()
        {
            string fuzhujianche = "select ID as ID,code as ���,name as ��Ŀ from t_data_code where type=62 order by length(code),code";
            DataSet ds = App.GetDataSet(fuzhujianche);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            DataColumn dc1 = new DataColumn("�۷�", typeof(double));
            dt.Columns.Add(dc1);
            DataColumn dc2 = new DataColumn("����", typeof(string));
            dt.Columns.Add(dc2);
            this.c1FlexGrid1_fuzhujiancha.DataSource = dt.DefaultView;
            this.c1FlexGrid1_fuzhujiancha.Cols["ID"].Visible = false;
            this.c1FlexGrid1_fuzhujiancha.Cols["��Ŀ"].Width = 427;
            this.c1FlexGrid1_fuzhujiancha.Cols["�۷�"].Width = 50;
            this.c1FlexGrid1_fuzhujiancha.Cols["����"].Width = 188;

        }
        /// <summary>
        ///����֪��ͬ��
        /// </summary>
        private void SetTongyiShu()
        {
            string zhiqingtongyi = "select ID as ID,code as ���,name as ��Ŀ from t_data_code where type=63 order by length(code),code";
            DataSet ds = App.GetDataSet(zhiqingtongyi);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            DataColumn dc1 = new DataColumn("�۷�", typeof(double));
            dt.Columns.Add(dc1);

            DataColumn dc2 = new DataColumn("����", typeof(string));
            dt.Columns.Add(dc2);
            this.c1FlexGrid1_zhiqingtongyi.DataSource = dt.DefaultView;
            this.c1FlexGrid1_zhiqingtongyi.Cols["ID"].Visible = false;
            //this.c1FlexGrid1_zhiqingtongyi.Cols["��Ŀ"].Width = 440;
            //this.c1FlexGrid1_zhiqingtongyi.Cols["�۷�"].Width = 100;
            this.c1FlexGrid1_zhiqingtongyi.Cols["����"].Width = 65;

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
             * ѭ��ÿ��c1�ؼ��۷ֵ�ֵȻ����100-�۷�ֵ �������ֺ���ܷ֡�
             */
            #region �ܷ�
            double bingansum = 0;
            //�Ѳ�����ҳ�۵��ܷ������
            for (int i = 1; i < this.c1FlexGrid1_BingAnShouYe.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_BingAnShouYe[i, 3].ToString() != "")
                {
                    bingansum += Convert.ToDouble(c1FlexGrid1_BingAnShouYe[i, 3].ToString());//�۷����ֵ
                }
            }
            double ruyuanSum = 0;
            //����Ժ��¼�۵��ܷ������
            for (int i = 1; i < this.c1FlexGrid1_ruYuanJilu.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_ruYuanJilu[i, 3].ToString() != "")
                {
                    ruyuanSum += Convert.ToDouble(c1FlexGrid1_ruYuanJilu[i, 3].ToString());//�۷����ֵ
                }
            }
            double bingchengSum = 0;
            //�Ѳ��̼�¼�۵��ܷ������
            for (int i = 1; i < this.c1FlexGrid1_bingchengjilu.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_bingchengjilu[i, 3].ToString() != "")
                {
                    bingchengSum += Convert.ToDouble(c1FlexGrid1_bingchengjilu[i, 3].ToString());//�۷����ֵ
                }
            }
            double jibenyaojiuSum = 0;
            //�ѻ���Ҫ��ҽ�����۵��ܷ������
            for (int i = 1; i < this.c1FlexGrid1_jibenyaoqiu.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_jibenyaoqiu[i, 3].ToString() != "")
                {
                    jibenyaojiuSum += Convert.ToDouble(c1FlexGrid1_jibenyaoqiu[i, 3].ToString());//�۷����ֵ
                }
            }
            double chuyuanSiwangSum = 0;
            //�ѳ�Ժ����������¼�۵��ܷ������
            for (int i = 1; i < this.c1FlexGrid1_chuyuansiwang.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_chuyuansiwang[i, 3].ToString() != "")
                {
                    chuyuanSiwangSum += Convert.ToDouble(c1FlexGrid1_chuyuansiwang[i, 3].ToString());//�۷����ֵ
                }
            }
            double fuzhujianchaSum = 0;
            //�Ѹ������۵��ܷ������
            for (int i = 1; i < this.c1FlexGrid1_fuzhujiancha.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_fuzhujiancha[i, 3].ToString() != "")
                {
                    fuzhujianchaSum += Convert.ToDouble(c1FlexGrid1_fuzhujiancha[i, 3].ToString());//�۷����ֵ
                }
            }
            double zhiqingtongyiSum = 0;
            //��֪��ͬ��۵��ܷ������
            for (int i = 1; i < this.c1FlexGrid1_zhiqingtongyi.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_zhiqingtongyi[i, 3].ToString() != "")
                {
                    zhiqingtongyiSum += Convert.ToDouble(c1FlexGrid1_zhiqingtongyi[i, 3].ToString());//�۷����ֵ
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
             * ��������־��ǰѼ�¼���뵽���ݿ����档����Ǳ༭���֣���ô���ȸ��ݲ���סԺID(pid)��ʱ��ɾ����������
             * ������Ŀ���ڲ��������ֵ���
             */
            #region ��ӻ��޸�����
            string time = "sysdate";
            List<string> list = new List<string>();

            //����Ǳ༭��ʱ���Ҫ��ɾ����������ǣ��Ǿ��ǵ�һ������
            if (fmshr != null)
            {
                //���֮ǰ��Ҫ��������Pid������ʱ�䣬��С��IDɾ��Ȼ�������
                for (int k = 0; k < dtitem_Id.Rows.Count; k++)
                {
                    string deleteSQL = "delete t_doc_grade where pid='" + pingfenId +
                        "' and item_id=" + dtitem_Id.Rows[k]["item_id"].ToString() + " and to_char(grade_time,'yyyy-MM-dd HH24:mi:ss')='" + pingfenTime + "'";
                    App.ExecuteSQL(deleteSQL);
                }
            }
            //ѭ��������ҳ��ÿһ����ӵ�������
            for (int i = 1; i < this.c1FlexGrid1_BingAnShouYe.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_BingAnShouYe[i, 3].ToString() != "")
                {
                    string binganID = c1FlexGrid1_BingAnShouYe[i, 1].ToString();//�۷����ID
                    string binganKoufen = c1FlexGrid1_BingAnShouYe[i, 3].ToString();//�۷����ֵ
                    string binganLiyou = c1FlexGrid1_BingAnShouYe[i, 4].ToString();//�۷�ԭ��
                    string dosID = App.UserAccount.UserInfo.User_id;//ҽ��ID
                    string dosName = App.UserAccount.UserInfo.User_name;//ҽ������ 
                    string operateSection = App.UserAccount.CurrentSelectRole.Section_name == null ? "" : App.UserAccount.CurrentSelectRole.Section_name;
                    if (App.UserAccount.CurrentSelectRole.Role_type.Trim() == "Z" && App.UserAccount.CurrentSelectRole.Role_name.Contains("�ʿؿ�"))
                    {//�Ƿ����ʿؿ���
                        operateSection = "�ʿؿ�";
                    }
                    else if (App.UserAccount.CurrentSelectRole.Role_type.Trim() == "Y" && App.UserAccount.CurrentSelectRole.Role_name.Contains("ҽ���"))
                    {//�Ƿ���ҽ�����
                        operateSection = "ҽ���";
                    }
                    string insertupdateSQL = "";//����Ҫִ�е�sql���
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
            //    App.Msg("���ֳɹ�");
            //}


            //ѭ����Ժ��¼��ÿһ����ӵ�������
            for (int i = 1; i < this.c1FlexGrid1_ruYuanJilu.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_ruYuanJilu[i, 3].ToString() != "")
                {
                    string binganID = c1FlexGrid1_ruYuanJilu[i, 1].ToString();//�۷����ID
                    string binganKoufen = c1FlexGrid1_ruYuanJilu[i, 3].ToString();//�۷����ֵ
                    string binganLiyou = c1FlexGrid1_ruYuanJilu[i, 4].ToString();//�۷�ԭ��
                    string dosID = App.UserAccount.UserInfo.User_id;//ҽ��ID
                    string dosName = App.UserAccount.UserInfo.User_name;//ҽ������
                    string operateSection = App.UserAccount.CurrentSelectRole.Section_name == null ? "" : App.UserAccount.CurrentSelectRole.Section_name;
                    if (App.UserAccount.CurrentSelectRole.Role_type.Trim() == "Z" && App.UserAccount.CurrentSelectRole.Role_name.Contains("�ʿؿ�"))
                    {//�Ƿ����ʿؿ���
                        operateSection = "�ʿؿ�";
                    }
                    else if (App.UserAccount.CurrentSelectRole.Role_type.Trim() == "Y" && App.UserAccount.CurrentSelectRole.Role_name.Contains("ҽ���"))
                    {//�Ƿ���ҽ�����
                        operateSection = "ҽ���";
                    }
                    string insertupdateSQL = "";//����Ҫִ�е�sql���
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



            //ѭ�����̼�¼��ÿһ����ӵ�������
            for (int i = 1; i < this.c1FlexGrid1_bingchengjilu.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_bingchengjilu[i, 3].ToString() != "")
                {
                    string binganID = c1FlexGrid1_bingchengjilu[i, 1].ToString();//�۷����ID
                    string binganKoufen = c1FlexGrid1_bingchengjilu[i, 3].ToString();//�۷����ֵ
                    string binganLiyou = c1FlexGrid1_bingchengjilu[i, 4].ToString();//�۷�ԭ��
                    string dosID = App.UserAccount.UserInfo.User_id;//ҽ��ID
                    string dosName = App.UserAccount.UserInfo.User_name;//ҽ������
                    string operateSection = App.UserAccount.CurrentSelectRole.Section_name == null ? "" : App.UserAccount.CurrentSelectRole.Section_name;
                    if (App.UserAccount.CurrentSelectRole.Role_type.Trim() == "Z" && App.UserAccount.CurrentSelectRole.Role_name.Contains("�ʿؿ�"))
                    {//�Ƿ����ʿؿ���
                        operateSection = "�ʿؿ�";
                    }
                    else if (App.UserAccount.CurrentSelectRole.Role_type.Trim() == "Y" && App.UserAccount.CurrentSelectRole.Role_name.Contains("ҽ���"))
                    {//�Ƿ���ҽ�����
                        operateSection = "ҽ���";
                    }
                    string insertupdateSQL = "";//����Ҫִ�е�sql���
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



            //ѭ������Ҫ��ҽ������ÿһ����ӵ�������
            for (int i = 1; i < this.c1FlexGrid1_jibenyaoqiu.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_jibenyaoqiu[i, 3].ToString() != "")
                {
                    string binganID = c1FlexGrid1_jibenyaoqiu[i, 1].ToString();//�۷����ID
                    string binganKoufen = c1FlexGrid1_jibenyaoqiu[i, 3].ToString();//�۷����ֵ
                    string binganLiyou = c1FlexGrid1_jibenyaoqiu[i, 4].ToString();//�۷�ԭ��
                    string dosID = App.UserAccount.UserInfo.User_id;//ҽ��ID
                    string dosName = App.UserAccount.UserInfo.User_name;//ҽ������
                    string operateSection = App.UserAccount.CurrentSelectRole.Section_name == null ? "" : App.UserAccount.CurrentSelectRole.Section_name;
                    if (App.UserAccount.CurrentSelectRole.Role_type.Trim() == "Z" && App.UserAccount.CurrentSelectRole.Role_name.Contains("�ʿؿ�"))
                    {//�Ƿ����ʿؿ���
                        operateSection = "�ʿؿ�";
                    }
                    else if (App.UserAccount.CurrentSelectRole.Role_type.Trim() == "Y" && App.UserAccount.CurrentSelectRole.Role_name.Contains("ҽ���"))
                    {//�Ƿ���ҽ�����
                        operateSection = "ҽ���";
                    }
                    string insertupdateSQL = "";//����Ҫִ�е�sql���
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



            //ѭ����Ժ����������¼��ÿһ����ӵ�������
            for (int i = 1; i < this.c1FlexGrid1_chuyuansiwang.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_chuyuansiwang[i, 3].ToString() != "")
                {
                    string binganID = c1FlexGrid1_chuyuansiwang[i, 1].ToString();//�۷����ID
                    string binganKoufen = c1FlexGrid1_chuyuansiwang[i, 3].ToString();//�۷����ֵ
                    string binganLiyou = c1FlexGrid1_chuyuansiwang[i, 4].ToString();//�۷�ԭ��
                    string dosID = App.UserAccount.UserInfo.User_id;//ҽ��ID
                    string dosName = App.UserAccount.UserInfo.User_name;//ҽ������
                    string operateSection = App.UserAccount.CurrentSelectRole.Section_name == null ? "" : App.UserAccount.CurrentSelectRole.Section_name;
                    if (App.UserAccount.CurrentSelectRole.Role_type.Trim() == "Z" && App.UserAccount.CurrentSelectRole.Role_name.Contains("�ʿؿ�"))
                    {//�Ƿ����ʿؿ���
                        operateSection = "�ʿؿ�";
                    }
                    else if (App.UserAccount.CurrentSelectRole.Role_type.Trim() == "Y" && App.UserAccount.CurrentSelectRole.Role_name.Contains("ҽ���"))
                    {//�Ƿ���ҽ�����
                        operateSection = "ҽ���";
                    }
                    string insertupdateSQL = "";//����Ҫִ�е�sql���
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



            //ѭ����������ÿһ����ӵ�������
            for (int i = 1; i < this.c1FlexGrid1_fuzhujiancha.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_fuzhujiancha[i, 3].ToString() != "")
                {
                    string binganID = c1FlexGrid1_fuzhujiancha[i, 1].ToString();//�۷����ID
                    string binganKoufen = c1FlexGrid1_fuzhujiancha[i, 3].ToString();//�۷����ֵ
                    string binganLiyou = c1FlexGrid1_fuzhujiancha[i, 4].ToString();//�۷�ԭ��
                    string dosID = App.UserAccount.UserInfo.User_id;//ҽ��ID
                    string dosName = App.UserAccount.UserInfo.User_name;//ҽ������
                    string operateSection = App.UserAccount.CurrentSelectRole.Section_name == null ? "" : App.UserAccount.CurrentSelectRole.Section_name;
                    if (App.UserAccount.CurrentSelectRole.Role_type.Trim() == "Z" && App.UserAccount.CurrentSelectRole.Role_name.Contains("�ʿؿ�"))
                    {//�Ƿ����ʿؿ���
                        operateSection = "�ʿؿ�";
                    }
                    else if (App.UserAccount.CurrentSelectRole.Role_type.Trim() == "Y" && App.UserAccount.CurrentSelectRole.Role_name.Contains("ҽ���"))
                    {//�Ƿ���ҽ�����
                        operateSection = "ҽ���";
                    }
                    string insertupdateSQL = "";//����Ҫִ�е�sql���
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



            //ѭ��֪��ͬ���ÿһ����ӵ�������
            for (int i = 1; i < this.c1FlexGrid1_zhiqingtongyi.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_zhiqingtongyi[i, 3].ToString() != "")
                {
                    string binganID = c1FlexGrid1_zhiqingtongyi[i, 1].ToString();//�۷����ID
                    string binganKoufen = c1FlexGrid1_zhiqingtongyi[i, 3].ToString();//�۷����ֵ
                    string binganLiyou = c1FlexGrid1_zhiqingtongyi[i, 4].ToString();//�۷�ԭ��
                    string dosID = App.UserAccount.UserInfo.User_id;//ҽ��ID
                    string dosName = App.UserAccount.UserInfo.User_name;//ҽ������
                    string operateSection = App.UserAccount.CurrentSelectRole.Section_name == null ? "" : App.UserAccount.CurrentSelectRole.Section_name;
                    if (App.UserAccount.CurrentSelectRole.Role_type.Trim() == "Z" && App.UserAccount.CurrentSelectRole.Role_name.Contains("�ʿؿ�"))
                    {//�Ƿ����ʿؿ���
                        operateSection = "�ʿؿ�";
                    }
                    else if (App.UserAccount.CurrentSelectRole.Role_type.Trim() == "Y" && App.UserAccount.CurrentSelectRole.Role_name.Contains("ҽ���"))
                    {//�Ƿ���ҽ�����
                        operateSection = "ҽ���";
                    }
                    string insertupdateSQL = "";//����Ҫִ�е�sql���
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

            //��û�۷�ʱ
            if (list.Count == 0)
            {
                string dosID = App.UserAccount.UserInfo.User_id;//ҽ��ID
                string dosName = App.UserAccount.UserInfo.User_name;//ҽ������
                string operateSection = App.UserAccount.CurrentSelectRole.Section_name == null ? "" : App.UserAccount.CurrentSelectRole.Section_name;
                if (App.UserAccount.CurrentSelectRole.Role_type.Trim() == "Z" && App.UserAccount.CurrentSelectRole.Role_name.Contains("�ʿؿ�"))
                {//�Ƿ����ʿؿ���
                    operateSection = "�ʿؿ�";
                }
                else if (App.UserAccount.CurrentSelectRole.Role_type.Trim() == "Y" && App.UserAccount.CurrentSelectRole.Role_name.Contains("ҽ���"))
                {//�Ƿ���ҽ�����
                    operateSection = "ҽ���";
                }
                string insertupdateSQL = "";//����Ҫִ�е�sql���
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
                //�����е�������Ŀ�Ĳ��������list��������
                
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