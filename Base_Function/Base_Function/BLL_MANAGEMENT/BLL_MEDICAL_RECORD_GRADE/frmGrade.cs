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
using Base_Function.BLL_DOCTOR.HisInStance.ҽ����;
using MySql.Data.MySqlClient;
//using Bifrost.HisInstance;


namespace Base_Function.BLL_MEDICAL_RECORD_GRADE
{
    /// <summary>
    /// �������֣�ҽ��
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
        public string BingLiType = "";//���в���������ĩ����

        string pingfenId = "";//��ȡ��������ID
        string pingfenTime = "";//��ȡ��������ʱ��
        string pingfenName = "";//��ȡ����������
        public string strMark = "";//����ģ���ʶ
        //string item_Id = "";//��ȡ��ÿһ���ID

        string strAllTypePF = "";//ȫԺ���ֱ�־
        string strSectionTypePF = "";//�������ֱ�־
        string strDoctorTypePF = "";//ҽ�����ֱ�־

        public string strMark_after = "";    //�޸�֮���ֵ
        public string strMark_before = ""; //�޸�֮ǰ��ֵ
        bool newflag;

        DataTable dt_list = new DataTable();

        string doctorID = App.UserAccount.UserInfo.User_id;
        string doctorName = App.UserAccount.UserInfo.User_name;
        /// <summary>
        /// ���ô��壨�������2013-11-06��
        /// </summary>
        /// <param name="_fmgr"></param>
        /// <param name="PingfenMark"></param>
        public frmGrade(string strPatientID, string strPId, string strsuffname, string PingfenMark)
        {
            InitializeComponent();
            patientId = strPatientID;//Ҫ���ݻ���id
            pid = strPId;//Ҫ���ݲ���סԺ��
            suffName = strsuffname;//Ҫ���ݹܴ�ҽ������
            strMark = PingfenMark;//�����1��string ���͵ģ���Ϊ���ʹ��
            this.Text = "��" + suffName + " ��������";

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
            this.Text = "�� " + suffName + " ��������";

            strAllTypePF = "1";//ȫԺ���ֱ�־

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
            this.Text = "�� " + suffName + " ��������";

            strDoctorTypePF = "3";//ҽ�����ֱ�־

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
            this.Text = "�� " + suffName + " ��������";

            strSectionTypePF = "2";//�������ֱ�־

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

            pingfenId = fmshr.SetPingFenID();//��ȡ��������ID
            patientId = fmshr.SetPatientID();
            pingfenTime = fmshr.SetPingFenTime();//��ȡ��������ʱ��
            pingfenName = fmshr.SetPingFenName();//��ȡ����������
            //item_Id = fmshr.SetPingFenItem_ID();//��ȡ��ÿһ���ID
            suffName = _fmshr.SetSuffererName();
            this.Text = "������:" + pingfenName + "    ����ʱ��:" + pingfenTime;

            SetBingAnShouYe();
            SetRuYuanJiLu();
            SetBingChengJiLu();
            SetJiBenYaoqiuyiZhuDan();
            SetChuyuanSiwangJilu();
            SetfuZhuJianCha();
            SetTongyiShu();
            SetYiZhudan();
            //SetKouFen();��ΪҪ֧��˫���������п۷֣����ԾͲ���Ҫ���Ҳ��ֵ���н��п۷�
            SetKouFenHuiZong();
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
            string selectItemIDSQL = "select item_id,down_point from t_doc_grade where pid='" + pingfenId + "' and to_char(grade_time,'yyyy-MM-dd HH24:mi:ss')='" + pingfenTime + "' and emptype = 'D'";
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
                for (int j = 1; j < c1FlexGrid1_zhiqingtongyi.Rows.Count; j++)
                {
                    if (dtitem_Id.Rows[i]["item_id"].ToString() == c1FlexGrid1_zhiqingtongyi[j, "ID"].ToString())
                    {
                        c1FlexGrid1_zhiqingtongyi[j, "�۷�"] = dtitem_Id.Rows[i]["down_point"].ToString();
                        c1FlexGrid1_zhiqingtongyi[j, "��"] = "TRUE";
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
                //    strKouFenHuiZong = " select t.id,t.item ������Ŀ,t.item_score ��ֵ,t.item_content �۷ֱ�׼,t.item_reason �۷�����,t.ITEM_PATIENTID ����id,t.medical_mark_id from t_deduct_score t where t.ITEM_PATIENTID='" + patientId + "'";

                //}
                if (newflag == true)
                {
                    strKouFenHuiZong = " select t.id,t.item ������Ŀ,t.item_score ��ֵ,t.item_score �ȽϷ�ֵ,t.item_content �۷ֱ�׼,t.item_reason �۷�����,t.ITEM_PATIENTID ����id,t.medical_mark_id,t.item_type from t_deduct_score t where t.ITEM_PATIENTID='" + patientId + "'";

                }
                else
                {
                    if (strMark == "1")
                    {
                        strKouFenHuiZong = "select distinct t.id,t.item ������Ŀ,t.item_score ��ֵ,t.item_score �ȽϷ�ֵ,t.item_content �۷ֱ�׼,t.item_reason �۷�����,t.ITEM_PATIENTID ����id,t.medical_mark_id,t.item_type,b.alltypepf,b.sectiontypepf,b.doctortypepf from t_deduct_score t,t_doc_grade b where t.item_patientid =b.patient_id and b.alltypepf ='1' and b.patient_id ='" + patientId + "'";

                    }
                    if (strMark == "2")
                    {
                        strKouFenHuiZong = "select distinct t.id,t.item ������Ŀ,t.item_score ��ֵ,t.item_score �ȽϷ�ֵ,t.item_content �۷ֱ�׼,t.item_reason �۷�����,t.ITEM_PATIENTID ����id,t.medical_mark_id,t.item_type,b.alltypepf,b.sectiontypepf,b.doctortypepf from t_deduct_score t,t_doc_grade b where t.item_patientid =b.patient_id and b.sectiontypepf ='2' and b.patient_id ='" + patientId + "'";

                    }
                    if (strMark == "3")
                    {
                        strKouFenHuiZong = "select distinct t.id,t.item ������Ŀ,t.item_score ��ֵ,t.item_score �ȽϷ�ֵ,t.item_content �۷ֱ�׼,t.item_reason �۷�����,t.ITEM_PATIENTID ����id,t.medical_mark_id,t.item_type,b.alltypepf,b.sectiontypepf,b.doctortypepf from t_deduct_score t,t_doc_grade b where t.item_patientid =b.patient_id and b.doctortypepf ='3' and b.patient_id ='" + patientId + "'";

                    }
                }


                DataSet ds = App.GetDataSet(strKouFenHuiZong);
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                this.c1FlexGrid2.DataSource = ds.Tables[0].DefaultView;
                //}
                this.c1FlexGrid2.Cols["id"].Visible = false;
                this.c1FlexGrid2.Cols["����id"].Visible = false;
                this.c1FlexGrid2.Cols["������Ŀ"].Width = 100;
                this.c1FlexGrid2.Cols["��ֵ"].Width = 50;
                this.c1FlexGrid2.Cols["�ȽϷ�ֵ"].Width = 50;
                this.c1FlexGrid2.Cols["�ȽϷ�ֵ"].Visible = false;
                this.c1FlexGrid2.Cols["�۷ֱ�׼"].Width = 250;
                this.c1FlexGrid2.Cols["�۷�����"].Width = 500;
                this.c1FlexGrid2.Cols["medical_mark_id"].Visible = false;
                this.c1FlexGrid2.Cols["item_type"].Visible = false;
                if (strMark == "1" || strMark == "2" || strMark == "3")
                {
                    this.c1FlexGrid2.Cols["alltypepf"].Visible = false;
                    this.c1FlexGrid2.Cols["sectiontypepf"].Visible = false;
                    this.c1FlexGrid2.Cols["doctortypepf"].Visible = false;
                }

                //        c1FlexGrid2[i, "id"] = dt.Rows[i]["medical_mark_id"];
                //        c1FlexGrid2[i, "����id"] = dt.Rows[i]["item_patientid"];
                //        c1FlexGrid2[i, "������Ŀ"] = dt.Rows[i]["item"];
                //        c1FlexGrid2[i, "��ֵ"] = dt.Rows[i]["item_score"];
                //        c1FlexGrid2[i, "�۷ֱ�׼"] = dt.Rows[i]["item_content"];
                //        c1FlexGrid2[i, "�۷�����"] = dt.Rows[i]["item_reason"];
            }
            catch
            {

            }
        }
        /// <summary>
        /// ���ò�����ҳ����
        /// </summary>
        private void SetBingAnShouYe()
        {
            string bingAn = "select t.id as ID,t.name as ���ַ���,t.check_req as ���Ҫ��,t.deduct_stand as �۷ֱ�׼,t.deduct_score as �����ֵ,t.type as ���͹۷��� from T_MEDICAL_MARK t where t.type_id = '7960653' order by case when regexp_like(t.code,'^[[:digit:]]+$') then to_number(t.code) else 999 end asc";
            DataSet ds = App.GetDataSet(bingAn);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            ////���һ�п۷���
            //DataColumn dc1 = new DataColumn("�۷�", typeof(double));
            //dt.Columns.Add(dc1);

            //DataColumn boolColumn = new DataColumn("��", typeof(bool));
            //boolColumn.DefaultValue = false;
            //dt.Columns.Add(boolColumn);

            ////���һ��������
            //DataColumn dc2 = new DataColumn("����", typeof(string));
            //dt.Columns.Add(dc2);
            this.c1FlexGrid1_BingAnShouYe.DataSource = dt.DefaultView;
            this.c1FlexGrid1_BingAnShouYe.Cols["�۷ֱ�׼"].Width = 350;
            this.c1FlexGrid1_BingAnShouYe.Cols["�����ֵ"].Width = 100;
            //this.c1FlexGrid1_BingAnShouYe.Cols["�۷�"].Width = 100;
            //this.c1FlexGrid1_BingAnShouYe.Cols["����"].Width = 222;
            //this.c1FlexGrid1_BingAnShouYe.Cols["��"].Width = 20;

            //this.c1FlexGrid1_BingAnShouYe.Cols["�۷�"].StyleNew.TextAlign = TextAlignEnum.CenterCenter;

            this.c1FlexGrid1_BingAnShouYe.Cols["���ַ���"].Visible = false;
            this.c1FlexGrid1_BingAnShouYe.Cols["���Ҫ��"].Visible = false;
            this.c1FlexGrid1_BingAnShouYe.Cols["���͹۷���"].Visible = false;
        }
        /// <summary>
        ///������Ժ��¼
        /// </summary>
        private void SetRuYuanJiLu()
        {
            string ruyuan = "select t.id as ID,t.name as ���ַ���,t.check_req as ���Ҫ��,t.deduct_stand as �۷ֱ�׼,t.deduct_score as �����ֵ,t.type as ���͹۷��� from T_MEDICAL_MARK t where t.type_id = '8880' order by case when regexp_like(t.code,'^[[:digit:]]+$') then to_number(t.code) else 999 end asc";
            DataSet ds = App.GetDataSet(ruyuan);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];

            ////���һ�п۷���
            //DataColumn dc1 = new DataColumn("�۷�", typeof(double));
            //dt.Columns.Add(dc1);

            //DataColumn boolColumn = new DataColumn("��", typeof(bool));
            //boolColumn.DefaultValue = false;
            //dt.Columns.Add(boolColumn);

            ////���һ��������
            //DataColumn dc2 = new DataColumn("����", typeof(string));
            //dt.Columns.Add(dc2);
            this.c1FlexGrid1_ruYuanJilu.DataSource = dt.DefaultView;
            this.c1FlexGrid1_ruYuanJilu.Cols["�۷ֱ�׼"].Width = 350;
            this.c1FlexGrid1_ruYuanJilu.Cols["�����ֵ"].Width = 100;
            //this.c1FlexGrid1_ruYuanJilu.Cols["�۷�"].Width = 100;
            //this.c1FlexGrid1_ruYuanJilu.Cols["����"].Width = 222;
            //this.c1FlexGrid1_ruYuanJilu.Cols["��"].Width = 20;

            //this.c1FlexGrid1_ruYuanJilu.Cols["�۷�"].StyleNew.TextAlign = TextAlignEnum.CenterCenter;

            this.c1FlexGrid1_ruYuanJilu.Cols["���ַ���"].Visible = false;
            this.c1FlexGrid1_ruYuanJilu.Cols["���Ҫ��"].Visible = false;
            this.c1FlexGrid1_ruYuanJilu.Cols["���͹۷���"].Visible = false;


            string sql = "select b.name as ��Ŀ,count(b.id) as ���� from t_quality_record_temp a " +
                         "inner join t_data_code b on a.text_name=b.name " +
                         "where a.pid = '" + pid + "' " +
                         "group by a.pid,b.id,b.name";

            DataSet dsItem = App.GetDataSet(sql);


            for (int j = 1; j < c1FlexGrid1_ruYuanJilu.Rows.Count; j++)
            {
                if (c1FlexGrid1_ruYuanJilu[j, "���͹۷���"].ToString() == "N")
                {
                    c1FlexGrid1_ruYuanJilu.Rows[j].StyleNew.BackColor = Color.LimeGreen;

                    for (int i = 0; i < dsItem.Tables[0].Rows.Count; i++)
                    {
                        if (dsItem.Tables[0].Rows[i]["��Ŀ"].ToString() == c1FlexGrid1_ruYuanJilu[j, "���ַ���"].ToString())
                        {
                            //c1FlexGrid1_ruYuanJilu[j, "��"] = "TRUE";
                            //  c1FlexGrid1_ruYuanJilu[j, "�۷�"] = Convert.ToDecimal(c1FlexGrid1_ruYuanJilu[j, "�����ֵ"].ToString()) * Convert.ToDecimal(dsItem.Tables[0].Rows[i]["����"].ToString());
                        }
                    }
                }
            }
        }
        /// <summary>
        ///���ò��̼�¼
        /// </summary>
        private void SetBingChengJiLu()
        {
            string bingcheng = "select t.id as ID,t.name as ���ַ���,t.check_req as ���Ҫ��,t.deduct_stand as �۷ֱ�׼,t.deduct_score as �����ֵ,t.type as ���͹۷��� from T_MEDICAL_MARK t where t.type_id = '7960658' order by case when regexp_like(t.code,'^[[:digit:]]+$') then to_number(t.code) else 999 end asc";
            DataSet ds = App.GetDataSet(bingcheng);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];

            ////���һ�п۷���
            //DataColumn dc1 = new DataColumn("�۷�", typeof(double));
            //dt.Columns.Add(dc1);

            //DataColumn boolColumn = new DataColumn("��", typeof(bool));
            //boolColumn.DefaultValue = false;
            //dt.Columns.Add(boolColumn);

            ////���һ��������
            //DataColumn dc2 = new DataColumn("����", typeof(string));
            //dt.Columns.Add(dc2);
            this.c1FlexGrid1_bingchengjilu.DataSource = dt.DefaultView;
            this.c1FlexGrid1_bingchengjilu.Cols["�۷ֱ�׼"].Width = 350;

            this.c1FlexGrid1_bingchengjilu.Cols["�����ֵ"].Width = 100;

            //this.c1FlexGrid1_bingchengjilu.Cols["�۷�"].Width = 100;
            //this.c1FlexGrid1_bingchengjilu.Cols["����"].Width = 222;
            //this.c1FlexGrid1_bingchengjilu.Cols["��"].Width = 20;

            //this.c1FlexGrid1_bingchengjilu.Cols["�۷�"].StyleNew.TextAlign = TextAlignEnum.CenterCenter;

            this.c1FlexGrid1_bingchengjilu.Cols["���ַ���"].Visible = false;
            this.c1FlexGrid1_bingchengjilu.Cols["���Ҫ��"].Visible = false;
            this.c1FlexGrid1_bingchengjilu.Cols["���͹۷���"].Visible = false;




            string sql = "select b.name as ��Ŀ,count(b.id) as ���� from t_quality_record_temp a " +
                         "inner join t_data_code b on a.text_name=b.name " +
                         "where a.pid = '" + pid + "' " +
                         "group by a.pid,b.id,b.name";

            DataSet dsItem = App.GetDataSet(sql);


            for (int j = 1; j < c1FlexGrid1_bingchengjilu.Rows.Count; j++)
            {
                if (c1FlexGrid1_bingchengjilu[j, "���͹۷���"].ToString() == "N")
                {
                    c1FlexGrid1_bingchengjilu.Rows[j].StyleNew.BackColor = Color.LimeGreen;

                    for (int i = 0; i < dsItem.Tables[0].Rows.Count; i++)
                    {
                        if (dsItem.Tables[0].Rows[i]["��Ŀ"].ToString() == c1FlexGrid1_bingchengjilu[j, "���ַ���"].ToString())
                        {
                            //c1FlexGrid1_bingchengjilu[j, "��"] = "TRUE";
                            //c1FlexGrid1_bingchengjilu[j, "�۷�"] = Convert.ToDecimal(c1FlexGrid1_bingchengjilu[j, "�����ֵ"].ToString()) * Convert.ToDecimal(dsItem.Tables[0].Rows[i]["����"].ToString());
                        }
                    }
                }
            }
        }
        /// <summary>
        ///���û���Ҫ��ҽ���� 69630004
        /// </summary>
        private void SetJiBenYaoqiuyiZhuDan()
        {
            string jibenyaoqiu = "select t.id as ID,t.name as ���ַ���,t.check_req as ���Ҫ��,t.deduct_stand as �۷ֱ�׼,t.deduct_score as �����ֵ,t.type as ���͹۷��� from T_MEDICAL_MARK t where t.type_id = '7960659' order by case when regexp_like(t.code,'^[[:digit:]]+$') then to_number(t.code) else 999 end asc";
            DataSet ds = App.GetDataSet(jibenyaoqiu);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];


            ////���һ�п۷���
            //DataColumn dc1 = new DataColumn("�۷�", typeof(double));
            //dt.Columns.Add(dc1);

            //DataColumn boolColumn = new DataColumn("��", typeof(bool));
            //boolColumn.DefaultValue = false;
            //dt.Columns.Add(boolColumn);

            ////���һ��������
            //DataColumn dc2 = new DataColumn("����", typeof(string));
            //dt.Columns.Add(dc2);
            this.c1FlexGrid1_jibenyaoqiu.DataSource = dt.DefaultView;
            this.c1FlexGrid1_jibenyaoqiu.Cols["�۷ֱ�׼"].Width = 350;
            this.c1FlexGrid1_jibenyaoqiu.Cols["�����ֵ"].Width = 100;
            //this.c1FlexGrid1_jibenyaoqiu.Cols["�۷�"].Width = 100;
            //this.c1FlexGrid1_jibenyaoqiu.Cols["����"].Width = 222;
            //this.c1FlexGrid1_jibenyaoqiu.Cols["��"].Width = 20;

            // this.c1FlexGrid1_jibenyaoqiu.Cols["�۷�"].StyleNew.TextAlign = TextAlignEnum.CenterCenter;

            this.c1FlexGrid1_jibenyaoqiu.Cols["���ַ���"].Visible = false;
            this.c1FlexGrid1_jibenyaoqiu.Cols["���Ҫ��"].Visible = false;
            this.c1FlexGrid1_jibenyaoqiu.Cols["���͹۷���"].Visible = false;
        }
        /// <summary>
        ///���ó�Ժ����������¼
        /// </summary>
        private void SetChuyuanSiwangJilu()
        {
            string chuyuan = "select t.id as ID,t.name as ���ַ���,t.check_req as ���Ҫ��,t.deduct_stand as �۷ֱ�׼,t.deduct_score as �����ֵ,t.type as ���͹۷��� from T_MEDICAL_MARK t where t.type_id = '8882' order by case when regexp_like(t.code,'^[[:digit:]]+$') then to_number(t.code) else 999 end asc";
            DataSet ds = App.GetDataSet(chuyuan);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];


            ////���һ�п۷���
            //DataColumn dc1 = new DataColumn("�۷�", typeof(double));
            //dt.Columns.Add(dc1);

            //DataColumn boolColumn = new DataColumn("��", typeof(bool));
            //boolColumn.DefaultValue = false;
            //dt.Columns.Add(boolColumn);

            ////���һ��������
            //DataColumn dc2 = new DataColumn("����", typeof(string));
            //dt.Columns.Add(dc2);
            this.c1FlexGrid1_chuyuansiwang.DataSource = dt.DefaultView;
            this.c1FlexGrid1_chuyuansiwang.Cols["�۷ֱ�׼"].Width = 350;
            this.c1FlexGrid1_chuyuansiwang.Cols["�����ֵ"].Width = 100;
            //this.c1FlexGrid1_chuyuansiwang.Cols["�۷�"].Width = 100;
            //this.c1FlexGrid1_chuyuansiwang.Cols["����"].Width = 222;
            //this.c1FlexGrid1_chuyuansiwang.Cols["��"].Width = 20;

            //this.c1FlexGrid1_chuyuansiwang.Cols["�۷�"].StyleNew.TextAlign = TextAlignEnum.CenterCenter;

            this.c1FlexGrid1_chuyuansiwang.Cols["���ַ���"].Visible = false;
            this.c1FlexGrid1_chuyuansiwang.Cols["���Ҫ��"].Visible = false;
            this.c1FlexGrid1_chuyuansiwang.Cols["���͹۷���"].Visible = false;


            string sql = "select b.name as ��Ŀ,count(b.id) as ���� from t_quality_record_temp a " +
                         "inner join t_data_code b on a.text_name=b.name " +
                         "where a.pid = '" + pid + "' " +
                         "group by a.pid,b.id,b.name";

            DataSet dsItem = App.GetDataSet(sql);


            for (int j = 1; j < c1FlexGrid1_chuyuansiwang.Rows.Count; j++)
            {
                if (c1FlexGrid1_chuyuansiwang[j, "���͹۷���"].ToString() == "N")
                {
                    c1FlexGrid1_chuyuansiwang.Rows[j].StyleNew.BackColor = Color.LimeGreen;

                    for (int i = 0; i < dsItem.Tables[0].Rows.Count; i++)
                    {
                        if (dsItem.Tables[0].Rows[i]["��Ŀ"].ToString() == c1FlexGrid1_chuyuansiwang[j, "���ַ���"].ToString())
                        {
                            //c1FlexGrid1_chuyuansiwang[j, "��"] = "TRUE";
                            //c1FlexGrid1_chuyuansiwang[j, "�۷�"] = Convert.ToDecimal(c1FlexGrid1_chuyuansiwang[j, "�����ֵ"].ToString()) * Convert.ToDecimal(dsItem.Tables[0].Rows[i]["����"].ToString());
                        }
                    }
                }
            }
        }
        /// <summary>
        ///���ø������
        /// </summary>
        private void SetfuZhuJianCha()
        {
            string fuzhujianche = "select t.id as ID,t.name as ���ַ���,t.check_req as ���Ҫ��,t.deduct_stand as �۷ֱ�׼,t.deduct_score as �����ֵ,t.type as ���͹۷��� from T_MEDICAL_MARK t where t.type_id = '7960659' order by case when regexp_like(t.code,'^[[:digit:]]+$') then to_number(t.code) else 999 end asc";
            DataSet ds = App.GetDataSet(fuzhujianche);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];


            ////���һ�п۷���
            //DataColumn dc1 = new DataColumn("�۷�", typeof(double));
            //dt.Columns.Add(dc1);

            //DataColumn boolColumn = new DataColumn("��", typeof(bool));
            //boolColumn.DefaultValue = false;
            //dt.Columns.Add(boolColumn);

            ////���һ��������
            //DataColumn dc2 = new DataColumn("����", typeof(string));
            //dt.Columns.Add(dc2);
            this.c1FlexGrid1_fuzhujiancha.DataSource = dt.DefaultView;
            this.c1FlexGrid1_fuzhujiancha.Cols["�۷ֱ�׼"].Width = 350;
            this.c1FlexGrid1_fuzhujiancha.Cols["�����ֵ"].Width = 100;
            //this.c1FlexGrid1_fuzhujiancha.Cols["�۷�"].Width = 100;
            //this.c1FlexGrid1_fuzhujiancha.Cols["����"].Width = 222;
            //this.c1FlexGrid1_fuzhujiancha.Cols["��"].Width = 20;

            //this.c1FlexGrid1_fuzhujiancha.Cols["�۷�"].StyleNew.TextAlign = TextAlignEnum.CenterCenter;

            this.c1FlexGrid1_fuzhujiancha.Cols["���ַ���"].Visible = false;
            this.c1FlexGrid1_fuzhujiancha.Cols["���Ҫ��"].Visible = false;
            this.c1FlexGrid1_fuzhujiancha.Cols["���͹۷���"].Visible = false;
        }
        /// <summary>
        ///����֪��ͬ��
        /// </summary>
        private void SetTongyiShu()
        {
            string zhiqingtongyi = "select t.id as ID,t.name as ���ַ���,t.check_req as ���Ҫ��,t.deduct_stand as �۷ֱ�׼,t.deduct_score as �����ֵ,t.type as ���͹۷��� from T_MEDICAL_MARK t where t.type_id = '7960664' order by case when regexp_like(t.code,'^[[:digit:]]+$') then to_number(t.code) else 999 end asc";
            DataSet ds = App.GetDataSet(zhiqingtongyi);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            //DataColumn dc1 = new DataColumn("�۷�", typeof(double));
            //dt.Columns.Add(dc1);

            //DataColumn boolColumn = new DataColumn("��", typeof(bool));
            //boolColumn.DefaultValue = false;
            //dt.Columns.Add(boolColumn);

            //DataColumn dc2 = new DataColumn("����", typeof(string));
            //dt.Columns.Add(dc2);
            this.c1FlexGrid1_zhiqingtongyi.DataSource = dt.DefaultView;
            this.c1FlexGrid1_zhiqingtongyi.Cols["�۷ֱ�׼"].Width = 440;
            this.c1FlexGrid1_zhiqingtongyi.Cols["�����ֵ"].Width = 100;
            //this.c1FlexGrid1_zhiqingtongyi.Cols["�۷�"].Width = 40;
            //this.c1FlexGrid1_zhiqingtongyi.Cols["��"].Width = 40;
            //this.c1FlexGrid1_zhiqingtongyi.Cols["����"].Width = 220;

            this.c1FlexGrid1_zhiqingtongyi.Cols["���ַ���"].Visible = false;
            this.c1FlexGrid1_zhiqingtongyi.Cols["���Ҫ��"].Visible = false;
            this.c1FlexGrid1_zhiqingtongyi.Cols["���͹۷���"].Visible = false;

        }
        /// <summary>
        /// ҽ����
        /// </summary>
        private void SetYiZhudan()
        {
            try
            {
                string fuzhujianche = "select t.id as ID,t.name as ���ַ���,t.check_req as ���Ҫ��,t.deduct_stand as �۷ֱ�׼,t.deduct_score as �����ֵ,t.type as ���͹۷��� from T_MEDICAL_MARK t where t.type_id = '7960659' order by case when regexp_like(t.code,'^[[:digit:]]+$') then to_number(t.code) else 999 end asc";
                DataSet ds = App.GetDataSet(fuzhujianche);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];

                this.c1FlexGrid1_yizhudan.DataSource = dt.DefaultView;
                this.c1FlexGrid1_yizhudan.Cols["�۷ֱ�׼"].Width = 450;
                this.c1FlexGrid1_yizhudan.Cols["�����ֵ"].Width = 100;
                //this.c1FlexGrid1_fuzhujiancha.Cols["����"].Width = 222;
                //this.c1FlexGrid1_fuzhujiancha.Cols["��"].Width = 20;

                //this.c1FlexGrid1_fuzhujiancha.Cols["�۷�"].StyleNew.TextAlign = TextAlignEnum.CenterCenter;

                this.c1FlexGrid1_yizhudan.Cols["���ַ���"].Visible = false;
                this.c1FlexGrid1_yizhudan.Cols["���Ҫ��"].Visible = false;
                this.c1FlexGrid1_yizhudan.Cols["���͹۷���"].Visible = false;

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

            #region Pacs Ӱ�񱨸�

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

            #region ���ӹ鵵����
            ArrayList searchFiles = new ArrayList();
            //searchFiles = Tools_Others.SearchFiles(patientId, "", "");
            //this.search_FilesBrowse.Patients = Tools_FileOperation.GetScanFiles(GlobalSettings.BrowsePath);
            //this.search_FilesBrowse.LoadTree();
            #endregion
            //��������
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
            //Ԭ����ʱע�� 141218
            //            
            text.MyDoc.OnBackPFId += new TextEditor.TextDocument.Document.ZYTextDocument.BackPFId(MyDoc_OnBackPFId);

        }
        //1:ɾ����0��ɫ
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


            if (App.Ask("ȷ�����ֲ����Ѿ�ȫ����ɣ���û����ɣ���������ɺ��ڵ���˲�����"))
            {
                btnConfirm.Visible = false;

                try
                {
                    /*
                                 * ѭ��ÿ��c1�ؼ��۷ֵ�ֵȻ����100-�۷�ֵ �������ֺ���ܷ֡�
                                 */
                    #region �ܷ�
                    double bingansum = 0;
                    //�Ѳ�����ҳ�۵��ܷ������
                    //for (int i = 1; i < this.c1FlexGrid1_BingAnShouYe.Rows.Count; i++)
                    //{
                    //    if (this.c1FlexGrid1_BingAnShouYe[i, "�۷�"].ToString() != "")
                    //    {
                    //        bingansum += Convert.ToDouble(c1FlexGrid1_BingAnShouYe[i, "�۷�"].ToString());//�۷����ֵ
                    //    }
                    //}
                    for (int i = 1; i < this.c1FlexGrid2.Rows.Count; i++)
                    {
                        if (this.c1FlexGrid2[i, "������Ŀ"].ToString() == "������ҳ")
                        {
                            bingansum += Convert.ToDouble(c1FlexGrid2[i, "��ֵ"].ToString());//�۷����ֵ
                        }
                    }
                    double ruyuanSum = 0;
                    //����Ժ��¼�۵��ܷ������
                    //for (int i = 1; i < this.c1FlexGrid1_ruYuanJilu.Rows.Count; i++)
                    //{
                    //    if (this.c1FlexGrid1_ruYuanJilu[i, "�۷�"].ToString() != "")
                    //    {
                    //        ruyuanSum += Convert.ToDouble(c1FlexGrid1_ruYuanJilu[i, "�۷�"].ToString());//�۷����ֵ
                    //    }
                    //}
                    for (int i = 1; i < this.c1FlexGrid2.Rows.Count; i++)
                    {
                        if (this.c1FlexGrid2[i, "������Ŀ"].ToString() == "��Ժ��¼")
                        {
                            ruyuanSum += Convert.ToDouble(c1FlexGrid2[i, "��ֵ"].ToString());//�۷����ֵ
                        }
                    }
                    double bingchengSum = 0;
                    //�Ѳ��̼�¼�۵��ܷ������
                    //for (int i = 1; i < this.c1FlexGrid1_bingchengjilu.Rows.Count; i++)
                    //{
                    //    if (this.c1FlexGrid1_bingchengjilu[i, "�۷�"].ToString() != "")
                    //    {
                    //        bingchengSum += Convert.ToDouble(c1FlexGrid1_bingchengjilu[i, "�۷�"].ToString());//�۷����ֵ
                    //    }
                    //}
                    for (int i = 1; i < this.c1FlexGrid2.Rows.Count; i++)
                    {
                        if (this.c1FlexGrid2[i, "������Ŀ"].ToString() == "���̼�¼")
                        {
                            bingchengSum += Convert.ToDouble(c1FlexGrid2[i, "��ֵ"].ToString());//�۷����ֵ
                        }
                    }

                    double fuzhujianchaSum = 0;
                    //�Ѹ�����鼰ҽ�����۵��ܷ������
                    //for (int i = 1; i < this.c1FlexGrid1_jibenyaoqiu.Rows.Count; i++)
                    //{
                    //    if (this.c1FlexGrid1_jibenyaoqiu[i, "�۷�"].ToString() != "")
                    //    {
                    //        jibenyaojiuSum += Convert.ToDouble(c1FlexGrid1_jibenyaoqiu[i, "�۷�"].ToString());//�۷����ֵ
                    //    }
                    //}
                    for (int i = 1; i < this.c1FlexGrid2.Rows.Count; i++)
                    {
                        if (this.c1FlexGrid2[i, "������Ŀ"].ToString() == "������鼰ҽ����")
                        {
                            fuzhujianchaSum += Convert.ToDouble(c1FlexGrid2[i, "��ֵ"].ToString());//�۷����ֵ
                        }
                    }
                    double chuyuanSiwangSum = 0;
                    //�ѳ�Ժ����������¼�۵��ܷ������
                    //for (int i = 1; i < this.c1FlexGrid1_chuyuansiwang.Rows.Count; i++)
                    //{
                    //    if (this.c1FlexGrid1_chuyuansiwang[i, "�۷�"].ToString() != "")
                    //    {
                    //        chuyuanSiwangSum += Convert.ToDouble(c1FlexGrid1_chuyuansiwang[i, "�۷�"].ToString());//�۷����ֵ
                    //    }
                    //}
                    for (int i = 1; i < this.c1FlexGrid2.Rows.Count; i++)
                    {
                        if (this.c1FlexGrid2[i, "������Ŀ"].ToString() == "��Ժ��¼")
                        {
                            chuyuanSiwangSum += Convert.ToDouble(c1FlexGrid2[i, "��ֵ"].ToString());//�۷����ֵ
                        }
                    }
                    double jibenyaojiuSum = 0;
                    //����дҪ��۵��ܷ������
                    for (int i = 1; i < this.c1FlexGrid2.Rows.Count; i++)
                    {
                        if (this.c1FlexGrid2[i, "������Ŀ"].ToString() == "��дҪ��")
                        {
                            jibenyaojiuSum += Convert.ToDouble(c1FlexGrid2[i, "��ֵ"].ToString());//�۷����ֵ
                        }
                    }
                    double zhiqingtongyiSum = 0;
                    // ��֪��ͬ��۵��ܷ������
                    for (int i = 1; i < this.c1FlexGrid2.Rows.Count; i++)
                    {
                        if (this.c1FlexGrid2[i, "������Ŀ"].ToString() == "֪��ͬ����")
                        {
                            zhiqingtongyiSum += Convert.ToDouble(c1FlexGrid2[i, "��ֵ"].ToString());//�۷����ֵ
                        }
                    }
                    double yizhudanSum = 0;
                    // ��ҽ�����۵��ܷ������
                    for (int i = 1; i < this.c1FlexGrid2.Rows.Count; i++)
                    {
                        if (this.c1FlexGrid2[i, "������Ŀ"].ToString() == "ҽ����")
                        {
                            yizhudanSum += Convert.ToDouble(c1FlexGrid2[i, "��ֵ"].ToString());//�۷����ֵ
                        }
                    }
                    //�۷ֵ���
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

                        if (strMark == "1")//����ȫԺ����ģʽ
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
                        if (strMark == "2")//���ǿ�������ģʽ
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
                        if (strMark == "3")//����ҽ������ģʽ
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

                    //ѭ��������ҳ��ÿһ����ӵ�������
                    for (int i = 1; i < this.c1FlexGrid2.Rows.Count; i++)
                    {
                        if (this.c1FlexGrid2[i, "������Ŀ"].ToString() == "������ҳ")
                        {
                            string binganID = c1FlexGrid2[i, "medical_mark_id"].ToString();//�۷����ID
                            string binganKoufen = c1FlexGrid2[i, "��ֵ"].ToString();//�۷����ֵ
                            string binganLiyou = c1FlexGrid2[i, "�۷�����"].ToString();//�۷�ԭ��
                            string dosID = App.UserAccount.UserInfo.User_id;//ҽ��ID
                            string dosName = App.UserAccount.UserInfo.User_name;//ҽ������ 
                            string insertupdateSQL = "";//����Ҫִ�е�sql���
                            if (strMark == "1")//����ȫԺ���ַ�ʽ
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
                            if (strMark == "2")//���ǿ������ַ�ʽ
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
                            if (strMark == "3")//���ǿ������ַ�ʽ
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
                    //    App.Msg("���ֳɹ�");
                    //}


                    //ѭ����Ժ��¼��ÿһ����ӵ�������
                    for (int i = 1; i < this.c1FlexGrid2.Rows.Count; i++)
                    {

                        if (this.c1FlexGrid2[i, "������Ŀ"].ToString() == "��Ժ��¼")
                        {
                            string binganID = c1FlexGrid2[i, "medical_mark_id"].ToString();//�۷����ID
                            string binganKoufen = c1FlexGrid2[i, "��ֵ"].ToString();//�۷����ֵ
                            string binganLiyou = c1FlexGrid2[i, "�۷�����"].ToString();//�۷�ԭ��
                            string dosID = App.UserAccount.UserInfo.User_id;//ҽ��ID
                            string dosName = App.UserAccount.UserInfo.User_name;//ҽ������

                            string insertupdateSQL = "";//����Ҫִ�е�sql���
                            if (strMark == "1")//����ȫԺ���ַ�ʽ
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
                            if (strMark == "2")//���ǿ������ַ�ʽ
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
                            if (strMark == "3")//����ҽ�����ַ�ʽ
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

                    //ѭ�����̼�¼��ÿһ����ӵ�������
                    for (int i = 1; i < this.c1FlexGrid2.Rows.Count; i++)
                    {
                        if (this.c1FlexGrid2[i, "������Ŀ"].ToString() == "���̼�¼")
                        {
                            string binganID = c1FlexGrid2[i, "medical_mark_id"].ToString();//�۷����ID
                            string binganKoufen = c1FlexGrid2[i, "��ֵ"].ToString();//�۷����ֵ
                            string binganLiyou = c1FlexGrid2[i, "�۷�����"].ToString();//�۷�ԭ��
                            string dosID = App.UserAccount.UserInfo.User_id;//ҽ��ID
                            string dosName = App.UserAccount.UserInfo.User_name;//ҽ������

                            string insertupdateSQL = "";//����Ҫִ�е�sql���
                            if (strMark == "1")//����ȫԺ���ַ�ʽ
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
                            if (strMark == "2")//���ǿ������ַ�ʽ
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
                            if (strMark == "3")//���Ǹ������ַ�ʽ
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




                    //ѭ������Ҫ��ҽ������ÿһ����ӵ�������
                    for (int i = 1; i < this.c1FlexGrid2.Rows.Count; i++)
                    {
                        if (this.c1FlexGrid2[i, "������Ŀ"].ToString() == "��Ժ��¼")
                        {
                            string binganID = c1FlexGrid2[i, "medical_mark_id"].ToString();//�۷����ID
                            string binganKoufen = c1FlexGrid2[i, "��ֵ"].ToString();//�۷����ֵ
                            string binganLiyou = c1FlexGrid2[i, "�۷�����"].ToString();//�۷�ԭ��
                            string dosID = App.UserAccount.UserInfo.User_id;//ҽ��ID
                            string dosName = App.UserAccount.UserInfo.User_name;//ҽ������

                            string insertupdateSQL = "";//����Ҫִ�е�sql���
                            if (strMark == "1")//����ȫԺ���ַ�ʽ
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
                            if (strMark == "2")//���ǿ������ַ�ʽ
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
                            if (strMark == "3")//����ȫԺ���ַ�ʽ
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



                    //ѭ����Ժ����������¼��ÿһ����ӵ�������
                    for (int i = 1; i < this.c1FlexGrid2.Rows.Count; i++)
                    {
                        if (this.c1FlexGrid2[i, "������Ŀ"].ToString() == "������鼰ҽ����")
                        {
                            string binganID = c1FlexGrid2[i, "medical_mark_id"].ToString();//�۷����ID
                            string binganKoufen = c1FlexGrid2[i, "��ֵ"].ToString();//�۷����ֵ
                            string binganLiyou = c1FlexGrid2[i, "�۷�����"].ToString();//�۷�ԭ��
                            string dosID = App.UserAccount.UserInfo.User_id;//ҽ��ID
                            string dosName = App.UserAccount.UserInfo.User_name;//ҽ������

                            string insertupdateSQL = "";//����Ҫִ�е�sql���
                            if (strMark == "1")//����ȫԺ���ַ�ʽ
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
                            if (strMark == "2")//���ǿ������ַ�ʽ
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
                            if (strMark == "3")//����ҽ�����ַ�ʽ
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



                    //ѭ����������ÿһ����ӵ�������
                    for (int i = 1; i < this.c1FlexGrid2.Rows.Count; i++)
                    {
                        if (this.c1FlexGrid2[i, "������Ŀ"].ToString() == "��дҪ��")
                        {
                            string binganID = c1FlexGrid2[i, "medical_mark_id"].ToString();//�۷����ID
                            string binganKoufen = c1FlexGrid2[i, "��ֵ"].ToString();//�۷����ֵ
                            string binganLiyou = c1FlexGrid2[i, "�۷�����"].ToString();//�۷�ԭ��
                            string dosID = App.UserAccount.UserInfo.User_id;//ҽ��ID
                            string dosName = App.UserAccount.UserInfo.User_name;//ҽ������

                            string insertupdateSQL = "";//����Ҫִ�е�sql���
                            if (strMark == "1")//����ȫԺ���ַ�ʽ
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
                            if (strMark == "2")//���ǿ������ַ�ʽ
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
                            if (strMark == "3")//����ҽ�����ַ�ʽ
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



                    // ѭ��֪��ͬ���ÿһ����ӵ�������
                    for (int i = 1; i < this.c1FlexGrid2.Rows.Count; i++)
                    {
                        #region �޸ĺ������
                        int deductid = int.Parse(c1FlexGrid2[i, "id"].ToString());
                        string fz = c1FlexGrid2[i, "��ֵ"].ToString();
                        string ly = c1FlexGrid2[i, "�۷�����"].ToString();
                        string sql = "update t_deduct_score set item_score ='" + fz + "',item_reason ='" + ly + "' where id =" + deductid;
                        App.ExecuteSQL(sql);
                        #endregion
                        if (this.c1FlexGrid2[i, "������Ŀ"].ToString() == "֪��ͬ����")
                        {
                            string binganID = c1FlexGrid2[i, "medical_mark_id"].ToString();//�۷����ID
                            string binganKoufen = c1FlexGrid2[i, "��ֵ"].ToString();//�۷����ֵ
                            string binganLiyou = c1FlexGrid2[i, "�۷�����"].ToString();//�۷�ԭ��
                            //string binganID = c1FlexGrid1_zhiqingtongyi[i, "ID"].ToString();//�۷����ID
                            //string binganKoufen = c1FlexGrid1_zhiqingtongyi[i, "�۷�"].ToString();//�۷����ֵ
                            //string binganLiyou = c1FlexGrid1_zhiqingtongyi[i, "����"].ToString();//�۷�ԭ��
                            string dosID = App.UserAccount.UserInfo.User_id;//ҽ��ID
                            string dosName = App.UserAccount.UserInfo.User_name;//ҽ������

                            string insertupdateSQL = "";//����Ҫִ�е�sql���
                            if (strMark == "1")//����ȫԺ���ַ�ʽ
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
                            if (strMark == "2")//���ǿ������ַ�ʽ
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
                            if (strMark == "3")//����ҽ�����ַ�ʽ
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
                            #region �޸���Ϣ��Ϣ Ԭ�����130724
                            string strDatetimeU = App.GetSystemTime().ToString();//��ȡ��ǰ����ʱ��
                            string strContentU = "";
                            if (BingLiType == "1")
                            {
                                strContentU = "���β������յ÷�Ϊ" + zongSum;//��Ϣ����
                            }
                            else
                            {
                                strContentU = "���в�����ȱ�����޸�";//���в�����Ϣ����
                            }
                            string strUpdateSqlU = "update t_msg_info t set t.content='" + strContentU + "',t.operator_user_id='" + doctorID
                              + "',t.operator_user_name='" + doctorName + "',t.add_time=to_date('" + strDatetimeU + "','yyyy-MM-dd HH24:mi:ss'),t.msg_status='0' where t.pid='" + patientId + "'";
                            App.ExecuteSQL(strUpdateSqlU);
                            #endregion
                            return;
                        }
                        else
                        {
                            //�����е�������Ŀ�Ĳ��������list��������
                            //fmgr.addPingFen(list);

                            //ִ��Ҫ���������sql���
                            if (App.ExecuteBatch(list.ToArray()) > 0)
                            {
                                #region Ԭ����� ����������Ϣ����130724
                                string New_Id = App.GenId("t_msg_info", "id").ToString();//����
                                string strDoctor_name = "";//�ܴ�ҽ������
                                string strDoctor_id = "";//�ܴ�ҽ��id
                                string strDoctorSql = "select t.sick_doctor_id,t.sick_doctor_name from t_in_patient t where t.id='" + patientId + "'";
                                if (strDoctorSql.Length > 0)
                                {
                                    DataSet ds = App.GetDataSet(strDoctorSql);
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        strDoctor_name = ds.Tables[0].Rows[0]["sick_doctor_name"].ToString();//�ܴ�ҽ��������ֵ
                                        strDoctor_id = ds.Tables[0].Rows[0]["sick_doctor_id"].ToString();//�ܴ�ҽ��id��ֵ
                                    }
                                }

                                string strDatetime = App.GetSystemTime().ToString();//��ȡ��ǰ����ʱ��
                                string strContent = "";
                                if (BingLiType == "1")
                                {
                                    strContent = "���β������յ÷�Ϊ" + zongSum;//��Ϣ����
                                }
                                else
                                {
                                    strContent = "���в�����ȱ�����޸�";//���в�����Ϣ����
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
   ('" + New_Id + "','" + patientId + "','', '" + strDoctor_id + "','" + strDoctor_name + "','" + doctorID + "','" + doctorName + "', '','','22','" + strContent + "',to_date('" + strDatetime + "','yyyy-MM-dd HH24:mi:ss'),'0', '','��������','', '','','','','','','17','')";
                                int n = App.ExecuteSQL(strInsertSql);
                                if (n > 0)
                                {

                                    App.Msg("����ɹ�");
                                    //ÿ�α���һ�ζ�Ҫ���һ��
                                    list.Clear();
                                }
                                #endregion
                            }
                            else
                            {
                                App.Msg("����ʧ��");
                                list.Clear();
                                return;
                            }
                        }
                    }
                    if (strMark == "2")
                    {
                        if (fmgrSection == null)
                        {
                            #region �޸���Ϣ��Ϣ Ԭ�����130724
                            string strDatetimeU = App.GetSystemTime().ToString();//��ȡ��ǰ����ʱ��
                            string strContentU = "";
                            if (BingLiType == "1")
                            {
                                strContentU = "���β������յ÷�Ϊ" + zongSum;//��Ϣ����
                            }
                            else
                            {
                                strContentU = "���в�����ȱ�����޸�";//���в�����Ϣ����
                            }
                            string strUpdateSqlU = "update t_msg_info t set t.content='" + strContentU + "',t.operator_user_id='" + doctorID
                              + "',t.operator_user_name='" + doctorName + "',t.add_time=to_date('" + strDatetimeU + "','yyyy-MM-dd HH24:mi:ss'),t.msg_status='0' where t.pid='" + patientId + "'";
                            App.ExecuteSQL(strUpdateSqlU);
                            #endregion
                            return;
                        }
                        else
                        {
                            //�����е�������Ŀ�Ĳ��������list��������
                            //fmgr.addPingFen(list);

                            //ִ��Ҫ���������sql���
                            if (App.ExecuteBatch(list.ToArray()) > 0)
                            {
                                #region Ԭ����� ����������Ϣ����130724
                                string New_Id = App.GenId("t_msg_info", "id").ToString();//����
                                string strDoctor_name = "";//�ܴ�ҽ������
                                string strDoctor_id = "";//�ܴ�ҽ��id
                                string strDoctorSql = "select t.sick_doctor_id,t.sick_doctor_name from t_in_patient t where t.id='" + patientId + "'";
                                if (strDoctorSql.Length > 0)
                                {
                                    DataSet ds = App.GetDataSet(strDoctorSql);
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        strDoctor_name = ds.Tables[0].Rows[0]["sick_doctor_name"].ToString();//�ܴ�ҽ��������ֵ
                                        strDoctor_id = ds.Tables[0].Rows[0]["sick_doctor_id"].ToString();//�ܴ�ҽ��id��ֵ
                                    }
                                }
                                string strDatetime = App.GetSystemTime().ToString();//��ȡ��ǰ����ʱ��

                                string strContent = "";
                                if (BingLiType == "1")
                                {
                                    strContent = "���β������յ÷�Ϊ" + zongSum;//��Ϣ����
                                }
                                else
                                {
                                    strContent = "���в�����ȱ�����޸�";//���в�����Ϣ����
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
   ('" + New_Id + "','" + patientId + "','', '" + strDoctor_id + "','" + strDoctor_name + "','" + doctorID + "','" + doctorName + "', '','','22','" + strContent + "',to_date('" + strDatetime + "','yyyy-MM-dd HH24:mi:ss'),'0', '','��������','', '','','','','','','17','')";
                                int n = App.ExecuteSQL(strInsertSql);
                                if (n > 0)
                                {

                                    App.Msg("����ɹ�");
                                    //ÿ�α���һ�ζ�Ҫ���һ��
                                    list.Clear();
                                }
                                #endregion
                            }
                            else
                            {
                                App.Msg("����ʧ��");
                                list.Clear();
                                return;
                            }
                        }
                    }
                    if (strMark == "3")
                    {
                        if (fmgrDoctor == null)
                        {
                            #region �޸���Ϣ��Ϣ Ԭ�����130724
                            string strDatetimeU = App.GetSystemTime().ToString();//��ȡ��ǰ����ʱ��
                            string strContentU = "";
                            if (BingLiType == "1")
                            {
                                strContentU = "���β������յ÷�Ϊ" + zongSum;//��Ϣ����
                            }
                            else
                            {
                                strContentU = "���в�����ȱ�����޸�";//���в�����Ϣ����
                            }
                            string strUpdateSqlU = "update t_msg_info t set t.content='" + strContentU + "',t.operator_user_id='" + doctorID
                              + "',t.operator_user_name='" + doctorName + "',t.add_time=to_date('" + strDatetimeU + "','yyyy-MM-dd HH24:mi:ss'),t.msg_status='0' where t.pid='" + patientId + "'";
                            App.ExecuteSQL(strUpdateSqlU);
                            #endregion
                            return;
                        }
                        else
                        {
                            //�����е�������Ŀ�Ĳ��������list��������
                            //fmgr.addPingFen(list);

                            //ִ��Ҫ���������sql���
                            if (App.ExecuteBatch(list.ToArray()) > 0)
                            {
                                #region Ԭ����� ����������Ϣ����130724
                                string New_Id = App.GenId("t_msg_info", "id").ToString();//����
                                string strDoctor_name = "";//�ܴ�ҽ������
                                string strDoctor_id = "";//�ܴ�ҽ��id
                                string strDoctorSql = "select t.sick_doctor_id,t.sick_doctor_name from t_in_patient t where t.id='" + patientId + "'";
                                if (strDoctorSql.Length > 0)
                                {
                                    DataSet ds = App.GetDataSet(strDoctorSql);
                                    if (ds.Tables[0].Rows.Count > 0)
                                    {
                                        strDoctor_name = ds.Tables[0].Rows[0]["sick_doctor_name"].ToString();//�ܴ�ҽ��������ֵ
                                        strDoctor_id = ds.Tables[0].Rows[0]["sick_doctor_id"].ToString();//�ܴ�ҽ��id��ֵ
                                    }
                                }
                                string strDatetime = App.GetSystemTime().ToString();//��ȡ��ǰ����ʱ��

                                string strContent = "";
                                if (BingLiType == "1")
                                {
                                    strContent = "���β������յ÷�Ϊ" + zongSum;//��Ϣ����
                                }
                                else
                                {
                                    strContent = "���в�����ȱ�����޸�";//���в�����Ϣ����
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
   ('" + New_Id + "','" + patientId + "','', '" + strDoctor_id + "','" + strDoctor_name + "','" + doctorID + "','" + doctorName + "', '','','22','" + strContent + "',to_date('" + strDatetime + "','yyyy-MM-dd HH24:mi:ss'),'0', '','��������','', '','','','','','','17','')";
                                int n = App.ExecuteSQL(strInsertSql);
                                if (n > 0)
                                {

                                    App.Msg("����ɹ�");
                                    //ÿ�α���һ�ζ�Ҫ���һ��
                                    list.Clear();
                                }
                                #endregion
                            }
                            else
                            {
                                App.Msg("����ʧ��");
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
                    App.MsgErr("��ȷ�������������������Ƿ�һ�£��Լ���д����ȷ������ԭ��" + ex.Message);
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
                App.MsgWaring("û�д򿪵����飡");
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
            //int rows = this.c1FlexGrid1_bingchengjilu.RowSel;//����ѡ�е��к�
            //if (rows >= 0)
            //{
            //    if (c1FlexGrid1_bingchengjilu[rows, "��"].ToString().ToLower() == "true")
            //    {
            //        if (string.IsNullOrEmpty(c1FlexGrid1_bingchengjilu[rows, "�۷�"].ToString()))
            //        {
            //            c1FlexGrid1_bingchengjilu[rows, "�۷�"] = c1FlexGrid1_bingchengjilu[rows, "�����ֵ"];
            //        }
            //    }
            //    else
            //    {
            //        c1FlexGrid1_bingchengjilu[rows, "�۷�"] = null;
            //    }
            //}
        }

        private void c1FlexGrid1_ruYuanJilu_MouseUp(object sender, MouseEventArgs e)
        {
            //int rows = this.c1FlexGrid1_ruYuanJilu.RowSel;//����ѡ�е��к�
            //if (rows >= 0)
            //{
            //    if (c1FlexGrid1_ruYuanJilu[rows, "��"].ToString().ToLower() == "true")
            //    {
            //        if (string.IsNullOrEmpty(c1FlexGrid1_ruYuanJilu[rows, "�۷�"].ToString()))
            //        {
            //            c1FlexGrid1_ruYuanJilu[rows, "�۷�"] = c1FlexGrid1_ruYuanJilu[rows, "�����ֵ"];
            //        }
            //    }
            //    else
            //    {
            //        c1FlexGrid1_ruYuanJilu[rows, "�۷�"] = null;
            //    }
            //}
        }

        private void c1FlexGrid1_BingAnShouYe_MouseUp(object sender, MouseEventArgs e)
        {
            //int rows = this.c1FlexGrid1_BingAnShouYe.RowSel;//����ѡ�е��к�

            //if (rows >= 0)
            //{
            //    if (c1FlexGrid1_BingAnShouYe[rows, "��"].ToString().ToLower() == "true")
            //    {
            //        c1FlexGrid1_BingAnShouYe[rows, "�۷�"] = c1FlexGrid1_BingAnShouYe[rows, "�����ֵ"];
            //    }
            //    else
            //    {
            //        c1FlexGrid1_BingAnShouYe[rows, "�۷�"] = null;
            //    }
            //}
        }

        private void c1FlexGrid1_chuyuansiwang_MouseUp(object sender, MouseEventArgs e)
        {
            //int rows = this.c1FlexGrid1_chuyuansiwang.RowSel;//����ѡ�е��к�
            //if (rows >= 0)
            //{
            //    if (c1FlexGrid1_chuyuansiwang[rows, "��"].ToString().ToLower() == "true")
            //    {
            //        if (string.IsNullOrEmpty(c1FlexGrid1_chuyuansiwang[rows, "�۷�"].ToString()))
            //        {
            //            c1FlexGrid1_chuyuansiwang[rows, "�۷�"] = c1FlexGrid1_chuyuansiwang[rows, "�����ֵ"];
            //        }
            //    }
            //    else
            //    {
            //        c1FlexGrid1_chuyuansiwang[rows, "�۷�"] = null;
            //    }
            //}
        }

        private void c1FlexGrid1_fuzhujiancha_MouseUp(object sender, MouseEventArgs e)
        {
            //int rows = this.c1FlexGrid1_fuzhujiancha.RowSel;//����ѡ�е��к�
            //if (rows >= 0)
            //{
            //    if (c1FlexGrid1_fuzhujiancha[rows, "��"].ToString().ToLower() == "true")
            //    {
            //        c1FlexGrid1_fuzhujiancha[rows, "�۷�"] = c1FlexGrid1_fuzhujiancha[rows, "�����ֵ"];
            //    }
            //    else
            //    {
            //        c1FlexGrid1_fuzhujiancha[rows, "�۷�"] = null;
            //    }
            //}
        }

        private void c1FlexGrid1_jibenyaoqiu_MouseUp(object sender, MouseEventArgs e)
        {
            //int rows = this.c1FlexGrid1_jibenyaoqiu.RowSel;//����ѡ�е��к�
            //if (rows >= 0)
            //{
            //    if (c1FlexGrid1_jibenyaoqiu[rows, "��"].ToString().ToLower() == "true")
            //    {
            //        c1FlexGrid1_jibenyaoqiu[rows, "�۷�"] = c1FlexGrid1_jibenyaoqiu[rows, "�����ֵ"];
            //    }
            //    else
            //    {
            //        c1FlexGrid1_jibenyaoqiu[rows, "�۷�"] = null;
            //    }
            //}
        }
        private void c1FlexGrid1_zhiqingtongyi_MouseUp(object sender, MouseEventArgs e)
        {
            //int rows = this.c1FlexGrid1_jibenyaoqiu.RowSel;//����ѡ�е��к�
            //if (rows >= 0)
            //{
            //    if (c1FlexGrid1_zhiqingtongyi[rows, "��"].ToString().ToLower() == "true")
            //    {
            //        c1FlexGrid1_zhiqingtongyi[rows, "�۷�"] = c1FlexGrid1_zhiqingtongyi[rows, "�۷ֱ�׼"];
            //    }
            //    else
            //    {
            //        c1FlexGrid1_zhiqingtongyi[rows, "�۷�"] = null;
            //    }
            //}
        }
        /// <summary>
        /// ���˫�����Ҳ�������� ������ҳ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGrid1_BingAnShouYe_Click(object sender, EventArgs e) //  ע�⣺������˫���¼���ֻ��������click
        {
            try
            {

                int rows = this.c1FlexGrid1_BingAnShouYe.RowSel;
                if (!CheckWS() && c1FlexGrid1_BingAnShouYe[rows, "���͹۷���"].ToString() == "Y")
                {
                    MessageBox.Show("û�д򿪵����飡");
                    return;
                }
                //if (rows >= 0)
                //{
                //    if (c1FlexGrid1_BingAnShouYe[rows, "��"].ToString() == "True")
                //    {
                //        c1FlexGrid1_BingAnShouYe[rows, "�۷�"] = c1FlexGrid1_BingAnShouYe[rows, "�����ֵ"];
                //    }
                //    else
                //    {
                //        App.Msg("����ѡ��۷��");
                //        return;
                //    }
                //}
                Row newRow = c1FlexGrid2.Rows.Add();
                string strBingAnShouYe_PatientID = patientId;
                if (strBingAnShouYe_PatientID != "")
                {
                    newRow["����id"] = Convert.ToInt32(strBingAnShouYe_PatientID);//ȡ������id
                }
                newRow["������Ŀ"] = "������ҳ";
                if (c1FlexGrid1_BingAnShouYe[rows, "�����ֵ"].ToString() != "")
                {
                    newRow["��ֵ"] = c1FlexGrid1_BingAnShouYe[rows, "�����ֵ"];
                }
                else
                {
                    App.Msg("����ѡ��۷��");
                    return;
                }
                if (c1FlexGrid1_BingAnShouYe[rows, "�۷ֱ�׼"].ToString() != "")
                {
                    newRow["�۷ֱ�׼"] = c1FlexGrid1_BingAnShouYe[rows, "�۷ֱ�׼"];
                }
                newRow["�۷�����"] = "";
                if (c1FlexGrid1_BingAnShouYe[rows, "ID"].ToString() != "")
                {
                    newRow["medical_mark_id"] = c1FlexGrid1_BingAnShouYe[rows, "ID"];
                }
                if (c1FlexGrid1_BingAnShouYe[rows, "���͹۷���"].ToString() == "Y")
                {
                    newRow["item_type"] = c1FlexGrid1_BingAnShouYe[rows, "���͹۷���"];
                    AddMark(newRow["medical_mark_id"].ToString(), newRow["������Ŀ"].ToString(), newRow["�۷ֱ�׼"].ToString(), newRow["��ֵ"].ToString(), newRow["����id"].ToString(), App.ReadSqlVal("select T_DEDUCT_SCORE_ID.NEXTVAL from dual", 0, "NEXTVAL"));
                }
                if (c1FlexGrid1_BingAnShouYe[rows, "���͹۷���"].ToString() == "N")
                {
                    newRow["item_type"] = c1FlexGrid1_BingAnShouYe[rows, "���͹۷���"];
                    AddMarkN(newRow["medical_mark_id"].ToString(), newRow["������Ŀ"].ToString(), newRow["�۷ֱ�׼"].ToString(), newRow["��ֵ"].ToString(), newRow["����id"].ToString(), App.ReadSqlVal("select T_DEDUCT_SCORE_ID.NEXTVAL from dual", 0, "NEXTVAL"));

                }
                SetKouFenHuiZong();

            }
            catch
            {


            }
        }
        /// <summary>
        /// ɾ������
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
        /// ɾ����ǰ�۷ּ�¼
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
                        MessageBox.Show("ɾ���ɹ���");
                        c1FlexGrid2.Rows.Remove(rows);
                    }
                }
                else
                {
                    App.Msg("��ѡ��һ�н���ɾ��!");
                }

            }
        }
        /// <summary>
        /// ���˫�����Ҳ�������� ��Ժ��¼
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
                //    if (c1FlexGrid1_ruYuanJilu[rows, "��"].ToString() == "True")
                //    {
                //        c1FlexGrid1_ruYuanJilu[rows, "�۷�"] = c1FlexGrid1_ruYuanJilu[rows, "�����ֵ"];
                //    }
                //    else
                //    {
                //        App.Msg("����ѡ��۷��");
                //        return;
                //    }
                //}
                if (!CheckWS() && c1FlexGrid1_ruYuanJilu[rows, "���͹۷���"].ToString() == "Y")
                {
                    MessageBox.Show("û�д򿪵����飡");
                    return;
                }
                Row newRow = c1FlexGrid2.Rows.Add();
                string strruYuanJilu_PatientID = patientId;
                if (strruYuanJilu_PatientID != "")
                {
                    newRow["����id"] = Convert.ToInt32(strruYuanJilu_PatientID);//ȡ������id
                }
                newRow["������Ŀ"] = "��Ժ��¼";
                if (c1FlexGrid1_ruYuanJilu[rows, "�����ֵ"].ToString() != "")
                {
                    newRow["��ֵ"] = c1FlexGrid1_ruYuanJilu[rows, "�����ֵ"];
                    newRow["�ȽϷ�ֵ"] = c1FlexGrid1_ruYuanJilu[rows, "�����ֵ"];
                }
                else
                {
                    App.Msg("����ѡ��۷��");
                    return;
                }
                if (c1FlexGrid1_ruYuanJilu[rows, "�۷ֱ�׼"].ToString() != "")
                {
                    newRow["�۷ֱ�׼"] = c1FlexGrid1_ruYuanJilu[rows, "�۷ֱ�׼"];
                }
                newRow["�۷�����"] = "";
                if (c1FlexGrid1_ruYuanJilu[rows, "ID"].ToString() != "")
                {
                    newRow["medical_mark_id"] = c1FlexGrid1_ruYuanJilu[rows, "ID"];
                }
                if (c1FlexGrid1_ruYuanJilu[rows, "���͹۷���"].ToString() == "Y")
                {
                    newRow["item_type"] = c1FlexGrid1_ruYuanJilu[rows, "���͹۷���"];
                    AddMark(newRow["medical_mark_id"].ToString(), newRow["������Ŀ"].ToString(), newRow["�۷ֱ�׼"].ToString(), newRow["��ֵ"].ToString(), newRow["����id"].ToString(), App.ReadSqlVal("select T_DEDUCT_SCORE_ID.NEXTVAL from dual", 0, "NEXTVAL"));
                }
                if (c1FlexGrid1_ruYuanJilu[rows, "���͹۷���"].ToString() == "N")
                {
                    newRow["item_type"] = c1FlexGrid1_ruYuanJilu[rows, "���͹۷���"];
                    AddMarkN(newRow["medical_mark_id"].ToString(), newRow["������Ŀ"].ToString(), newRow["�۷ֱ�׼"].ToString(), newRow["��ֵ"].ToString(), newRow["����id"].ToString(), App.ReadSqlVal("select T_DEDUCT_SCORE_ID.NEXTVAL from dual", 0, "NEXTVAL"));

                }
                SetKouFenHuiZong();
            }
            catch
            {


            }
        }
        /// <summary>
        /// ���˫�����Ҳ�������� ���̼�¼
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
                //    if (c1FlexGrid1_bingchengjilu[rows, "��"].ToString() == "True")
                //    {
                //        c1FlexGrid1_bingchengjilu[rows, "�۷�"] = c1FlexGrid1_bingchengjilu[rows, "�����ֵ"];
                //    }
                //    else
                //    {
                //        App.Msg("����ѡ��۷��");
                //        return;
                //    }
                //}
                if (!CheckWS() && c1FlexGrid1_bingchengjilu[rows, "���͹۷���"].ToString() == "Y")
                {
                    MessageBox.Show("û�д򿪵����飡");
                    return;
                }
                Row newRow = c1FlexGrid2.Rows.Add();
                string strbingchengjilu_PatientID = patientId;
                if (strbingchengjilu_PatientID != "")
                {
                    newRow["����id"] = Convert.ToInt32(strbingchengjilu_PatientID);//ȡ������id
                }
                newRow["������Ŀ"] = "���̼�¼";
                if (c1FlexGrid1_bingchengjilu[rows, "�����ֵ"].ToString() != "")
                {
                    newRow["��ֵ"] = c1FlexGrid1_bingchengjilu[rows, "�����ֵ"];
                    newRow["�ȽϷ�ֵ"] = c1FlexGrid1_bingchengjilu[rows, "�����ֵ"];
                }
                else
                {
                    App.Msg("����ѡ��۷��");
                    return;
                }
                if (c1FlexGrid1_bingchengjilu[rows, "�۷ֱ�׼"].ToString() != "")
                {
                    newRow["�۷ֱ�׼"] = c1FlexGrid1_bingchengjilu[rows, "�۷ֱ�׼"];
                }
                newRow["�۷�����"] = "";
                if (c1FlexGrid1_bingchengjilu[rows, "ID"].ToString() != "")
                {
                    newRow["medical_mark_id"] = c1FlexGrid1_bingchengjilu[rows, "ID"];
                }
                if (c1FlexGrid1_bingchengjilu[rows, "���͹۷���"].ToString() == "Y")
                {
                    newRow["item_type"] = c1FlexGrid1_bingchengjilu[rows, "���͹۷���"];
                    AddMark(newRow["medical_mark_id"].ToString(), newRow["������Ŀ"].ToString(), newRow["�۷ֱ�׼"].ToString(), newRow["��ֵ"].ToString(), newRow["����id"].ToString(), App.ReadSqlVal("select T_DEDUCT_SCORE_ID.NEXTVAL from dual", 0, "NEXTVAL"));
                }
                if (c1FlexGrid1_bingchengjilu[rows, "���͹۷���"].ToString() == "N")
                {
                    newRow["item_type"] = c1FlexGrid1_bingchengjilu[rows, "���͹۷���"];
                    AddMarkN(newRow["medical_mark_id"].ToString(), newRow["������Ŀ"].ToString(), newRow["�۷ֱ�׼"].ToString(), newRow["��ֵ"].ToString(), newRow["����id"].ToString(), App.ReadSqlVal("select T_DEDUCT_SCORE_ID.NEXTVAL from dual", 0, "NEXTVAL"));

                }
                SetKouFenHuiZong();
            }
            catch
            {


            }
        }
        /// <summary>
        /// ���˫�����Ҳ�������� ��Ժ��¼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGrid1_chuyuansiwang_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                int rows = this.c1FlexGrid1_chuyuansiwang.RowSel;
                if (!CheckWS() && c1FlexGrid1_chuyuansiwang[rows, "���͹۷���"].ToString() == "Y")
                {
                    MessageBox.Show("û�д򿪵����飡");
                    return;
                }
                //if (rows >= 0)
                //{
                //    if (c1FlexGrid1_chuyuansiwang[rows, "��"].ToString() == "True")
                //    {
                //        c1FlexGrid1_chuyuansiwang[rows, "�۷�"] = c1FlexGrid1_chuyuansiwang[rows, "�����ֵ"];
                //    }
                //    else
                //    {
                //        App.Msg("����ѡ��۷��");
                //        return;
                //    }
                //}
                Row newRow = c1FlexGrid2.Rows.Add();
                string strchuyuansiwang_PatientID = patientId;
                if (strchuyuansiwang_PatientID != "")
                {
                    newRow["����id"] = Convert.ToInt32(strchuyuansiwang_PatientID);//ȡ������id
                }
                newRow["������Ŀ"] = "��Ժ��¼";
                if (c1FlexGrid1_chuyuansiwang[rows, "�����ֵ"].ToString() != "")
                {
                    newRow["��ֵ"] = c1FlexGrid1_chuyuansiwang[rows, "�����ֵ"];
                    newRow["�ȽϷ�ֵ"] = c1FlexGrid1_chuyuansiwang[rows, "�����ֵ"];
                }
                else
                {
                    App.Msg("����ѡ��۷��");
                    return;
                }
                if (c1FlexGrid1_chuyuansiwang[rows, "�۷ֱ�׼"].ToString() != "")
                {
                    newRow["�۷ֱ�׼"] = c1FlexGrid1_chuyuansiwang[rows, "�۷ֱ�׼"];
                }
                newRow["�۷�����"] = "";
                if (c1FlexGrid1_chuyuansiwang[rows, "ID"].ToString() != "")
                {
                    newRow["medical_mark_id"] = c1FlexGrid1_chuyuansiwang[rows, "ID"];
                }
                if (c1FlexGrid1_chuyuansiwang[rows, "���͹۷���"].ToString() == "Y")
                {
                    newRow["item_type"] = c1FlexGrid1_chuyuansiwang[rows, "���͹۷���"];
                    AddMark(newRow["medical_mark_id"].ToString(), newRow["������Ŀ"].ToString(), newRow["�۷ֱ�׼"].ToString(), newRow["��ֵ"].ToString(), newRow["����id"].ToString(), App.ReadSqlVal("select T_DEDUCT_SCORE_ID.NEXTVAL from dual", 0, "NEXTVAL"));
                }
                if (c1FlexGrid1_chuyuansiwang[rows, "���͹۷���"].ToString() == "N")
                {
                    newRow["item_type"] = c1FlexGrid1_chuyuansiwang[rows, "���͹۷���"];
                    AddMarkN(newRow["medical_mark_id"].ToString(), newRow["������Ŀ"].ToString(), newRow["�۷ֱ�׼"].ToString(), newRow["��ֵ"].ToString(), newRow["����id"].ToString(), App.ReadSqlVal("select T_DEDUCT_SCORE_ID.NEXTVAL from dual", 0, "NEXTVAL"));

                }
                SetKouFenHuiZong();
            }
            catch
            {


            }
        }
        /// <summary>
        /// ���������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGrid1_fuzhujiancha_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int rows = this.c1FlexGrid1_fuzhujiancha.RowSel;
                if (!CheckWS() && c1FlexGrid1_fuzhujiancha[rows, "���͹۷���"].ToString() == "Y")
                {
                    MessageBox.Show("û�д򿪵����飡");
                    return;
                }
                //if (rows >= 0)
                //{
                //    if (c1FlexGrid1_fuzhujiancha[rows, "��"].ToString() == "True")
                //    {
                //        c1FlexGrid1_fuzhujiancha[rows, "�۷�"] = c1FlexGrid1_fuzhujiancha[rows, "�����ֵ"];
                //    }
                //    else
                //    {
                //        App.Msg("����ѡ��۷��");
                //        return;
                //    }
                //}
                Row newRow = c1FlexGrid2.Rows.Add();
                string strfuzhujiancha_PatientID = patientId;
                if (strfuzhujiancha_PatientID != "")
                {
                    newRow["����id"] = Convert.ToInt32(strfuzhujiancha_PatientID);//ȡ������id
                }
                newRow["������Ŀ"] = "�������";
                if (c1FlexGrid1_fuzhujiancha[rows, "�۷ֱ�׼"].ToString() != "")
                {
                    newRow["�۷ֱ�׼"] = c1FlexGrid1_fuzhujiancha[rows, "�۷ֱ�׼"];
                }
                else
                {
                    App.Msg("����ѡ��۷��");
                    return;
                }
                if (c1FlexGrid1_fuzhujiancha[rows, "�����ֵ"].ToString() != "")
                {
                    newRow["��ֵ"] = c1FlexGrid1_fuzhujiancha[rows, "�����ֵ"];
                    newRow["�ȽϷ�ֵ"] = c1FlexGrid1_fuzhujiancha[rows, "�����ֵ"];
                }
                newRow["�۷�����"] = "";
                if (c1FlexGrid1_fuzhujiancha[rows, "ID"].ToString() != "")
                {
                    newRow["medical_mark_id"] = c1FlexGrid1_fuzhujiancha[rows, "ID"];
                }
                if (c1FlexGrid1_fuzhujiancha[rows, "���͹۷���"].ToString() == "Y")
                {
                    newRow["item_type"] = c1FlexGrid1_fuzhujiancha[rows, "���͹۷���"];
                    AddMark(newRow["medical_mark_id"].ToString(), newRow["������Ŀ"].ToString(), newRow["�۷ֱ�׼"].ToString(), newRow["��ֵ"].ToString(), newRow["����id"].ToString(), App.ReadSqlVal("select T_DEDUCT_SCORE_ID.NEXTVAL from dual", 0, "NEXTVAL"));
                }
                if (c1FlexGrid1_fuzhujiancha[rows, "���͹۷���"].ToString() == "N")
                {
                    newRow["item_type"] = c1FlexGrid1_fuzhujiancha[rows, "���͹۷���"];
                    AddMarkN(newRow["medical_mark_id"].ToString(), newRow["������Ŀ"].ToString(), newRow["�۷ֱ�׼"].ToString(), newRow["��ֵ"].ToString(), newRow["����id"].ToString(), App.ReadSqlVal("select T_DEDUCT_SCORE_ID.NEXTVAL from dual", 0, "NEXTVAL"));

                }
                SetKouFenHuiZong();
            }
            catch
            {


            }
        }
        /// <summary>
        /// ��дҪ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGrid1_jibenyaoqiu_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                int rows = this.c1FlexGrid1_jibenyaoqiu.RowSel;
                if (!CheckWS() && c1FlexGrid1_jibenyaoqiu[rows, "���͹۷���"].ToString() == "Y")
                {
                    MessageBox.Show("û�д򿪵����飡");
                    return;
                }
                //if (rows >= 0)
                //{
                //    if (c1FlexGrid1_jibenyaoqiu[rows, "��"].ToString() == "True")
                //    {
                //        c1FlexGrid1_jibenyaoqiu[rows, "�۷�"] = c1FlexGrid1_jibenyaoqiu[rows, "�����ֵ"];
                //    }
                //    else
                //    {
                //        App.Msg("����ѡ��۷��");
                //        return;
                //    }
                //}
                Row newRow = c1FlexGrid2.Rows.Add();
                string strjibenyaoqiu_PatientID = patientId;
                if (strjibenyaoqiu_PatientID != "")
                {
                    newRow["����id"] = Convert.ToInt32(strjibenyaoqiu_PatientID);//ȡ������id
                }
                newRow["������Ŀ"] = "��дҪ��";
                if (c1FlexGrid1_jibenyaoqiu[rows, "�����ֵ"].ToString() != "")
                {
                    newRow["��ֵ"] = c1FlexGrid1_jibenyaoqiu[rows, "�����ֵ"];
                    newRow["�ȽϷ�ֵ"] = c1FlexGrid1_jibenyaoqiu[rows, "�����ֵ"];
                }
                else
                {
                    App.Msg("����ѡ��۷��");
                    return;
                }
                if (c1FlexGrid1_jibenyaoqiu[rows, "�۷ֱ�׼"].ToString() != "")
                {
                    newRow["�۷ֱ�׼"] = c1FlexGrid1_jibenyaoqiu[rows, "�۷ֱ�׼"];
                }
                newRow["�۷�����"] = "";
                if (c1FlexGrid1_jibenyaoqiu[rows, "ID"].ToString() != "")
                {
                    newRow["medical_mark_id"] = c1FlexGrid1_jibenyaoqiu[rows, "ID"];
                }
                if (c1FlexGrid1_jibenyaoqiu[rows, "���͹۷���"].ToString() == "Y")
                {
                    newRow["item_type"] = c1FlexGrid1_jibenyaoqiu[rows, "���͹۷���"];
                    AddMark(newRow["medical_mark_id"].ToString(), newRow["������Ŀ"].ToString(), newRow["�۷ֱ�׼"].ToString(), newRow["��ֵ"].ToString(), newRow["����id"].ToString(), App.ReadSqlVal("select T_DEDUCT_SCORE_ID.NEXTVAL from dual", 0, "NEXTVAL"));
                }
                if (c1FlexGrid1_jibenyaoqiu[rows, "���͹۷���"].ToString() == "N")
                {
                    newRow["item_type"] = c1FlexGrid1_jibenyaoqiu[rows, "���͹۷���"];
                    AddMarkN(newRow["medical_mark_id"].ToString(), newRow["������Ŀ"].ToString(), newRow["�۷ֱ�׼"].ToString(), newRow["��ֵ"].ToString(), newRow["����id"].ToString(), App.ReadSqlVal("select T_DEDUCT_SCORE_ID.NEXTVAL from dual", 0, "NEXTVAL"));

                }
                SetKouFenHuiZong();
            }
            catch
            {


            }
        }
        /// <summary>
        /// ֪��ͬ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGrid1_zhiqingtongyi_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (!CheckWS())
                {
                    MessageBox.Show("û�д򿪵����飡");
                    return;
                }
                int rows = this.c1FlexGrid1_zhiqingtongyi.RowSel;
                //if (rows >= 0)
                //{
                //    if (c1FlexGrid1_zhiqingtongyi[rows, "��"].ToString() == "True")
                //    {
                //        c1FlexGrid1_zhiqingtongyi[rows, "�۷�"] = c1FlexGrid1_zhiqingtongyi[rows, "�۷ֱ�׼"];
                //    }
                //    else
                //    {
                //        App.Msg("����ѡ��۷��");
                //        return;
                //    }
                //}

                Row newRow = c1FlexGrid2.Rows.Add();
                string strzhiqingtongyi_PatientID = patientId;
                if (strzhiqingtongyi_PatientID != "")
                {
                    newRow["����id"] = Convert.ToInt32(strzhiqingtongyi_PatientID);//ȡ������id
                }
                newRow["������Ŀ"] = "֪��ͬ����";
                if (c1FlexGrid1_zhiqingtongyi[rows, "�����ֵ"].ToString() != "")
                {
                    newRow["��ֵ"] = c1FlexGrid1_zhiqingtongyi[rows, "�����ֵ"];
                    newRow["�ȽϷ�ֵ"] = c1FlexGrid1_zhiqingtongyi[rows, "�����ֵ"];
                }
                else
                {
                    App.Msg("����ѡ��۷��");
                    return;
                }
                if (c1FlexGrid1_zhiqingtongyi[rows, "�۷ֱ�׼"].ToString() != "")
                {
                    newRow["�۷ֱ�׼"] = c1FlexGrid1_zhiqingtongyi[rows, "�۷ֱ�׼"];
                }
                newRow["�۷�����"] = "";
                if (c1FlexGrid1_zhiqingtongyi[rows, "ID"].ToString() != "")
                {
                    newRow["medical_mark_id"] = c1FlexGrid1_zhiqingtongyi[rows, "ID"];
                }

                AddMark(newRow["medical_mark_id"].ToString(), newRow["������Ŀ"].ToString(), newRow["�۷ֱ�׼"].ToString(), newRow["��ֵ"].ToString(), newRow["����id"].ToString(), App.ReadSqlVal("select T_DEDUCT_SCORE_ID.NEXTVAL from dual", 0, "NEXTVAL"));


                SetKouFenHuiZong();
            }
            catch
            {


            }
        }
        /// <summary>
        /// ҽ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void c1FlexGrid1_DoubleClick(object sender, EventArgs e)
        {
            try
            {

                int rows = this.c1FlexGrid1_yizhudan.RowSel;
                if (!CheckWS() && c1FlexGrid1_yizhudan[rows, "���͹۷���"].ToString() == "Y")
                {
                    MessageBox.Show("û�д򿪵����飡");
                    return;
                }

                Row newRow = c1FlexGrid2.Rows.Add();
                string strYIZHUDAN_PatientID = patientId;
                if (strYIZHUDAN_PatientID != "")
                {
                    newRow["����id"] = Convert.ToInt32(strYIZHUDAN_PatientID);//ȡ������id
                }
                newRow["������Ŀ"] = "ҽ����";
                if (c1FlexGrid1_yizhudan[rows, "�����ֵ"].ToString() != "")
                {
                    newRow["��ֵ"] = c1FlexGrid1_yizhudan[rows, "�����ֵ"];
                    newRow["�ȽϷ�ֵ"] = c1FlexGrid1_yizhudan[rows, "�����ֵ"];
                }
                else
                {
                    App.Msg("����ѡ��۷��");
                    return;
                }
                if (c1FlexGrid1_yizhudan[rows, "�۷ֱ�׼"].ToString() != "")
                {
                    newRow["�۷ֱ�׼"] = c1FlexGrid1_yizhudan[rows, "�۷ֱ�׼"];
                }
                newRow["�۷�����"] = "";
                if (c1FlexGrid1_yizhudan[rows, "ID"].ToString() != "")
                {
                    newRow["medical_mark_id"] = c1FlexGrid1_yizhudan[rows, "ID"];
                }
                if (c1FlexGrid1_yizhudan[rows, "���͹۷���"].ToString() == "Y")
                {
                    newRow["item_type"] = c1FlexGrid1_yizhudan[rows, "���͹۷���"];
                    AddMark(newRow["medical_mark_id"].ToString(), newRow["������Ŀ"].ToString(), newRow["�۷ֱ�׼"].ToString(), newRow["��ֵ"].ToString(), newRow["����id"].ToString(), App.ReadSqlVal("select T_DEDUCT_SCORE_ID.NEXTVAL from dual", 0, "NEXTVAL"));
                }

                if (c1FlexGrid1_yizhudan[rows, "���͹۷���"].ToString() == "N")
                {
                    newRow["item_type"] = c1FlexGrid1_yizhudan[rows, "���͹۷���"];
                    AddMarkN(newRow["medical_mark_id"].ToString(), newRow["������Ŀ"].ToString(), newRow["�۷ֱ�׼"].ToString(), newRow["��ֵ"].ToString(), newRow["����id"].ToString(), App.ReadSqlVal("select T_DEDUCT_SCORE_ID.NEXTVAL from dual", 0, "NEXTVAL"));

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

                //��ȡ�༭������
                //tabControl1.Tabs[2].AttachedControl.Controls[0].Controls[0].Name
                //for (int i = 0; i < tabControl1.Tabs.Count; i++)
                //{
                //    if (tabControl1.Tabs[i].Text == "��������")
                //    {
                DevComponents.DotNetBar.TabControl tctlDoc = this.Controls.Find("tctlDoc", true)[0] as DevComponents.DotNetBar.TabControl;//tabControl1.Tabs[2].AttachedControl.Controls[0].Controls[0] as DevComponents.DotNetBar.TabControl;
                if (tctlDoc != null && tctlDoc.Tabs.Count > 0)
                {
                    frmText frm = tctlDoc.SelectedTab.AttachedControl.Controls[0] as frmText;
                    frm.MyDoc.InsertBAPF(id, item_con);// Ԭ����ʱע�͵�
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
                    App.MsgWaring("û�д򿪵����飡");
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
                    MessageBox.Show("ɾ���ɹ���");
                    DevComponents.DotNetBar.TabControl tctlDoc = this.Controls.Find("tctlDoc", true)[0] as DevComponents.DotNetBar.TabControl;//tabControl1.Tabs[2].AttachedControl.Controls[0].Controls[0] as DevComponents.DotNetBar.TabControl;
                    if (tctlDoc != null && tctlDoc.Tabs.Count > 0)
                    {
                        frmText frm = tctlDoc.SelectedTab.AttachedControl.Controls[0] as frmText;
                        //frm.MyDoc.InsertBAPF(id, item_con);// Ԭ����ʱע�͵�
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
                        App.MsgWaring("û�д򿪵����飡");
                    }
                    SetKouFenHuiZong();
                }
            }
        }

        private void btnZC_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < this.c1FlexGrid2.Rows.Count; i++)
            {
                #region �޸ĺ������
                int deductid = int.Parse(c1FlexGrid2[i, "id"].ToString());
                string fz = c1FlexGrid2[i, "��ֵ"].ToString();
                string ly = c1FlexGrid2[i, "�۷�����"].ToString();

                string sql = "update t_deduct_score set item_score ='" + fz + "',item_reason ='" + ly + "' where id =" + deductid;
                int a = App.ExecuteSQL(sql);
                #endregion
            }
        }

        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
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
                                App.Msg("ɾ���ɹ���");
                                c1FlexGrid2.Rows.Remove(rows);
                            }
                        }
                        else
                        {
                            App.Msg("��ѡ��һ�н���ɾ��!");
                        }

                    }
                }
                else
                {
                    App.Msg("����������ɾ��!");
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
                strMark_after = c1FlexGrid2[rows, "��ֵ"].ToString();
                strMark_before = c1FlexGrid2[rows, "�ȽϷ�ֵ"].ToString();
                if (Convert.ToDouble(strMark_after) > Convert.ToDouble(strMark_before))
                {

                    App.Msg("��ǰ�޸ĺ�ķ�ֵ�Ѿ���������ֵ,�������޸ģ�");
                    c1FlexGrid2[rows, "��ֵ"] = c1FlexGrid2[rows, "�ȽϷ�ֵ"];
                    return;

                }

                string kfbz = c1FlexGrid2[rows, "�۷ֱ�׼"].ToString();
                string kfly = c1FlexGrid2[rows, "�۷�����"].ToString();
                string id = c1FlexGrid2[rows, "ID"].ToString();

                DevComponents.DotNetBar.TabControl tctlDoc = this.Controls.Find("tctlDoc", true)[0] as DevComponents.DotNetBar.TabControl;//tabControl1.Tabs[2].AttachedControl.Controls[0].Controls[0] as DevComponents.DotNetBar.TabControl;
                if (tctlDoc != null && tctlDoc.Tabs.Count > 0)
                {
                    frmText frm = tctlDoc.SelectedTab.AttachedControl.Controls[0] as frmText;
                    //frm.MyDoc.InsertBAPF(id, kfbz + "\n�۷����ɣ�\n" + "    " + kfly);// Ԭ����ʱע�͵�
                    XmlDocument tempxmldoc = new XmlDocument();
                    tempxmldoc.PreserveWhitespace = true;
                    tempxmldoc.LoadXml("<emrtextdoc/>");
                    frm.MyDoc.ToXML(tempxmldoc.DocumentElement);

                    XmlNode bapf_xnl = tempxmldoc.SelectSingleNode("//bapf[@value=\"" + id + "\"]");

                    bapf_xnl.Attributes["sign"].Value = kfbz + "\n�۷����ɣ�\n" + "    " + kfly;


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
                    App.MsgWaring("û�д򿪵����飡");
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
        /// �鿴LIS��Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLis_Click(object sender, EventArgs e)
        {
            FrmLis fc = new FrmLis(this.pid);
            fc.WindowState = FormWindowState.Normal;
            fc.Show();
        }

        //�鿴PACS��Ϣ
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