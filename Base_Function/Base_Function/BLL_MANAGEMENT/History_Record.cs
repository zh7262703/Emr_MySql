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
using Base_Function.MODEL;

namespace Base_Function.BLL_MANAGEMENT
{
    public partial class History_Record : UserControl
    {
        ColumnInfo[] cols = new ColumnInfo[10];

        ColumnInfo[] colss = new ColumnInfo[13];
        ArrayList Sqls = new ArrayList();
        ArrayList sums = new ArrayList();
        private string see_particulars=null;// ��¼���ֵ����µ�����
        private string see_particulars_nurse=null;// ��¼���ֵ�Σ�ػ����¼������
        private string His_sql = "";

        private string re_sql = "";//���µ���ѯ
        private string co_sql = "";//Σ�ػ����ѯ
        private string rd_sql = "";//���µ�+Σ�ز�ѯ
        
        public History_Record()
        {
            try
            {
                InitializeComponent();
                //���µ���ѯ inner join t_vital_signs sig on sig.pid=t.pid
                re_sql = "select distinct  t.sick_area_id as �������,t.sick_area_name as ����,t.section_id as ���ұ��," +
                            @"t.section_name as ����,t.sick_bed_no as ����,t.patient_name as ��������,t.pid as ������," +
                           @" to_char(t.in_time,'yyyy-mm-dd  hh:mi') as ��Ժʱ��,t.id as ���  from  t_in_patient t " +
                          @" inner join t_inhospital_action tap on  t.id=tap.pid  where t.sick_degree is null and tap.action_state=3";
                //Σ�ز�ѯ
                co_sql = "select distinct  t.sick_area_id as �������,t.sick_area_name as ����,t.section_id as ���ұ��," +
                         @"t.section_name as ����,t.sick_bed_no as ����,t.patient_name as ��������,t.pid as ������," +
                        @" to_char(t.in_time,'yyyy-mm-dd  hh:mi') as ��Ժʱ��,t.id as ���  from t_in_patient t "+
                        @"  inner join t_inhospital_action tap on  t.id=tap.pid where t.sick_degree='��Σ' and tap.action_state=3";

                rd_sql = "select distinct  t.sick_area_id as �������,t.sick_area_name as ����,t.section_id as ���ұ��," +
                         @"t.section_name as ����,t.sick_bed_no as ����,t.patient_name as ��������,t.pid as ������," +
                        @" to_char(t.in_time,'yyyy-mm-dd  hh:mi') as ��Ժʱ��,t.id as ��� from t_in_patient t "+
                        @" inner join t_inhospital_action tap on  t.id=tap.pid  where tap.action_state=3";
            }
            catch
            {
            }
        }
        private void History_Record_Load(object sender, EventArgs e)
        {
            try
            {
                flgView.fg.Click += new EventHandler(flgView_Click);
                ucflgView.fg.MouseDoubleClick += new MouseEventHandler(ucflgView_MouseDoubleClick);
                Sick();
                Section();
                Refurbish();
                //textBox1.Text = "First Line\r\n Second Liner\r\n Third Line";
               lblTime.Text =App.GetSystemTime().ToString("yyyy-MM-dd HH:mm");
                
                //lblTime.Text ="sysdate";//System.App.GetSystemTime().ToString("yyyy-MM-dd HH:mm");
                btnSelete_Click(sender, e);
                ucflgView.fg.AllowEditing = false;
                //flgView.fg.AllowEditing = false;
            }
            catch
            {
            }
        }
   
        //�������Ʋ���
        private void Sick()
        {
            DataSet ds = App.GetDataSet("select * from T_SICKAREAINFO  where ISBELONGTOSECTION='N'");
            cboSick.DataSource = ds.Tables[0].DefaultView;
            cboSick.ValueMember = "SAID";
            cboSick.DisplayMember = "SICK_AREA_NAME";
        }
        //����������
        private void Section()
        {
            DataSet ds = App.GetDataSet("select * from T_SECTIONINFO where ISBELONGTOBIGSECTION='N'");
            cboSections.DataSource = ds.Tables[0].DefaultView;
            cboSections.ValueMember = "SID";
            cboSections.DisplayMember = "SECTION_NAME";
        }
        //private void  dd()
        //{
    
        //        CheckBox bx = new CheckBox();
        //        bx.Visible = true;
        //        bx.Text = "ȫѡ";
        //        flgView.fg.Controls.Add(bx);
        //}
        //private void  cc()
        //{

        //        CheckBox bx1 = new CheckBox();
        //        bx1.Visible = true;
        //        bx1.Text = "��ѡ";
        //        flgView.fg.Controls.Add(bx1);
        //}
        #region
        ////�ж�ʱ��
        ////private void Time()
        ////{
        ////    if (dtpEndTime.Value < dtpStartTime.Value)
        ////    {
        ////        App.Msg("�������ڲ���С����ʼ���ڣ�");
        ////        dtpEndTime.Focus();
        ////        return;
        ////    }
        ////}
        ////���ڲ�ѯ
        //private void RuTime()
        //{
        //    #region
        //    string Start_Admission = dtpStartTime.Value.ToString("yyyy-MM-dd");
        //    string End_Admission = dtpEndTime.Value.ToString("yyyy-MM-dd");
        //    if (chkTime.Checked == true)
        //    {
        //        if (chkTemperture.Checked == true || chkGravenurserecord.Checked == true || chkTemperture.Checked == true && chkGravenurserecord.Checked == true)
        //        {
        //            if (dtpEndTime.Value < dtpStartTime.Value)
        //            {
        //                App.Msg("�������ڲ���С����ʼ���ڣ�");
        //                dtpEndTime.Focus();
        //                return;
        //            }
        //            else
        //            {

        //                //���µ�
        //                if (chkTemperture.Checked == true)
        //                {

        //                    His_sql = re_sql + " and  t.in_time between  to_timestamp( '" + Start_Admission + "','syyyy-mm-dd')  and  to_timestamp('" + End_Admission + "','syyyy-mm-dd') order by t.pid asc ";
        //                }
        //                //Σ�ػ����¼��
        //                if (chkGravenurserecord.Checked == true)
        //                {

        //                    His_sql = co_sql + "  and t.in_time between  to_timestamp( '" + Start_Admission + "','syyyy-mm-dd')  and  to_timestamp('" + End_Admission + "','syyyy-mm-dd') order by t.pid asc";
        //                }
        //                //���µ�+Σ�ػ����¼��
        //                if (chkTemperture.Checked == true && chkGravenurserecord.Checked == true)
        //                {

        //                    His_sql = rd_sql + " and t.sick_degree='��Σ' and t.in_time between  to_timestamp( '" + Start_Admission + "','syyyy-mm-dd')  and  to_timestamp('" + End_Admission + "','syyyy-mm-dd')  or  t.sick_degree is null and  t.in_time between  to_timestamp( '" + Start_Admission + "','syyyy-mm-dd')  and  to_timestamp('" + End_Admission + "','syyyy-mm-dd') order by t.pid asc";
        //                }
        //                if (chkSick.Checked == true && chkTemperture.Checked == true)
        //                {

        //                    His_sql = re_sql + " and  t.in_time between  to_timestamp( '" + Start_Admission + "','syyyy-mm-dd')  and  to_timestamp('" + End_Admission + "','syyyy-mm-dd')  and t.sick_area_id='" + cboSick.SelectedValue + "' order by t.pid asc ";
        //                }
        //                if (chkSection.Checked == true && chkTemperture.Checked == true)
        //                {

        //                    His_sql = re_sql + "  and   t.in_time between  to_timestamp( '" + Start_Admission + "','syyyy-mm-dd')  and  to_timestamp('" + End_Admission + "','syyyy-mm-dd')  and t.section_id='" + cboSections.SelectedValue + "' order by t.pid asc ";
        //                }
        //                if (chkSick.Checked == true && chkGravenurserecord.Checked == true)
        //                {

        //                    His_sql = co_sql + "  and  t.in_time between  to_timestamp( '" + Start_Admission + "','syyyy-mm-dd')  and  to_timestamp('" + End_Admission + "','syyyy-mm-dd')  and t.sick_area_id='" + cboSick.SelectedValue + "' order by t.pid asc";
        //                }
        //                if (chkSection.Checked == true && chkGravenurserecord.Checked == true)
        //                {

        //                    His_sql = co_sql + "  and  t.in_time between  to_timestamp( '" + Start_Admission + "','syyyy-mm-dd')  and  to_timestamp('" + End_Admission + "','syyyy-mm-dd')  and t.section_id='" + cboSections.SelectedValue + "' order by t.pid asc";
        //                }
        //            }
        //        }
        //        else
        //        {
        //            App.Msg("��ѡ���������࣡");
        //        }
        //    #endregion
        //    }
        //}
        ////������ѯ
        //private void SickArae()
        //{
        //    #region
        //    if (chkSick.Checked == true)
        //    {
        //        if (chkTemperture.Checked == true || chkGravenurserecord.Checked == true || chkTemperture.Checked == true && chkGravenurserecord.Checked == true)
        //        {
        //            if (chkTemperture.Checked == true)
        //            {
        //                His_sql = re_sql + "  and  t.sick_area_id='" + cboSick.SelectedValue + "' order by t.pid asc ";
        //                // His_sql = "select t.sick_area_id as �������,t.sick_area_name as ����,t.section_id as ���ұ��,t.section_name as ����,t.sick_bed_no as ����,t.patient_name as ��������,t.pid as ������,to_char(t.in_time,'yyyy-mm-dd  hh:mi') as ��Ժʱ�� from t_in_patient t where t.sick_area_id='" + cboSick.SelectedValue + "'";
        //            }
        //            else if (chkGravenurserecord.Checked == true)
        //            {
        //                His_sql = co_sql + "  and  t.sick_area_id='" + cboSick.SelectedValue + "' order by t.pid asc";
        //            }
        //            if (chkTemperture.Checked == true && chkGravenurserecord.Checked == true)
        //            {

        //                His_sql = rd_sql + " where t.sick_degree='��Σ' and  t.sick_area_id='" + cboSick.SelectedValue + "' or  t.sick_degree is null and  t.sick_area_id='" + cboSick.SelectedValue + "' order by t.pid asc";
        //            }
        //        }
        //        else
        //        {
        //            App.Msg("��ѡ���������࣡");
        //        }
        //    }
        //    #endregion
        //}
        ////���Ҳ�ѯ
        //private void Sectioninfo()
        //{
        //    #region
        //    if (chkSection.Checked == true)
        //    {
        //        if (chkTemperture.Checked == true || chkGravenurserecord.Checked == true || chkTemperture.Checked == true && chkGravenurserecord.Checked == true)
        //        {
        //            if (chkTemperture.Checked == true)
        //            {
        //                His_sql = re_sql + " and  t.section_id='" + cboSections.SelectedValue + "' order by t.pid asc";
        //                // His_sql = "select t.sick_area_id as �������,t.sick_area_name as ����,t.section_id as ���ұ��,t.section_name as ����,t.sick_bed_no as ����,t.patient_name as ��������,t.pid as ������,to_char(t.in_time,'yyyy-mm-dd  hh:mi') as ��Ժʱ�� from t_in_patient t where t.section_id='" + cboSections.SelectedValue + "'";
        //            }
        //            if (chkGravenurserecord.Checked == true)
        //            {
        //                His_sql = co_sql + "  and  t.section_id='" + cboSections.SelectedValue + "' order by t.pid asc";
        //            }
        //            if (chkTemperture.Checked == true && chkGravenurserecord.Checked == true)
        //            {

        //                His_sql = rd_sql + "  where t.sick_degree='��Σ' and t.section_id='" + cboSections.SelectedValue + "' or  t.sick_degree is null and t.section_id='" + cboSections.SelectedValue + "'  order by t.pid asc";
        //            }
        //        }
        //        else
        //        {
        //            App.Msg("��ѡ���������࣡");
        //        }
        //    }
        //    #endregion

        //}
        ////�����������
        //private void Book_type()
        //{
        //    #region
        //    if (chkTemperture.Checked == true)
        //    {
        //        His_sql = re_sql + " order by t.pid asc ";
        //    }
        //    if (chkGravenurserecord.Checked == true)
        //    {
        //        His_sql = co_sql +" order by t.pid asc";
        //    }
        //    if (chkTemperture.Checked == true && chkGravenurserecord.Checked == true)
        //    {
        //        His_sql = rd_sql;//+ " where t.sick_degree='��Σ'  or  t.sick_degree is null "
        //    }
        //    #endregion
        //}
#endregion
        //ArrayList _al = new ArrayList();
        /// <summary>
        /// ��Ԫ��ϲ������� 
        /// </summary>
        private void CellUnit()
        {
            
            #region
            //��Ԫ��ϲ������� 
            flgView.fg[0, 0] ="";

            flgView.fg[1, 1] = "�������";
            flgView.fg[1, 2] = "����";
            flgView.fg[1, 3] = "���ұ��";
            flgView.fg[1, 4] = "����";
            flgView.fg[1, 5] = "����";
            flgView.fg[1, 6] = "��������";
            flgView.fg[1, 7] = "������";
            flgView.fg[1, 8] = "��Ժ����";
            flgView.fg[1, 9] = "���";

            flgView.fg.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            flgView.fg.Cols.Fixed = 0;
            //�ϲ���Ԫ��
            C1.Win.C1FlexGrid.CellRange cr;

            cr = flgView.fg.GetCellRange(0, 0, 1, 0);
            cr.Data = "";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.fg.MergedRanges.Add(cr);

            //cr = flgView.fg.GetCellRange(0, 1, 1, 0);
            //cr.Data = "";
            //cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            //flgView.fg.MergedRanges.Add(cr);

            cr = flgView.fg.GetCellRange(0, 1, 1, 1);
            cr.Data = "�������";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.fg.MergedRanges.Add(cr);

            cr = flgView.fg.GetCellRange(0, 2, 1, 2);
            cr.Data = "����";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.fg.MergedRanges.Add(cr);

            cr = flgView.fg.GetCellRange(0, 3, 1, 3);
            cr.Data = "���ұ��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.fg.MergedRanges.Add(cr);

            cr = flgView.fg.GetCellRange(0, 4, 1, 4);
            cr.Data = "����";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.fg.MergedRanges.Add(cr);


            cr = flgView.fg.GetCellRange(0, 5, 1, 5);
            cr.Data = "����";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.fg.MergedRanges.Add(cr);


            cr = flgView.fg.GetCellRange(0, 6, 1, 6);
            cr.Data = "��������";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.fg.MergedRanges.Add(cr);


            cr = flgView.fg.GetCellRange(0, 7, 1, 7);
            cr.Data = "������";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.fg.MergedRanges.Add(cr);

            cr = flgView.fg.GetCellRange(0, 8, 1, 8);
            cr.Data = "��Ժ����";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.fg.MergedRanges.Add(cr);

            cr = flgView.fg.GetCellRange(0, 9, 1, 9);
            cr.Data = "���";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.fg.MergedRanges.Add(cr);

            flgView.fg.AutoSizeCols();

            for (int i = 2; i < flgView.fg.Rows.Count; i++)
            {
                CellRange rg2 = flgView.fg.GetCellRange(i, 0);
                rg2.StyleNew.DataType = typeof(bool);
            }

            CellRange rg = flgView.fg.GetCellRange(0, 0);
            rg.StyleNew.ForeColor = Color.SkyBlue;

            for (int i = 1; i < flgView.fg.Cols.Count; i++)
            {
                flgView.fg.Cols[i].Width = 120;
            }
            flgView.fg.Cols[0].Width = 52;
            flgView.fg.Rows[1].Height = 22;
         
            //_al.Add(new HostedControl(flgView,bx,0,0)); 
            //_al.Add(new HostedControl(flgView, bx1,1, 1));
            //�ѱ������
            flgView.fg.Cols[1].Visible = false;
            flgView.fg.Cols[1].AllowEditing = false;

            flgView.fg.Cols[3].Visible = false;
            flgView.fg.Cols[3].AllowEditing = false;

            flgView.fg.Cols[9].Visible = false;
            flgView.fg.Cols[9].AllowEditing = false;

            #endregion
        }

        #region
        ///// <summary>
        ///// HostedControl
        ///// helper class that contains a control hosted within a C1FlexGrid
        ///// </summary>
        //internal class HostedControl
        //{
        //    internal ucC1FlexGrid _flex;
        //    internal Control _ctl;
        //    internal Row _row;
        //    internal Column _col;

        //    internal HostedControl(ucC1FlexGrid flex, Control hosted, int row, int col)
        //    {
        //        // save info
        //        _flex = flex;
        //        _ctl = hosted;
        //        _row = flex.fg.Rows[row];
        //        _col = flex.fg.Cols[col];

        //        // insert hosted control into grid
        //        _flex.Controls.Add(_ctl);
        //    }
        //    internal bool UpdatePosition()
        //    {
        //        // get row/col indices
        //        int r = _row.Index;
        //        int c = _col.Index;
        //        if (r < 0 || c < 0) return false;

        //        // get cell rect GetCellRect
        //        Rectangle rc = _flex.fg.GetCellRect(r, c, false);

        //        // hide control if out of range
        //        if (rc.Width <= 0 || rc.Height <= 0 || !rc.IntersectsWith(_flex.ClientRectangle))
        //        {
        //            _ctl.Visible = false;
        //            return true;
        //        }

        //        // move the control and show it
        //        _ctl.Bounds = rc;
        //        _ctl.Visible = true;

        //        // done
        //        return true;
        //    }
        //}
        //private void flgView_Paint(object sender, PaintEventArgs e)
        //{
        //    foreach (HostedControl hosted in _al)
        //    {
        //        hosted.UpdatePosition();
        //        //_flex.Rows[hosted._row.Index].Height = hosted._ctl.Height;
        //        //_flex.Cols[hosted._col.Index].Width = hosted._ctl.Width;
        //    }
        //}
        #endregion
        /// <summary>
        /// ��ͷ����
        /// </summary>
        private void SetTable()
        {
            flgView.fg.Cols.Count = 10;
            flgView.fg.Cols.Fixed = 0;
            flgView.fg.Rows.Count = 2;
            flgView.fg.Rows.Fixed = 2;
        }
        //ˢ��
        private void Refurbish()
        {

            if (chkTime.Checked == true)
            {
                dtpStartTime.Enabled = true;
                dtpEndTime.Enabled = true;
            }
            else
            {
                dtpStartTime.Enabled = false;
                dtpEndTime.Enabled = false;
            }

            if (chkSick.Checked == true)
            {
                cboSick.Enabled = true;
            }
            else
            {
                cboSick.Enabled = false;
            }
            if (chkSection.Checked == true)
            {
                cboSections.Enabled = true;
  
            }
            else
            {
                cboSections.Enabled = false;
            }
            if (chkQuanxuan.Checked == true)
            {
                if (flgView.fg.RowSel > 1)
                {

                    for (int j = 2; j < flgView.fg.Rows.Count; j++)
                    {
                        flgView.fg[j, 0] = "true";
                    }
                }
                chkfanxuan.Checked = false;
            }
            if (chkQuanxuan.Checked == true)
            {
                if (flgView.fg.RowSel > 1)
                {

                    for (int j = 2; j < flgView.fg.Rows.Count; j++)
                    {
                        flgView.fg[j, 0] = "true";
                    }
                }
                chkfanxuan.Checked = false;
            }
        }
        private void chkQuanxuan_Click(object sender, EventArgs e)
        {
            if (chkQuanxuan.Checked == true)
            {
                if (flgView.fg.RowSel > 1)
                {

                    for (int j = 2; j < flgView.fg.Rows.Count; j++)
                    {
                        flgView.fg[j, 0] = "true";
                    }
                }
                chkfanxuan.Checked = false;
            }
        }

        private void chkfanxuan_Click(object sender, EventArgs e)
        {
            if (chkfanxuan.Checked == true)
            {
                if (flgView.fg.RowSel > 1)
                {

                    for (int j = 2; j < flgView.fg.Rows.Count; j++)
                    {
                        flgView.fg[j, 0] = "false";
                    }
                }
                chkQuanxuan.Checked = false;
            }
        }

        private void dtpEndTime_ValueChanged(object sender, EventArgs e)
        {
            if (chkTime.Checked == true)
            {
                
            }
        }
         
        /// <summary>
        /// ��ѯ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelete_Click(object sender, EventArgs e)
        {
            flgView.fg.Clear();
           
            //chkQuanxuan.Checked = false;
            //chkfanxuan.Checked = false;
            //��Ժ���ڣ�Start_Admission ��ʼʱ�� End_Admission ����ʱ��
            string Start_Admission = dtpStartTime.Value.ToString("yyyy-MM-dd");
            string End_Admission = dtpEndTime.Value.ToString("yyyy-MM-dd");
            //���������ѯ
            if (chkTemperture.Checked == true)
            {
                His_sql = re_sql + " order by t.pid asc ";
            }
            if (chkGravenurserecord.Checked == true)
            {
                His_sql = co_sql + " order by t.pid asc";
            }
            if (chkTemperture.Checked == true && chkGravenurserecord.Checked == true)
            {
                His_sql = rd_sql;
            }
            //����+���������ѯ
            if (chkSection.Checked == true)
            {
                #region
                if (chkTemperture.Checked == true || chkGravenurserecord.Checked == true || chkTemperture.Checked == true && chkGravenurserecord.Checked == true)
                {
                    if (chkTemperture.Checked == true)
                    {
                        His_sql = re_sql + " and  t.section_id='" + cboSections.SelectedValue + "' order by t.pid asc";
                        
                    }
                    if (chkGravenurserecord.Checked == true)
                    {
                        His_sql = co_sql + "  and  t.section_id='" + cboSections.SelectedValue + "' order by t.pid asc";
                    }
                    if (chkTemperture.Checked == true && chkGravenurserecord.Checked == true)
                    {

                        His_sql = rd_sql + "  and  t.sick_degree='��Σ' and t.section_id='" + cboSections.SelectedValue + "' or  t.sick_degree is null and t.section_id='" + cboSections.SelectedValue + "'  order by t.pid asc";
                    }
                }
                else
                {
                    App.Msg("��ѡ���������࣡");
                    string ss = null;
                    DataSet ds1 = App.GetDataSet(ss);
                    if (ds1 == null)
                    {
                        CellUnit();
                    }
                    return;
                }
#endregion
            }
            //����+���������ѯ
            if (chkSick.Checked == true)
            {
                #region
                if (chkTemperture.Checked == true || chkGravenurserecord.Checked == true || chkTemperture.Checked == true && chkGravenurserecord.Checked == true)
                {
                    if (chkTemperture.Checked == true)
                    {
                        His_sql = re_sql + "  and  t.sick_area_id='" + cboSick.SelectedValue + "' order by t.pid asc ";
                        // His_sql = "select t.sick_area_id as �������,t.sick_area_name as ����,t.section_id as ���ұ��,t.section_name as ����,t.sick_bed_no as ����,t.patient_name as ��������,t.pid as ������,to_char(t.in_time,'yyyy-mm-dd  hh:mi') as ��Ժʱ�� from t_in_patient t where t.sick_area_id='" + cboSick.SelectedValue + "'";
                    }
                    if (chkGravenurserecord.Checked == true)
                    {
                        His_sql = co_sql + "  and  t.sick_area_id='" + cboSick.SelectedValue + "' order by t.pid asc";
                    }
                    if (chkTemperture.Checked == true && chkGravenurserecord.Checked == true)
                    {

                        His_sql = rd_sql + " and t.sick_degree='��Σ' and  t.sick_area_id='" + cboSick.SelectedValue + "' or  t.sick_degree is null and  t.sick_area_id='" + cboSick.SelectedValue + "' order by t.pid asc";
                    }
                    if (chkSection.Checked == true && chkTemperture.Checked == true)
                    {
                        His_sql = rd_sql + " and t.sick_degree is null  and t.sick_area_id='" + cboSick.SelectedValue + "' and t.section_id='" + cboSections.SelectedValue + "'  order by t.pid asc";
                    }
                    if (chkSection.Checked == true && chkGravenurserecord.Checked == true)
                    {
                        His_sql = rd_sql + " and t.sick_degree='��Σ'  and t.sick_area_id='" + cboSick.SelectedValue + "' and t.section_id='" + cboSections.SelectedValue + "'  order by t.pid asc";
                    }
                    if (chkSection.Checked == true && chkTemperture.Checked == true && chkGravenurserecord.Checked == true)
                    {
                        His_sql = rd_sql + " and t.sick_degree is null  and t.sick_area_id='" + cboSick.SelectedValue + "' and t.section_id='" + cboSections.SelectedValue + "' or t.sick_degree='��Σ'  and t.sick_area_id='" + cboSick.SelectedValue + "' and t.section_id='" + cboSections.SelectedValue + "'  order by t.pid asc";
                    }
                }
                else
                {
                    App.Msg("��ѡ���������࣡");
                    string ss = null;
                    DataSet ds1 = App.GetDataSet(ss);
                    if (ds1 == null)
                    {
                        CellUnit();
                    }
                    return;
                }
                #endregion
            }
            //����+���������ѯ
            if (chkTime.Checked == true)
            {
                #region

                    if (chkTemperture.Checked == true || chkGravenurserecord.Checked == true || chkTemperture.Checked == true && chkGravenurserecord.Checked == true)
                    {
                        if (dtpEndTime.Value <= dtpStartTime.Value)
                        {
                            App.Msg("�������ڲ���С�ڻ������ʼ���ڣ�");
                            dtpEndTime.Focus();
                            string ss = null;
                            DataSet ds1 = App.GetDataSet(ss);
                             if (ds1 == null)
                             {
                                 CellUnit();
                             }
                            return;
                        }
                        else
                        {
                            //���µ�
                            if (chkTemperture.Checked == true)
                            {

                                His_sql = re_sql + " and  t.in_time between  to_timestamp( '" + Start_Admission + "','syyyy-mm-dd')  and  to_timestamp('" + End_Admission + "','syyyy-mm-dd') order by t.pid asc ";
                            }
                            //Σ�ػ����¼��
                            if (chkGravenurserecord.Checked == true)
                            {

                                His_sql = co_sql + "  and t.in_time between  to_timestamp( '" + Start_Admission + "','syyyy-mm-dd')  and  to_timestamp('" + End_Admission + "','syyyy-mm-dd') order by t.pid asc";
                            }
                            //���µ�+Σ�ػ����¼��
                            if (chkTemperture.Checked == true && chkGravenurserecord.Checked == true)
                            {

                                His_sql = rd_sql + " and t.sick_degree='��Σ' and t.in_time between  to_timestamp( '" + Start_Admission + "','syyyy-mm-dd')  and  to_timestamp('" + End_Admission + "','syyyy-mm-dd')  or  t.sick_degree is null and  t.in_time between  to_timestamp( '" + Start_Admission + "','syyyy-mm-dd')  and  to_timestamp('" + End_Admission + "','syyyy-mm-dd') order by t.pid asc";
                            }
                            if (chkSick.Checked == true && chkTemperture.Checked == true)
                            {

                                His_sql = re_sql + " and  t.in_time between  to_timestamp( '" + Start_Admission + "','syyyy-mm-dd')  and  to_timestamp('" + End_Admission + "','syyyy-mm-dd')  and t.sick_area_id='" + cboSick.SelectedValue + "' order by t.pid asc ";
                            }
                            if (chkSection.Checked == true && chkTemperture.Checked == true)
                            {

                                His_sql = re_sql + "  and   t.in_time between  to_timestamp( '" + Start_Admission + "','syyyy-mm-dd')  and  to_timestamp('" + End_Admission + "','syyyy-mm-dd')  and t.section_id='" + cboSections.SelectedValue + "' order by t.pid asc ";
                            }
                            if (chkSick.Checked == true && chkGravenurserecord.Checked == true)
                            {

                                His_sql = co_sql + "  and  t.in_time between  to_timestamp( '" + Start_Admission + "','syyyy-mm-dd')  and  to_timestamp('" + End_Admission + "','syyyy-mm-dd')  and t.sick_area_id='" + cboSick.SelectedValue + "' order by t.pid asc";
                            }
                            if (chkSection.Checked == true && chkGravenurserecord.Checked == true)
                            {

                                His_sql = co_sql + "  and  t.in_time between  to_timestamp( '" + Start_Admission + "','syyyy-mm-dd')  and  to_timestamp('" + End_Admission + "','syyyy-mm-dd')  and t.section_id='" + cboSections.SelectedValue + "' order by t.pid asc";
                            }
                            if (chkSick.Checked == true && chkGravenurserecord.Checked == true && chkSection.Checked == true)
                            {
                                His_sql = rd_sql + " and t.sick_degree='��Σ' and  t.in_time between  to_timestamp( '" + Start_Admission + "','syyyy-mm-dd')  and  to_timestamp('" + End_Admission + "','syyyy-mm-dd')  and t.sick_area_id='" + cboSick.SelectedValue + "' and t.section_id='" + cboSections.SelectedValue + "'  order by t.pid asc";
                            }
                            if (chkSick.Checked == true && chkTemperture.Checked == true && chkSection.Checked == true)
                            {
                                His_sql = rd_sql + "  and t.sick_degree is null  and  t.in_time between  to_timestamp( '" + Start_Admission + "','syyyy-mm-dd')  and  to_timestamp('" + End_Admission + "','syyyy-mm-dd')  and t.sick_area_id='" + cboSick.SelectedValue + "' and t.section_id='" + cboSections.SelectedValue + "' order by t.pid asc";
                            }
                            if (chkSick.Checked == true && chkGravenurserecord.Checked == true && chkSection.Checked == true && chkTemperture.Checked == true)
                            {
                                His_sql = rd_sql + " and t.sick_degree='��Σ' and  t.in_time between  to_timestamp( '" + Start_Admission + "','syyyy-mm-dd')  and  to_timestamp('" + End_Admission + "','syyyy-mm-dd')  and t.sick_area_id='" + cboSick.SelectedValue + "' and t.section_id='" + cboSections.SelectedValue + "' or  t.sick_degree is null  and  t.in_time between  to_timestamp( '" + Start_Admission + "','syyyy-mm-dd')  and  to_timestamp('" + End_Admission + "','syyyy-mm-dd')  and t.sick_area_id='" + cboSick.SelectedValue + "' and t.section_id='" + cboSections.SelectedValue + "' order by t.pid asc";
                            }
                        }
                    }
                    else
                    {
                        App.Msg("��ѡ���������࣡");
                        string ss = null;
                        DataSet ds1 = App.GetDataSet(ss);
                        if (ds1 == null)
                        {
                            CellUnit();
                        }
                        return;
                    }
#endregion
            }
            SetTable();
            //Book_type();
            //RuTime();
            //SickArae();
            //Sectioninfo();
            
            DataSet ds = App.GetDataSet(His_sql);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        flgView.fg.Rows.Add();
                        Class_Historyrecord His = new Class_Historyrecord();
                        His.Sick_id = dt.Rows[i]["�������"].ToString();
                        His.Sick_name = dt.Rows[i]["����"].ToString();
                        His.Section_id = dt.Rows[i]["���ұ��"].ToString();
                        His.Section_name = dt.Rows[i]["����"].ToString();
                        His.Bed = dt.Rows[i]["����"].ToString();
                        His.Patient_name = dt.Rows[i]["��������"].ToString();
                        His.Pids = dt.Rows[i]["������"].ToString();
                        His.In_time = dt.Rows[i]["��Ժʱ��"].ToString();
                        His.Id = dt.Rows[i]["���"].ToString();

                        flgView.fg[2 + i, 1] = His.Sick_id;
                        flgView.fg[2 + i, 2] = His.Sick_name;
                        flgView.fg[2 + i, 3] = His.Section_id;
                        flgView.fg[2 + i, 4] = His.Section_name;
                        flgView.fg[2 + i, 5] = His.Bed;
                        flgView.fg[2 + i, 6] = His.Patient_name;
                        flgView.fg[2 + i, 7] = His.Pids;
                        flgView.fg[2 + i, 8] = His.In_time;
                        flgView.fg[2 + i, 9] = His.Id;
                    }
                    
                }
                chkQuanxuan.Visible = true;
                chkfanxuan.Visible = true;
                CellUnit();
         
                flgView.fg.Cols[1].TextAlign = TextAlignEnum.CenterCenter;
                flgView.fg.Cols[2].TextAlign = TextAlignEnum.CenterCenter;
                flgView.fg.Cols[3].TextAlign = TextAlignEnum.CenterCenter;
                flgView.fg.Cols[4].TextAlign = TextAlignEnum.CenterCenter;
                flgView.fg.Cols[5].TextAlign = TextAlignEnum.CenterCenter;
                flgView.fg.Cols[6].TextAlign = TextAlignEnum.CenterCenter;
                flgView.fg.Cols[7].TextAlign = TextAlignEnum.CenterCenter;
                flgView.fg.Cols[8].TextAlign = TextAlignEnum.CenterCenter;
                flgView.fg.Cols[9].TextAlign = TextAlignEnum.CenterCenter;
            }
            else
            {
                CellUnit();
                chkQuanxuan.Visible = true;
                chkfanxuan.Visible = true;
            }

                
           
        }
        /// <summary>
        /// ʱ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkTime_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTime.Checked == true)
            {
                dtpStartTime.Enabled = true;
                dtpEndTime.Enabled = true;
                chkSick.Checked = false;
                chkSection.Checked = false;
            }
            else
            {
                dtpStartTime.Enabled = false;
                dtpEndTime.Enabled = false;
            }
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkSick_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSick.Checked == true)
            {
                cboSick.Enabled = true;
            }
            else
            {
                cboSick.Enabled = false;
            }
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkSection_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSection.Checked == true)
            {
                cboSections.Enabled = true;
            }
            else
            {
                cboSections.Enabled = false;
            }
        }
        //private void chkTemperture_Click(object sender, EventArgs e)
        //{
        //    if (chkTemperture.Checked == true)
        //    {
        //        chkTemperture.Checked = true;

        //    }
        //}

        //private void chkGravenurserecord_Click(object sender, EventArgs e)
        //{
        //    if (chkGravenurserecord.Checked == true)
        //    {
        //        chkGravenurserecord.Checked = true;

        //    }
        //}

        //private void chkTime_Click(object sender, EventArgs e)
        //{
        //    if (chkTime.Checked == true)
        //    {
        //        dtpStartTime.Enabled = true;
        //        dtpEndTime.Enabled = true;
        //        chkSick.Checked = false;
        //        chkSection.Checked = false;
        //    }
        //    else
        //    {
        //        dtpStartTime.Enabled = false;
        //        dtpEndTime.Enabled = false;
        //    }
        //}

        //private void chkSick_Click(object sender, EventArgs e)
        //{
        //    if (chkSick.Checked == true)
        //    {
        //        cboSick.Enabled = true;
        //    }
        //    else
        //    {
        //        cboSick.Enabled = false;
        //    }
        //}

        //private void chkSection_Click(object sender, EventArgs e)
        //{
        //    if (chkSection.Checked == true)
        //    {
        //        cboSections.Enabled = true;
        //    }
        //    else
        //    {
        //        cboSections.Enabled = false;
        //    }
        //}
        /// <summary>
        /// ���µ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkTemperture_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkTemperture.Checked == true)
            //{
            //    chkGravenurserecord.Checked = false;

            //}

        }
        /// <summary>
        /// Σ�ػ����¼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkGravenurserecord_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkGravenurserecord.Checked == true)
            //{
            //    chkTemperture.Checked = false;
            //}
        }
        /// <summary>
        /// ȫѡ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkQuanxuan_CheckedChanged(object sender, EventArgs e)
        {
            if (chkQuanxuan.Checked == true)
            {
                if (flgView.fg.RowSel > 1)
                {

                    for (int j = 2; j < flgView.fg.Rows.Count; j++)
                    {
                        flgView.fg[j, 0] = "true";
                    }
                }
                chkfanxuan.Checked = false;
            }
        }
        /// <summary>
        /// ��ѡ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkfanxuan_CheckedChanged(object sender, EventArgs e)
        {
            if (chkfanxuan.Checked == true)
            {
                if (flgView.fg.RowSel > 1)
                {
                    for (int j = 2; j < flgView.fg.Rows.Count; j++)
                    {
                        flgView.fg[j, 0] = "false";
                    }
                }
                chkQuanxuan.Checked = false;
            }
            else
            {
                if (flgView.fg.RowSel > 1)
                {
                    for (int j = 2; j < flgView.fg.Rows.Count; j++)
                    {
                        flgView.fg[j, 0] =null;
                    }
                }
            }
        }
        /// <summary>
        /// ���ֵ�Ԫ��ϲ������� 
        /// </summary>
        private void CellUnits()
        {
            string tempture = "";
            string grave = "";
             if (chkTemperture.Checked == true && chkGravenurserecord.Checked == true)
            {
                tempture = "���µ�";
                grave = "Σ�ػ����¼��";
            }
            else if (chkTemperture.Checked == true)
            {
                tempture = "���µ�";
            }
            else if (chkGravenurserecord.Checked == true)
            {
                tempture = "Σ�ػ����¼��";
            }
          

            //��Ԫ��ϲ������� 
            //ucflgView.fg[0, 0] = "";
            ucflgView.fg[1, 0] = "���";
            ucflgView.fg[1, 1] = "������";
            ucflgView.fg[1, 2] = "��������";
            ucflgView.fg[1, 3] = "������";
            ucflgView.fg[1, 4] = "����";
            ucflgView.fg[1, 5] = tempture;
            ucflgView.fg[1, 6] = grave;
            ucflgView.fg[1, 7] = "�ϼ�";
            ucflgView.fg[1, 8] = "�������";
            ucflgView.fg[1, 9] = "��������";
            ucflgView.fg[1, 10] = "���ұ��";
            ucflgView.fg[1, 11] = "��������";
            ucflgView.fg[1, 12] = "����";


            ucflgView.fg.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            ucflgView.fg.Cols.Fixed = 0;
            //�ϲ���Ԫ��
            C1.Win.C1FlexGrid.CellRange cr;

            cr = ucflgView.fg.GetCellRange(0, 0, 1, 0);
            cr.Data = "���";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            ucflgView.fg.MergedRanges.Add(cr);

            cr = ucflgView.fg.GetCellRange(0, 1, 1, 1);
            cr.Data = "������";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            ucflgView.fg.MergedRanges.Add(cr);

            cr = ucflgView.fg.GetCellRange(0, 2, 1, 2);
            cr.Data = "��������";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            ucflgView.fg.MergedRanges.Add(cr);

            cr = ucflgView.fg.GetCellRange(0, 3, 1, 3);
            cr.Data = "������";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            ucflgView.fg.MergedRanges.Add(cr);

            cr = ucflgView.fg.GetCellRange(0, 4, 1, 4);
            cr.Data = "����";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            ucflgView.fg.MergedRanges.Add(cr);


            cr = ucflgView.fg.GetCellRange(0, 5, 0, 6);
            cr.Data = "����";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            ucflgView.fg.MergedRanges.Add(cr);


            cr = ucflgView.fg.GetCellRange(0, 7, 1, 7);
            cr.Data = "�ϼ�";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            ucflgView.fg.MergedRanges.Add(cr);

            cr = ucflgView.fg.GetCellRange(0, 8, 1, 8);
            cr.Data = "�������";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            ucflgView.fg.MergedRanges.Add(cr);

            cr = ucflgView.fg.GetCellRange(0, 9, 1, 9);
            cr.Data = "��������";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            ucflgView.fg.MergedRanges.Add(cr);

            cr = ucflgView.fg.GetCellRange(0, 10, 1, 10);
            cr.Data = "���ұ��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            ucflgView.fg.MergedRanges.Add(cr);

            cr = ucflgView.fg.GetCellRange(0, 11, 1, 11);
            cr.Data = "��������";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            ucflgView.fg.MergedRanges.Add(cr);

            cr = ucflgView.fg.GetCellRange(0, 12, 1, 12);
            cr.Data = "����";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            ucflgView.fg.MergedRanges.Add(cr);
            ucflgView.fg.AutoSizeCols();



            for (int y = 2; y < ucflgView.fg.Rows.Count; y++)
            {
                CellRange rg = ucflgView.fg.GetCellRange(y, 12);
                rg.StyleNew.ForeColor = Color.Blue;
            }
            for (int i = 0; i < ucflgView.fg.Rows.Count; i++)
            {
                if (ucflgView.fg[i, 1].ToString().Contains("�ۼ�"))
                {
                    ucflgView.fg.Rows[i].StyleNew.ForeColor = Color.Red;
                    //���߼Ӵ�
                    ucflgView.fg.Rows[i - 1].StyleNew.Border.Color = Color.Red;
                    ucflgView.fg.Rows[i - 1].StyleNew.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Horizontal;
                    ucflgView.fg.Rows[i - 1].StyleNew.Border.Width = 3;
                }
            }

            //���ر��
            ucflgView.fg.Cols[0].Visible = false;
            ucflgView.fg.Cols[0].AllowEditing = false;

            //���ز������
            ucflgView.fg.Cols[8].Visible = false;
            ucflgView.fg.Cols[8].AllowEditing = false;
            //���ز�������
            ucflgView.fg.Cols[9].Visible = false;
            ucflgView.fg.Cols[9].AllowEditing = false;
            //���ؿ��ұ��
            ucflgView.fg.Cols[10].Visible = false;
            ucflgView.fg.Cols[10].AllowEditing = false;
            //���ؿ�������
            ucflgView.fg.Cols[11].Visible = false;
            ucflgView.fg.Cols[11].AllowEditing = false;

            if (chkTemperture.Checked == true && chkGravenurserecord.Checked == true)
            {
                ucflgView.fg.Cols[6].Visible = true;

            }
            else
            {
                ucflgView.fg.Cols[6].Visible = false;
            }

        }
        /// <summary>
        /// ���ֱ�ͷ����
        /// </summary>
        private void SetTables()
        {
            ucflgView.fg.Cols.Count = 13;
            ucflgView.fg.Cols.Fixed = 0;
            ucflgView.fg.Rows.Count = 2;
            ucflgView.fg.Rows.Fixed = 2;
        }
        /// <summary>
        /// ��ͷ����
        /// </summary>
        private void SetTabless()
        {
            ucflgView.fg.Cols.Count = 13;
            //ucflgView.fg.Cols.Fixed = 0;
            ucflgView.fg.Rows.Count = 2;
            ucflgView.fg.Rows.Fixed = 2;
            //��ͷ����
            colss[0].Name = "���";
            colss[0].Field = "id";
            colss[0].Index = 1;
            colss[0].visible = true ;

            colss[1].Name = "������";
            colss[1].Field = "person_in_charge";
            colss[1].Index = 2;
            colss[1].visible = true;

            colss[2].Name = "��������";
            colss[2].Field = "pidname";
            colss[2].Index = 3;
            colss[2].visible = true;

            colss[3].Name = "������";
            colss[3].Field = "pids";
            colss[3].Index = 4;
            colss[3].visible = true;

            colss[4].Name = "����";
            colss[4].Field = "beds";
            colss[4].Index = 5;
            colss[4].visible = true;

            colss[5].Name = "���µ�";
            colss[5].Field = "book_type";
            colss[5].Index = 6;
            colss[5].visible = true;

            colss[6].Name = "Σ�ػ����¼��";
            colss[6].Field = "book_weizhong";
            colss[6].Index = 7;
            colss[6].visible = true;

            colss[7].Name = "�ϼ�";
            colss[7].Field = "total";
            colss[7].Index = 8;
            colss[7].visible = true;

            colss[8].Name = "�������";
            colss[8].Field = "sick_id";
            colss[8].Index = 9;
            colss[8].visible = true;

            colss[9].Name = "��������";
            colss[9].Field = "sick_name";
            colss[9].Index = 10;
            colss[9].visible = true;

            colss[10].Name = "���ұ��";
            colss[10].Field = "section_id";
            colss[10].Index = 11;
            colss[10].visible = true;

            colss[11].Name = "��������";
            colss[11].Field = "section_name";
            colss[11].Index = 12;
            colss[11].visible = true;

            colss[12].Name = "����";
            colss[12].Field = "look_over";
            colss[12].Index = 13;
            colss[12].visible = true;

        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPingfen_Click(object sender, EventArgs e)
        {

            string sql = "";
            string cha_name = "�鿴��ϸ";
            Class_Grade Cgrade = new Class_Grade();
            string TValue = null;
            int t = 0;
            double sum1 = 0;
            double sum2 = 0;
            double sum3 = 0;
            string name="�ۼ�";
            string types = "0";
            string nuse = "0";
            string pid = "";//����pid
            string sick_ID = "";//����ID
            string sick_Name = "";//��������
            string section_ID = "";//����ID
            string section_Name = "";//��������
            ucflgView.fg.Clear();
            //ȫѡ
            if (chkQuanxuan.Checked == true)
            {
                if (flgView.fg.RowSel > 1)
                {
                    SetTables();//��ͷ
                    for (int j = 2; j < flgView.fg.Rows.Count; j++)
                    {
                        flgView.fg[j, 0] = "true";
                        //��ȡpid
                         pid = flgView.fg[j, 7].ToString();
                         sick_ID = flgView.fg[j, 1].ToString();
                         sick_Name = flgView.fg[j, 2].ToString();
                         section_ID = flgView.fg[j, 3].ToString();
                         section_Name = flgView.fg[j, 4].ToString();
                        //���µ���Σ�ػ����¼����Ϊtrue
                        if (chkTemperture.Checked == true && chkGravenurserecord.Checked == true)
                        {
                            see_particulars = "���µ�";
                            see_particulars_nurse = "Σ��";
                            sql = "select  t.sick_doctor_name as ������,t.patient_name as ��������,t.pid as  ������,t.sick_bed_no as ����," +
                                 @"(select sum(qua.take_grade)  from t_quality_record qua where qua.doctype like 'Σ��'and qua.pid='" + pid + "') as �ϼ� " +
                                  @"from t_in_patient t where t.pid='" + pid + "'";
                            string Tsql = "select sum(qua.take_grade) as ���µ�  from t_quality_record qua where qua.doctype like '���µ�'and qua.pid='" + pid + "' ";
                            DataSet ds = App.GetDataSet(sql);
                            DataSet ds2 = App.GetDataSet(Tsql);
                            if (ds != null)
                            {
                                double sum;
                                double bookType;
                                double book_nurse;
                                ucflgView.fg.Rows.Add();
                                Cgrade.Person_in_charge = ds.Tables[0].Rows[0]["������"].ToString();
                                Cgrade.Pidname = ds.Tables[0].Rows[0]["��������"].ToString();
                                Cgrade.Pids = ds.Tables[0].Rows[0]["������"].ToString();
                                Cgrade.Beds = ds.Tables[0].Rows[0]["����"].ToString();
                                if (ds2.Tables[0].Rows[0]["���µ�"].ToString() != "")
                                {
                                    Cgrade.Book_type =Convert.ToDouble( ds2.Tables[0].Rows[0]["���µ�"].ToString());
                                }
                                else
                                {
                                    
                                    Cgrade.Book_type = Convert.ToDouble(types);
                                }
                                if (ds.Tables[0].Rows[0]["�ϼ�"].ToString() != "")
                                {
                                    Cgrade.Book_weizhong = Convert.ToDouble(ds.Tables[0].Rows[0]["�ϼ�"].ToString());
                                }
                                else
                                {
                                    
                                    Cgrade.Book_weizhong = Convert.ToDouble(nuse);
                                }

                                bookType = Cgrade.Book_type;
                                book_nurse = Cgrade.Book_weizhong;
                                sum = bookType + book_nurse;
                                Cgrade.Total = sum;
                                Cgrade.Sick_id = sick_ID;
                                Cgrade.Sick_name = sick_Name;
                                Cgrade.Section_id = section_ID;
                                Cgrade.Section_name = section_Name;

                                ucflgView.fg[j, 1] = Cgrade.Person_in_charge;
                                ucflgView.fg[j, 2] = Cgrade.Pidname;
                                ucflgView.fg[j, 3] = Cgrade.Pids;
                                ucflgView.fg[j, 4] = Cgrade.Beds;
                                ucflgView.fg[j, 5] = Cgrade.Book_type;
                                ucflgView.fg[j, 6] = Cgrade.Book_weizhong;
                                ucflgView.fg[j, 7] = Cgrade.Total;
                                ucflgView.fg[j, 8] = Cgrade.Sick_id;
                                ucflgView.fg[j, 9] = Cgrade.Sick_name;
                                ucflgView.fg[j, 10] = Cgrade.Section_id;
                                ucflgView.fg[j, 11] = Cgrade.Section_name;
                                ucflgView.fg[j, 12] = cha_name;
                                string   value = ucflgView.fg[j, 5].ToString();
                                string  value_nurse = ucflgView.fg[j, 6].ToString();
                                string valueTotal = ucflgView.fg[j, 7].ToString();
                                sum1 +=Convert.ToDouble( value);
                                sum2 += Convert.ToDouble(value_nurse);
                                sum3 += Convert.ToDouble(valueTotal);
                                t = j;

                            }
                        }
                        //���µ�Ϊtrue
                        else if (chkTemperture.Checked == true)
                        {
                            see_particulars = "���µ�";
                            
                            sql = "select  t.sick_doctor_name as ������,t.patient_name as ��������,t.pid as  ������,t.sick_bed_no as ����," +
                                @"(select sum(qua.take_grade)  from t_quality_record qua where qua.doctype='���µ�'and qua.pid='" + pid + "') as �ϼ� " +
                                 @"from t_in_patient t where t.pid='" + pid + "'";
                            DataSet ds = App.GetDataSet(sql);
                            if (ds != null)
                            {
                                ucflgView.fg.Rows.Add();
                                Cgrade.Person_in_charge = ds.Tables[0].Rows[0]["������"].ToString();
                                Cgrade.Pidname = ds.Tables[0].Rows[0]["��������"].ToString();
                                Cgrade.Pids = ds.Tables[0].Rows[0]["������"].ToString();
                                Cgrade.Beds = ds.Tables[0].Rows[0]["����"].ToString();
                                if (ds.Tables[0].Rows[0]["�ϼ�"].ToString() != "")
                                {
                                    Cgrade.Book_type = Convert.ToDouble(ds.Tables[0].Rows[0]["�ϼ�"].ToString());
                                }
                                else
                                {
                                    Cgrade.Book_type = Convert.ToDouble(types);
                                }
                                Cgrade.Sick_id = sick_ID;
                                Cgrade.Sick_name = sick_Name;
                                Cgrade.Section_id = section_ID;
                                Cgrade.Section_name = section_Name;
                                ucflgView.fg[j, 1] = Cgrade.Person_in_charge;
                                ucflgView.fg[j, 2] = Cgrade.Pidname;
                                ucflgView.fg[j, 3] = Cgrade.Pids;
                                ucflgView.fg[j, 4] = Cgrade.Beds;
                                ucflgView.fg[j, 5] = Cgrade.Book_type;
                                ucflgView.fg[j, 7] = Cgrade.Book_type;
                                ucflgView.fg[j, 8] = Cgrade.Sick_id;
                                ucflgView.fg[j, 9] = Cgrade.Sick_name;
                                ucflgView.fg[j, 10] = Cgrade.Section_id;
                                ucflgView.fg[j, 11] = Cgrade.Section_name;
                                ucflgView.fg[j, 12] = cha_name;

                                string value = ucflgView.fg[j, 5].ToString();

                                sum1 += Convert.ToDouble(value);

                                sum3 += Convert.ToDouble(value);
                                t = j;
                            }
                        }
                        //Σ�ػ����¼��Ϊtrue
                        else if (chkGravenurserecord.Checked == true)
                        {
                            see_particulars_nurse = "Σ��";
                            sql = "select  t.sick_doctor_name as ������,t.patient_name as ��������,t.pid as  ������,t.sick_bed_no as ����," +
                                 @"(select sum(qua.take_grade)  from t_quality_record qua where qua.doctype like 'Σ��'and qua.pid='" + pid + "') as �ϼ� " +
                                  @"from t_in_patient t where t.pid='" + pid + "'";
                            DataSet ds = App.GetDataSet(sql);
                            if (ds != null)
                            {
                                ucflgView.fg.Rows.Add();
                                Cgrade.Person_in_charge = ds.Tables[0].Rows[0]["������"].ToString();
                                Cgrade.Pidname = ds.Tables[0].Rows[0]["��������"].ToString();
                                Cgrade.Pids = ds.Tables[0].Rows[0]["������"].ToString();
                                Cgrade.Beds = ds.Tables[0].Rows[0]["����"].ToString();
                                if (ds.Tables[0].Rows[0]["�ϼ�"].ToString() != "")
                                {
                                    Cgrade.Book_weizhong = Convert.ToDouble(ds.Tables[0].Rows[0]["�ϼ�"].ToString());
                                }
                                else
                                {
                                    Cgrade.Book_weizhong = Convert.ToDouble(nuse);
                                }
                                Cgrade.Sick_id = sick_ID;
                                Cgrade.Sick_name = sick_Name;
                                Cgrade.Section_id = section_ID;
                                Cgrade.Section_name = section_Name;
                                ucflgView.fg[j, 1] = Cgrade.Person_in_charge;
                                ucflgView.fg[j, 2] = Cgrade.Pidname;
                                ucflgView.fg[j, 3] = Cgrade.Pids;
                                ucflgView.fg[j, 4] = Cgrade.Beds;
                                ucflgView.fg[j, 6] = Cgrade.Book_weizhong;
                                ucflgView.fg[j, 7] = Cgrade.Book_weizhong;
                                ucflgView.fg[j, 8] = Cgrade.Sick_id;
                                ucflgView.fg[j, 9] = Cgrade.Sick_name;
                                ucflgView.fg[j, 10] = Cgrade.Section_id;
                                ucflgView.fg[j, 11] = Cgrade.Section_name;
                                ucflgView.fg[j, 12] = cha_name;

                                string value_nurse = ucflgView.fg[j, 6].ToString();
                                sum2 += Convert.ToDouble(value_nurse);
                                sum3 += Convert.ToDouble(value_nurse);
                                t = j;
                            }
                        }
                    }
                    if(chkTemperture.Checked == true && chkGravenurserecord.Checked == true)
                    {
                        ucflgView.fg.Rows.Add();
                        ucflgView.fg[t+1, 1] = name;
                        ucflgView.fg[t+1, 2] = null;
                        ucflgView.fg[t+1, 3] = null;
                        ucflgView.fg[t+1, 4] = null;
                        string fgsum1 = Tvalues(sum1.ToString());
                        ucflgView.fg[t + 1, 5] = fgsum1;
                        string fgsum2 = Tvalues(sum2.ToString());
                        ucflgView.fg[t + 1, 6] = fgsum2;
                        string fgsum3 = Tvalues(sum3.ToString());
                        ucflgView.fg[t + 1, 7] = fgsum3;
                        ucflgView.fg[t+1, 8] = null;
                        ucflgView.fg[t + 1, 9] = null;
                        ucflgView.fg[t + 1, 10] = null;
                        ucflgView.fg[t + 1, 11] = null;
                        ucflgView.fg[t + 1, 12] = null;
                    }
                    else if(chkTemperture.Checked == true)
                    {
                         ucflgView.fg.Rows.Add();
                        ucflgView.fg[t+1, 1] = name;
                        ucflgView.fg[t+1, 2] = null;
                        ucflgView.fg[t+1, 3] = null;
                        ucflgView.fg[t+1, 4] = null;
                        string fgsum1 = Tvalues(sum1.ToString());
                        ucflgView.fg[t + 1, 5] = fgsum1;
                        ucflgView.fg[t+1, 6] = null;
                        string fgsum3 = Tvalues(sum3.ToString());
                        ucflgView.fg[t + 1, 7] = fgsum3;
                        ucflgView.fg[t+1, 8] = null;
                        ucflgView.fg[t + 1, 9] = null;
                        ucflgView.fg[t + 1, 10] = null;
                        ucflgView.fg[t + 1, 11] = null;
                        ucflgView.fg[t + 1, 12] = null;
                    }
                    else if(chkGravenurserecord.Checked == true)
                    {
                         ucflgView.fg.Rows.Add();
                        ucflgView.fg[t+1, 1] = name;
                        ucflgView.fg[t+1, 2] = null;
                        ucflgView.fg[t+1, 3] = null;
                        ucflgView.fg[t+1, 4] = null;
                        ucflgView.fg[t+1, 5] = null;
                        string fgsum2 = Tvalues(sum2.ToString());
                        ucflgView.fg[t + 1, 6] = fgsum2;
                        string fgsum3 = Tvalues(sum3.ToString());
                        ucflgView.fg[t + 1, 7] = fgsum3;
                        ucflgView.fg[t+1, 8] = null;
                        ucflgView.fg[t + 1, 9] = null;
                        ucflgView.fg[t + 1, 10] = null;
                        ucflgView.fg[t + 1, 11] = null;
                        ucflgView.fg[t + 1, 12] = null;
                    }

                    CellUnits();
                    ucflgView.fg.Cols[1].TextAlign = TextAlignEnum.CenterCenter;
                    ucflgView.fg.Cols[2].TextAlign = TextAlignEnum.CenterCenter;
                    ucflgView.fg.Cols[3].TextAlign = TextAlignEnum.CenterCenter;
                    ucflgView.fg.Cols[4].TextAlign = TextAlignEnum.CenterCenter;
                    ucflgView.fg.Cols[5].TextAlign = TextAlignEnum.CenterCenter;
                    ucflgView.fg.Cols[6].TextAlign = TextAlignEnum.CenterCenter;
                    ucflgView.fg.Cols[7].TextAlign = TextAlignEnum.CenterCenter;
                    ucflgView.fg.Cols[8].TextAlign = TextAlignEnum.CenterCenter;
                    ucflgView.fg.Cols[9].TextAlign = TextAlignEnum.CenterCenter;
                    ucflgView.fg.Cols[10].TextAlign = TextAlignEnum.CenterCenter;
                    ucflgView.fg.Cols[11].TextAlign = TextAlignEnum.CenterCenter;
                    ucflgView.fg.Cols[12].TextAlign = TextAlignEnum.CenterCenter;
                }
            }
            //ȫѡ�ͷ�ѡΪfalse
            else if (chkfanxuan.Checked == false && chkQuanxuan.Checked == false)
            {

                ucflgView.fg.Clear();
                Sqls.Clear();

                if (flgView.fg.RowSel > 1)
                {
                    SetTabless();
                    for (int j = 2; j < flgView.fg.Rows.Count; j++)
                    {
                        Class_Grade temp = new Class_Grade();
                        if (flgView.fg[j, 0] != null)
                        {
                            flgView.fg[j, 0] = "true";
                            if (flgView.fg[j, 0].ToString().ToLower() != "false")
                            {
                                 pid = flgView.fg[j, 7].ToString();
                                 sick_ID = flgView.fg[j, 1].ToString();
                                 sick_Name = flgView.fg[j, 2].ToString();
                                 section_ID = flgView.fg[j, 3].ToString();
                                 section_Name = flgView.fg[j, 4].ToString();
                                if (chkTemperture.Checked == true && chkGravenurserecord.Checked == true)
                                {
                                    see_particulars = "���µ�";
                                    see_particulars_nurse = "Σ��";
                                    sql = "select  t.sick_doctor_name as ������,t.patient_name as ��������,t.pid as  ������,t.sick_bed_no as ����," +
                                         @"(select sum(qua.take_grade)  from t_quality_record qua where qua.doctype like 'Σ��' and qua.pid='" + pid + "') as �ϼ� " +
                                          @"from t_in_patient t where t.pid='" + pid + "'";
                                    string Tsql = "select sum(qua.take_grade) as ���µ�  from t_quality_record qua where qua.doctype like '���µ�'and qua.pid='" + pid + "' ";
                                    DataSet ds1 = App.GetDataSet(sql);
                                    DataSet ds2 = App.GetDataSet(Tsql);
                                    if (ds1 != null)
                                    {
                                        double sum;
                                        double bookType;
                                        double book_nurse;
                                        temp.Id = null;
                                        temp.Person_in_charge = ds1.Tables[0].Rows[0]["������"].ToString();
                                        temp.Pidname = ds1.Tables[0].Rows[0]["��������"].ToString();
                                        temp.Pids = ds1.Tables[0].Rows[0]["������"].ToString();
                                        temp.Beds = ds1.Tables[0].Rows[0]["����"].ToString();
                                        if (ds2.Tables[0].Rows[0]["���µ�"].ToString() != "")
                                        {
                                            temp.Book_type = Convert.ToDouble(ds2.Tables[0].Rows[0]["���µ�"].ToString());
                                        }
                                        else
                                        {
                                            temp.Book_type = Convert.ToDouble(types);
                                        }
                                        if (ds1.Tables[0].Rows[0]["�ϼ�"].ToString() != "")
                                        {
                                            temp.Book_weizhong = Convert.ToDouble(ds1.Tables[0].Rows[0]["�ϼ�"].ToString());
                                        }
                                        else
                                        {
                                            temp.Book_weizhong =Convert.ToDouble(nuse);
                                        }
                                        bookType = temp.Book_type;
                                        book_nurse = temp.Book_weizhong;
                                        sum = bookType + book_nurse;
                                        if (sum == null)
                                        {
                                            sum = 0;
                                        }
                                        temp.Total = sum;
                                        temp.Sick_id = sick_ID;
                                        temp.Sick_name = sick_Name;
                                        temp.Section_id = section_ID;
                                        temp.Section_name = section_Name;
                                        temp.Look_over = cha_name;
                                        double value = temp.Book_type;
                                        double value_nurse = temp.Book_weizhong;
                                        double valueTotal = temp.Total;
                                        sum1 += value;
                                        sum2 += value_nurse;
                                        sum3 += value + value_nurse;
                                       
                                    }
                                    Sqls.Add(temp);
                                    t = Sqls.Count;
                                }
                                else if (chkTemperture.Checked == true)
                                {
                                    see_particulars = "���µ�";
                                    
                                    sql = "select  t.sick_doctor_name as ������,t.patient_name as ��������,t.pid as  ������,t.sick_bed_no as ����," +
                                        @"(select sum(qua.take_grade)  from t_quality_record qua where qua.doctype='���µ�'and qua.pid='" + pid + "') as �ϼ� " +
                                         @"from t_in_patient t where t.pid='" + pid + "'";
                                    DataSet ds = App.GetDataSet(sql);

                                    if (ds != null)
                                    {
                                        temp.Id = null;
                                        temp.Person_in_charge = ds.Tables[0].Rows[0]["������"].ToString();
                                        temp.Pidname = ds.Tables[0].Rows[0]["��������"].ToString();
                                        temp.Pids = ds.Tables[0].Rows[0]["������"].ToString();
                                        temp.Beds = ds.Tables[0].Rows[0]["����"].ToString();
                                        if (ds.Tables[0].Rows[0]["�ϼ�"].ToString() != "")
                                        {
                                            temp.Book_type =Convert.ToDouble(ds.Tables[0].Rows[0]["�ϼ�"].ToString());
                                        }
                                        else
                                        {
                                            temp.Book_type = Convert.ToDouble(types);
                                        }
                                        temp.Book_weizhong =Convert.ToDouble(null);
                                        temp.Total = temp.Book_type;
                                        temp.Sick_id = sick_ID;
                                        temp.Sick_name = sick_Name;
                                        temp.Section_id = section_ID;
                                        temp.Section_name = section_Name;
                                        temp.Look_over = cha_name;
                                        double value = temp.Book_type;
                                        sum1 +=value;
                                        sum3 += value;
                                       
                                    }
                                    Sqls.Add(temp);
                                    t = Sqls.Count;
                                }
                                else if (chkGravenurserecord.Checked == true)
                                {
                                    see_particulars_nurse = "Σ��";
                                    sql = "select  t.sick_doctor_name as ������,t.patient_name as ��������,t.pid as  ������,t.sick_bed_no as ����," +
                                         @"(select sum(qua.take_grade)  from t_quality_record qua where qua.doctype like 'Σ��'and qua.pid='" + pid + "') as �ϼ� " +
                                          @"from t_in_patient t where t.pid='" + pid + "'";
                                    DataSet ds1 = App.GetDataSet(sql);
                                    if (ds1 != null)
                                    {
                                        temp.Id = null;
                                        temp.Person_in_charge = ds1.Tables[0].Rows[0]["������"].ToString();
                                        temp.Pidname = ds1.Tables[0].Rows[0]["��������"].ToString();
                                        temp.Pids = ds1.Tables[0].Rows[0]["������"].ToString();
                                        temp.Beds = ds1.Tables[0].Rows[0]["����"].ToString();
                                        temp.Book_type =Convert.ToDouble(null) ;
                                        if (ds1.Tables[0].Rows[0]["�ϼ�"].ToString() != "")
                                        {
                                            temp.Book_weizhong = Convert.ToDouble(ds1.Tables[0].Rows[0]["�ϼ�"].ToString());
                                        }
                                        else
                                        {
                                            temp.Book_weizhong = Convert.ToDouble(nuse);
                                        }

                                        temp.Total = temp.Book_weizhong;
                                        temp.Sick_id = sick_ID;
                                        temp.Sick_name = sick_Name;
                                        temp.Section_id = section_ID;
                                        temp.Section_name = section_Name;
                                        temp.Look_over = cha_name;
                                         
                                        double value_nurse = temp.Book_weizhong;
                                        
                                        sum2 += value_nurse;
                                        sum3 += value_nurse;
                                    }
                                    Sqls.Add(temp);
                                    t = Sqls.Count;
                                }
                            }
                        }
                    }
                    Class_Grade tempGrad = new Class_Grade();
                    if (chkTemperture.Checked == true && chkGravenurserecord.Checked == true)
                    {

                        tempGrad.Id = null;
                        tempGrad.Person_in_charge = name;
                        tempGrad.Pidname = null;
                        tempGrad.Pids = null;
                        tempGrad.Beds = null;
                        string fgsum1 = Tvalues(sum1.ToString());
                        string fgsum2 = Tvalues(sum2.ToString());
                        string fgsum3 = Tvalues(sum3.ToString());
                        tempGrad.Book_type = Convert.ToDouble(fgsum1);
                        tempGrad.Book_weizhong = Convert.ToDouble(fgsum2);
                        tempGrad.Total = Convert.ToDouble(fgsum3);
                        tempGrad.Sick_id = null;
                        tempGrad.Sick_name = null;
                        tempGrad.Section_id = null;
                        tempGrad.Section_name = null;
                        tempGrad.Look_over = null;
                        Sqls.Add(tempGrad);
                    }
                    else if (chkTemperture.Checked == true)
                    {
                        
                        tempGrad.Id = null;
                        tempGrad.Person_in_charge = name;
                        tempGrad.Pidname = null;
                        tempGrad.Pids = null;
                        tempGrad.Beds = null;
                        string fgsum1 = Tvalues(sum1.ToString());
                        string fgsum3 = Tvalues(sum3.ToString());
                        tempGrad.Book_type = Convert.ToDouble(fgsum1);
                        tempGrad.Book_weizhong =Convert.ToDouble(null);
                        tempGrad.Total = Convert.ToDouble(fgsum3);
                        tempGrad.Sick_id = null;
                        tempGrad.Sick_name = null;
                        tempGrad.Section_id = null;
                        tempGrad.Section_name = null;
                        tempGrad.Look_over = null;
                        Sqls.Add(tempGrad);
                    }
                    else if (chkGravenurserecord.Checked == true)
                    {
                      
                        tempGrad.Id = null;
                        tempGrad.Person_in_charge = name;
                        tempGrad.Pidname = null;
                        tempGrad.Pids = null;
                        tempGrad.Beds = null;
                        tempGrad.Book_type =Convert.ToDouble( null);
                        string fgsum2 = Tvalues(sum2.ToString());
                        string fgsum3 = Tvalues(sum3.ToString());
                        tempGrad.Book_weizhong =Convert.ToDouble(fgsum2);
                        tempGrad.Total = Convert.ToDouble(fgsum3);
                        tempGrad.Sick_id = null;
                        tempGrad.Sick_name = null;
                        tempGrad.Section_id = null;
                        tempGrad.Section_name = null;
                        tempGrad.Look_over = null;
                        Sqls.Add(tempGrad);
                    }
                    Class_Grade[] Cbgrecode = new Class_Grade[Sqls.Count];
                    for (int r = 0; r < Sqls.Count; r++)
                    {                        
                        Cbgrecode[r] = new Class_Grade();
                        Cbgrecode[r] = (Class_Grade)Sqls[r];
                    }
                    try
                    {
                        if (Cbgrecode.Length != 0)
                        {
                            App.ArrayToGrid(ucflgView.fg, Cbgrecode, colss, 2);
                        }
                    }
                    catch
                    {
                    }
                
                    CellUnits();
                    ucflgView.fg.AllowEditing = false;
                    ucflgView.fg.Cols[1].TextAlign = TextAlignEnum.CenterCenter;
                    ucflgView.fg.Cols[2].TextAlign = TextAlignEnum.CenterCenter;
                    ucflgView.fg.Cols[3].TextAlign = TextAlignEnum.CenterCenter;
                    ucflgView.fg.Cols[4].TextAlign = TextAlignEnum.CenterCenter;
                    ucflgView.fg.Cols[5].TextAlign = TextAlignEnum.CenterCenter;
                    ucflgView.fg.Cols[6].TextAlign = TextAlignEnum.CenterCenter;
                    ucflgView.fg.Cols[7].TextAlign = TextAlignEnum.CenterCenter;
                    ucflgView.fg.Cols[8].TextAlign = TextAlignEnum.CenterCenter;
                    ucflgView.fg.Cols[9].TextAlign = TextAlignEnum.CenterCenter;
                    ucflgView.fg.Cols[10].TextAlign = TextAlignEnum.CenterCenter;
                    ucflgView.fg.Cols[11].TextAlign = TextAlignEnum.CenterCenter;
                    ucflgView.fg.Cols[12].TextAlign = TextAlignEnum.CenterCenter;

                }


            }
        }
        private string Tvalues(string value)
        {
            string Tvalued = ""; 
            if (value.ToString().Contains("."))
            {
                //��ȡС���������
                int index = value.ToString().IndexOf('.');
                //��ȡ��С��������һλС��
                Tvalued = value.ToString().Substring(0, index + 2);
            }
            else
            {
                Tvalued = value.ToString() + ".0";
            }
            return Tvalued;

        }
        /// <summary>
        /// �鿴���µ���Σ�ػ����¼���۷���Ϣ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucflgView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ucflgView.fg.RowSel > 1)
            {
               
                if (ucflgView.fg[1, ucflgView.fg.ColSel].ToString().Trim() == "����")
                {
                    string pid = "";
                    if (ucflgView.fg[ucflgView.fg.RowSel, 3] == null)
                    {
                        return;
                    }
                    if (ucflgView.fg[ucflgView.fg.RowSel, 3].ToString() != "")
                    {
                        pid = ucflgView.fg[ucflgView.fg.RowSel, 3].ToString();
                    }
                    string person_in_charge = ucflgView.fg[ucflgView.fg.RowSel, 1].ToString();
                    if (chkTemperture.Checked == true)
                    {
                        see_particulars = "���µ�";
                    }
                    else
                    {
                        see_particulars = null;
                    }
                    if (chkGravenurserecord.Checked == true)
                    {
                        see_particulars_nurse = "Σ��";
                    }
                    else
                    {
                        see_particulars_nurse = null;
                    }
                    FrmSee_Particulars frm = new FrmSee_Particulars(pid, person_in_charge,see_particulars,see_particulars_nurse);
                    frm.Dock = DockStyle.Fill;
                    frm.ShowDialog();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string pid = "";//������
            string person_in_charge = "";//������
            string Sick_ID = "";//����ID
            string Sick_Name = "";//��������
            string Section_ID = "";//����ID
            string Section_Name = "";//��������
            string[] Tempstr =null;
            if (ucflgView.fg.RowSel > 1)
            {
                for (int i = 2; i < ucflgView.fg.Rows.Count; i++)
                {
                    if (ucflgView.fg[i, 3]!= null)
                    {
                        pid = ucflgView.fg[i, 3].ToString();
                    }
                    person_in_charge = ucflgView.fg[i, 1].ToString();
                    Sick_ID = ucflgView.fg[i, 8].ToString();
                    Sick_Name = ucflgView.fg[i, 9].ToString();
                    Section_ID = ucflgView.fg[i, 10].ToString();
                    Section_Name = ucflgView.fg[i, 11].ToString();
                    if (pid != "")
                    {
                        string sql1 = "";
                    
                        if (chkTemperture.Checked == true)
                        {
                            sql1 = "select qua.pid as ������,pat.sick_doctor_id as �����˱��,pat.sick_doctor_name as ������,qua.note as �۷ֵ�,qua.doctype as �۷�����,to_char(qua.noteztime,'yyyy-MM-dd hh:mi:ss') as ��¼ʱ��," +
                             @"qua.take_grade as �۷�ֵ from t_quality_record qua inner join t_in_patient pat on pat.pid=qua.pid where qua.pid='" + pid + "'  and qua.doctype like '%���µ�%' order by to_char(qua.noteztime,'yyyy-MM-dd hh:mi:ss') desc";
                        }
                        if (chkGravenurserecord.Checked == true)
                        {
                            sql1 = "select qua.pid as ������,pat.sick_doctor_id as �����˱��,pat.sick_doctor_name as ������,qua.note as �۷ֵ�,qua.doctype as �۷�����,to_char(qua.noteztime,'yyyy-MM-dd hh:mi:ss') as ��¼ʱ��," +
                             @"qua.take_grade as �۷�ֵ from t_quality_record qua inner join t_in_patient pat on pat.pid=qua.pid where qua.pid='" + pid + "' and qua.doctype like '%Σ��%' order by to_char(qua.noteztime,'yyyy-MM-dd hh:mi:ss') desc";
                        }
                        //���µ���Σ�ػ����¼����Ϊtrue
                        if (chkTemperture.Checked == true && chkGravenurserecord.Checked == true)
                        {
                            sql1 = "select qua.pid as ������,pat.sick_doctor_id as �����˱��,pat.sick_doctor_name as ������,qua.note as �۷ֵ�,qua.doctype as �۷�����,to_char(qua.noteztime,'yyyy-MM-dd hh:mi:ss') as ��¼ʱ��," +
                             @"qua.take_grade as �۷�ֵ from t_quality_record qua inner join t_in_patient pat on pat.pid=qua.pid where qua.pid='" + pid + "'  and qua.doctype like '%���µ�%' or  qua.pid='1213345' and qua.doctype like '%Σ��%' order by to_char(qua.noteztime,'yyyy-MM-dd hh:mi:ss') desc";
                        }

                        DataSet ds = App.GetDataSet(sql1);
                        if (ds != null)
                        {
                            DataTable dt = ds.Tables[0];
                            if (dt != null)
                            {
                                Tempstr = new string[dt.Rows.Count];
                                for (int j = 0; j < dt.Rows.Count; j++)
                                {
                                    Class_Toshow_particulars pat = new Class_Toshow_particulars();
                                    pat.Pids = dt.Rows[j]["������"].ToString();
                                    pat.Person_in_change_id = dt.Rows[j]["�����˱��"].ToString();
                                    pat.Person_in_change = dt.Rows[j]["������"].ToString();
                                    pat.Deduct_mark = dt.Rows[j]["�۷ֵ�"].ToString();
                                    pat.Deduct_mark_book = dt.Rows[j]["�۷�����"].ToString();
                                    pat.Record_time = dt.Rows[j]["��¼ʱ��"].ToString();
                                    pat.Deduct_mark_value = dt.Rows[j]["�۷�ֵ"].ToString();
                                    string ss = "select PID,DOWN_POINT_1,DOWN_REASON_1,GRADE_DOC_ID,GRADE_DOC_NAME,GRADE_TIME,DOC_TYPE  from T_NURSE_GRADE where  pid='" + pat.Pids + "' and GRADE_TIME= to_timestamp('" + lblTime.Text + "','syyyy-mm-dd hh24:mi:ss.ff9')  and DOC_TYPE='" + pat.Deduct_mark_book + "'";//DOWN_REASON_1='" + pat.Deduct_mark + "' and DOC_TYPE='" + pat.Deduct_mark_book + "'
                                    DataSet dst = App.GetDataSet(ss);
                                    int count1 = dst.Tables[0].Select(" pid='" + pat.Pids + "' and GRADE_TIME='" + lblTime.Text + "' and DOC_TYPE='" + pat.Deduct_mark_book + "'").Length;
                                    if (count1 == 0)
                                    {
                                        Tempstr[j] = "insert into T_NURSE_GRADE(PID,DOWN_POINT_1,DOWN_REASON_1,GRADE_DOC_ID,GRADE_DOC_NAME,GRADE_TIME,DOC_TYPE,SICKAREA_ID,SICKAREA_NAME,SECTION_ID,SECTION_NAME) values('"
                                           + pat.Pids + "','" + pat.Deduct_mark_value + "','" + pat.Deduct_mark + "','" + pat.Person_in_change_id + "','"
                                           + pat.Person_in_change + "',to_timestamp('" + lblTime.Text + "','syyyy-mm-dd hh24:mi:ss.ff9'),'" +pat.Deduct_mark_book + "','"+Sick_ID+"','"+Sick_Name+"','"+Section_ID+"','"+Section_Name+"')";
                                    }
                                    else
                                    {
                                        Tempstr[j] = "update  T_NURSE_GRADE set DOWN_POINT_1='" + pat.Deduct_mark_value + "', DOWN_REASON_1='" + pat.Deduct_mark + "',GRADE_DOC_ID='" + pat.Person_in_change_id + "',GRADE_DOC_NAME='"
                                            + pat.Person_in_change + "',SICKAREA_ID='" + Sick_ID + "',SICKAREA_NAME='" + Sick_Name + "',SECTION_ID='" + Section_ID + "',SECTION_NAME='" + Section_Name + "'  where PID='" + pat.Pids + "' and  GRADE_TIME=to_timestamp('" + lblTime.Text + "','syyyy-mm-dd hh24:mi:ss.ff9')  and DOC_TYPE='" + pat.Deduct_mark_book + "'";
                                    } 
                                }
                            }
                            if (Tempstr != null)
                            {
                                App.ExecuteBatch(Tempstr);
                                //if (App.ExecuteBatch(Tempstr) > 0)
                                //{
                                //    App.Msg("����ɹ�!");
                                //}
                            }
                        } 
                    }
                }
                App.Msg("����ɹ�!");
            }
        }

        private void flgView_Click(object sender, EventArgs e)
        {
            if (flgView.fg.ColSel > 0)
            {
                flgView.fg.Cols[1].AllowEditing = false;
                flgView.fg.Cols[2].AllowEditing = false;
                flgView.fg.Cols[3].AllowEditing = false;
                flgView.fg.Cols[4].AllowEditing = false;
                flgView.fg.Cols[5].AllowEditing = false;
                flgView.fg.Cols[6].AllowEditing = false;
                flgView.fg.Cols[7].AllowEditing = false;
                flgView.fg.Cols[8].AllowEditing = false;
               

            }
            else
            {
                if (flgView.fg.RowSel > 1)
                {
                    if (flgView.fg[flgView.fg.RowSel, 0] == null)
                    {
                        return;
                    }
                    else
                    {
                        if (flgView.fg[flgView.fg.RowSel, 0].ToString().ToLower() == "False" || flgView.fg[flgView.fg.RowSel, 0].ToString().ToLower() == "false")
                        {
                            flgView.fg[flgView.fg.RowSel, 0] = null;

                        }
                    }
                }
            }
        }

        private void ucflgView_Click(object sender, EventArgs e)
        {
            ucflgView.fg.Cols[0].AllowEditing = false;
            ucflgView.fg.Cols[1].AllowEditing = false;
            ucflgView.fg.Cols[2].AllowEditing = false;
            ucflgView.fg.Cols[3].AllowEditing = false;
            ucflgView.fg.Cols[4].AllowEditing = false;
            ucflgView.fg.Cols[5].AllowEditing = false;
            ucflgView.fg.Cols[6].AllowEditing = false;
            ucflgView.fg.Cols[7].AllowEditing = false;
            flgView.fg.Cols[8].AllowEditing = false;
            flgView.fg.Cols[9].AllowEditing = false;
            flgView.fg.Cols[10].AllowEditing = false;
            flgView.fg.Cols[11].AllowEditing = false;

        }

    


        //private void lblTime_Leave(object sender, EventArgs e)
        //{
        //    lblTime.Text = System.App.GetSystemTime().ToString("yyyy-MM-dd HH:mm");
        //}

        //private void lblTime_AutoSizeChanged(object sender, EventArgs e)
        //{
        //    lblTime.Text = System.App.GetSystemTime().ToString("yyyy-MM-dd HH:mm");
        //}
    }
 }
