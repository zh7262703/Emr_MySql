using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;
using System.Collections;
using Bifrost;
using Bifrost_Nurse.UControl;
using Base_Function.MODEL;
using Base_Function.BASE_COMMON;


namespace Base_Function.BLL_NURSE.NBlood_sugarRecord
{
    public partial class UcBlood_SugarRecord : UserControl
    {
        ColumnInfo[] cols = new ColumnInfo[18];
        private string SelectCellVal = "��ֵ";  //��¼��ǰѡ�е�Ԫ���ֵ
        private int RowIndex = 0;    //��¼��Ԫ�������
        private int ColIndex = 0;    //��¼��Ԫ�������
        ArrayList selectTemp = new ArrayList();
        //List<string> list = new List<string>();
        ArrayList lists = new ArrayList();

        public UcBlood_SugarRecord()
        {
            try
            {
                InitializeComponent();
                lblDatePriview.Text = dtpDate.Value.AddDays(-1).ToShortDateString() + "<<";
                lblDateNext.Text = ">>" + dtpDate.Value.AddDays(1).ToShortDateString();
                //ShowDate();
            }
            catch
            {
            }

        }

        private void UcBlood_SugarRecord_Load(object sender, EventArgs e)
        {
            try
            {
                ShowDate();
                lblDatePriview.Text = dtpDate.Value.AddDays(-1).ToShortDateString() + "<<";
                lblDateNext.Text = ">>" + dtpDate.Value.AddDays(1).ToShortDateString();
            }
            catch
            {

            }
        }

         /// <summary>
        /// ��Ԫ��ϲ������� 
        /// </summary>
        private void CellUnit()
        {
            //��Ԫ��ϲ�������         
            flgView[0, 0] = "����";
            flgView[0, 1] = "����";
            flgView[0, 2] = "7:00";
            flgView[0, 3] = "9:30";
            flgView[0, 4] = "11:00";
            flgView[0, 5] = "14:00";
            flgView[0, 6] = "17:00";
            flgView[0, 7] = "20:00";
            flgView[0, 8] = "22:00";
            flgView[0, 9] = "0:00";
            flgView[0, 10] = "03:00";
            flgView[0, 11] = "סԺ��";
            flgView[0, 12] = "�Ʊ�";
            flgView[0, 13] = "����";
            flgView[0, 14] = "��Ժʱ��";
            flgView[0, 15] = "����";
            flgView[0, 16] = "��ӡ";
            flgView[0, 17] = "���˱��";
            flgView.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            flgView.Cols.Fixed = 0;

            C1.Win.C1FlexGrid.CellRange cr;
            cr = flgView.GetCellRange(0, 0, 0, 0);
            cr.Data = "����";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 1, 0, 1);
            cr.Data = "����";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 2, 0, 2);
            cr.Data = "7:00";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 3, 0, 3);
            cr.Data = "9:30";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 4, 0, 4);
            cr.Data = "11:00";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 5, 0, 5);
            cr.Data = "14:00";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 6, 0, 6);
            cr.Data = "17:00";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 7, 0, 7);
            cr.Data = "20:00";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);


            cr = flgView.GetCellRange(0, 8, 0, 8);
            cr.Data = "22:00";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 9, 0, 9);
            cr.Data = "0:00";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 10, 0, 10);
            cr.Data = "03:00";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 11, 0, 11);
            cr.Data = "סԺ��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 12, 0, 12);
            cr.Data = "�Ʊ�";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 13, 0, 13);
            cr.Data = "����";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 14, 0, 14);
            cr.Data = "��Ժʱ��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 15, 0, 15);
            cr.Data = "����";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 16, 0, 16);
            cr.Data = "��ӡ";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);
            cr = flgView.GetCellRange(0, 17, 0, 17);
            cr.Data = "���˱��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);
            flgView.AutoSizeCols();

            for (int i = 0; i < flgView.Cols.Count; i++)
            {
                flgView.Cols[i].Width = 40;
            }

            for (int i = 0; i < flgView.Rows.Count; i++)
            {
                flgView.Rows[i].Height = 25;
            }
            //��סԺ�š��Ʊ𡢲�������Ժʱ�䡢��������
            flgView.Cols[11].Visible = false;
            flgView.Cols[11].AllowEditing = false;

            flgView.Cols[12].Visible = false;
            flgView.Cols[12].AllowEditing = false;

            flgView.Cols[13].Visible = false;
            flgView.Cols[13].AllowEditing = false;

            flgView.Cols[14].Visible = false;
            flgView.Cols[14].AllowEditing = false;

            flgView.Cols[15].Visible = false;
            flgView.Cols[15].AllowEditing = false;
            flgView.Cols[17].Visible = false;
            flgView.Cols[17].AllowEditing = false;

            //������ʾ
            flgView.Cols[0].TextAlign =TextAlignEnum.CenterCenter;
            flgView.Cols[1].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[2].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[3].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[4].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[5].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[6].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[7].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[8].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[9].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[10].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[11].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[12].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[13].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[14].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[15].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[16].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[17].TextAlign = TextAlignEnum.CenterCenter;
        }
        /// <summary>
        /// ��ͷ����
        /// </summary>
        private void SetTable()
        {
            //��Ԫ��ϲ�������           
            flgView.Cols.Count = 18;
            flgView.Cols.Fixed = 0;
            flgView.Rows.Count = 1;
            flgView.Rows.Fixed = 1;


        }

        /// <summary>
        /// ��֤���������0�ľ���ʾΪ��
        /// </summary>
        /// <param Name="str">����</param>
        /// <returns></returns>
        public string isExNot(string str)
        {
            if (str == "0")
            {
                str = "";
            }
            return str;
        }
        /// <summary>
        /// ��ʾ�б�
        /// </summary>
        private void ShowDate()
        {
            try
            {
                flgView.Clear();
                
                SetTable();
                string date = dtpDate.Value.ToString("yyyy-MM-dd");
                //��ʾһ�������Ĳ���
                string PatintInfoSql = @"select a.id,patient_name,case when gender_code=0 then '��' else 'Ů' end gender_code,birthday,a.pid,sick_doctor_id," +
                            @"sick_doctor_name,sick_area_id,sick_area_name,section_id,section_name,a.in_time,a.state,a.sick_bed_id,a.SICK_BED_NO from t_in_patient a  " +
                            @"inner join t_inhospital_action b on a.id=b.patient_id inner join t_sickbedinfo c on a.sick_bed_id=c.bed_id  where  a.SICK_AREA_ID=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " and  b.action_state=4  and  a.SICK_BED_NO is not null and  b.id in (select max(id) from t_inhospital_action group by patient_id) order by sick_bed_no ";
                DataSet dsPatint = App.GetDataSet(PatintInfoSql);

                //��ѯ���е�Ѫ�Ǽ�ⵥ
                //string sql = "select * from v_periphery_bg_record where ����='" + date + "'";
                string sql="select pat.sick_bed_no as ����,pat.patient_name as ��������,ITEM_VALUE as Ѫ��ֵ,"+
                   " to_char(tpg.record_time,'yyyy-mm-dd') as ����,to_char(tpg.record_time,'HH24:mi') as ʱ��,"+
                    "tpg.patient_id as סԺ��,pat.section_name as �Ʊ�,pat.sick_area_name as ����,pat.in_time as ��Ժʱ�� " +
                    " from T_PERIPHERY_BG_RECORD tpg left join T_IN_PATIENT pat on tpg.patient_id=pat.id " +
                   " where pat.sick_bed_no is not null and tpg.record_time is not null and  to_char(tpg.record_time,'yyyy-mm-dd')='" + date + "'";
                     DataSet ds = App.GetDataSet(sql);

                if (dsPatint != null)
                {
                    /*
                    * ��ʾ���еı������Ĳ�����Ϣ
                    */
                    for (int i = 0; i < dsPatint.Tables[0].Rows.Count; i++)
                    {
                        flgView.Rows.Add();
                        Class_ucBlood_SugarRecord temp = new Class_ucBlood_SugarRecord();
                        temp.Bed = dsPatint.Tables[0].Rows[i]["SICK_BED_NO"].ToString();
                        temp.Pid_name = dsPatint.Tables[0].Rows[i]["patient_name"].ToString();
                        temp.Pid = dsPatint.Tables[0].Rows[i]["pid"].ToString();
                        temp.Section_name = dsPatint.Tables[0].Rows[i]["section_name"].ToString();
                        temp.Sickarea_name = dsPatint.Tables[0].Rows[i]["sick_area_name"].ToString();
                        temp.In_time = dsPatint.Tables[0].Rows[i]["in_time"].ToString();
                        temp.Patient_id = dsPatint.Tables[0].Rows[i]["id"].ToString();
                        flgView[1 + i, 0] = temp.Bed;
                        flgView[1 + i, 1] = temp.Pid_name;
                        flgView[1 + i, 11] = temp.Pid;
                        flgView[1 + i, 12] = temp.Section_name;
                        flgView[1 + i, 13] = temp.Sickarea_name;
                        flgView[1 + i, 14] = temp.In_time;
                        flgView[1 + i, 17] = temp.Patient_id;
                        /*
                        * ������������Ӧ�Ĳ��˰�����
                        */
                        if (ds != null)
                        {

                            DataRow[] rows = ds.Tables[0].Select("סԺ��='" + temp.Patient_id + "'");
                            if (rows.Length > 0)
                            {
                                for (int k = 0; k < rows.Length; k++)
                                {
                                    if (rows[k]["ʱ��"].ToString() == "07:00")
                                    {
                                        temp.Values_7 = rows[k]["Ѫ��ֵ"].ToString();
                                    }
                                    else if (rows[k]["ʱ��"].ToString() == "09:30")
                                    {
                                        temp.Values_9 = rows[k]["Ѫ��ֵ"].ToString();
                                    }
                                    else if (rows[k]["ʱ��"].ToString() == "11:00")
                                    {
                                        temp.Values_11 = rows[k]["Ѫ��ֵ"].ToString();
                                    }
                                    else if (rows[k]["ʱ��"].ToString() == "14:00")
                                    {
                                        temp.Values_14 = rows[k]["Ѫ��ֵ"].ToString();
                                    }
                                    else if (rows[k]["ʱ��"].ToString() == "17:00")
                                    {
                                        temp.Values_17 = rows[k]["Ѫ��ֵ"].ToString();
                                    }
                                    else if (rows[k]["ʱ��"].ToString() == "20:00")
                                    {
                                        temp.Values_20 = rows[k]["Ѫ��ֵ"].ToString();
                                    }
                                    else if (rows[k]["ʱ��"].ToString() == "22:00")
                                    {
                                        temp.Values_22 = rows[k]["Ѫ��ֵ"].ToString();
                                    }
                                    else if (rows[k]["ʱ��"].ToString() == "00:00")
                                    {
                                        temp.Values_00 = rows[k]["Ѫ��ֵ"].ToString();
                                    }
                                    else if (rows[k]["ʱ��"].ToString() == "03:00")
                                    {
                                        temp.Values_03 = rows[k]["Ѫ��ֵ"].ToString();
                                    }
                                    if (rows[k]["����"].ToString() != "")
                                    {
                                        temp.Date = rows[k]["����"].ToString();
                                    }
                                }
       
                                flgView[1 + i, 2] = isExNot(temp.Values_7);
                                flgView[1 + i, 3] = isExNot(temp.Values_9);
                                flgView[1 + i, 4] = isExNot(temp.Values_11);
                                flgView[1 + i, 5] = isExNot(temp.Values_14);
                                flgView[1 + i, 6] = isExNot(temp.Values_17);
                                flgView[1 + i, 7] = isExNot(temp.Values_20);
                                flgView[1 + i, 8] = isExNot(temp.Values_22);
                                flgView[1 + i, 9] = isExNot(temp.Values_00);
                                flgView[1 + i, 10] = isExNot(temp.Values_03);
                                flgView[1 + i, 11] = isExNot(temp.Pid);
                                flgView[1 + i, 12] = isExNot(temp.Section_name);
                                flgView[1 + i, 13] = isExNot(temp.Sickarea_name);
                                flgView[1 + i, 14] = isExNot(temp.In_time);
                                flgView[1 + i, 15] = isExNot(temp.Date);
                                flgView[1 + i, 17] = temp.Patient_id;
                            }

                        }
                    }
                    //��Ԫ��ϲ�������
                    CellUnit();
                    for (int i = 1; i < flgView.Rows.Count; i++)
                    {
                        /*
                          * ��ӡͼ��
                          */
                        CellRange rg1 = flgView.GetCellRange(i, 16);
                        rg1.Image = imageList1.Images[0];
                        /*
                         * סԺ�źͲ������������ɫ
                         */
                        CellRange rg = flgView.GetCellRange(i, 0);
                        rg.StyleNew.ForeColor = Color.Blue;

                        CellRange rg2 = flgView.GetCellRange(i, 1);
                        rg2.StyleNew.ForeColor = Color.Blue;
                    }
             
                    //��Ԫ�������Ӵ�
                    flgView.Cols[0].StyleNew.Border.Color = Color.Black;
                    flgView.Cols[1].StyleNew.Border.Color = Color.Black;
                    flgView.Cols[2].StyleNew.Border.Color = Color.Black;
                    flgView.Cols[3].StyleNew.Border.Color = Color.Black;
                    flgView.Cols[4].StyleNew.Border.Color = Color.Black;
                    flgView.Cols[5].StyleNew.Border.Color = Color.Black;
                    flgView.Cols[6].StyleNew.Border.Color = Color.Black;
                    flgView.Cols[7].StyleNew.Border.Color = Color.Black;
                    flgView.Cols[8].StyleNew.Border.Color = Color.Black;
                    flgView.Cols[9].StyleNew.Border.Color = Color.Black;
                    flgView.Cols[10].StyleNew.Border.Color = Color.Black;
                    flgView.Cols[11].StyleNew.Border.Color = Color.Black;
                    flgView.Cols[12].StyleNew.Border.Color = Color.Black;
                    flgView.Cols[13].StyleNew.Border.Color = Color.Black;
                    flgView.Cols[14].StyleNew.Border.Color = Color.Black;
                    flgView.Cols[15].StyleNew.Border.Color = Color.Black;
                    flgView.Cols[16].StyleNew.Border.Color = Color.Black;
                    flgView.Cols[17].StyleNew.Border.Color = Color.Black;
              
                }
               
            }
            catch
            {
            }
        }
        private string SeleteCell(string rows, string cols)
        {
            Class_count[] Ctemp = new Class_count[selectTemp.Count];
            string count_values = "";
            for (int j = 0; j < selectTemp.Count; j++)
            {
                Ctemp[j] = new Class_count();

                Ctemp[j] = (Class_count)selectTemp[j];
                if (Ctemp[j].Rowindex == rows && Ctemp[j].Colsindex == cols)
                {
                    count_values = "0";
                    return count_values;
                }
                //else
                //{
                //    count_values = "";
                //}
            }
            return "";

        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string dssql = "select * from T_PERIPHERY_BG_RECORD where to_char(record_time,'yyyy-MM-dd')='" + dtpDate.Value.ToShortDateString() + "'";
                DataSet ds = App.GetDataSet(dssql);
                string rows = "";//��ǰ��
                string cols = "";//��ǰ��
                ArrayList Sqls = new ArrayList();
                for (int i = 1; i < flgView.Rows.Count; i++)
                {
                    //7��Ѫ�Ǽ�ⵥ
                    string SugarRecord_7 = "";
                    if (flgView[i, 2] != null)
                    {
                        if (flgView[i, 2].ToString().Trim() != "")
                        {
                            SugarRecord_7 = flgView[i, 2].ToString();
                        }
                        else
                        {
                            rows = i.ToString();
                            cols = "2";
                            SugarRecord_7 = SeleteCell(rows, cols);
                        }
                    }
                    
                    string SugarRecord_7time = dtpDate.Value.ToString("yyyy-MM-dd") + " 07:00";

                    //9:30Ѫ�Ǽ�ⵥ
                    string SugarRecord_9 = "";
                    if (flgView[i, 3] != null)
                    {
                        if (flgView[i, 3].ToString().Trim() != "")
                        {
                            SugarRecord_9 = flgView[i, 3].ToString();
                        }
                        else
                        {
                            rows = i.ToString();
                            cols = "3";
                            SugarRecord_9 = SeleteCell(rows, cols);
                        }
                    }
                   
                    string SugarRecord_9time = dtpDate.Value.ToString("yyyy-MM-dd") + " 09:30";

                    //11��Ѫ�Ǽ�ⵥ
                    string SugarRecord_11 = "";
                    if (flgView[i, 4] != null)
                    {
                        if (flgView[i, 4].ToString().Trim() != "")
                        {
                            SugarRecord_11 = flgView[i, 4].ToString();
                        }
                        else
                        {
                            rows = i.ToString();
                            cols = "4";
                            SugarRecord_11 = SeleteCell(rows, cols);
                        }
                    }
                   
                    string SugarRecord_11time = dtpDate.Value.ToString("yyyy-MM-dd") + " 11:00";

                    //14��Ѫ�Ǽ�ⵥ
                    string SugarRecord_14 = "";
                    if (flgView[i, 5] != null)
                    {
                        if (flgView[i, 5].ToString().Trim() != "")
                        {
                            SugarRecord_14 = flgView[i, 5].ToString();
                        }
                        else
                        {
                            rows = i.ToString();
                            cols = "5";
                            SugarRecord_14 = SeleteCell(rows, cols);
                        }
                    }
                 
                    string SugarRecord_14time = dtpDate.Value.ToString("yyyy-MM-dd") + " 14:00";

                    //17��Ѫ�Ǽ�ⵥ
                    string SugarRecord_17 = "";
                    if (flgView[i, 6] != null)
                    {
                        if (flgView[i, 6].ToString().Trim() != "")
                        {
                            SugarRecord_17 = flgView[i, 6].ToString();
                        }
                        else
                        {
                            rows = i.ToString();
                            cols = "6";
                            SugarRecord_17 = SeleteCell(rows, cols);
                        }
                    }
                  
                    string SugarRecord_17time = dtpDate.Value.ToString("yyyy-MM-dd") + " 17:00";

                    //20��Ѫ�Ǽ�ⵥ
                    string SugarRecord_20 = "";
                    if (flgView[i, 7] != null)
                    {
                        if (flgView[i, 7].ToString().Trim() != "")
                        {
                            SugarRecord_20 = flgView[i, 7].ToString();
                        }
                        else
                        {
                            rows = i.ToString();
                            cols = "7";
                            SugarRecord_20 = SeleteCell(rows, cols);
                        }
                    }
                  
                    string SugarRecord_20time = dtpDate.Value.ToString("yyyy-MM-dd") + " 20:00";

                    //22��Ѫ�Ǽ�ⵥ
                    string SugarRecord_22 = "";
                    if (flgView[i, 8] != null)
                    {
                        if (flgView[i, 8].ToString().Trim() != "")
                        {
                            SugarRecord_22 = flgView[i, 8].ToString();
                        }
                        else
                        {
                            rows = i.ToString();
                            cols = "8";
                            SugarRecord_22 = SeleteCell(rows, cols);
                        }
                    }
                  
                    string SugarRecord_22time = dtpDate.Value.ToString("yyyy-MM-dd") + " 22:00";


                    //00��Ѫ�Ǽ�ⵥ
                    string SugarRecord_00 = "";
                    if (flgView[i, 9] != null)
                    {
                        if (flgView[i, 9].ToString().Trim() != "")
                        {
                            SugarRecord_00 = flgView[i, 9].ToString();
                        }
                        else
                        {
                            rows = i.ToString();
                            cols = "9";
                            SugarRecord_00 = SeleteCell(rows, cols);
                        }
                    }
                  
                    string SugarRecord_00time = dtpDate.Value.ToString("yyyy-MM-dd") + " 00:00";

                    //03��Ѫ�Ǽ�ⵥ
                    string SugarRecord_03 = "";
                    if (flgView[i, 10] != null)
                    {
                        if (flgView[i, 10].ToString().Trim() != "")
                        {
                            SugarRecord_03 = flgView[i, 10].ToString();
                        }
                        else
                        {
                            rows = i.ToString();
                            cols = "10";
                            SugarRecord_03 = SeleteCell(rows, cols);
                        }
                    }
                
                    string SugarRecord_03time = dtpDate.Value.ToString("yyyy-MM-dd") + " 03:00";

                    //����סԺ��
                    string Pid = flgView[i, 11].ToString();
                    string Pid_Ids = flgView[i, 17].ToString();

                    string Tempstrs = null;
                    string[] arrs=null;
                    #region 3��
                    string values1 = null;
                    if (SugarRecord_7 != "")
                    {
                        int rowcount = ds.Tables[0].Select("PATIENT_ID='" + Pid_Ids + "' and  record_time='" + SugarRecord_7time + "'").Length;
                        if (rowcount == 0)
                        {
                            DataSet SQl = App.GetDataSet("select ID,PID,ITEM_VALUE,RECORD_TIME,PATIENT_ID from T_PERIPHERY_BG_RECORD where PATIENT_ID=" + Pid_Ids + "");

                            int rowSql = SQl.Tables[0].Select("PATIENT_ID=" + Pid_Ids + " and  RECORD_TIME='" + SugarRecord_7time + "'").Length;
                            if (rowSql == 0)
                            {
                                values1 = "insert into T_PERIPHERY_BG_RECORD(PID,ITEM_VALUE,RECORD_TIME,RECORD_ID,RECORD_NAME,PATIENT_ID)values(" + Pid + "," + SugarRecord_7 + ",to_timestamp('" + SugarRecord_7time + "','syyyy-mm-dd hh24:mi'),'" + App.UserAccount.Account_id + "','" + App.UserAccount.UserInfo.User_name + "',"+Pid_Ids+")";
                                Tempstrs += values1 + "��";

                            }
                            else
                            {
                                values1 = "update T_PERIPHERY_BG_RECORD set ITEM_VALUE=" + SugarRecord_7 + " where PATIENT_ID=" + Pid_Ids + " and RECORD_TIME=to_timestamp('" + SugarRecord_7time + "','syyyy-mm-dd hh24:mi')";
                                Tempstrs += values1 + "��";
                            }

                        }
                        else
                        {
                            values1 = "update T_PERIPHERY_BG_RECORD set ITEM_VALUE=" + SugarRecord_7 + " where PATIENT_ID=" + Pid_Ids + " and RECORD_TIME=to_timestamp('" + SugarRecord_7time + "','syyyy-mm-dd hh24:mi')";
                            Tempstrs += values1 + "��";
                        }
                    }
                    #endregion
                    #region 9��30
                    string values2 = null;
                    if (SugarRecord_9 != "")
                    {
                        int rowcount = ds.Tables[0].Select("PATIENT_ID=" + Pid_Ids + " and record_time='" + SugarRecord_9time + "'").Length;
                        if (rowcount == 0)
                        {
                            DataSet SQl = App.GetDataSet("select ID,PID,ITEM_VALUE,RECORD_TIME,PATIENT_ID,PATIENT_ID from T_PERIPHERY_BG_RECORD where PATIENT_ID=" + Pid_Ids + "");

                            int rowSql = SQl.Tables[0].Select("PATIENT_ID=" + Pid_Ids + " and  RECORD_TIME='" + SugarRecord_9time + "'").Length;
                            if (rowSql == 0)
                            {
                                values2 = "insert into T_PERIPHERY_BG_RECORD(PID,ITEM_VALUE,RECORD_TIME,RECORD_ID,RECORD_NAME,PATIENT_ID)values(" + Pid + "," + SugarRecord_9 + ",to_timestamp('" + SugarRecord_9time + "','syyyy-mm-dd hh24:mi'),'" + App.UserAccount.Account_id + "','" + App.UserAccount.UserInfo.User_name + "'," + Pid_Ids + ")";
                                Tempstrs += values2 + "��";

                            }
                            else
                            {
                                values2 = "update T_PERIPHERY_BG_RECORD set ITEM_VALUE=" + SugarRecord_9 + " where PATIENT_ID=" + Pid_Ids + "  and RECORD_TIME=to_timestamp('" + SugarRecord_9time + "','syyyy-mm-dd hh24:mi')";
                                Tempstrs += values2 + "��";
                            }

                        }
                        else
                        {
                            values2 = "update T_PERIPHERY_BG_RECORD set ITEM_VALUE=" + SugarRecord_9 + " where PATIENT_ID=" + Pid_Ids + "  and RECORD_TIME=to_timestamp('" + SugarRecord_9time + "','syyyy-mm-dd hh24:mi')";
                            Tempstrs += values2 + "��";
                        }
                    }
                    #endregion
                    #region 11��
                    string values3 = null;
                    if (SugarRecord_11 != "")
                    {
                        int rowcount = ds.Tables[0].Select("PATIENT_ID=" + Pid_Ids + " and record_time='" + SugarRecord_11time + "'").Length;
                        if (rowcount == 0)
                        {
                            DataSet SQl = App.GetDataSet("select ID,PID,ITEM_VALUE,RECORD_TIME,PATIENT_ID from T_PERIPHERY_BG_RECORD where PATIENT_ID=" + Pid_Ids + "");

                            int rowSql = SQl.Tables[0].Select("PATIENT_ID=" + Pid_Ids + " and  RECORD_TIME='" + SugarRecord_11time + "'").Length;
                            if (rowSql == 0)
                            {
                                values3 = "insert into T_PERIPHERY_BG_RECORD(PID,ITEM_VALUE,RECORD_TIME,RECORD_ID,RECORD_NAME,PATIENT_ID)values(" + Pid + "," + SugarRecord_11 + ",to_timestamp('" + SugarRecord_11time + "','syyyy-mm-dd hh24:mi'),'" + App.UserAccount.Account_id + "','" + App.UserAccount.UserInfo.User_name + "'," + Pid_Ids + ")";
                                Tempstrs += values3 + "��";

                            }
                            else
                            {
                                values3 = "update T_PERIPHERY_BG_RECORD set ITEM_VALUE=" + SugarRecord_11 + " where PATIENT_ID=" + Pid_Ids + " and RECORD_TIME=to_timestamp('" + SugarRecord_11time + "','syyyy-mm-dd hh24:mi')";
                                Tempstrs += values3 + "��";
                            }

                        }
                        else
                        {
                            values3 = "update T_PERIPHERY_BG_RECORD set ITEM_VALUE=" + SugarRecord_11 + " where PATIENT_ID=" + Pid_Ids + " and RECORD_TIME=to_timestamp('" + SugarRecord_11time + "','syyyy-mm-dd hh24:mi')";
                            Tempstrs += values3 + "��";
                        }
                    }
                    #endregion
                    #region 14��
                    string values4 = null;
                    if (SugarRecord_14 != "")
                    {
                        int rowcount = ds.Tables[0].Select("PATIENT_ID=" + Pid_Ids + " and record_time='" + SugarRecord_14time + "'").Length;
                        if (rowcount == 0)
                        {
                            DataSet SQl = App.GetDataSet("select ID,PID,ITEM_VALUE,RECORD_TIME,PATIENT_ID from T_PERIPHERY_BG_RECORD where PATIENT_ID=" + Pid_Ids + "");

                            int rowSql = SQl.Tables[0].Select("PATIENT_ID=" + Pid_Ids + " and  RECORD_TIME='" + SugarRecord_14time + "'").Length;
                            if (rowSql == 0)
                            {
                                values4 = "insert into T_PERIPHERY_BG_RECORD(PID,ITEM_VALUE,RECORD_TIME,RECORD_ID,RECORD_NAME,PATIENT_ID)values(" + Pid + "," + SugarRecord_14 + ",to_timestamp('" + SugarRecord_14time + "','syyyy-mm-dd hh24:mi'),'" + App.UserAccount.Account_id + "','" + App.UserAccount.UserInfo.User_name + "'," + Pid_Ids + ")";
                                Tempstrs += values4 + "��";

                            }
                            else
                            {
                                values4 = "update T_PERIPHERY_BG_RECORD set ITEM_VALUE=" + SugarRecord_14 + " where PATIENT_ID=" + Pid_Ids + " and RECORD_TIME=to_timestamp('" + SugarRecord_14time + "','syyyy-mm-dd hh24:mi')";
                                Tempstrs += values4 + "��";
                            }

                        }
                        else
                        {
                            values4 = "update T_PERIPHERY_BG_RECORD set ITEM_VALUE=" + SugarRecord_14 + " where PATIENT_ID=" + Pid_Ids + " and RECORD_TIME=to_timestamp('" + SugarRecord_14time + "','syyyy-mm-dd hh24:mi')";
                            Tempstrs += values4 + "��";
                        }
                    }

                    #endregion
                    #region 17��
                    string values5 = null;
                    if (SugarRecord_17 != "")
                    {
                        int rowcount = ds.Tables[0].Select("PATIENT_ID=" + Pid_Ids + " and record_time='" + SugarRecord_17time + "'").Length;
                        if (rowcount == 0)
                        {
                            DataSet SQl = App.GetDataSet("select ID,PID,ITEM_VALUE,RECORD_TIME,PATIENT_ID from T_PERIPHERY_BG_RECORD where PATIENT_ID=" + Pid_Ids + "");

                            int rowSql = SQl.Tables[0].Select("PATIENT_ID=" + Pid_Ids + " and  RECORD_TIME='" + SugarRecord_17time + "'").Length;
                            if (rowSql == 0)
                            {
                                values5 = "insert into T_PERIPHERY_BG_RECORD(PID,ITEM_VALUE,RECORD_TIME,RECORD_ID,RECORD_NAME,PATIENT_ID)values(" + Pid + "," + SugarRecord_17 + ",to_timestamp('" + SugarRecord_17time + "','syyyy-mm-dd hh24:mi'),'" + App.UserAccount.Account_id + "','" + App.UserAccount.UserInfo.User_name + "'," + Pid_Ids + ")";
                                Tempstrs += values5 + "��";

                            }
                            else
                            {
                                values5 = "update T_PERIPHERY_BG_RECORD set ITEM_VALUE=" + SugarRecord_17 + " where PATIENT_ID=" + Pid_Ids + " and RECORD_TIME=to_timestamp('" + SugarRecord_17time + "','syyyy-mm-dd hh24:mi')";
                                Tempstrs += values5 + "��";
                            }

                        }
                        else
                        {
                            values5 = "update T_PERIPHERY_BG_RECORD set ITEM_VALUE=" + SugarRecord_17 + " where PATIENT_ID=" + Pid_Ids + " and RECORD_TIME=to_timestamp('" + SugarRecord_17time + "','syyyy-mm-dd hh24:mi')";
                            Tempstrs += values5 + "��";
                        }
                    }
                    #endregion
                    #region 20��
                    string values6 = null;
                    if (SugarRecord_20 != "")
                    {
                        int rowcount = ds.Tables[0].Select("PATIENT_ID=" + Pid_Ids + " and record_time='" + SugarRecord_20time + "'").Length;
                        if (rowcount == 0)
                        {
                            DataSet SQl = App.GetDataSet("select ID,PID,ITEM_VALUE,RECORD_TIME,PATIENT_ID from T_PERIPHERY_BG_RECORD where PATIENT_ID=" + Pid_Ids + "");

                            int rowSql = SQl.Tables[0].Select("PATIENT_ID=" + Pid_Ids + " and  RECORD_TIME='" + SugarRecord_20time + "'").Length;
                            if (rowSql == 0)
                            {
                                values6 = "insert into T_PERIPHERY_BG_RECORD(PID,ITEM_VALUE,RECORD_TIME,RECORD_ID,RECORD_NAME,PATIENT_ID)values(" + Pid + "," + SugarRecord_20 + ",to_timestamp('" + SugarRecord_20time + "','syyyy-mm-dd hh24:mi'),'" + App.UserAccount.Account_id + "','" + App.UserAccount.UserInfo.User_name + "'," + Pid_Ids + ")";
                                Tempstrs += values6 + "��";

                            }
                            else
                            {
                                values6 = "update T_PERIPHERY_BG_RECORD set ITEM_VALUE=" + SugarRecord_20 + " where PATIENT_ID=" + Pid_Ids + " and RECORD_TIME=to_timestamp('" + SugarRecord_20time + "','syyyy-mm-dd hh24:mi')";
                                Tempstrs += values6 + "��";
                            }

                        }
                        else
                        {
                            values6 = "update T_PERIPHERY_BG_RECORD set ITEM_VALUE=" + SugarRecord_20 + " where PATIENT_ID=" + Pid_Ids + " and RECORD_TIME=to_timestamp('" + SugarRecord_20time + "','syyyy-mm-dd hh24:mi')";
                            Tempstrs += values6 + "��";
                        }
                    }
                    #endregion
                    #region 22��
                    string values7 = null;
                    if (SugarRecord_22 != "")
                    {
                        int rowcount = ds.Tables[0].Select("PATIENT_ID=" + Pid_Ids + " and record_time='" + SugarRecord_22time + "'").Length;
                        if (rowcount == 0)
                        {
                            DataSet SQl = App.GetDataSet("select ID,PID,ITEM_VALUE,RECORD_TIME,PATIENT_ID from T_PERIPHERY_BG_RECORD where PATIENT_ID=" + Pid_Ids + "");

                            int rowSql = SQl.Tables[0].Select("PATIENT_ID=" + Pid_Ids + " and  RECORD_TIME='" + SugarRecord_22time + "'").Length;
                            if (rowSql == 0)
                            {
                                values7 = "insert into T_PERIPHERY_BG_RECORD(PID,ITEM_VALUE,RECORD_TIME,RECORD_ID,RECORD_NAME,PATIENT_ID)values(" + Pid + "," + SugarRecord_22 + ",to_timestamp('" + SugarRecord_22time + "','syyyy-mm-dd hh24:mi'),'" + App.UserAccount.Account_id + "','" + App.UserAccount.UserInfo.User_name + "'," + Pid_Ids + ")";
                                Tempstrs += values7 + "��";

                            }
                            else
                            {
                                values7 = "update T_PERIPHERY_BG_RECORD set ITEM_VALUE=" + SugarRecord_22 + " where PATIENT_ID=" + Pid_Ids + " and RECORD_TIME=to_timestamp('" + SugarRecord_22time + "','syyyy-mm-dd hh24:mi')";
                                Tempstrs += values7 + "��";
                            }

                        }
                        else
                        {
                            values7 = "update T_PERIPHERY_BG_RECORD set ITEM_VALUE=" + SugarRecord_22 + " where PATIENT_ID=" + Pid_Ids + " and RECORD_TIME=to_timestamp('" + SugarRecord_22time + "','syyyy-mm-dd hh24:mi')";
                            Tempstrs += values7 + "��";
                        }
                    }
                    #endregion
                    #region 00��
                    string values8 = null;
                    if (SugarRecord_00 != "")
                    {
                        int rowcount = ds.Tables[0].Select("PATIENT_ID=" + Pid_Ids + " and record_time='" + SugarRecord_00time + "'").Length;
                        if (rowcount == 0)
                        {
                            DataSet SQl = App.GetDataSet("select ID,PID,ITEM_VALUE,RECORD_TIME,PATIENT_ID from T_PERIPHERY_BG_RECORD where PATIENT_ID=" + Pid_Ids + "");

                            int rowSql = SQl.Tables[0].Select("PATIENT_ID=" + Pid_Ids + " and  RECORD_TIME='" + SugarRecord_00time + "'").Length;
                            if (rowSql == 0)
                            {
                                values8 = "insert into T_PERIPHERY_BG_RECORD(PID,ITEM_VALUE,RECORD_TIME,RECORD_ID,RECORD_NAME,PATIENT_ID)values(" + Pid + "," + SugarRecord_00 + ",to_timestamp('" + SugarRecord_00time + "','syyyy-mm-dd hh24:mi'),'" + App.UserAccount.Account_id + "','" + App.UserAccount.UserInfo.User_name + "'," + Pid_Ids + ")";
                                Tempstrs += values8 + "��";

                            }
                            else
                            {
                                values8 = "update T_PERIPHERY_BG_RECORD set ITEM_VALUE=" + SugarRecord_00 + " where PATIENT_ID=" + Pid_Ids + " and RECORD_TIME=to_timestamp('" + SugarRecord_00time + "','syyyy-mm-dd hh24:mi')";
                                Tempstrs += values8 + "��";
                            }

                        }
                        else
                        {
                            values8 = "update T_PERIPHERY_BG_RECORD set ITEM_VALUE=" + SugarRecord_00 + " where PATIENT_ID=" + Pid_Ids + " and RECORD_TIME=to_timestamp('" + SugarRecord_00time + "','syyyy-mm-dd hh24:mi')";
                            Tempstrs += values8 + "��";
                        }
                    }
                    #endregion
                    #region 03��
                    string values9 = null;
                    if (SugarRecord_03 != "")
                    {
                        int rowcount = ds.Tables[0].Select(" PATIENT_ID=" + Pid_Ids + " and record_time='" + SugarRecord_03time + "'").Length;
                        if (rowcount == 0)
                        {
                            DataSet SQl = App.GetDataSet("select ID,PID,ITEM_VALUE,RECORD_TIME,PATIENT_ID from T_PERIPHERY_BG_RECORD where PATIENT_ID=" + Pid_Ids + "");

                            int rowSql = SQl.Tables[0].Select("PATIENT_ID=" + Pid_Ids + " and  RECORD_TIME='" + SugarRecord_03time + "'").Length;
                            if (rowSql == 0)
                            {
                                values9 = "insert into T_PERIPHERY_BG_RECORD(PID,ITEM_VALUE,RECORD_TIME,RECORD_ID,RECORD_NAME,PATIENT_ID)values(" + Pid + "," + SugarRecord_03 + ",to_timestamp('" + SugarRecord_03time + "','syyyy-mm-dd hh24:mi'),'" + App.UserAccount.Account_id + "','" + App.UserAccount.UserInfo.User_name + "'," + Pid_Ids + ")";
                                Tempstrs += values9 + "��";

                            }
                            else
                            {
                                values9 = "update T_PERIPHERY_BG_RECORD set ITEM_VALUE=" + SugarRecord_03 + " where PATIENT_ID=" + Pid_Ids + " and RECORD_TIME=to_timestamp('" + SugarRecord_03time + "','syyyy-mm-dd hh24:mi')";
                                Tempstrs += values9 + "��";
                            }

                        }
                        else
                        {
                            values9 = "update T_PERIPHERY_BG_RECORD set ITEM_VALUE=" + SugarRecord_03 + " where PATIENT_ID=" + Pid_Ids + " and RECORD_TIME=to_timestamp('" + SugarRecord_03time + "','syyyy-mm-dd hh24:mi')";
                            Tempstrs += values9 + "��";
                        }
                    }
                    #endregion

                    if (Tempstrs != null)
                    {
                        arrs = new string[Tempstrs.Split('��').Length];
                        for (int j = 0; j < Tempstrs.Split('��').Length; j++)
                        {
                            if (Tempstrs.Split('��')[j] != "" || Tempstrs.Split('��')[j] != null)
                            {
                                arrs[j] = Tempstrs.Split('��')[j];
                            }
                        }

                        for (int i1 = 0; i1 < arrs.Length; i1++)
                        {
                            if (arrs[i1].Trim() != "")
                            {
                                Sqls.Add(arrs[i1]);
                            }
                        }

                    }
                }

                string[] SqlStrs = new string[Sqls.Count];
                for (int i1 = 0; i1 < Sqls.Count; i1++)
                {
                    SqlStrs[i1] = Sqls[i1].ToString();
                }
                int count = 0;
                try
                {
                    count = App.ExecuteBatch(SqlStrs);
                }
                catch (Exception)
                {

                    throw;
                }
                if (count > 0)
                {
                    App.Msg("�����ɹ���");
                    ShowDate();

                }
                else
                {
                    App.Msg("����ʧ�ܣ�");
                }
            }
            catch
            {

            }
        }
        /// <summary>
        /// ��ӡ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTemperaturePaint_1_Click(object sender, EventArgs e)
        {
            //if (flgView.RowSel > 1)
            //{
            //    for(int j=0;j<flgView.Rows.Count;j++)
            //    {

            //    }
            //}
        }

        private void lblDatePriview_Click(object sender, EventArgs e)
        {
            dtpDate.Value = Convert.ToDateTime(dtpDate.Value.AddDays(-1));
            lblDatePriview.Text = dtpDate.Value.AddDays(-1).ToShortDateString() + "<<";
            //ShowDate();
        }

        private void lblDateNext_Click(object sender, EventArgs e)
        {
            
            dtpDate.Value = Convert.ToDateTime(dtpDate.Value.AddDays(1));
            lblDateNext.Text = ">>" + dtpDate.Value.AddDays(1).ToShortDateString();
            //ShowDate();
        }

        private void flgView_Click(object sender, EventArgs e)
        {
        ��������flgView.Cols[16].AllowEditing = false;
                flgView.Cols[0].AllowEditing = false;
                flgView.Cols[1].AllowEditing = false;
        }
        private void flgView_DoubleClick(object sender, EventArgs e)
        {
            if (flgView.RowSel > 0)
            {
                lists.Clear();
                string Bed = flgView[flgView.RowSel, 0].ToString();
                string Pid_Name = flgView[flgView.RowSel, 1].ToString();
                string PID = flgView[flgView.RowSel, 11].ToString();
                string Section_name = flgView[flgView.RowSel, 12].ToString();
                string Sickarea_name = flgView[flgView.RowSel, 13].ToString();
                string Pid_IDS = flgView[flgView.RowSel, 17].ToString();
                string pids = Class_Blood.GetSelectItemId(PID);
                if (PID != "")
                {
                    if (flgView[0, flgView.ColSel].ToString().Trim() == "��ӡ")
                    {
                        DataSet ds = Class_Blood.GETDaes(pids);
                        frmBlood_Sugar_Record_Print bgprit = new frmBlood_Sugar_Record_Print(ds, null, Bed, Pid_Name, PID, Section_name, Sickarea_name);
                        bgprit.Show();
                    }
                    else
                    {
                        if (flgView.Rows.Count > 0)
                        {
                            if (flgView[flgView.RowSel, flgView.ColSel]!=null)
                            {
                                SelectCellVal = flgView[flgView.RowSel, flgView.ColSel].ToString();
                                if (SelectCellVal != "")
                                {
                                    //RowIndex = 2;
                                    Class_count C_count = new Class_count();
                                    RowIndex = flgView.RowSel;
                                    ColIndex = flgView.ColSel;
                                    C_count.Selectvalues = SelectCellVal;
                                    C_count.Rowindex = RowIndex.ToString();
                                    C_count.Colsindex = ColIndex.ToString();
                                    selectTemp.Add(C_count);

                                }
                            }
                        }
                    }
                 
                }
             

            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {

                ShowDate();
               
                lblDatePriview.Text = dtpDate.Value.AddDays(-1).ToShortDateString() + "<<";
              
                lblDateNext.Text = ">>" + dtpDate.Value.AddDays(1).ToShortDateString();
            }
            catch
            {
            }
        }



    }
}
