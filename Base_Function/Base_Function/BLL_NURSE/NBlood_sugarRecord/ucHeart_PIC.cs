using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using C1.Win.C1FlexGrid;
using System.Collections;
using Base_Function.MODEL;

namespace Base_Function.BLL_NURSE.NBlood_sugarRecord
{
    public partial class ucHeart_PIC : UserControl
    {
        private string ID = "";//hic ����ID
        private string pid = "";//סԺ��
        private string pname = "";//��������
        private string bed_no = "";//���˴���
        private string id = "";//��������
        private string p_section = "";//���˿���
        public ucHeart_PIC()
        {
            InitializeComponent();
        }
        /// <summary>
        /// ��ȡbed_no,pname,pid,id�Ĺ��캯��
        /// </summary>
        /// <param name="bed_no">���˴���</param>
        /// <param name="pname">��������</param>
        /// <param name="pid">סԺ��</param>
        /// <param name="id">��������</param>
        public ucHeart_PIC(string bed_no, string pname, string pid,string id,string section)
        {
            InitializeComponent();
            this.lblBed.Text = bed_no;
            this.lblName.Text = pname;
            this.lblPid.Text = pid;
            this.p_section = section;
            this.pid = pid;
            this.pname = pname;
            this.bed_no = bed_no;
            this.id = id;

        }
        public ucHeart_PIC(string bed_no, string pname, string pid, string id)
        {
            InitializeComponent();
            this.lblBed.Text = bed_no;
            this.lblName.Text = pname;
            this.lblPid.Text = pid;
            this.pid = pid;
            this.pname = pname;
            this.bed_no = bed_no;
            this.id = id;

        }
        /// <summary>
        /// LOAD����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucHeart_PIC_Load(object sender, EventArgs e)
        {
            try
            {
                //App.SetMainFrmMsgToolBarText("�ĵ�ʾ����¼��");
                ShowGrid();
                refersh();//ˢ��
                txtBZ.SelectedIndex = 0;
                txtBZ.Enabled = false;
                txtValue.Enabled = false;
                dtpDatetime.Enabled = false;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                btnAdd.Enabled = true;
                //flgView.AllowEditing = false;
            }
            catch
            {
            }
        }
        private void refersh()
        {
            string sql = "select to_char(t.record_time,'yyyy-mm-dd') as ����,to_char(t.record_time,'HH24:mi') as ʱ��,t.heart_val as ���ֵ,t.sing_name as ǩ��,t.bz as �ĵ�ʾ�����  from t_heart_pic t where t.pid='" + pid + "'order by t.record_time";
            DataSet ds = App.GetDataSet(sql);
            ArrayList lists = new ArrayList(); 
            lists.Clear();
            if (ds != null)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    flgView.Rows.Add();
                    Class_Heart_PIC hpic = new Class_Heart_PIC();
                    hpic.Date = ds.Tables[0].Rows[i]["����"].ToString();
                    hpic.Time = ds.Tables[0].Rows[i]["ʱ��"].ToString();
                    hpic.Value_val = ds.Tables[0].Rows[i]["���ֵ"].ToString();
                    hpic.BZ = ds.Tables[0].Rows[i]["�ĵ�ʾ�����"].ToString();
                    hpic.Create_Name = ds.Tables[0].Rows[i]["ǩ��"].ToString();
                    lists.Add(hpic);
                    flgView[1 + i, 0] = hpic.Date;
                    flgView[1 + i, 1] = hpic.Time;
                    flgView[1 + i, 2] = hpic.Value_val;
                    flgView[1 + i, 3] = hpic.BZ;
                    flgView[1 + i, 4] = hpic.Create_Name;
                    string date = Convert.ToDateTime(hpic.Date + " " + hpic.Time).ToString();
                    string RowSelcolor = isExisitDate(date);
                    if (RowSelcolor != "0" && RowSelcolor != "first")
                    {
                        flgView.Rows[i + 1].StyleNew.BackColor = Color.Red;
                    }
                }
                //Class_Heart_PIC[] PIC_obj=new Class_Heart_PIC[lists.Count];
                //for (int j = 0; j < lists.Count; j++)
                //{
                //    PIC_obj[j] = new Class_Heart_PIC();
                //    PIC_obj[j] = (Class_Heart_PIC)lists[j];
                //}
                //DataSet ds = App.ObjectArrayToDataSet(PIC_obj);
            }
        }
        /// <summary>
        /// ������ʾ
        /// </summary>
        private void ShowGrid()
        {
            try
            {
                flgView.Clear();
                //5��0��          
                flgView.Cols.Count = 5;
                flgView.Cols.Fixed = 0;
                flgView.Rows.Count = 1;
                flgView.Rows.Fixed = 1;
                //string sql = "select to_char(t.record_time,'yyyy-mm-dd') as ����,to_char(t.record_time,'HH24:mi') as ʱ��,t.heart_val as ���ֵ,t.sing_name as ǩ��,t.bz as �ĵ�ʾ�����  from t_heart_pic t where t.pid='" + pid + "'";
                //DataSet ds = App.GetDataSet(sql);
                //if (ds != null)
                //{
                //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //    {

                //        flgView.Rows.Add();
                //        Class_Heart_PIC hpic = new Class_Heart_PIC();
                //        hpic.Date = ds.Tables[0].Rows[i]["����"].ToString();
                //        hpic.Time = ds.Tables[0].Rows[i]["ʱ��"].ToString();
                //        hpic.Value_val = ds.Tables[0].Rows[i]["���ֵ"].ToString();
                //        hpic.BZ = ds.Tables[0].Rows[i]["�ĵ�ʾ�����"].ToString();
                //        hpic.Create_Name = ds.Tables[0].Rows[i]["ǩ��"].ToString();
                //        flgView[1 + i, 0] = hpic.Date;
                //        flgView[1 + i, 1] = hpic.Time;
                //        flgView[1 + i, 2] = hpic.Value_val;
                //        flgView[1 + i, 3] = hpic.BZ;
                //        flgView[1 + i, 4] = hpic.Create_Name;
                //    }
                //}
                CellUnit();
                flgView.Cols[0].StyleNew.Border.Color = Color.Black;
                flgView.Cols[1].StyleNew.Border.Color = Color.Black;
                flgView.Cols[2].StyleNew.Border.Color = Color.Black;
                flgView.Cols[3].StyleNew.Border.Color = Color.Black;
                flgView.Cols[4].StyleNew.Border.Color = Color.Black;
            }
            catch
            { }
        }

        /// <summary>
        /// ��Ԫ��ϲ������� 
        /// </summary>
        private void CellUnit()
        {
            //��Ԫ��ϲ�������         
            flgView[0, 0] = "����";
            flgView[0, 1] = "ʱ��";
            flgView[0, 2] = "HR ��/��";
            flgView[0, 3] = "�ĵ�ʾ�����";
            flgView[0, 4] = "ǩ��";
            flgView.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            flgView.Cols.Fixed = 0;

            C1.Win.C1FlexGrid.CellRange cr;
            cr = flgView.GetCellRange(0, 0, 0, 0);
            cr.Data = "����";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 1, 0, 1);
            cr.Data = "ʱ��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 2, 0, 2);
            cr.Data = "HR ��/��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 3, 0, 3);
            cr.Data = "�ĵ�ʾ�����";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 4, 0, 4);
            cr.Data = "ǩ��";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            for (int i = 0; i < flgView.Cols.Count; i++)
            {

                flgView.Cols[i].Width = 170;
            }
            for (int i = 0; i < flgView.Rows.Count; i++)
            {
                flgView.Rows[i].Height = 35;
            }
            //������ʾ
            flgView.Cols[0].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[1].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[2].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[3].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[4].TextAlign = TextAlignEnum.CenterCenter;

        }

        //����
        private void btnSelect_Click(object sender, EventArgs e)
        {
            CellUnit();
        }

        //���״̬
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //���״̬
            txtBZ.SelectedIndex = 0;
            txtBZ.Enabled = true;
            txtValue.Enabled = true;
            dtpDatetime.Enabled = true;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnAdd.Enabled = false;
        }
        //ȡ��״̬
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //ȡ��״̬
            txtBZ.SelectedIndex = 0;
            txtBZ.Enabled = false;
            txtValue.Enabled = false;
            dtpDatetime.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnAdd.Enabled = true;
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            /*
             * 1.�жϵ�ǰ�ĵ�ֵ�Ƿ��� 
             * 2.�жϵ�ǰ��¼�Ƿ��������ݿ�������ڣ����ڵĻ����޸�����
             * 3.û�еĻ��������ݿ������������
             */
            int PIC_number = -1;//�ĵ�ʾ��ֵ
            try
            {
                PIC_number = Convert.ToInt32(txtValue.Text.ToString());
            }
            catch
            {
                App.Msg("�ĵ�ʾ���Ľ��ֵֻ��������ֵ����");
                txtValue.Focus();
                txtValue.Clear();
                return;
            }
            string Date = dtpDatetime.Value.ToString("yyyy-MM-dd HH:mm");
            string SQL = "";
            ID = App.GenId("t_Heart_Pic", "ID").ToString();
            string IDP = isExisitDate(Date);
            //if (IDP == "0")//����
            //{
            if (IDP != "0")
            {
                App.Ask("��ʱ����Ѿ�����һ����¼���Ƿ�������뵱ǰ��¼��");
                {
                    SQL = "insert into t_Heart_Pic (id,record_time,heart_val,bz,create_id,sing_name,pid)values('" + ID + "',to_timestamp('" + Date + "','syyyy-mm-dd hh24:mi:ss.ff9'),'" + txtValue.Text + "','" + txtBZ.Text + "','" + App.UserAccount.UserInfo.User_id + "','" + App.UserAccount.UserInfo.User_name + "','" + pid + "')";
                    if (App.ExecuteSQL(SQL) > 0)
                    {
                        App.Msg("������¼�ɹ���");
                        ucHeart_PIC_Load(sender, e);
                        //refersh();
                    }
                }
            }
            else
            {
                SQL = "insert into t_Heart_Pic (id,record_time,heart_val,bz,create_id,sing_name,pid)values('" + ID + "',to_timestamp('" + Date + "','syyyy-mm-dd hh24:mi:ss.ff9'),'" + txtValue.Text + "','" + txtBZ.Text + "','" + App.UserAccount.UserInfo.User_id + "','" + App.UserAccount.UserInfo.User_name + "','" + pid + "')";
                if (App.ExecuteSQL(SQL) > 0)
                {
                    App.Msg("������¼�ɹ���");
                    ucHeart_PIC_Load(sender, e);
                    //refersh();
                }
 
            }
            //}
            //else//�޸�
            //{
            //    SQL = "update t_Heart_Pic set heart_val='" + txtValue.Text + "',bz='" + txtBZ.Text + "' where id='" + IDP + "'";
            //    App.Ask("��ǰʱ���Ѿ�����һ����¼���Ƿ񸲸ǵ���");
            //    {
            //        if (App.ExecuteSQL(SQL) > 0)
            //        {
            //            App.Msg("�����ѳɹ���");
            //            ucHeart_PIC_Load(sender, e);
            //            //refersh();
            //        }
            //    }

            //}
            

        }
        /// <summary>
        /// �ж��Ƿ��������
        /// </summary>
        /// <param Name="Date">��ǰʱ��</param>
        /// <returns></returns>
        private string isExisitDate(string date)
        {

            DataSet ds = App.GetDataSet("select id from  t_Heart_Pic  where RECORD_TIME=to_timestamp('" + date + "','syyyy-mm-dd hh24:mi:ss.ff9') ");//
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 1)
                {
                    return ds.Tables[0].Rows[0][0].ToString();
                }
                else if (ds.Tables[0].Rows.Count == 1)
                {
                    return "first";
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
        /// ��ӡ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            string sql = "select to_char(t.record_time,'yyyy-mm-dd') as ����,to_char(t.record_time,'HH24:mi') as ʱ��,t.heart_val as �ĵ�ʾ��ֵ,t.bz as �ĵ�ʾ�����,t.sing_name as ǩ�� from t_heart_pic t where t.pid='"+pid+"'";
            DataSet ds = App.GetDataSet(sql);
            DataSet dss = new DataSet();
            if (ds != null)
            {
                ArrayList lists = new ArrayList();
                lists.Clear();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Class_Heart_PIC hpic = new Class_Heart_PIC();
                    hpic.Date = ds.Tables[0].Rows[i]["����"].ToString();
                    hpic.Time = ds.Tables[0].Rows[i]["ʱ��"].ToString();
                    hpic.Value_val = ds.Tables[0].Rows[i]["�ĵ�ʾ��ֵ"].ToString();
                    hpic.BZ = ds.Tables[0].Rows[i]["�ĵ�ʾ�����"].ToString();
                    hpic.Create_Name = ds.Tables[0].Rows[i]["ǩ��"].ToString();
                    lists.Add(hpic);
                }
                Class_Heart_PIC[] PIC_obj = new Class_Heart_PIC[lists.Count];
                for (int j = 0; j < lists.Count; j++)
                {
                    PIC_obj[j] = new Class_Heart_PIC();
                    PIC_obj[j] = (Class_Heart_PIC)lists[j];
                }
                dss = App.ObjectArrayToDataSet(PIC_obj);
            }
            frmHeart_PIC_Print pic = new frmHeart_PIC_Print(dss, pname, p_section, bed_no, pid, "");
            pic.ShowDialog();
        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// ˫���޸�ɾ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flgView_DoubleClick(object sender, EventArgs e)
        {
            if (flgView[flgView.RowSel, flgView.ColSel].ToString() == "")
            {
                App.Msg("�˴���ֵ�����ܽ����޸Ĳ�����");
                flgView.Focus();
                return;
            }
            if (flgView.RowSel > 0)
            {
                string data = flgView[flgView.RowSel, 0].ToString();//����
                string time = flgView[flgView.RowSel, 1].ToString();//ʱ��
                string value_val = flgView[flgView.RowSel, 2].ToString();//�ĵ�ʾ��ֵ
                string sign_name = flgView[flgView.RowSel, 4].ToString();//ִ����ǩ��
                string bz = flgView[flgView.RowSel, 3].ToString();//��ע

                string sql = "";
                if (bz == "")
                {
                    sql = "select t.sing_name from t_heart_pic t where to_char(t.record_time,'yyyy-mm-dd')='" + data + "' and to_char(t.record_time,'HH24:mi')='" + time + "' and t.sing_name='" + sign_name + "' and t.heart_val='" + value_val + "' ";//and t.bz='" + bz + "'
                }
                else
                {
                    sql = "select t.sing_name from t_heart_pic t where to_char(t.record_time,'yyyy-mm-dd')='" + data + "' and to_char(t.record_time,'HH24:mi')='" + time + "' and t.sing_name='" + sign_name + "' and t.heart_val='" + value_val + "'and t.bz='" + bz + "' ";//
                }
                string record_name = App.GetDataSet(sql).Tables[0].Rows[0]["sing_name"].ToString();
                if (App.UserAccount.UserInfo.U_position_name != "��ʿ��")
                {
                    if (App.UserAccount.UserInfo.User_name != record_name)
                    {
                        App.Msg("ֻ�д����˺ͻ�ʿ�������޸ĸ����ݣ�");
                        return;
                    }
                }
                frmHeartpicShow frm = new frmHeartpicShow(data, time, value_val, sign_name, bz);
                frm.ShowDialog();
                ucHeart_PIC_Load(sender,e);
            }

        }


    }
}
