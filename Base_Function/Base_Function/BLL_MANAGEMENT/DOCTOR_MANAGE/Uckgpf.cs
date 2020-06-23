using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using System.Windows.Forms.VisualStyles;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Reflection;

namespace Base_Function.BLL_MANAGEMENT.DOCTOR_MANAGE
{
    public partial class Uckgpf : UserControl
    {
        public Uckgpf()
        {
            InitializeComponent();
        }

        private void Uckgpf_Load(object sender, EventArgs e)
        {
            ucGridviewX1.fg.CellDoubleClick += new DataGridViewCellEventHandler(fg_CellDoubleClick);
            DataBindSection();
        }

        void fg_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (ucGridviewX1.fg.CurrentRow.Index >= 0)
                {
                    if (ucGridviewX1.fg.CurrentCell.Value.ToString().Contains("扣分明细"))
                    {
                        string patient_id = ucGridviewX1.fg.CurrentRow.Cells["id"].Value.ToString();
                        FrmkgpfDetail frmkgpf = new FrmkgpfDetail(patient_id);
                        frmkgpf.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void Select(string strswitch)
        {
            string sql = "select * from record_grade_detail t"+strswitch;
            DataSet ds = App.GetDataSet(sql);
            if (ds != null)
            {
                ucGridviewX1.DataBd(sql, "id", "", "");
                ucGridviewX1.fg.Columns["section_id"].Visible = false;
                ucGridviewX1.fg.Columns["id"].Visible = false;
                ucGridviewX1.fg.Columns["sick_area_id"].Visible = false;
                ucGridviewX1.fg.Columns["科室"].Width = 150;
                ucGridviewX1.fg.Columns["病区"].Width = 150;
                ucGridviewX1.fg.Columns["扣分明细"].DefaultCellStyle.ForeColor = Color.Blue;
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string strswtich = GetSwitch();
            Select(strswtich);
        }

        private void chbIn_Time_CheckedChanged(object sender, EventArgs e)
        {
      
        }

        private void chbLeave_Time_CheckedChanged(object sender, EventArgs e)
        {
            if (chbLeave_Time.Checked)
            {
                panel2.Enabled = true;
            }
            else
            {
                panel2.Enabled = false;
            }
        }
        private void DataBindSection()
        {
            try
            {
                string sql = "select a.sid,section_name from t_sectioninfo a inner join t_section_area b on a.sid=b.sid";
                DataSet ds = App.GetDataSet(sql);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    DataRow row = dt.NewRow();
                    row[0] = "0";
                    row[1] = "全院";
                    dt.Rows.InsertAt(row, 0);
                    cboSickArea.DataSource = dt;
                    cboSickArea.DisplayMember = "section_name";
                    cboSickArea.ValueMember = "sid";
                    cboSickArea.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {

                App.MsgErr("绑定科室错误！"+ex.Message);
            }
        }
        /// <summary>
        /// 获取查询条件
        /// </summary>
        /// <returns></returns>
        private string GetSwitch()
        {
            string strswitchs = "  where t.所得总分 between " + txtMin.Text.Trim() + " and " + txtMax.Text.Trim() + " ";
            //出院
            if (chbLeave_Time.Checked)
            {
                strswitchs = strswitchs + " and 出院时间 between to_date('" +
                        dtpOutStart.Value.ToString("yyyy-MM-dd") + "','yyyy-MM-dd') and to_date('" +
                        dtpOutEnd.Value.ToString("yyyy-MM-dd") + "','yyyy-MM-dd')";
            }
            if (!string.IsNullOrEmpty(txtPid.Text.Trim()))
            {
                strswitchs = strswitchs + " and 住院号 like '%" + txtPid.Text.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(txtPatientName.Text.Trim()))
            {
                strswitchs = strswitchs + " and 患者姓名 like '%" + txtPatientName.Text.Trim() + "%'";
            }
            if (cboSickArea.Text != "全院")
            {
                strswitchs = strswitchs + " and 科室='"+cboSickArea.Text+"'";
            }
            if (!string.IsNullOrEmpty(txtDoctor.Text.Trim()))
            {
                strswitchs = strswitchs + " and 管床医生 like '%" + txtDoctor.Text.Trim() + "%'";
            }
            return strswitchs;
        }

        private void txtDoctor_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtDoctor.Text.Trim() != "")
                {
                    if (App.SelectObj != null)
                        if (App.SelectObj.Select_Row != null)
                        {
                            DataRow row = App.SelectObj.Select_Row;
                            txtDoctor.Text = row["姓名"].ToString(); //textName;
                            App.SelectObj = null;
                        }
                }
                else
                {
                    App.HideFastCodeCheck();
                }
            }
            catch
            { }
        }

        private void txtDoctor_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down)
                {
                    App.SelectFastCodeCheck();
                }
                else if (e.KeyCode == Keys.Left)
                {

                }
                else if (e.KeyCode == Keys.Right)
                {

                }
                else if (e.KeyCode == Keys.Escape)
                {
                    App.HideFastCodeCheck();
                }
                else
                {
                    if (!App.FastCodeFlag)
                    {
                        if (txtDoctor.Text.Trim() != "")
                        {
                            App.SelectObj = null;
                            string sql_select = "select distinct(a.user_id) as 序号,a.user_name as 姓名,g.name as 职称,m.section_name as 科室 from t_userinfo a" +
                                                " inner join t_account_user b on a.user_id=b.user_id" +
                                                " inner join t_account c on b.account_id = c.account_id" +
                                                " inner join t_acc_role d on d.account_id = c.account_id" +
                                                " inner join t_role e on e.role_id = d.role_id" +
                                                " inner join t_acc_role_range f on d.id = f.acc_role_id" +
                                                " inner join t_data_code g on g.id=a.u_tech_post" +
                                                " inner join t_sectioninfo m on f.section_id=m.sid" +
                                                " where e.role_type='D' and UPPER(a.shortcut_code) like '" + txtDoctor.Text.ToUpper().Trim() + "%'";
                            App.FastCodeCheck(sql_select, txtDoctor, "姓名", "职称");
                        }
                    }
                    App.FastCodeFlag = false;
                }
            }
            catch
            { }
            finally
            {
                App.FastCodeFlag = false;
            }
        }

        private void btnSecion_Click(object sender, EventArgs e)
        {
            string strSwitchs = GetSwitchTotal();
            string sql = "select section_name 科室,count(-1) 总份数,ROUND（avg(total),2) 平均分," +
                          " sum(case when total>=90 then 1 end) \"甲（份）\"," +
                           " sum(case when total>75 and total <90 then 1 end) \"乙（份）\"," +
                           " sum(case when total<=75 then 1 end) \"丙（份）\" from " +
                           " (select a.*,b.section_name from record_grade_sum a " +
                           " inner join t_in_patient b on a.patient_id=b.id " + strSwitchs + ")" +
                           " group by section_name" +
                           " order by section_name";
            DataTable dt = App.GetDataSet(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                string title = "武汉市第三医院光谷分院" + cboSickArea.Text + "病历质控评分表" +
                                dtpOutStart.Value.ToString("yyyy-MM-dd") + "-" + dtpOutEnd.Value.ToString("yyyy-MM-dd");
                string title2 = "武汉市第三医院光谷分院" + cboSickArea.Text + "病历质控评分表            " +
                                dtpOutStart.Value.ToString("yyyy.MM.dd") + "—" + dtpOutEnd.Value.ToString("yyyy.MM.dd");
                //SaveFileDialog sfg = new SaveFileDialog();
                //sfg.Filter = "Excel 工作薄(.xls)|*.xls";
                //sfg.FileName = title;
                //DialogResult drst = sfg.ShowDialog();
                //if (drst == DialogResult.OK)
                //{
                    //DataTabletoExcel(dt, sfg.FileName, title2);
                    this.Cursor = Cursors.AppStarting;
                    //例如在中文系统下安装的是英文的Office，就需要指定CultureInfo为en-US
                    ExportToExcel(dt, new System.Globalization.CultureInfo("en-US"), title2);
                    this.Cursor = Cursors.Default;
                //}
            }
            else
            {
                App.Msg("未查到数据！");
            }
        }

        private void btnDoctor_Click(object sender, EventArgs e)
        {
            string str = "";
            if (!string.IsNullOrEmpty(txtDoctor.Text.Trim()))
            {
                str = txtDoctor.Text.Trim();
            }
            string strSwitchs = GetSwitchTotal();
            string sql = "select sick_doctor_name 管床医生,count(-1) 总份数,ROUND（avg(total),2) 平均分,"+
                          " sum(case when total>=90 then 1 end) \"甲（份）\","+
                           " sum(case when total>75 and total <90 then 1 end) \"乙（份）\","+
                           " sum(case when total<=75 then 1 end) \"丙（份）\" from "+
                           " (select a.*,b.sick_doctor_name from record_grade_sum a "+
                           " inner join t_in_patient b on a.patient_id=b.id " + strSwitchs + ")" +
                           " group by sick_doctor_name"+
                           " order by sick_doctor_name";
            DataTable dt = App.GetDataSet(sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                string title = "武汉市第三医院光谷分院" + cboSickArea.Text + str + "医师病历质控评分表" +
                                dtpOutStart.Value.ToString("yyyy-MM-dd") + "-" + dtpOutEnd.Value.ToString("yyyy-MM-dd");
                //SaveFileDialog sfg = new SaveFileDialog();
                //sfg.Filter = "Excel 工作薄(.xls)|*.xls";            
                //sfg.FileName = title;
                string title2 = "武汉市第三医院光谷分院" + cboSickArea.Text + str + "医师病历质控评分表            " +
                                dtpOutStart.Value.ToString("yyyy.MM.dd") + "-" + dtpOutEnd.Value.ToString("yyyy.MM.dd");
                //DialogResult drst = sfg.ShowDialog();
                //if (drst == DialogResult.OK)
                //{
                    //DataTabletoExcel(dt, sfg.FileName, title2);
                    this.Cursor = Cursors.AppStarting;
                    //例如在中文系统下安装的是英文的Office，就需要指定CultureInfo为en-US
                    ExportToExcel(dt, new System.Globalization.CultureInfo("en-US"), title2);
                    this.Cursor = Cursors.Default;

                //}
            }
            else
            {
                App.Msg("未查到数据！");
            }
        }
        /// <summary>
        /// 导出ExCel
        /// </summary>
        /// <param name="tmpDataTable"></param>
        /// <param name="strFileName"></param>
        /// <param name="title"></param>
        //private void DataTabletoExcel(System.Data.DataTable tmpDataTable, string strFileName, string title)
        //{
        //    if (tmpDataTable == null)
        //    { return; }
        //    int rowNum = tmpDataTable.Rows.Count;
        //    int columnNum = tmpDataTable.Columns.Count;
        //    int rowIndex = 3;
        //    int columnIndex = 0;
        //    Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
        //    xlApp.DefaultFilePath = "";
        //    xlApp.DisplayAlerts = true;
        //    xlApp.SheetsInNewWorkbook = 1;
        //    Microsoft.Office.Interop.Excel.Workbook xlBook = xlApp.Workbooks.Add(true);
        //    //将大标题导入Excel表第一行  
        //    //xlApp.Cells[1, columnIndex] = title;
        //    Microsoft.Office.Interop.Excel.Range range = xlApp.get_Range(xlApp.Cells[1, 1], xlApp.Cells[2, 6]);
        //    range.MergeCells = true;
        //    range.set_Value(Type.Missing, title);
        //    //自动换行
        //    range.WrapText = true;
        //    range.Font.Bold = true;
        //    range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        //    range.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;

        //    //将DataTable的列名导入Excel表第二行   
        //    foreach (DataColumn dc in tmpDataTable.Columns)
        //    {
        //        columnIndex++;
        //        xlApp.Cells[rowIndex, columnIndex] = dc.ColumnName;
        //    }   //将DataTable中的数据导入Excel中  
        //    for (int i = 0; i < rowNum; i++)
        //    {
        //        rowIndex++;
        //        columnIndex = 0;
        //        for (int j = 0; j < columnNum; j++)
        //        {
        //            columnIndex++;
        //            xlApp.Cells[rowIndex, columnIndex] = tmpDataTable.Rows[i][j].ToString();
        //        }
        //    }
        //    int total = rowNum + 4;
        //    //xlApp.Cells[total, 0] = "总计";
        //    Microsoft.Office.Interop.Excel.Range totalRang1 = xlApp.get_Range("A" + total);
        //    totalRang1.set_Value(Type.Missing, "总计：");
        //    totalRang1.Font.Color = Color.FromArgb(255).ToArgb();
        //    totalRang1.Calculate();

        //    Microsoft.Office.Interop.Excel.Range totalRang = xlApp.get_Range("B" + total);
        //    totalRang.Formula = "=SUM(B4:B" + rowIndex + ")";
        //    totalRang.Font.Color = Color.FromArgb(255).ToArgb();
        //    totalRang.Calculate();

        //    Microsoft.Office.Interop.Excel.Range totalRang2 = xlApp.get_Range("C" + total);
        //    totalRang2.Formula = "=AVERAGE(C4:C" + rowIndex + ")";
        //    totalRang2.Font.Color = Color.FromArgb(255).ToArgb();
        //    totalRang2.Calculate();

        //    Microsoft.Office.Interop.Excel.Range totalRang3 = xlApp.get_Range("D" + total);
        //    totalRang3.Formula = "=SUM(D4:D" + rowIndex + ")";
        //    totalRang3.Font.Color = Color.FromArgb(255).ToArgb();
        //    totalRang3.Calculate();

        //    Microsoft.Office.Interop.Excel.Range totalRang4 = xlApp.get_Range("E" + total);
        //    totalRang4.Formula = "=SUM(E4:E" + rowIndex + ")";
        //    totalRang4.Font.Color = Color.FromArgb(255).ToArgb();
        //    totalRang4.Calculate();

        //    Microsoft.Office.Interop.Excel.Range totalRang5 = xlApp.get_Range("F" + total);
        //    totalRang5.Formula = "=SUM(F4:F" + rowIndex + ")";
        //    totalRang5.Font.Color = Color.FromArgb(255).ToArgb();
        //    totalRang5.Calculate();
        //    xlBook.SaveCopyAs(strFileName);
        //    xlApp.DisplayAlerts = false;
        //    xlBook.Close();
        //    xlApp.Quit();
        //    System.GC.Collect();
        //    KissExcel(xlApp);

        //}
        //[DllImport("user32.dll", CharSet = CharSet.Auto)]
        //public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);
        //private void KissExcel(Microsoft.Office.Interop.Excel.Application xlApp)
        //{
        //    IntPtr ptr = new IntPtr(xlApp.Hwnd);
        //    int k = 0;
        //    GetWindowThreadProcessId(ptr, out k);
        //    Process p = Process.GetProcessById(k);
        //    p.Kill();

        //}
        //private void Test()
        //{
        //    DataTable table = new DataTable();
        //    table.Columns.Add("ID", System.Type.GetType("System.Int32"));
        //    table.Columns.Add("Name", System.Type.GetType("System.String"));
        //    for (int i = 0; i < 22; i++)
        //    {
        //        DataRow row = table.NewRow();
        //        row["ID"] = i;
        //        row["Name"] = "name" + i;
        //        table.Rows.Add(row);
        //    }
        //    try
        //    {
        //        this.Cursor = Cursors.AppStarting;
        //        //例如在中文系统下安装的是英文的Office，就需要指定CultureInfo为en-US
        //        ExportToExcel(table, new System.Globalization.CultureInfo("en-US"),"");
        //        this.Cursor = Cursors.Default;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Exception \n" + ex.Message + "\nStack Trace: \n" + ex.StackTrace.ToString(), "信息提示",
        //                MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

        public void ExportToExcel(System.Data.DataTable table, string filename)
        {
            ExportToExcel(table, System.Globalization.CultureInfo.CurrentCulture, filename);
        }

        public void ExportToExcel(System.Data.DataTable table, System.Globalization.CultureInfo cultureInfoOfOffice,string filename)
        {
            object excel;
            object book;
            object books;
            object sheet;
            object sheets;
            object range;
            object[] parameters;
            Type ExcelType;

            parameters = new object[1];
            //获取Excel类型
            ExcelType = Type.GetTypeFromProgID("Excel.Application");
            excel = Activator.CreateInstance(ExcelType);
           // xlApp.DisplayAlerts = false;
            parameters[0] = false;
            excel.GetType().InvokeMember("DisplayAlerts", BindingFlags.SetProperty, null, excel, parameters);
            //获取workbooks集合
            books = excel.GetType().InvokeMember("Workbooks", BindingFlags.GetProperty, null, excel, null);
            //新增workbook.
            //BUG：自动化 Excel 时出现“格式太旧或是类型库无效”错误
            //http://support.microsoft.com/kb/320369/zh-cn
            //如果满足以下条件，在调用某个 Excel 方法时会收到此错误：
            //* 该方法需要一个 LCID（区域设置标识符）。
            //* 运行的是英语版本的 Excel。但是，计算机的区域设置是针对非英语语言配置的。
            //如果客户端计算机运行的是英语版本的 Excel 并且当前用户的区域设置配置为英语之外的某个语言，则 Excel 将尝试查找针对所配置语言的语言包。
            //如果没有找到所需语言包，则会报告错误。 
            book = books.GetType().InvokeMember("Add", BindingFlags.InvokeMethod, null, books, null, cultureInfoOfOffice);
            //获取worksheets集合
            sheets = book.GetType().InvokeMember("Worksheets", BindingFlags.GetProperty, null, book, null);
            //获取第一个 worksheet.
            parameters = new object[1];
            parameters[0] = 1;
            sheet = sheets.GetType().InvokeMember("Item", BindingFlags.GetProperty, null, sheets, parameters);

           //设置表头
            parameters = new object[1];
            parameters[0] = "A1:F2";
            range = sheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, sheet, parameters);
            parameters = new object[1];
            parameters[0] = filename;
            range.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, range, parameters, cultureInfoOfOffice);

            parameters = new object[1];
            parameters[0] = true;
            range.GetType().InvokeMember("MergeCells", BindingFlags.SetProperty, null, range, parameters, cultureInfoOfOffice);

            parameters = new object[1];
            parameters[0] = true;
            range.GetType().InvokeMember("WrapText", BindingFlags.SetProperty, null, range, parameters, cultureInfoOfOffice);
            //Font f = new System.Drawing.Font("宋体",12f,FontStyle.Bold);
             
            //parameters = new object[1];
            //parameters[0] = f;
            //range.GetType().InvokeMember("Font", BindingFlags.SetProperty, null, range, parameters, cultureInfoOfOffice);

            int rowtotal = table.Rows.Count + 2;
            int coltotal = table.Columns.Count;
            //获取A1单元格所在区域
            object[] header = new Object[coltotal];
            parameters = new object[1];
            parameters[0] = "A3:" + Convert.ToString(Convert.ToChar(64 + coltotal)) + "3";
            range = sheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, sheet, parameters);
            //在A1单元格中填充数据.
            parameters = new object[1];
            for (int i = 0; i < table.Columns.Count; i++)
            {
                header[i] = table.Columns[i].ToString();
            }
            parameters[0] = header;
            range.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, range, parameters, cultureInfoOfOffice);
            parameters = new object[2];
            parameters[0] = "A4:" + Convert.ToString(Convert.ToChar(64 + coltotal)) + (rowtotal + 1).ToString().Trim();
            parameters[1] = Missing.Value;
            range = sheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, sheet, parameters);
            parameters = new object[1];
            Object[,] data = new Object[table.Rows.Count, coltotal];
            Object[] total = new object[coltotal];
            for (int j = 0; j < table.Columns.Count; j++)
            {
                double intsum = 0f;
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    double sums = 0f;
                    double.TryParse(table.Rows[i][j].ToString(), out sums);
                    data[i, j] = table.Rows[i][j].ToString();
                    intsum = intsum + sums;
                }
                if (j == 0)
                {
                    total[j] = "总计：";
                }
                else if (j == 2)//求平均数
                {
                    double dbavg = intsum / table.Rows.Count;
                    total[j] = dbavg;
                }
                else//求和
                {
                    total[j] = intsum;
                }
            }
            parameters[0] = data;
            range.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, range, parameters, cultureInfoOfOffice);

            parameters = new object[2];
            parameters[0] = "A" + (rowtotal+2) + ":" + Convert.ToString(Convert.ToChar(64 + coltotal)) + (rowtotal + 2).ToString().Trim();
            parameters[1] = Missing.Value;
            range = sheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, sheet, parameters);

            parameters = new object[1];
            parameters[0] = total;
            range.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, range, parameters, cultureInfoOfOffice);
            parameters = new object[1];
            //启动 Excel
            parameters[0] = true;
            excel.GetType().InvokeMember("Visible", BindingFlags.SetProperty, null, excel, parameters);
            excel.GetType().InvokeMember("UserControl", BindingFlags.SetProperty, null, excel, parameters);
            parameters = new object[1];

            //parameters[0] = filename;
            //books.GetType().InvokeMember("SaveCopyAs", BindingFlags.InvokeMethod, null, books, parameters);
        }

        /// <summary>
        /// 获取查询条件
        /// </summary>
        /// <returns></returns>
        private string GetSwitchTotal()
        {
            string strswitchs = "  where  b.patient_name like '%" + txtPatientName.Text.Trim() + "%'";
            //出院
            if (chbLeave_Time.Checked)
            {
                strswitchs = strswitchs + " and b.leave_time between to_date('" +
                        dtpOutStart.Value.ToString("yyyy-MM-dd") + "','yyyy-MM-dd') and to_date('" +
                        dtpOutEnd.Value.ToString("yyyy-MM-dd") + "','yyyy-MM-dd')";
            }
            if (!string.IsNullOrEmpty(txtPid.Text.Trim()))
            {
                strswitchs = strswitchs + " and b.pid like '%" + txtPid.Text.Trim() + "%'";
            }
            if (!string.IsNullOrEmpty(txtPatientName.Text.Trim()))
            {
                strswitchs = strswitchs + " and b.patient_name like '%" + txtPatientName.Text.Trim() + "%'";
            }
            if (cboSickArea.Text != "全院")
            {
                strswitchs = strswitchs + " and b.section_name='" + cboSickArea.Text + "'";
            }
            if (!string.IsNullOrEmpty(txtDoctor.Text.Trim()))
            {
                strswitchs = strswitchs + " and b.sick_doctor_name like '%" + txtDoctor.Text.Trim() + "%'";
            }
            return strswitchs;
        }
    }
}
