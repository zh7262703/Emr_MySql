using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using Bifrost;
using System.Windows.Forms;
using System.Collections;
using C1.Win.C1FlexGrid;
using System.Text.RegularExpressions;
using Base_Function.BASE_COMMON;
using Bifrost_Nurse.UControl;
using Base_Function.MODEL;
using Base_Function.TEMPERATURES;

namespace Base_Function.BLL_NURSE.Tempreture_Management
{
    public partial class ucTemperatureInfo : UserControl
    {
        ColumnInfo[] cols = new ColumnInfo[34];
        ArrayList VitalTemp = new ArrayList();
        ArrayList selectTemp = new ArrayList();
        ArrayList Temperinfo = new ArrayList();
        ArrayList Temperaturelist = new ArrayList();
        List<string> list = new List<string>();
        bool isreflesh = false;
        //�жϵ�ǰ�û������Ƿ����쳣ֵ���쳣true,����true
        bool Flag = false;
        //��ѯ���µ�Ⱥ¼��ص�ֵ
        private string TValue = null;
        //private string Tvaues = null;
        private string SelectCellVal = "��ֵ";  //��¼��ǰѡ�е�Ԫ���ֵ
        private int RowIndex = 0;    //��¼��Ԫ�������
        private int ColIndex = 0;    //��¼��Ԫ�������

        private string startCellVal = null;

        DataSet dst_temper;
        DataSet dssql = new DataSet();

        double dTmax = 0;
        double dTmin = 0;
        int iRmax = 0;
        int iRmin = 0;
        int iPmax = 0;
        int iPmin = 0;
        public ucTemperatureInfo()
        {
            try
            {
                InitializeComponent();


                //ShowDate();

            }
            catch //(Exception ex)
            {
                //throw;
            }
        }
        private bool IsChild = false;
        public void ucTemperatureInfo_Load(object sender, EventArgs e)
        {
            try
            {
                string Sickarea_Id = "";
                try
                {
                    Sickarea_Id=App.UserAccount.CurrentSelectRole.Sickarea_Id.ToString();
                }
                catch
                { }
                //if (Sickarea_Id == "3" || Sickarea_Id == "1")
                //{//���ƺͶ���
                //    radioButton1.Visible = true;
                //    radioButton2.Visible = true;
                //}
                //�ж����¡�������������������ֵ��С
                string sql = "select * from T_TEMPERATURE_MONITORING";
                dssql = App.GetDataSet(sql);
                //if(dssql!=null&&dssql.Tables.Count>0&&dssql.Tables[0].Rows.Count>0)
                //{
                //    DataRow row=dssql.Tables[0].Rows[0];
                //    if (!double.TryParse(row["temperaturemin"].ToString(), out dTmin))
                //        dTmin = 32;
                //    if (!double.TryParse(row["temperaturemax"].ToString(), out dTmax))
                //        dTmax = 45;
                //    if (!int.TryParse(row["breathmin"].ToString(), out iRmin))
                //        iRmin = 10;
                //    if (!int.TryParse(row["breathmax"].ToString(), out iRmax))
                //        iRmax = 30;
                //    if (!int.TryParse(row["pulsemin"].ToString(), out iPmin))
                //        iPmin = 20;
                //    if (!int.TryParse(row["pulsemax"].ToString(), out iPmax))
                //        iPmax = 160;
                //}
                //else
                //{
                //    dTmin = 32;
                //    dTmax = 45;
                //    iRmin = 10;
                //    iRmax = 30;
                //    iPmin = 20;
                //    iPmax = 160;
                //}
                dTmin = 34;
                dTmax = 43;
                iRmin = 1;
                iRmax = 100;
                iPmin = 0;
                iPmax = 190;
                STS();
                //ShowDate();
                CellChangeRedColor();
                lblDatePriview.Text = dtpDate.Value.AddDays(-1).ToShortDateString() + "<<";
                lblDateNext.Text = ">>" + dtpDate.Value.AddDays(1).ToShortDateString();
                //PatientIDList.Clear();
                if (isreflesh)
                {
                    isreflesh = false;
                }
                //if (App.OnErrorTemper == null)
                //{
                //    App.OnErrorTemper += new EventHandler(ErrorTemper);
                //}

            }
            catch //(Exception ex)
            {
                //throw;
            }
        }
        private void ErrorTemper(object sender, EventArgs e)
        {
            string sick = Getsiskarea();
            string date = dtpDate.Value.ToString("yyyy-MM-dd");
            Class_Tempertureinfo[] temps_objs = new Class_Tempertureinfo[Temperinfo.Count];
            for (int i = 0; i < Temperinfo.Count; i++)
            {
                temps_objs[i] = new Class_Tempertureinfo();
                temps_objs[i] = (Class_Tempertureinfo)Temperinfo[i];
            }
            Unusual_Temperture untemps = new Unusual_Temperture(App.ObjectArrayToDataSet(temps_objs), sick, date);
            untemps.Show();
        }
        private void STS()
        {
            string Temper_sql = "select t.patient_id as ��������,to_char(t.measure_time,'yyyy-MM-dd') as ��ʩ����,to_char(measure_time,'HH24:mi') as ��ʩʱ��,t.describe from t_vital_signs t  where  t.describe like '%��Ժ%'";
            //if (IsChild == true)
            //{
            //    Temper_sql = "select t.patient_id as ��������,to_char(t.measure_time,'yyyy-MM-dd') as ��ʩ����,to_char(measure_time,'HH24:mi') as ��ʩʱ��,t.describe from t_child_vital_signs t  where  t.describe like '%��Ժ%'";
            //}
            dst_temper = App.GetDataSet(Temper_sql);
        }

        /// <summary>
        /// ��ǰ�༭���Ļ���ID����
        /// </summary>
        private List<string> PatientIDList = new List<string>();

        /// <summary>
        /// ��Ԫ��ϲ������� 
        /// </summary>
        private void CellUnit()
        {
            return;
            //��Ԫ��ϲ�������           
            flgView[1, 0] = "����";
            flgView[1, 1] = "��������";
            flgView[1, 2] = "T";
            flgView[1, 3] = "P";
            flgView[1, 4] = "R";
            flgView[1, 5] = "T";
            flgView[1, 6] = "P";
            flgView[1, 7] = "R";
            flgView[1, 8] = "T";
            flgView[1, 9] = "P";
            flgView[1, 10] = "R";
            flgView[1, 11] = "T";
            flgView[1, 12] = "P";
            flgView[1, 13] = "R";
            flgView[1, 14] = "���";
            flgView[1, 15] = "����";
            flgView[1, 16] = "T";
            flgView[1, 17] = "P";
            flgView[1, 18] = "R";
            flgView[1, 19] = "T";
            flgView[1, 20] = "P";
            flgView[1, 21] = "R";
            flgView[1, 22] = "���˱��";
            flgView[1, 23] = "����";
            flgView[1, 24] = "���䵥λ";
            flgView[1, 25] = "�Ա�";
            flgView[1, 26] = "�Ʊ�";
            flgView[1, 27] = "����";
            flgView[1, 28] = "��Ժʱ��";
            flgView[1, 29] = "����";
            flgView[1, 30] = "����";
            flgView[1, 31] = "���";
            flgView[1, 32] = "Һ����";
            flgView[1, 33] = "�ܳ���";
            flgView[1, 34] = "סԺ����";
            flgView[1, 35] = "��ӡ";
            flgView[1, 36] = "�ʿ�";
            flgView[1, 37] = "סԺ��";
            flgView[1, 38] = "��";
            flgView[1, 39] = "��";

            flgView.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            flgView.Cols.Fixed = 0;
            //ʱ�����ʾ
            string[] strTimePoint = new string[] { "02:00", "06:00", "10:00", "14:00", "18:00", "22:00" };
            //��Ԫ��ϲ�
            C1.Win.C1FlexGrid.CellRange cr;
            cr = flgView.GetCellRange(0, 0, 1, 0);
            cr.Data = "����";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 1, 1, 1);
            cr.Data = "��������";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 2, 0, 4);
            cr.Data = strTimePoint[0];
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 2, 1, 2);
            cr.Data = "T";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);
            cr = flgView.GetCellRange(1, 3, 1, 3);
            cr.Data = "P";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);
            cr = flgView.GetCellRange(1, 4, 1, 4);
            cr.Data = "R";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 5, 0, 7);
            cr.Data = strTimePoint[1];
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 5, 1, 5);
            cr.Data = "T";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);
            cr = flgView.GetCellRange(1, 6, 1, 6);
            cr.Data = "P";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);
            cr = flgView.GetCellRange(1, 7, 1, 7);
            cr.Data = "R";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);


            cr = flgView.GetCellRange(0, 8, 0, 10);
            cr.Data = strTimePoint[2];
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);


            cr = flgView.GetCellRange(1, 8, 1, 8);
            cr.Data = "T";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);
            cr = flgView.GetCellRange(1, 9, 1, 9);
            cr.Data = "P";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);
            cr = flgView.GetCellRange(1, 10, 1, 10);
            cr.Data = "R";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);


            cr = flgView.GetCellRange(0, 11, 0, 13);
            cr.Data = strTimePoint[3];
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 11, 1, 11);
            cr.Data = "T";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);
            cr = flgView.GetCellRange(1, 12, 1, 12);
            cr.Data = "P";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);
            cr = flgView.GetCellRange(1, 13, 1, 13);
            cr.Data = "R";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);


            cr = flgView.GetCellRange(0, 14, 1, 14);
            cr.Data = "���";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 15, 1, 15);
            cr.Data = "����";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 16, 0, 18);
            cr.Data = strTimePoint[4];
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 16, 1, 16);
            cr.Data = "T";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);
            cr = flgView.GetCellRange(1, 17, 1, 17);
            cr.Data = "P";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);
            cr = flgView.GetCellRange(1, 18, 1, 18);
            cr.Data = "R";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);


            cr = flgView.GetCellRange(0, 19, 0, 21);
            cr.Data = strTimePoint[5];
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 19, 1, 19);
            cr.Data = "T";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);
            cr = flgView.GetCellRange(1, 20, 1, 20);
            cr.Data = "P";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);
            cr = flgView.GetCellRange(1, 21, 1, 21);
            cr.Data = "R";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);


            cr = flgView.GetCellRange(0, 22, 1, 22);
            cr.Data = "סԺ��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 23, 1, 23);
            cr.Data = "����";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 24, 1, 24);
            cr.Data = "���䵥λ";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 25, 1, 25);
            cr.Data = "�Ա�";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 26, 1, 26);
            cr.Data = "�Ʊ�";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 27, 1, 27);
            cr.Data = "����";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 28, 1, 28);
            cr.Data = "��Ժʱ��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 29, 1, 29);
            cr.Data = "����";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 30, 1, 30);
            cr.Data = "����";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 31, 1, 31);
            cr.Data = "���";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 32, 1, 32);
            cr.Data = "Һ����";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 33, 1, 33);
            cr.Data = "�ܳ���";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 34, 1, 34);
            cr.Data = "סԺ����";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 35, 1, 35);
            cr.Data = "��ӡ";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 36, 1, 36);
            cr.Data = "�ʿ�";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 37, 1, 37);
            cr.Data = "���˱��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 38, 0, 39);
            cr.Data = "Ѫѹ";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);




            //��סԺ������

            //flgView.Cols[4].Visible = false;
            //flgView.Cols[4].AllowEditing = false;
            //flgView.Cols[4].Visible = false;
            //flgView.Cols[7].AllowEditing = false;
            //flgView.Cols[7].Visible = false;
            //flgView.Cols[7].AllowEditing = false;
            //flgView.Cols[10].Visible = false;
            //flgView.Cols[10].AllowEditing = false;
            //flgView.Cols[13].Visible = false;
            //flgView.Cols[13].AllowEditing = false;
            //flgView.Cols[17].Visible = false;
            //flgView.Cols[17].AllowEditing = false;
            //flgView.Cols[20].Visible = false;
            //flgView.Cols[20].AllowEditing = false;

            flgView.Cols[22].Visible = false;
            flgView.Cols[22].AllowEditing = false;

            flgView.Cols[23].Visible = false;
            flgView.Cols[23].AllowEditing = false;

            flgView.Cols[24].Visible = false;
            flgView.Cols[24].AllowEditing = false;

            flgView.Cols[25].Visible = false;
            flgView.Cols[25].AllowEditing = false;

            flgView.Cols[26].Visible = false;
            flgView.Cols[26].AllowEditing = false;

            flgView.Cols[27].Visible = false;
            flgView.Cols[27].AllowEditing = false;

            flgView.Cols[28].Visible = false;
            flgView.Cols[28].AllowEditing = false;
            flgView.Cols[37].Visible = false;
            flgView.Cols[37].AllowEditing = false;

            flgView.Cols[37].Visible = false;
            flgView.Cols[37].AllowEditing = false;




            for (int i = 0; i < flgView.Cols.Count; i++)
            {
                flgView.Cols[i].Width = 40;

            }

            flgView.Cols["��Ժ����"].Width = 80;

            for (int i = 0; i < flgView.Rows.Count; i++)
            {
                flgView.Rows[i].Height = 25;
            }

            flgView.Cols[0].AllowEditing = false;
            flgView.Cols[1].AllowEditing = false;

            //������ʾ
            flgView.Cols[0].TextAlign = TextAlignEnum.CenterCenter;
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
            flgView.Cols[18].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[19].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[20].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[21].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[22].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[23].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[24].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[25].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[26].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[27].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[28].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[29].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[30].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[31].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[32].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[33].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[34].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[35].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[36].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[37].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[38].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[39].TextAlign = TextAlignEnum.CenterCenter;
        }

        /// <summary>
        /// ��ͷ����
        /// </summary>
        private void SetTable()
        {
            flgView.Cols.Count = 37;
            flgView.Cols.Fixed = 0;
            flgView.Rows.Count = 2;
            flgView.Rows.Fixed = 2;
            ////��ͷ����
            //cols[0].Name = "����";
            //cols[0].Field = "Bed";
            //cols[0].Index = 1;
            //cols[0].visible = true;
            //flgView[0, 0] = "����";
            //flgView[1, 0] = "����";
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
            else if (str == null)
            {
                str = "";
            }
            return str;
        }

        /// <summary>
        /// ��֤���������0.0�ľ���ʾΪ��
        /// </summary>
        /// <param Name="tmp">��������</param>
        /// <returns></returns>
        public string Istemperature(string tmp)
        {
            if (tmp == "0.0")
            {
                tmp = "";
            }
            return tmp;
        }

        /// <summary>
        /// ��֤�����������������.�Ļ�����Ĭ��ΪһλС��������������Ļ��������.0
        /// </summary>
        /// <param name="newValue">��������</param>
        /// <returns></returns>
        public string Temperature(string newValue)
        {
            if (newValue.ToString().Contains("."))
            {
                int index = newValue.ToString().IndexOf('.');
                newValue = newValue.ToString().Substring(0, index + 2);

            }
            else
            {
                newValue = newValue.ToString() + ".0";
            }
            if (newValue == "0.0")
            {
                newValue = "";
            }
            return newValue;
        }

        DataTable dtInfo = null;
        string strTablename = "t_vital_signs";
        string strTablename2 = "t_temperature_info";
        private void ShowData()
        {

            //if (IsChild)
            //{
            //    strTablename = "t_vital_signs";
            //    strTablename2 = "t_temperature_info";
            //}
            //else
            //{
            //    strTablename = "t_vital_signs";
            //    strTablename2 = "t_temperature_info";
            //}
            StringBuilder sBuilder = new StringBuilder();
            DateTime curdate = dtpDate.Value.Date;
            sBuilder.Append(" select distinct a.sick_bed_no ����,a.medicare_no �ǼǺ� ,a.patient_name ��������,decode(a.gender_code,'0','��',1,'Ů') �Ա�,a.age||a.age_unit ����,in_time ��Ժ����,a.pid סԺ��,a.id ��������");

            //int count = 6;
            //for (int i = 0; i < count; i++)
            //{
            //    string order = string.Empty;
            //    string order2 = string.Empty;
            //    order = Convert.ToString(i * 4 + 2);
            //    if (order.Length == 1)
            //    {
            //        order2 = "0" + order;
            //    }
            //    else
            //    {
            //        order2 = order;
            //    }
            //    sBuilder.Append(",to_char(round(tvs" + order + ".temperature_value,1)) T" + order2 + ",to_char(tvs" + order + ".pulse_value) P" + order2 + ",to_char(tvs" + order + ".breath_value) as \"R" + order2 + "\"");
            //}

            sBuilder.Append(",to_char(round(tvs2.temperature_value,1)) T02,to_char(tvs2.pulse_value) P02,to_char(tvs2.breath_value) as \"R02\"");
            sBuilder.Append(",to_char(round(tvs6.temperature_value,1)) T06,to_char(tvs6.pulse_value) P06,to_char(tvs6.breath_value) as \"R06\"");
            sBuilder.Append(",to_char(round(tvs10.temperature_value,1)) T10,to_char(tvs10.pulse_value) P10,to_char(tvs10.breath_value) as \"R10\"");
            sBuilder.Append(",to_char(round(tvs14.temperature_value,1)) T14,to_char(tvs14.pulse_value) P14,to_char(tvs14.breath_value) as \"R14\"");
            sBuilder.Append(",to_char(round(tvs18.temperature_value,1)) T18,to_char(tvs18.pulse_value) P18,to_char(tvs18.breath_value) as \"R18\"");
            sBuilder.Append(",to_char(round(tvs22.temperature_value,1)) T22,to_char(tvs22.pulse_value) P22,to_char(tvs22.breath_value) as \"R22\"");
            sBuilder.Append(",tti.bp_blood ��,tti.bp_blood ��,tti.in_amount Һ����,tti.empty_value2 ������,tti.out_amount ����,tti.empty_value3 Ż��,tti.shit ���,tti.URINE ����,tti.empty_value4 ����,tti.weight ���� ");
            sBuilder.Append(",'' סԺ���� ");
            sBuilder.Append(",'' ��ӡ");
            sBuilder.Append(" from t_in_patient a");
            sBuilder.Append(" inner join t_inhospital_action b on a.id=b.patient_id and b.next_id=0 and b.action_type<>'����'");
            sBuilder.Append(" left join " + strTablename + " tvs2 on a.id=tvs2.patient_id and to_char(tvs2.measure_time,'yyyy-mm-dd hh24:mi')='" + curdate.AddHours(2).ToString("yyyy-MM-dd HH:mm") + "'");
            sBuilder.Append(" left join " + strTablename + " tvs6 on a.id=tvs6.patient_id and to_char(tvs6.measure_time,'yyyy-mm-dd hh24:mi')='" + curdate.AddHours(6).ToString("yyyy-MM-dd HH:mm") + "'");
            sBuilder.Append(" left join " + strTablename + " tvs10 on a.id=tvs10.patient_id and to_char(tvs10.measure_time,'yyyy-mm-dd hh24:mi')='" + curdate.AddHours(10).ToString("yyyy-MM-dd HH:mm") + "'");
            sBuilder.Append(" left join " + strTablename + " tvs14 on a.id=tvs14.patient_id and to_char(tvs14.measure_time,'yyyy-mm-dd hh24:mi')='" + curdate.AddHours(14).ToString("yyyy-MM-dd HH:mm") + "'");
            sBuilder.Append(" left join " + strTablename + " tvs18 on a.id=tvs18.patient_id and to_char(tvs18.measure_time,'yyyy-mm-dd hh24:mi')='" + curdate.AddHours(18).ToString("yyyy-MM-dd HH:mm") + "'");
            sBuilder.Append(" left join " + strTablename + " tvs22 on a.id=tvs22.patient_id and to_char(tvs22.measure_time,'yyyy-mm-dd hh24:mi')='" + curdate.AddHours(22).ToString("yyyy-MM-dd HH:mm") + "'");
            sBuilder.Append(" left join " + strTablename2 + " tti on a.id=tti.patient_id and to_char(tti.record_time,'yyyy-mm-dd')='" + curdate.AddHours(2).ToString("yyyy-MM-dd") + "'");
            sBuilder.Append(" where a.sick_area_id=" + App.UserAccount.CurrentSelectRole.Sickarea_Id);
            //if (IsChild)
            //{
            //    //sBuilder.Append(" and instr(a.pid,'_',1)>0");
            //    sBuilder.Append(" order by length(a.sick_bed_no),a.sick_bed_no");
            //}
            //else
            //{
            //    //sBuilder.Append("  and instr(a.pid,'_',1)=0");
            //    sBuilder.Append(" order by case when regexp_like(a.sick_bed_no,'^[[:digit:]]+$') then to_number(a.sick_bed_no) else 999 end,a.sick_bed_no");
            //}
            //dtInfo = new DataTable();
            //if (IsChild)
            //{
            //    if (App.UserAccount.CurrentSelectRole.Sickarea_Id == "1")
            //    {//�������������28���Ҳʹ�����������µ�: 2-1��2��
            //        sBuilder.Append(" and trunc(a.in_time)-trunc(a.birthday)<28");
            //    }
            //    else
            //    {
            //        sBuilder.Append(" and instr(a.pid,'_',1)>0"); //a.pid like '%=_%' escape '='
            //    }
            //}
            //else
            //{                
            //    if (App.UserAccount.CurrentSelectRole.Sickarea_Id == "1")
            //    {//�������䣾28��ʹ��һ�����µ�
            //        sBuilder.Append(" and trunc(a.in_time)-trunc(a.birthday)>=28");
            //    }
            //    else
            //    {
            //        sBuilder.Append(" and instr(a.pid,'_',1)=0");
            //    }
            //}

            
            sBuilder.Append(" order by case when regexp_like(a.sick_bed_no,'^[[:digit:]]+$') then to_number(a.sick_bed_no) else 999 end,a.sick_bed_no");
            dtInfo = App.GetDataSet(sBuilder.ToString()).Tables[0];

            string[] ColNames = new string[] { "T02", "T06", "T10", "T14", "T18", "T22", "P02", "P06", "P10", "P14", "P18", "P22", "R02", "R06", "R10", "R14", "R18", "R22" };

            foreach (DataRow row in dtInfo.Rows)
            {
                for (int i = 0; i < ColNames.Length; i++)
                {
                    string strCellValue = row[ColNames[i]].ToString();
                    float f = 0;
                    if (float.TryParse(strCellValue, out f))
                    {
                        if (f == 0)
                        {
                            if (!ColNames[i].ToString().Contains("R"))
                            {
                                row[ColNames[i]] = "";
                            }
                            else
                            {
                                row[ColNames[i]] = "0";
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < dtInfo.Rows.Count; i++)
            {

                string in_time = dtInfo.Rows[i]["��Ժ����"].ToString();
                //string daycout = DataInit.GetInHospitalDaysCount(Convert.ToDateTime(in_time));
                TimeSpan tsp = new TimeSpan();
                tsp = Convert.ToDateTime(App.GetSystemTime().Date) - Convert.ToDateTime(in_time).Date;
                string daycout = tsp.Days + 1 + "��";
                dtInfo.Rows[i]["סԺ����"] = daycout;

            }
            
            flgView.DataSource = dtInfo.DefaultView;


            CellUnit2();
        }




        private void CellUnit2()
        {
            if (dtInfo != null)
            {   
                flgView.MergedRanges.Clear();
                flgView.Rows.Fixed = 2;              
                int startindex = 1;
                flgView.Cols["סԺ��"].Visible = false;
                flgView.Cols["��������"].Visible = false;
                flgView.Cols["��Ժ����"].Visible = false;
                flgView.Cols["�Ա�"].Visible = false;
                flgView.Cols["����"].Visible = false;
                flgView.Cols["�ǼǺ�"].Visible = false;
                flgView.Cols["����"].Visible = false;
                //flgView.Cols["�ܳ���"].Visible = false;
                if (IsChild)
                {
                    flgView.Cols["��"].Visible = false;
                    flgView.Cols["��"].Visible = false;                   
                }
                else 
                {
                    flgView.Cols["������"].Visible = false;
                    flgView.Cols["Ż��"].Visible = false;
                    flgView.Cols["����"].Visible = false;
                }

                flgView.AllowMerging = AllowMergingEnum.Custom;

                C1.Win.C1FlexGrid.CellRange cr;

                for (int i = 0; i < dtInfo.Columns.Count; i++)
                {
                    string strColNmae = dtInfo.Columns[i].ColumnName;
                    if (strColNmae == "����" || strColNmae == "��������")
                    {
                        flgView.Cols[strColNmae].AllowEditing = false;
                    }
                    if (strColNmae.Equals("��������") || strColNmae.Equals("סԺ����"))
                    {
                        flgView.Cols[strColNmae].Width = 60;
                    }
                    else
                    {
                        flgView.Cols[strColNmae].Width = 40;
                    }
                    flgView.Cols[strColNmae].TextAlign = TextAlignEnum.CenterCenter;
                    #region TPR
if (strColNmae.Contains("02"))
                    {
                        string strTemp = strColNmae.Replace("02", "");
                        if (strTemp == "T")
                        {
                            cr = flgView.GetCellRange(0, startindex + i, 0, startindex + i + 2);
                            cr.Data = "02:00";
                            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
                            flgView.MergedRanges.Add(cr);
                        }

                        cr = flgView.GetCellRange(1, startindex + i, flgView.Rows.Fixed - 1, startindex + i);
                        cr.Data = strTemp;
                        cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
                        flgView.MergedRanges.Add(cr);
                    }
                    else if (strColNmae.Contains("06"))
                    {
                        flgView.Cols[strColNmae].Style.BackColor = Color.LightSteelBlue;
                        string strTemp = strColNmae.Replace("06", "");
                        if (strTemp == "T")
                        {
                            cr = flgView.GetCellRange(0, startindex + i, 0, startindex + i + 2);
                            cr.Data = "06:00";
                            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
                            flgView.MergedRanges.Add(cr);
                        }

                        cr = flgView.GetCellRange(1, startindex + i, flgView.Rows.Fixed - 1, startindex + i);
                        cr.Data = strTemp;
                        cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
                        flgView.MergedRanges.Add(cr);
                    }
                    else if (strColNmae.Contains("10"))
                    {
                        string strTemp = strColNmae.Replace("10", "");
                        if (strTemp == "T")
                        {
                            cr = flgView.GetCellRange(0, startindex + i, 0, startindex + i + 2);
                            cr.Data = "10:00";
                            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
                            flgView.MergedRanges.Add(cr);
                        }

                        cr = flgView.GetCellRange(1, startindex + i, flgView.Rows.Fixed - 1, startindex + i);
                        cr.Data = strTemp;
                        cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
                        flgView.MergedRanges.Add(cr);
                    }
                    else if (strColNmae.Contains("14"))
                    {
                        flgView.Cols[strColNmae].Style.BackColor = Color.LightSteelBlue;
                        string strTemp = strColNmae.Replace("14", "");
                        if (strTemp == "T")
                        {
                            cr = flgView.GetCellRange(0, startindex + i, 0, startindex + i + 2);
                            cr.Data = "14:00";
                            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
                            flgView.MergedRanges.Add(cr);
                        }

                        cr = flgView.GetCellRange(1, startindex + i, flgView.Rows.Fixed - 1, startindex + i);
                        cr.Data = strTemp;
                        cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
                        flgView.MergedRanges.Add(cr);
                    }
                    else if (strColNmae.Contains("18"))
                    {
                        string strTemp = strColNmae.Replace("18", "");
                        if (strTemp == "T")
                        {
                            cr = flgView.GetCellRange(0, startindex + i, 0, startindex + i + 2);
                            cr.Data = "18:00";
                            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
                            flgView.MergedRanges.Add(cr);
                        }

                        cr = flgView.GetCellRange(1, startindex + i, flgView.Rows.Fixed - 1, startindex + i);
                        cr.Data = strTemp;
                        cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
                        flgView.MergedRanges.Add(cr);
                    }
                    else if (strColNmae.Contains("22"))
                    {
                        flgView.Cols[strColNmae].Style.BackColor = Color.LightSteelBlue;
                        string strTemp = strColNmae.Replace("22", "");
                        if (strTemp == "T")
                        {
                            cr = flgView.GetCellRange(0, startindex + i, 0, startindex + i + 2);
                            cr.Data = "22:00";
                            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
                            flgView.MergedRanges.Add(cr);
                        }

                        cr = flgView.GetCellRange(1, startindex + i, flgView.Rows.Fixed - 1, startindex + i);
                        cr.Data = strTemp;
                        cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
                        flgView.MergedRanges.Add(cr);
                    }
#endregion
                    else if (strColNmae.Contains("��")|| strColNmae.Contains("��"))
                    {   
                        if (strColNmae.Contains("��"))
                        {
                            cr = flgView.GetCellRange(0, startindex + i, 0, startindex + i + 1);
                            cr.Data = "Ѫ  ѹ";
                            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
                            flgView.MergedRanges.Add(cr);
                        }
                        cr = flgView.GetCellRange(1, startindex + i, flgView.Rows.Fixed - 1, startindex + i);
                        cr.Data = strColNmae;
                        cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
                        flgView.MergedRanges.Add(cr);
                        flgView.Cols[strColNmae].Width = 60;
                    }
                    //else if ((strColNmae.Contains("���") || strColNmae.Contains("����"))&& IsChild)
                    //{
                    //    if (strColNmae.Contains("���"))
                    //    {
                    //        cr = flgView.GetCellRange(0, startindex + i, 0, startindex + i + 1);
                    //        cr.Data = "��  ��";
                    //        cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
                    //        flgView.MergedRanges.Add(cr);
                    //    }
                    //    cr = flgView.GetCellRange(1, startindex + i, flgView.Rows.Fixed - 1, startindex + i);
                    //    if (strColNmae == "���")
                    //        cr.Data = "��״";
                    //    else
                    //        cr.Data = strColNmae;
                    //    cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
                    //    flgView.MergedRanges.Add(cr);
                    //    //flgView.Cols[strColNmae].Width = 60;
                    //}
                    //else if((strColNmae.Contains("����") || strColNmae.Contains("Ż��"))&& IsChild)
                    //{
                    //    if (strColNmae.Contains("����"))
                    //    {
                    //        cr = flgView.GetCellRange(0, startindex + i, 0, startindex + i + 1);
                    //        cr.Data = "��  ��";
                    //        cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
                    //        flgView.MergedRanges.Add(cr);
                    //    }
                    //    cr = flgView.GetCellRange(1, startindex + i, flgView.Rows.Fixed - 1, startindex + i);
                    //    cr.Data = strColNmae;
                    //    cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
                    //    flgView.MergedRanges.Add(cr);
                    //    //flgView.Cols[strColNmae].Width = 60;
                    //}
                    //else if ((strColNmae.Contains("Һ����")|| strColNmae.Contains("������")) && IsChild)
                    //{
                    //    if (strColNmae.Contains("Һ����"))
                    //    {
                    //        cr = flgView.GetCellRange(0, startindex + i, 0, startindex + i + 1);
                    //        cr.Data = "��  ��";
                    //        cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
                    //        flgView.MergedRanges.Add(cr);
                    //    }
                    //    cr = flgView.GetCellRange(1, startindex + i, flgView.Rows.Fixed - 1, startindex + i);
                    //    cr.Data = strColNmae;
                    //    cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
                    //    flgView.MergedRanges.Add(cr);
                    //    //flgView.Cols[strColNmae].Width = 60;
                    //}
                    else if (strColNmae.Contains("Һ����") && !IsChild)
                    {
                        cr = flgView.GetCellRange(0, startindex + i, flgView.Rows.Fixed - 1, startindex + i);
                        if (strColNmae.Contains("Һ����"))
                            cr.Data = "����";
                        cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
                        flgView.MergedRanges.Add(cr);
                    }
                    else
                    {
                        cr = flgView.GetCellRange(0, startindex + i, flgView.Rows.Fixed - 1, startindex + i);
                        cr.Data = strColNmae;
                        cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
                        flgView.MergedRanges.Add(cr);
                    }

                }




                for (int i = 0; i < flgView.Rows.Count; i++)
                {
                    flgView.Rows[i].Height = 25;
                    if (i < flgView.Rows.Fixed)
                    {
                        continue;
                    }
                    TimeSpan sp = Convert.ToDateTime(App.GetSystemTime().Date) - Convert.ToDateTime(flgView[i, "��Ժ����"].ToString()).Date;
                    int pcolindex = flgView.Cols["��ӡ"].SafeIndex;
                    int days = Convert.ToInt32(sp.Days + 1);
                    if (days >= 7)
                    {
                        /*
                         * ��ӡͼ��
                         */
                        //if ((days + 1) % 7 == 0)
                        if (days % 7 == 0)
                        {
                            CellRange rg1 = flgView.GetCellRange(i, pcolindex);
                            rg1.Image = imageList1.Images[3];
                        }
                        else
                        {
                            CellRange rg1 = flgView.GetCellRange(i, pcolindex);
                            rg1.Image = imageList1.Images[0];
                        }
                    }
                    else
                    {
                        CellRange rg1 = flgView.GetCellRange(i, pcolindex);
                        rg1.Image = imageList1.Images[0];
                    }
                    string blood = flgView[i, "��"].ToString();
                    if (blood != "")
                    {
                        string[] bloodArr = blood.Split(',');

                        if (bloodArr.Length > 1)
                        {
                            flgView[i, "��"] = bloodArr[0];
                            flgView[i, "��"] = bloodArr[1];
                        }
                        else
                        {
                            flgView[i, "��"] = "";
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ��ʾ�������
        /// </summary>
        public void ShowDate()
        {
            ShowData();
        }


        /// <summary>
        /// ������¡�����������������С��ҽԺ�������õĲ�������Ԫ�����ɫ��Ϊ��ɫ
        /// </summary>
        public void CellChangeColor()
        {
            if (list.Count > 0)
            {
                foreach (string str in list)
                {
                    int RowSel = Convert.ToInt32(str.Split(',')[0]);
                    int colSel = Convert.ToInt32(str.Split(',')[1]);
                    if (flgView.RowSel > 1)
                    {
                        //��Ԫ���ƺ�ɫ
                        CellRange rg = flgView.GetCellRange(RowSel, colSel);
                        rg.StyleNew.ForeColor = Color.Red;                        

                    }
                }
            }
        }

        /// <summary>
        /// ������¡�����������������С��ҽԺ�������õĲ�������Ԫ�����ɫ��Ϊ��ɫ
        /// </summary>
        public void CellChangeRedColor()
        {
            if (dssql == null || dssql.Tables.Count == 0)
            {
                return;
            }
            for (int i = flgView.Rows.Fixed; i < flgView.Rows.Count; i++)
            {

                for (int j = flgView.Cols.Fixed; j < flgView.Cols.Count; j++)
                {
                    string colname = this.flgView.Cols[j].Name;
                    CellRange rg = flgView.GetCellRange(i, j);
                    //rg.StyleNew.ForeColor = Color.Black;
                    string cvalue = "";
                    if (flgView[i, j] != null)
                    {
                        cvalue = flgView[i, j].ToString().Trim();

                    }
                    if (!App.isNumval(cvalue))
                    {
                        continue;
                    }
                    #region    /*******--�ж����´��ڵ���38

                    if (cvalue != "" && colname.Contains("T"))
                    {
                        if (Convert.ToDouble(cvalue) > Convert.ToDouble(dssql.Tables[0].Rows[0]["TEMPERATUREMAX"].ToString()))
                        {
                            rg.StyleNew.ForeColor = Color.Red;
                        }
                        else if (Convert.ToDouble(cvalue) < Convert.ToDouble(dssql.Tables[0].Rows[0]["TEMPERATUREMIN"].ToString()))
                        {
                            rg.StyleNew.ForeColor = Color.Red;
                        }
                    }
                    #endregion
                    #region /*�ж���������160��С��40*/
                    /*
                                 * �ж���������160��С��40
                                 */
                    if (cvalue != "" && colname.Contains("P"))
                    {
                        if (Convert.ToDouble(cvalue) > Convert.ToInt32(dssql.Tables[0].Rows[0]["PULSEMAX"].ToString()))
                        {
                            rg.StyleNew.ForeColor = Color.Red;
                        }
                        else if (Convert.ToDouble(cvalue) < Convert.ToInt32(dssql.Tables[0].Rows[0]["PULSEMIN"].ToString()))
                        {
                            rg.StyleNew.ForeColor = Color.Red;
                        }
                    }

                    #endregion
                    #region /----***�ж���������30��С��10
                    /*
                                 *�жϺ�������30��С��10 
                                 */
                    if (cvalue != "" && colname.Contains("R"))
                    {
                        if (Convert.ToDouble(cvalue) > Convert.ToInt32(dssql.Tables[0].Rows[0]["BREATHMAX"].ToString()))
                        {
                            rg.StyleNew.ForeColor = Color.Red;
                        }
                        else if (Convert.ToDouble(cvalue) < Convert.ToInt32(dssql.Tables[0].Rows[0]["BREATHMIN"].ToString()))
                        {
                            rg.StyleNew.ForeColor = Color.Red;
                        }
                    }
                    #endregion
                    //������30
                    //if (cvalue != "" && colname.Contains("���"))
                    //{
                    //    if (Convert.ToDouble(cvalue) > Convert.ToUInt32(dssql.Tables[0].Rows[0]["STOOLMAX"].ToString()))
                    //    {
                    //        rg.StyleNew.ForeColor = Color.Red;
                    //    }
                    //}
                }
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            ShowDate();
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (PatientIDList.Count > 0)
            {
                Save();
                PatientIDList.Clear();
            }
            btnSelect_Click(null, null);
        }

        private void Save()
        {
            List<string> Sqls = new List<string>();
            int Err = 0;
            DataSet ds = null;
            ds = App.GetDataSet("select * from " + strTablename + " where to_char(MEASURE_TIME,'yyyy-MM-dd')='" + dtpDate.Text + "'");

            for (int i = flgView.Rows.Fixed; i < flgView.Rows.Count; i++)
            {
                string[] TimePointList = new string[] { "02", "06", "10", "14", "18", "22" };
                string Patient_ID = flgView[i, "��������"].ToString();
                if (!PatientIDList.Exists(delegate(string s) { return s == Patient_ID; }))
                {
                    continue;
                }
                string Pid = flgView[i, "סԺ��"].ToString();
                string BedNo = flgView[i, "����"].ToString();
                string ID = string.Empty;
                for (int j = 0; j < TimePointList.Length; j++)
                {
                    string value1 = null;
                    string strDate = dtpDate.Value.Date.AddHours(int.Parse(TimePointList[j].ToString())).ToString("yyyy-MM-dd HH:mm");
                    string state = "F";
                    string T = string.Empty;
                    string P = string.Empty;
                    string R = string.Empty;

                    T = flgView[i, "T" + TimePointList[j]].ToString();
                    P = flgView[i, "P" + TimePointList[j]].ToString();
                    R = flgView[i, "R" + TimePointList[j]].ToString();
                    //if (string.IsNullOrEmpty(T) && string.IsNullOrEmpty(P) && string.IsNullOrEmpty(R))
                    //{
                    //    continue;
                    //}
                    //else //(Am_Three_value_t == "" || Am_Three_value_p == "" || Am_Three_value_r == "")
                    //{
                    DataRow[] dr_state;
                    if (IsChild)
                    {
                        dr_state = ds.Tables[0].Select("PATIENT_ID=" + Patient_ID + " and  measure_time='" + strDate + "'");
                    }
                    else
                    {
                        dr_state = ds.Tables[0].Select("PATIENT_ID=" + Patient_ID + " and  measure_time='" + strDate + "'");
                    }
                    int rowcount = dr_state.Length;
                    if (rowcount == 0)
                    {
                        //���ݲ��˵�PID���в�ѯ�ж�
                        DataSet SQl = null;

                        SQl = App.GetDataSet("select temperature_value,pulse_value,breath_value,pid,BED_NO,measure_time,TEMPERATURE_BODY,MEASURE_STATE,PATIENT_ID from " + strTablename + " where PATIENT_ID=" + Patient_ID + "");

                        dr_state = SQl.Tables[0].Select("PATIENT_ID=" + Patient_ID + " and  measure_time='" + strDate + "'");
                        int rowSql = dr_state.Length;
                        if (rowSql == 0)
                        {
                            ID = App.GenId().ToString();
                            value1 = "insert into " + strTablename + "(temperature_value,pulse_value,breath_value,pid,BED_NO,measure_time,TEMPERATURE_BODY,MEASURE_STATE,PATIENT_ID,ID)values('" + T + "','" + P + "','" + R + "','" + Pid + "','" + BedNo + "',to_timestamp('" + strDate + "','syyyy-mm-dd hh24:mi'),'" + 0 + "','" + state + "'," + Patient_ID + ",'" + ID + "')";
                            Sqls.Add(value1);
                        }
                        else
                        {
                            //value1 = "update T_VITAL_SIGNS set temperature_value='" + Am_Three_value_t + "',pulse_value='" + Am_Three_value_p + "',breath_value='" + Am_Three_value_r + "' where PATIENT_ID=" + Pid_ID + " and measure_time=to_timestamp('" + Date_Am_Three + "','syyyy-mm-dd hh24:mi')";
                            string isNull = dr_state[0]["MEASURE_STATE"] == null ? "" : dr_state[0]["MEASURE_STATE"].ToString();
                            if (isNull != "")
                            {
                                value1 = "update " + strTablename + " set temperature_value='" + T + "',pulse_value='" + P + "',breath_value='" + R + "' where PATIENT_ID=" + Patient_ID + "  and measure_time=to_timestamp('" + strDate + "','syyyy-mm-dd hh24:mi')";
                            }
                            else
                            {
                                value1 = "update " + strTablename + " set temperature_value='" + T + "',pulse_value='" + P + "',breath_value='" + R + "',MEASURE_STATE='" + state + "' where PATIENT_ID=" + Patient_ID + "  and measure_time=to_timestamp('" + strDate + "','syyyy-mm-dd hh24:mi')";
                            }
                            Sqls.Add(value1);
                        }

                    }
                    else
                    {
                        string isNull = dr_state[0]["MEASURE_STATE"] == null ? "" : dr_state[0]["MEASURE_STATE"].ToString();
                        if (isNull != "")
                        {
                            value1 = "update " + strTablename + " set temperature_value='" + T + "',pulse_value='" + P + "',breath_value='" + R + "' where PATIENT_ID=" + Patient_ID + "  and measure_time=to_timestamp('" + strDate + "','syyyy-mm-dd hh24:mi')";
                        }
                        else
                        {
                            value1 = "update " + strTablename + " set temperature_value='" + T + "',pulse_value='" + P + "',breath_value='" + R + "',MEASURE_STATE='" + state + "' where PATIENT_ID=" + Patient_ID + "  and measure_time=to_timestamp('" + strDate + "','syyyy-mm-dd hh24:mi')";
                        }
                        Sqls.Add(value1);
                    }
                    ///}
                }
                string strBlood = "";
                if (flgView[i, "��"].ToString() != "")
                {
                    strBlood = flgView[i, "��"].ToString() + "," + flgView[i, "��"].ToString();
                }
                else
                {
                    strBlood = flgView[i, "��"].ToString();
                }
                string strUrine = flgView[i, "����"].ToString();
                string strShit = flgView[i, "���"].ToString();
                string empty_value4 = flgView[i, "����"].ToString();
                string empty_value3 = flgView[i, "Ż��"].ToString();
                string empty_value2 = flgView[i, "������"].ToString();
                string strInamount = flgView[i, "Һ����"].ToString();
                string strOutamount = flgView[i, "����"].ToString();
                string value7 = null;
                //if (string.IsNullOrEmpty(strUrine) && string.IsNullOrEmpty(strShit) && string.IsNullOrEmpty(strWeight))
                //{

                //    value7 = "update " + strTablename2 + " set shit='" + strShit + "',WEIGHT='" + strWeight + "',urine='" + 
                //              strUrine + "',urine_state='N',in_amount='" + strInamount + "',out_amount='" + strOutamount + 
                //              "'  where  PATIENT_ID=" + Patient_ID + " and  to_char(record_time,'yyyy-MM-dd')='" + 
                //              dtpDate.Value.Date.ToString("yyyy-MM-dd") + "'";
                //    Sqls.Add(value7);
                //    Err++;
                //    DBControl.ErrorLog("���µ�Ⱥ¼�޸�" + Err + ": �����û�:" + App.UserAccount.UserInfo.User_name, value7);
                //}
                //else
                //{
                //DataSet SQl = App.GetDataSet("select STOOL_COUNT,STOOL_STATE,BED_NO,PID,RECORD_TIME from t_temperature_info  where pid='" + Pid + "' and RECORD_TIME=to_timestamp('" + FecesDate + "','syyyy-mm-dd')");
                //int rowSql = SQl.Tables[0].Select("pid='" + Pid + "' and  RECORD_TIME='" + FecesDate + "'").Length;
                string StoolCount = App.ReadSqlVal("select Count(*) as cot from " + strTablename2 + " where  PATIENT_ID=" + Patient_ID + " and  to_char(record_time,'yyyy-MM-dd')='" + dtpDate.Value.Date.ToString("yyyy-MM-dd") + "'", 0, "cot");
                if (StoolCount == "0")
                {
                    ID = App.GenId().ToString();
                    value7 = "insert into " + strTablename2 + "(bp_blood,EMPTY_VALUE2,SHIT,EMPTY_VALUE4,BED_NO,PID,RECORD_TIME,PATIENT_ID,EMPTY_VALUE3,ID,in_amount,out_amount,urine)values('" + strBlood + "','" + empty_value2 + "','" + strShit + "','" + empty_value4 + "','" + BedNo + "','" + Pid + "',to_timestamp('" +
                             dtpDate.Value.Date.ToString("yyyy-MM-dd HH:mm") + "','syyyy-mm-dd hh24:mi')," +
                             Patient_ID + ",'" + empty_value3 + "','" + ID + "','" + strInamount + "','" + strOutamount + "','" + strUrine + "')";
                    Sqls.Add(value7);
                }
                else
                {
                    value7 = "update " + strTablename2 + " set bp_blood='" + strBlood + "',shit='" + strShit + "',EMPTY_VALUE4='" + empty_value4 + "',EMPTY_VALUE3='" +
                              empty_value3 + "',EMPTY_VALUE2='" + empty_value2 + "',urine_state='N',in_amount='" + strInamount + "',out_amount='" + strOutamount + "',urine='" + strUrine + "' where  PATIENT_ID=" + Patient_ID
                               + " and  to_char(record_time,'yyyy-MM-dd')='" + dtpDate.Value.Date.ToString("yyyy-MM-dd")
                               + "' ";
                    Sqls.Add(value7);
                    Err++;
                    DBControl.ErrorLog("���µ�Ⱥ¼�޸�" + Err + ": �����û�:" + App.UserAccount.UserInfo.User_name, value7);
                }
                //}
            }
            int count = 0;
            try
            {
                count = App.ExecuteBatch(Sqls.ToArray());
            }
            catch (Exception ex)
            {
                if (Err > 0)
                {
                    DBControl.ErrorLog("���µ�Ⱥ¼�޸�ʧ��: �����û�:" + App.UserAccount.UserInfo.User_name, ex.Message);
                }
                throw;
            }
            if (count > 0)
            {
                if (Err > 0)
                {
                    DBControl.ErrorLog("���µ�Ⱥ¼�޸ĳɹ�: �����û�:" + App.UserAccount.UserInfo.User_name, "�����ɹ�");
                    PatientIDList.Clear();
                }
                App.Msg("�����ɹ���");
                selectTemp.Clear();
                isreflesh = true;
                btnSelect_Click(null, null);
            }
            else
            {
                App.Msg("����ʧ�ܣ�");
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
            }
            return "";

        }
        /// <summary>
        /// ��Ԫ��仯����
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void flgView_CellChanged(object sender, RowColEventArgs e)
        {
            if (!isreflesh)
            {
                lastRowindex = flgView.RowSel;
                lastColindex = flgView.ColSel;
                string da_time = dtpDate.Value.ToString("yyyy-MM-dd");

                int a;
                int b;
                if (flgView.RowSel > 1)
                {
                    if (flgView[flgView.RowSel, flgView.ColSel] != null)
                    {
                        if (flgView[flgView.RowSel, flgView.ColSel].ToString().Trim() != "")
                        {
                            if (flgView.RowSel > 1 && flgView.ColSel > 1)
                            {
                                // �жϳ�Ժ��ʾ
                                string PatientId = flgView[flgView.RowSel, "��������"].ToString();
                                DataRow[] rows_temp = dst_temper.Tables[0].Select("��������='" + PatientId + "'");
                                if (rows_temp.Length > 0)
                                {
                                    int colst = flgView.ColSel;
                                    DateTime dtTime = Convert.ToDateTime(rows_temp[0]["��ʩ����"]);

                                    if (Convert.ToDateTime(da_time) > dtTime)
                                    {
                                        if (colst > 1)
                                        {
                                            App.Msg("�����ѳ�Ժ������д���ݣ�");
                                            errorflag = 2;
                                            flgView[lastRowindex, lastColindex] = "";
                                            return;
                                        }
                                    }
                                    else if (Convert.ToDateTime(da_time) == dtTime)
                                    {

                                        if (rows_temp[0]["��ʩʱ��"].ToString() == "02:00")
                                        {

                                            if (colst > 4 && colst != 14)
                                            {
                                                App.Msg("�����ѳ�Ժ������д���ݣ�");
                                                errorflag = 2;
                                                flgView[lastRowindex, lastColindex] = "";
                                                return;
                                            }
                                        }
                                        else if (rows_temp[0]["��ʩʱ��"].ToString() == "06:00")
                                        {

                                            if (colst > 7 && colst != 14)
                                            {
                                                App.Msg("�����ѳ�Ժ������д���ݣ�");
                                                errorflag = 2;
                                                flgView[lastRowindex, lastColindex] = "";
                                                return;
                                            }
                                        }
                                        else if (rows_temp[0]["��ʩʱ��"].ToString() == "10:00")
                                        {

                                            if (colst > 10 && colst != 14)
                                            {
                                                App.Msg("�����ѳ�Ժ������д���ݣ�");
                                                errorflag = 2;
                                                flgView[lastRowindex, lastColindex] = "";
                                                return;
                                            }
                                        }
                                        else if (rows_temp[0]["��ʩʱ��"].ToString() == "14:00")
                                        {
                                            if (colst > 13 && colst != 14)
                                            {
                                                App.Msg("�����ѳ�Ժ������д���ݣ�");
                                                errorflag = 2;
                                                flgView[lastRowindex, lastColindex] = "";
                                                return;
                                            }
                                        }
                                        else if (rows_temp[0]["��ʩʱ��"].ToString() == "18:00")
                                        {
                                            if (colst > 18 || colst != 14)
                                            {
                                                App.Msg("�����ѳ�Ժ������д���ݣ�");
                                                errorflag = 2;
                                                flgView[lastRowindex, lastColindex] = "";
                                                return;
                                            }
                                        }

                                        //else if (rows_temp[0]["��ʩʱ��"].ToString() == "22:00")
                                        //{
                                        //    if (colst > 4 || colst != 14)
                                        //    {
                                        //        App.Msg("�����ѳ�Ժ������д���ݣ�");
                                        //        errorflag = 2;
                                        //        flgView[lastRowindex, lastColindex] = "";
                                        //        return;
                                        //    }
                                        //}
                                    }
                                    //PatientIDList.Add(PatientId); 
                                }
                                //if (flgView[flgView.RowSel, flgView.ColSel].ToString() != "+" 
                                //    && flgView[flgView.RowSel, flgView.ColSel].ToString() != "-"
                                //    && !flgView[flgView.RowSel, flgView.ColSel].ToString().Contains("h")
                                //    && !flgView[flgView.RowSel, flgView.ColSel].ToString().Contains("H"))
                                //{
                                //    if (!App.isNumval(flgView[flgView.RowSel, flgView.ColSel].ToString()))
                                //    {
                                //        App.Msg("�Ƿ��ַ�");
                                //        errorflag = 2;
                                //        flgView[lastRowindex, lastColindex] = "";
                                //        return;
                                //    }
                                //}
                                //if (flgView[1,flgView.ColSel].ToString() == "P")
                                //{

                                //    if (!int.TryParse(flgView[flgView.RowSel,flgView.ColSel].ToString().Trim(),out a))
                                //    {

                                //        App.Msg("����ֻ������������");
                                //        flgView.Focus();
                                //        flgView[lastRowindex,lastColindex] = "";
                                //        return;
                                //    }
                                //}

                                //if (flgView[1,flgView.ColSel].ToString() == "R")
                                //{

                                //    if (!int.TryParse(flgView[flgView.RowSel,flgView.ColSel].ToString().Trim(),out b))
                                //    {

                                //        App.Msg("����ֻ������������");
                                //        //errorflag = 1;
                                //        flgView.Focus();
                                //        flgView[lastRowindex,lastColindex] = "";
                                //        return;
                                //    }
                                //}
                                #region
                                ////�����ж�ֵ
                                //if (flgView[1, flgView.ColSel].ToString() == "T")
                                //{
                                //    #region
                                //    //������µ�ֵ������.�Ļ��ͽ�ȡС��������һλ����������.0
                                //    if (flgView[flgView.RowSel, flgView.ColSel].ToString().Contains("."))
                                //    {
                                //        //��ȡС���������
                                //        int index = flgView[flgView.RowSel, flgView.ColSel].ToString().IndexOf('.');
                                //        //��ȡ��С��������һλС��
                                //        TValue = flgView[flgView.RowSel, flgView.ColSel].ToString().Substring(0, index + 2);
                                //    }
                                //    else
                                //    {
                                //        TValue = flgView[flgView.RowSel, flgView.ColSel].ToString() + ".0";
                                //    }
                                //    flgView[flgView.RowSel, flgView.ColSel] = TValue;
                                //    //flgView[flgView.RowSel, flgView.ColSel] = TValue;

                                //    Tvaues = flgView[flgView.RowSel, flgView.ColSel].ToString();
                                //   // return;
                                //    #endregion
                                //}
                                #endregion
                            }
                        }

                    }

                    /*
                     * ����
                     */
                    if (flgView[1, flgView.ColSel] != null)
                    {
                        if (flgView[1, flgView.ColSel].ToString() == "T")
                        {
                            Flag = TIsvalue();

                        }
                        /*
                         * ����
                         */
                        else if (flgView[1, flgView.ColSel].ToString() == "P")
                        {
                            Flag = PIsvalue();

                        }
                        /*
                        * ����
                        */
                        else if (flgView[1, flgView.ColSel].ToString() == "R")
                        {
                            Flag = RIsvalue();

                        }
                        else if (flgView[1, flgView.ColSel].ToString() == "���")
                        {
                            Flag = Isvalue();

                        }
                    }

                    if (changeCount > 1)
                    {
                        changeCount = 0;

                    }
                    else
                    {
                        if (Flag)
                        {
                            if (flgView[flgView.RowSel, flgView.ColSel] != null)
                            {
                                if (flgView.RowSel > 1 && flgView.ColSel > 1)
                                {
                                    //��Ԫ���ƺ�ɫ
                                    CellRange rg = flgView.GetCellRange(flgView.RowSel, flgView.ColSel);
                                    rg.StyleNew.ForeColor = Color.Red;
                                    //Flag = false;
                                }
                            }
                        }
                        else
                        {
                            CellRange rg = flgView.GetCellRange(flgView.RowSel, flgView.ColSel);
                            rg.StyleNew.ForeColor = Color.Black;
                        }
                    }
                }
            }
        }


        private int changeCount = 0;

        /// <summary>
        /// �ж�����
        /// </summary>
        /// <returns>true �쳣ֵ��false ����ֵ</returns>
        private bool TIsvalue()
        {
            return false; ;
            string sql = "select * from T_TEMPERATURE_MONITORING";
            DataSet dssql = App.GetDataSet(sql);
            float t = 0;
            bool flag = false;
            if (flgView[flgView.RowSel, flgView.ColSel] != null)
            {
                if (flgView[flgView.RowSel, flgView.ColSel].ToString().Trim() != "")
                {
                    //������µ�ֵ������.�Ļ��ͽ�ȡС��������һλ����������.0
                    if (flgView[flgView.RowSel, flgView.ColSel].ToString().Contains("."))
                    {
                        //��ȡС���������
                        int index = flgView[flgView.RowSel, flgView.ColSel].ToString().IndexOf('.');
                        if (index != flgView[flgView.RowSel, flgView.ColSel].ToString().Length - 1)
                        {
                            //��ȡ��С��������һλС��                       
                            TValue = flgView[flgView.RowSel, flgView.ColSel].ToString().Substring(0, index + 2);
                        }
                        else
                        {
                            TValue = flgView[flgView.RowSel, flgView.ColSel].ToString() + "0";
                        }
                    }
                    else
                    {
                        TValue = flgView[flgView.RowSel, flgView.ColSel].ToString() + ".0";
                    }
                    flgView[flgView.RowSel, flgView.ColSel] = TValue;

                    if (changeCount < 1)
                    {
                        if (App.isNumval(flgView[flgView.RowSel, flgView.ColSel].ToString()))
                        {

                            flgView[flgView.RowSel, flgView.ColSel] = TValue;
                            t = Convert.ToSingle(flgView[flgView.RowSel, flgView.ColSel].ToString());
                            if (t < Convert.ToSingle(dssql.Tables[0].Rows[0]["TEMPERATUREMAX"].ToString()))
                            {
                                if (t >= 37.2)
                                {
                                    errorflag = 1;
                                    flag = true;
                                }
                            }
                            else if (t >= Convert.ToSingle(dssql.Tables[0].Rows[0]["TEMPERATUREMAX"].ToString()))
                            {
                                App.MsgErr("�����쳣ֵ");
                                errorflag = 1;
                                flag = true;

                            }

                            else if (t < Convert.ToSingle(dssql.Tables[0].Rows[0]["TEMPERATUREMIN"].ToString()))
                            {

                                App.MsgErr("�����쳣ֵ");
                                errorflag = 1;
                                flag = true;
                            }


                        }

                    }
                    changeCount++;
                }
            }
            return flag;
        }
        /// <summary>
        /// �ж�����
        /// </summary>
        /// <returns>true �쳣ֵ��false ����ֵ</returns>
        private bool PIsvalue()
        {
            return false;
            //��ѯ�������õ��������ֵ����Сֵ
            string sql = "select * from T_TEMPERATURE_MONITORING";
            DataSet dssql = App.GetDataSet(sql);

            float p = 0;
            bool flag = false;
            if (flgView[flgView.RowSel, flgView.ColSel] != null)
            {

                if (flgView[flgView.RowSel, flgView.ColSel].ToString().Trim() != "")
                {
                    if (App.isNumval(flgView[flgView.RowSel, flgView.ColSel].ToString()))
                    {
                        p = Convert.ToSingle(flgView[flgView.RowSel, flgView.ColSel].ToString());
                        if (p > Convert.ToSingle(dssql.Tables[0].Rows[0]["PULSEMAX"].ToString()))
                        {
                            App.Msg("�������ڻ������õ����ֵ" + Convert.ToSingle(dssql.Tables[0].Rows[0]["PULSEMAX"].ToString()) + "��/��");
                            errorflag = 1;
                            flag = true;
                        }
                        else if (p < Convert.ToSingle(dssql.Tables[0].Rows[0]["PULSEMIN"].ToString()))
                        {
                            App.Msg("����С�ڻ������õ���Сֵ" + Convert.ToSingle(dssql.Tables[0].Rows[0]["PULSEMIN"].ToString()) + "��/��");
                            errorflag = 1;
                            flag = true;
                        }
                    }
                }

            }
            return flag;
        }
        /// <summary>
        ///�жϺ���
        /// </summary>
        /// <returns>ture �쳣ֵ��false,����ֵ</returns>
        private bool RIsvalue()
        {
            return false;
            //��ѯ�������õĺ������ֵ����Сֵ
            string sql = "select * from T_TEMPERATURE_MONITORING";
            DataSet dssql = App.GetDataSet(sql);

            bool flag = false;
            float r = 0;
            if (flgView[flgView.RowSel, flgView.ColSel] != null)
            {
                if (flgView[flgView.RowSel, flgView.ColSel].ToString().Trim() != "")
                {
                    if (App.isNumval(flgView[flgView.RowSel, flgView.ColSel].ToString()))
                    {
                        r = Convert.ToSingle(flgView[flgView.RowSel, flgView.ColSel].ToString());
                        if (r > Convert.ToSingle(dssql.Tables[0].Rows[0]["BREATHMAX"].ToString()))
                        {
                            App.Msg("�������ڻ������õ����ֵ" + Convert.ToSingle(dssql.Tables[0].Rows[0]["BREATHMAX"].ToString()) + "��/��");
                            errorflag = 1;
                            flag = true;
                        }
                        else if (r < Convert.ToSingle(dssql.Tables[0].Rows[0]["BREATHMIN"].ToString()))
                        {
                            App.Msg("����С�ڻ������õ���Сֵ" + Convert.ToSingle(dssql.Tables[0].Rows[0]["BREATHMIN"].ToString()) + "��/��");
                            errorflag = 1;
                            flag = true;
                        }

                    }
                }

            }
            return flag;
        }
        /// <summary>
        ///�жϴ��
        /// </summary>
        /// <returns>ture �쳣ֵ��false,����ֵ</returns>
        private bool Isvalue()
        {
            return false;
            //��ѯ�������õĺ������ֵ����Сֵ
            string sql = "select * from T_TEMPERATURE_MONITORING";
            DataSet dssql = App.GetDataSet(sql);
            bool flag = false;
            float Excu = 0;
            if (flgView[flgView.RowSel, flgView.ColSel] != null)
            {
                if (flgView[flgView.RowSel, flgView.ColSel].ToString().Trim() != "")
                {
                    if (App.isNumval(flgView[flgView.RowSel, flgView.ColSel].ToString()))
                    {
                        Excu = Convert.ToSingle(flgView[flgView.RowSel, flgView.ColSel].ToString());
                        if (Excu > Convert.ToSingle(dssql.Tables[0].Rows[0]["STOOLMAX"].ToString()))
                        {
                            App.Msg("�����ڻ������õ����ֵ" + Convert.ToSingle(dssql.Tables[0].Rows[0]["STOOLMAX"].ToString()) + "��/��");
                            errorflag = 1;
                            flag = true;
                        }

                    }
                }

            }
            return flag;
        }


        /// <summary>
        /// ��һ��
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void lblDatePriview_Click(object sender, EventArgs e)
        {
            dtpDate.Value = Convert.ToDateTime(dtpDate.Value.AddDays(-1));
            lblDatePriview.Text = dtpDate.Value.AddDays(-1).ToShortDateString() + "<<";
            if (App.GetSystemTime().Date > dtpDate.Value.Date)
            {
                lblDateNext.Visible = true;
            }
        }

        /// <summary>
        /// ��һ��
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void lblDateNext_Click(object sender, EventArgs e)
        {
            dtpDate.Value = Convert.ToDateTime(dtpDate.Value.AddDays(1));
            lblDateNext.Text = ">>" + dtpDate.Value.AddDays(1).ToShortDateString();
            if (App.GetSystemTime().Date == dtpDate.Value.Date)
            {
                lblDateNext.Visible = false;
            }
        }

        public void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            if (PatientIDList.Count > 0)
            {
                App.Msg("�������޸ģ����ȱ��棡");
                return;
            }
            lblDatePriview.Text = dtpDate.Value.AddDays(-1).ToShortDateString() + "<<";
            lblDateNext.Text = ">>" + dtpDate.Value.AddDays(1).ToShortDateString();
            isreflesh = true;
            btnSelect_Click(sender, e);
            PatientIDList.Clear();
        }

        int lastRowindex = 0;
        int lastColindex = 0;
        int errorflag = 0; //0 ����,1 ������ֵ,2 �Ƿ��ַ�
        private void flgView_KeyDown(object sender, KeyEventArgs e)
        {
            errorflag = 0;
        }

        private void flgView_KeyUp(object sender, KeyEventArgs e)
        {
            if (errorflag == 1)
            {

                flgView.RowSel = lastRowindex;
                flgView.ColSel = lastColindex;
                flgView.Select(lastRowindex, lastColindex);
                errorflag = 0;
            }
        }
        /// <summary>
        /// �ж������Ƿ���������ͬ
        /// </summary>
        private string ShowSelectSql(string pid, string date)
        {
            string SQl = "select * from T_VITAL_SIGNS where pid='" + pid + "' and measure_time='" + date + "'";
            DataSet selectSql = App.GetDataSet(SQl);
            return selectSql.ToString();
        }

        private string pid;            //����PID
        private string medicare_no;    //���˵ǼǺ�
        private string bed_no;         //���˴���
        private string pidname;        //��������
        private string gender_code;   //�����Ա�
        private string age;              //��������
        private string section_name;  //������������
        private string sick_name;     //������������
        private string in_time;       //������Ժʱ��
        private string date;          //��ǰʱ��
        private string PID_IDS;//��������
        /// <summary>
        /// ˫������������ת��������Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flgView_DoubleClick(object sender, EventArgs e)
        {
            if (flgView.RowSel > 1)
            {
                pid = flgView[flgView.RowSel, "סԺ��"].ToString();
                bed_no = flgView[flgView.RowSel, "����"].ToString();
                pidname = flgView[flgView.RowSel, "��������"].ToString();
                gender_code = flgView[flgView.RowSel, "�Ա�"].ToString();
                age = flgView[flgView.RowSel, "����"].ToString();
                medicare_no = flgView[flgView.RowSel, "�ǼǺ�"].ToString();
                section_name = App.UserAccount.CurrentSelectRole.Sickarea_name;
                sick_name = App.UserAccount.CurrentSelectRole.Sickarea_name;

                if (string.IsNullOrEmpty(section_name))
                {
                    string sickid = App.UserAccount.CurrentSelectRole.Sickarea_Id;
                    section_name = App.ReadSqlVal("select b.section_name  from t_section_area a inner join t_sectioninfo b on a.sid=b.sid where a.said='" + sickid + "'", 0, "section_name");
                }
                in_time = flgView[flgView.RowSel, "��Ժ����"].ToString();
                date = dtpDate.Value.ToString("yyyy-MM-dd");
                PID_IDS = flgView[flgView.RowSel, "��������"].ToString();

                InPatientInfo currentPatient = DataInit.GetInpatientInfoByPid(PID_IDS);
                /*
                 * ˫��������������������˵ĵ�¼�༭ҳ��
                 */
                if (flgView[1, flgView.ColSel].ToString().Trim() == "��������")
                {
                    if (PatientIDList.Count > 0)
                    {
                        App.Msg("�������޸ģ��뱣����ٽ��룡");
                        return;
                    }
                    //if (App.Ask("��ǰȺ¼ҳ��������Ƿ񱣴���?δ������㡰�񡱺󱣴��ٽ���! "))
                    //{
                    ucOneHospetal frm = new ucOneHospetal(currentPatient);////this, pid, medicare_no, bed_no, pidname, gender_code, age, section_name, sick_name, in_time, dtpDate.Value, PID_IDS);
                    frm.Text = frm.Text + "(" + pidname + " ���ţ�" + bed_no + ")";
                    //frm.Dock = DockStyle.Fill;
                    //frm.MdiParent = App.ParentForm;
                    //App.ButtonStytle(frm, true);
                    App.UsControlStyle(frm);
                    App.AddNewBusUcControl(frm, pidname + "-���µ���Ϣ");
                    btnSelect_Click(sender, e);
                    //}

                }
                /*
                * ��ӡ
                */
                else if (flgView[1, flgView.ColSel].ToString().Trim() == "��ӡ")
                {
                    DateTime inDatetime = Convert.ToDateTime(Convert.ToDateTime(this.in_time).ToString("yyyy-MM-dd"));
                    DateTime today = Convert.ToDateTime(Convert.ToDateTime(this.date).ToString("yyyy-MM-dd"));// Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));
                    if (inDatetime.CompareTo(today) > 0)
                    {
                        App.Msg("��Ժʱ��" + Convert.ToDateTime(this.in_time).ToString("yyyy-MM-dd") + "���ڽ���ʱ��" + Convert.ToDateTime(this.date).ToString("yyyy-MM-dd") + "");
                        return;
                    }
                    string pids = GetSelectItemId(pid);
                    frmTemperPrint tem = new frmTemperPrint(currentPatient);//pid, medicare_no, PID_IDS, bed_no, pidname, gender_code, age, section_name, sick_name, in_time);
                    tem.ShowDialog();
                    btnSelect_Click(sender, e);
                }
                else
                {
                    if (flgView.Rows.Count > 2)
                    {
                        if (flgView[flgView.RowSel, flgView.ColSel] != null)
                        {
                            SelectCellVal = flgView[flgView.RowSel, flgView.ColSel].ToString();
                            if (SelectCellVal != "")
                            {
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
        private string GetSelectItemId(string pid)
        {
            string Sql = "select PID from T_IN_PATIENT  where ID ='" + pid + "'";
            string ID = App.ReadSqlVal(Sql, 0, "PID");
            return ID;
        }
        /// <summary>
        /// ��ӡ��¼���µ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTemperaturePaint_1_Click(object sender, EventArgs e)
        {
            this.flgView.PrintParameters.PrintDocument.DefaultPageSettings.Landscape = true;
            this.flgView.Cols["��ӡ"].Visible = false;
            //this.flgView.PrintParameters.PrintDocument.PrintPage+=new System.Drawing.Printing.PrintPageEventHandler(PrintDocument_PrintPage);
            this.flgView.PrintGrid("��ӡ��¼���µ�", C1.Win.C1FlexGrid.PrintGridFlags.ShowPreviewDialog);
            this.flgView.Cols["��ӡ"].Visible = true;
        }

        private void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }


        /// <summary>
        /// ��ӡ�쳣���µ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExTemperaturePaint_1_Click(object sender, EventArgs e)
        {

            this.flgView.PrintParameters.PrintDocument.DefaultPageSettings.Landscape = true;
            this.flgView.Cols["��ӡ"].Visible = false;
            for (int i = flgView.Rows.Fixed; i < flgView.Rows.Count; i++)
            {
                flgView.Rows[i].Visible = IsHigherTemperature(flgView.Rows[i]);
            }
            this.flgView.PrintGrid("��ӡ��¼���µ�", C1.Win.C1FlexGrid.PrintGridFlags.ShowPreviewDialog);
            this.flgView.Cols["��ӡ"].Visible = true;

            for (int i = flgView.Rows.Fixed; i < flgView.Rows.Count; i++)
            {
                flgView.Rows[i].Visible = true;
            }
            //string sick = Getsiskarea();
            //string date = dtpDate.Value.ToString("yyyy-MM-dd");
            //Class_Tempertureinfo[] temps_objs = new Class_Tempertureinfo[Temperinfo.Count];
            //for (int i = 0;i < Temperinfo.Count;i++)
            //{
            //    temps_objs[i] = new Class_Tempertureinfo();
            //    temps_objs[i] = (Class_Tempertureinfo)Temperinfo[i];
            //}
            //Unusual_Temperture untemps = new Unusual_Temperture(App.ObjectArrayToDataSet(temps_objs),sick,date);
            //untemps.Show();
        }

        /// <summary>
        /// ���ݵ�ǰ�˻��Ĳ���id�õ���������
        /// </summary>
        /// <returns></returns>
        private string Getsiskarea()
        {
            string sql = "select sick_area_name from T_IN_PATIENT where SICK_AREA_ID=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + "";
            string sickname = App.ReadSqlVal(sql, 0, "sick_area_name");
            return sickname;
        }

        private bool IsHigherTemperature(C1.Win.C1FlexGrid.Row row)
        {
            for (int i = 0; i < 6; i++)
            {
                string strValue = string.Empty;
                string strName = (2 + i * 4).ToString();
                if (strName.Length == 1)
                {
                    strName = "0" + strName;
                }
                strValue = row["T" + strName].ToString();

                float f = 0;

                if (float.TryParse(strValue, out f))
                {
                    if (f > 38)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void flgView_Click(object sender, EventArgs e)
        {

            #region

            //if (errorflag==1)
            //{
            //    if (flgView[flgView.RowSel, flgView.ColSel].ToString().Trim() != "")
            //    {
            //        if (flgView.RowSel > 1 && flgView.ColSel > 1)
            //        {
            //            //��Ԫ���ƺ�ɫ
            //            CellRange rg = flgView.GetCellRange(flgView.RowSel, flgView.ColSel);
            //            rg.StyleNew.ForeColor = Color.Red;
            //        }
            //    }
            //}
            //else
            //{
            //    CellRange rg = flgView.GetCellRange(flgView.RowSel, flgView.ColSel);
            //    rg.StyleNew.ForeColor = Color.Black;
            //}
            #endregion
            if (flgView.RowSel > 2)
            {
                CellRange rg = flgView.GetCellRange(flgView.RowSel, flgView.ColSel);
                //rg.StyleNew.ForeColor = Color.Black;
                if (flgView[flgView.RowSel, flgView.ColSel] == null)
                {
                    rg.StyleNew.ForeColor = Color.Black;
                }
                Color color = rg.StyleNew.ForeColor;
                if (color == Color.Red)
                {
                    rg.StyleNew.ForeColor = Color.Red;
                }
                else if (color == Color.Blue)
                {
                    rg.StyleNew.ForeColor = Color.Blue;
                }
                else
                {
                    rg.StyleNew.ForeColor = Color.Black;
                }
            }

            //flgView.Cols[31].AllowEditing = false;
            //flgView.Cols[32].AllowEditing = false;
        }



        private void flgView_AfterDataRefresh(object sender, ListChangedEventArgs e)
        {
            //CellChangeColor();
            CellChangeRedColor();
        }

        private void flgView_AfterSelChange(object sender, RangeEventArgs e)
        {
            try
            {
                if (flgView.RowSel > 2)
                {
                    CellRange rg = flgView.GetCellRange(flgView.RowSel, flgView.ColSel);
                    rg.StyleNew.ForeColor = Color.Black;
                }
            }
            catch
            { }
        }

        private void flgView_LeaveCell(object sender, EventArgs e)
        {

            //if (this.flgView.Row >= 0 && this.flgView.Col >= 0 && this.flgView[this.flgView.Row, this.flgView.Col] != null)
            //{
            //    string cellvalue = this.flgView[this.flgView.Row, this.flgView.Col].ToString();
            //    if (!string.IsNullOrEmpty(cellvalue))
            //    {
            //        string colname = this.flgView.Cols[this.flgView.Col].Name;
            //        string patientid = this.flgView[this.flgView.Row, "��������"].ToString();
            //        if (colname.Contains("T"))
            //        {
            //            float f = 0;
            //            if (!float.TryParse(cellvalue, out f))
            //            {
            //                App.Msg("�������±���Ϊ��ֵ��!");
            //                this.flgView[this.flgView.Row, this.flgView.Col] = "";
            //                return;
            //            }
            //            if (!PatientIDList.Exists(delegate(string s) { return s == patientid; }))
            //            {
            //                PatientIDList.Add(patientid);
            //            }
            //        }
            //        else if (colname.Contains("R"))
            //        {
            //            int i = 0;
            //            if (!int.TryParse(cellvalue, out i))
            //            {
            //                App.Msg("���ߺ�������Ϊ����!");
            //                this.flgView[this.flgView.Row, this.flgView.Col] = "";
            //                return;
            //            }
            //            if (!PatientIDList.Exists(delegate(string s) { return s == patientid; }))
            //            {
            //                PatientIDList.Add(patientid);
            //            }
            //        }
            //        else if (colname.Contains("P"))
            //        {
            //            int i = 0;
            //            if (!int.TryParse(cellvalue, out i))
            //            {
            //                App.Msg("������������Ϊ����!");
            //                this.flgView[this.flgView.Row, this.flgView.Col] = "";
            //                return;
            //            }
            //            if (!PatientIDList.Exists(delegate(string s) { return s == patientid; }))
            //            {
            //                PatientIDList.Add(patientid);
            //            }
            //        }
            //        else if (colname.Contains("���") || colname.Contains("����") || colname.Contains("����"))
            //        {
            //            if (!PatientIDList.Exists(delegate(string s) { return s == patientid; }))
            //            {
            //                PatientIDList.Add(patientid);
            //            }
            //        }
            //    }
            //    else
            //    {
            //        string colname = this.flgView.Cols[this.flgView.Col].Name;
            //        string patientid = this.flgView[this.flgView.Row, "��������"].ToString();
            //        PatientIDList.Add(patientid);
            //    }
            //}
            //CellChangeRedColor();
        }

        private void btnTemperRemind_Click(object sender, EventArgs e)
        {
            TemperatureRemindFrm frm = new TemperatureRemindFrm();
            frm.Show();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                this.IsChild = false;
            }
            else
            {
                this.IsChild = true;
            }
            //btnSelect_Click(sender, e);
        }
      
        private void flgView_StartEdit(object sender, RowColEventArgs e)
        {
            startCellVal = null;
            if (this.flgView.Row >= 0 && this.flgView.Col >= 0 && this.flgView[this.flgView.Row, this.flgView.Col] != null)
            {
                startCellVal = this.flgView[this.flgView.Row, this.flgView.Col].ToString();       
            }
        }

        private void flgView_AfterEdit(object sender, RowColEventArgs e)
        {
            //if (this.flgView.Row >= 0 && this.flgView.Col >= 0 && this.flgView[this.flgView.Row, this.flgView.Col] != null)
            //{
            //    string currentVal = this.flgView[this.flgView.Row, this.flgView.Col].ToString();
            //    if (currentVal == startCellVal)
            //    {
            //        string patientid = this.flgView[this.flgView.Row, "��������"].ToString();
            //        PatientIDList.Add(patientid);
            //        return;
            //    }
            //}

            if (this.flgView.Row >= 0 && this.flgView.Col >= 0 && this.flgView[this.flgView.Row, this.flgView.Col] != null)
            {
                string cellvalue = this.flgView[this.flgView.Row, this.flgView.Col].ToString();
                string msg = string.Empty;
                if (cellvalue == startCellVal || (string.IsNullOrEmpty(cellvalue) && (string.IsNullOrEmpty(startCellVal))))
                {
                    //ԭΪ��ɫ���༭״̬���ɫ����Ϊ��ɫ
                    string colname = this.flgView.Cols[this.flgView.Col].Name;
                    CellRange rg = flgView.GetCellRange(this.flgView.Row, this.flgView.Col);                    
                    string cvalue = "";
                    if (flgView[this.flgView.Row, this.flgView.Col] != null)
                    {
                        cvalue = flgView[this.flgView.Row, this.flgView.Col].ToString().Trim();

                    }                 
                    #region    /*******--�ж����´��ڵ���38

                    if (cvalue != "" && colname.Contains("T"))
                    {
                        if (Convert.ToDouble(cvalue) > Convert.ToDouble(dssql.Tables[0].Rows[0]["TEMPERATUREMAX"].ToString()))
                        {
                            rg.StyleNew.ForeColor = Color.Red;
                        }
                        else if (Convert.ToDouble(cvalue) < Convert.ToDouble(dssql.Tables[0].Rows[0]["TEMPERATUREMIN"].ToString()))
                        {
                            rg.StyleNew.ForeColor = Color.Red;
                        }
                    }
                    #endregion
                    #region /*�ж���������160��С��40*/
                    /*
                                 * �ж���������160��С��40
                                 */
                    if (cvalue != "" && colname.Contains("P"))
                    {
                        if (Convert.ToDouble(cvalue) > Convert.ToInt32(dssql.Tables[0].Rows[0]["PULSEMAX"].ToString()))
                        {
                            rg.StyleNew.ForeColor = Color.Red;
                        }
                        else if (Convert.ToDouble(cvalue) < Convert.ToInt32(dssql.Tables[0].Rows[0]["PULSEMIN"].ToString()))
                        {
                            rg.StyleNew.ForeColor = Color.Red;
                        }
                    }

                    #endregion
                    #region /----***�ж���������30��С��10
                    /*
                                 *�жϺ�������30��С��10 
                                 */
                    if (cvalue != "" && colname.Contains("R"))
                    {
                        if (Convert.ToDouble(cvalue) > Convert.ToInt32(dssql.Tables[0].Rows[0]["BREATHMAX"].ToString()))
                        {
                            rg.StyleNew.ForeColor = Color.Red;
                        }
                        else if (Convert.ToDouble(cvalue) < Convert.ToInt32(dssql.Tables[0].Rows[0]["BREATHMIN"].ToString()))
                        {
                            rg.StyleNew.ForeColor = Color.Red;
                        }
                    }
                    #endregion
                    return;
                }
                if (!string.IsNullOrEmpty(cellvalue))
                {
                    string colname = this.flgView.Cols[this.flgView.Col].Name;
                    string patientid = this.flgView[this.flgView.Row, "��������"].ToString();
                    if (colname.Contains("T"))
                    {
                        float f = 0;
                        if (!float.TryParse(cellvalue, out f))
                        {
                            App.Msg("�������±���Ϊ��ֵ��!");
                            this.flgView[this.flgView.Row, this.flgView.Col] = "";
                            return;
                        }
                        if (IsNeedRemind("T", f.ToString(), ref msg))
                        {
                            App.Msg(msg);
                            this.flgView[this.flgView.Row, this.flgView.Col] = "";
                            return;
                        }
                        if (!PatientIDList.Exists(delegate(string s) { return s == patientid; }))
                        {
                            PatientIDList.Add(patientid);
                        }
                    }
                    else if (colname.Contains("R"))
                    {
                        int i = 0;
                        if (!int.TryParse(cellvalue, out i))
                        {
                            App.Msg("���ߺ�������Ϊ����!");
                            this.flgView[this.flgView.Row, this.flgView.Col] = "";
                            return;
                        }
                        if (IsNeedRemind("R", i.ToString(), ref msg))
                        {
                            App.Msg(msg);
                            this.flgView[this.flgView.Row, this.flgView.Col] = "";
                            return;
                        }
                        if (!PatientIDList.Exists(delegate(string s) { return s == patientid; }))
                        {
                            PatientIDList.Add(patientid);
                        }
                    }
                    else if (colname.Contains("P"))
                    {
                        int i = 0;
                        if (!int.TryParse(cellvalue, out i))
                        {
                            App.Msg("������������Ϊ����!");
                            this.flgView[this.flgView.Row, this.flgView.Col] = "";
                            return;
                        }
                        if (IsNeedRemind("P", i.ToString(), ref msg))
                        {
                            App.Msg(msg);
                            this.flgView[this.flgView.Row, this.flgView.Col] = "";
                            return;
                        }
                        if (!PatientIDList.Exists(delegate(string s) { return s == patientid; }))
                        {
                            PatientIDList.Add(patientid);
                        }
                    }
                    else if (colname.Contains("���") || colname.Contains("����") || colname.Contains("Ż��") ||
                  colname.Contains("Һ����") || colname.Contains("������") || colname.Contains("����") || colname.Contains("����") || colname.Contains("��") || colname.Contains("��"))
                    {
                        if (!PatientIDList.Exists(delegate(string s) { return s == patientid; }))
                        {
                            PatientIDList.Add(patientid);
                        }
                    }
                }
                else
                {
                    string colname = this.flgView.Cols[this.flgView.Col].Name;
                    string patientid = this.flgView[this.flgView.Row, "��������"].ToString();
                    PatientIDList.Add(patientid);
                }
            }
            CellChangeRedColor();
        }

        /// <summary>
        /// ¼���ֵ�Ƿ���Ҫ��ʾ�쳣��Ϣ
        /// </summary>
        /// <param name="Sign"></param>
        /// <param name="SignValue"></param>
        /// <param name="Msg"></param>
        /// <returns></returns>
        bool IsNeedRemind(string Sign, string SignValue, ref string Msg)
        {
            bool b = false;
            switch (Sign)
            {
                case "T":
                    double t = 0;
                    double.TryParse(SignValue, out t);
                    if (t < dTmin || t > dTmax)
                    {
                        b = true;
                        Msg = "�������±�����" + dTmin.ToString() + "��" + dTmax.ToString() + "֮��";
                    }
                    else
                        b = false;
                    break;
                case "R":
                    int r = 0;
                    int.TryParse(SignValue, out r);
                    if (r < iRmin || r > iRmax)
                    {
                        b = true;
                        Msg = "���ߺ���������" + iRmin.ToString() + "��" + iRmax.ToString() + "֮��";
                    }
                    else
                        b = false;
                    break;
                case "P":
                    int p = 0;
                    int.TryParse(SignValue, out p);
                    if (p < iPmin || p > iPmax)
                    {
                        b = true;
                        Msg = "��������������" + iPmin.ToString() + "��" + iPmax.ToString() + "֮��";
                    }
                    else
                        b = false;
                    break;
                default:
                    b = false;
                    break;
            }
            return b;
        }
        private void flgView_EnterCell(object sender, EventArgs e)
        {
            string str = "fdsafdsa";
        }



   

    }
}
