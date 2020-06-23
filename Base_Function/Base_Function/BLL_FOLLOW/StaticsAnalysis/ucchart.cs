using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using C1.Win.C1Chart;
using C1.Win.C1Chart.DataEditor;
using C1.Common;
using System.IO;
using System.Drawing.Printing;
using Bifrost;

namespace MyCode
{
    public partial class ucchart : Form
    {

        DataSet CurrentDS = new DataSet();
        public ucchart()
        {
            InitializeComponent();
            //App.ini();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            CurrentDS = null;
            //暂时还没有数据 考虑手工录入统计结果到一张表里面试试效果
            string sql = "select t.section_id 科室ID,t.section_name 科室,t.follow_number 随访人数,t.manyi 满意人数,to_char(t.manyi/t.follow_number*100,99.99)||'%' 满意率,t.no_manyi 不满意人数,to_char(t.no_manyi/t.follow_number*100,99.99)||'%' 不满意率 from t_follow_element_count t";
            CurrentDS = App.GetDataSet(sql);

            dgvShow.DataSource = CurrentDS.Tables[0].DefaultView;
           
             string[] args = new string[3];
             args[0] = "随访人数";
             args[1] = "满意人数";
             args[2] = "不满意人数";

             SetLineAndBarChart(CurrentDS.Tables[0], "", "", "", "科室", "", args, "", args, "");
        }


        #region 柱状图以及对应方法
        /// <summary>
        /// 柱状图和折线图混合图
        /// </summary>
        /// <param name="dt">数据</param>
        /// <param name="_Header">图表头标题</param>
        /// <param name="_Footer">图表尾文本</param>
        /// <param name="_Legend">图例名称</param>
        /// <param name="_XDataName">X轴数据列名称</param>
        /// <param name="_XTitle">X轴名称</param>
        /// <param name="_YDataNames">左Y轴数据列名称集合</param>
        /// <param name="_YTitle">左Y轴名称</param>
        /// <param name="_YDataNames2">右Y轴数据列名称集合</param>
        /// <param name="_YTitle2">右Y轴名称</param>
        public void SetLineAndBarChart(DataTable dt, string _Header, string _Footer, string _Legend, string _XDataName, string _XTitle, string[] _YDataNames, string _YTitle, string[] _YDataNames2, string _YTitle2)
        {
            c1Chart1.Reset();
            c1Chart1.BackColor = Color.White;
            c1Chart1.ChartArea.Style.Font = new Font("Tahoma", 8);
            c1Chart1.ChartGroups.Group0.ChartType = Chart2DTypeEnum.XYPlot;
            c1Chart1.ChartGroups.Group1.ChartType = Chart2DTypeEnum.Bar;
            c1Chart1.Header.Visible = true;
            c1Chart1.Header.Text = _Header;
            c1Chart1.Header.Style.Font = new Font("宋体", 14, FontStyle.Bold);
            c1Chart1.Footer.Visible = true;
            c1Chart1.Footer.Text = _Footer;
            c1Chart1.BackColor = Color.White;


            c1Chart1.Legend.Visible = true;
            c1Chart1.Legend.Text = _Legend;
            c1Chart1.Legend.Style.Border.BorderStyle = C1.Win.C1Chart.BorderStyleEnum.Groove;
            c1Chart1.Legend.Style.Border.Thickness = 1;
            c1Chart1.Legend.Style.Border.Color = Color.LightGray;
            c1Chart1.Legend.Style.HorizontalAlignment = C1.Win.C1Chart.AlignHorzEnum.Center;
            c1Chart1.Legend.Style.Font = new Font("宋体", 10);
            c1Chart1.Legend.Compass = CompassEnum.East;
            c1Chart1.Legend.Reversed = false;

            c1Chart1.Legend.Style.GradientStyle = GradientStyleEnum.Diagonal;
            c1Chart1.Legend.Style.HatchStyle = HatchStyleEnum.Cross;
            //c1Chart1.Legend.Style.Rotation = RotationEnum.Rotate180;    //旋转
            //c1Chart1.Legend.Style.VerticalAlignment = AlignVertEnum.Top;

            //c1Chart1.Legend.ShouldSerializeStyle();

            c1Chart1.ChartArea.AxisX.Text = _XTitle;
            c1Chart1.ChartArea.AxisY.OnTop = true;
            //c1Chart1.ChartArea.AxisY.Alignment = StringAlignment.Center;
            //c1Chart1.ChartArea.AxisY.TickMinor = TickMarksEnum.Cross;
            //c1Chart1.ChartArea.AxisY.TickMajor = TickMarksEnum.Inside;
            //c1Chart1.ChartArea.AxisY.TickLabels = TickLabelsEnum.NextToAxis;
            c1Chart1.ChartArea.AxisY.Text = _YTitle;
            //c1Chart1.ChartArea.AxisY.Rotation = RotationEnum.Rotate0;
            c1Chart1.ChartArea.AxisY2.Text = _YTitle2;
            GetChart(dt, _XDataName, _YDataNames, _YDataNames2);
        }


        public void SetBarCharts(DataTable dt, string _Header, string _Footer, string _Legend, string _XDataName, string _XTitle, string[] _YDataNames, string _YTitle)
        {
            c1Chart1.Reset();
            c1Chart1.BackColor = Color.White;
            c1Chart1.ChartArea.Style.Font = new Font("Tahoma", 8);
            c1Chart1.ChartGroups.Group0.ChartType = Chart2DTypeEnum.Bar;
            c1Chart1.ChartGroups.Group1.ChartType = Chart2DTypeEnum.Bar;
            c1Chart1.Header.Visible = true;
            c1Chart1.Header.Text = _Header;
            c1Chart1.Header.Style.Font = new Font("宋体", 14, FontStyle.Bold);
            c1Chart1.Footer.Visible = true;
            c1Chart1.Footer.Text = _Footer;
            c1Chart1.BackColor = Color.White;


            c1Chart1.Legend.Visible = true;
            c1Chart1.Legend.Text = _Legend;
            c1Chart1.Legend.Style.Border.BorderStyle = C1.Win.C1Chart.BorderStyleEnum.Groove;
            c1Chart1.Legend.Style.Border.Thickness = 1;
            c1Chart1.Legend.Style.Border.Color = Color.LightGray;
            c1Chart1.Legend.Style.HorizontalAlignment = C1.Win.C1Chart.AlignHorzEnum.Center;
            c1Chart1.Legend.Style.Font = new Font("宋体", 10);
            c1Chart1.Legend.Compass = CompassEnum.East;
            c1Chart1.Legend.Reversed = false;

            c1Chart1.Legend.Style.GradientStyle = GradientStyleEnum.Diagonal;
            c1Chart1.Legend.Style.HatchStyle = HatchStyleEnum.Cross;
            //c1Chart1.Legend.Style.Rotation = RotationEnum.Rotate180;    //旋转
            //c1Chart1.Legend.Style.VerticalAlignment = AlignVertEnum.Top;

            //c1Chart1.Legend.ShouldSerializeStyle();

            c1Chart1.ChartArea.AxisX.Text = _XTitle;
            c1Chart1.ChartArea.AxisY.OnTop = true;

            GetBarCharts(dt, _XDataName, _YDataNames);
        }

        public void SetBarAndBarChart(DataTable dt, string _Header, string _Footer, string _Legend, string _XDataName, string _XTitle, string[] _YDataNames, string _YTitle, string[] _YDataNames2, string _YTitle2)
        {
            c1Chart1.Reset();
            c1Chart1.BackColor = Color.White;
            c1Chart1.ChartArea.Style.Font = new Font("Tahoma", 8);
            c1Chart1.ChartGroups.Group0.ChartType = Chart2DTypeEnum.Bar;
            c1Chart1.ChartGroups.Group1.ChartType = Chart2DTypeEnum.Bar;
            c1Chart1.Header.Visible = true;
            c1Chart1.Header.Text = _Header;
            c1Chart1.Header.Style.Font = new Font("宋体", 14, FontStyle.Bold);
            c1Chart1.Footer.Visible = true;
            c1Chart1.Footer.Text = _Footer;
            c1Chart1.BackColor = Color.White;


            c1Chart1.Legend.Visible = true;
            c1Chart1.Legend.Text = _Legend;
            c1Chart1.Legend.Style.Border.BorderStyle = C1.Win.C1Chart.BorderStyleEnum.Groove;
            c1Chart1.Legend.Style.Border.Thickness = 1;
            c1Chart1.Legend.Style.Border.Color = Color.LightGray;
            c1Chart1.Legend.Style.HorizontalAlignment = C1.Win.C1Chart.AlignHorzEnum.Center;
            c1Chart1.Legend.Style.Font = new Font("宋体", 10);
            c1Chart1.Legend.Compass = CompassEnum.East;
            c1Chart1.Legend.Reversed = false;

            c1Chart1.Legend.Style.GradientStyle = GradientStyleEnum.Diagonal;
            c1Chart1.Legend.Style.HatchStyle = HatchStyleEnum.Cross;
            //c1Chart1.Legend.Style.Rotation = RotationEnum.Rotate180;    //旋转
            //c1Chart1.Legend.Style.VerticalAlignment = AlignVertEnum.Top;

            //c1Chart1.Legend.ShouldSerializeStyle();

            c1Chart1.ChartArea.AxisX.Text = _XTitle;
            c1Chart1.ChartArea.AxisY.OnTop = true;
            //c1Chart1.ChartArea.AxisY.Alignment = StringAlignment.Center;
            //c1Chart1.ChartArea.AxisY.TickMinor = TickMarksEnum.Cross;
            //c1Chart1.ChartArea.AxisY.TickMajor = TickMarksEnum.Inside;
            //c1Chart1.ChartArea.AxisY.TickLabels = TickLabelsEnum.NextToAxis;
            c1Chart1.ChartArea.AxisY.Text = _YTitle;
            //c1Chart1.ChartArea.AxisY.Rotation = RotationEnum.Rotate0;
            c1Chart1.ChartArea.AxisY2.Text = _YTitle2;
            GetChart(dt, _XDataName, _YDataNames, _YDataNames2);
        }

        /// <summary>
        /// 折线图
        /// </summary>
        /// <param name="dt">数据</param>
        /// <param name="_Header">图表头标题</param>
        /// <param name="_Footer">图表尾文本</param>
        /// <param name="_Legend">图例名称</param>
        /// <param name="_XDataName">X轴数据列名称</param>
        /// <param name="_XTitle">X轴名称</param>
        /// <param name="_YDataNames">左Y轴数据列名称集合</param>
        /// <param name="_YTitle">左Y轴名称</param>
        public void SetLineChart(DataTable dt, string _Header, string _Footer, string _Legend, string _XDataName, string _XTitle, string[] _YDataNames, string _YTitle)
        {
            c1Chart1.Reset();
            c1Chart1.BackColor = Color.White;
            c1Chart1.ChartArea.Style.Font = new Font("Tahoma", 8);
            c1Chart1.ChartGroups.Group1.ChartType = Chart2DTypeEnum.Bar;
            c1Chart1.ChartGroups.Group0.ChartType = Chart2DTypeEnum.XYPlot;
            c1Chart1.Header.Visible = true;
            c1Chart1.Header.Text = _Header;
            c1Chart1.Header.Style.Font = new Font("宋体", 14, FontStyle.Bold);
            c1Chart1.Footer.Visible = true;
            c1Chart1.Footer.Text = _Footer;
            c1Chart1.BackColor = Color.White;


            c1Chart1.Legend.Visible = true;
            c1Chart1.Legend.Text = _Legend;
            c1Chart1.Legend.Style.Border.BorderStyle = C1.Win.C1Chart.BorderStyleEnum.Groove;
            c1Chart1.Legend.Style.Border.Thickness = 1;
            c1Chart1.Legend.Style.Border.Color = Color.LightGray;
            c1Chart1.Legend.Style.HorizontalAlignment = C1.Win.C1Chart.AlignHorzEnum.Center;
            c1Chart1.Legend.Style.Font = new Font("宋体", 10);
            c1Chart1.Legend.Compass = CompassEnum.East;
            c1Chart1.Legend.Reversed = false;

            c1Chart1.Legend.Style.GradientStyle = GradientStyleEnum.Diagonal;
            c1Chart1.Legend.Style.HatchStyle = HatchStyleEnum.Cross;
            //c1Chart1.Legend.Style.Rotation = RotationEnum.Rotate180;    //旋转
            //c1Chart1.Legend.Style.VerticalAlignment = AlignVertEnum.Top;

            //c1Chart1.Legend.ShouldSerializeStyle();

            c1Chart1.ChartArea.AxisX.Text = _XTitle;
            c1Chart1.ChartArea.AxisY.Text = _YTitle;
            c1Chart1.ChartArea.AxisY.OnTop = true;
            GetLineChart(dt, _XDataName, _YDataNames, 0);
        }

        /// <summary>
        /// 柱状图
        /// </summary>
        /// <param name="dt">数据</param>
        /// <param name="_Header">图表头标题</param>
        /// <param name="_Footer">图表尾文本</param>
        /// <param name="_Legend">图例名称</param>
        /// <param name="_XDataName">X轴数据列名称</param>
        /// <param name="_XTitle">X轴名称</param>
        /// <param name="_YDataNames">左Y轴数据列名称集合</param>
        /// <param name="_YTitle">左Y轴名称</param>
        public void SetBarChart(DataTable dt, string _Header, string _Footer, string _Legend, string _XDataName, string _XTitle, string[] _YDataNames, string _YTitle)
        {
            c1Chart1.Reset();
            c1Chart1.BackColor = Color.White;
            c1Chart1.ChartArea.Style.Font = new Font("Tahoma", 8);
            c1Chart1.ChartGroups.Group0.ChartType = Chart2DTypeEnum.Bar;
            c1Chart1.Header.Visible = true;
            c1Chart1.Header.Text = _Header;
            c1Chart1.Header.Style.Font = new Font("宋体", 14, FontStyle.Bold);
            c1Chart1.Footer.Visible = true;
            c1Chart1.Footer.Text = _Footer;
            c1Chart1.BackColor = Color.White;


            c1Chart1.Legend.Visible = true;
            c1Chart1.Legend.Text = _Legend;
            c1Chart1.Legend.Style.Border.BorderStyle = C1.Win.C1Chart.BorderStyleEnum.Groove;
            c1Chart1.Legend.Style.Border.Thickness = 1;
            c1Chart1.Legend.Style.Border.Color = Color.LightGray;
            c1Chart1.Legend.Style.HorizontalAlignment = C1.Win.C1Chart.AlignHorzEnum.Center;
            c1Chart1.Legend.Style.Font = new Font("宋体", 10);
            c1Chart1.Legend.Compass = CompassEnum.East;
            c1Chart1.Legend.Reversed = false;

            c1Chart1.Legend.Style.GradientStyle = GradientStyleEnum.Diagonal;
            c1Chart1.Legend.Style.HatchStyle = HatchStyleEnum.Cross;
            //c1Chart1.Legend.Style.Rotation = RotationEnum.Rotate180;    //旋转
            //c1Chart1.Legend.Style.VerticalAlignment = AlignVertEnum.Top;

            //c1Chart1.Legend.ShouldSerializeStyle();

            c1Chart1.ChartArea.AxisX.Text = _XTitle;
            c1Chart1.ChartArea.AxisY.Text = _YTitle;
            c1Chart1.ChartArea.AxisY.OnTop = true;

            GetBarChart(dt, _XDataName, _YDataNames, 0);
        }

        /// <summary>
        /// 饼图
        /// </summary>
        /// <param name="dt">数据</param>
        /// <param name="_Header">图表头标题</param>
        /// <param name="_Footer">图表尾文本</param>
        /// <param name="_Legend">图例名称</param>
        /// <param name="_XDataName">X轴数据列名称</param>
        /// <param name="_XTitle">X轴名称</param>
        /// <param name="_YDataNames">左Y轴数据列名称集合</param>
        /// <param name="_YTitle">左Y轴名称</param>
        public void SetPieChart(DataTable dt, string _Header, string _Footer, string _Legend, string _XDataName, string _XTitle, string[] _YDataNames, string _YTitle)
        {
            c1Chart1.Reset();
            c1Chart1.BackColor = Color.White;
            c1Chart1.ChartArea.Style.Font = new Font("Tahoma", 8);
            c1Chart1.ChartGroups.Group0.ChartType = Chart2DTypeEnum.Pie;
            c1Chart1.Header.Visible = true;
            c1Chart1.Header.Text = _Header;
            c1Chart1.Header.Style.Font = new Font("宋体", 14, FontStyle.Bold);
            c1Chart1.Footer.Visible = true;
            c1Chart1.Footer.Text = _Footer;
            c1Chart1.BackColor = Color.White;


            c1Chart1.Legend.Visible = true;
            c1Chart1.Legend.Text = _Legend;
            c1Chart1.Legend.Style.Border.BorderStyle = C1.Win.C1Chart.BorderStyleEnum.Groove;
            c1Chart1.Legend.Style.Border.Thickness = 1;
            c1Chart1.Legend.Style.Border.Color = Color.LightGray;
            c1Chart1.Legend.Style.HorizontalAlignment = C1.Win.C1Chart.AlignHorzEnum.Center;
            c1Chart1.Legend.Style.Font = new Font("宋体", 10);
            c1Chart1.Legend.Compass = CompassEnum.East;
            c1Chart1.Legend.Reversed = false;

            c1Chart1.Legend.Style.GradientStyle = GradientStyleEnum.Diagonal;
            c1Chart1.Legend.Style.HatchStyle = HatchStyleEnum.Cross;
            //c1Chart1.Legend.Style.Rotation = RotationEnum.Rotate180;    //旋转
            //c1Chart1.Legend.Style.VerticalAlignment = AlignVertEnum.Top;

            //c1Chart1.Legend.ShouldSerializeStyle();

            c1Chart1.ChartArea.AxisX.Text = _XTitle;
            c1Chart1.ChartArea.AxisY.Text = _YTitle;
            c1Chart1.ChartArea.AxisY.OnTop = true;

            GetPieChart(dt, _XDataName, _YDataNames);
        }

        private void GetPieChart(DataTable dt, string XDataName, string[] YCols)
        {
            try
            {
                DataView dv = dt.DefaultView;
                int countColumns = YCols.Length;      //多少列
                int allNum = 0;
                PointF[][] data = new PointF[countColumns][]; //视图的数据

                for (int i = 0; i < countColumns; i++)
                {
                    data[i] = new PointF[dv.Count];
                }
                for (int j = 0; j < countColumns; j++)
                {
                    //各列对应的数据
                    for (int i = 0; i < dv.Count; i++)
                    {
                        float y = float.Parse((dv[i][j]).ToString());
                        data[j][i] = new PointF(i, y);
                    }
                }
                //绑定数据  
                ChartDataSeriesCollection collSeries = c1Chart1.ChartGroups[0].ChartData.SeriesList;

                collSeries.Clear();
                for (int i = 0; i < countColumns; i++) //如果是双条,则显示   
                {
                    ChartDataSeries series = collSeries.AddNewSeries();
                    series.PointData.CopyDataIn(data[i]);
                    //collSeries[i].LineStyle.Pattern = LinePatternEnum.DashDot;
                    series.FitType = C1.Win.C1Chart.FitTypeEnum.Beziers;
                    //series.PointData.CopyDataIn(data[i]);// 这里的data是PointF类型
                    //series.FitType = C1.Win.C1Chart.FitTypeEnum.Spline;
                    series.Label = YCols[i];
                }
                for (int i = 0; i < countColumns; i++) //如果是双条,则显示   
                {
                    //lend，对三种颜色Bar块的描述 
                    c1Chart1.ChartGroups[0].ChartData.SeriesList[i].Label = YCols[i];
                }
                // c1Chart1.ChartGroups[0].ChartData.SeriesList[2].Label = "英语成绩";
                //c1Chart1.ChartGroups[0].ChartData[3].LineStyle.Color = Color.LightSteelBlue;
                //c1Chart1.ChartGroups[0].ChartData[3].LineStyle.Thickness = 0;
                //c1Chart1.ChartGroups[0].ChartData.SeriesList[3].Group.Visible = true;                  //坐标上的柱被隐藏
                //c1Chart1.ChartGroups[0].ChartData.SeriesList[3].Display = SeriesDisplayEnum.Hide;  
                // c1Chart1.ChartGroups[0].ChartData.SeriesList[3].Display = SeriesDisplayEnum.Exclude; 

                //c1Chart1.ChartGroups[0].ChartData[3].Display = SeriesDisplayEnum.Exclude;
                //c1Chart1.Legend
                //在Bar中显示值   
                ChartDataSeriesCollection dscoll = c1Chart1.ChartGroups[0].ChartData.SeriesList;
                //dscoll.Remove(c1Chart1.ChartGroups[0].ChartData.SeriesList[3]);
                c1Chart1.ChartLabels.LabelsCollection.Clear();
                for (int i = 0; i < dscoll.Count; i++)
                {

                    ChartDataSeries series = dscoll[i];
                    for (int j = 0; j < dv.Count; j++)
                    {
                        allNum = 0;
                        for (int k = 0; k < YCols.Length; k++)
                        {
                            allNum += int.Parse(dv[j][YCols[k]].ToString());
                        }
                        //加标签,在Bar块上面显示数据
                        C1.Win.C1Chart.Label lbl = c1Chart1.ChartLabels.LabelsCollection.AddNewLabel();

                        string c1Label = string.Format("{0}", float.Parse(dv[j][series.Label].ToString()));
                        float labelNum = float.Parse(dv[j][series.Label].ToString());//显示的实际数值
                        lbl.Text = series.Label;
                        lbl.Text += ":" + labelNum.ToString();
                        if (allNum != 0)
                        {
                            float percent = labelNum * 100 / allNum;
                            lbl.Text += ", " + String.Format("{0:F2} ", percent) + "%";
                        }

                        //lbl.Text = string.Format("{0}", float.Parse(dv[j][series.Label].ToString()));

                        lbl.Compass = LabelCompassEnum.Radial;
                        //lbl.Style.BackColor = Color.Brown;
                        lbl.Style.ForeColor = Color.Blue;
                        lbl.Offset = 10;
                        lbl.Connected = false;
                        lbl.Visible = true;
                        lbl.AttachMethod = AttachMethodEnum.DataIndex;
                        AttachMethodData am = lbl.AttachMethodData;
                        am.GroupIndex = 0;  //0
                        am.SeriesIndex = i; //i
                        am.PointIndex = j;  //0 

                    }
                }
                //显示X轴标签 
                //Axis ax = c1Chart1.ChartArea.AxisX;
                //ax.ValueLabels.Clear();
                //ax.AnnoMethod = AnnotationMethodEnum.ValueLabels;

                //for (int i = 0; i < dv.Count; i++)
                //{
                //    //ax.ValueLabels.Add(i, dv[i]["path_code"].ToString());
                //}
                ////显示X轴标签 
                //Axis ay = c1Chart1.ChartArea.AxisY;
                //ay.Text=""
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetChart(DataTable dt, string XDataName, string[] YCols, string[] YCols2)
        {
            int index = 0;
            if (YCols != null)
            {
                GetBarChart(dt, XDataName, YCols, index);
                index++;
            }
            if (YCols2 != null)
            {
                GetLineChart(dt, XDataName, YCols2, index);
                index++;
            }
        }

        private void GetBarChart(DataTable dt, string XDataName, string[] YCols, int GroupIndex)
        {
            try
            {
                DataView dv = dt.DefaultView;
                int countColumns = YCols.Length;          //多少列 ；第一列未x坐标值 ；其他为数据
                int countRows = dt.Rows.Count;

                PointF[][] data = new PointF[countColumns][]; //视图的数据 

                for (int i = 0; i < countColumns; i++)
                {
                    data[i] = new PointF[countRows];
                }
                //各列对应的数据
                for (int j = 0; j < countColumns; j++)
                {
                    for (int i = 0; i < countRows; i++)
                    {
                        string data1 = dv[i][YCols[j]].ToString();
                        float y = float.Parse(data1);
                        data[j][i] = new PointF(i, y);
                    }
                }
                //绑定数据 
                ChartDataSeriesCollection collSeries = c1Chart1.ChartGroups[GroupIndex].ChartData.SeriesList;
                collSeries.Clear();

                for (int i = 0; i < countColumns; i++) //如果是双条,则显示   
                {
                    ChartDataSeries series = collSeries.AddNewSeries();
                    series.PointData.CopyDataIn(data[i]);
                    series.FitType = C1.Win.C1Chart.FitTypeEnum.Line;
                    series.Label = dt.Columns[YCols[i]].ColumnName;
                }
                //for (int i = 0; i < countColumns; i++) //如果是双条,则显示   
                //{
                //    //lend，对三种颜色Bar块的描述 
                //    c1Chart1.ChartGroups[0].ChartData.SeriesList[i].Label = dt.Columns[YCol[i]].ColumnName.Replace("时间", "");
                //}

                ChartDataSeriesCollection dscoll = c1Chart1.ChartGroups[GroupIndex].ChartData.SeriesList;                //dscoll.Remove(c1Chart1.ChartGroups[0].ChartData.SeriesList[3]);
                if (GroupIndex == 0)
                {
                    c1Chart1.ChartLabels.LabelsCollection.Clear();
                }
                for (int i = 0; i < dscoll.Count; i++)
                {
                    ChartDataSeries series = dscoll[i];
                    for (int j = 0; j < dv.Count; j++)
                    {
                        //加标签,在Bar块上面显示数据
                        C1.Win.C1Chart.Label lbl = c1Chart1.ChartLabels.LabelsCollection.AddNewLabel();
                        string data1 = dv[j][YCols[i]].ToString();
                        if (!string.IsNullOrEmpty(data1))
                        {
                            float y = float.Parse(data1);
                            lbl.Text = string.Format("{0}", y);
                        }
                        lbl.Compass = LabelCompassEnum.North;
                        //lbl.Style.BackColor = Color.Brown;
                        lbl.Style.ForeColor = Color.Blue;
                        lbl.Offset = 10;
                        lbl.Connected = false;
                        lbl.Visible = true;
                        lbl.AttachMethod = AttachMethodEnum.DataIndex;
                        AttachMethodData am = lbl.AttachMethodData;
                        am.GroupIndex = GroupIndex;  //0
                        am.SeriesIndex = i; //i
                        am.PointIndex = j;  //0 
                    }
                }
                if (GroupIndex == 0)
                {
                    //显示X轴标签 
                    Axis ax = c1Chart1.ChartArea.AxisX;
                    //ax.Min = 10;
                    ax.TickMinor = TickMarksEnum.None;
                    ax.ValueLabels.Clear();
                    ax.AnnoMethod = AnnotationMethodEnum.ValueLabels;
                    int num = 15 - dv.Count;
                    if (num < 1)
                    {
                        num = 1;
                    }
                    for (int i = 0; i < dv.Count; i++)
                    {
                        string xTitle = dv[i][XDataName].ToString();
                        //xTitle = GetNewString(xTitle, num, "\n");
                        ax.ValueLabels.Add(i, xTitle);
                        //string data1=dv[i][countColumns].ToString();
                    }
                    //ax.TickLabels = TickLabelsEnum.High;
                    Axis ay = c1Chart1.ChartArea.AxisY;
                    //if(!string.IsNullOrEmpty(YDanWei))
                    //{
                    //    for (int i = 0; i < ay.; i++)
                    //    {
                    //        string yValue = ay.ValueLabels[0].ToString() + YDanWei;
                    //        ay.ValueLabels.Add(i,yValue);
                    //    }
                    //}
                    //ay.TickMinor = TickMarksEnum.None;
                    ay.GridMajor.Visible = true;
                    ay.GridMajor.Color = Color.White;
                    ay.Min = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetBarCharts(DataTable dt, string XDataName, string[] YCols)
        {
            for (int GroupIndex = 0; GroupIndex < 2; GroupIndex++)
            {
                try
                {
                    DataView dv = dt.DefaultView;
                    int countColumns = YCols.Length;          //多少列 ；第一列未x坐标值 ；其他为数据
                    int countRows = dt.Rows.Count;

                    PointF[][] data = new PointF[countColumns][]; //视图的数据 

                    for (int i = 0; i < countColumns; i++)
                    {
                        data[i] = new PointF[countRows];
                    }
                    //各列对应的数据
                    for (int j = 0; j < countColumns; j++)
                    {
                        for (int i = 0; i < countRows; i++)
                        {
                            string data1 = "0";
                            if (i == GroupIndex)
                            {
                                data1 = dv[i][YCols[j]].ToString();
                            }
                            float y = float.Parse(data1);
                            data[j][i] = new PointF(i, y);
                        }
                    }
                    //绑定数据 
                    ChartDataSeriesCollection collSeries = c1Chart1.ChartGroups[GroupIndex].ChartData.SeriesList;
                    collSeries.Clear();

                    for (int i = 0; i < countColumns; i++) //如果是双条,则显示   
                    {
                        ChartDataSeries series = collSeries.AddNewSeries();
                        series.PointData.CopyDataIn(data[i]);
                        series.FitType = C1.Win.C1Chart.FitTypeEnum.Line;
                        series.Label = dt.Columns[YCols[i]].ColumnName + dt.Rows[GroupIndex][XDataName];
                    }
                    //for (int i = 0; i < countColumns; i++) //如果是双条,则显示   
                    //{
                    //    //lend，对三种颜色Bar块的描述 
                    //    c1Chart1.ChartGroups[0].ChartData.SeriesList[i].Label = dt.Columns[YCol[i]].ColumnName.Replace("时间", "");
                    //}

                    ChartDataSeriesCollection dscoll = c1Chart1.ChartGroups[GroupIndex].ChartData.SeriesList;                //dscoll.Remove(c1Chart1.ChartGroups[0].ChartData.SeriesList[3]);
                    if (GroupIndex == 0)
                    {
                        c1Chart1.ChartLabels.LabelsCollection.Clear();
                    }

                    for (int i = 0; i < dscoll.Count; i++)
                    {
                        ChartDataSeries series = dscoll[i];
                        for (int j = 0; j < dv.Count; j++)
                        {
                            //加标签,在Bar块上面显示数据
                            C1.Win.C1Chart.Label lbl = c1Chart1.ChartLabels.LabelsCollection.AddNewLabel();
                            string data1 = dv[j][YCols[i]].ToString();
                            if (!string.IsNullOrEmpty(data1))
                            {
                                float y = float.Parse(data1);
                                lbl.Text = string.Format("{0}", y);
                            }
                            lbl.Compass = LabelCompassEnum.North;
                            //lbl.Style.BackColor = Color.Brown;
                            lbl.Style.ForeColor = Color.Blue;
                            lbl.Offset = 10;
                            lbl.Connected = false;
                            lbl.Visible = true;
                            lbl.AttachMethod = AttachMethodEnum.DataIndex;
                            AttachMethodData am = lbl.AttachMethodData;
                            am.GroupIndex = GroupIndex;  //0
                            am.SeriesIndex = i; //i
                            am.PointIndex = j;  //0 
                        }
                    }
                    if (GroupIndex == 0)
                    {
                        //显示X轴标签 
                        Axis ax = c1Chart1.ChartArea.AxisX;
                        //ax.Min = 10;
                        ax.TickMinor = TickMarksEnum.None;
                        ax.ValueLabels.Clear();
                        ax.AnnoMethod = AnnotationMethodEnum.ValueLabels;
                        int num = 15 - dv.Count;
                        if (num < 1)
                        {
                            num = 1;
                        }
                        for (int i = 0; i < dv.Count; i++)
                        {
                            string xTitle = dv[i][XDataName].ToString();
                            //xTitle = GetNewString(xTitle, num, "\n");
                            ax.ValueLabels.Add(i, xTitle);
                            //string data1=dv[i][countColumns].ToString();
                        }
                        //ax.TickLabels = TickLabelsEnum.High;
                        Axis ay = c1Chart1.ChartArea.AxisY;
                        ay.GridMajor.Visible = true;
                        ay.GridMajor.Color = Color.White;
                        ay.Min = 0;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private void GetLineChart(DataTable dt, string XDataName, string[] YCols, int Groupindex)
        {
            try
            {
                DataView dv = dt.DefaultView;
                int countColumns = YCols.Length;          //多少列 ；第一列未x坐标值 ；其他为数据
                int countRows = dt.Rows.Count;

                PointF[][] data = new PointF[countColumns][]; //视图的数据 

                for (int i = 0; i < countColumns; i++)
                {
                    data[i] = new PointF[countRows];
                }
                //各列对应的数据
                for (int j = 0; j < countColumns; j++)
                {
                    for (int i = 0; i < countRows; i++)
                    {
                        string data1 = dv[i][YCols[j]].ToString().Replace("天", "").Trim();
                        float y = 0;
                        if (!string.IsNullOrEmpty(data1))
                        {
                            y = float.Parse(data1);
                        }
                        data[j][i] = new PointF(i, y);
                    }
                }
                //绑定数据  
                ChartDataSeriesCollection collSeries = c1Chart1.ChartGroups[Groupindex].ChartData.SeriesList;

                collSeries.Clear();

                for (int i = 0; i < countColumns; i++) //如果是双条,则显示   
                {
                    ChartDataSeries series = collSeries.AddNewSeries();
                    series.PointData.CopyDataIn(data[i]);
                    series.FitType = C1.Win.C1Chart.FitTypeEnum.Line;
                    series.LineStyle.Pattern = LinePatternEnum.Solid;
                    //series.Label = dt.Columns[i].ColumnName;
                }
                for (int i = 0; i < countColumns; i++) //如果是双条,则显示   
                {
                    //lend，对三种颜色Bar块的描述 
                    c1Chart1.ChartGroups[Groupindex].ChartData.SeriesList[i].Label = YCols[i];
                }

                ChartDataSeriesCollection dscoll = c1Chart1.ChartGroups[Groupindex].ChartData.SeriesList;                //dscoll.Remove(c1Chart1.ChartGroups[0].ChartData.SeriesList[3]);
                if (Groupindex == 0)
                {
                    c1Chart1.ChartLabels.LabelsCollection.Clear();
                }
                for (int i = 0; i < dscoll.Count; i++)
                {
                    ChartDataSeries series = dscoll[i];
                    for (int j = 0; j < dv.Count; j++)
                    {
                        //加标签,在Bar块上面显示数据
                        C1.Win.C1Chart.Label lbl = c1Chart1.ChartLabels.LabelsCollection.AddNewLabel();
                        string data1 = dv[j][YCols[i]].ToString().Replace("天", "").Trim();
                        if (!string.IsNullOrEmpty(data1))
                        {
                            lbl.Text = string.Format("{0}", float.Parse(data1));
                        }

                        lbl.Compass = LabelCompassEnum.North;
                        //lbl.Style.BackColor = Color.Brown;
                        lbl.Style.ForeColor = Color.Blue;
                        lbl.Offset = 10;
                        lbl.Connected = false;
                        lbl.Visible = true;
                        lbl.AttachMethod = AttachMethodEnum.DataIndex;
                        AttachMethodData am = lbl.AttachMethodData;
                        am.GroupIndex = Groupindex;  //0
                        am.SeriesIndex = i; //i
                        am.PointIndex = j;  //0 

                    }
                }
                if (Groupindex == 0)
                {
                    //显示X轴标签 
                    Axis ax = c1Chart1.ChartArea.AxisX;
                    //ax.Min = 10;
                    ax.TickMinor = TickMarksEnum.None;
                    ax.ValueLabels.Clear();
                    ax.AnnoMethod = AnnotationMethodEnum.ValueLabels;
                    for (int i = 0; i < dv.Count; i++)
                    {
                        ax.ValueLabels.Add(i, dv[i][XDataName].ToString());
                    }
                    //ax.TickLabels = TickLabelsEnum.High;
                    Axis ay = c1Chart1.ChartArea.AxisY;
                    //ay.TickMinor = TickMarksEnum.None;
                    ay.GridMajor.Visible = true;
                    ay.GridMajor.Color = Color.White;
                    ay.Min = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            if (CurrentDS != null)
            {
                DataTableToExcel(CurrentDS.Tables[0]);
            }
        }

        /// <summary>
        /// DataTable数据导出Excel
        /// </summary>
        /// <param name="datatable"></param>
        public void DataTableToExcel(DataTable datatable)
        {
            if (datatable == null)
            {
                return;
            }
            SaveFileDialog kk = new SaveFileDialog();
            kk.Title = "保存EXECL文件";
            kk.Filter = "EXECL文件(*.xls) |*.xls |所有文件(*.*) |*.*";
            kk.FilterIndex = 1;
            if (kk.ShowDialog() == DialogResult.OK)
            {
                string FileName = kk.FileName;
                if (File.Exists(FileName))
                    File.Delete(FileName);
                FileStream objFileStream;
                StreamWriter objStreamWriter;
                string strLine = "";
                objFileStream = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
                objStreamWriter = new StreamWriter(objFileStream, System.Text.Encoding.Unicode);
                //添加列名称
                for (int i = 0; i < datatable.Columns.Count; i++)
                {
                    strLine = strLine + datatable.Columns[i].ColumnName.ToString() + Convert.ToChar(9);
                }
                objStreamWriter.WriteLine(strLine);
                strLine = "";
                //添加内容
                for (int i = 0; i < datatable.Rows.Count; i++)
                {
                    for (int j = 0; j < datatable.Columns.Count; j++)
                    {

                        if (String.IsNullOrEmpty(datatable.Rows[i][j].ToString()))
                            strLine = strLine + " " + Convert.ToChar(9);
                        else
                        {
                            string rowstr = "";
                            rowstr = datatable.Rows[i][j].ToString();
                            if (rowstr.IndexOf("\r\n") > 0)
                                rowstr = rowstr.Replace("\r\n", " ");
                            if (rowstr.IndexOf("\t") > 0)
                                rowstr = rowstr.Replace("\t", " ");
                            strLine = strLine + rowstr + Convert.ToChar(9);
                        }

                    }
                    objStreamWriter.WriteLine(strLine);
                    strLine = "";
                }
                objStreamWriter.Close();
                objFileStream.Close();
                MessageBox.Show(this, "保存EXCEL成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog1 = new PrintDialog();
            PrintDocument printDocument2 = new PrintDocument();
            Margins marg = new Margins(20, 20, 20, 20);
            printDocument2.DefaultPageSettings.Margins = marg;
            printDocument2.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
            printDialog1.AllowSomePages = true;
            printDialog1.ShowHelp = true;
            printDialog1.Document = printDocument2;

            DialogResult Rest = printDialog1.ShowDialog();
            if (Rest == DialogResult.OK)
            {
                printDocument2.Print();
            }
        }

        void pd_PrintPage(object sender, PrintPageEventArgs e)
        {

            Image curImage = c1Chart1.GetImage();
            if (curImage != null)
            {
                Graphics g = Graphics.FromImage(curImage);

                g.DrawImage(curImage, 100, 100, curImage.Width, curImage.Height);
            }
        }
    }
}