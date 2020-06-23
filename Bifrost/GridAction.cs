using System;
using DevComponents.DotNetBar.Controls;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using DevComponents.DotNetBar.Rendering;
using System.Collections.Generic;

namespace Bifrost
{
    public class GridAction
    {
        static List<Control> Grids = new List<Control>();

        public static void SetGridStyle(Control grid)
        {
            if (grid is DataGridViewX)
            {
                if (!Grids.Contains(grid))
                {
                    SetGridStyle(grid as DataGridViewX);
                    Grids.Add(grid);
                }
            }
            else if (grid is DataGridView)
            {
                if (!Grids.Contains(grid))
                {
                    SetGridStyle(grid as DataGridView);
                    Grids.Add(grid);
                }
            }
            else if (grid is C1.Win.C1FlexGrid.C1FlexGrid)
            {
                if (!Grids.Contains(grid))
                {
                    SetGridStyle(grid as C1.Win.C1FlexGrid.C1FlexGrid);
                    Grids.Add(grid);
                }
            }
        }

        static void SetGridStyle(DataGridViewX grid)
        {
            grid.DataSourceChanged += Grid_DataSourceChanged;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.ReadOnly = true;
            grid.RowHeadersVisible = false;
            grid.EnableHeadersVisualStyles = false;
            grid.HighlightSelectedColumnHeaders = false;
            grid.ColumnHeadersDefaultCellStyle.Font = captionFont;
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.DefaultCellStyle = DataCellStyle;
            grid.AlternatingRowsDefaultCellStyle = AlternatingRowsDefaultCellStyle;
            grid.AllowUserToResizeColumns = false;
            grid.AllowUserToResizeRows = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.RowsDefaultCellStyle.SelectionBackColor = selectedBackColor;
            //grid.Paint += Grid_Paint;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.RowTemplate.Height = rowHeight;
            grid.ColumnHeadersHeight = headRowHeight;
            grid.BackgroundColor = Color.White;
            if (GlobalManager.Renderer is Office2007Renderer)
            {
                (((Office2007Renderer)GlobalManager.Renderer).ColorTable).ButtonItemColors[0].Checked.Background = new LinearGradientColorTable(Color.FromArgb(200, selectedBackColor), Color.FromArgb(200, selectedBackColor));
            }
        }

        static void SetGridStyle(DataGridView grid)
        {
            grid.DataSourceChanged += Grid_DataSourceChanged;
            grid.RowHeadersVisible = false;
            grid.EnableHeadersVisualStyles = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.ReadOnly = true;
            //grid.HighlightSelectedColumnHeaders = false;
            grid.ColumnHeadersDefaultCellStyle.Font = captionFont;
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.DefaultCellStyle = DataCellStyle;
            grid.AlternatingRowsDefaultCellStyle = AlternatingRowsDefaultCellStyle;
            grid.AllowUserToResizeColumns = false;
            grid.AllowUserToResizeRows = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.RowsDefaultCellStyle.SelectionBackColor = selectedBackColor;
            //grid.Paint += Grid_Paint;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.RowTemplate.Height = rowHeight;
            grid.ColumnHeadersHeight = headRowHeight;
            grid.BackgroundColor = Color.White;
            if (GlobalManager.Renderer is Office2007Renderer)
            {
                (((Office2007Renderer)GlobalManager.Renderer).ColorTable).ButtonItemColors[0].Checked.Background = new LinearGradientColorTable(Color.FromArgb(200, selectedBackColor), Color.FromArgb(200, selectedBackColor));
            }
        }

        private static void Grid_Paint(object sender, PaintEventArgs e)
        {
            var grid = sender as DataGridViewX;
            if (grid != null)
            {
                using (Brush solid = new SolidBrush(Color.FromArgb(180, headerBackColor)))
                {
                    e.Graphics.FillRectangle(solid, 0, 0, grid.Columns.GetColumnsWidth(DataGridViewElementStates.Visible), grid.ColumnHeadersHeight);
                }
            }
        }

        static void SetColoumns(DataGridView grid)
        {
            if (grid != null)
            {
                if (!(grid.DataSource is System.Data.DataView))
                {
                    grid.Columns.Cast<DataGridViewColumn>().ToList().ForEach(o =>
                    {
                        o.SortMode = DataGridViewColumnSortMode.NotSortable;
                        //o.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    });
                }
            }
        }

        static Font dataFont = new Font("宋体", 9);

        static Font captionFont = new Font("宋体", 9, FontStyle.Bold);

        static Color dataBackColor1 = Color.FromArgb(238, 238, 238);

        static Color dataBackColor2 = Color.White;

        static Color headerBackColor = ColorTranslator.FromHtml("#42B3E5");

        //static Color headerBackColor = Color.FromArgb(255, 250, 250);

        static Color selectedBackColor = Color.FromArgb(23, 80, 130);
        //static Color selectedBackColor = Color.White;

        /// <summary>
        /// 数据行高
        /// </summary>
        static int rowHeight = 23;

        /// <summary>
        /// 表头行高
        /// </summary>
        static int headRowHeight = 30;

        private static void Grid_DataSourceChanged(object sender, EventArgs e)
        {
            DataGridViewX grid = sender as DataGridViewX;
            SetColoumns(grid);
            //grid?.AutoResizeColumns();
        }

        static DataGridViewCellStyle HeaderCellStyle = new DataGridViewCellStyle()
        {
            Font = new Font("宋体", 10, FontStyle.Bold),
            //BackColor = Color.FromArgb(100, headerBackColor),
            //ForeColor = Color.FromArgb(0, 104, 183),
            //SelectionBackColor = ColorTranslator.FromHtml("#E8F4FF"),
            Alignment = DataGridViewContentAlignment.MiddleCenter
        };

        static DataGridViewCellStyle DataCellStyle = new DataGridViewCellStyle()
        {
            Font = dataFont,
            //BackColor = dataBackColor2,
            //SelectionBackColor = ColorTranslator.FromHtml("#E8F4FF"),
            //SelectionBackColor = Color.Red,
            //SelectionForeColor= Color.FromArgb(0, 104, 183),
            BackColor = dataBackColor2
            //,
            //Alignment = DataGridViewContentAlignment.MiddleLeft
        };

        static DataGridViewCellStyle AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle()
        {
            Font = dataFont,
            BackColor = dataBackColor1
            //,
            //Alignment = DataGridViewContentAlignment.MiddleLeft
        };

        static void SetGridStyle(C1.Win.C1FlexGrid.C1FlexGrid grid)
        {
            grid.AfterDataRefresh += Grid_AfterDataRefresh;
            grid.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
        }


        private static void Grid_AfterDataRefresh(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            C1.Win.C1FlexGrid.C1FlexGrid grid = sender as C1.Win.C1FlexGrid.C1FlexGrid;
            //grid.SelChange += Grid_SelChange;
            if (grid != null)
            {
                grid.Cols.Cast<C1.Win.C1FlexGrid.Column>()
                       .ToList()
                       .ForEach(o =>
                       {
                           if (string.IsNullOrEmpty(o.Caption) || o.Caption.ToUpper().Equals("RN"))
                               o.Visible = false;
                           else
                           {
                               o.TextAlignFixed = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
                               if (o.DataType == typeof(bool))
                                   o.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
                               else
                                   o.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.LeftCenter;
                               o.StyleFixed.Font = captionFont;
                               o.Style.Font = dataFont;
                           }
                       });
                grid.Rows.Cast<C1.Win.C1FlexGrid.Row>()
                    .ToList()
                    .ForEach(o =>
                    {
                        if (o.Index < grid.Rows.Fixed)
                            o.Height = headRowHeight;
                        else
                        {
                            if (o.Index % 2 == 0)
                                o.StyleNew.BackColor = dataBackColor1;
                            else
                                o.StyleNew.BackColor = dataBackColor2;
                            o.Height = rowHeight;
                        }
                    });
            }

        }
    }

    //public class GridCol
    //{
    //    public string Name { get; set; }

    //    public string Caption { get; set; }
    //}
}
