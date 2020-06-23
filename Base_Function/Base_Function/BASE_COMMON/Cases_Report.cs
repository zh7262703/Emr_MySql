using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.Reporting.WinForms;
using System.Collections;

namespace Base_Function.BASE_COMMON
{
    public class Cases_Report
    {

        public static void Local_Report(DataSet DsSource, ReportViewer reportviewer1)
        {
            ArrayList zds = new ArrayList();
            ArrayList list = new ArrayList();
            string OT = "-";
            #region
            //this.reportViewer1.LocalReport.ReportPath = App.SysPath + "\\First_Cases.rdlc";
            reportviewer1.RefreshReport();
            reportviewer1.LocalReport.DataSources.Clear();
            zds.Clear();
            list.Clear();
            string zdval = "";
            string zdvals = "";//���ƴ���ַ���
            string OPERATION = "";
            string operation_s = "";
            if (DsSource != null)
            {
                #region ������ϲ���
                zds.Clear();
                //zds.Count = "" ;
                //�ż������
                DataRow[] rows = DsSource.Tables["COVER_DIAGNOSE"].Select("type='O'");
                #region
                if (rows.Length > 0)
                {
                    zdval = rows[0]["TYPE"].ToString() + "," +
                           rows[0]["CODE"].ToString() + "," +
                           rows[0]["NAME"].ToString() + "," +
                           rows[0]["ICD10NAME"].ToString() + "," +
                           rows[0]["CASE_HOSPITAL"].ToString();
                    zds.Add(zdval);
                }
                else
                {
                    zdval = "-,-,-,-,-";
                    zds.Add(zdval);
                }
                #endregion


                //��Ժ���
                DataRow[] rows1 = DsSource.Tables["COVER_DIAGNOSE"].Select("type='I'");
                #region
                if (rows1.Length > 0)
                {
                    zdval = rows1[0]["TYPE"].ToString() + "," +
                          rows1[0]["CODE"].ToString() + "," +
                          rows1[0]["NAME"].ToString() + "," +
                          rows1[0]["ICD10NAME"].ToString() + "," +
                          rows1[0]["CASE_HOSPITAL"].ToString();
                    zds.Add(zdval);
                }
                else
                {
                    zdval = "-,-,-,-,-";
                    zds.Add(zdval);
                }
                #endregion
                //��Ҫ���
                DataRow[] rows2 = DsSource.Tables["COVER_DIAGNOSE"].Select("type='L' and CODE='1'");
                #region
                if (rows2.Length > 0)
                {

                    zdval = rows2[0]["TYPE"].ToString() + "," +
                          rows2[0]["CODE"].ToString() + "," +
                          rows2[0]["NAME"].ToString() + "," +
                          rows2[0]["ICD10NAME"].ToString() + "," +
                          rows2[0]["CASE_HOSPITAL"].ToString();
                    zds.Add(zdval);
                }
                else
                {
                    zdval = "-,-,-,,";
                    zds.Add(zdval);
                }
                #endregion
                //�������
                #region
                DataRow[] rows22 = DsSource.Tables["COVER_DIAGNOSE"].Select("type='L' and CODE='2'");
                if (rows22.Length > 0)
                {

                    zdval = rows22[0]["TYPE"].ToString() + "," +
                          rows22[0]["CODE"].ToString() + "," +
                          rows22[0]["NAME"].ToString() + "," +
                          rows22[0]["ICD10NAME"].ToString() + "," +
                          rows22[0]["CASE_HOSPITAL"].ToString();
                    zds.Add(zdval);
                }
                else
                {
                    zdval = "-,-,-,,";
                    zds.Add(zdval);
                }
                DataRow[] rows23 = DsSource.Tables["COVER_DIAGNOSE"].Select("type='L' and CODE='3'");
                if (rows23.Length > 0)
                {

                    zdval = rows23[0]["TYPE"].ToString() + "," +
                          rows23[0]["CODE"].ToString() + "," +
                          rows23[0]["NAME"].ToString() + "," +
                          rows23[0]["ICD10NAME"].ToString() + "," +
                          rows23[0]["CASE_HOSPITAL"].ToString();
                    zds.Add(zdval);
                }
                else
                {
                    zdval = "-,-,-,,";
                    zds.Add(zdval);
                }
                DataRow[] rows24 = DsSource.Tables["COVER_DIAGNOSE"].Select("type='L' and CODE='4'");
                if (rows24.Length > 0)
                {

                    zdval = rows24[0]["TYPE"].ToString() + "," +
                          rows24[0]["CODE"].ToString() + "," +
                          rows24[0]["NAME"].ToString() + "," +
                          rows24[0]["ICD10NAME"].ToString() + "," +
                          rows24[0]["CASE_HOSPITAL"].ToString();
                    zds.Add(zdval);
                }
                else
                {
                    zdval = "-,-,-,,";
                    zds.Add(zdval);
                }
                DataRow[] rows25 = DsSource.Tables["COVER_DIAGNOSE"].Select("type='L' and CODE='5'");
                if (rows25.Length > 0)
                {

                    zdval = rows25[0]["TYPE"].ToString() + "," +
                          rows25[0]["CODE"].ToString() + "," +
                          rows25[0]["NAME"].ToString() + "," +
                          rows25[0]["ICD10NAME"].ToString() + "," +
                          rows25[0]["CASE_HOSPITAL"].ToString();
                    zds.Add(zdval);
                }
                else
                {
                    zdval = "-,-,-,,";
                    zds.Add(zdval);
                }
                DataRow[] rows26 = DsSource.Tables["COVER_DIAGNOSE"].Select("type='L' and CODE='6'");
                if (rows26.Length > 0)
                {

                    zdval = rows26[0]["TYPE"].ToString() + "," +
                          rows26[0]["CODE"].ToString() + "," +
                          rows26[0]["NAME"].ToString() + "," +
                          rows26[0]["ICD10NAME"].ToString() + "," +
                          rows26[0]["CASE_HOSPITAL"].ToString();
                    zds.Add(zdval);
                }
                else
                {
                    zdval = "-,-,-,,";
                    zds.Add(zdval);
                }
                DataRow[] rows27 = DsSource.Tables["COVER_DIAGNOSE"].Select("type='L' and CODE='7'");
                if (rows27.Length > 0)
                {

                    zdval = rows27[0]["TYPE"].ToString() + "," +
                          rows27[0]["CODE"].ToString() + "," +
                          rows27[0]["NAME"].ToString() + "," +
                          rows27[0]["ICD10NAME"].ToString() + "," +
                          rows27[0]["CASE_HOSPITAL"].ToString();
                    zds.Add(zdval);
                }
                else
                {
                    zdval = "-,-,-,,";
                    zds.Add(zdval);
                }
                #endregion
                //��ǰ���
                DataRow[] rows3 = DsSource.Tables["COVER_DIAGNOSE"].Select("type='S'");
                #region
                if (rows3.Length > 0)
                {
                    zdval = rows3[0]["TYPE"].ToString() + "," +
                            rows3[0]["CODE"].ToString() + "," +
                            rows3[0]["NAME"].ToString() + "," +
                            rows3[0]["ICD10NAME"].ToString() + "," +
                            rows3[0]["CASE_HOSPITAL"].ToString();
                    zds.Add(zdval);
                }
                else
                {
                    zdval = "-,-,-,,";
                    zds.Add(zdval);
                }
                #endregion

                //�������
                DataRow[] rows4 = DsSource.Tables["COVER_DIAGNOSE"].Select("type='H'");
                #region
                if (rows4.Length > 0)
                {
                    zdval = rows4[0]["TYPE"].ToString() + "," +
                            rows4[0]["CODE"].ToString() + "," +
                            rows4[0]["NAME"].ToString() + "," +
                            rows4[0]["ICD10NAME"].ToString() + "," +
                            rows4[0]["CASE_HOSPITAL"].ToString();
                    zds.Add(zdval);
                }
                else
                {
                    zdval = "-,-,-,,";
                    zds.Add(zdval);
                }
                #endregion
                #endregion
                //ҽԺ��Ⱦ
                DataRow[] rows5 = DsSource.Tables["COVER_DIAGNOSE"].Select("type='F'");
                #region
                if (rows5.Length > 0)
                {
                    zdval = rows5[0]["TYPE"].ToString() + "," +
                            rows5[0]["CODE"].ToString() + "," +
                            rows5[0]["NAME"].ToString() + "," +
                            rows5[0]["ICD10NAME"].ToString() + "," +
                            rows5[0]["CASE_HOSPITAL"].ToString();
                    zds.Add(zdval);
                }
                else
                {
                    zdval = "-,-,-,,";
                    zds.Add(zdval);
                }
                #endregion
                //�������
                DataRow[] rows6 = DsSource.Tables["COVER_DIAGNOSE"].Select("type='P'");
                #region
                if (rows6.Length > 0)
                {
                    zdval = rows6[0]["TYPE"].ToString() + "," +
                           rows6[0]["CODE"].ToString() + "," +
                           rows6[0]["NAME"].ToString() + "," +
                           rows6[0]["ICD10NAME"].ToString() + "," +
                           rows6[0]["CASE_HOSPITAL"].ToString();
                    zds.Add(zdval);
                }
                else
                {
                    zdval = "-,-,-,-,-";
                    zds.Add(zdval);
                }
                #endregion
                //ʬ����Ҫ���
                DataRow[] rows7 = DsSource.Tables["COVER_DIAGNOSE"].Select("type='T'");
                #region
                if (rows7.Length > 0)
                {
                    zdval = rows7[0]["TYPE"].ToString() + "," +
                           rows7[0]["CODE"].ToString() + "," +
                           rows7[0]["NAME"].ToString() + "," +
                           rows7[0]["ICD10NAME"].ToString() + "," +
                           rows7[0]["CASE_HOSPITAL"].ToString();
                    zds.Add(zdval);
                }
                else
                {
                    zdval = "-,-,-,-,-";
                    zds.Add(zdval);
                }
                #endregion
            }

            //�ַ���ƴ��
            if (zds.Count >= 14)
            {
                zdvals = "";
                for (int i = 0; i < zds.Count; i++)
                {
                    zdvals = zdvals + zds[i].ToString() + ";";
                }
            }


            #region ������¼

            if (DsSource.Tables["COVER_OPERATION"].Rows.Count > 0)
            {
                int count = 0;
                for (int i = 0; i < DsSource.Tables["COVER_OPERATION"].Rows.Count; i++)
                {
                    count++;
                    if (DsSource.Tables["COVER_OPERATION"].Rows[i]["cut_level"].ToString() == "--��ѡ��--")
                    {
                        DsSource.Tables["COVER_OPERATION"].Rows[i]["cut_level"] = "-";
                    }
                    if (DsSource.Tables["COVER_OPERATION"].Rows[i]["close_level"].ToString() == "--��ѡ��--")
                    {
                        DsSource.Tables["COVER_OPERATION"].Rows[i]["close_level"] = "-";
                    }
                    OPERATION = DsSource.Tables["COVER_OPERATION"].Rows[i]["oper_code"].ToString() + "," +
                              DsSource.Tables["COVER_OPERATION"].Rows[i]["oper_date"].ToString() + "," +
                              DsSource.Tables["COVER_OPERATION"].Rows[i]["OPER_NAME"].ToString() + "," +
                              DsSource.Tables["COVER_OPERATION"].Rows[i]["operator"].ToString() + "," +
                              DsSource.Tables["COVER_OPERATION"].Rows[i]["oper_assist1"].ToString() + "," +
                              DsSource.Tables["COVER_OPERATION"].Rows[i]["oper_assist2"].ToString() + "," +
                              DsSource.Tables["COVER_OPERATION"].Rows[i]["anaes_method"].ToString() + "," +
                              DsSource.Tables["COVER_OPERATION"].Rows[i]["cut_level"].ToString() + "," +
                              DsSource.Tables["COVER_OPERATION"].Rows[i]["close_level"].ToString() + "," +
                              DsSource.Tables["COVER_OPERATION"].Rows[i]["ANAESTHETIST"].ToString();
                    list.Add(OPERATION);

                }
                if (count < 5)
                {
                    int count_oT = 4 - count;
                    for (int j = 0; j < count_oT; j++)
                    {
                        OPERATION = "-,,,,,,,,,";
                        list.Add(OPERATION);
                    }
                }
            }
            else
            {
                int count = 0;
                for (int j = 0; j < 4; j++)
                {
                    count++;
                    if (count == 1)
                    {
                        OPERATION = "-,,,,,,,,,";
                        list.Add(OPERATION);
                    }
                    if (count == 2)
                    {
                        OPERATION = "-,,,,,,,,,";
                        list.Add(OPERATION);
                    }
                    if (count == 3)
                    {
                        OPERATION = "-,,,,,,,,,";
                        list.Add(OPERATION);
                    }
                    if (count == 4)
                    {
                        OPERATION = "-,,,,,,,,,";
                        list.Add(OPERATION);
                    }

                }
            }


            //�ַ���ƴ��
            if (list.Count >= 4)
            {
                operation_s = "";
                for (int i = 0; i < list.Count; i++)
                {
                    operation_s = operation_s + list[i].ToString() + ";";
                }
            }

            string AGECount = "";
            if (DsSource.Tables["COVER_INFO"].Rows.Count > 0)
            {
                if (DsSource.Tables["COVER_INFO"].Rows[0]["AGE"].ToString() == "")
                {
                    if (DsSource.Tables["COVER_INFO"].Rows[0]["AGE"].ToString() != "")
                    {
                        AGECount = DsSource.Tables["COVER_INFO"].Rows[0]["AGE"].ToString();
                    }
                    else
                    {
                        AGECount = "";
                    }
                }
                else
                {
                    string age1 = DsSource.Tables["COVER_INFO"].Rows[0]["AGE"].ToString();
                    string age2 = DsSource.Tables["COVER_INFO"].Rows[0]["AGE_UNIT"].ToString();
                    string age3 = DsSource.Tables["COVER_INFO"].Rows[0]["AGE_COUNT"].ToString();
                    AGECount = age1 + age2 + age3;
                }

            }
            string Droomyear = OT;
            string DroomMouth = OT;
            string DroomDay = OT;
            string DroomHour = OT;
            string DroomMinute = OT;
            string DroomCause = OT;

            if (DsSource.Tables["COVER_INSTATUS"].Rows.Count > 0)
            {
                if (DsSource.Tables["COVER_INSTATUS"].Rows[0]["DROOM_CAUSE"].ToString() != "")
                {
                    DroomCause = DsSource.Tables["COVER_INSTATUS"].Rows[0]["DROOM_CAUSE"].ToString();
                }
                else
                {
                    DroomCause = OT;
                }
                if (DsSource.Tables["COVER_INSTATUS"].Rows[0]["DROOM_TIME"].ToString() != "")
                {
                    string Dtime = DsSource.Tables["COVER_INSTATUS"].Rows[0]["DROOM_TIME"].ToString();
                    if (Dtime != "")
                    {
                        DateTime dt = Convert.ToDateTime(Dtime);

                        Droomyear = dt.Year.ToString();
                        DroomMouth = dt.Month.ToString();
                        DroomDay = dt.Day.ToString();
                        DroomHour = dt.Hour.ToString();
                        DroomMinute = dt.Minute.ToString();
                    }
                }
            }
            string TRANS_TIME1 = OT;
            string TRANS_TIME2 = OT;
            string TRANS_TIME3 = OT;
            if (DsSource.Tables["COVER_TRANSFER"].Rows.Count > 0)
            {
                if (DsSource.Tables["COVER_TRANSFER"].Rows[0]["TRANS_TIME"].ToString() != "")
                {
                    string Dtime = DsSource.Tables["COVER_TRANSFER"].Rows[0]["TRANS_TIME"].ToString();
                    if (Dtime != "")
                    {
                        DateTime dt = Convert.ToDateTime(Dtime);

                        TRANS_TIME1 = dt.Year.ToString();
                        TRANS_TIME2 = dt.Month.ToString();
                        TRANS_TIME3 = dt.Day.ToString();
                    }
                }
            }
            #endregion
            if (DsSource != null && DsSource.Tables["COVER_INFO"].Rows.Count > 0 && DsSource.Tables["COVER_INFO"].Rows[0]["INPATIENT_ID"].ToString() != "" && DsSource.Tables["COVER_INFO"].Rows[0]["IN_TIMES"].ToString() != "")
            {
                //if (DsSource.Tables["COVER_INFO"].Rows[0]["FEE_TYPE_O"].ToString() == "")
                //{
                //    DsSource.Tables["COVER_INFO"].Rows[0]["FEE_TYPE_O"] = OT;
                //}
                string Fee_type_o = "";
                if (DsSource.Tables["COVER_INFO"].Rows[0]["FEE_TYPE_O"].ToString() == "")
                {
                    DsSource.Tables["COVER_INFO"].Rows[0]["FEE_TYPE_O"] = OT;
                    //Fee_type_o = OT + "," + OT;
                }
                if (DsSource.Tables["COVER_INFO"].Rows[0]["BORN_PLACE"].ToString() == "")
                {

                    Fee_type_o = OT + "-" + OT;
                }
                else
                {
                    if (DsSource.Tables["COVER_INFO"].Rows[0]["BORN_PLACE"].ToString().Split('-')[0] == "" && DsSource.Tables["COVER_INFO"].Rows[0]["BORN_PLACE"].ToString().Split('-')[1] == "")
                    {
                        Fee_type_o = OT + "-" + OT;
                    }
                    else
                    {
                        Fee_type_o = DsSource.Tables["COVER_INFO"].Rows[0]["BORN_PLACE"].ToString();
                    }

                }
                ReportParameter[] report = new ReportParameter[] { new ReportParameter("inpatient_id", "" + DsSource.Tables["COVER_INFO"].Rows[0]["INPATIENT_ID"] + ""), new ReportParameter("countNum", "" + DsSource.Tables["COVER_INFO"].Rows[0]["IN_TIMES"] + ""), new ReportParameter("payMouny", "" + DsSource.Tables["COVER_INFO"].Rows[0]["FEE_TYPE_O"] + ""), new ReportParameter("Diagnose", zdvals), new ReportParameter("Operation", operation_s), new ReportParameter("Pravice", Fee_type_o),
                               new ReportParameter("Age", AGECount), new ReportParameter("DroomYear", Droomyear), new ReportParameter("DroomMouth", DroomMouth), new ReportParameter("DroomDay", DroomDay), new ReportParameter("DroomHour", DroomHour), new ReportParameter("DroomMinute", DroomMinute), new ReportParameter("DroomCause", DroomCause),
                               new ReportParameter("TRANS_TIME1", TRANS_TIME1), new ReportParameter("TRANS_TIME2", TRANS_TIME2), new ReportParameter("TRANS_TIME3", TRANS_TIME3)};//zdvals,operation_s   + DsSource.Tables["COVER_INFO"].Rows[0]["BORN_PLACE"] + 
                reportviewer1.LocalReport.SetParameters(report);
            }

            //this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"/First_Cases.rdlc";     && DsSource.Tables["COVER_INFO"].Rows[0]["FEE_TYPE_O"].ToString()!=""

            if (DsSource != null)
            {

                #region ���˻�����Ϣ
                if (DsSource.Tables["COVER_INFO"].Rows.Count > 0)
                {//��ϵ
                    if (DsSource.Tables["COVER_INFO"].Rows[0]["RELATION"].ToString() == "")
                    {
                        DsSource.Tables["COVER_INFO"].Rows[0]["RELATION"] = "��";
                    }
                    //���֤
                    if (DsSource.Tables["COVER_INFO"].Rows[0]["CERT_NO"].ToString() == "")
                    {
                        DsSource.Tables["COVER_INFO"].Rows[0]["CERT_NO"] = "-";
                    }
                    //����
                    if (DsSource.Tables["COVER_INFO"].Rows[0]["NATION"].ToString() == "")
                    {
                        DsSource.Tables["COVER_INFO"].Rows[0]["NATION"] = "-";
                    }
                    //����
                    if (DsSource.Tables["COVER_INFO"].Rows[0]["MARRIAGE"].ToString() == "")
                    {
                        DsSource.Tables["COVER_INFO"].Rows[0]["MARRIAGE"] = "-";
                    }
                    //����
                    if (DsSource.Tables["COVER_INFO"].Rows[0]["COUNRTY"].ToString() == "")
                    {
                        DsSource.Tables["COVER_INFO"].Rows[0]["COUNRTY"] = "-";
                    }
                    //������λ����ַ
                    if (DsSource.Tables["COVER_INFO"].Rows[0]["WORK_ORG"].ToString() == "")
                    {
                        DsSource.Tables["COVER_INFO"].Rows[0]["WORK_ORG"] = "-";
                    }
                    //�绰
                    if (DsSource.Tables["COVER_INFO"].Rows[0]["W_PHONE"].ToString() == "")
                    {
                        DsSource.Tables["COVER_INFO"].Rows[0]["W_PHONE"] = "-";
                    }
                    //��������
                    if (DsSource.Tables["COVER_INFO"].Rows[0]["W_POST_CODE"].ToString() == "")
                    {
                        DsSource.Tables["COVER_INFO"].Rows[0]["W_POST_CODE"] = "-";
                    }
                    //���ڵ�ַ
                    if (DsSource.Tables["COVER_INFO"].Rows[0]["HOME_ADDR"].ToString() == "")
                    {
                        DsSource.Tables["COVER_INFO"].Rows[0]["HOME_ADDR"] = "-";
                    }
                    //��������
                    if (DsSource.Tables["COVER_INFO"].Rows[0]["H_POST_CODE"].ToString() == "")
                    {
                        DsSource.Tables["COVER_INFO"].Rows[0]["H_POST_CODE"] = "-";
                    }
                    //��ϵ��
                    if (DsSource.Tables["COVER_INFO"].Rows[0]["RELATION_NAME"].ToString() == "")
                    {
                        DsSource.Tables["COVER_INFO"].Rows[0]["RELATION_NAME"] = "-";
                    }
                    //��ϵ�˵�ַ
                    if (DsSource.Tables["COVER_INFO"].Rows[0]["RELATION_ADDRESS"].ToString() == "")
                    {
                        DsSource.Tables["COVER_INFO"].Rows[0]["RELATION_ADDRESS"] = "-";
                    }
                    //�绰
                    if (DsSource.Tables["COVER_INFO"].Rows[0]["RELATION_PHONE"].ToString() == "")
                    {
                        DsSource.Tables["COVER_INFO"].Rows[0]["RELATION_PHONE"] = "-";
                    }
                }
                #endregion
                if (DsSource.Tables["COVER_INSTATUS"].Rows.Count > 0)
                {
                    #region COVER_INSTATUS��������0
                    //��Ժ�Ʊ�
                    if (DsSource.Tables["COVER_INSTATUS"].Rows[0]["IN_SEC_NAME"].ToString() == "")
                    {
                        DsSource.Tables["COVER_INSTATUS"].Rows[0]["IN_SEC_NAME"] = "-";
                    }
                    //��Ժ����
                    if (DsSource.Tables["COVER_INSTATUS"].Rows[0]["IN_ROOM_NAME"].ToString() == "")
                    {
                        DsSource.Tables["COVER_INSTATUS"].Rows[0]["IN_ROOM_NAME"] = "-";
                    }
                    //��ǰסԺ
                    if (DsSource.Tables["COVER_INSTATUS"].Rows[0]["PREOPERATION_IN_DAYS"].ToString() == "")
                    {
                        DsSource.Tables["COVER_INSTATUS"].Rows[0]["PREOPERATION_IN_DAYS"] = "0";
                    }
                    //��Ժ�Ʊ�
                    if (DsSource.Tables["COVER_INSTATUS"].Rows[0]["LEAVE_SEC_NAME"].ToString() == "")
                    {
                        DsSource.Tables["COVER_INSTATUS"].Rows[0]["LEAVE_SEC_NAME"] = "-";
                    }
                    //��Ժ����
                    if (DsSource.Tables["COVER_INSTATUS"].Rows[0]["LEAVE_ROOM_NAME"].ToString() == "")
                    {
                        DsSource.Tables["COVER_INSTATUS"].Rows[0]["LEAVE_ROOM_NAME"] = "-";
                    }
                    //ʵ��סԺ
                    if (DsSource.Tables["COVER_INSTATUS"].Rows[0]["REAL_IN_DAYS"].ToString() == "")
                    {
                        DsSource.Tables["COVER_INSTATUS"].Rows[0]["REAL_IN_DAYS"] = "-";
                    }
                    //������
                    if (DsSource.Tables["COVER_INSTATUS"].Rows[0]["SEC_DIRE_NAME"].ToString() == "")
                    {
                        DsSource.Tables["COVER_INSTATUS"].Rows[0]["SEC_DIRE_NAME"] = "-";
                    }
                    //��(����)��ҽʦ
                    if (DsSource.Tables["COVER_INSTATUS"].Rows[0]["DIRE_NAME"].ToString() == "")
                    {
                        DsSource.Tables["COVER_INSTATUS"].Rows[0]["DIRE_NAME"] = "-";
                    }
                    //����ҽʦ
                    if (DsSource.Tables["COVER_INSTATUS"].Rows[0]["DUTY_DOC_NAME"].ToString() == "")
                    {
                        DsSource.Tables["COVER_INSTATUS"].Rows[0]["DUTY_DOC_NAME"] = "-";
                    }
                    //סԺҽʦ
                    if (DsSource.Tables["COVER_INSTATUS"].Rows[0]["IN_DOC_NAME"].ToString() == "")
                    {
                        DsSource.Tables["COVER_INSTATUS"].Rows[0]["IN_DOC_NAME"] = "-";
                    }
                    //����ҽʦ
                    if (DsSource.Tables["COVER_INSTATUS"].Rows[0]["STU_DOC_NAME"].ToString() == "")
                    {
                        DsSource.Tables["COVER_INSTATUS"].Rows[0]["STU_DOC_NAME"] = "-";
                    }
                    //�о���ʵϰҽʦ
                    if (DsSource.Tables["COVER_INSTATUS"].Rows[0]["POS_DOC_NAME"].ToString() == "")
                    {
                        DsSource.Tables["COVER_INSTATUS"].Rows[0]["POS_DOC_NAME"] = "-";
                    }
                    //ʵϰҽʦ
                    if (DsSource.Tables["COVER_INSTATUS"].Rows[0]["PRA_DOC_NAME"].ToString() == "")
                    {
                        DsSource.Tables["COVER_INSTATUS"].Rows[0]["PRA_DOC_NAME"] = "-";
                    }

                    //1.��ϸ��
                    if (DsSource.Tables["COVER_INSTATUS"].Rows[0]["TRANS_HYP_AMT"].ToString() == "")
                    {
                        DsSource.Tables["COVER_INSTATUS"].Rows[0]["TRANS_HYP_AMT"] = OT;
                    }
                    //2.ѪС��
                    if (DsSource.Tables["COVER_INSTATUS"].Rows[0]["TRANS_HEM_AMT"].ToString() == "")
                    {
                        DsSource.Tables["COVER_INSTATUS"].Rows[0]["TRANS_HEM_AMT"] = OT;
                    }
                    //3.Ѫ��
                    if (DsSource.Tables["COVER_INSTATUS"].Rows[0]["TRANS_PLA_AMT"].ToString() == "")
                    {
                        DsSource.Tables["COVER_INSTATUS"].Rows[0]["TRANS_PLA_AMT"] = OT;
                    }
                    //4.ȫѪ
                    if (DsSource.Tables["COVER_INSTATUS"].Rows[0]["TRANS_HB_AMT"].ToString() == "")
                    {
                        DsSource.Tables["COVER_INSTATUS"].Rows[0]["TRANS_HB_AMT"] = OT;
                    }
                    //5.����
                    if (DsSource.Tables["COVER_INSTATUS"].Rows[0]["TRANS_OT_AMT"].ToString() == "")
                    {
                        DsSource.Tables["COVER_INSTATUS"].Rows[0]["TRANS_OT_AMT"] = OT;
                    }
                    //���ˡ��ж����ⲿ����
                    if (DsSource.Tables["COVER_INSTATUS"].Rows[0]["DAM_FACTOR_O"].ToString() == "")
                    {
                        DsSource.Tables["COVER_INSTATUS"].Rows[0]["DAM_FACTOR_O"] = OT;
                    }
                    //����ҩ��
                    if (DsSource.Tables["COVER_INSTATUS"].Rows[0]["MEDICINE_ALLERGIC"].ToString() == "")
                    {
                        DsSource.Tables["COVER_INSTATUS"].Rows[0]["MEDICINE_ALLERGIC"] = OT;
                    }
                    //X��
                    if (DsSource.Tables["COVER_INSTATUS"].Rows[0]["INSPECT_NUMBER_X"].ToString() == "")
                    {
                        DsSource.Tables["COVER_INSTATUS"].Rows[0]["INSPECT_NUMBER_X"] = OT;
                    }
                    //CT
                    if (DsSource.Tables["COVER_INSTATUS"].Rows[0]["INSPECT_NUMBER_CT"].ToString() == "")
                    {
                        DsSource.Tables["COVER_INSTATUS"].Rows[0]["INSPECT_NUMBER_CT"] = OT;
                    }
                    //MRT
                    if (DsSource.Tables["COVER_INSTATUS"].Rows[0]["INSPECT_NUMBER_MRT"].ToString() == "")
                    {
                        DsSource.Tables["COVER_INSTATUS"].Rows[0]["INSPECT_NUMBER_MRT"] = OT;
                    }
                    //DST
                    if (DsSource.Tables["COVER_INSTATUS"].Rows[0]["INSPECT_NUMBER_DST"].ToString() == "")
                    {
                        DsSource.Tables["COVER_INSTATUS"].Rows[0]["INSPECT_NUMBER_DST"] = OT;
                    }
                    //����Ա
                    if (DsSource.Tables["COVER_INSTATUS"].Rows[0]["CODER_NAME"].ToString() == "")
                    {
                        DsSource.Tables["COVER_INSTATUS"].Rows[0]["CODER_NAME"] = OT;
                    }
                    //�ʿ�ҽʦ
                    if (DsSource.Tables["COVER_INSTATUS"].Rows[0]["QC_DOCTOR_NAME"].ToString() == "")
                    {
                        DsSource.Tables["COVER_INSTATUS"].Rows[0]["QC_DOCTOR_NAME"] = OT;
                    }
                    //�ʿػ�ʿ
                    if (DsSource.Tables["COVER_INSTATUS"].Rows[0]["QC_NURSE_NAME"].ToString() == "")
                    {
                        DsSource.Tables["COVER_INSTATUS"].Rows[0]["QC_NURSE_NAME"] = OT;
                    }
                    //if (DsSource.Tables["COVER_INSTATUS"].Rows[0]["F_DIAG_UNIT"].ToString() == "")
                    //{
                    //    DsSource.Tables["COVER_INSTATUS"].Rows[0]["F_DIAG_TERM"] = "";
                    //}
                    #endregion
                }
                if (DsSource.Tables["COVER_TRANSFER"].Rows.Count > 0)
                {
                    if (DsSource.Tables["COVER_TRANSFER"].Rows[0]["SECTION_NAME"].ToString() == "")
                    {
                        DsSource.Tables["COVER_TRANSFER"].Rows[0]["SECTION_NAME"] = OT;
                    }
                    if (DsSource.Tables["COVER_TRANSFER"].Rows[0]["ROOM_NAME"].ToString() == "")
                    {
                        DsSource.Tables["COVER_TRANSFER"].Rows[0]["ROOM_NAME"] = OT;
                    }
                    if (DsSource.Tables["COVER_TRANSFER"].Rows[0]["IN_SECTION_NAME"].ToString() == "")
                    {
                        DsSource.Tables["COVER_TRANSFER"].Rows[0]["IN_SECTION_NAME"] = OT;
                    }
                }

                reportviewer1.LocalReport.DataSources.Add(new ReportDataSource("DsReportSource_Cover_Info", DsSource.Tables["COVER_INFO"]));
                reportviewer1.LocalReport.DataSources.Add(new ReportDataSource("DsReportSource_Cover_Instatus", DsSource.Tables["COVER_INSTATUS"]));
                reportviewer1.LocalReport.DataSources.Add(new ReportDataSource("DsReportSource_Cover_Transfer", DsSource.Tables["COVER_TRANSFER"]));

            }

            reportviewer1.RefreshReport();
            reportviewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportviewer1.ZoomMode = ZoomMode.Percent;
            reportviewer1.ZoomPercent = 100;
            #endregion
        }
    }
}
