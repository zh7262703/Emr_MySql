using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using C1.Win.C1Chart;

namespace Base_Function.EMERGENCY
{
    public partial class frmZXT : DevComponents.DotNetBar.Office2007Form
    {
        public frmZXT(DataTable dt)
        {
            InitializeComponent();
            SetChart(dt);
        }

        void SetChart(DataTable table1)
        {

            try
            {
                c1Chart1.Reset();
                c1Chart1.ChartLabels.LabelsCollection.Clear();
                c1Chart1.ChartArea.AxisX.ValueLabels.Clear();
                c1Chart1.ChartArea.AxisX.Text = "日期";
                c1Chart1.ChartArea.AxisY.Text = "数值";
                c1Chart1.Legend.Visible = false;
                c1Chart1.Legend.Orientation = LegendOrientationEnum.Auto;
                c1Chart1.Legend.Text = "平均时间(分)";
                c1Chart1.Legend.Style.Border.BorderStyle = BorderStyleEnum.Solid;
                //c1Chart1.ChartGroups.Group0.ChartType = Chart2DTypeEnum.Area;
                c1Chart1.ChartGroups[0].ChartData.SeriesList.Clear();

                if (table1 != null)
                {

                    DataTable objTable = table1;

                    if (objTable == null)
                        return;
                    //非饼图的数据加载

                    for (int j = 1; j < objTable.Columns.Count; j++)
                    {
                        //if (j > 1)
                        //    continue;

                        ChartDataSeries tval = new ChartDataSeries();
                        c1Chart1.ChartArea.AxisX.AnnoMethod = C1.Win.C1Chart.AnnotationMethodEnum.ValueLabels;
                        tval.DataLabel.Visible = true;
                        tval.Label = objTable.Columns[j].ColumnName;
                        for (int i = 0; i < objTable.Rows.Count; i++)
                        {
                            float fvalue = 0;
                            float.TryParse(objTable.Rows[i][j].ToString(), out fvalue);
                            tval.PointData.Add(new PointF(i, fvalue));
                            #region 具体每一项的值显示
                            C1.Win.C1Chart.Label lab = c1Chart1.ChartLabels.LabelsCollection.AddNewLabel();
                            lab.AttachMethod = AttachMethodEnum.DataIndex;
                            AttachMethodData amd = lab.AttachMethodData;
                            amd.GroupIndex = 0;
                            amd.PointIndex = i;
                            amd.SeriesIndex = j - 1; //数据集的索引
                            lab.Text = objTable.Rows[i][j].ToString(); //标签值
                            //lab.Visible = chklabVisable.Checked;
                            lab.Visible = true;
                            lab.Compass = LabelCompassEnum.NorthEast; //值显示的位置
                            lab.Connected = false;
                            lab.Offset = 20; //值显示的位置的偏移量
                            lab.TooltipText = objTable.Columns[j].ColumnName + "：" + lab.Text;
                            #endregion
                            if (j == 1)
                            {
                                //X轴中的内容标签
                                ValueLabel vlbl = new ValueLabel();
                                vlbl.NumericValue = i;
                                vlbl.Text = objTable.Rows[i]["月份"].ToString() + "月";
                                c1Chart1.ChartArea.AxisX.ValueLabels.Add(vlbl);
                            }
                        }
                        c1Chart1.ChartGroups[0].ChartData.SeriesList.Add(tval);
                    }
                }
            }
            catch (Exception ex) { ex.Message.ToString(); }
        }

        private void frmZXT_Load(object sender, EventArgs e)
        {

        }
    }
}