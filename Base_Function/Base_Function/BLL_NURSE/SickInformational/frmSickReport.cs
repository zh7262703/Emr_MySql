using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_NURSE.SickInformational
{
    /// <summary>
    /// ���Ӱ��¼
    /// </summary>
    /// ���� ��ΰ
    /// ʱ�� 2010��9��14��
    public partial class frmSickReport : DevComponents.DotNetBar.Office2007Form
    {
        ucfrmSickReport ucfsrt = new ucfrmSickReport();
        private int RowIndex = 0;    //��¼��Ԫ�������
        private int ColIndex = 0;    //��¼��Ԫ�������
        string ID = "";   //ѡ�е�Ԫ���ID
        public frmSickReport()
        {
            InitializeComponent();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        //private void CurrentDataChange()
        //{
        //    try
        //    {
        //        cfgcentent.Cols["id"].Visible = false;//����ID����
        //        cfgcentent.Cols["id"].AllowEditing = false;
        //        cfgcentent.AllowEditing = false;

        //        cfgcentent.Cols[2].Visible = false;//����ID����
        //        cfgcentent.Cols[2].AllowEditing = false;
        //        cfgcentent.AllowEditing = false;
        //        cfgcentent.AutoSizeCol(2);
        //        cfgcentent.AutoSizeCol(3);
        //        cfgcentent.AutoSizeCol(4);
        //        cfgcentent.AutoSizeCol(5);
        //        SetContent("");
        //        cfgcentent.MergedRanges.Clear();
        //        CellRow();
        //    }
        //    catch (Exception ex)
        //    {
        //        App.MsgErr(ex.Message);
        //    }

        //}

        private void frmSickReport_Load(object sender, EventArgs e)
        {
            string sickID = App.UserAccount.UserInfo.Sickarea_id;
            DataSet sickNames = App.GetDataSet("select sick_area_name from t_sickareainfo where said='" + sickID + "'");
            //cfgcentent.AfterSort-=new C1.Win.C1FlexGrid.SortColEventHandler(cfgcentent_AfterSort);
            this.SickName.Text = sickNames.Tables[0].Rows[0][0].ToString();
            //cfgcentent.RowColChange += new EventHandler(CurrentDataChange);
            //this.nowTime.Text = App.GetSystemTime().ToString("yyyy-MM-dd");
            #region ��������
            ////��ʾ�߽� 
            //tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            //tableLayoutPanel1.BackColor = Color.White;
            ////���ǵ�tableLayoutPanel1.GrowStyle��ÿ��ˢ��ǰ���control 
            //tableLayoutPanel1.Controls.Clear();

            ////��ʾ��=5����=5 
            //tableLayoutPanel1.RowCount = 4;
            //tableLayoutPanel1.ColumnCount = 12;


            //#region �к��д�Сһ��
            //TableLayoutColumnStyleCollection cols = tableLayoutPanel1.ColumnStyles;
            ////cols.Add(RtlTranslateAlignment(ContentAlignment.MiddleCenter));
            //for (int i = 0; i < cols.Count; i++)
            //{
            //    cols[i].SizeType = SizeType.Percent;
            //    cols[i].Width = 100 / cols.Count;
            //}
            //TableLayoutRowStyleCollection rows = tableLayoutPanel1.RowStyles;
            //for (int i = 0; i < rows.Count; i++)
            //{
            //    rows[i].SizeType = SizeType.Percent;
            //    rows[i].Height = 100 / rows.Count;
            //}

            //#endregion


            ////Ϊÿ��Cell���һ���ؼ���������������label�� 
            //for (int i = 0; i < tableLayoutPanel1.ColumnCount; i++)
            //{
            //    for (int j = 0; j < tableLayoutPanel1.RowCount; j++)
            //    {
            //        Label label = new Label();
            //        label.TextAlign = ContentAlignment.MiddleCenter;

            //        //label.Text = "Col:" + i.ToString() + ";Row:" + j.ToString();

            //        tableLayoutPanel1.RowStyles[0] =(RowStyle)Color.Blue;

            //        if (i == 0 && j == 0)
            //            label.Text = "���";
            //        if (i==1 && j==0)
            //            label.Text = "����";
            //        if (i == 2 && j == 0)
            //            label.Text = "��Ժ";
            //        if (i == 3 && j == 0)
            //            label.Text = "ת��";
            //        if (i == 4 && j == 0)
            //            label.Text = "����";
            //        if (i == 5 && j == 0)
            //            label.Text = "��Ժ";
            //        if (i == 6 && j == 0)
            //            label.Text = "ת��";
            //        if (i == 7 && j == 0)
            //            label.Text = "����";
            //        if (i == 8 && j == 0)
            //            label.Text = "��Σ";
            //        if (i == 9 && j == 0)
            //            label.Text = "����";
            //        if (i == 10 && j == 0)
            //            label.Text = "����";
            //        if (i == 11 && j == 0)
            //            label.Text = "������";
            //        if (i == 12 && j == 0)
            //            label.Text = "������";

            //        if (i == 0 && j == 1)
            //            label.Text = "�װ�";
            //        if (i == 1 && j == 1)
            //            label.Text = "";
            //        if (i == 2 && j == 1)
            //            label.Text = "";
            //        if (i == 3 && j == 1)
            //            label.Text = "";
            //        if (i == 4 && j == 1)
            //            label.Text = "";
            //        if (i == 5 && j == 1)
            //            label.Text = "";
            //        if (i == 6 && j == 1)
            //            label.Text = "";
            //        if (i == 7 && j == 1)
            //            label.Text = "";
            //        if (i == 8 && j == 1)
            //            label.Text = "";
            //        if (i == 9 && j == 1)
            //            label.Text = "";
            //        if (i == 10 && j == 1)
            //            label.Text = "";
            //        if (i == 11 && j == 1)
            //            label.Text = "";
            //        if (i == 12 && j == 1)
            //            label.Text = "";

            //        if (i == 0 && j == 2)
            //        {
            //            label.Text = "���";
            //            label.ForeColor = Color.Red;
            //        }
            //        if (i == 1 && j == 2)
            //            label.Text = "";
            //        if (i == 2 && j == 2)
            //            label.Text = "";
            //        if (i == 3 && j == 2)
            //            label.Text = "";
            //        if (i == 4 && j == 2)
            //            label.Text = "";
            //        if (i == 5 && j == 2)
            //            label.Text = "";
            //        if (i == 6 && j == 2)
            //            label.Text = "";
            //        if (i == 7 && j == 2)
            //            label.Text = "";
            //        if (i == 8 && j == 2)
            //            label.Text = "";
            //        if (i == 9 && j == 2)
            //            label.Text = "";
            //        if (i == 10 && j == 2)
            //            label.Text = "";
            //        if (i == 11 && j == 2)
            //            label.Text = "";
            //        if (i == 12 && j == 2)
            //            label.Text = "";

            //        if (i == 0 && j == 3)
            //            label.Text = "24Сʱ";
            //        if (i == 1 && j == 3)
            //            label.Text = "";
            //        if (i == 2 && j == 3)
            //            label.Text = "";
            //        if (i == 3 && j == 3)
            //            label.Text = "";
            //        if (i == 4 && j == 3)
            //            label.Text = "";
            //        if (i == 5 && j == 3)
            //            label.Text = "";
            //        if (i == 6 && j == 3)
            //            label.Text = "";
            //        if (i == 7 && j == 3)
            //            label.Text = "";
            //        if (i == 8 && j == 3)
            //            label.Text = "";
            //        if (i == 9 && j == 3)
            //            label.Text = "";
            //        if (i == 10 && j == 3)
            //            label.Text = "";
            //        if (i == 11 && j == 3)
            //            label.Text = "";
            //        if (i == 12 && j == 3)
            //            label.Text = "";
            //        tableLayoutPanel1.Controls.Add(label, i, j);
            //    }
            //}

            //���ô�С 
            //tableLayoutPanel1.Size = new Size(600, 400);
            //tableLayoutPanel1.Update();   
            #endregion
            SetHand();
            SetContent("");

            //ShowGrid();
        }
        ColumnInfo[] cols = new ColumnInfo[4];
        private void SetHand()
        {
            string tableView = "select * from SICKREPORT_VIEW";
            DataSet ds = App.GetDataSet(tableView);
            if (null != ds && ds.Tables[0].Rows.Count > 0)
            {
                cfgTableHand.DataSource = ds.Tables[0].DefaultView;
            }

        }
        DataSet dssick = null;
        private void SetContent(string data)
        {
            try
            {
                string querySQL = "";

                if (data != "")
                {
                    querySQL = "select a.id as ID, b.name as ����, bed_no as ����, REMARK as �װ�, REMARK as ���, daywork, set_yuanwai_datetime as ���ʱ�� from t_handovers_record a  inner join T_DATA_CODE b on a.actiontype=b.id where " + data + " order by b.name";
                }
                else
                {
                    querySQL = "select a.id as ID, b.name as ����, bed_no as ����, REMARK as �װ�, REMARK as ���, daywork, set_yuanwai_datetime as ���ʱ�� from t_handovers_record a  inner join T_DATA_CODE b on a.actiontype=b.id  order by b.name";
                }
                dssick = App.GetDataSet(querySQL);
                DataTable dt = dssick.Tables[0] as DataTable;
                if (dssick != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr["daywork"].ToString() == "�װ�")
                        {
                            dr[4] = null;
                        }
                        else
                        {
                            dr[3] = null;
                        }
                    }
                }
                if (dssick != null && dssick.Tables[0].Rows.Count > 0)
                {
                    this.cfgcentent.DataSource = dt.DefaultView;
                    cfgcentent.Cols[2].Width = 100;
                    cfgcentent.Cols[3].Width = 100;
                    cfgcentent.Cols[4].Width = 350;
                    cfgcentent.Cols[5].Width = 350;
                    cfgcentent.Cols[6].Width = 200;
                    this.cfgcentent.Cols[2].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
                    this.cfgcentent.Cols[3].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
                    this.cfgcentent.Cols[4].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
                    this.cfgcentent.Cols[5].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
                    this.cfgcentent.Cols[6].TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;


                    cfgcentent.Cols["id"].Visible = false;//����ID����
                    cfgcentent.Cols["id"].AllowEditing = false;

                    cfgcentent.Cols["daywork"].Visible = false;//����ID����
                    cfgcentent.Cols["daywork"].AllowEditing = false;
                    CellRow();
                }
                else
                {
                    cfgcentent.DataSource = null;
                }
            }
            catch
            {
            }
        }
        private void CellRow()
        {
            this.cfgcentent.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;//��ʾ��cfgcentent�ؼ��Զ���

            string oldName = "";//��һ�ε���������
            int rows = 0;//��¼��һ�ε�����
            int count = 0;//��¼�������ͬ����������
            for (int i = 0; i < cfgcentent.Rows.Count - 1; i++)
            {

            }
            for (int i = 1; i < cfgcentent.Rows.Count; i++)
            {

                if (cfgcentent.Rows[i]["����"].ToString() == oldName)//�жϵ�ǰ��κ���һ�ε�����������Ƿ���ͬ
                {
                    count++;//�������ͬ�ľ�count+1
                    if (count == 1)
                    {
                        rows = i - 1;//�����Ҫ�ϲ��ģ�ֵ����ͬ�ģ�����һ�ε�������¼
                    }
                }
                else
                {
                    if (count > 0)
                    {
                        C1.Win.C1FlexGrid.CellRange cr = cfgcentent.GetCellRange(rows, 2, i - 1, 2);//�кϲ��ľͺϲ�
                        cfgcentent.MergedRanges.Add(cr);//�ϲ��ĵ�Ԫ��
                        count = 0;
                        rows = 0;
                    }
                }
                oldName = cfgcentent.Rows[i]["����"].ToString();
            }
            if (count > 0)
            {
                C1.Win.C1FlexGrid.CellRange cr = cfgcentent.GetCellRange(rows, 2, cfgcentent.Rows.Count - 1, 2);
                cfgcentent.MergedRanges.Add(cr);
            }

        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cfgcentent_AfterSort(object sender, C1.Win.C1FlexGrid.SortColEventArgs e)
        {

            cfgcentent.MergedRanges.Clear();
            //SetContent();
            CellRow();
        }

        private void btnDay_Click(object sender, EventArgs e)
        {
            if (App.UserAccount.CurrentSelectRole.Sickarea_Id == "")
            {
                App.MsgErr("����¼���ʺ��޲�����Ϣ!");
                return;
            }
            else
            {
                string baiban = "�װ�";
                AddSickTeport addsick = new AddSickTeport(ucfsrt, baiban);
                addsick.ShowDialog();
            }


        }

        public void refreshLoad()
        {
            cfgcentent.MergedRanges.Clear();
            SetContent("");
            SetHand();
        }

        private void btnnight_Click(object sender, EventArgs e)
        {
            if (App.UserAccount.CurrentSelectRole.Sickarea_Id == "")
            {
                App.MsgErr("����¼���ʺ��޲�����Ϣ!");
                return;
            }
            else
            {
                string baiban = "���";
                AddSickTeport addsick = new AddSickTeport(ucfsrt, baiban);
                addsick.ShowDialog();
            }

        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            //"select a.id, b.name as ����, bed_no as ����, REMARK as �װ�, REMARK as ���, daywork from t_handovers_record a  inner join T_DATA_CODE b on a.actiontype=b.id where '" + data + "' order by b.name";
            string sql = " set_yuanwai_datetime like '%" + this.PKdateTime.Text + "%' ";
            SetContent(sql);

        }

        private void DeleteSick()
        {
            if (cfgcentent.RowSel >= 0)
            {
                ID = cfgcentent[cfgcentent.RowSel, 1].ToString();
                string deleteSQL = "delete t_handovers_record where id='" + ID + "'";
                try
                {
                    if (App.Ask("��ȷ��Ҫɾ����"))
                    {
                        App.ExecuteSQL(deleteSQL);
                        //btnQuery_Click(sender, e);
                        refreshLoad();
                    }
                    else
                    {
                    }
                }
                catch (Exception ex)
                {
                    App.MsgErr("������Ϣ��" + ex.Message);
                }
            }

        }

        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteSick();
        }

        private void UpdateSick()
        {
            ID = cfgcentent[cfgcentent.RowSel, 1].ToString();
            string deleteSQL = "update t_handovers_record set REMARK='" + cfgcentent[cfgcentent.RowSel, cfgcentent.ColSel].ToString() + "' where id='" + ID + "'";
            try
            {
                if (App.Ask("ֵ���޸�,�Ƿ񱣴棿"))
                {
                    App.ExecuteSQL(deleteSQL);
                    //btnQuery_Click(sender, e);
                    refreshLoad();
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
                App.MsgErr("������Ϣ��" + ex.Message);
            }
        }
        private string SelectCellVal = "��ֵ";
        private void �޸�ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateSick();
        }

        private void cfgcentent_Click(object sender, EventArgs e)
        {
            //SelectCellVal = cfgcentent[cfgcentent.RowSel, cfgcentent.ColSel].ToString();
            if (selRow > 0)
            {
                if (cfgcentent.RowSel >= 0)
                {
                    string aa = cfgcentent[RowIndex, ColIndex].ToString();
                    if (SelectCellVal != aa && SelectCellVal != "��ֵ")
                    {
                        if (App.Ask("��Ԫ���е�ֵ�Ѿ����޸Ĺ����Ƿ񱣴棿"))
                        {
                            ID = cfgcentent[RowIndex, 1].ToString();
                            string deleteSQL = "update t_handovers_record set REMARK='" + aa + "' where id='" + ID + "'";
                            try
                            {
                                App.ExecuteSQL(deleteSQL);
                                if (App.ExecuteSQL(deleteSQL) > 0)
                                {
                                    App.Msg("�����ѳɹ���");
                                    refreshLoad();
                                }
                            }
                            catch (Exception ex)
                            {
                                App.MsgErr("������Ϣ��" + ex.Message);
                            }
                        }
                    }
                    SelectCellVal = "��ֵ";
                }

            }
        }
        int selRow = 0;
        private void cfgcentent_DoubleClick(object sender, EventArgs e)
        {
            selRow = 1;
            if (cfgcentent.RowSel >= 0)
            {
                SelectCellVal = cfgcentent[cfgcentent.RowSel, cfgcentent.ColSel].ToString();
                RowIndex = cfgcentent.RowSel;
                ColIndex = cfgcentent.ColSel;
            }
        }
        private void cfgTableHand_DoubleClick(object sender, EventArgs e)
        {
            cfgTableHand.AllowEditing = false;
        }

        private void cfgTableHand_Click(object sender, EventArgs e)
        {
            cfgTableHand.AllowEditing = false;
        }
    }
}