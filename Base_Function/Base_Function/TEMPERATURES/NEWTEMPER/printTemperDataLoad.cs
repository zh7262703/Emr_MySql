using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using Bifrost;
using System.Data;
using System.Collections;
using Base_Function.TEMPERATURES;
using System.Globalization;
using Base_Function.MODEL;
using TempertureEditor.Element;
using TempertureEditor;

namespace Base_Function.BASE_COMMON
{
    public class printTemperDataLoad
    {
        public TempertureEditor.Element.Page currentpage = new TempertureEditor.Element.Page(); //��ǰҳ

       
        private Dictionary<string, string> user = new Dictionary<string, string>();
        private int pageIndex = 0;
        private int leftwidth = 110;//��ߵ�һ�п��
        private int gridColsWidth = 12;//���
        private Rectangle mainRec;//y:130,height:910 //1080
        private DateTime startTime; //��ʼʱ��
        private DateTime endTime;  //����ʱ��
        private string ToTime = string.Empty;   //��Ժʱ��
        private string pid = string.Empty; //����ID
        public List<DataTable> dbList = null; //���ݼ���
        private const int dayWidth = 72;  // һ��� ���
        private const int hourWidth = 12; // һ��ʱ�����
        public DateTime out_time;

        DataSet ds_operaters = new DataSet();
        InPatientInfo currPatient;

        /// <summary>
        /// ��ǰҳ��
        /// </summary>
        public int PageIndex
        {
            get { return pageIndex; }
            set { pageIndex = value; }
        }

        /// <summary>
        /// ��ӡ�û���Ϣ
        /// </summary>
        public Dictionary<string, string> User
        {
            get { return user; }
            set { user = value; }
        }

        private bool isDrawHeader = true;
        /// <summary>
        /// �Ƿ��ӡҳü
        /// </summary>
        public bool IsDrawHeader
        {
            get { return isDrawHeader; }
            set { isDrawHeader = value; }
        }

        private bool isDrawFooter = true;
        /// <summary>
        /// �Ƿ��ӡҳ��
        /// </summary>
        public bool IsDrawFooter
        {
            get { return isDrawFooter; }
            set { isDrawFooter = value; }
        }

        private string _hospital;
        /// <summary>
        /// ҽԺ����
        /// </summary>
        public string Hospital
        {
            get { return _hospital; }
            set { _hospital = value; }
        }

        private string _textName;
        /// <summary>
        /// ��������
        /// </summary>
        public string TextName
        {
            get { return _textName; }
            set { _textName = value; }
        }


        public void Init(string _pid, string _toTime)
        {
            /***
             * ����
             */
            if (dbList != null)
            {
                dbList.Clear();
            }
            this.pid = _pid;
            this.ToTime = _toTime;
            currPatient = DataInit.GetInpatientInfoByPid(pid);

            InitInOrOutTime();
        }

        /// <summary>
        /// �����ӣ�����Ժ�¼�
        /// </summary>
        private void InitInOrOutTime()
        {
            try
            {
                DateTime dtin = Convert.ToDateTime(user["��Ժ����:"]);
                DateTime dtinpoint = GetTimePoint(dtin);
                string describe = string.Empty;
                describe = "��Ժ_" + dtin.ToString("HH:mm");
                //������
                if (currPatient.PId.Contains("_"))
                {
                    dtin = Convert.ToDateTime(currPatient.Birthday);
                    dtinpoint = GetTimePoint(dtin);
                    describe = "����_" + dtin.ToString("HH:mm");
                }
                DataSet ryds = App.GetDataSet("select id from t_vital_signs t where t.patient_id=" + pid + " and  (t.describe like '%��Ժ%' or t.describe like '%����%')");
                if (ryds.Tables[0].Rows.Count == 0)
                {
                    string sql = string.Empty;
                    sql = "update T_VITAL_SIGNS t set t.describe='" + describe + "|'||t.describe where t.patient_id=" + pid + " and t.measure_time=to_date('" + dtinpoint.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss')";
                    int count = App.ExecuteSQL(sql);
                    if (count == 0)
                    {
                        int id = App.GenId();
                        string sql_in = "insert into T_VITAL_SIGNS (id,measure_time,describe,patient_id,measure_state,temperature_body)values("
                                        + id + ","
                                        + "to_date('" + dtinpoint.ToString("yyyy-MM-dd HH:mm") + "','yyyy-mm-dd hh24:mi')"
                                        + ",'" + describe + "'"
                                        + "," + pid + ",'F','0')";
                        App.ExecuteSQL(sql_in);
                    }
                }

                DataSet zrds = App.GetDataSet("select a.happen_time from T_Inhospital_Action a where a.patient_id='" + user["���:"].ToString() + "'  and a.action_type='ת��'");

                if (zrds != null && zrds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < zrds.Tables[0].Rows.Count; i++)
                    {
                        string zr_time = "ת��_" + Convert.ToDateTime(zrds.Tables[0].Rows[i]["happen_time"]).ToString("HH:mm");
                        DateTime dtout = Convert.ToDateTime(zrds.Tables[0].Rows[i]["happen_time"]);
                        DateTime dtoutpoint = GetTimePoint(dtout);
                        string str_zr = App.ReadSqlVal("select count(*) c from T_VITAL_SIGNS t where t.patient_id=" + pid + " and t.measure_time=to_date('" + dtoutpoint.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss')", 0, "c");
                        string zr_sql = string.Empty;
                        if (str_zr == null || str_zr == "0")//!str_zr.Contains("ת��"))
                        {
                            string sql_in = "insert into T_VITAL_SIGNS (id,measure_time,describe,patient_id,measure_state,temperature_body)values("
                                                + App.GenId() + ","
                                                + "to_date('" + dtoutpoint.ToString("yyyy-MM-dd HH:mm") + "','yyyy-mm-dd hh24:mi')"
                                                + ",'" + zr_time + "'"
                                                + "," + pid + ",'F','0')";
                            App.ExecuteSQL(sql_in);
                        }
                        else
                        {
                            str_zr = App.ReadSqlVal("select t.describe from T_VITAL_SIGNS t where t.patient_id=" + pid + " and t.measure_time=to_date('" + dtoutpoint.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss')", 0, "describe");
                            if (str_zr == null || !str_zr.Contains("ת��"))
                            {
                                zr_sql = "update T_VITAL_SIGNS t set t.describe='" + zr_time + "|'||t.describe where t.patient_id=" + pid + " and t.measure_time=to_date('" + dtoutpoint.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss')";
                                App.ExecuteSQL(zr_sql);
                            }
                        }
                    }
                }

                /*
                 * ��Ժ�¼��Զ����
                 */
                DataSet ds = null;
                if (user["��Ժ����:"].ToString() != "")
                {
                    string out_h_time = "��Ժ_" + Convert.ToDateTime(user["��Ժ����:"]).ToString("HH:mm");
                    DateTime dtout = Convert.ToDateTime(user["��Ժ����:"]);
                    DateTime dtoutpoint = GetTimePoint(dtout);
                    //�ò����Ѿ���Ժ
                    ds = App.GetDataSet("select t.id from t_vital_signs t inner join t_in_patient ti on t.patient_id=ti.id where t.patient_id=" + pid + " and (t.describe like '%��Ժ%' or t.describe like '%����%' or (instr(ti.pid,'_')>0 and t.describe like '%ת��%'))");
                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        int id = App.GenId();
                        string sql_out = "insert into T_VITAL_SIGNS (id,measure_time,describe,patient_id,measure_state,temperature_body)values("
                                        + id + ","
                                        + "to_date('" + dtoutpoint.ToString("yyyy-MM-dd HH:mm") + "','yyyy-mm-dd hh24:mi')"
                                        + ",'" + out_h_time + "'"
                                        + "," + pid + ",'F','0')";
                        App.ExecuteSQL(sql_out);
                    }
                }
            }
            catch
            { }
        }

        private DateTime GetTimePoint(DateTime dt)
        {
            DateTime dtReturn = dt.Date;
            #region 2,6,10,14,18,22
            if (dt < dt.Date.AddHours(4))
            {
                dtReturn = dtReturn.AddHours(2);
            }
            else if (dt < dt.Date.AddHours(8))
            {
                dtReturn = dtReturn.AddHours(6);
            }
            else if (dt < dt.Date.AddHours(12))
            {
                dtReturn = dtReturn.AddHours(10);
            }
            else if (dt < dt.Date.AddHours(16))
            {
                dtReturn = dtReturn.AddHours(14);
            }
            else if (dt < dt.Date.AddHours(20))
            {
                dtReturn = dtReturn.AddHours(18);
            }
            else
            {
                dtReturn = dtReturn.AddHours(22);
            }
            #endregion
            return dtReturn;
        }

        /// <summary>
        ///��ͨ���µ� ������
        /// </summary>
        /// <param name="_graph">��ͼ�豸</param>
        /// <param name="_startTime">��ʼʱ��</param>
        /// <param name="_endTime">����ʱ��</param>
        /// <param name="_pid">����id</param>
        /// <param name="_toTime">��Ժʱ��</param>
        /// <param name="_isChild">�Ƿ���������</param>
        public void printMain(string _startTime, string _endTime)
        {

            string sql = "select t.measure_time,t.describe from T_VITAL_SIGNS t where t.describe like '%����%'   and t.patient_id=" +
                          pid + " order by t.measure_time,t.describe asc";
            ds_operaters = App.GetDataSet(sql);

            this.startTime = Convert.ToDateTime(_startTime); //��ʼʱ��
            this.endTime = Convert.ToDateTime(_endTime);
            /***
             * ҳü
             */

            printHeader();
            dbList = null;
            dbList = GetTempertureCount(ToTime, startTime.ToString("yyyy-MM-dd"), endTime.ToString("yyyy-MM-dd"), this.pid);
            if (dbList == null)
            {
                App.Msg("���ݿⷱæ���Ժ����ԣ�");
                return;
            }
            printMain();
            /***
             *ҳ��
             */

            printFooter();
        }

        /// <summary>
        /// ��ӡҳü
        /// </summary>
        /// <param name="rec"></param>
        /// <param name="graph"></param>
        private void printHeader()
        {
            string datestr = Convert.ToDateTime(user["��Ժ����:"]).ToString("yyyy-MM-dd");
            user["��Ժ����:"] = datestr;
            string[] headlist = new string[] { "����", "����", "�Ա�", "���", "����", "����", "��Ժ����", "סԺ��" };

            for (int i = 0; i < headlist.Length; i++)
            {
                string itemtext = "";
                if (i == 0)
                {//"����",
                    itemtext = user[headlist[i] + ":"];

                    ClsDataObj tojbxm = new ClsDataObj();
                    tojbxm.Val = itemtext;
                    tojbxm.Rdatatime = "";
                    tojbxm.Typename = "����";
                    tojbxm.setdataxy(currentpage.Starttime);
                    currentpage.Objs.Add(tojbxm);
                }
                else if (i == 1)
                {//����
                    itemtext = user[headlist[i] + ":"];

                    ClsDataObj tojbAge = new ClsDataObj();
                    tojbAge.Val = itemtext;
                    tojbAge.Rdatatime = "";
                    tojbAge.Typename = "����";
                    tojbAge.setdataxy(currentpage.Starttime);
                    currentpage.Objs.Add(tojbAge);
                }
                else if (i == 2)
                {//�Ա�
                    itemtext = user[headlist[i] + ":"];

                    ClsDataObj tojbSex = new ClsDataObj();
                    tojbSex.Val = itemtext;
                    tojbSex.Rdatatime = "";
                    tojbSex.Typename = "�Ա�";
                    tojbSex.setdataxy(currentpage.Starttime);
                    currentpage.Objs.Add(tojbSex);
                }
                else if (i == 3)
                {//���
                    itemtext = user[headlist[i] + ":"];

                    ClsDataObj tojbDiag = new ClsDataObj();
                    tojbDiag.Val = itemtext;
                    tojbDiag.Rdatatime = "";
                    tojbDiag.Typename = "���";
                    tojbDiag.setdataxy(currentpage.Starttime);
                    currentpage.Objs.Add(tojbDiag);
                }
                else if (i == 4)
                {//�������ǲ��˿���
                    itemtext = user[headlist[i] + ":"];

                    ClsDataObj tojbSickRoom = new ClsDataObj();
                    tojbSickRoom.Val = itemtext;
                    tojbSickRoom.Rdatatime = "";
                    tojbSickRoom.Typename = "����";
                    tojbSickRoom.setdataxy(currentpage.Starttime);
                    currentpage.Objs.Add(tojbSickRoom);
                }
                else if (i == 5)
                {//����
                    itemtext = user[headlist[i] + ":"];

                    ClsDataObj tojbBedNo = new ClsDataObj();
                    tojbBedNo.Val = itemtext;
                    tojbBedNo.Rdatatime = "";
                    tojbBedNo.Typename = "��λ";
                    tojbBedNo.setdataxy(currentpage.Starttime);
                    currentpage.Objs.Add(tojbBedNo);
                }
                else if (i == 6)
                {//��Ժ����
                    itemtext = user[headlist[i] + ":"];

                    ClsDataObj tojbInTime = new ClsDataObj();
                    tojbInTime.Val = itemtext;
                    tojbInTime.Rdatatime = "";
                    tojbInTime.Typename = "��Ժʱ��";
                    tojbInTime.setdataxy(currentpage.Starttime);
                    currentpage.Objs.Add(tojbInTime);
                }
                else if (i == 7)
                {//סԺ��
                    itemtext = user[headlist[i] + ":"];

                    ClsDataObj tojbPid = new ClsDataObj();
                    tojbPid.Val = itemtext;
                    tojbPid.Rdatatime = "";
                    tojbPid.Typename = "סԺ��";
                    tojbPid.setdataxy(currentpage.Starttime);
                    currentpage.Objs.Add(tojbPid);
                }
            }
        }

        
        /// <summary>
        /// ��ӡҳ��
        /// </summary>
        private void printFooter()
        {
            ClsDataObj tojbPageNum = new ClsDataObj();
            tojbPageNum.Val = this.pageIndex.ToString();
            tojbPageNum.Rdatatime = "";
            tojbPageNum.Typename = "ҳ��";
            tojbPageNum.setdataxy(currentpage.Starttime);
            currentpage.Objs.Add(tojbPageNum);
        }

        /// <summary>
        /// ���µ�
        /// </summary>
        public void printMain()
        {
            mainRec = new Rectangle(64, 134, 614, 880);

            printTime();
            printData();

            dbList.Clear();
        }


        /// <summary>
        /// ���ݵ�ǰX���귵��ָ��������
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public DateTime GetSelectDay(int x)
        {
            DateTime nowTime=App.GetSystemTime();
            for (int i = 1; i <= 7; i++)
            {
                int objWidth = 38;
                if (x >= mainRec.Left + leftwidth + objWidth + (i - 1) * 6 * gridColsWidth && x < mainRec.Left + objWidth + leftwidth + i * 6 * gridColsWidth)
                {
                    for (int j = 1; j <= 6; j++)
                    {
                        if (x >= mainRec.Left + leftwidth + objWidth + (i - 1) * 6 * gridColsWidth + (j - 1) * gridColsWidth && x < mainRec.Left + objWidth + leftwidth + (i - 1) * 6 * gridColsWidth + j * gridColsWidth)
                        {
                            DateTime dtime = startTime.AddDays(i - 1).Date;
                            if (dtime.Date > nowTime.Date)
                            {
                                return nowTime;
                            }
                            switch (j)
                            {//2.6.10.14.18.22
                                case 1:
                                    return dtime.AddHours(2);
                                case 2:
                                    return dtime.AddHours(6);
                                case 3:
                                    return dtime.AddHours(10);
                                case 4:
                                    return dtime.AddHours(14);
                                case 5:
                                    return dtime.AddHours(18);
                                case 6:
                                    return dtime.AddHours(22);
                            }
                        }
                    }
                }
            }
            return nowTime;
        }


        /// <summary>
        /// ��ͨ���µ�����
        /// </summary>
        private void printData()
        {
            printTempers(); //��������
            printOther();   //������Ϣ
        }

        /// <summary>
        /// ��ͨ���µ���������
        /// </summary>
        private void printTempers()
        {
            DataTable tempers = dbList[0];             //������������

            if (tempers.Rows.Count > 0)
            {
                string measureState = string.Empty; //���²�������   
                string IS_ASSIST_BR = string.Empty;//����������

                TimeSpan begin = new TimeSpan(this.startTime.Ticks);
                string is_qixian = string.Empty;//�Ƿ�����

                for (int i = 0; i < tempers.Rows.Count; i++)
                {
                    DataRow currentRow = tempers.Rows[i]; //��ǰѭ����
                    string IS_ASSIST_BR_old = i > 0 ? tempers.Rows[i - 1]["IS_ASSIST_BR"].ToString() : "";//��һ�к���������
                    DateTime rowTime = Convert.ToDateTime(currentRow["measure_time"].ToString());//��ǰ��¼ʱ��
                    string measureTime = rowTime.ToString("yyyy-MM-dd HH:mm:ss");
                    measureState = currentRow["measure_state"].ToString(); //��ǰ��¼�������
                    string describe = currentRow["describe"].ToString();
                    IS_ASSIST_BR = currentRow["IS_ASSIST_BR"].ToString();
                    is_qixian = currentRow["is_qixian"].ToString();//�Ƿ�����
                    /***
                     * �����ǰ��¼�е�״̬Ϊ�Ѳ�
                     */

                    if (measureState != "R")
                    {
                        float temperValue = 0;
                        float coolValue = 0;
                        int pulseValue = 0;
                        int heartValue = 0;
                        int breathValue = 0;
                        int painValue = -1;
                        int painValue2 = -1;

                        string temperString = currentRow["temperature_value"].ToString();//����
                        string coolString = currentRow["cooling_value"].ToString();      //���º�����
                        string pulseString = currentRow["pulse_value"].ToString();       //����
                        string heartString = currentRow["heart_rhythm"].ToString();      //����
                        string breathString = currentRow["breath_value"].ToString();     //���� 
                        string painString = currentRow["PAIN_VALUE"].ToString();         //��ʹ 
                        string pain2String = currentRow["PAIN_VALUE2"].ToString();       //��ʹ��ֵ 
                        string reMeasure = currentRow["re_measure"].ToString();          //�����־
                        string reHeartMesure = currentRow["is_assist_hr"].ToString();
                        int temprtType = Convert.ToInt32(currentRow["temperature_body"]);//Ҹ���ڱ��ر�
                        

                        if (temperString != "")
                        {
                            float.TryParse(temperString, out temperValue);       //����
                        }
                        if (coolString != "")
                        {
                            float.TryParse(coolString, out coolValue);     //���º�����
                        }
                        if (pulseString != "")
                        {
                            int.TryParse(pulseString, out pulseValue);     //����
                        }
                        if (heartString != "")
                        {
                            int.TryParse(heartString, out heartValue);     //����
                        }
                        if (breathString != "")
                        {
                            int.TryParse(breathString, out breathValue);   //����                        
                        }
                        else
                        {
                            breathValue = -1;
                        }
                        if (painString != "")
                        {
                            int.TryParse(painString, out painValue);       //��ʹ                       
                        }
                        if (pain2String != "")
                        {
                            int.TryParse(pain2String, out painValue2);       //��ʹ��ֵ                       
                        }

                        #region ����

                        if (temperValue > 0 && temperValue < 35)
                        {
                            ClsDataObj tojbtemp = new ClsDataObj();
                            tojbtemp.Val = "����";
                            tojbtemp.Rdatatime = measureTime;
                            tojbtemp.Typename = "���²���";
                            tojbtemp.setdataxy(currentpage.Starttime);
                            currentpage.Objs.Add(tojbtemp);
                        }
                        else if (temperValue >= 35)
                        {
                            if (reMeasure == "Y")
                            {
                                if (temprtType == 0) //Ҹ��
                                {
                                    if (is_qixian == "Y")
                                    {
                                        ClsDataObj tojbyb = new ClsDataObj();
                                        tojbyb.Val = temperValue.ToString();
                                        tojbyb.Rdatatime = measureTime;
                                        tojbyb.Typename = "Ҹ�¸�������";
                                        tojbyb.setdataxy(currentpage.Starttime);
                                        currentpage.Objs.Add(tojbyb);
                                    }
                                    else
                                    {
                                        ClsDataObj tojbyb = new ClsDataObj();
                                        tojbyb.Val = temperValue.ToString();
                                        tojbyb.Rdatatime = measureTime;
                                        tojbyb.Typename = "Ҹ�¸���";
                                        tojbyb.setdataxy(currentpage.Starttime);
                                        currentpage.Objs.Add(tojbyb);
                                    }
                                }
                                else if (temprtType == 1) //�ڱ�
                                {
                                    if (is_qixian == "Y")
                                    {
                                        ClsDataObj tojbkb = new ClsDataObj();
                                        tojbkb.Val = temperValue.ToString();
                                        tojbkb.Rdatatime = measureTime;
                                        tojbkb.Typename = "���¸�������";
                                        tojbkb.setdataxy(currentpage.Starttime);
                                        currentpage.Objs.Add(tojbkb);
                                    }
                                    else
                                    {
                                        ClsDataObj tojbkb = new ClsDataObj();
                                        tojbkb.Val = temperValue.ToString();
                                        tojbkb.Rdatatime = measureTime;
                                        tojbkb.Typename = "���¸���";
                                        tojbkb.setdataxy(currentpage.Starttime);
                                        currentpage.Objs.Add(tojbkb);
                                    }
                                }
                                else //�ر�
                                {
                                    if (is_qixian == "Y")
                                    {
                                        ClsDataObj tojbgb = new ClsDataObj();
                                        tojbgb.Val = temperValue.ToString();
                                        tojbgb.Rdatatime = measureTime;
                                        tojbgb.Typename = "���¸�������";
                                        tojbgb.setdataxy(currentpage.Starttime);
                                        currentpage.Objs.Add(tojbgb);
                                    }
                                    else
                                    {
                                        ClsDataObj tojbgb = new ClsDataObj();
                                        tojbgb.Val = temperValue.ToString();
                                        tojbgb.Rdatatime = measureTime;
                                        tojbgb.Typename = "���¸���";
                                        tojbgb.setdataxy(currentpage.Starttime);
                                        currentpage.Objs.Add(tojbgb);
                                    }
                                }
                            }
                            else
                            {
                                if (temprtType == 0) //Ҹ��
                                {
                                    if (is_qixian == "Y")
                                    {
                                        ClsDataObj tojbyb = new ClsDataObj();
                                        tojbyb.Val = temperValue.ToString();
                                        tojbyb.Rdatatime = measureTime;
                                        tojbyb.Typename = "Ҹ������";
                                        tojbyb.setdataxy(currentpage.Starttime);
                                        currentpage.Objs.Add(tojbyb);
                                    }
                                    else
                                    {
                                        ClsDataObj tojbyb = new ClsDataObj();
                                        tojbyb.Val = temperValue.ToString();
                                        tojbyb.Rdatatime = measureTime;
                                        tojbyb.Typename = "Ҹ��";
                                        tojbyb.setdataxy(currentpage.Starttime);
                                        currentpage.Objs.Add(tojbyb);
                                    }
                                }
                                else if (temprtType == 1) //�ڱ�
                                {
                                    if (is_qixian == "Y")
                                    {
                                        ClsDataObj tojbkb = new ClsDataObj();
                                        tojbkb.Val = temperValue.ToString();
                                        tojbkb.Rdatatime = measureTime;
                                        tojbkb.Typename = "��������";
                                        tojbkb.setdataxy(currentpage.Starttime);
                                        currentpage.Objs.Add(tojbkb);
                                    }
                                    else
                                    {
                                        ClsDataObj tojbkb = new ClsDataObj();
                                        tojbkb.Val = temperValue.ToString();
                                        tojbkb.Rdatatime = measureTime;
                                        tojbkb.Typename = "����";
                                        tojbkb.setdataxy(currentpage.Starttime);
                                        currentpage.Objs.Add(tojbkb);
                                    }
                                }
                                else //�ر�
                                {
                                    if (is_qixian == "Y")
                                    {
                                        ClsDataObj tojbgb = new ClsDataObj();
                                        tojbgb.Val = temperValue.ToString();
                                        tojbgb.Rdatatime = measureTime;
                                        tojbgb.Typename = "��������";
                                        tojbgb.setdataxy(currentpage.Starttime);
                                        currentpage.Objs.Add(tojbgb);
                                    }
                                    else
                                    {
                                        ClsDataObj tojbgb = new ClsDataObj();
                                        tojbgb.Val = temperValue.ToString();
                                        tojbgb.Rdatatime = measureTime;
                                        tojbgb.Typename = "����";
                                        tojbgb.setdataxy(currentpage.Starttime);
                                        currentpage.Objs.Add(tojbgb);
                                    }
                                }
                            }
                        }

                        if (coolValue > 33 && coolValue < 42)
                        {
                            if (is_qixian == "Y")
                            {
                                ClsDataObj tojbcool = new ClsDataObj();
                                tojbcool.Val = coolValue.ToString();
                                tojbcool.Rdatatime = measureTime;
                                tojbcool.Typename = "���¡�����";
                                tojbcool.setdataxy(currentpage.Starttime);
                                currentpage.Objs.Add(tojbcool);
                            }
                            else
                            {
                                ClsDataObj tojbcool = new ClsDataObj();
                                tojbcool.Val = coolValue.ToString();
                                tojbcool.Rdatatime = measureTime;
                                tojbcool.Typename = "���¡�";
                                tojbcool.setdataxy(currentpage.Starttime);
                                currentpage.Objs.Add(tojbcool);
                            }
                        }
                        #endregion

                        #region ����

                        if (pulseValue > 0)
                        {
                            if (is_qixian == "Y")
                            {
                                ClsDataObj tojbpulse = new ClsDataObj();
                                tojbpulse.Val = pulseValue.ToString();
                                tojbpulse.Rdatatime = measureTime;
                                tojbpulse.Typename = "��������";
                                tojbpulse.setdataxy(currentpage.Starttime);
                                currentpage.Objs.Add(tojbpulse);
                            }
                            else
                            {
                                ClsDataObj tojbpulse = new ClsDataObj();
                                tojbpulse.Val = pulseValue.ToString();
                                tojbpulse.Rdatatime = measureTime;
                                tojbpulse.Typename = "����";
                                tojbpulse.setdataxy(currentpage.Starttime);
                                currentpage.Objs.Add(tojbpulse);
                            }
                        }
                        #endregion

                        #region ����

                        if (heartValue > 0)
                        {
                            if (is_qixian == "Y")
                            {
                                ClsDataObj tojbheart = new ClsDataObj();
                                tojbheart.Val = heartValue.ToString();
                                tojbheart.Rdatatime = measureTime;
                                tojbheart.Typename = "��������";
                                tojbheart.setdataxy(currentpage.Starttime);
                                currentpage.Objs.Add(tojbheart);
                            }
                            else
                            {
                                ClsDataObj tojbheart = new ClsDataObj();
                                tojbheart.Val = heartValue.ToString();
                                tojbheart.Rdatatime = measureTime;
                                tojbheart.Typename = "����";
                                tojbheart.setdataxy(currentpage.Starttime);
                                currentpage.Objs.Add(tojbheart);
                            }
                        }

                        #endregion 

                        #region ����

                        if (breathValue >= 0)
                        {
                            if (IS_ASSIST_BR == "Y")
                            {
                                if (is_qixian == "Y")
                                {
                                    ClsDataObj tojbassbr = new ClsDataObj();
                                    tojbassbr.Val = breathValue.ToString();
                                    tojbassbr.Rdatatime = measureTime;
                                    tojbassbr.Typename = "�˹���������";
                                    tojbassbr.setdataxy(currentpage.Starttime);
                                    currentpage.Objs.Add(tojbassbr);
                                }
                                else
                                {
                                    ClsDataObj tojbassbr = new ClsDataObj();
                                    tojbassbr.Val = breathValue.ToString();
                                    tojbassbr.Rdatatime = measureTime;
                                    tojbassbr.Typename = "�˹�����";
                                    tojbassbr.setdataxy(currentpage.Starttime);
                                    currentpage.Objs.Add(tojbassbr);
                                }
                            }
                            else
                            {
                                if (is_qixian == "Y")
                                {
                                    ClsDataObj tojbbr = new ClsDataObj();
                                    tojbbr.Val = breathValue.ToString();
                                    tojbbr.Rdatatime = measureTime;
                                    tojbbr.Typename = "��������";
                                    tojbbr.setdataxy(currentpage.Starttime);
                                    currentpage.Objs.Add(tojbbr);
                                }
                                else
                                {
                                    ClsDataObj tojbbr = new ClsDataObj();
                                    tojbbr.Val = breathValue.ToString();
                                    tojbbr.Rdatatime = measureTime;
                                    tojbbr.Typename = "����";
                                    tojbbr.setdataxy(currentpage.Starttime);
                                    currentpage.Objs.Add(tojbbr);
                                }
                            }

                            ClsDataObj tojbbrs = new ClsDataObj();
                            tojbbrs.Val = breathValue.ToString();
                            tojbbrs.Rdatatime = measureTime;
                            tojbbrs.Typename = "����S";
                            tojbbrs.setdataxy(currentpage.Starttime);
                            currentpage.Objs.Add(tojbbrs);
                        }

                        #endregion
                    }
                    else
                    {}

                    #region   �¼�
                    
                    if (describe != "")
                    {
                        //1�� ͬһ�����ж���¼�����ʾ��ʽΪͬһ��������ʾ�������
                        string s1 = string.Empty;
                        string s2 = string.Empty;
                        foreach (string var in describe.Split('|'))
                        {
                            if (var == "" || var.IndexOf('_') == -1)
                            {
                                continue;
                            }
                            string[] eventTime = var.Split('_');
                            string eventT = eventTime[0];
                            if (eventT.Contains("��Ժ"))
                            {
                                s1 = eventT;
                            }
                            else if (!eventT.Contains("����") && !eventT.Contains("����"))
                            {
                                if (!string.IsNullOrEmpty(s1) || !string.IsNullOrEmpty(s2))
                                    s2 += "|";
                                s2 += eventT;
                            }
                        }
                        describe = s1 + s2;

                        //string measure_time = currentRow["measure_time"].ToString();
                        //DateTime timepoint = GetTimePoint(Convert.ToDateTime(measure_time));

                        ClsDataObj tojbEvent = new ClsDataObj();
                        tojbEvent.Val = describe;
                        tojbEvent.Rdatatime = measureTime;
                        tojbEvent.Typename = "�¼�";
                        tojbEvent.setdataxy(currentpage.Starttime);
                        currentpage.Objs.Add(tojbEvent);
                    }
                    #endregion

                    bool Eventbool = false;
                    if (Eventbool == false)
                    {
                        string eventStr = GetEventState(measureState);

                        if (!string.IsNullOrEmpty(eventStr))
                        {
                            ClsDataObj tojbEvent = new ClsDataObj();
                            tojbEvent.Val = eventStr;
                            tojbEvent.Rdatatime = measureTime;
                            tojbEvent.Typename = "�¼�";
                            tojbEvent.setdataxy(currentpage.Starttime);
                            currentpage.Objs.Add(tojbEvent);
                        }
                    }
                }
 
            }

        }

        private string GetEventState(string state)
        {
            string text = "";
            switch (state)
            {
                case "W":
                    text = "���";
                    break;
                case "L":
                    text = "���";
                    break;
                case "Q":
                    text = "Ȱ����Ч���";
                    break;
                case "R":
                    text = "�ܲ�";
                    break;
                case "J":
                    text = "������";
                    break;
                case "O":
                    text = "˽�����";
                    break;
                case "T":
                    text = "ͣ��";
                    break;
            }

            return text;
        }

        
        /// <summary>
        /// ��ͨ���µ�������Ϣ
        /// </summary>
        private void printOther()
        {
            DataTable other = dbList[1];

            for (int i = 0; i < other.Rows.Count; i++)
            {
                DataRow currentRow = other.Rows[i];
                DateTime rowTime = Convert.ToDateTime(Convert.ToDateTime(currentRow["record_time"]).ToString("yyyy-MM-dd"));

                /*
                 * Ѫѹ
                 */
                string bp_blood = currentRow["bp_blood"].ToString();
                if (bp_blood != "")
                {
                    ClsDataObj tojbBlood = new ClsDataObj();
                    tojbBlood.Val = bp_blood;
                    tojbBlood.Rdatatime = rowTime.ToString();
                    tojbBlood.Typename = "����Ѫѹ";
                    tojbBlood.setdataxy(currentpage.Starttime);
                    currentpage.Objs.Add(tojbBlood);
                }

                string bp_blood2 = currentRow["bp_blood2"].ToString();
                if (bp_blood2 != "")
                {
                    ClsDataObj tojbBlood = new ClsDataObj();
                    tojbBlood.Val = bp_blood;
                    tojbBlood.Rdatatime = rowTime.ToString();
                    tojbBlood.Typename = "����Ѫѹ";
                    tojbBlood.setdataxy(currentpage.Starttime);
                    currentpage.Objs.Add(tojbBlood);
                }

                //1������
                ClsDataObj tojbShit = new ClsDataObj();
                tojbShit.Val = currentRow["shit"].ToString();
                tojbShit.Rdatatime = rowTime.ToString();
                tojbShit.Typename = "������";
                tojbShit.setdataxy(currentpage.Starttime);
                currentpage.Objs.Add(tojbShit);

                
                //2С�����
                ClsDataObj tojbUrinecount = new ClsDataObj();
                tojbUrinecount.Val = currentRow["urine_count"].ToString();
                tojbUrinecount.Rdatatime = rowTime.ToString();
                tojbUrinecount.Typename = "С�����";
                tojbUrinecount.setdataxy(currentpage.Starttime);
                currentpage.Objs.Add(tojbUrinecount);

                //3����
                ClsDataObj tojbUrine = new ClsDataObj();
                tojbUrine.Val = currentRow["urine"].ToString();
                tojbUrine.Rdatatime = rowTime.ToString();
                tojbUrine.Typename = "����";
                tojbUrine.setdataxy(currentpage.Starttime);
                currentpage.Objs.Add(tojbUrine);
                
                //4������
                ClsDataObj tojbVOLUME = new ClsDataObj();
                tojbVOLUME.Val = currentRow["VOLUME_OF_DRAINAGE"].ToString();
                tojbVOLUME.Rdatatime = rowTime.ToString();
                tojbVOLUME.Typename = "������";
                tojbVOLUME.setdataxy(currentpage.Starttime);
                currentpage.Objs.Add(tojbVOLUME);

                //5��ˮ��
                ClsDataObj tojbWateramount = new ClsDataObj();
                tojbWateramount.Val = currentRow["WATER_AMOUNT"].ToString();
                tojbWateramount.Rdatatime = rowTime.ToString();
                tojbWateramount.Typename = "��ˮ��";
                tojbWateramount.setdataxy(currentpage.Starttime);
                currentpage.Objs.Add(tojbWateramount);

                //6������
                ClsDataObj tojbInamount = new ClsDataObj();
                tojbInamount.Val = currentRow["in_amount"].ToString();
                tojbInamount.Rdatatime = rowTime.ToString();
                tojbInamount.Typename = "������";
                tojbInamount.setdataxy(currentpage.Starttime);
                currentpage.Objs.Add(tojbInamount);
                
                //7����               
                ClsDataObj tojbWeight = new ClsDataObj();
                tojbWeight.Val = currentRow["weight"].ToString();
                tojbWeight.Rdatatime = rowTime.ToString();
                tojbWeight.Typename = "����";
                tojbWeight.setdataxy(currentpage.Starttime);
                currentpage.Objs.Add(tojbWeight);
                
                //8���
                ClsDataObj tojbLength = new ClsDataObj();
                tojbLength.Val = currentRow["length"].ToString();
                tojbLength.Rdatatime = rowTime.ToString();
                tojbLength.Typename = "���";
                tojbLength.setdataxy(currentpage.Starttime);
                currentpage.Objs.Add(tojbLength);

                //9��ע
                ClsDataObj tojbRemark = new ClsDataObj();
                tojbRemark.Val = currentRow["remark"].ToString();
                tojbRemark.Rdatatime = rowTime.ToString();
                tojbRemark.Typename = "��ע";
                tojbRemark.setdataxy(currentpage.Starttime);
                currentpage.Objs.Add(tojbRemark);
            }
        }

        #region ��ӡ���� סԺ����

        /// <summary>
        /// ��ӡ���� סԺ���� ����������
        /// </summary>
        private void printTime()
        {
            DateTime dtStart = this.startTime;
            string dateString = "";
            DataTable dtSurgery = null;
            DateTime systime = App.GetSystemTime();
            //������¼�ͷ����¼����
            if (dtSurgery == null)
            {
                dtSurgery = dbList[2];
            }
            for (int i = 0; i < 7; i++)
            {
                DateTime oldTime = dtStart;     //�¸�ʱ��
                if ((out_time < (i == 0 ? dtStart : dtStart.AddDays(1)) && out_time.Year > 2000) || (i == 0 ? dtStart > systime : dtStart.AddDays(1) > systime))
                {
                    return;
                }
                if (i == 0)
                {
                    dateString = oldTime.ToString("yyyy-MM-dd");
                }
                else
                {
                    oldTime = dtStart.AddDays(1);
                    if (oldTime.Month != dtStart.Month)
                    {
                        if (oldTime.Year != dtStart.Year)
                        {
                            dateString = oldTime.ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            dateString = oldTime.ToString("MM-dd");
                        }
                    }
                    else
                    {
                        dateString = oldTime.ToString("dd");
                    }
                    dtStart = oldTime;
                }
                //���µ�����
                ClsDataObj tojbdt = new ClsDataObj();
                tojbdt.Val = dateString;
                tojbdt.Rdatatime = dtStart.ToString("yyyy-MM-dd");
                tojbdt.Typename = "����";
                tojbdt.setdataxy(currentpage.Starttime);
                currentpage.Objs.Add(tojbdt);
               

                /***
                 * ����������
                 */
                if (dtSurgery != null && dtSurgery.Rows.Count > 0)
                {
                    if (DateTime.Compare(dtStart, dtStart.AddDays(i)) < 1)
                    {
                        string surgeryDays = "";
                        for (int j = 0; j < dtSurgery.Rows.Count; j++)
                        {
                            DateTime dttimeRos = Convert.ToDateTime(Convert.ToDateTime(dtSurgery.Rows[j][0]).ToString("yyyy-MM-dd"));//���������¼���
                            TimeSpan abject = oldTime - dttimeRos; //
                            if (abject.Days >= 0 && abject.Days <= 14 && DateTime.Compare(dtStart, dttimeRos) >= 0)
                            {
                                string[] surgerys = dtSurgery.Rows[j]["DESCRIBE"].ToString().Split('|');
                                foreach (string surgeryStr in surgerys)
                                {
                                    string surgery = "";
                                    if (surgeryStr.Contains("����") || surgeryStr.Contains("����"))
                                    {
                                        surgery = surgeryStr.Contains("����") ? "����" : "����";
                                        if (abject.Days.ToString() == "0")
                                        {
                                            if (j > 0)
                                                surgeryDays = surgeryDays + "/" + surgery;//NumberConvertToNoman(j + 1);
                                            else
                                                surgeryDays = surgery;//I
                                        }
                                        else
                                        {
                                            if (surgeryDays != "")
                                                surgeryDays = surgeryDays + "/" + abject.Days.ToString();
                                            else
                                                surgeryDays = abject.Days.ToString();
                                        }
                                    }
                                }
                            }
                        }

                        if (surgeryDays.Length > 0)
                        {
                            //���µ�����
                            ClsDataObj tojbOper = new ClsDataObj();
                            tojbOper.Val = surgeryDays;
                            tojbOper.Rdatatime = dtStart.ToString("yyyy-MM-dd");
                            tojbOper.Typename = "��������";
                            tojbOper.setdataxy(currentpage.Starttime);
                            currentpage.Objs.Add(tojbOper);                      
                        }
                    }
                }

                //סԺ����
                TimeSpan tsp = new TimeSpan();
                if (dtStart != null && user["��Ժ����:"] != "")
                {
                    tsp = Convert.ToDateTime(dtStart) - Convert.ToDateTime(Convert.ToDateTime(user["��Ժ����:"]).ToString("yyyy-MM-dd"));
                    int Days = tsp.Days + 1;

                    //���µ�����
                    ClsDataObj tojbDay = new ClsDataObj();
                    tojbDay.Val = Days.ToString();
                    tojbDay.Rdatatime = dtStart.ToString("yyyy-MM-dd");
                    tojbDay.Typename = "סԺ����";
                    tojbDay.setdataxy(currentpage.Starttime);
                    currentpage.Objs.Add(tojbDay);
                }
            }
        }


        /// <summary>
        /// ��������ת��Ϊ��������
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private string NumberConvertToNoman(int num)
        {
            string return_s = "";
            if (num <= 1)
                return_s = "";
            else if (num > 10)
                return_s = "��";
            else if (num >= 2 && num <= 10)
            {
                switch (num)
                {
                    case 2:
                        return_s = "��";
                        break;
                    case 3:
                        return_s = "��";
                        break;
                    case 4:
                        return_s = "��";
                        break;
                    case 5:
                        return_s = "��";
                        break;
                    case 6:
                        return_s = "��";
                        break;
                    case 7:
                        return_s = "��";
                        break;
                    case 8:
                        return_s = "��";
                        break;
                    case 9:
                        return_s = "��";
                        break;
                    case 10:
                        return_s = "��";
                        break;
                }
            }
            else
                return_s = "";
            return return_s;
        }

        #endregion

        #region ������ʱ��ת����ʱ��
        /// <summary>
        /// ������������ת��Ϊ���ļ���
        /// </summary>
        /// <param name="time">HH:mm</param>
        /// <returns></returns>
        public string ConvertText(string time)
        {
            string[] stringArr = time.Split(':');
            if (stringArr.Length > 1)
            {
                int temperHour = Convert.ToInt32(stringArr[0]);
                int temperMinute = Convert.ToInt32(stringArr[1]);
                if (temperMinute == 00)
                {
                    return NumForChinese(temperHour, 0) + "ʱ";
                }
                else
                {
                    return NumForChinese(temperHour, 0) + "ʱ" + NumForChinese(temperMinute, 1) + "��";
                }
            }
            return "";
        }

        public string NumForChinese(int number, int type)
        {
            string returnTime = "";
            if (number < 10)
            {
                if (type == 1)
                {
                    returnTime = "��";
                }
                if (number == 0)
                {
                    returnTime = "��";
                }
                else
                {
                    switch (number)
                    {
                        case 1:
                            returnTime += "һ";
                            break;
                        case 2:
                            returnTime += "��";
                            break;
                        case 3:
                            returnTime += "��";
                            break;
                        case 4:
                            returnTime += "��";
                            break;
                        case 5:
                            returnTime += "��";
                            break;
                        case 6:
                            returnTime += "��";
                            break;
                        case 7:
                            returnTime += "��";
                            break;
                        case 8:
                            returnTime += "��";
                            break;
                        case 9:
                            returnTime += "��";
                            break;
                    }
                }
            }
            else
            {
                switch (Convert.ToInt32(number.ToString().Substring(0, 1)))
                {
                    case 1:
                        returnTime = "ʮ";
                        break;
                    case 2:
                        returnTime = "��ʮ";
                        break;
                    case 3:
                        returnTime = "��ʮ";
                        break;
                    case 4:
                        returnTime = "��ʮ";
                        break;
                    case 5:
                        returnTime = "��ʮ";
                        break;
                }
                switch (Convert.ToInt32(number.ToString().Substring(1, 1)))
                {
                    case 1:
                        returnTime += "һ";
                        break;
                    case 2:
                        returnTime += "��";
                        break;
                    case 3:
                        returnTime += "��";
                        break;
                    case 4:
                        returnTime += "��";
                        break;
                    case 5:
                        returnTime += "��";
                        break;
                    case 6:
                        returnTime += "��";
                        break;
                    case 7:
                        returnTime += "��";
                        break;
                    case 8:
                        returnTime += "��";
                        break;
                    case 9:
                        returnTime += "��";
                        break;
                }
            }
            return returnTime;
        }
        #endregion

        #region �������ݲ�ѯ

        /// <summary>
        /// ����������7������
        /// </summary>
        /// <returns></returns>
        public List<DataTable> getChildTemperureCount(string startTime, string endTime, string pid)
        {
            List<DataTable> childList = new List<DataTable>();
            try
            {
                string sql = string.Format(" select child_id,cooling_value,measure_time,temperature_value,re_measure,describe,temp_state "
                                           + " from t_child_vital_signs "
                                           + " where to_char(measure_time,'yyyy-mm-dd') "
                                           + " between '{0}' "
                                           + " and '{1}' "
                                           + " and child_id = '{2}' "
                                           + " order by measure_time ", startTime, endTime, pid);
                string sql2 = string.Format(" select child_id, feed_style, icterus, stool_count, stool_color, umbilicalcord,COLOUR_FACE,BREATHE,CRY,REACTION,DIAPER,weight,NUTRUE_OTHERNAME,record_time "
                                          + " from t_child_temperature_info"
                                          + " where to_char(record_time,'yyyy-MM-dd')"
                                          + " between '{0}'"
                                          + " and '{1}'"
                                          + " and child_id = '{2}'"
                                          + " order by record_time", startTime, endTime, pid);
                string sql3 = string.Format("select NEWBORN_WEIGHT from T_NEW_BORN_PATIENT where id = '{0}'", pid);
                childList.Add(App.GetDataSet(sql).Tables[0]);
                childList.Add(App.GetDataSet(sql2).Tables[0]);
                childList.Add(App.GetDataSet(sql3).Tables[0]);
            }
            catch (Exception)
            {

                throw;
            }
            return childList;
        }

        /// <summary>
        /// ��ͨ���µ�7�������
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public List<DataTable> GetTempertureCount(string inTime, string startTime, string endTime, string pid)
        {
            List<DataTable> list = new List<DataTable>();
            string sql = string.Format("select measure_time, " +
                                        "temperature_value, temperature_body, " +
                                        "re_measure, cooling_value, cooling_type," +
                                        "pulse_value, is_briefness, is_assist_hr, " +
                                        "breath_value, is_assist_br, measure_state, " +
                                        "describe, remark, heart_rhythm,PAIN_VALUE,PAIN_MOTHED,pain_value2,is_qixian from t_vital_signs " +
                                        "WHERE to_char(MEASURE_TIME,'yyyy-MM-dd') " +
                                        "BETWEEN '{0}' AND '{1}' AND PATIENT_ID = '{2}' ORDER BY MEASURE_TIME ASC", startTime, endTime, pid);

            string sql2 = string.Format("select stool_count, stool_state, clysis_count, stool_count_e,stool_count_f, " +
                                        "stool_amount, stool_amount_unit, stale_amount, is_catheter, weighttype, " +
                                        "weight, weight_unit, weight_special, length, sensi_test_code, sensi_test_result, " +
                                        "sensi_test_result_temp, record_id, record_time, in_amount, out_amount, out_amount1, " +
                                        "out_amount2, out_amount3, remark, bp_high, bp_low, bp_unit,out_other, bp_blood,bp_blood2,SPECIAL,SPUTUM_QUANTITY,VOLUME_OF_DRAINAGE,VOMIT,URINE,URINE_STATE,SHIT_STATE,empty_name1,empty_value1,empty_name2,empty_value2,shit,empty_name3,empty_value3,empty_name4,empty_value4,empty_name5,empty_value5,sensi,urine_count,water_amount from t_temperature_info " +
                                        "WHERE to_char(record_time,'yyyy-MM-dd') BETWEEN '{0}' AND '{1}' AND PATIENT_ID = '{2}' ORDER BY record_time", startTime, endTime, pid);

            string sql3 = string.Format("select measure_time,DESCRIBE from t_vital_signs " +
                                        "where (describe like '%����%' or describe like '%����%') " +
                                        "and PATIENT_ID ='{0}' " +
                                        "and to_char(MEASURE_TIME,'yyyy-MM-dd') BETWEEN '{1}' AND '{2}' " +
                                        "ORDER BY MEASURE_TIME ASC", pid, DateTime.Parse(inTime).ToString("yyyy-MM-dd"), endTime);
            try
            {
                list.Add(App.GetDataSet(sql).Tables[0]);
                list.Add(App.GetDataSet(sql2).Tables[0]);
                list.Add(App.GetDataSet(sql3).Tables[0]);
            }
            catch
            {
                return null;
            }
            return list;
        }

        #endregion

    }
}
