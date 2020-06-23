using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using System.Text.RegularExpressions;
using System.Collections;
using C1.Win.C1FlexGrid;
using Base_Function.BASE_COMMON;
using Base_Function.MODEL;

namespace Base_Function.BLL_NURSE.NBlood_sugarRecord
{
    public partial class ucBlood_Sugar_Record : UserControl
    {

        ColumnInfo[] cols = new ColumnInfo[10];
        private bool isSave = false;//���ڴ�ŵ�ǰ�Ĳ���״̬ trueΪ��Ӳ��� falseΪ�޸Ĳ���
        private string ID = "";
        ArrayList Bgrecode = new ArrayList();
        private int RowIndex = 0;    //��¼��Ԫ�������
        private int ColIndex = 0;    //��¼��Ԫ�������
        private string SelectCellVal = "��ֵ";  //��¼��ǰѡ�е�Ԫ���ֵ 
        private string bed;

        private string pname;

        private string pid; //��ȡ�û�PID

        private string pid_ids;

    
        /// <summary>
        ///  ���˴���
        /// </summary>
        public string Bed
        {
            get { return bed; }
            set { bed = value; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string Pname
        {
            get { return pname; }
            set { pname = value; }
        }
         /// <summary>
         /// ����סԺ��
         /// </summary>
        public string Pid
        {
            get { return pid; }
            set { pid = value; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public string Pid_ids
        {
            get { return pid_ids; }
            set { pid_ids = value; }
        }
        
        UserPower userpower = new UserPower();
        public ucBlood_Sugar_Record()
        {
            InitializeComponent();
        }
        /// <summary>
        /// ��ȡbed_no,pname,pid�Ĺ��캯��
        /// </summary>InPatientInfo inpatientinfo
        /// <param name="bed_no">���˴���</param>
        /// <param name="pname">��������</param>
        /// <param name="pid">����סԺ��</param>
        /// <param name="pid_id">��������</param>
        public ucBlood_Sugar_Record(string bed_no, string pname, string pid,string pid_id)
        {
            try
            {
                InitializeComponent();

                Bed = bed_no;
                this.lblBed_no.Text = Bed;
                Pname = pname;
                this.lblPname.Text = Pname;
                Pid = pid;
                this.lblHosNumber.Text = Pid;
                Pid_ids = pid_id;
                //btnPrint.Enabled = false;
                //btnAdd.Enabled = false;
                //btnSave.Enabled = false;
                //btnCancel.Enabled = false;
                ////�鿴��Ȩ��
                //if (userpower.isExistRole("tsbtnLook", arraylist))
                //{
                //    this.btnSelect.Enabled = true;
                //}
                ////��д��Ȩ��
                //if (userpower.isExistRole("tsbtnWrite", arraylist))
                //{
                //    this.btnAdd.Enabled = true;
                //    this.btnSave.Enabled = true;
                //    this.btnCancel.Enabled = true;
                //}
                ////��ӡȨ��
                //if (userpower.isExistRole("ttsbtnPrint", arraylist))
                //{
                //    btnPrint.Enabled = true;
                //}
            }
            catch (Exception e)
            {
            }

        }
       /// <summary>
       /// ��ȡbed_no,pname,pid�Ĺ��캯��
      /// </summary>InPatientInfo inpatientinfo
      /// <param name="bed_no">���˴���</param>
      /// <param name="pname">��������</param>
      /// <param name="pid">����סԺ��</param>
        public ucBlood_Sugar_Record(string bed_no, string pname, string pid,string pid_id,ArrayList arraylist)
        {
            try
            {
                InitializeComponent();

                Bed = bed_no;
                this.lblBed_no.Text = Bed;
                Pname = pname;
                this.lblPname.Text = Pname;
                Pid = pid;
                this.lblHosNumber.Text = Pid;
                Pid_ids = pid_id;
                btnPrint.Enabled = false;
                btnAdd.Enabled = false;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                //�鿴��Ȩ��
                if (userpower.isExistRole("tsbtnLook", arraylist))
                {
                    this.btnSelect.Enabled = true;
                }
                //��д��Ȩ��
                if (userpower.isExistRole("tsbtnWrite", arraylist))
                {
                    this.btnAdd.Enabled = true;
                    this.btnSave.Enabled = true;
                    this.btnCancel.Enabled = true;
                }
                //��ӡȨ��
                if (userpower.isExistRole("ttsbtnPrint", arraylist))
                {
                    btnPrint.Enabled = true;
                }
            }
            catch (Exception e)
            {
            }

        }     
        private void ucBlood_Sugar_Record_Load(object sender, EventArgs e)
        {
            try
            {
                App.SetMainFrmMsgToolBarText("Ѫ�Ǽ�ⵥ��Ϣ");
                //Type();
                ShowGrid();
                flgView.AllowEditing = false;
                //cboType.SelectedIndex = 0;
                //RefleshFrm();
            }
            catch
            {
            }
        }
        //��Ѫ�Ǽ������
        private void Type()
        {
            DataSet ds = App.GetDataSet("select * from T_DATA_CODE where TYPE=24");
            cboType.DataSource = ds.Tables[0].DefaultView;
            cboType.ValueMember = "ID";
            cboType.DisplayMember = "NAME";

        }
        /// <summary>
        /// ˢ��
        /// </summary>
        private void RefleshFrm()
        {
            dtpDatetime.Enabled = false;
            txtValue.Enabled = false;
            cboType.Enabled = false;
            txtTosign.Enabled = false;
            btnAdd.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            //groupBox2.Enabled = true;
            isSave = false;

        }

        /// <summary>
        /// �༭״̬
        /// </summary>
        /// <param Name="flag"></param>
        private void Edit(bool flag)
        {
            if (flag)
            {
                dtpDatetime.Text = "";
                txtValue.Text = "";
                txtTosign.Text = "";
            }
            dtpDatetime.Enabled = true;
            txtValue.Enabled = true;
            cboType.Enabled = true;
            txtTosign.Enabled = true;
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            //groupBox2.Enabled = true;
            dtpDatetime.Focus();
        }

        /// <summary>
        /// �ж��Ƿ��������
        /// </summary>
        /// <param Name="Date">��ǰʱ��</param>
        /// <returns></returns>
        private string isExisitDate(string date)
        {

            DataSet ds = App.GetDataSet("select id from  t_Periphery_Bg_Record  where RECORD_TIME=to_timestamp('" + date + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_kind=" + cboType.SelectedValue.ToString() + "");
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    return "0";
                }
            }
            else
            {
                return "0";
            }
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtValue.Text.Trim() == "")
            {
                App.Msg("Ѫ�Ǽ�ⵥ��ֵ����Ϊ�գ�");
                txtValue.Focus();
                return;
            }
            else
            {
                string pattern = @"^\d+(\.\d)?$";
                if (txtValue.Text.Trim() != "")
                {
                    if (!Regex.IsMatch(txtValue.Text.Trim(), pattern))
                    {
                        App.Msg("���ֵֻ��������ֵ����");
                        txtValue.Focus();
                        txtValue.Clear();
                        return;
                    }
                 
                }
            }

            string Date = dtpDatetime.Value.ToString("yyyy-MM-dd HH:mm");
            string SQL = "";
            ID = App.GenId("T_PERIPHERY_BG_RECORD", "ID").ToString();
            if (isSave)
            {
                string IDP = isExisitDate(Date);

                if (IDP == "0")
                {
                    try
                    {

                        SQL = "insert into T_PERIPHERY_BG_RECORD(ID,PID,RECORD_TIME,ITEM_VALUE,ITEM_KIND,RECORD_ID,RECORD_NAME) values('"
                           + ID + "','"
                           + Pid + "',to_timestamp('"
                           + Date + "','syyyy-mm-dd hh24:mi:ss.ff9'),'"
                           + txtValue.Text + "','"
                           + cboType.SelectedValue + "','"
                           + App.SelectObj.Select_Val + "','"
                           + txtTosign.Text + "')";
                    }
                    catch (Exception ex)
                    {
                        App.MsgErr("����д��ȷ��ǩ��!");
                    }
                 
                }
                else
                {
                    SQL = "update T_PERIPHERY_BG_RECORD set ITEM_VALUE='" + txtValue.Text + "' where id=" + IDP + "";
                }
                btnAdd_Click(sender, e);
            }
            if (App.ExecuteSQL(SQL) > 0)
                App.Msg("�����ѳɹ���");
            btnSelect_Click(sender, e);

        }
        /// <summary>
        /// ���
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            isSave = true;
            Edit(isSave);

        }
        /// <summary>
        /// ȡ��
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            RefleshFrm();
        }
        /// <summary>
        /// ��Ԫ��ϲ������� 
        /// </summary>
        private void CellUnit()
        {
            //��Ԫ��ϲ�������         
            flgView[0, 0] = "����";
            //flgView[0, 1] = "����";
            flgView[0, 1] = "7:00";
            flgView[0, 2] = "9:30";
            flgView[0, 3] = "11:00";
            flgView[0, 4] = "14:00";
            flgView[0, 5] = "17:00";
            flgView[0, 6] = "20:00";
            flgView[0, 7] = "22:00";
            flgView[0, 8] = "0:00";
            flgView[0, 9] = "03:00";
            //flgView[0, 10] = "סԺ��";
            //flgView[0, 11] = "�Ʊ�";
            //flgView[0, 12] = "����";
            //flgView[0, 13] = "��Ժʱ��";
            //flgView[0, 15] = "����";
            //flgView[0, 16] = "��ӡ";
            //flgView[0, 17] = "���˱��";
            flgView.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            flgView.Cols.Fixed = 0;

            C1.Win.C1FlexGrid.CellRange cr;
            cr = flgView.GetCellRange(0, 0, 0, 0);
            cr.Data = "����";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            //cr = flgView.GetCellRange(0, 1, 0, 1);
            //cr.Data = "����";
            //cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            //flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 1, 0, 1);
            cr.Data = "7:00";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 2, 0, 2);
            cr.Data = "9:30";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 3, 0, 3);
            cr.Data = "11:00";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 4, 0, 4);
            cr.Data = "14:00";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 5, 0, 5);
            cr.Data = "17:00";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 6, 0, 6);
            cr.Data = "20:00";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);


            cr = flgView.GetCellRange(0, 7, 0, 7);
            cr.Data = "22:00";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 8, 0, 8);
            cr.Data = "0:00";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 9, 0, 9);
            cr.Data = "03:00";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            //cr = flgView.GetCellRange(0, 11, 0, 11);
            //cr.Data = "סԺ��";
            //cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            //flgView.MergedRanges.Add(cr);

            //cr = flgView.GetCellRange(0, 12, 0, 12);
            //cr.Data = "�Ʊ�";
            //cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            //flgView.MergedRanges.Add(cr);

            //cr = flgView.GetCellRange(0, 13, 0, 13);
            //cr.Data = "����";
            //cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            //flgView.MergedRanges.Add(cr);

            //cr = flgView.GetCellRange(0, 14, 0, 14);
            //cr.Data = "��Ժʱ��";
            //cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            //flgView.MergedRanges.Add(cr);

            //cr = flgView.GetCellRange(0, 15, 0, 15);
            //cr.Data = "����";
            //cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            //flgView.MergedRanges.Add(cr);

            //cr = flgView.GetCellRange(0, 16, 0, 16);
            //cr.Data = "��ӡ";
            //cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            //flgView.MergedRanges.Add(cr);
            //cr = flgView.GetCellRange(0, 17, 0, 17);
            //cr.Data = "���˱��";
            //cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            //flgView.MergedRanges.Add(cr);
            //flgView.AutoSizeCols();

            for (int i = 0; i < flgView.Cols.Count; i++)
            {
                flgView.Cols[i].Width = 70;
            }

            for (int i = 0; i < flgView.Rows.Count; i++)
            {
                flgView.Rows[i].Height = 25;
            }
            //��סԺ�š��Ʊ𡢲�������Ժʱ�䡢��������
            //flgView.Cols[11].Visible = false;
            //flgView.Cols[11].AllowEditing = false;

            //flgView.Cols[12].Visible = false;
            //flgView.Cols[12].AllowEditing = false;

            //flgView.Cols[13].Visible = false;
            //flgView.Cols[13].AllowEditing = false;

            //flgView.Cols[14].Visible = false;
            //flgView.Cols[14].AllowEditing = false;

            //flgView.Cols[15].Visible = false;
            //flgView.Cols[15].AllowEditing = false;
            //flgView.Cols[17].Visible = false;
            //flgView.Cols[17].AllowEditing = false;

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
            //flgView.Cols[10].TextAlign = TextAlignEnum.CenterCenter;
            //flgView.Cols[11].TextAlign = TextAlignEnum.CenterCenter;
            //flgView.Cols[12].TextAlign = TextAlignEnum.CenterCenter;
            //flgView.Cols[13].TextAlign = TextAlignEnum.CenterCenter;
            //flgView.Cols[14].TextAlign = TextAlignEnum.CenterCenter;
    
        }
        /// <summary>
        /// ��ͷ����
        /// </summary>
        private void SetTable()
        {
            //flgView.Cols.Count = 11;
            //flgView.Rows.Count = 2;
            //flgView.Rows.Fixed = 2;
            ////��ͷ����
            //cols[0].Name = "����";
            //cols[0].Field = "date";
            //cols[0].Index = 1;
            //cols[0].visible = true;

            //cols[1].Name = "���mmol/L";
            //cols[1].Field = "limosis";
            //cols[1].Index = 2;
            //cols[1].visible = true;

            //cols[2].Name = "ǩ��";
            //cols[2].Field = "limosis_tosign";
            //cols[2].Index = 3;
            //cols[2].visible = true;

            //cols[3].Name = "���mmol/L";
            //cols[3].Field = "breakfast";
            //cols[3].Index = 4;
            //cols[3].visible = true;

            //cols[4].Name = "ǩ��";
            //cols[4].Field = "breakfast_tosign";
            //cols[4].Index = 5;
            //cols[4].visible = true;

            //cols[5].Name = " ���mmol/L";
            //cols[5].Field = "lunch";
            //cols[5].Index = 6;
            //cols[5].visible = true;

            //cols[6].Name = "ǩ��";
            //cols[6].Field = "lunch_tosign";
            //cols[6].Index = 7;
            //cols[6].visible = true;

            //cols[7].Name = "���mmol/L";
            //cols[7].Field = "evening_meal";
            //cols[7].Index = 8;
            //cols[7].visible = true;

            //cols[8].Name = "ǩ��";
            //cols[8].Field = "evening_meal_tosign";
            //cols[8].Index = 9;
            //cols[8].visible = true;

            //cols[9].Name = "��ע";
            //cols[9].Field = "remarks";
            //cols[9].Index = 10;
            //cols[9].visible = true;

            //cols[10].Name = "ǩ��";
            //cols[10].Field = "remarks_tosign";
            //cols[10].Index = 11;
            //cols[10].visible = true;

            //��Ԫ��ϲ�������           
            flgView.Cols.Count = 10;
            flgView.Cols.Fixed = 0;
            flgView.Rows.Count = 1;
            flgView.Rows.Fixed = 1;
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
            return str;
        }

        //��ʾ�������
        public void ShowGrid()
        {

            //Bgrecode.Clear();
            //SetTable();
            #region
            //string sql = "select * from v_periphery_bg_record  where PID='"+Pid+"' order by ���� asc";
            //DataSet ds = App.GetDataSet(sql);
            //if (ds != null)
            //{
            //    DataTable dt = ds.Tables[0];
            //    if (dt != null)
            //    {
            //        for (int i = 0; i < dt.Rows.Count; i++)
            //        {
            //            Class_Bgrecode temp = new Class_Bgrecode();
            //            temp.Date = Convert.ToDateTime(dt.Rows[i]["����"]).ToString("yyyy-MM-dd HH:mm");
            //            temp.Limosis = dt.Rows[i]["�ո�"].ToString();
            //            temp.Limosis_tosign = dt.Rows[i]["�ո�ǩ��"].ToString();
            //            temp.Breakfast = dt.Rows[i]["��ͺ�2Сʱ"].ToString();
            //            temp.Breakfast_tosign = dt.Rows[i]["��ͺ�2Сʱǩ��"].ToString();
            //            temp.Lunch = dt.Rows[i]["��ͺ�2Сʱ"].ToString();
            //            temp.Lunch_tosign = dt.Rows[i]["��ͺ�2Сʱǩ��"].ToString();
            //            temp.Evening_meal = dt.Rows[i]["��ͺ�2Сʱ"].ToString();
            //            temp.Evening_meal_tosign = dt.Rows[i]["��ͺ�2Сʱǩ��"].ToString();
            //            temp.Remarks = dt.Rows[i]["��ע"].ToString();
            //            temp.Remarks_tosign = dt.Rows[i]["��עǩ��"].ToString();

            //            temp.Limosis = isExNot(temp.Limosis);
            //            temp.Limosis_tosign = isExNot(temp.Limosis_tosign);
            //            temp.Breakfast = isExNot(temp.Breakfast);
            //            temp.Breakfast_tosign = isExNot(temp.Breakfast_tosign);
            //            temp.Lunch = isExNot(temp.Lunch);
            //            temp.Lunch_tosign = isExNot(temp.Lunch_tosign);
            //            temp.Evening_meal = isExNot(temp.Evening_meal);
            //            temp.Evening_meal_tosign = isExNot(temp.Evening_meal_tosign);
            //            temp.Remarks = isExNot(temp.Remarks);
            //            temp.Remarks_tosign = isExNot(temp.Remarks_tosign);
            //           Bgrecode.Add(temp);

            //        }

            //        //����
            //        string TempDate = null;

            //        Class_Bgrecode[] Cbgrecode = new Class_Bgrecode[Bgrecode.Count];
            //        for (int j = 0; j < Bgrecode.Count; j++)
            //        {
            //            Cbgrecode[j] = new Class_Bgrecode();
            //            Cbgrecode[j] = (Class_Bgrecode)Bgrecode[j];
            //            TempDate = Cbgrecode[j].Date;


            //        }
            //        try
            //        {
            //            if (Cbgrecode.Length!=0)
            //            {
            //                App.ArrayToGrid(flgView, Cbgrecode, cols, 2);
            //            }
            //        }
            //        catch
            //        {
            //        }
            //        CellUnit();
            //        flgView.Cols[0].TextAlign =TextAlignEnum.CenterCenter;
            //        flgView.Cols[1].TextAlign = TextAlignEnum.CenterCenter;
            //        flgView.Cols[2].TextAlign = TextAlignEnum.CenterCenter;
            //        flgView.Cols[3].TextAlign = TextAlignEnum.CenterCenter;
            //        flgView.Cols[4].TextAlign = TextAlignEnum.CenterCenter;
            //        flgView.Cols[5].TextAlign = TextAlignEnum.CenterCenter;
            //        flgView.Cols[6].TextAlign = TextAlignEnum.CenterCenter;
            //        flgView.Cols[7].TextAlign = TextAlignEnum.CenterCenter;
            //        flgView.Cols[8].TextAlign = TextAlignEnum.CenterCenter;
            //        flgView.Cols[9].TextAlign = TextAlignEnum.CenterCenter;
            //        flgView.Cols[10].TextAlign = TextAlignEnum.CenterCenter;
            //        //flgView.Cols[11].TextAlign = TextAlignEnum.CenterCenter;
            //    }

            //}
            #endregion

            try
            {
                flgView.Clear();

                SetTable();
                //string date = dtpDate.Value.ToString("yyyy-MM-dd");
                //��ʾһ�������Ĳ���
                string PatintInfoSql = "select distinct to_char(record_time,'yyyy-mm-dd') as ����,patient_id as סԺ�� from T_PERIPHERY_BG_RECORD  where patient_id="+Pid_ids+" order by  to_char(record_time,'yyyy-mm-dd')";
                DataSet dsPatint = App.GetDataSet(PatintInfoSql);

                //��ѯ���е�Ѫ�Ǽ�ⵥ
                //string sql = "select * from v_periphery_bg_record where ����='" + date + "'"; and  to_char(tpg.record_time,'yyyy-mm-dd')='" + date + "'
                string sql = "select pat.sick_bed_no as ����,pat.patient_name as ��������,ITEM_VALUE as Ѫ��ֵ," +
                   " to_char(tpg.record_time,'yyyy-mm-dd') as ����,to_char(tpg.record_time,'HH24:mi') as ʱ��," +
                    "tpg.patient_id as סԺ��,pat.section_name as �Ʊ�,pat.sick_area_name as ����,pat.in_time as ��Ժʱ�� " +
                    " from T_PERIPHERY_BG_RECORD tpg left join T_IN_PATIENT pat on tpg.patient_id=pat.id " +
                   " where pat.sick_bed_no is not null and tpg.record_time is not null";
                DataSet ds = App.GetDataSet(sql);

                if (dsPatint != null)
                {
                    /*
                    * ��ʾ���еı������Ĳ�����Ϣ
                    */
                    for (int i = 0; i < dsPatint.Tables[0].Rows.Count; i++)
                    {
                        flgView.Rows.Add();
                        Class_ucBlood_SugarRecord temp = new Class_ucBlood_SugarRecord();
                        temp.Date = dsPatint.Tables[0].Rows[i]["����"].ToString();
                        /*
                        * ������������Ӧ�Ĳ��˰�����
                        */
                        if (ds != null)
                        {

                            DataRow[] rows = ds.Tables[0].Select("סԺ��='" + Pid_ids+ "' and  ����='" + temp.Date + "'");
                            if (rows.Length > 0)
                            {
                                for (int k = 0; k < rows.Length; k++)
                                {
                                    if (rows[k]["ʱ��"].ToString() == "07:00")
                                    {
                                        temp.Values_7 = rows[k]["Ѫ��ֵ"].ToString();
                                    }
                                    else if (rows[k]["ʱ��"].ToString() == "09:30")
                                    {
                                        temp.Values_9 = rows[k]["Ѫ��ֵ"].ToString();
                                    }
                                    else if (rows[k]["ʱ��"].ToString() == "11:00")
                                    {
                                        temp.Values_11 = rows[k]["Ѫ��ֵ"].ToString();
                                    }
                                    else if (rows[k]["ʱ��"].ToString() == "14:00")
                                    {
                                        temp.Values_14 = rows[k]["Ѫ��ֵ"].ToString();
                                    }
                                    else if (rows[k]["ʱ��"].ToString() == "17:00")
                                    {
                                        temp.Values_17 = rows[k]["Ѫ��ֵ"].ToString();
                                    }
                                    else if (rows[k]["ʱ��"].ToString() == "20:00")
                                    {
                                        temp.Values_20 = rows[k]["Ѫ��ֵ"].ToString();
                                    }
                                    else if (rows[k]["ʱ��"].ToString() == "22:00")
                                    {
                                        temp.Values_22 = rows[k]["Ѫ��ֵ"].ToString();
                                    }
                                    else if (rows[k]["ʱ��"].ToString() == "00:00")
                                    {
                                        temp.Values_00 = rows[k]["Ѫ��ֵ"].ToString();
                                    }
                                    else if (rows[k]["ʱ��"].ToString() == "03:00")
                                    {
                                        temp.Values_03 = rows[k]["Ѫ��ֵ"].ToString();
                                    }
                                    if (rows[k]["����"].ToString() != "")
                                    {
                                        temp.Date = rows[k]["����"].ToString();
                                    }
                                }
                                flgView[1 + i, 0] = temp.Date;
                                flgView[1 + i, 1] = isExNot(temp.Values_7);
                                flgView[1 + i, 2] = isExNot(temp.Values_9);
                                flgView[1 + i, 3] = isExNot(temp.Values_11);
                                flgView[1 + i, 4] = isExNot(temp.Values_14);
                                flgView[1 + i, 5] = isExNot(temp.Values_17);
                                flgView[1 + i, 6] = isExNot(temp.Values_20);
                                flgView[1 + i, 7] = isExNot(temp.Values_22);
                                flgView[1 + i, 8] = isExNot(temp.Values_00);
                                flgView[1 + i, 9] = isExNot(temp.Values_03);
                                //flgView[1 + i, 10] = isExNot(temp.Pid);
                                //flgView[1 + i, 11] = isExNot(temp.Section_name);
                                //flgView[1 + i, 12] = isExNot(temp.Sickarea_name);
                                //flgView[1 + i, 13] = isExNot(temp.In_time);
                                ////flgView[1 + i, 15] = isExNot(temp.Date);
                                //flgView[1 + i, 14] = temp.Patient_id;
                               
                            }
                            //Bgrecode.Add(temp);

                        }
                    }
                    //��Ԫ��ϲ�������
                    CellUnit();
                    //for (int i = 1; i < flgView.Rows.Count; i++)
                    //{
                    //    /*
                    //      * ��ӡͼ��
                    //      */
                    //    CellRange rg1 = flgView.GetCellRange(i, 16);
                    //    rg1.Image = imageList1.Images[0];
                    //    /*
                    //     * סԺ�źͲ������������ɫ
                    //     */
                    //    CellRange rg = flgView.GetCellRange(i, 0);
                    //    rg.StyleNew.ForeColor = Color.Blue;

                    //    CellRange rg2 = flgView.GetCellRange(i, 1);
                    //    rg2.StyleNew.ForeColor = Color.Blue;
                    //}

                    //��Ԫ�������Ӵ�
                    flgView.Cols[0].StyleNew.Border.Color = Color.Black;
                    flgView.Cols[1].StyleNew.Border.Color = Color.Black;
                    flgView.Cols[2].StyleNew.Border.Color = Color.Black;
                    flgView.Cols[3].StyleNew.Border.Color = Color.Black;
                    flgView.Cols[4].StyleNew.Border.Color = Color.Black;
                    flgView.Cols[5].StyleNew.Border.Color = Color.Black;
                    flgView.Cols[6].StyleNew.Border.Color = Color.Black;
                    flgView.Cols[7].StyleNew.Border.Color = Color.Black;
                    flgView.Cols[8].StyleNew.Border.Color = Color.Black;
                    flgView.Cols[9].StyleNew.Border.Color = Color.Black;
                    //flgView.Cols[10].StyleNew.Border.Color = Color.Black;
                    //flgView.Cols[11].StyleNew.Border.Color = Color.Black;
                    //flgView.Cols[12].StyleNew.Border.Color = Color.Black;
                    //flgView.Cols[13].StyleNew.Border.Color = Color.Black;
                    //flgView.Cols[14].StyleNew.Border.Color = Color.Black;

                }

            }
            catch
            {
            }

        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            ShowGrid();
        }
        /// <summary>
        /// ��ӡ
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            //Class_Bgrecode[] Bgrecode_objs = new Class_Bgrecode[Bgrecode.Count];
            //for (int i = 0; i < Bgrecode.Count; i++)
            //{
            //    Bgrecode_objs[i] = new Class_Bgrecode();
            //    Bgrecode_objs[i] = (Class_Bgrecode)Bgrecode[i];
            //}
            //frmBlood_Sugar_Record_Print bgprit = new frmBlood_Sugar_Record_Print(App.ObjectArrayToDataSet(Bgrecode_objs), null, Bed, Pname, Pid);
            //bgprit.Show();
            //select a.item_value,b.name from t_periphery_bg_record a left join t_data_code b on b.id=a.item_kind
            //string PatintInfoSql = " select �ո�,��ͺ�2Сʱ from v_periphery_bg_record where pid='" + Pid + "' ";
            //DataSet dsPatint = App.GetDataSet(PatintInfoSql);
            //Class_Bgrecode[] Bgrecode_objs = new Class_Bgrecode[dsPatint.Tables[0].Rows.Count];

            //if (dsPatint != null)
            //{
            //    for (int j = 0; j < dsPatint.Tables[0].Rows.Count; j++)
            //    {
            //        Bgrecode_objs[j] = new Class_Bgrecode();
            //        Bgrecode_objs[j].Limosis = dsPatint.Tables[0].Rows[j]["�ո�"].ToString();
            //        Bgrecode_objs[j].Evening_meal = dsPatint.Tables[0].Rows[j]["��ͺ�2Сʱ"].ToString();

            //    }
            //}
            //FormRopert bgprit = new FormRopert(App.ObjectArrayToDataSet(Bgrecode_objs),Pid);
            //bgprit.Show();
 
        }
        /// <summary>
        /// �����¼��Ǳ��浥Ԫ������
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void flgView_Click(object sender, EventArgs e)
        {
            //if (SelectCellVal != flgView[RowIndex, ColIndex].ToString() && SelectCellVal != "��ֵ")
            //{
            //    string pattern = @"^\d+(\.\d)?$";
            //    if (flgView[RowIndex, ColIndex].ToString() != "")
            //    {
            //        if (!Regex.IsMatch(flgView[RowIndex, ColIndex].ToString(), pattern))
            //        {
            //            App.Msg("ֵֻ��Ϊ��ֵ�ͣ�");
            //            flgView.Focus();
            //            flgView[RowIndex, ColIndex] = SelectCellVal;
            //            return;
            //        }  
            //        if (App.Ask("��Ԫ���е�ֵ�Ѿ����޸Ĺ����Ƿ񱣴棿"))
            //        {
            //            string DateT = flgView[RowIndex, 0].ToString(); //��ȡʱ��

            //            /*
            //           * ��ȡ��Ŀ����
            //           */
            //            string ItemName = "";
            //            ItemName = flgView[0, ColIndex].ToString();

            //            /*
            //             * �޸Ļ�ɾ������
            //             */


            //            if (SelectCellVal.Trim() != "")
            //            {

            //                if (SelectCellVal != flgView[RowIndex, ColIndex].ToString())
            //                {

            //                    string ID = "";
            //                    /*
            //                     * ��ȡ������ID  ,STATUS_MEASURE='" +  + "'
            //                     */
            //                    ID = GetSelectItemId(ItemName, DateT);
            //                    App.ExecuteSQL("Update T_PERIPHERY_BG_RECORD set item_value='" + flgView[RowIndex, ColIndex].ToString() + "' where ID=" + ID + "");
            //                }
            //            }
            //            else
            //            {
            //                App.Msg("ֻ�����е�ֵ�����޸ģ�");
            //                return;
            //            }

            //            App.Msg("�����ѳɹ���");
            //            SelectCellVal = "��ֵ";
            //            btnSelect_Click(sender, e);
            //        }
                    
            //    }
            //}
        }
        /// <summary>
        /// ˫���¼������޸ĵ�Ԫ������
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void flgView_DoubleClick(object sender, EventArgs e)
        {
            //if (flgView.RowSel > 1)
            //{
            //    if (flgView.ColSel > 0)
            //    {

            //        if (flgView[flgView.RowSel, flgView.ColSel].ToString() == "")
            //        {
            //            App.MsgErr("�˴����ܽ����޸Ĳ�����");
            //            flgView.Focus();
            //            return;
            //        }

            //    }
            //    else
            //    {
            //        //������ʱ��ε���Ŀ�б�
            //        if (flgView[1, flgView.ColSel].ToString().Trim() == "����")
            //        {
            //            if (flgView.RowSel > 1)
            //            {
            //                string date = flgView[flgView.RowSel, 0].ToString();
            //                if (date != null)
            //                {
            //                    frmBgrecord frm = new frmBgrecord(date);
            //                    frm.ShowDialog();
            //                    ShowGrid();
            //                }
            //            }
            //        }

            //    }
            //    //�ж�flgView���д���2
            //    if (flgView.Rows.Count > 2)
            //    {
            //        SelectCellVal = flgView[flgView.RowSel, flgView.ColSel].ToString();
            //    }
            //    RowIndex = flgView.RowSel;
            //    ColIndex = flgView.ColSel;
            //}
        }

        /// <summary>
        /// ������Ŀ���ƺ�����ʱ���ȡ��ؼ�¼��ID
        /// </summary>
        /// <param Name="ItemName">��Ŀ����</param>
        /// <param Name="strtime">����ʱ��</param>
        /// <returns></returns>
        private string GetSelectItemId(string ItemName, string strtime)
        {
            string Sql = "select a.id from T_PERIPHERY_BG_RECORD a inner join t_data_code b on a.item_kind=b.id where b.name='" + ItemName + "' and a.RECORD_TIME=to_timestamp('" + strtime + "','syyyy-mm-dd hh24:mi:ss.ff9')";
            string ID = App.ReadSqlVal(Sql, 0, "ID");
            return ID;
        }

    
        private void dtpDatetime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtValue.Focus();
            }
        }

        private void txtValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboType.Focus();
            }
        }

        private void cboType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTosign.Focus();
            }
        }

        private void txtTosign_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTosign_KeyUp(sender, e);
                btnSave_Click(sender, e);
            }
        }

        private void flgView_KeyDown(object sender, KeyEventArgs e)
        {
            // /// <summary>
            ///// ����ƶ���������
            ///// </summary>
            ///// <param Name="sender"></param>
            ///// <param Name="e"></param>
          
            //    if (e.KeyCode == Keys.Down)
            //    {
            //        flgView.Focus();
            //    }
            //    else if (e.KeyCode == Keys.Left)
            //    {
            //        flgView_DoubleClick(sender, e);
            //    }
            //    else if (e.KeyCode == Keys.Right)
            //    {
            //        flgView_DoubleClick(sender, e);
            //    }
            //    else if (e.KeyCode == Keys.Up)
            //    {
            //        flgView_DoubleClick(sender, e);
            //    }
        
        }

        private void txtTosign_KeyUp(object sender, KeyEventArgs e)
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
                    if (txtTosign.Text.Trim() != "")
                        App.FastCodeCheck("select user_id as �û����,user_name as �û����� from t_userinfo t where user_name like '%" + txtTosign.Text + "%'", txtTosign, "�û�����", "�û����");
                App.FastCodeFlag = false;
                
            }  

        }
    }
}
