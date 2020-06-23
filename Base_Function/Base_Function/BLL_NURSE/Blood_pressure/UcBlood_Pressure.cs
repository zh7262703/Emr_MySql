using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using System.Collections;
using C1.Win.C1FlexGrid;
using Bifrost_Nurse.UControl;
using Base_Function.MODEL;

namespace Base_Function.BLL_NURSE.Blood_pressure
{
    /// <summary>
    /// 血压群录
    /// 创建者：杨妹
    /// 创建时间 2011-03-06
    /// </summary>
    public partial class UcBlood_Pressure : UserControl
    {
        ColumnInfo[] cols = new ColumnInfo[6];
        private string SelectCellVal = "无值";  //记录当前选中单元格的值
        private int RowIndex = 0;    //记录单元格的行数
        private int ColIndex = 0;    //记录单元格的列数
        ArrayList selectTemp = new ArrayList();
        private bool isreflesh = false;
        public UcBlood_Pressure()
        {
            try
            {
                InitializeComponent();
               
            }
            catch
            {

            }
        }
        private void UcBlood_Pressure_Load(object sender, EventArgs e)
        {
            try
            {
                isreflesh = true;
                if (isreflesh == true)
                {
                    ShowDate();
                }
                isreflesh = false;
                lblDatePriview.Text = dtpDate.Value.AddDays(-1).ToShortDateString() + "<<";
                lblDateNext.Text = ">>" + dtpDate.Value.AddDays(1).ToShortDateString();
            }
            catch
            {

            }
        }
        private void lblDatePriview_Click(object sender, EventArgs e)
        {
            isreflesh = true;
            dtpDate.Value = Convert.ToDateTime(dtpDate.Value.AddDays(-1));
            lblDatePriview.Text = dtpDate.Value.AddDays(-1).ToShortDateString() + "<<";
            if (isreflesh == true)
            {
                ShowDate();
            }
            isreflesh = false;
        }

        private void lblDateNext_Click(object sender, EventArgs e)
        {
            isreflesh = true;
            dtpDate.Value = Convert.ToDateTime(dtpDate.Value.AddDays(1));
            lblDateNext.Text = ">>" + dtpDate.Value.AddDays(1).ToShortDateString();
            if (isreflesh == true)
            {
                ShowDate();
            }
            isreflesh = false;
        }
        
         /// <summary>
        /// 单元格合并和设置 
        /// </summary>
        private void CellUnit()
        {
            //单元格合并和设置         
            flgView[1, 0] = "床号";
            flgView[1, 1] = "姓名";
            flgView[1, 2] = "mmHg";
            flgView[1, 3] = "mmHg";
            flgView[1, 4] = "住院号";
            flgView[1, 5] = "病人编号";
    
            flgView.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            flgView.Cols.Fixed = 0;

            C1.Win.C1FlexGrid.CellRange cr;
            cr = flgView.GetCellRange(0, 0, 1, 0);
            cr.Data = "床号";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 1, 1, 1);
            cr.Data = "姓名";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 2, 0, 2);
            cr.Data = "08:00";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 2, 1, 2);
            cr.Data = "mmHg";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 3, 0, 3);
            cr.Data = "14:00";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 3, 1, 3);
            cr.Data = "mmHg";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 4, 1, 4);
            cr.Data = "住院号";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);
            cr = flgView.GetCellRange(0, 5, 1, 5);
            cr.Data = "病人编号";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);
            flgView.AutoSizeCols();

            for (int i = 0; i < flgView.Cols.Count; i++)
            {
                flgView.Cols[i].Width = 50;
                if (i== 2 || i == 3)
                {
                    flgView.Cols[i].Width =100;
                }
                //flgView.CellChanged += new RowColEventHandler(flgView_CellChanged);
            }

            for (int i = 2; i < flgView.Rows.Count; i++)
            {
                flgView.Rows[i].Height = 35;
            }

            //隐藏列
            flgView.Cols[4].AllowEditing = false;
            flgView.Cols[4].Visible = false;
            flgView.Cols[5].AllowEditing = false;
            flgView.Cols[5].Visible = false;
            //居中显示
            flgView.Cols[0].TextAlign =TextAlignEnum.CenterCenter;
            flgView.Cols[1].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[2].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[3].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[4].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[5].TextAlign = TextAlignEnum.CenterCenter;
        }
         /// <summary>
        /// 表头设置
        /// </summary>
        private void SetTable()
        {
            //单元格合并和设置           
            //flgView.Cols.Count = 5;
            //flgView.Cols.Fixed = 0;
            //flgView.Rows.Count = 1;
            //flgView.Rows.Fixed = 1;

            flgView.Cols.Count = 6;
            flgView.Cols.Fixed = 0;
            flgView.Rows.Count = 2;
            flgView.Rows.Fixed = 2;


        }
        private int y = 0;
        /// <summary>
        /// 显示列表
        /// </summary>
        private void ShowDate()
        {
            try
            {
                flgView.Clear();
                SetTable();
                string date = dtpDate.Value.ToString("yyyy-MM-dd");
                //显示一个病区的病人
                string PatintInfoSql = @"select a.id,patient_name,case when gender_code=0 then '男' else '女' end gender_code,birthday,a.pid,sick_doctor_id," +
                            @"sick_doctor_name,sick_area_id,sick_area_name,section_id,section_name,a.in_time,a.state,a.sick_bed_id,a.SICK_BED_NO from t_in_patient a  " +
                            @"inner join t_inhospital_action b on a.id=b.patient_id inner join t_sickbedinfo c on a.sick_bed_id=c.bed_id  where  a.SICK_AREA_ID=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " and  b.action_state=4  and  a.SICK_BED_NO is not null and  b.id in (select max(id) from t_inhospital_action group by patient_id) order by sick_bed_no ";
                DataSet dsPatint = App.GetDataSet(PatintInfoSql);
                
                if (dsPatint != null)
                {
                    /*
                    * 显示所有的本病区的病人信息
                    */
                    for (int i = 0; i < dsPatint.Tables[0].Rows.Count; i++)
                    {
                        flgView.Rows.Add();
                      
                        ClassBlood_pressure temp = new ClassBlood_pressure();
                        temp.Bed = dsPatint.Tables[0].Rows[i]["SICK_BED_NO"].ToString();
                        temp.Pidname = dsPatint.Tables[0].Rows[i]["patient_name"].ToString();
                        temp.Pid = dsPatint.Tables[0].Rows[i]["pid"].ToString();
                        temp.Pidids = dsPatint.Tables[0].Rows[i]["id"].ToString();
                        flgView[2 + i, 0] = temp.Bed;
                        flgView[2 + i, 1] = temp.Pidname;
                        flgView[2 + i, 4] = temp.Pid;
                        flgView[2 + i, 5] = temp.Pidids;
                        if (temp.Pid != "")
                        {
                            //查询所有的血压
                            string sql = "select * from t_temperature_info where to_char(RECORD_TIME,'yyyy-MM-dd')='" + date + "' and patient_id='" + temp.Pidids + "'";
                            DataSet ds = App.GetDataSet(sql);
                            if (ds != null)
                            {

                                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                                {
                                    string pressure = ds.Tables[0].Rows[j]["BP_BLOOD"].ToString();
                                    if (pressure != "")
                                    {
                                        if (pressure.ToString().Contains(","))
                                        {
                                            string[] bloodArr = pressure.Split(',');

                                            if (bloodArr[0].ToString() != "")
                                            {
                                                if (bloodArr.Length > 1)
                                                {
                                                    string bloodOne = bloodArr[0].Substring(1, bloodArr[0].Length - 1);
                                                    if (bloodOne.Length > 1)
                                                    {

                                                        temp.Blood_pressure08 = bloodOne;
                                                    }
                                                    if (bloodArr[1].ToString() != "")
                                                    {
                                                        string bloodTwo = bloodArr[1].Substring(1, bloodArr[1].Length - 1);

                                                        if (bloodTwo.Length > 1)
                                                        {
                                                            temp.Blood_pressure14 = bloodTwo;
                                                        }
                                                    }


                                                }
                                            }
                                        }
                                        else
                                        {
                                            string oneOrTwo = pressure.Substring(0, 1);
                                            string one = pressure.Substring(1, pressure.Length - 1);
                                            if (oneOrTwo == "O")
                                            {
                                                if (one.Length > 1)
                                                {

                                                    temp.Blood_pressure08 = one;
                                                }

                                            }
                                            else
                                            {
                                                if (one.Length > 1)
                                                {
                                                    temp.Blood_pressure14 = one;

                                                }
                                            }
                                        }
                                    }
                                }

                                string blood08 = isExNot(temp.Blood_pressure08);
                                string blood14 = isExNot(temp.Blood_pressure14);
                                if (blood08 != ""&&blood08 !=null)
                                {
                                    if (blood08.ToString().Contains("/"))
                                    {
                                        flgView[2 + i, 2] = blood08;
                                    }
                                    else
                                    {
                                        flgView[2 + i, 2] = blood08 + "/";
                                    }
                                }
                                else
                                {
                                    flgView[2 + i, 2] = "/";
                                }

                                if (blood14 != ""&&blood14 != null)
                                {
                                    if (blood14.ToString().Contains("/"))
                                    {
                                        flgView[2 + i, 3] = blood14;
                                    }
                                    else
                                    {
                                        flgView[2 + i, 3] = blood14 + "/";
                                    }
                                }
                                else
                                {
                                    flgView[2 + i, 3] = "/";
                                }

                        //flgView[2 + i, 2] = isExNot(temp.Blood_pressure08);
                  
                        //flgView[2 + i, 3] = isExNot(temp.Blood_pressure14);
                  
                      
                            }
                        }
                    }
                }

                //单元格合并和设置
                CellUnit();
                for (int i = 2; i < flgView.Rows.Count; i++)
                {
                   
                    /*
                     * 住院号和病人姓名变成蓝色
                     */
                    CellRange rg = flgView.GetCellRange(i, 0);
                    rg.StyleNew.ForeColor = Color.Blue;
                    

                    CellRange rg2 = flgView.GetCellRange(i, 1);
                    rg2.StyleNew.ForeColor = Color.Blue;
                }
              
                //单元格线条加粗
                flgView.Cols[0].StyleNew.Border.Color = Color.Black;
                flgView.Cols[1].StyleNew.Border.Color = Color.Black;
                flgView.Cols[2].StyleNew.Border.Color = Color.Black;
                flgView.Cols[3].StyleNew.Border.Color = Color.Black;
                flgView.Cols[4].StyleNew.Border.Color = Color.Black;
            }
            catch
            {
            }
        }
        int lastRowindex = 0;
        int lastColindex = 0;
        int errorflag = 0; //0 正常,1非法字符
        private void flgView_CellChanged(object sender, RowColEventArgs e)
        {
            if (isreflesh == false)
            {
                if (flgView.RowSel > 2)
                {
                    lastRowindex = flgView.RowSel;
                    lastColindex = flgView.ColSel;
                    string blood = "";
                    if (flgView[flgView.RowSel, flgView.ColSel].ToString() == "")
                    {
                        //if (flgView[flgView.RowSel, flgView.ColSel].ToString().Trim() == "")
                        //{
                        if (flgView.RowSel > 1 && flgView.ColSel > 1)
                        {
                            blood = flgView[flgView.RowSel, flgView.ColSel].ToString();
                            if (!blood.ToString().Contains("/"))
                            {
                                App.Msg("/ 不能去除！");
                                flgView[lastRowindex, lastColindex] = "/";
                                errorflag = 1;
                                return;
                            }
                        }
                        //}
                    }
                    else
                    {
                        string name = flgView[flgView.RowSel, flgView.ColSel].ToString();
                        if (!name.ToString().Contains("/"))
                        {
                            App.Msg("/ 不能去除!(注：它‘/ '的后面请填写值)");
                            flgView[lastRowindex, lastColindex] = "/";
                            errorflag = 1;
                            return;
                        }
                    }
                }
            }

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
        private void flgView_KeyDown(object sender, KeyEventArgs e)
        {
            errorflag = 0;
        }

        /// <summary>
        /// 验证数据如果是0的就显示为空
        /// </summary>
        /// <param Name="str">数据</param>
        /// <returns></returns>
        public string isExNot(string str)
        {
            if (str == "0")
            {
                str = "";
            }
            return str;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string dssql = "select * from t_temperature_info where to_char(RECORD_TIME,'yyyy-MM-dd')='" + dtpDate.Value.ToShortDateString() + "'";
                DataSet ds = App.GetDataSet(dssql);
                string rows = "";//当前行
                string cols = "";//当前列
                ArrayList Sqls = new ArrayList();
               // string Tempstrs = null;
                for (int i = 2; i < flgView.Rows.Count; i++)
                {
                    
                    //t_temperature_info tti = new t_temperature_info();
                    //7点血糖监测单
                    string blood = "";
                    string SugarRecord_08="", SugarRecord_14="";
                    if (flgView[i, 2] != null)
                    {
                        if (flgView[i, 2].ToString().Trim() != "")
                        {
                            SugarRecord_08 = flgView[i, 2].ToString();
                            if (SugarRecord_08 != "/")
                            {
                                blood += "O" + SugarRecord_08;
                            }
                        }
                        else
                        {
                            rows = i.ToString();
                            cols = "2";
                            SugarRecord_08 = SeleteCell(rows, cols);
                            if (SugarRecord_08 != "/")
                            {
                                blood += SugarRecord_08;
                            }
                        }
                    }
                    if (flgView[i, 3] != null)
                    {
                        if (flgView[i, 3].ToString().Trim() != "")
                        {
                            if (flgView[i, 3].ToString() != "/")
                            {
                                if (blood != "")
                                {
                                    blood += ",";
                                }
                                SugarRecord_14 = flgView[i, 3].ToString();
               
                                blood += "T" + SugarRecord_14;
                            }
                         
                        }
                        else
                        {
                            //if (blood != null)
                            //{
                            //    blood += ",";
                            //}
                            rows = i.ToString();
                            cols = "2";
                            SugarRecord_14 = SeleteCell(rows, cols);
                            if (SugarRecord_14 != "/")
                            {
                                blood += SugarRecord_14;
                            }
                        }
                    }
               
                    string blood_pressure = blood;
                    string Record_time = dtpDate.Value.ToString("yyyy-MM-dd");
                    
                    string Bed_no = flgView[i, 0].ToString();
                    string Pid = flgView[i, 4].ToString();
                    string Pid_IDS = flgView[i, 5].ToString();
                    string values1 = null;
                    string Tempstrs = null;
                    string[] arrs = null;
                    if (blood == "" )
                    {

                    }
                    else
                    {
                        if (blood == "00")
                        {
                            blood = "0";
                        }
                        int rowcount = ds.Tables[0].Select("PATIENT_ID='" + Pid_IDS + "' and  record_time='" + Record_time + "'").Length;
                        if (rowcount == 0)
                        {
                            string bed_sql = "";
                            bed_sql = "select ID,BED_NO,PID,BP_BLOOD,RECORD_TIME,PATIENT_ID  from t_temperature_info where PATIENT_ID=" + Pid_IDS + " and to_char(record_time,'yyyy-MM-dd')='" + Record_time + "'";
                            DataSet SQl = App.GetDataSet(bed_sql);
                            //int rowcount1 = SQl.Tables[0].Select("PID='" + Pid + "' and  record_time='" + Record_time + "'").Length;
                            //if (rowcount1 == 0)
                            //{
                                //DataSet ds1 = App.GetDataSet(SQl);
                            if (SQl.Tables[0].Rows.Count > 0)
                            {
                                values1 = "update t_temperature_info set BP_BLOOD='" + blood + "' where  PATIENT_ID=" + Pid_IDS + " and to_char(RECORD_TIME,'yyyy-MM-dd')='" + Record_time + "'";
                                Tempstrs += values1 + "．";
                            }
                            //}
                            else
                            {
                                values1 = "insert into t_temperature_info(BED_NO,RECORD_TIME,BP_BLOOD,PID,PATIENT_ID)values('" + Bed_no + "',to_timestamp('" + Record_time + "','syyyy-mm-dd hh24:mi'),'" + blood + "','" + Pid + "',"+Pid_IDS+")";
                                Tempstrs += values1 + "．";

                            }


                        }
                        else
                        {
                            values1 = "update t_temperature_info set BP_BLOOD='" + blood_pressure + "' where  PATIENT_ID=" + Pid_IDS + "  and  to_char(RECORD_TIME,'yyyy-MM-dd')='" + Record_time + "'";
                            Tempstrs += values1 + "．";
                        }
                    }
                    if (Tempstrs != null)
                    {
                        arrs = new string[Tempstrs.Split('．').Length];
                        for (int j = 0; j < Tempstrs.Split('．').Length; j++)
                        {
                            if (Tempstrs.Split('．')[j] != "" || Tempstrs.Split('．')[j] != null)
                            {
                                arrs[j] = Tempstrs.Split('．')[j];
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
                    App.Msg("操作成功！");
                    isreflesh = true;
                    if (isreflesh == true)
                    {
                        ShowDate();
                    }
                    isreflesh = false;
                    //ShowDate();

                }
                else
                {
                    App.Msg("操作失败！");
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
            }
            return "";

        }

        private void flgView_DoubleClick(object sender, EventArgs e)
        {

                if (flgView.RowSel > 1)
                {
                    if (flgView.Rows.Count > 2)
                    {
                        if (flgView[flgView.RowSel, flgView.ColSel] != null)
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

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (isreflesh == true)
                {
                    ShowDate();
                }
                isreflesh = false;
                lblDatePriview.Text = dtpDate.Value.AddDays(-1).ToShortDateString() + "<<";
                lblDateNext.Text = ">>" + dtpDate.Value.AddDays(1).ToShortDateString();
            }
            catch
            {
            }
        }

   

    
 

      

     

     


    }
}
