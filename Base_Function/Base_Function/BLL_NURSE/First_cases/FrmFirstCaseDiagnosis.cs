using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using Bifrost;namespace Base_Function.BLL_NURSE.First_cases
{
    public partial class FrmFirstCaseDiagnosis : DevComponents.DotNetBar.Office2007Form
    {
        InPatientInfo inPatientInfo=null;
        DataTable dtDiag=null;
        //TextBox txt = new TextBox();
        public FrmFirstCaseDiagnosis(InPatientInfo _inPatientInfo)
        {
            InitializeComponent();
            this.KeyPreview = true;
            //this.Controls.Add(txt);
            //txt.Visible = false;
            this.inPatientInfo = _inPatientInfo;
            this.dtDiag = GetDiagData().Tables[0];
            this.dataGridViewX1.DataSource = this.dtDiag;
        }

        /// <summary>
        /// ªÒ»° ◊“≥’Ô∂œ–≈œ¢
        /// </summary>
        /// <returns></returns>
        private DataSet GetDiagData()
        {
            //string sqlDiag = "select a.id,a.patient_id as patientid,a.type typecode,"
            //+ "decode(a.type,'E','√≈’Ô’Ô∂œ','S','À…À÷–∂æº∞Õ‚≤ø“ÚÀÿ','P','≤°¿Ì’Ô∂œ','M','≥ˆ‘∫÷˜“™’Ô∂œ','O','≥ˆ‘∫∆‰À¸’Ô∂œ') as typename,"
            //+ "a.name diagnosename,a.icd10code,a.icd10name,a.incondition,a.pnumber sicknumber "
            //+ " from cover_diagnose a"
            //+ " where a.patient_id=" + inPatientInfo.Id
            //+ " order by type";

            StringBuilder sb = new StringBuilder("select a.typecode,a.typename,a.patientid,");
            sb.Append("b.name diagnosename,b.icd10code,b.incondition,b.pnumber sicknumber,b.TURN_TO turnto,b.is_chinese as ischinese ");
            sb.Append(" from");
            sb.Append("(select 'E' typecode,'√≈’Ô’Ô∂œ' typename," + inPatientInfo.Id + " patientid from cover_diagnose where rownum=1");
            sb.Append(" union");
            sb.Append(" select 'S' typecode,'À…À÷–∂æ' typename," + inPatientInfo.Id + " patientid from cover_diagnose where rownum=1");
            sb.Append(" union");
            sb.Append(" select 'P' typecode,'≤°¿Ì’Ô∂œ' typename," + inPatientInfo.Id + " patientid from cover_diagnose where rownum=1");
            sb.Append(" union");
            sb.Append(" select 'M' typecode,'≥ˆ‘∫÷˜“™’Ô∂œ' typename," + inPatientInfo.Id + " patientid from cover_diagnose where rownum=1");
            sb.Append(" union");
            sb.Append(" select 'O' typecode,'≥ˆ‘∫∆‰À¸’Ô∂œ' typename," + inPatientInfo.Id + " patientid from cover_diagnose where rownum=1) a");
            sb.Append(" left join cover_diagnose b on a.typecode=b.type and b.patient_id=a.patientid");
            sb.Append(" order by decode(a.typecode,'E','1','M','2','O','3','P','4','S','5') asc");
            return App.GetDataSet(sb.ToString());

        }

        private void btnDiagSelect_Click(object sender, EventArgs e)
        {
            if (this.dataGridViewX1.CurrentCell.RowIndex < 0)
            {
                App.Msg("«Îœ»—°‘Ò–Ë“™—°‘ÒÃ·»°’Ô∂œµƒŒª÷√");
                return;
            }
            DataRow curRow = dtDiag.Rows[dataGridViewX1.CurrentCell.RowIndex];
            int rowindex = dataGridViewX1.CurrentCell.RowIndex;
            frmSelDiag fdiag = new frmSelDiag(inPatientInfo);
            if (fdiag.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < fdiag.List.Count; i++)
                {
                    if (i == 0)
                    {
                        curRow["diagnosename"] = fdiag.List[i]["’Ô∂œ√˚≥∆"];
                        curRow["icd10code"] = fdiag.List[i]["±‡¬Î"];
                        continue;
                    }
                    DataRow dr = dtDiag.NewRow();
                    dr["diagnosename"] = fdiag.List[i]["’Ô∂œ√˚≥∆"];
                    dr["icd10code"] = fdiag.List[i]["±‡¬Î"].ToString();
                    dr["patientid"] = curRow["patientid"];
                    dr["typecode"] = curRow["typecode"];
                    dr["typename"] = curRow["typename"];
                    dtDiag.Rows.InsertAt(dr, rowindex + 1);
                    rowindex++;
                }
                for (int i = 0; i < fdiag.Clist.Count; i++)
                {
                    if (i == 0 && fdiag.List.Count == 0)
                    {
                        curRow["diagnosename"] = fdiag.Clist[i]["≤°√˚"];
                        curRow["icd10code"] = fdiag.Clist[i]["±‡¬Î"];
                        continue;
                    }
                    DataRow dr = dtDiag.NewRow();
                    dr["diagnosename"] = fdiag.Clist[i]["≤°√˚"];
                    dr["icd10code"] = fdiag.Clist[i]["±‡¬Î"].ToString();
                    dr["patientid"] = curRow["patientid"];
                    dr["typecode"] = curRow["typecode"];
                    dr["typename"] = curRow["typename"];
                    dtDiag.Rows.InsertAt(dr, rowindex + 1);
                    rowindex++;
                }
            }
        }

        private void btnDiagUp_Click(object sender, EventArgs e)
        {
            DataGridViewRow curRow = this.dataGridViewX1.CurrentRow;
            if (curRow.Cells[0].RowIndex == 0)
            {
                return;
            }
            DataGridViewRow nextRow = this.dataGridViewX1.Rows[curRow.Cells[0].RowIndex - 1];
            if (curRow.Cells["typename"].Value == nextRow.Cells["typename"].Value)
            {
                SwapRows(dtDiag.Rows[curRow.Cells[0].RowIndex], dtDiag.Rows[nextRow.Cells[0].RowIndex]);
            }
            else
            {
                return;
            }
        }

        private void btnDiagDown_Click(object sender, EventArgs e)
        {
            DataGridViewRow curRow = this.dataGridViewX1.CurrentRow;
            if (curRow.Cells[0].RowIndex == dataGridViewX1.Rows.Count - 1)
            {
                return;
            }
            DataGridViewRow nextRow = this.dataGridViewX1.Rows[curRow.Cells[0].RowIndex + 1];
            if (curRow.Cells["typename"].Value == nextRow.Cells["typename"].Value)
            {
                //SwapRows(curRow, nextRow);
                SwapRows(dtDiag.Rows[curRow.Cells[0].RowIndex], dtDiag.Rows[nextRow.Cells[0].RowIndex]);
            }
            else
            {
                return;
            }
        }

        private void SwapRows(DataGridViewRow row1, DataGridViewRow row2)
        {
            for (int i = 0; i < row1.Cells.Count; i++)
            {
                string strTemp = row1.Cells[i].Value.ToString();
                row1.Cells[i].Value = row2.Cells[i].Value;
                row2.Cells[i].Value = strTemp;
            }
        }

        private void SwapRows(DataRow row1, DataRow row2)
        {
            for (int i = 0; i < row1.Table.Columns.Count; i++)
            {
                string strTemp = row1[i].ToString();
                row1[i] = row2[i];
                row2[i] = strTemp;
            }
        }

        private void btnDiagInsert_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.CurrentCell.RowIndex < 0)
            {
                App.Msg("«Î—°‘Ò–Ë“™≤Â»Î’Ô∂œµƒŒª÷√");
                return;
            }
            else
            {
                //DataGridViewRow row=new DataGridViewRow ();
                DataRow row = dtDiag.NewRow();
                DataRow curRow = dtDiag.Rows[this.dataGridViewX1.CurrentCell.RowIndex];
                for (int i = 0; i < dtDiag.Columns.Count; i++)
                {
                    string strColName = dataGridViewX1.Columns[i].Name;
                    switch (strColName)
                    {
                        case "diagnosename":
                        case "icd10code":
                        case "incondition":
                        case "sicknumber":
                            row[strColName] = "";
                            break;
                        default:
                            row[strColName] = curRow[strColName];
                            break;
                    }
                }
                dtDiag.Rows.InsertAt(row, dataGridViewX1.CurrentCell.RowIndex + 1);
                //dataGridViewX1.Rows.Insert(dataGridViewX1.CurrentCell.RowIndex, row);
            }
        }

        private void btnDiagDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.CurrentCell.RowIndex < 0)
            {
                App.Msg("«Î—°‘Ò–Ë“™…æ≥˝µƒ’Ô∂œ");
                return;
            }
            else
            {
                int rowindex = dataGridViewX1.CurrentCell.RowIndex;
                //bool isfirst = false;
                bool istopsame = true;
                bool isbottomsame = true;
                if (rowindex > 0)
                {
                    if (dtDiag.Rows[rowindex]["typename"].ToString() != dtDiag.Rows[rowindex - 1]["typename"].ToString())
                    {
                        istopsame = false;
                    }
                }
                else
                {
                    istopsame = false;
                }
                if (rowindex < dtDiag.Rows.Count - 1)
                {
                    if (dtDiag.Rows[rowindex]["typename"].ToString() != dtDiag.Rows[rowindex + 1]["typename"].ToString())
                    {
                        isbottomsame = false;
                    }
                }
                else
                {
                    isbottomsame = false;
                }
                if (istopsame || isbottomsame)
                {
                    //dtDiag.Rows[dataGridViewX1.CurrentCell.RowIndex].Delete();
                    dtDiag.Rows.RemoveAt(dataGridViewX1.CurrentCell.RowIndex);
                }
                else
                {
                    DataRow curRow = dtDiag.Rows[rowindex];
                    for (int i = 0; i < dtDiag.Columns.Count; i++)
                    {
                        string strColName = dtDiag.Columns[i].ColumnName.ToLower();
                        switch (strColName)
                        {
                            case "diagnosename":
                            case "icd10code":
                            case "incondition":
                            case "sicknumber":
                            case "turnto":
                                curRow[strColName] = "";
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        private void btnCDiagName_Click(object sender, EventArgs e)
        {
            frmCDiagDict frmcdiag = new frmCDiagDict();
            if (this.dataGridViewX1.CurrentCell.RowIndex < 0)
            {
                App.Msg("«Îœ»—°‘Ò––");
            }
            DataRow dr = dtDiag.Rows[this.dataGridViewX1.CurrentCell.RowIndex];
            if (frmcdiag.ShowDialog() == DialogResult.OK)
            {
                dr["diagnosename"] = frmcdiag.Bmname + (frmcdiag.Zhname.Length == 0 ? "" : "-" + frmcdiag.Zhname);
                dr["icd10code"] = frmcdiag.Bmcode;
                dr["ischinese"] = "1";
            }
        }

        private void btnCDiagZH_Click(object sender, EventArgs e)
        {
            string sql_select = "select zh_code ±‡¬Î,zh_name ÷¢∫Ú from T_ZH where rownum<200";
            List<string> oldlist = new List<string>();
            oldlist.Add("zh_name");
            oldlist.Add("zh_code");
            oldlist.Add("py");
            List<string> Newlist = new List<string>();
            Newlist.Add("÷¢∫Ú");
            Newlist.Add("±‡¬Î");
            Newlist.Add("÷¢∫Ú∆¥“Ù");
            Bifrost.frmCode f = new frmCode(sql_select, oldlist, Newlist);
            if (f.ShowDialog() == DialogResult.OK)
            {
                if (App.SelectObj != null)
                {
                    if (App.SelectObj.Select_Row != null)
                    {
                        DataRow row = App.SelectObj.Select_Row;
                        int rowindex = 0;
                        if (this.dataGridViewX1.CurrentCell.RowIndex >= 0)
                        {
                            rowindex = dataGridViewX1.CurrentCell.RowIndex;
                        }
                        else
                        {
                            return;
                        }
                        DataRow objRow = GetDiagData().Tables[0].Rows[rowindex];
                        objRow["diagnosename"] = row["º≤≤°√˚≥∆"].ToString();
                        objRow["icd10code"] = row["º≤≤°±‡¬Î"].ToString();
                        objRow["ischinese"] = "1";
                        App.SelectObj = null;
                    }
                }
            }
        }

        private void dataGridViewX1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex < 0)
            //    return;
            //if (e.ColumnIndex < 0)
            //    return;
            //string strColName = dataGridViewX1.Columns[e.ColumnIndex].Name;
            //string strDiagType = dataGridViewX1.Rows[e.RowIndex].Cells["typecode"].Value.ToString();
            //switch (strColName)
            //{
            //    case "typename":
            //        dataGridViewX1.Columns[strColName].ReadOnly = true;
            //        return;
            //    case "diagnosename":
            //        if (strDiagType == "E" || strDiagType == "M" || strDiagType == "O")
            //        {
            //            dataGridViewX1.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;
            //        }
            //        return;
            //    case "incondition":
            //        if (strDiagType != "M" && strDiagType != "O")
            //        {
            //            dataGridViewX1.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
            //        }
            //        return;
            //    case "sicknumber":
            //        if (strDiagType != "P")
            //        {
            //            dataGridViewX1.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
            //        }
            //        return;
            //    case "turnto":
            //        if (strDiagType != "M")
            //        {
            //            dataGridViewX1.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
            //        }
            //        return;
            //    default:
            //        break;
            //}
        }

        private void dataGridViewX1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //DataGridViewCell cell = this.dataGridViewX1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            //DataGridViewTextBoxCell cell2 = cell as DataGridViewTextBoxCell;
            //Control c = cell2 as Control;
            //for (int i = 0; i < c.Controls.Count; i++)
            //{
            //   txt= c.Controls[i] as TextBox;
            //   if (txt != null)
            //   {

            //   }
            //} 
           
            //Point p = this.dataGridViewX1.PointToScreen(new Point(0, this.dataGridViewX1.Rows[e.RowIndex].Height));
            //txt.Location = p;
            //txt.Width = this.dataGridViewX1.Columns[e.ColumnIndex].Width;
            //txt.Height = this.dataGridViewX1.Rows[e.RowIndex].Height;
            //txt.Visible = true;
            //txt.Text = "text";
        }

        private void dataGridViewX1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //txt.Visible = false;
            //txt.Text = "";
            
        }
        AutoCompleteStringCollection scAutoComplete = new AutoCompleteStringCollection();
        List<int> RowIndexs = new List<int>();
        bool b = false;
        private void dataGridViewX1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (b == false)
            {
                TextBox txt = e.Control as TextBox;
                if (txt != null)
                {
                    txt.AutoCompleteCustomSource = scAutoComplete;
                    txt.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    txt.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    txt.KeyUp += new KeyEventHandler(txt_KeyUp);
                    txt.TextChanged += new EventHandler(txt_TextChanged);
                    txt.PreviewKeyDown += new PreviewKeyDownEventHandler(txt_PreviewKeyDown);
                }
                b = true;
            }
           
            
        }


        void txt_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //TextBox s = sender as TextBox;
            //KeyEventArgs ke = new KeyEventArgs(e.KeyCode);
            //if (e.KeyCode == Keys.Down)
            //{
            //    ke.Handled = true;
            //}
            //else if (e.KeyCode == Keys.Up)
            //{
            //    ke.Handled = true;
            //}
            
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            return base.ProcessDialogKey(keyData);
        }

        void txt_TextChanged(object sender, EventArgs e)
        {
            if (this.dataGridViewX1.CurrentCell.RowIndex < 0)
                return;
            if (this.dataGridViewX1.Columns[this.dataGridViewX1.CurrentCell.ColumnIndex].HeaderText!= "’Ô∂œ√˚≥∆")
                return;
            TextBox textBox = sender as TextBox;
            try
            {
                string text = textBox.Text.Trim();
                if (!string.IsNullOrEmpty(text))
                {
                    if (App.SelectObj != null)
                        if (App.SelectObj.Select_Row != null)
                        {
                            DataRow row = App.SelectObj.Select_Row;
                            this.dataGridViewX1.CurrentRow.Cells["diagnosename"].Value = row["º≤≤°√˚≥∆"].ToString();
                            this.dataGridViewX1.CurrentRow.Cells["icd10code"].Value = row["º≤≤°±‡¬Î"].ToString();
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

        void txt_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.dataGridViewX1.CurrentCell.RowIndex < 0)
                return;
            if (this.dataGridViewX1.Columns[this.dataGridViewX1.CurrentCell.ColumnIndex].HeaderText != "’Ô∂œ√˚≥∆")
                return;
            App.FastCodeFlag = false;
            TextBox txtBox = sender as TextBox;
            txtBox.ImeMode = System.Windows.Forms.ImeMode.Off;
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
                        string text = txtBox.Text.Trim();
                        if (!string.IsNullOrEmpty(text))
                        {
                            App.SelectObj = null;
                            int length = text.Length;
                            //string order = " order by case when substr(shortcut1,0," + length + ")='" + text + "' then 0 else 1 end";
                            string sql_select = "select code º≤≤°±‡¬Î,name º≤≤°√˚≥∆ from diag_def_icd10  where ((upper(shortcut1) like '%" + text.ToUpper()
                                                + "%' AND upper(substr(shortcut1,0," + length + "))='" + text.ToUpper() + "')"
                                                + " or upper(name) like '%" + text.ToUpper() + "%')";
                            //sql_select += order;
                            App.FastCodeCheck(sql_select, txtBox, "º≤≤°√˚≥∆", "º≤≤°±‡¬Î");
                            App.FastCodeFlag = true;

                        }
                    }
                }
            }
            catch
            { }
        }

        private void dataGridViewX1_SelectionChanged(object sender, EventArgs e)
        {
            int rowindex = this.dataGridViewX1.CurrentCell.RowIndex;
            int colindex = this.dataGridViewX1.CurrentCell.ColumnIndex;
            if (rowindex < 0)
                return;
            if (colindex < 0)
                return;
            string strColName = dataGridViewX1.Columns[colindex].Name;
            string strDiagType = dataGridViewX1.Rows[rowindex].Cells["typecode"].Value.ToString();
            switch (strColName)
            {
                case "typename":
                    dataGridViewX1.Columns[strColName].ReadOnly = true;
                    return;
                case "diagnosename":
                    if (strDiagType == "E" || strDiagType == "M" || strDiagType == "O")
                    {
                       this.dataGridViewX1.CurrentCell.ReadOnly = false;
                    }
                    return;
                case "incondition":
                    if (strDiagType != "M" && strDiagType != "O")
                    {
                        this.dataGridViewX1.CurrentCell.ReadOnly = true;
                    }
                    return;
                case "sicknumber":
                    if (strDiagType != "P")
                    {
                        this.dataGridViewX1.CurrentCell.ReadOnly = true;
                    }
                    return;
                case "turnto":
                    if (strDiagType != "M")
                    {
                        this.dataGridViewX1.CurrentCell.ReadOnly = true;
                    }
                    return;
                default:
                    break;
            }
        }
    }
}