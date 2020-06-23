using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;
using DevComponents.DotNetBar;
using Bifrost;

namespace Base_Function.BLL_MANAGEMENT
{
    public partial class frmQualityList : Office2007Form
    {
        public frmQualityList(DataSet dsQuality, string name, string textType)
        {
            InitializeComponent();
            if (textType != "请选择...")
            {
                this.label1.Text = "["+name + "] [" + textType + "] 的质控扣分详细列表";
            }
            else
            {
                this.label1.Text = "["+name +"] 的质控扣分详细列表";
            }
            InitTable(dsQuality);
        }

        public void InitTable(DataSet dsQuality)
        {
            try
            {
                flgView.Clear();
                flgView.AllowEditing = false;
                flgView.Rows.Count = 1;
                flgView.Cols.Count = 6;
                //flgView[0, 1] = "科室";
                flgView[0, 1] = "床号";
                flgView[0, 2] = "病人姓名";
                flgView[0, 3] = "提醒信息";
                flgView[0, 4] = "扣分值";
                flgView[0, 5] = "超时天数";
                flgView.Cols.Fixed = 0;

                string nameTemp = "";
                string bedNoTemp = "";
                int tempNum = 0;
                bool flag = true;
                if (dsQuality.Tables[0].Rows.Count > 0)
                {
                    DataRow[] drList = dsQuality.Tables[0].Select();
                    for (int i = 0; i < drList.Length; i++)
                    {
                        flgView.Rows.Add();

                        //string sectionName = drList[i]["SECTION_NAME"].ToString();
                        string sickBedNO = drList[i]["SICK_BED_NO"].ToString();
                        string patientName = drList[i]["PATIENT_NAME"].ToString();

                        if (bedNoTemp == sickBedNO && nameTemp == patientName)
                        {
                            sickBedNO = "";
                            patientName = "";
                            flgView.Rows[i].StyleNew.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Horizontal;
                        }
                        if (sickBedNO != ""&&i!=0)
                        {
                            //flgView.Rows[i].StyleNew.ForeColor = Color.Red;
                            //横线加粗
                            flgView.Rows[i].StyleNew.Border.Color = Color.Red;
                            flgView.Rows[i].StyleNew.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Horizontal;
                            flgView.Rows[i].StyleNew.Border.Width = 1;

                        }
                        string note = drList[i]["NOTE"].ToString();
                        string grade = drList[i]["TAKE_GRADE"].ToString();
                        string noteTime = TimeDiff(Convert.ToDateTime(drList[i]["NOTEZTIME"].ToString()));

                       // flgView[1 + i, 1] = sectionName;
                        flgView[1 + i , 1] = sickBedNO;
                        flgView[1 + i , 2] = patientName;
                        flgView[1 + i , 3] = note;
                        flgView[1 + i, 4] = grade;
                        flgView[1 + i , 5] = noteTime;

                        nameTemp = drList[i]["PATIENT_NAME"].ToString();
                        bedNoTemp = drList[i]["SICK_BED_NO"].ToString();
                       
                    }

                    flgView.Cols[1].TextAlign = TextAlignEnum.CenterCenter;
                    flgView.Cols[4].TextAlign = TextAlignEnum.CenterCenter;

                 
                    flgView.AutoSizeCols();
                    //flgView.AutoSizeRows();
                    for (int i = 2; i < flgView.Rows.Count; i++)
                    {
                        flgView.Rows[i].Height = 25;
                    } 
                }
            }
            catch
            { 
            }
        }

        public string TimeDiff(DateTime dateTime)
        {
            string dateDiff=null;

            TimeSpan ts1 = new TimeSpan(App.GetSystemTime().Ticks);
            TimeSpan ts2 = new TimeSpan(dateTime.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            dateDiff = ts.Days.ToString() + "天"
                    + ts.Hours.ToString() + "小时";


            return dateDiff;

        }

     
    }
}