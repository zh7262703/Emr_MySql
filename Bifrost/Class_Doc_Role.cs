using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data;

namespace Bifrost
{
    /// <summary>
    /// �ͻ����ʿع���У��
    /// �����ߣ�¬����
    /// ����ʱ�䣺2011-11-28
    /// </summary>
    public class Class_Doc_Rule
    {

        /// <summary>
        /// ��Ժ��¼
        /// </summary>
        /// <param name="in_time">��Ժʱ��</param>
        /// <param name="record_time">��¼ʱ��</param>
        /// <param name="inital_time">�������ʱ��</param>
        /// <param name="confirm_time">ȷ�����ʱ��</param>
        /// <param name="reference_time">�ο�ʱ��</param>
        /// <param name="turntime">�ʿ�ʱ�䣺����λ</param>
        /// <param name="unit">�ʿ����ڣ���λ</param>
        /// <param name="isOkDiagnose">�Ƿ���ȷ�����ʱ��</param>
        /// <param name="referDiagnoseTime">ȷ�����ʱ�䣨�ַ�����ʽ��</param>
        /// <returns></returns>
        public static string In_Area_Rule(DateTime in_time, DateTime record_time, DateTime inital_time, DateTime confirm_time, DateTime reference_time, int turntime, string unit, ref bool isOkDiagnose, ref string referDiagnoseTime)
        {           
            DateTime temptime = new DateTime();
            if (unit == "Сʱ")
            {
                temptime = in_time.AddHours(turntime);
            }
            else if (unit == "��")
            {
                temptime = in_time.AddDays(turntime);
            }

            if (in_time < record_time)
            {
                if (record_time < inital_time || record_time == inital_time)
                {
                    if (confirm_time != reference_time)
                    //�ж��Ƿ���ȷ�����ʱ��
                    {
                        isOkDiagnose = true;
                        referDiagnoseTime = confirm_time.ToString();
                        if (inital_time < confirm_time || inital_time == confirm_time)
                        {
                            if (inital_time < temptime || inital_time == temptime)
                            {
                                if (confirm_time < in_time.AddDays(7) || confirm_time == in_time.AddDays(7))
                                {
                                    return "";
                                }
                                else
                                {
                                    return "ȷ�����ʱ�䳬����Ժʱ��+7�죬�Ƿ�ȷ���ύ����ȷ���ύ�����ʿز��������ݱ���";
                                }

                            }
                            else
                            {
                                return "�������ʱ��/����Ӧ��С�ڵ�����Ժʱ��+24Сʱ";
                            }
                        }
                        else
                        {
                            return "�������ʱ��/����Ӧ��С�ڵ���ȷ�����ʱ��/����";
                        }
                    }
                    else
                    {
                        //û��ȷ�����ʱ��
                        if (inital_time < temptime || inital_time == temptime)
                        {
                            return "";
                        }
                        else
                        {
                            return "�������ʱ��/����Ӧ��С�ڵ�����Ժʱ��+24Сʱ";
                        }

                    }
                }
                else
                {
                    return "��¼ʱ��/����Ӧ��С�ڵ��ڳ������ʱ��/����";
                }

            }
            else
            {
                return "��Ժʱ��Ӧ��С�ڼ�¼ʱ��/����";
            }
        }

        /// <summary>
        /// 24Сʱ�����Ժ��¼
        /// </summary>
        /// <param name="turntime">�ʿ�ʱ�䣺����λ</param>
        /// <param name="unit">�ʿ����ڣ���λ</param>
        /// <param name="in_time">��Ժʱ��</param>
        /// <param name="sign_time">ǩ��ʱ��</param>
        /// <param name="xmldocument">��ǰ����</param>
        /// <returns></returns>
        public static string In_Out_Area_Rule(int turntime, string unit, DateTime in_time, DateTime sign_time, System.Xml.XmlDocument xmldocument)
        {
            DateTime out_time1 = new DateTime();
            string strout_time = "";
            XmlNodeList footnodeListInput = xmldocument.GetElementsByTagName("input");
            for (int ii = 0; ii < footnodeListInput.Count; ii++)
            {
                if (footnodeListInput[ii].Attributes["name"].Value == "��Ժʱ��" || 
                    footnodeListInput[ii].Attributes["name"].Value == "��Ժ����")
                {

                    for (int chnu = 0; chnu < footnodeListInput[ii].ChildNodes.Count; chnu++)
                    {

                        if (footnodeListInput[ii].ChildNodes[chnu].OuterXml.ToString().Contains("deleter"))
                        {
                            continue;
                        }
                        else
                        {
                            strout_time += footnodeListInput[ii].ChildNodes[chnu].InnerText;
                        }

                    }
                }
            }
            strout_time = strout_time.Replace("��", " ");
            strout_time = strout_time.Replace(",", " ");
            strout_time = strout_time.Replace("��", ":");
            if (strout_time != "")
                try
                {
                    out_time1 = Convert.ToDateTime(strout_time);
                }
                catch
                {
                    return "��Ժʱ���ʽ����ȷ�������������ύ��";

                }
            else
                out_time1 = Convert.ToDateTime("1900-01-01 01:01");
            DateTime temptime = new DateTime();
            if (unit == "Сʱ")
            {
                temptime = out_time1.AddHours(turntime);
            }
            else if (unit == "��")
            {
                temptime = out_time1.AddDays(turntime);
            }
            if (in_time < sign_time)
            {
                if (in_time < out_time1)
                {
                    if (out_time1 < in_time.AddHours(24) || out_time1 == in_time.AddHours(24))
                    {
                        if (sign_time < temptime)
                        {
                            return "";
                        }
                        else
                        {
                            return "����ǩ��ʱ��Ӧ��С�ڳ�Ժʱ��/����+24Сʱ";
                        }

                    }
                    else
                    {
                        return "��Ժʱ��/����Ӧ��С�ڵ�����Ժʱ��+24Сʱ";
                    }

                }
                else
                {
                    return "��Ժʱ��Ӧ��С�ڳ�Ժʱ��/����";
                }
            }
            else
            {
                return "����ǩ��ʱ��Ӧ�ô�����Ժʱ��";
            }
        }

        /// <summary>
        /// 24Сʱ����Ժ������¼
        /// </summary>
        /// <param name="turntime">�ʿ�ʱ�䣺����λ</param>
        /// <param name="unit">�ʿ����ڣ���λ</param>
        /// <param name="in_time">��Ժʱ��</param>
        /// <param name="sign_time">ǩ��ʱ��</param>
        /// <param name="xmldocument">��ǰ����</param>
        /// <returns></returns>
        public static string In_Die_Area_Rule(int turntime, string unit, DateTime in_time, DateTime sign_time, System.Xml.XmlDocument xmldocument)
        {
            DateTime out_time1 = new DateTime();
            string strout_time = "";
            XmlNodeList footnodeListInput = xmldocument.GetElementsByTagName("input");
            for (int ii = 0; ii < footnodeListInput.Count; ii++)
            {
                if (footnodeListInput[ii].Attributes["name"].Value == "����ʱ��")
                {

                    for (int chnu = 0; chnu < footnodeListInput[ii].ChildNodes.Count; chnu++)
                    {

                        if (footnodeListInput[ii].ChildNodes[chnu].OuterXml.ToString().Contains("deleter"))
                        {
                            continue;
                        }
                        else
                        {
                            strout_time += footnodeListInput[ii].ChildNodes[chnu].InnerText;
                        }

                    }
                }
            }
            strout_time = strout_time.Replace("��", " ");
            strout_time = strout_time.Replace(",", " ");
            strout_time = strout_time.Replace("��", ":");
            if (strout_time != "")
                try
                {
                    out_time1 = Convert.ToDateTime(strout_time);
                }
                catch
                {
                    return "����ʱ���ʽ����ȷ�������������ύ��";
                }
            else
                out_time1 = Convert.ToDateTime("1900-01-01 01:01");
            DateTime temptime = new DateTime();
            if (unit == "Сʱ")
            {
                temptime = out_time1.AddHours(turntime);
            }
            else if (unit == "��")
            {
                temptime = out_time1.AddDays(turntime);
            }
            if (in_time < sign_time)
            {
                if (in_time < out_time1)
                {
                    if (out_time1 < in_time.AddHours(24) || out_time1 == in_time.AddHours(24))
                    {
                        if (sign_time < temptime)
                        {
                            return "";
                        }
                        else
                        {
                            return "����ǩ��ʱ��Ӧ��С������ʱ��/����+24Сʱ";
                        }

                    }
                    else
                    {
                        return "����ʱ��/����Ӧ��С�ڵ�����Ժʱ��+24Сʱ";
                    }
                }
                else
                {
                    return "��Ժʱ��Ӧ��С������ʱ��/����";
                }
            }
            else
            {
                return "����ǩ��ʱ��Ӧ�ô�����Ժʱ��";
            }
        }

        /// <summary>
        /// һ�㲡�̼�¼
        /// </summary>
        /// <param name="patient_Id">����ID</param>
        /// <param name="in_time">��Ժʱ��</param>
        /// <param name="turntime">�ʿ�ʱ�䣺����λ</param>
        /// <param name="unit">�ʿ����ڣ���λ</param>
        /// <param name="tittle_time">����ʱ��</param>
        /// <param name="doc_tittle">�������</param>
        /// <param name="replaceHigher">�������λ������Σ��ϼ�ҽ��</param>
        /// <returns></returns>
        public static string Day_Medical_Record_Rule(string patient_Id, DateTime in_time, int turntime, string unit, DateTime tittle_time, string doc_tittle, int replaceHigher)
        {
            DateTime referTime = new DateTime();
            int bingchengNumber = 0;
            string strResult = "";
            DateTime temptime = new DateTime();
            tittle_time = Convert.ToDateTime(App.GetTimeString(doc_tittle));
            string Sqlbingcheng = "select * from t_patients_doc  t  where t.textname like '%���̼�¼%' and t.patient_id='" + patient_Id + "' and textkind_id=126 order by doc_name desc";
            DataSet bingcheng = App.GetDataSet(Sqlbingcheng);
            if (bingcheng != null && bingcheng.Tables.Count > 0)
            {
                bingchengNumber = bingcheng.Tables[0].Rows.Count;
                if (bingchengNumber > 0)
                {
                    referTime = Convert.ToDateTime(App.GetTimeString(bingcheng.Tables[0].Rows[0]["doc_name"].ToString()));
                }
            }
            #region
            if (tittle_time < in_time || tittle_time == in_time)
                return "�������ʱ��Ӧ�ô�����Ժʱ��";

            if (bingchengNumber == 0)
            {
                if (tittle_time > in_time.AddHours(24))
                {
                    strResult = "�ճ����̼�¼��Ժʱ��+72Сʱ��ÿ24Сʱ������Ҫдһ�ݣ�";
                }
            }
            else
            {
                //��һ�������ʱ������Ժ24Сʱ��
                if (referTime > in_time && referTime < in_time.AddHours(24))
                {
                    if (tittle_time > in_time.AddHours(48))
                    {
                        strResult = "�ճ����̼�¼��Ժʱ��+72Сʱ��ÿ24Сʱ������Ҫдһ�ݣ�";
                    }
                }
                //��һ�������ʱ������Ժ48Сʱ��
                else if ((referTime > in_time.AddHours(24) || referTime == in_time.AddHours(24)) && referTime < in_time.AddHours(48))
                {
                    if (tittle_time > in_time.AddHours(72))
                    {
                        strResult = "�ճ����̼�¼��Ժʱ��+72Сʱ��ÿ24Сʱ������Ҫдһ�ݣ�";
                    }
                }
                //��һ�������ʱ������Ժ72Сʱ��
                else if ((referTime > in_time.AddHours(48) || referTime == in_time.AddHours(48)) && referTime < in_time.AddHours(72))
                {
                    if (tittle_time > referTime.AddHours(72))
                    {
                        strResult = "�ճ����̼�¼Ӧÿ3������1�Σ�";
                    }
                }
                //��һ�������ʱ������Ժ72Сʱ����
                else
                {
                    if (tittle_time > referTime.AddHours(72))
                    {
                        strResult = "�ճ����̼�¼Ӧÿ3������1�Σ�";
                    }
                }
            }
            #endregion
            if (strResult != "")
                return strResult;
            else
            {
                //������
                if (replaceHigher == 1)
                {
                    #region
                    string SqlChairman = "select * from t_patients_doc  t  where  t.patient_id='" + patient_Id + "' and textkind_id=126 and t.israplacehightdoctor='Y' " +
                        "or t.patient_id='" + patient_Id + "' and textkind_id=126 and t.israplacehightdoctor2='Y'" +
                        "or t.patient_id='" + patient_Id + "' and textkind_id=127 order by doc_name desc";
                    DataSet dsChairman = App.GetDataSet(SqlChairman);
                    if (dsChairman != null && dsChairman.Tables.Count > 0)
                    {
                        //û���״����β鷿
                        #region
                        if (dsChairman.Tables[0].Rows.Count == 0)
                        {
                            temptime = in_time.AddHours(48);
                            if (in_time < tittle_time)
                            {
                                if (tittle_time < temptime || tittle_time == temptime)
                                {
                                    return "";
                                }
                                else
                                {
                                    return "[�״����β鷿]����ʱ��Ӧ��С�ڵ�����Ժʱ��+48Сʱ";
                                }
                            }
                            else
                            {
                                return "��Ժʱ��Ӧ��С��[�״����β鷿]����ʱ��";
                            }
                        }
                        #endregion
                        //���״����β鷿��¼
                        else
                        {
                            //����
                            string sqlIsHaveFirstChain = "select * from t_patients_doc  t where  t.patient_id='" + patient_Id + "' and textkind_id=126 and t.israplacehightdoctor='Y' " +
                                                         "or t.patient_id='" + patient_Id + "' and textkind_id=127 and doc_name like '%����%' order by doc_name desc";
                            //����
                            string sqlIsHaveFirstChain2 = "select * from t_patients_doc  t  where  " +
                                                            " t.patient_id='" + patient_Id + "' and textkind_id=126 and t.israplacehightdoctor2='Y'" +
                                                            "or t.patient_id='" + patient_Id + "' and textkind_id=127 and doc_name like '%����%'order by doc_name desc";
                            //û���״β鷿��¼��ֻ���״����β鷿��¼�����ʱ��ͽ��״����ε����״�����
                            if (App.GetDataSet(sqlIsHaveFirstChain).Tables[0].Rows.Count == 0 )
                            {
                                //������
                                if (App.GetDataSet(sqlIsHaveFirstChain2).Tables[0].Rows.Count == 0)
                                {
                                    temptime = in_time.AddHours(48);
                                    if (in_time < tittle_time)
                                    {
                                        if (tittle_time < temptime || tittle_time == temptime)
                                        {
                                            return "";
                                        }
                                        else
                                        {
                                            return "[�״����β鷿]����ʱ��Ӧ��С�ڵ�����Ժʱ��+48Сʱ";
                                        }
                                    }
                                    else
                                    {
                                        return "��Ժʱ��Ӧ��С��[�״����β鷿]����ʱ��";
                                    }
                                }
                                //������
                                else if (App.GetDataSet(sqlIsHaveFirstChain2).Tables[0].Rows.Count == 1)
                                {
                                    temptime = in_time.AddHours(72);
                                    if (in_time < tittle_time)
                                    {
                                        if (tittle_time < temptime || tittle_time == temptime)
                                        {
                                            return "";
                                        }
                                        else
                                        {
                                            return "[�״����β鷿]����ʱ��Ӧ��С�ڵ�����Ժʱ��+72Сʱ��û���״β鷿��¼��ֻ���״����β鷿��¼�����ʱ��ͽ��״����ε����״����Σ�";
                                        }
                                    }
                                    else
                                    {
                                        return "��Ժʱ��Ӧ��С��[�״����β鷿]����ʱ�䣨û���״β鷿��¼��ֻ���״����β鷿��¼�����ʱ��ͽ��״����ε����״����Σ�";
                                    }
                                }
                                else
                                {
                                    DateTime refTime = Convert.ToDateTime(App.GetTimeString(App.GetDataSet(sqlIsHaveFirstChain2).Tables[0].Rows[0]["doc_name"].ToString()));
                                    if (tittle_time > refTime.AddDays(7))
                                    {
                                        return "ÿ���ڣ�7�գ���������һ�����β鷿¼";
                                    }
                                    else
                                    {
                                        return "";
                                    }
                                }
                            }
                            //д���״����β鷿
                            else
                            {
                                if (App.GetDataSet(sqlIsHaveFirstChain2).Tables[0].Rows.Count == 0)
                                {
                                    temptime = in_time.AddHours(72);
                                    if (in_time < tittle_time)
                                    {
                                        if (tittle_time < temptime || tittle_time == temptime)
                                        {
                                            return "";
                                        }
                                        else
                                        {
                                            return "[�״����β鷿]����ʱ��Ӧ��С�ڵ�����Ժʱ��+72Сʱ";
                                        }
                                    }
                                    else
                                    {
                                        return "��Ժʱ��Ӧ��С��[�״����β鷿]����ʱ��";
                                    }
                                }
                                else
                                {
                                    DateTime refTime = Convert.ToDateTime(App.GetTimeString(App.GetDataSet(sqlIsHaveFirstChain2).Tables[0].Rows[0]["doc_name"].ToString()));
                                    if (tittle_time > refTime.AddDays(7))
                                    {
                                        return "ÿ���ڣ�7�գ���������һ�����β鷿¼";
                                    }
                                    else
                                    {
                                        return "";
                                    }
                                }
                            }

                        }
                    }
                    #endregion
                }
                //������
                if (replaceHigher == 2)
                {
                    #region
                    temptime = in_time.AddHours(48);//t.pid='00507075' and textkind_id=126 and t.israplacehightdoctor='Y' 
                    string SqlAttending = "select * from t_patients_doc  t  where  t.patient_id='" + patient_Id + "' and textkind_id=126 and t.israplacehightdoctor='Y' " +
                        "or t.patient_id='" + patient_Id + "' and textkind_id=126 and t.israplacehightdoctor2='Y'" +
                        "or t.patient_id='" + patient_Id + "' and textkind_id=127 order by doc_name desc";
                    DataSet dsAttending = App.GetDataSet(SqlAttending);
                    if (dsAttending != null && dsAttending.Tables.Count > 0)
                    {
                        //û���״����β鷿
                        if (dsAttending.Tables[0].Rows.Count == 0)
                        {
                            if (in_time < tittle_time)
                            {
                                if (tittle_time < temptime || tittle_time == temptime)
                                {
                                    return "";
                                }
                                else
                                {
                                    return "[�״����β鷿]����ʱ��Ӧ��С����Ժʱ��+48Сʱ";
                                }
                            }
                            else
                            {
                                return "��Ժʱ��Ӧ��С��[�״����β鷿]����ʱ��";
                            }
                        }
                        //���״����β鷿��¼
                        else
                        {
                            DateTime beforeTime = Convert.ToDateTime(App.GetTimeString(dsAttending.Tables[0].Rows[0]["doc_name"].ToString()));
                            if (tittle_time > beforeTime.AddDays(3))
                            {
                                return "�ճ����β鷿ʱ��Ӧÿ3������һ�Σ����β鷿�ɴ����β鷿����";
                            }
                            else
                            {
                                return "";
                            }
                        }
                    }
                    #endregion
                }
            }
            return strResult;
        }

        /// <summary>
        /// �״β��̼�¼
        /// </summary>
        /// <param name="turntime">�ʿ�ʱ�䣺����λ</param>
        /// <param name="unit">�ʿ����ڣ���λ</param>
        /// <param name="tittle_time">����ʱ��</param>
        /// <param name="doc_tittle">�������</param>
        /// <param name="in_time">��Ժʱ��</param>
        /// <returns></returns>
        public static string First_Medical_Record_Rule(int turntime, string unit, DateTime tittle_time, string doc_tittle,DateTime in_time)
        {
            DateTime temptime = new DateTime();
            if (unit == "Сʱ")
            {
                temptime = in_time.AddHours(turntime);
            }
            else if (unit == "��")
            {
                temptime = in_time.AddDays(turntime);
            }
            if (doc_tittle.Length != 0)
            {
                tittle_time = Convert.ToDateTime(App.GetTimeString(doc_tittle));
            }


            if (in_time < tittle_time)
            {
                if (tittle_time < temptime || tittle_time == temptime)
                {
                    return "";
                }
                else
                {
                    return "����ʱ��Ӧ��С�ڵ�����Ժʱ��+8Сʱ";
                }
            }
            else
            {
                return "��Ժʱ��Ӧ��С�ڱ���ʱ��";
            }
        }

        /// <summary>
        /// �ϼ�ҽ���鷿��¼
        /// </summary>
        /// <param name="doc_tittle">�������</param>
        /// <param name="patient_Id">����ID</param>
        /// <param name="in_time">��Ժʱ��</param>
        /// <param name="tittle_time">����ʱ��</param>
        /// <returns></returns>
        public static string Higher_Docter_Check_Rule(string doc_tittle,string patient_Id,DateTime in_time,DateTime tittle_time)
        {
            DateTime temptime = new DateTime();
            tittle_time = Convert.ToDateTime(App.GetTimeString(doc_tittle));
            if (doc_tittle.Contains("����"))
            {
                #region
                temptime = in_time.AddHours(48);//t.pid='00507075' and textkind_id=126 and t.israplacehightdoctor='Y' 
                string SqlAttending = "select * from t_patients_doc  t  where  t.patient_id='" + patient_Id + "' and textkind_id=126 and t.israplacehightdoctor='Y' " +
                    "or t.patient_id='" + patient_Id + "' and textkind_id=126 and t.israplacehightdoctor2='Y'" +
                    "or t.patient_id='" + patient_Id + "' and textkind_id=127 order by doc_name desc";
                DataSet dsAttending = App.GetDataSet(SqlAttending);
                if (dsAttending != null && dsAttending.Tables.Count > 0)
                {
                    //û���״����β鷿
                    if (dsAttending.Tables[0].Rows.Count == 0)
                    {
                        if (in_time < tittle_time)
                        {
                            if (tittle_time < temptime || tittle_time == temptime)
                            {
                                return "";
                            }
                            else
                            {
                                return "[�״����β鷿]����ʱ��Ӧ��С����Ժʱ��+48Сʱ";
                            }
                        }
                        else
                        {
                            return "��Ժʱ��Ӧ��С��[�״����β鷿]����ʱ��";
                        }
                    }
                    //���״����β鷿��¼
                    else
                    {
                        DateTime beforeTime = Convert.ToDateTime(App.GetTimeString(dsAttending.Tables[0].Rows[0]["doc_name"].ToString()));
                        if (tittle_time > beforeTime.AddDays(3))
                        {
                            return "�ճ����β鷿ʱ��Ӧÿ3������һ�Σ����β鷿�ɴ����β鷿����";
                        }
                        else
                        {
                            return "";
                        }
                    }
                }
                #endregion
            }
            else if (doc_tittle.Contains("����"))
            {
                #region
                DateTime LastTime=new DateTime();
                string SqlChairman = "select * from t_patients_doc  t  where  t.patient_id='" + patient_Id + "' and textkind_id=126 and t.israplacehightdoctor='Y' " +
                    "or t.patient_id='" + patient_Id + "' and textkind_id=126 and t.israplacehightdoctor2='Y'" +
                    "or t.patient_id='" + patient_Id + "' and textkind_id=127 order by doc_name desc";
                DataSet dsChairman = App.GetDataSet(SqlChairman);
                if (dsChairman != null && dsChairman.Tables.Count > 0)
                {
                    //û���״����β鷿
                    #region
                    if (dsChairman.Tables[0].Rows.Count == 0)
                    {
                        temptime = in_time.AddHours(48);
                        if (in_time < tittle_time)
                        {
                            if (tittle_time < temptime || tittle_time == temptime)
                            {
                                return "";
                            }
                            else
                            {
                                return "[�״����β鷿]����ʱ��Ӧ��С�ڵ�����Ժʱ��+48Сʱ";
                            }
                        }
                        else
                        {
                            return "��Ժʱ��Ӧ��С��[�״����β鷿]����ʱ��";
                        }
                    }
                    #endregion
                    //���״����β鷿��¼
                    else
                    {
                        string sqlIsHaveFirstChain = "select * from t_patients_doc  t where  t.patient_id='" + patient_Id + "' and textkind_id=126 and t.israplacehightdoctor='Y' " +
                                                     "or t.patient_id='" + patient_Id + "' and textkind_id=127 and doc_name like '%����%' order by doc_name desc";
                        string sqlIsHaveFirstChain2 = "select * from t_patients_doc  t  where  " +
                                                        " t.patient_id='" + patient_Id + "' and textkind_id=126 and t.israplacehightdoctor2='Y'" +
                                                        "or t.patient_id='" + patient_Id + "' and textkind_id=127 and doc_name like '%����%'order by doc_name desc";
                        //û���״β鷿��¼��ֻ���״����β鷿��¼�����ʱ��ͽ��״����ε����״�����
                        if (App.GetDataSet(sqlIsHaveFirstChain).Tables[0].Rows.Count == 0 )
                        {
                            if (App.GetDataSet(sqlIsHaveFirstChain2).Tables[0].Rows.Count == 0)
                            {
                                if (tittle_time > in_time.AddDays(2))
                                {
                                    return "�״����β鷿ʱ��Ӧ����Ժʱ��+48Сʱ�ڣ�";
                                }
                                else
                                {
                                    return "";
                                }
                            }
                            else if (App.GetDataSet(sqlIsHaveFirstChain2).Tables[0].Rows.Count == 1)
                            {
                                if (tittle_time > in_time.AddDays(3))
                                {
                                    return "�״����β鷿ʱ��Ӧ����Ժʱ��+72Сʱ�ڣ�";
                                }
                                else
                                {
                                    return "";
                                }
                            }
                            else
                            {
                                LastTime = Convert.ToDateTime(App.GetTimeString(App.GetDataSet(sqlIsHaveFirstChain2).Tables[0].Rows[0]["doc_name"].ToString()));
                                if (tittle_time > in_time.AddDays(7))
                                {
                                    return "�����ճ��鷿��¼ÿ7��һ�Σ�";
                                }
                                else
                                {
                                    return "";
                                }
                            }
                        }
                        //д���״����β鷿
                        else 
                        {
                            if (App.GetDataSet(sqlIsHaveFirstChain2).Tables[0].Rows.Count == 0)
                            {
                                if (tittle_time > in_time.AddDays(3))
                                {
                                    return "�״����β鷿ʱ��Ӧ����Ժʱ��+72Сʱ�ڣ�";
                                }
                                else
                                {
                                    return "";
                                }
                            }
                            else
                            {
                                LastTime = Convert.ToDateTime(App.GetTimeString(App.GetDataSet(sqlIsHaveFirstChain2).Tables[0].Rows[0]["doc_name"].ToString()));
                                if (tittle_time > LastTime.AddDays(7))
                                {
                                    return "�����ճ��鷿��¼ÿ7��һ�Σ�";
                                }
                                else
                                {
                                    return "";
                                }
                            }
                           
                        }

                    }
                }
                #endregion
            }
            return "";
        }

        /// <summary>
        /// ת����¼
        /// </summary>
        /// <param name="tittle_time">����ʱ��</param>
        /// <param name="doc_tittle">�������</param>
        /// <param name="patient_Id">����ID</param>
        /// <param name="reference_time">�ο�ʱ��</param>
        /// <param name="out_time">ת��ʱ��</param>
        /// <param name="in_time">��Ժʱ��</param>
        /// <returns></returns>
        public static string Turn_Out_Rule(DateTime tittle_time, string doc_tittle, string patient_Id, DateTime reference_time, DateTime out_time, DateTime in_time)
        {
            tittle_time = Convert.ToDateTime(App.GetTimeString(doc_tittle));
            //out_time = tittle_time;
            out_time = reference_time;
            string SqlInfoouttime = "select b.happen_time,b.action_type from t_in_patient a inner join t_inhospital_action b on a.id=b.patient_id where a.id=" + patient_Id + " and b.next_id=0 and b.action_type='ת��' order by happen_time desc";
            DataSet PatientInfodsouttime = App.GetDataSet(SqlInfoouttime);
            if (PatientInfodsouttime != null && PatientInfodsouttime.Tables.Count > 0)
            {
                if (PatientInfodsouttime.Tables[0].Rows.Count > 0)
                {
                    if (PatientInfodsouttime.Tables[0].Rows[0]["action_type"].ToString() == "ת��")
                    {
                        out_time = Convert.ToDateTime(PatientInfodsouttime.Tables[0].Rows[0]["happen_time"].ToString());
                    }
                }
            }
            if (out_time == reference_time)
            {
                //û��ת����¼��ʱ��
                if (in_time < tittle_time)
                {
                    return "";
                }
                else
                {
                    return "��Ժʱ��Ӧ��С�ڱ���ʱ��";
                }
            }
            if (in_time < tittle_time)
            {
                //��ת����¼��ʱ��
                if (tittle_time < out_time)
                {
                    return "";
                }
                else
                {
                    return "����ʱ��Ӧ��С��ת��ʱ��";
                }
            }
            else
            {
                return "��Ժʱ��Ӧ��С�ڱ���ʱ��";
            }
        }

        /// <summary>
        /// ת���¼
        /// </summary>
        /// <param name="reference_time">�ο�ʱ��</param>
        /// <param name="out_time">ת��ʱ��</param>
        /// <param name="patient_Id">����ID</param>
        /// <param name="turntime">�ʿ�ʱ�䣺����λ</param>
        /// <param name="unit">�ʿ�ʱ�䣺��λ</param>
        /// <param name="tittle_time">����ʱ��</param>
        /// <param name="doc_tittle">�������</param>
        /// <returns></returns>
        public static string Turn_In_Rule(DateTime in_time,DateTime reference_time, DateTime out_time, string patient_Id, int turntime, string unit, DateTime tittle_time, string doc_tittle, bool isNew)
        {
            DateTime temptime = new DateTime();
            //�ҵ����˼�¼�����ת����¼��û���ҵ��Ļ�ֱ�ӵ���û���ҵ���¼
            //out_time = reference_time;
            //string SqlInfoouttime = "select b.happen_time,b.action_type from t_in_patient a inner join t_inhospital_action b on a.id=b.patient_id where a.id=" + patient_Id + "and b.action_type='ת��' order by happen_time desc";
            //DataSet PatientInfodsouttime = App.GetDataSet(SqlInfoouttime);
            //if (PatientInfodsouttime != null && PatientInfodsouttime.Tables.Count > 0)
            //{
            //    if (PatientInfodsouttime.Tables[0].Rows.Count > 0)
            //    {
            //        if (PatientInfodsouttime.Tables[0].Rows[0]["action_type"].ToString() == "ת��")
            //        {
            //            out_time = Convert.ToDateTime(PatientInfodsouttime.Tables[0].Rows[0]["happen_time"].ToString());
            //        }
            //    }
            //}
            //ת����¼
            string turn_outInfo = "select doc_name from t_patients_doc t where  t.textkind_id=130 and t.patient_id='" + patient_Id + "' order by doc_name desc ";
            //ת����Ϣ
            string turn_inInfo = "select doc_name from t_patients_doc t where  t.textkind_id=301 and t.patient_id='" + patient_Id + "' order by doc_name desc ";
            DataSet PatientInfodsouttime = App.GetDataSet(turn_outInfo);
            DataSet PatientInfodsintime = App.GetDataSet(turn_inInfo);
            if (PatientInfodsintime != null)
            {
                if (PatientInfodsouttime.Tables[0].Rows.Count > 0)
                {
                    try
                    {
                        out_time = Convert.ToDateTime(App.GetTimeString(PatientInfodsouttime.Tables[0].Rows[0]["doc_name"].ToString()));
                    }
                    catch 
                    {
                        return "δ�ҵ����Ӧ��ת����¼";
                    }
                }
                else
                {
                    return "δ�ҵ����Ӧ��ת����¼";
                }
            }
            if (unit == "Сʱ")
            {
                temptime = out_time.AddHours(turntime);
            }
            else if (unit == "��")
            {
                temptime = out_time.AddDays(turntime);
            }
            //out_time ת��ʱ�� temptimeת��ʱ��+24Сʱ  in_time ��Ժʱ�� tittle_time ����ʱ��
            tittle_time = Convert.ToDateTime(App.GetTimeString(doc_tittle));
            if (isNew == false)
            {
                //ת����¼Ҫ����ת���¼
                if (PatientInfodsouttime.Tables[0].Rows.Count > PatientInfodsintime.Tables[0].Rows.Count)
                {
                    if (out_time < tittle_time)
                    {
                        return "";
                    }
                    else
                    {
                        return "ת����¼����ʱ��Ӧ��С��ת���¼����ʱ�䣨�����Ӧ�ģ�";
                    }
                }
                else
                {
                    return "δ�ҵ����Ӧ��ת����¼";
                }
            }
            else
            {
                if (PatientInfodsouttime.Tables[0].Rows.Count+1 > PatientInfodsintime.Tables[0].Rows.Count)
                {
                    if (out_time < tittle_time)
                    {
                        return "";
                    }
                    else
                    {
                        return "ת����¼����ʱ��Ӧ��С��ת���¼����ʱ�䣨�����Ӧ�ģ�";
                    }
                }
                else
                {
                    return "δ�ҵ����Ӧ��ת����¼";
                }
            }
            //if (tittle_time < temptime || tittle_time == temptime)
            //{
            //    if (out_time < tittle_time)
            //    {
            //        return "";
            //    }
            //    else
            //    {
            //        return "���Ӧ��ת��ʱ��Ӧ��С��ת���¼����ʱ�䣩";
            //    }
            //}
            //else
            //{
            //    return "����ʱ��Ӧ��С�ڵ���ת��ʱ��+24Сʱ";
            //}
        }

        /// <summary>
        /// �����¼
        /// </summary>
        /// <param name="tittle_time">����ʱ��</param>
        /// <param name="doc_tittle">�������</param>
        /// <param name="reference_time">�ο�ʱ��</param>
        /// <param name="in_time">��Ժʱ��</param>
        /// <returns></returns>
        public static string JiaoBan_Record_Rule(DateTime tittle_time, string doc_tittle, DateTime reference_time, DateTime in_time)
        {
            if (doc_tittle.Length != 0)
                tittle_time = Convert.ToDateTime(App.GetTimeString(doc_tittle));
            if (tittle_time != reference_time)
            {
                if (in_time < tittle_time)
                {
                    return "";
                }
                else
                {
                    return "��Ժʱ��Ӧ��С�����Ӧ�Ľ����¼ ����ʱ��";
                }
            }
            return "";
        }

        /// <summary>
        /// �Ӱ��¼
        /// </summary>
        /// <param name="tittle_time">����ʱ��</param>
        /// <param name="doc_tittle">�������</param>
        /// <param name="in_time">��Ժʱ��</param>
        /// <returns></returns>
        public static string JieBan_Record_Rule(DateTime tittle_time, string doc_tittle, DateTime in_time,string patient_id)
        {
            DataSet dsexchange = new DataSet();
            string Sqlexchange = "select doc_name from t_patients_doc e where  e.textkind_id=890 and e.patient_id='"+patient_id+"' order by doc_name desc ";
            dsexchange = App.GetDataSet(Sqlexchange);
            DateTime jiaob_time = new DateTime();
            if (dsexchange != null)
            {
                DataTable dt = dsexchange.Tables[0];
                if (dt != null)
                {
                    if (dt.Rows.Count == 0)
                    {
                        return "δ�ҵ���Ӧ�Ľ����¼��";
                    }
                    else
                    {
                        string tittle_name = dt.Rows[0][0].ToString();//�����¼
                        if (tittle_name.Length != 0)
                        {
                            jiaob_time = Convert.ToDateTime(App.GetTimeString(tittle_name));
                        }
                    }
                }
            }
            if (doc_tittle.Length > 0)
            {
                tittle_time = Convert.ToDateTime(App.GetTimeString(doc_tittle));
            }
            if (in_time < jiaob_time)
            {
                if (jiaob_time < tittle_time)
                {
                    if (tittle_time < jiaob_time.AddHours(24) || tittle_time == jiaob_time.AddHours(24))
                    {
                        return "";
                    }
                    else
                    {
                        return "���Ӧ�ĽӰ��¼����ʱ��Ӧ��С�����Ӧ�Ľ����¼����ʱ��+24Сʱ";
                    }
                }
                else
                {
                    return "���Ӧ�Ľ����¼����ʱ��Ӧ��С�����Ӧ�ĽӰ��¼����ʱ��";
                }
            }
            else
            {
                return "��Ժʱ��Ӧ��С�����Ӧ�Ľ����¼�ı���ʱ��";
            }
            return "";
        }

        /// �׶�С��
        /// </summary>
        /// <param name="tittle_time">����ʱ��</param>
        /// <param name="doc_tittle">�������</param>
        /// <param name="turntime">�ʿ�ʱ�䣺����λ</param>
        /// <param name="unit">�ʿ�ʱ�䣺��λ</param>
        /// <param name="in_time">��Ժʱ��</param>
        /// <param name="patient_Id">����ID</param>
        /// <returns></returns>
        public static string Stage_Summary_Rule(DateTime tittle_time, string doc_tittle, int turntime, string unit, DateTime in_time, string patient_Id)
        {
            DateTime temptime = new DateTime();
            if (unit == "Сʱ")
            {
                temptime = in_time.AddHours(turntime);
            }
            else if (unit == "��")
            {
                temptime = in_time.AddDays(turntime);
            }
            if (tittle_time < in_time || tittle_time == in_time)
            {
                return "����ʱ��Ӧ�ô�����Ժʱ��";
            }
            //�׶�С�ᣬ��Ժʱ�䣬��ǰ���ۣ�ת���¼���Ӱ��¼
            string Sqlstage = "select * from t_patients_doc  t  where  t.textkind_id in ('131','301','891') and t.patient_id='" + patient_Id + "'  order by t.doc_name desc";
            string Sqlstage1 = "select * from t_patients_doc  t  where  t.textkind_id='134' and t.patient_id='" + patient_Id + "'  order by t.doc_name desc";
            DataSet dsStage = App.GetDataSet(Sqlstage);
            DataSet dsStage1 = App.GetDataSet(Sqlstage1);
            if (dsStage != null && dsStage1 != null)
            {
                if (dsStage.Tables[0].Rows.Count == 0 && dsStage1.Tables[0].Rows.Count==0)
                {
                    if (tittle_time < temptime || tittle_time == temptime)
                    {
                        return "";
                    }
                    else
                    {
                        return "����ʱ��Ӧ��С�ڵ�����Ժʱ�䣨��ȡ�������޸ģ�+30��";
                    }
                }
                else
                {
                    if (dsStage.Tables[0].Rows.Count > 0)
                    {
                        DateTime beforeTime = Convert.ToDateTime(App.GetTimeString(dsStage.Tables[0].Rows[0]["doc_name"].ToString()));
                        if (dsStage1.Tables[0].Rows.Count == 0)
                        {
                            if (tittle_time > beforeTime.AddDays(30))
                            {
                                return "ÿ30��Ӧ����һ���׶�С��";
                            }
                        }
                        else
                        {
                            
                            #region
                            for (int num = 0; num < dsStage1.Tables[0].Rows.Count; num++)
                            {
                                XmlDocument xnldocument = new XmlDocument();
                                DateTime taolun = new DateTime();
                                xnldocument.LoadXml(dsStage1.Tables[0].Rows[num]["patients_doc"].ToString());
                                XmlNodeList footnodeListInput = xnldocument.GetElementsByTagName("input");
                                for (int ii = 0; ii < footnodeListInput.Count; ii++)
                                {
                                    string strout_time = "";
                                    if (footnodeListInput[ii].Attributes["name"].Value == "��������")
                                    {
                                        for (int chnu = 0; chnu < footnodeListInput[ii].ChildNodes.Count; chnu++)
                                        {

                                            if (footnodeListInput[ii].ChildNodes[chnu].OuterXml.ToString().Contains("deleter"))
                                            {
                                                continue;
                                            }
                                            else
                                            {
                                                strout_time += footnodeListInput[ii].ChildNodes[chnu].InnerText;
                                            }

                                        }
                                        strout_time = strout_time.Replace("��", " ");
                                        strout_time = strout_time.Replace(",", " ");
                                        strout_time = strout_time.Replace("��", ":");
                                        if (strout_time != "")
                                        {
                                            try
                                            {
                                                //����ʱ��
                                                taolun = Convert.ToDateTime(strout_time);
                                            }
                                            catch
                                            {
                                                //
                                            }
                                        }
                                        if (taolun > beforeTime)
                                        {
                                            beforeTime = taolun;
                                        }
                                    }
                                }
                            }
                            if (tittle_time > beforeTime.AddDays(30))
                            {
                                return "ÿ30��Ӧ����һ���׶�С��";
                            }
                            #endregion
                        }
                    }
                    else
                    {
                        DateTime beforeTime = new DateTime();
                        #region
                        for (int num = 0; num < dsStage1.Tables[0].Rows.Count; num++)
                        {
                            XmlDocument xnldocument = new XmlDocument();
                            DateTime taolun = new DateTime();
                            xnldocument.LoadXml(dsStage1.Tables[0].Rows[num]["patients_doc"].ToString());
                            XmlNodeList footnodeListInput = xnldocument.GetElementsByTagName("input");
                            for (int ii = 0; ii < footnodeListInput.Count; ii++)
                            {
                                string strout_time = "";
                                if (footnodeListInput[ii].Attributes["name"].Value == "��������")
                                {
                                    for (int chnu = 0; chnu < footnodeListInput[ii].ChildNodes.Count; chnu++)
                                    {

                                        if (footnodeListInput[ii].ChildNodes[chnu].OuterXml.ToString().Contains("deleter"))
                                        {
                                            continue;
                                        }
                                        else
                                        {
                                            strout_time += footnodeListInput[ii].ChildNodes[chnu].InnerText;
                                        }

                                    }
                                    strout_time = strout_time.Replace("��", " ");
                                    strout_time = strout_time.Replace(",", " ");
                                    strout_time = strout_time.Replace("��", ":");
                                    if (strout_time != "")
                                    {
                                        try
                                        {
                                            //����ʱ��
                                            taolun = Convert.ToDateTime(strout_time);
                                        }
                                        catch
                                        {
                                            taolun = Convert.ToDateTime("0001-01-01");
                                        }
                                    }
                                    if (taolun > beforeTime)
                                    {
                                        beforeTime = taolun;
                                    }
                                }
                            }
                        }
                        if (tittle_time > beforeTime.AddDays(30))
                        {
                            return "ÿ30��Ӧ����һ���׶�С��";
                        }
                        #endregion
                    }
                }
            }
            return "";
        }

        /// <summary>
        /// �����¼
        /// </summary>
        /// <param name="patient_id">����ID</param>
        /// <param name="turntime">�ʿ�ʱ�䣺����λ</param>
        /// <param name="unit">�ʿ�ʱ�䣺��λ</param>
        /// <param name="tittle_time">����ʱ��</param>
        /// <param name="doc_tittle">�������</param>
        /// <returns></returns>
        public static string Consultaion_Record_Rule(string patient_id, int turntime, string unit, DateTime tittle_time, string doc_tittle)
        {
            //����������t_consultaion_apply  ���������t_consultaion_record 
            string Sqlapply = "select apply_time from t_consultaion_apply t where 1=1 and t.patient_id='" + patient_id + "'";
            DateTime consulTime = new DateTime();//�����ʱ��
            DataSet ds = App.GetDataSet(Sqlapply);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        consulTime = Convert.ToDateTime(dt.Rows[0]["apply_time"].ToString());
                    }
                    else
                    {
                        return "�Ҳ�����Ӧ��������¼";
                    }
                }
                else
                {
                    return "�Ҳ�����Ӧ��������¼";
                }
            }
            else
            {
                return "�Ҳ�����Ӧ��������¼";

            }
            tittle_time = Convert.ToDateTime(App.GetTimeString(doc_tittle));
            DateTime temptime = new DateTime();
            if (unit == "Сʱ")
            {
                temptime = consulTime.AddHours(turntime);
            }
            else if (unit == "��")
            {
                temptime = consulTime.AddDays(turntime);
            }
            if (consulTime < tittle_time)
            {
                if ((tittle_time < temptime) || (tittle_time == temptime))
                {
                    return "";
                }
                else
                {
                    return "Ӧ����������дʱ��Ӧ��С�ڵ����������Ҽ�¼ʱ��/����+48Сʱ";
                }
            }
            else
            {
                return "�������Ҽ�¼ʱ��/����Ӧ��С��Ӧ����������дʱ��";
            }
        }

        /// <summary>
        /// ��Ժ��¼
        /// </summary>
        /// <param name="patient_id">����ID</param>
        /// <param name="in_time">��Ժʱ��</param>
        /// <param name="tittle_time">����ʱ��</param>
        /// <param name="doc_tittle">�������</param>
        /// <param name="xmldocument">��ǰ����</param>
        /// <returns></returns>
        public static string Out_Record_Rule(string patient_id, DateTime in_time, DateTime tittle_time, string doc_tittle, System.Xml.XmlDocument xmldocument)
        {
            string Sqllastbc = "select textname,doc_name,textkind_id from t_patients_doc  t where t.patient_id='" + patient_id + "' and t.textkind_id='844' order by doc_name desc";
            DataSet dslastbingcheng = App.GetDataSet(Sqllastbc);//���һ�β��̼�¼

            if (dslastbingcheng != null && dslastbingcheng.Tables[0].Rows.Count == 0)
            {
                return "��Ժǰ���һ�β�������û��д";
            }
            else
            {
                DateTime out_time1 = new DateTime();
                string strout_time = "";
                XmlNodeList footnodeListInput = xmldocument.GetElementsByTagName("input");
                for (int ii = 0; ii < footnodeListInput.Count; ii++)
                {
                    if (footnodeListInput[ii].Attributes["name"].Value == "��Ժ����" || 
                        footnodeListInput[ii].Attributes["name"].Value == "��Ժʱ��")
                    {

                        for (int chnu = 0; chnu < footnodeListInput[ii].ChildNodes.Count; chnu++)
                        {

                            if (footnodeListInput[ii].ChildNodes[chnu].OuterXml.ToString().Contains("deleter"))
                            {
                                continue;
                            }
                            else
                            {
                                strout_time += footnodeListInput[ii].ChildNodes[chnu].InnerText;
                            }

                        }
                    }
                }
                strout_time = strout_time.Replace("��", " ");
                strout_time = strout_time.Replace(",", " ");
                strout_time = strout_time.Replace("��", ":");
                if (strout_time != "")
                {
                    try
                    {
                        //��Ժʱ��
                        out_time1 = Convert.ToDateTime(strout_time);
                    }
                    catch
                    {
                        return "��Ժʱ���ʽ����ȷ�������������ύ��";
                    }
                }
                //���һ�β��̼�¼��ʱ��
                doc_tittle = dslastbingcheng.Tables[0].Rows[0]["doc_name"].ToString();
                tittle_time = Convert.ToDateTime(App.GetTimeString(doc_tittle));
                //��Ժǰ���һ�β��̼�¼�ͳ�Ժ������һ��Ļ������ҳ�Ժ���ڵĺ������00��00��ʱ��ʱ���Ĭ��Ϊ23:59
                if (out_time1.ToShortDateString() == tittle_time.ToShortDateString() && out_time1.ToString().Contains("0:00:00") == true && out_time1.ToString().Contains("10:00:00") == false && out_time1.ToString().Contains("20:00:00")==false)
                {
                    out_time1 = out_time1.AddHours(23).AddMinutes(59);
                }
                if (in_time < tittle_time)
                {
                    if (tittle_time < out_time1)
                    {
                        return "";
                    }
                    else
                    {
                        return "��Ժ/����ǰ���һ�β��� ����ʱ��Ӧ��С�ڳ�Ժʱ��/���� ";
                    }
                }
                else
                {
                    return "סԺʱ��/���ڣ���Ժʱ��/���ڣ�Ӧ��С�ڳ�Ժ/����ǰ���һ�β��� ����ʱ��";
                }
            }
        }

        /// <summary>
        /// <summary>
        /// ������¼
        /// </summary>
        /// <param name="patient_id">����ID</param>
        /// <param name="in_time">��Ժʱ��</param>
        /// <param name="tittle_time">����ʱ��</param>
        /// <param name="doc_tittle">�������</param>
        /// <param name="xmldocument">��ǰ����</param>
        /// <returns></returns>
        public static string Die_Record_Rule(string patient_id, DateTime in_time, DateTime tittle_time, string doc_tittle, System.Xml.XmlDocument xmldocument)
        {
            string Sqllastbc = "select textname,doc_name,textkind_id from t_patients_doc  t  where t.patient_id='" + patient_id + "' and t.textkind_id='844' order by doc_name desc";
            DataSet dslastbingcheng = App.GetDataSet(Sqllastbc);//���һ�β��̼�¼
            if (dslastbingcheng != null && dslastbingcheng.Tables[0].Rows.Count == 0)
            {
                return "����ǰ���һ�β�������û��д";
            }
            else
            {
                DateTime out_time1 = new DateTime();
                string strout_time = "";
                XmlNodeList footnodeListInput = xmldocument.GetElementsByTagName("input");
                for (int ii = 0; ii < footnodeListInput.Count; ii++)
                {
                    if (footnodeListInput[ii].Attributes["name"].Value == "��Ժʱ��"|| 
                        footnodeListInput[ii].Attributes["name"].Value == "��Ժ����")
                    {

                        for (int chnu = 0; chnu < footnodeListInput[ii].ChildNodes.Count; chnu++)
                        {

                            if (footnodeListInput[ii].ChildNodes[chnu].OuterXml.ToString().Contains("deleter"))
                            {
                                continue;
                            }
                            else
                            {
                                strout_time += footnodeListInput[ii].ChildNodes[chnu].InnerText;
                            }
                        }
                    }
                }
                strout_time = strout_time.Replace("��", " ");
                strout_time = strout_time.Replace(",", " ");
                strout_time = strout_time.Replace("��", ":");
                if (strout_time != "")
                {
                    try
                    {
                        //����ʱ��
                        out_time1 = Convert.ToDateTime(strout_time);
                    }
                    catch
                    {
                        return "��Ժʱ���ʽ����ȷ�������������ύ��";
                    }
                }
                //���һ�β��̼�¼ʱ��
                //doc_tittle = dslastbingcheng.Tables[0].Rows[0]["doc_name"].ToString();
                //tittle_time = Convert.ToDateTime(App.GetTimeString(doc_tittle));

                //if (in_time < tittle_time)
                //{
                //    if (tittle_time < out_time1)
                //    {
                //        return "";
                //    }
                //    else
                //    {
                //        return "����ǰ���һ�β��� ����ʱ��Ӧ��С������ʱ��/����";
                //    }
                //}
                //else
                //{
                //    return "סԺʱ��/���ڣ���Ժʱ��/���ڣ�Ӧ��С������ǰ���һ�β��� ����ʱ��";
                //}
                if (in_time < out_time1)
                {

                }
                else
                {
                    return "סԺʱ��/���ڣ���Ժʱ��/���ڣ�Ӧ��С������ʱ��/����";
                }
            }
            return "";
        }

        /// <summary>
        /// ���һ�β��̼�¼
        /// </summary>
        /// <param name="tittle_time">����ʱ��</param>
        /// <param name="doc_tittle">�������</param>
        /// <param name="in_time">��Ժʱ��</param>
        /// <returns></returns>
        public static string Last_Medical_Record_Rule(DateTime tittle_time, string doc_tittle, DateTime in_time)
        {
            if (doc_tittle != "")
                tittle_time = Convert.ToDateTime(App.GetTimeString(doc_tittle));
            if (in_time < tittle_time)
            {
                return "";
            }
            else
            {
                return "סԺʱ��/���ڣ���Ժʱ��/���ڣ�Ӧ��С�ڳ�Ժ/����ǰ���һ�β��� ����ʱ��";
            }
        }

        /// <summary>
        /// �����������ۼ�¼
        /// </summary>
        /// <param name="patient_Id">����ID</param>
        /// <param name="turntime">�ʿ�ʱ�䣺����λ</param>
        /// <param name="unit">�ʿ�ʱ�䣺��λ</param>
        /// <param name="out_time">����ʱ��</param>
        /// <param name="tittle_time">����ʱ��</param>
        /// <param name="doc_tittle">�������</param>
        /// <returns></returns>
        public static string Die_Discussion_Record(string patient_Id, int turntime, string unit, DateTime out_time, DateTime tittle_time, string doc_tittle)
        {
            tittle_time = Convert.ToDateTime(App.GetTimeString(doc_tittle));
            string Sqldie = "select * from t_patients_doc t inner join  t_in_patient b on t.pid=b.pid where textname like '%������¼%' and b.id='" + patient_Id + "' ";
            DataSet dsDie = App.GetDataSet(Sqldie);
            if (dsDie != null && dsDie.Tables.Count > 0)
            {
                if (dsDie.Tables[0].Rows.Count == 0)
                {
                    return "������¼/24Сʱ����Ժ������¼û��д";
                }
                else
                {
                    string strout_time = "";
                    string t_textkind_id= dsDie.Tables[0].Rows[0]["textkind_id"].ToString();
                    //������¼
                    if (t_textkind_id == "138")
                    {
                        XmlDocument die = new XmlDocument();
                        die.LoadXml(dsDie.Tables[0].Rows[0]["patients_doc"].ToString());
                        //dsDie.Tables[0].Rows[0]["patients_doc"] as XmlDocument;
                        XmlNodeList footnodeListInput = die.GetElementsByTagName("input");
                        for (int ii = 0; ii < footnodeListInput.Count; ii++)
                        {
                            if (footnodeListInput[ii].Attributes["name"].Value == "��Ժʱ��")
                            {

                                for (int chnu = 0; chnu < footnodeListInput[ii].ChildNodes.Count; chnu++)
                                {

                                    if (footnodeListInput[ii].ChildNodes[chnu].OuterXml.ToString().Contains("deleter"))
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        strout_time += footnodeListInput[ii].ChildNodes[chnu].InnerText;
                                    }
                                }
                            }
                        }
                        strout_time = strout_time.Replace("��", " ");
                        strout_time = strout_time.Replace(",", " ");
                        strout_time = strout_time.Replace("��", ":");
                        if (strout_time != "")
                        {
                            try
                            {
                                //����ʱ��
                                out_time = Convert.ToDateTime(strout_time);
                            }
                            catch
                            {
                                return "��Ժʱ���ʽ����ȷ�������������ύ��";
                            }
                        }

                    }
                    //24Сʱ����Ժ������¼
                    else if (t_textkind_id == "121")
                    {
                        XmlDocument die = new XmlDocument();
                        die.LoadXml(dsDie.Tables[0].Rows[0]["patients_doc"].ToString());
                        XmlNodeList footnodeListInput = die.GetElementsByTagName("input");
                        for (int ii = 0; ii < footnodeListInput.Count; ii++)
                        {
                            if (footnodeListInput[ii].Attributes["name"].Value == "����ʱ��")
                            {

                                for (int chnu = 0; chnu < footnodeListInput[ii].ChildNodes.Count; chnu++)
                                {

                                    if (footnodeListInput[ii].ChildNodes[chnu].OuterXml.ToString().Contains("deleter"))
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        strout_time += footnodeListInput[ii].ChildNodes[chnu].InnerText;
                                    }
                                }
                            }
                        }
                        strout_time = strout_time.Replace("��", " ");
                        strout_time = strout_time.Replace(",", " ");
                        strout_time = strout_time.Replace("��", ":");
                        if (strout_time != "")
                        {
                            try
                            {
                                //����ʱ��
                                out_time = Convert.ToDateTime(strout_time);
                            }
                            catch
                            {
                                return "��Ժʱ���ʽ����ȷ�������������ύ��";
                            }
                        }

                    }
                    DateTime temptime = new DateTime();
                    if (unit == "Сʱ")
                    {
                        temptime = out_time.AddHours(turntime);
                    }
                    else if (unit == "��")
                    {
                        temptime = out_time.AddDays(turntime);
                    }
                    if (out_time < tittle_time)
                    {
                        if (tittle_time < temptime || tittle_time == temptime)
                        {
                            return "";
                        }
                        else
                        {
                            return "����ʱ��Ӧ��С�ڵ���+7��";
                        }
                    }
                    else
                    {
                        return "����ʱ��Ӧ��С�ڱ���ʱ��";
                    }
                }
            }
            return "";
        }

        /// <summary>
        /// �����ơ��ƻ���������/סԺ������
        /// </summary>
        /// <param name="in_time">��Ժʱ��</param>
        /// <param name="sign_time">ǩ��ʱ��</param>
        /// <param name="XmlDocument">��ǰ����</param>
        /// <param name="out_time">��Ժʱ��</param>
        /// <param name="doc_tittle">�������</param>
        /// <returns></returns>
        public static string Beijing_Birth_Control_Record_Rule(DateTime in_time, DateTime sign_time, System.Xml.XmlDocument xmldocument, DateTime out_time, string doc_tittle)
        {
            XmlNodeList HeadNode = xmldocument.GetElementsByTagName("head");
            doc_tittle = HeadNode[0].Attributes["text_name"].Value;
            string strout_time = "";
            //�����мƻ���������/סԺ���� ����<����ǩ��ʱ�䣨����ǩ�������ʱ�䣩
            if (doc_tittle.Contains("����") == true)
            {
                if (in_time < sign_time)
                {
                    return "";
                }
                else
                {
                    return "��Ժ����Ӧ��С��ǩ��ʱ��";
                }
            }
            //��Ժʱ�䣨��ȡ�������޸�)<��Ժʱ��<=��Ժʱ�䣨��ȡ�������޸�)+24Сʱ
            //And ��Ժʱ��<=����ǩ��ʱ�䣨����ǩ�������ʱ�䣩<=��Ժʱ�䣨��ȡ�������޸�)+24Сʱ
            else if (doc_tittle.Contains("����") == false && doc_tittle.Contains("�ƻ�����") == true)
            {
                bool IsFirstNew = false;
                XmlNodeList InputNodeList = xmldocument.GetElementsByTagName("input");
                for (int ii = 0; ii < InputNodeList.Count; ii++)
                {
                    if (InputNodeList[ii].Attributes["name"].Value == "������������")
                    {
                        IsFirstNew = true;
                        for (int chnu = 0; chnu < InputNodeList[ii].ChildNodes.Count; chnu++)
                        {

                            if (InputNodeList[ii].ChildNodes[chnu].OuterXml.ToString().Contains("deleter"))
                            {
                                continue;
                            }
                            else
                            {
                                strout_time += InputNodeList[ii].ChildNodes[chnu].InnerText;
                            }
                        }
                        if (IsFirstNew == true)
                        {
                            break;
                        }
                    }
                }
                strout_time = strout_time.Replace("��", " ");
                strout_time = strout_time.Replace(",", " ");
                strout_time = strout_time.Replace("��", ":");
                if (strout_time != "")
                {
                    try
                    {
                        //��Ժʱ��
                        out_time = Convert.ToDateTime(strout_time);
                    }
                    catch
                    {
                        return "��Ժʱ���ʽ����ȷ�������������ύ��";
                    }
                }
                if (in_time < out_time)
                {
                    if (out_time < in_time.AddHours(24)||out_time==in_time.AddHours(24))
                    {
                        if (in_time < sign_time || in_time == sign_time)
                        {
                            if (sign_time < out_time.AddHours(24) || sign_time == out_time.AddHours(24))
                            {
                                return "";
                            }
                            else
                            {
                                return "����ǩ��ʱ��Ӧ��С�ڵ��ڳ�Ժʱ��+24Сʱ";
                            }
                        }
                        else
                        {
                            return "��Ժʱ��Ӧ��С�ڵ�������ǩ��ʱ��";
                        }
                    }
                    else
                    {
                        return "��Ժʱ��Ӧ��С�ڵ�����Ժʱ��+24Сʱ";
                    }
                }
                else
                {
                    return "��Ժʱ��Ӧ��С�ڳ�Ժʱ��";
                }
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// һ�ղ���סԺ��������Σ�
        /// </summary>
        /// <param name="in_time">��Ժʱ��</param>
        /// <param name="sign_time">����ʱ��</param>
        /// <param name="xmldocument">��ǰ����</param>
        /// <param name="out_time">��Ժʱ��</param>
        /// <returns></returns>
        public static string Day_Medical_Record_Curattage_Rule(DateTime in_time, DateTime sign_time, System.Xml.XmlDocument xmldocument, DateTime out_time)
        {
            bool IsFirstNew = false;
            string strout_time = "";
            XmlNodeList InputNodeList = xmldocument.GetElementsByTagName("input");
            for (int ii = 0; ii < InputNodeList.Count; ii++)
            {
                if (InputNodeList[ii].Attributes["name"].Value == "������������")
                {
                    IsFirstNew = true;
                    for (int chnu = 0; chnu < InputNodeList[ii].ChildNodes.Count; chnu++)
                    {

                        if (InputNodeList[ii].ChildNodes[chnu].OuterXml.ToString().Contains("deleter"))
                        {
                            continue;
                        }
                        else
                        {
                            strout_time += InputNodeList[ii].ChildNodes[chnu].InnerText;
                        }
                    }
                    if (IsFirstNew == true)
                    {
                        break;
                    }
                }
            }
            strout_time = strout_time.Replace("��", " ");
            strout_time = strout_time.Replace(",", " ");
            strout_time = strout_time.Replace("��", ":");
            if (strout_time != "")
            {
                try
                {
                    //��Ժʱ��
                    out_time = Convert.ToDateTime(strout_time);
                }
                catch
                {
                    return "��Ժʱ���ʽ����ȷ�������������ύ��";
                }
            }
            if (in_time < out_time)
            {
                if (out_time < in_time.AddHours(24) || out_time == in_time.AddHours(24))
                {
                    if (sign_time < out_time.AddHours(24) || sign_time == out_time.AddHours(24))
                    {
                        return "";
                    }
                    else
                    {
                        return "����ǩ��ʱ��Ӧ��С�ڵ��ڳ�Ժʱ��+24Сʱ";
                    }
                }
                else
                {
                    return "��Ժʱ��Ӧ��С�ڵ�����Ժʱ��+24Сʱ";
                }
            }
            else
            {
                return "��Ժʱ��Ӧ��С�ڳ�Ժʱ��";
            }
        }



        /// <summary>
        /// ������¼
        /// </summary>
        /// <param name="patient_Id">����ID</param>
        /// <param name="xmldocument">��ǰ����</param>
        /// <param name="in_time">��Ժʱ��</param>
        /// <returns></returns>
        public static string Operation_Record_Rule(string patient_Id, System.Xml.XmlDocument xmldocument,DateTime in_time,bool isNew)
        {
            DateTime operation_time = new DateTime();//����ʱ��
            DateTime medical_time = new DateTime();//���̼�¼����ʱ��
            bool IsFirstNew = false;
            string strout_time = "";
            string sql_before_operation = "select * from t_patients_doc t where t.textkind_id='135' and t.patient_id='" + patient_Id + "' ";
            string sql_operation = "select * from t_patients_doc t where t.textkind_id='151' and t.patient_id='" + patient_Id + "' ";
            string sql_medical_recodr = "select * from t_patients_doc t where  t.patient_id='" + patient_Id + "' and textkind_id in ('125','126','127','135') " +
                                        " order by doc_name desc";
            XmlNodeList InputNodeList = xmldocument.GetElementsByTagName("input");
            for (int ii = 0; ii < InputNodeList.Count; ii++)
            {
                if (InputNodeList[ii].Attributes["name"].Value == "��������")
                {
                    IsFirstNew = true;
                    for (int chnu = 0; chnu < InputNodeList[ii].ChildNodes.Count; chnu++)
                    {

                        if (InputNodeList[ii].ChildNodes[chnu].OuterXml.ToString().Contains("deleter"))
                        {
                            continue;
                        }
                        else
                        {
                            strout_time += InputNodeList[ii].ChildNodes[chnu].InnerText;
                        }
                    }
                    if (IsFirstNew == true)
                    {
                        break;
                    }
                }
            }
            strout_time = strout_time.Replace("��", " ");
            strout_time = strout_time.Replace(",", " ");
            strout_time = strout_time.Replace("��", ":");
            if (strout_time != "")
            {
                try
                {
                    //����ʱ��
                    operation_time = Convert.ToDateTime(strout_time);
                }
                catch
                {
                    return "�������ڸ�ʽ����ȷ�������������ύ��";
                }
            }

            operation_time = Convert.ToDateTime(operation_time.ToShortDateString());
            if (operation_time.ToString().Contains("0:00:00") == true && operation_time.ToString().Contains("10:00:00") == false && operation_time.ToString().Contains("20:00:00") == false)
            {
                operation_time = operation_time.AddHours(23).AddMinutes(59);
            }
            DataSet ds_before_operation = App.GetDataSet(sql_before_operation);
            DataSet ds_operation = App.GetDataSet(sql_operation);
            if (ds_before_operation != null)
            {
                if (ds_before_operation.Tables.Count > 0)
                {
                    if (ds_before_operation.Tables[0].Rows.Count == 0)
                    {
                        return "������¼�ύǰ��������ǰС�ᣡ";
                    }
                }
            }
            if (operation_time < Convert.ToDateTime(in_time.ToShortDateString()))
            {
                return "��Ժ����Ӧ��С�ڵ�����������";
            }
            if (isNew == false)
            {
                if (ds_before_operation.Tables[0].Rows.Count == ds_operation.Tables[0].Rows.Count || ds_before_operation.Tables[0].Rows.Count < ds_operation.Tables[0].Rows.Count)
                {
                    return "ÿ��������¼ǰ����Ҫ��һ����ǰС�ᣡ";
                }
                if (operation_time.ToShortDateString() == in_time.ToShortDateString())
                {
                    return "";
                }
                DataSet ds_medical_record = App.GetDataSet(sql_medical_recodr);
                if (ds_medical_record != null)
                {
                    
                    if (ds_medical_record.Tables.Count > 0)
                    {
                        if (ds_medical_record.Tables[0].Rows.Count == 0)
                        {
                            return "������¼�ύʱ��ǰһ�������һ�β��̼�¼��";
                        }
                        else
                        {
                            for (int i = 0; i < ds_medical_record.Tables[0].Rows.Count; i++)
                            {
                                string doc_name = ds_medical_record.Tables[0].Rows[i]["doc_name"].ToString();
                                medical_time = Convert.ToDateTime(App.GetTimeString(doc_name));
                                if (medical_time.AddHours(24).ToShortDateString() == operation_time.ToShortDateString())
                                {
                                    return "";
                                }
                            }
                            return "������¼�ύʱ��ǰһ�������һ�β��̼�¼";
                        }
                    }
                }
            }
            else
            {
                if (ds_before_operation.Tables[0].Rows.Count < ds_operation.Tables[0].Rows.Count)
                {
                    return "ÿ��������¼ǰ����Ҫ��һ����ǰС�ᣡ";
                }
                if (operation_time.ToShortDateString() == in_time.ToShortDateString())
                {
                    return "";
                }
                DataSet ds_medical_record = App.GetDataSet(sql_medical_recodr);
                if (ds_medical_record != null)
                {
                    if (ds_medical_record.Tables.Count > 0)
                    {
                        if (ds_medical_record.Tables[0].Rows.Count == 0)
                        {
                            return "������¼�ύʱ��ǰһ�������һ�β��̼�¼��";
                        }
                        else
                        {
                            for (int i = 0; i < ds_medical_record.Tables[0].Rows.Count; i++)
                            {
                                string doc_name = ds_medical_record.Tables[0].Rows[i]["doc_name"].ToString();
                                medical_time = Convert.ToDateTime(App.GetTimeString(doc_name));
                                if (medical_time.AddHours(24).ToShortDateString() == operation_time.ToShortDateString())
                                {
                                    return "";
                                }
                            }
                            return "������¼�ύʱ��ǰһ�������һ�β��̼�¼";
                        }
                    }
                }
            }
            return "";
        }


        /// <summary>
        /// ��ǰС��
        /// </summary>
        /// <param name="tittle_time">����ʱ��</param>
        /// <param name="doc_tittle">�������</param>
        /// <param name="in_time">��Ժʱ��</param>
        /// <returns></returns>
        public static string Before_Operation_Rule(DateTime tittle_time, string doc_tittle, DateTime in_time)
        {
            if (doc_tittle != "") 
            {
                try
                {
                    tittle_time = Convert.ToDateTime(App.GetTimeString(doc_tittle));
                }
                catch
                {
                    return "��ǰС�����ʱ�䲻��׼";
                }
            }
            if (in_time < tittle_time || in_time == tittle_time)
            {
                return "";
            }
            else
            {
                return "��Ժʱ��Ӧ��С�ڵ����������ʱ��";
            }
            //return "";
        }
    }
}
