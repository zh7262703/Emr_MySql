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
    /// �������֣�����
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

        string pingfenId = "";//��ȡ��������ID
        string pingfenTime = "";//��ȡ��������ʱ��
        string pingfenName = "";//��ȡ����������
        //string item_Id = "";//��ȡ��ÿһ���ID

        string doctorID = App.UserAccount.UserInfo.User_id;
        string doctorName = App.UserAccount.UserInfo.User_name;
        public frmGradeNurse(ucfrmMainGradeRepart _fmgr)
        {
            InitializeComponent();
            this.fmgr = _fmgr;
            pid = fmgr.SetPingfen();
            patientId = fmgr.SetPatientID();
            suffName = fmgr.SetSuffererName();
            this.Text = "�� " + suffName + " ��������";

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
            this.Text = "�� " + suffName + " ��������";

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
            this.Text = "�� " + suffName + " ��������";

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

            pingfenId = fmshr.SetPingFenID();//��ȡ��������ID
            patientId = fmshr.SetPatientID();
            pingfenTime = fmshr.SetPingFenTimeNurse();//��ȡ��������ʱ��
            pingfenName = fmshr.SetPingFenNameNurse();//��ȡ����������
            //item_Id = fmshr.SetPingFenItem_ID();//��ȡ��ÿһ���ID
            suffName = _fmshr.SetSuffererName();
            this.Text = "������:" + pingfenName + "    ����ʱ��:" + pingfenTime;

            SetBingAnShouYe();
            SetRuYuanJiLu();
            SetBingChengJiLu();
            SetJiBenYaoqiuyiZhuDan();
            SetChuyuanSiwangJilu();
            SetfuZhuJianCha();
            //SetTongyiShu();
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
            string selectItemIDSQL = "select item_id,down_point from t_doc_grade where pid='" + pingfenId + "' and to_char(grade_time,'yyyy-MM-dd HH24:mi:ss')='" + pingfenTime + "' and emptype = 'N'";
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
                        c1FlexGrid1_BingAnShouYe[j, "��"] = "TRUE";
                    }
                }
                //�ڶ���ѭ����ѭ��c1�ؼ�������ǵ�ID��ͬ���ǿ۷ֵ��� �ѿ۷�ֵ����c1�ؼ��Ŀ۷���
                for (int j = 1; j < c1FlexGrid1_ruYuanJilu.Rows.Count; j++)
                {
                    if (dtitem_Id.Rows[i]["item_id"].ToString() == c1FlexGrid1_ruYuanJilu[j, "ID"].ToString())
                    {
                        c1FlexGrid1_ruYuanJilu[j, "�۷�"] = dtitem_Id.Rows[i]["down_point"].ToString();
                        c1FlexGrid1_ruYuanJilu[j, "��"] = "TRUE";
                    }
                }
                //�ڶ���ѭ����ѭ��c1�ؼ�������ǵ�ID��ͬ���ǿ۷ֵ��� �ѿ۷�ֵ����c1�ؼ��Ŀ۷���
                for (int j = 1; j < c1FlexGrid1_bingchengjilu.Rows.Count; j++)
                {
                    if (dtitem_Id.Rows[i]["item_id"].ToString() == c1FlexGrid1_bingchengjilu[j, "ID"].ToString())
                    {
                        c1FlexGrid1_bingchengjilu[j, "�۷�"] = dtitem_Id.Rows[i]["down_point"].ToString();
                        c1FlexGrid1_bingchengjilu[j, "��"] = "TRUE";
                    }
                }
                //�ڶ���ѭ����ѭ��c1�ؼ�������ǵ�ID��ͬ���ǿ۷ֵ��� �ѿ۷�ֵ����c1�ؼ��Ŀ۷���
                for (int j = 1; j < c1FlexGrid1_jibenyaoqiu.Rows.Count; j++)
                {
                    if (dtitem_Id.Rows[i]["item_id"].ToString() == c1FlexGrid1_jibenyaoqiu[j, "ID"].ToString())
                    {
                        c1FlexGrid1_jibenyaoqiu[j, "�۷�"] = dtitem_Id.Rows[i]["down_point"].ToString();
                        c1FlexGrid1_jibenyaoqiu[j, "��"] = "TRUE";
                    }
                }
                //�ڶ���ѭ����ѭ��c1�ؼ�������ǵ�ID��ͬ���ǿ۷ֵ��� �ѿ۷�ֵ����c1�ؼ��Ŀ۷���
                for (int j = 1; j < c1FlexGrid1_chuyuansiwang.Rows.Count; j++)
                {
                    if (dtitem_Id.Rows[i]["item_id"].ToString() == c1FlexGrid1_chuyuansiwang[j, "ID"].ToString())
                    {
                        c1FlexGrid1_chuyuansiwang[j, "�۷�"] = dtitem_Id.Rows[i]["down_point"].ToString();
                        c1FlexGrid1_chuyuansiwang[j, "��"] = "TRUE";
                    }
                }
                //�ڶ���ѭ����ѭ��c1�ؼ�������ǵ�ID��ͬ���ǿ۷ֵ��� �ѿ۷�ֵ����c1�ؼ��Ŀ۷���
                for (int j = 1; j < c1FlexGrid1_fuzhujiancha.Rows.Count; j++)
                {
                    if (dtitem_Id.Rows[i]["item_id"].ToString() == c1FlexGrid1_fuzhujiancha[j, "ID"].ToString())
                    {
                        c1FlexGrid1_fuzhujiancha[j, "�۷�"] = dtitem_Id.Rows[i]["down_point"].ToString();
                        c1FlexGrid1_fuzhujiancha[j, "��"] = "TRUE";
                    }
                }
                //�ڶ���ѭ����ѭ��c1�ؼ�������ǵ�ID��ͬ���ǿ۷ֵ��� �ѿ۷�ֵ����c1�ؼ��Ŀ۷���
                //for (int j = 1; j < c1FlexGrid1_zhiqingtongyi.Rows.Count; j++)
                //{
                //    if (dtitem_Id.Rows[i]["item_id"].ToString() == c1FlexGrid1_zhiqingtongyi[j, "ID"].ToString())
                //    {
                //        c1FlexGrid1_zhiqingtongyi[j, "�۷�"] = dtitem_Id.Rows[i]["down_point"].ToString();
                //        c1FlexGrid1_zhiqingtongyi[j, "��"] = "TRUE";
                //    }
                //}
            }
        }
        /// <summary>
        /// ���ò�����ҳ����
        /// </summary>
        private void SetBingAnShouYe()
        {
            string bingAn = "select t.id as ID,t.name as ���ַ���,t.check_req as ���Ҫ��,t.deduct_stand as �۷ֱ�׼,t.deduct_score as �����ֵ,t.type as ���͹۷��� from T_MEDICAL_MARK t where t.type_id = '8885' order by t.code asc";
            DataSet ds = App.GetDataSet(bingAn);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            //���һ�п۷���
            DataColumn dc1 = new DataColumn("�۷�", typeof(double));
            dt.Columns.Add(dc1);

            DataColumn boolColumn = new DataColumn("��", typeof(bool));
            boolColumn.DefaultValue = false;
            dt.Columns.Add(boolColumn);

            //���һ��������
            DataColumn dc2 = new DataColumn("����", typeof(string));
            dt.Columns.Add(dc2);
            this.c1FlexGrid1_BingAnShouYe.DataSource = dt.DefaultView;
            this.c1FlexGrid1_BingAnShouYe.Cols["�۷ֱ�׼"].Width = 350;
            this.c1FlexGrid1_BingAnShouYe.Cols["�۷�"].Width = 100;
            this.c1FlexGrid1_BingAnShouYe.Cols["����"].Width = 222;
            this.c1FlexGrid1_BingAnShouYe.Cols["��"].Width = 20;

            this.c1FlexGrid1_BingAnShouYe.Cols["�۷�"].StyleNew.TextAlign = TextAlignEnum.CenterCenter;

            this.c1FlexGrid1_BingAnShouYe.Cols["���ַ���"].Visible = false;
            this.c1FlexGrid1_BingAnShouYe.Cols["���Ҫ��"].Visible = false;
            this.c1FlexGrid1_BingAnShouYe.Cols["���͹۷���"].Visible = false;
        }
        /// <summary>
        ///������Ժ��¼
        /// </summary>
        private void SetRuYuanJiLu()
        {
            string ruyuan = "select t.id as ID,t.name as ���ַ���,t.check_req as ���Ҫ��,t.deduct_stand as �۷ֱ�׼,t.deduct_score as �����ֵ,t.type as ���͹۷��� from T_MEDICAL_MARK t where t.type_id = '8886' order by t.code asc";
            DataSet ds = App.GetDataSet(ruyuan);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];

            //���һ�п۷���
            DataColumn dc1 = new DataColumn("�۷�", typeof(double));
            dt.Columns.Add(dc1);

            DataColumn boolColumn = new DataColumn("��", typeof(bool));
            boolColumn.DefaultValue = false;
            dt.Columns.Add(boolColumn);

            //���һ��������
            DataColumn dc2 = new DataColumn("����", typeof(string));
            dt.Columns.Add(dc2);
            this.c1FlexGrid1_ruYuanJilu.DataSource = dt.DefaultView;
            this.c1FlexGrid1_ruYuanJilu.Cols["�۷ֱ�׼"].Width = 350;
            this.c1FlexGrid1_ruYuanJilu.Cols["�۷�"].Width = 100;
            this.c1FlexGrid1_ruYuanJilu.Cols["����"].Width = 222;
            this.c1FlexGrid1_ruYuanJilu.Cols["��"].Width = 20;

            this.c1FlexGrid1_ruYuanJilu.Cols["�۷�"].StyleNew.TextAlign = TextAlignEnum.CenterCenter;

            this.c1FlexGrid1_ruYuanJilu.Cols["���ַ���"].Visible = false;
            this.c1FlexGrid1_ruYuanJilu.Cols["���Ҫ��"].Visible = false;
            this.c1FlexGrid1_ruYuanJilu.Cols["���͹۷���"].Visible = false;
        }
        /// <summary>
        ///���ò��̼�¼
        /// </summary>
        private void SetBingChengJiLu()
        {
            string bingcheng = "select t.id as ID,t.name as ���ַ���,t.check_req as ���Ҫ��,t.deduct_stand as �۷ֱ�׼,t.deduct_score as �����ֵ,t.type as ���͹۷��� from T_MEDICAL_MARK t where t.type_id = '8887' order by t.code asc";
            DataSet ds = App.GetDataSet(bingcheng);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];

            //���һ�п۷���
            DataColumn dc1 = new DataColumn("�۷�", typeof(double));
            dt.Columns.Add(dc1);

            DataColumn boolColumn = new DataColumn("��", typeof(bool));
            boolColumn.DefaultValue = false;
            dt.Columns.Add(boolColumn);

            //���һ��������
            DataColumn dc2 = new DataColumn("����", typeof(string));
            dt.Columns.Add(dc2);
            this.c1FlexGrid1_bingchengjilu.DataSource = dt.DefaultView;
            this.c1FlexGrid1_bingchengjilu.Cols["�۷ֱ�׼"].Width = 350;
            this.c1FlexGrid1_bingchengjilu.Cols["�۷�"].Width = 100;
            this.c1FlexGrid1_bingchengjilu.Cols["����"].Width = 222;
            this.c1FlexGrid1_bingchengjilu.Cols["��"].Width = 20;

            this.c1FlexGrid1_bingchengjilu.Cols["�۷�"].StyleNew.TextAlign = TextAlignEnum.CenterCenter;

            this.c1FlexGrid1_bingchengjilu.Cols["���ַ���"].Visible = false;
            this.c1FlexGrid1_bingchengjilu.Cols["���Ҫ��"].Visible = false;
            this.c1FlexGrid1_bingchengjilu.Cols["���͹۷���"].Visible = false;
        }
        /// <summary>
        ///���û���Ҫ��ҽ����
        /// </summary>
        private void SetJiBenYaoqiuyiZhuDan()
        {
            string jibenyaoqiu = "select t.id as ID,t.name as ���ַ���,t.check_req as ���Ҫ��,t.deduct_stand as �۷ֱ�׼,t.deduct_score as �����ֵ,t.type as ���͹۷��� from T_MEDICAL_MARK t where t.type_id = '8884' order by t.code asc";
            DataSet ds = App.GetDataSet(jibenyaoqiu);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];


            //���һ�п۷���
            DataColumn dc1 = new DataColumn("�۷�", typeof(double));
            dt.Columns.Add(dc1);

            DataColumn boolColumn = new DataColumn("��", typeof(bool));
            boolColumn.DefaultValue = false;
            dt.Columns.Add(boolColumn);

            //���һ��������
            DataColumn dc2 = new DataColumn("����", typeof(string));
            dt.Columns.Add(dc2);
            this.c1FlexGrid1_jibenyaoqiu.DataSource = dt.DefaultView;
            this.c1FlexGrid1_jibenyaoqiu.Cols["�۷ֱ�׼"].Width = 350;
            this.c1FlexGrid1_jibenyaoqiu.Cols["�۷�"].Width = 100;
            this.c1FlexGrid1_jibenyaoqiu.Cols["����"].Width = 222;
            this.c1FlexGrid1_jibenyaoqiu.Cols["��"].Width = 20;

            this.c1FlexGrid1_jibenyaoqiu.Cols["�۷�"].StyleNew.TextAlign = TextAlignEnum.CenterCenter;

            this.c1FlexGrid1_jibenyaoqiu.Cols["���ַ���"].Visible = false;
            this.c1FlexGrid1_jibenyaoqiu.Cols["���Ҫ��"].Visible = false;
            this.c1FlexGrid1_jibenyaoqiu.Cols["���͹۷���"].Visible = false;
        }
        /// <summary>
        ///���ó�Ժ����������¼
        /// </summary>
        private void SetChuyuanSiwangJilu()
        {
            string chuyuan = "select t.id as ID,t.name as ���ַ���,t.check_req as ���Ҫ��,t.deduct_stand as �۷ֱ�׼,t.deduct_score as �����ֵ,t.type as ���͹۷��� from T_MEDICAL_MARK t where t.type_id = '8888' order by t.code asc";
            DataSet ds = App.GetDataSet(chuyuan);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];


            //���һ�п۷���
            DataColumn dc1 = new DataColumn("�۷�", typeof(double));
            dt.Columns.Add(dc1);

            DataColumn boolColumn = new DataColumn("��", typeof(bool));
            boolColumn.DefaultValue = false;
            dt.Columns.Add(boolColumn);

            //���һ��������
            DataColumn dc2 = new DataColumn("����", typeof(string));
            dt.Columns.Add(dc2);
            this.c1FlexGrid1_chuyuansiwang.DataSource = dt.DefaultView;
            this.c1FlexGrid1_chuyuansiwang.Cols["�۷ֱ�׼"].Width = 350;
            this.c1FlexGrid1_chuyuansiwang.Cols["�۷�"].Width = 100;
            this.c1FlexGrid1_chuyuansiwang.Cols["����"].Width = 222;
            this.c1FlexGrid1_chuyuansiwang.Cols["��"].Width = 20;

            this.c1FlexGrid1_chuyuansiwang.Cols["�۷�"].StyleNew.TextAlign = TextAlignEnum.CenterCenter;

            this.c1FlexGrid1_chuyuansiwang.Cols["���ַ���"].Visible = false;
            this.c1FlexGrid1_chuyuansiwang.Cols["���Ҫ��"].Visible = false;
            this.c1FlexGrid1_chuyuansiwang.Cols["���͹۷���"].Visible = false;
        }
        /// <summary>
        ///���ø������
        /// </summary>
        private void SetfuZhuJianCha()
        {
            string fuzhujianche = "select t.id as ID,t.name as ���ַ���,t.check_req as ���Ҫ��,t.deduct_stand as �۷ֱ�׼,t.deduct_score as �����ֵ,t.type as ���͹۷��� from T_MEDICAL_MARK t where t.type_id = '8889' order by t.code asc";
            DataSet ds = App.GetDataSet(fuzhujianche);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];


            //���һ�п۷���
            DataColumn dc1 = new DataColumn("�۷�", typeof(double));
            dt.Columns.Add(dc1);

            DataColumn boolColumn = new DataColumn("��", typeof(bool));
            boolColumn.DefaultValue = false;
            dt.Columns.Add(boolColumn);

            //���һ��������
            DataColumn dc2 = new DataColumn("����", typeof(string));
            dt.Columns.Add(dc2);
            this.c1FlexGrid1_fuzhujiancha.DataSource = dt.DefaultView;
            this.c1FlexGrid1_fuzhujiancha.Cols["�۷ֱ�׼"].Width = 350;
            this.c1FlexGrid1_fuzhujiancha.Cols["�۷�"].Width = 100;
            this.c1FlexGrid1_fuzhujiancha.Cols["����"].Width = 222;
            this.c1FlexGrid1_fuzhujiancha.Cols["��"].Width = 20;

            this.c1FlexGrid1_fuzhujiancha.Cols["�۷�"].StyleNew.TextAlign = TextAlignEnum.CenterCenter;

            this.c1FlexGrid1_fuzhujiancha.Cols["���ַ���"].Visible = false;
            this.c1FlexGrid1_fuzhujiancha.Cols["���Ҫ��"].Visible = false;
            this.c1FlexGrid1_fuzhujiancha.Cols["���͹۷���"].Visible = false;
        }
        /// <summary>
        ///����֪��ͬ��
        /// </summary>
        private void SetTongyiShu()
        {
            string zhiqingtongyi = "select ID as ID,name as ��Ŀ from t_data_code where type=63";
            DataSet ds = App.GetDataSet(zhiqingtongyi);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            DataColumn dc1 = new DataColumn("�۷�", typeof(double));
            dt.Columns.Add(dc1);

            DataColumn dc2 = new DataColumn("����", typeof(string));
            dt.Columns.Add(dc2);
            this.c1FlexGrid1_zhiqingtongyi.DataSource = dt.DefaultView;
            //this.c1FlexGrid1_zhiqingtongyi.Cols["��Ŀ"].Width = 440;
            //this.c1FlexGrid1_zhiqingtongyi.Cols["�۷�"].Width = 100;
            this.c1FlexGrid1_zhiqingtongyi.Cols["����"].Width = 65;

        }


        private void frmGrade_Load(object sender, EventArgs e)
        {
            //��������
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
             * ѭ��ÿ��c1�ؼ��۷ֵ�ֵȻ����100-�۷�ֵ �������ֺ���ܷ֡�
             */
            #region �ܷ�
            double bingansum = 0;
            //�Ѳ�����ҳ�۵��ܷ������
            for (int i = 1; i < this.c1FlexGrid1_BingAnShouYe.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_BingAnShouYe[i, "�۷�"].ToString() != "")
                {
                    bingansum += Convert.ToDouble(c1FlexGrid1_BingAnShouYe[i, "�۷�"].ToString());//�۷����ֵ
                }
            }
            double ruyuanSum = 0;
            //����Ժ��¼�۵��ܷ������
            for (int i = 1; i < this.c1FlexGrid1_ruYuanJilu.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_ruYuanJilu[i, "�۷�"].ToString() != "")
                {
                    ruyuanSum += Convert.ToDouble(c1FlexGrid1_ruYuanJilu[i, "�۷�"].ToString());//�۷����ֵ
                }
            }
            double bingchengSum = 0;
            //�Ѳ��̼�¼�۵��ܷ������
            for (int i = 1; i < this.c1FlexGrid1_bingchengjilu.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_bingchengjilu[i, "�۷�"].ToString() != "")
                {
                    bingchengSum += Convert.ToDouble(c1FlexGrid1_bingchengjilu[i, "�۷�"].ToString());//�۷����ֵ
                }
            }
            double jibenyaojiuSum = 0;
            //�ѻ���Ҫ��ҽ�����۵��ܷ������
            //for (int i = 1; i < this.c1FlexGrid1_jibenyaoqiu.Rows.Count; i++)
            //{
            //    if (this.c1FlexGrid1_jibenyaoqiu[i, "�۷�"].ToString() != "")
            //    {
            //        jibenyaojiuSum += Convert.ToDouble(c1FlexGrid1_jibenyaoqiu[i, "�۷�"].ToString());//�۷����ֵ
            //    }
            //}
            double chuyuanSiwangSum = 0;
            //�ѳ�Ժ����������¼�۵��ܷ������
            for (int i = 1; i < this.c1FlexGrid1_chuyuansiwang.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_chuyuansiwang[i, "�۷�"].ToString() != "")
                {
                    chuyuanSiwangSum += Convert.ToDouble(c1FlexGrid1_chuyuansiwang[i, "�۷�"].ToString());//�۷����ֵ
                }
            }
            double fuzhujianchaSum = 0;
            //�Ѹ������۵��ܷ������
            for (int i = 1; i < this.c1FlexGrid1_fuzhujiancha.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_fuzhujiancha[i, "�۷�"].ToString() != "")
                {
                    fuzhujianchaSum += Convert.ToDouble(c1FlexGrid1_fuzhujiancha[i, "�۷�"].ToString());//�۷����ֵ
                }
            }
            double zhiqingtongyiSum = 0;
            //��֪��ͬ��۵��ܷ������
            //for (int i = 1; i < this.c1FlexGrid1_zhiqingtongyi.Rows.Count; i++)
            //{
            //    if (this.c1FlexGrid1_zhiqingtongyi[i, "�۷�"].ToString() != "")
            //    {
            //        zhiqingtongyiSum += Convert.ToDouble(c1FlexGrid1_zhiqingtongyi[i, "�۷�"].ToString());//�۷����ֵ
            //    }
            //}


            //�۷ֵ���
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
            //����
            if (zongSum == 100)
            {
                string binganID = "0";//�۷����ID
                string binganKoufen = "";//�۷����ֵ
                string binganLiyou = "";//�۷�ԭ��
                string dosID = App.UserAccount.UserInfo.User_id;//ҽ��ID
                string dosName = App.UserAccount.UserInfo.User_name;//ҽ������ 
                string insertupdateSQL = "";//����Ҫִ�е�sql���

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
            //ѭ��������ҳ��ÿһ����ӵ�������
            for (int i = 1; i < this.c1FlexGrid1_BingAnShouYe.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_BingAnShouYe[i, "�۷�"].ToString() != "")
                {
                    string binganID = c1FlexGrid1_BingAnShouYe[i, "ID"].ToString();//�۷����ID
                    string binganKoufen = c1FlexGrid1_BingAnShouYe[i, "�۷�"].ToString();//�۷����ֵ
                    string binganLiyou = c1FlexGrid1_BingAnShouYe[i, "����"].ToString();//�۷�ԭ��
                    string dosID = App.UserAccount.UserInfo.User_id;//ҽ��ID
                    string dosName = App.UserAccount.UserInfo.User_name;//ҽ������ 
                    string insertupdateSQL = "";//����Ҫִ�е�sql���
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
            //    App.Msg("���ֳɹ�");
            //}


            //ѭ����Ժ��¼��ÿһ����ӵ�������
            for (int i = 1; i < this.c1FlexGrid1_ruYuanJilu.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_ruYuanJilu[i, "�۷�"].ToString() != "")
                {
                    string binganID = c1FlexGrid1_ruYuanJilu[i, "ID"].ToString();//�۷����ID
                    string binganKoufen = c1FlexGrid1_ruYuanJilu[i, "�۷�"].ToString();//�۷����ֵ
                    string binganLiyou = c1FlexGrid1_ruYuanJilu[i, "����"].ToString();//�۷�ԭ��
                    string dosID = App.UserAccount.UserInfo.User_id;//ҽ��ID
                    string dosName = App.UserAccount.UserInfo.User_name;//ҽ������

                    string insertupdateSQL = "";//����Ҫִ�е�sql���
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



            //ѭ�����̼�¼��ÿһ����ӵ�������
            for (int i = 1; i < this.c1FlexGrid1_bingchengjilu.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_bingchengjilu[i, "�۷�"].ToString() != "")
                {
                    string binganID = c1FlexGrid1_bingchengjilu[i, "ID"].ToString();//�۷����ID
                    string binganKoufen = c1FlexGrid1_bingchengjilu[i, "�۷�"].ToString();//�۷����ֵ
                    string binganLiyou = c1FlexGrid1_bingchengjilu[i, "����"].ToString();//�۷�ԭ��
                    string dosID = App.UserAccount.UserInfo.User_id;//ҽ��ID
                    string dosName = App.UserAccount.UserInfo.User_name;//ҽ������

                    string insertupdateSQL = "";//����Ҫִ�е�sql���
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



            //ѭ������Ҫ��ҽ������ÿһ����ӵ�������
            //for (int i = 1; i < this.c1FlexGrid1_jibenyaoqiu.Rows.Count; i++)
            //{
            //    if (this.c1FlexGrid1_jibenyaoqiu[i, "�۷�"].ToString() != "")
            //    {
            //        string binganID = c1FlexGrid1_jibenyaoqiu[i, "ID"].ToString();//�۷����ID
            //        string binganKoufen = c1FlexGrid1_jibenyaoqiu[i, "�۷�"].ToString();//�۷����ֵ
            //        string binganLiyou = c1FlexGrid1_jibenyaoqiu[i, "����"].ToString();//�۷�ԭ��
            //        string dosID = App.UserAccount.UserInfo.User_id;//ҽ��ID
            //        string dosName = App.UserAccount.UserInfo.User_name;//ҽ������

            //        string insertupdateSQL = "";//����Ҫִ�е�sql���
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



            //ѭ����Ժ����������¼��ÿһ����ӵ�������
            for (int i = 1; i < this.c1FlexGrid1_chuyuansiwang.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_chuyuansiwang[i, "�۷�"].ToString() != "")
                {
                    string binganID = c1FlexGrid1_chuyuansiwang[i, "ID"].ToString();//�۷����ID
                    string binganKoufen = c1FlexGrid1_chuyuansiwang[i, "�۷�"].ToString();//�۷����ֵ
                    string binganLiyou = c1FlexGrid1_chuyuansiwang[i, "����"].ToString();//�۷�ԭ��
                    string dosID = App.UserAccount.UserInfo.User_id;//ҽ��ID
                    string dosName = App.UserAccount.UserInfo.User_name;//ҽ������

                    string insertupdateSQL = "";//����Ҫִ�е�sql���
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



            //ѭ����������ÿһ����ӵ�������
            for (int i = 1; i < this.c1FlexGrid1_fuzhujiancha.Rows.Count; i++)
            {
                if (this.c1FlexGrid1_fuzhujiancha[i, "�۷�"].ToString() != "")
                {
                    string binganID = c1FlexGrid1_fuzhujiancha[i, "ID"].ToString();//�۷����ID
                    string binganKoufen = c1FlexGrid1_fuzhujiancha[i, "�۷�"].ToString();//�۷����ֵ
                    string binganLiyou = c1FlexGrid1_fuzhujiancha[i, "����"].ToString();//�۷�ԭ��
                    string dosID = App.UserAccount.UserInfo.User_id;//ҽ��ID
                    string dosName = App.UserAccount.UserInfo.User_name;//ҽ������

                    string insertupdateSQL = "";//����Ҫִ�е�sql���
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



            //ѭ��֪��ͬ���ÿһ����ӵ�������
            //for (int i = 1; i < this.c1FlexGrid1_zhiqingtongyi.Rows.Count; i++)
            //{
            //    if (this.c1FlexGrid1_zhiqingtongyi[i, "�۷�"].ToString() != "")
            //    {
            //        string binganID = c1FlexGrid1_zhiqingtongyi[i, "ID"].ToString();//�۷����ID
            //        string binganKoufen = c1FlexGrid1_zhiqingtongyi[i, "�۷�"].ToString();//�۷����ֵ
            //        string binganLiyou = c1FlexGrid1_zhiqingtongyi[i, "����"].ToString();//�۷�ԭ��
            //        string dosID = App.UserAccount.UserInfo.User_id;//ҽ��ID
            //        string dosName = App.UserAccount.UserInfo.User_name;//ҽ������

            //        string insertupdateSQL = "";//����Ҫִ�е�sql���
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
                //�����е�������Ŀ�Ĳ��������list��������
                //fmgr.addPingFen(list);

                //ִ��Ҫ���������sql���
                if (App.ExecuteBatch(list.ToArray()) > 0)
                {
                    App.Msg("����ɹ�");
                    //ÿ�α���һ�ζ�Ҫ���һ��
                    list.Clear();
                }
                else
                {
                    App.Msg("����ʧ��");
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
            int rows = this.c1FlexGrid1_bingchengjilu.RowSel;//����ѡ�е��к�

            if (c1FlexGrid1_bingchengjilu[rows, "��"].ToString().ToLower() == "true")
            {
                c1FlexGrid1_bingchengjilu[rows, "�۷�"] = c1FlexGrid1_bingchengjilu[rows, "�����ֵ"];
            }
            else
            {
                c1FlexGrid1_bingchengjilu[rows, "�۷�"] = null;
            }
        }

        private void c1FlexGrid1_ruYuanJilu_MouseUp(object sender, MouseEventArgs e)
        {
            int rows = this.c1FlexGrid1_ruYuanJilu.RowSel;//����ѡ�е��к�

            if (c1FlexGrid1_ruYuanJilu[rows, "��"].ToString().ToLower() == "true")
            {
                c1FlexGrid1_ruYuanJilu[rows, "�۷�"] = c1FlexGrid1_ruYuanJilu[rows, "�����ֵ"];
            }
            else
            {
                c1FlexGrid1_ruYuanJilu[rows, "�۷�"] = null;
            }
        }

        private void c1FlexGrid1_BingAnShouYe_MouseUp(object sender, MouseEventArgs e)
        {
            int rows = this.c1FlexGrid1_BingAnShouYe.RowSel;//����ѡ�е��к�

            if (c1FlexGrid1_BingAnShouYe[rows, "��"].ToString().ToLower() == "true")
            {
                c1FlexGrid1_BingAnShouYe[rows, "�۷�"] = c1FlexGrid1_BingAnShouYe[rows, "�����ֵ"];
            }
            else
            {
                c1FlexGrid1_BingAnShouYe[rows, "�۷�"] = null;
            }
        }

        private void c1FlexGrid1_chuyuansiwang_MouseUp(object sender, MouseEventArgs e)
        {
            int rows = this.c1FlexGrid1_chuyuansiwang.RowSel;//����ѡ�е��к�

            if (c1FlexGrid1_chuyuansiwang[rows, "��"].ToString().ToLower() == "true")
            {
                c1FlexGrid1_chuyuansiwang[rows, "�۷�"] = c1FlexGrid1_chuyuansiwang[rows, "�����ֵ"];
            }
            else
            {
                c1FlexGrid1_chuyuansiwang[rows, "�۷�"] = null;
            }
        }

        private void c1FlexGrid1_fuzhujiancha_MouseUp(object sender, MouseEventArgs e)
        {
            int rows = this.c1FlexGrid1_fuzhujiancha.RowSel;//����ѡ�е��к�

            if (c1FlexGrid1_fuzhujiancha[rows, "��"].ToString().ToLower() == "true")
            {
                c1FlexGrid1_fuzhujiancha[rows, "�۷�"] = c1FlexGrid1_fuzhujiancha[rows, "�����ֵ"];
            }
            else
            {
                c1FlexGrid1_fuzhujiancha[rows, "�۷�"] = null;
            }
        }

        private void c1FlexGrid1_jibenyaoqiu_MouseUp(object sender, MouseEventArgs e)
        {
            int rows = this.c1FlexGrid1_jibenyaoqiu.RowSel;//����ѡ�е��к�

            if (c1FlexGrid1_jibenyaoqiu[rows, "��"].ToString().ToLower() == "true")
            {
                c1FlexGrid1_jibenyaoqiu[rows, "�۷�"] = c1FlexGrid1_jibenyaoqiu[rows, "�����ֵ"];
            }
            else
            {
                c1FlexGrid1_jibenyaoqiu[rows, "�۷�"] = null;
            }
        }

    }
}