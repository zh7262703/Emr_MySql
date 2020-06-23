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
        private string ID = "";//hic 主键ID
        private string pid = "";//住院号
        private string pname = "";//病人姓名
        private string bed_no = "";//病人床号
        private string id = "";//病人主键
        private string p_section = "";//病人科室
        public ucHeart_PIC()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 获取bed_no,pname,pid,id的构造函数
        /// </summary>
        /// <param name="bed_no">病人床号</param>
        /// <param name="pname">病人姓名</param>
        /// <param name="pid">住院号</param>
        /// <param name="id">病人主键</param>
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
        /// LOAD函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucHeart_PIC_Load(object sender, EventArgs e)
        {
            try
            {
                //App.SetMainFrmMsgToolBarText("心电示波记录单");
                ShowGrid();
                refersh();//刷新
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
            string sql = "select to_char(t.record_time,'yyyy-mm-dd') as 日期,to_char(t.record_time,'HH24:mi') as 时间,t.heart_val as 结果值,t.sing_name as 签名,t.bz as 心电示波情况  from t_heart_pic t where t.pid='" + pid + "'order by t.record_time";
            DataSet ds = App.GetDataSet(sql);
            ArrayList lists = new ArrayList(); 
            lists.Clear();
            if (ds != null)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    flgView.Rows.Add();
                    Class_Heart_PIC hpic = new Class_Heart_PIC();
                    hpic.Date = ds.Tables[0].Rows[i]["日期"].ToString();
                    hpic.Time = ds.Tables[0].Rows[i]["时间"].ToString();
                    hpic.Value_val = ds.Tables[0].Rows[i]["结果值"].ToString();
                    hpic.BZ = ds.Tables[0].Rows[i]["心电示波情况"].ToString();
                    hpic.Create_Name = ds.Tables[0].Rows[i]["签名"].ToString();
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
        /// 界面显示
        /// </summary>
        private void ShowGrid()
        {
            try
            {
                flgView.Clear();
                //5列0行          
                flgView.Cols.Count = 5;
                flgView.Cols.Fixed = 0;
                flgView.Rows.Count = 1;
                flgView.Rows.Fixed = 1;
                //string sql = "select to_char(t.record_time,'yyyy-mm-dd') as 日期,to_char(t.record_time,'HH24:mi') as 时间,t.heart_val as 结果值,t.sing_name as 签名,t.bz as 心电示波情况  from t_heart_pic t where t.pid='" + pid + "'";
                //DataSet ds = App.GetDataSet(sql);
                //if (ds != null)
                //{
                //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //    {

                //        flgView.Rows.Add();
                //        Class_Heart_PIC hpic = new Class_Heart_PIC();
                //        hpic.Date = ds.Tables[0].Rows[i]["日期"].ToString();
                //        hpic.Time = ds.Tables[0].Rows[i]["时间"].ToString();
                //        hpic.Value_val = ds.Tables[0].Rows[i]["结果值"].ToString();
                //        hpic.BZ = ds.Tables[0].Rows[i]["心电示波情况"].ToString();
                //        hpic.Create_Name = ds.Tables[0].Rows[i]["签名"].ToString();
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
        /// 单元格合并和设置 
        /// </summary>
        private void CellUnit()
        {
            //单元格合并和设置         
            flgView[0, 0] = "日期";
            flgView[0, 1] = "时间";
            flgView[0, 2] = "HR 次/分";
            flgView[0, 3] = "心电示波情况";
            flgView[0, 4] = "签字";
            flgView.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            flgView.Cols.Fixed = 0;

            C1.Win.C1FlexGrid.CellRange cr;
            cr = flgView.GetCellRange(0, 0, 0, 0);
            cr.Data = "日期";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 1, 0, 1);
            cr.Data = "时间";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 2, 0, 2);
            cr.Data = "HR 次/分";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 3, 0, 3);
            cr.Data = "心电示波情况";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 4, 0, 4);
            cr.Data = "签字";
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
            //居中显示
            flgView.Cols[0].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[1].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[2].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[3].TextAlign = TextAlignEnum.CenterCenter;
            flgView.Cols[4].TextAlign = TextAlignEnum.CenterCenter;

        }

        //查找
        private void btnSelect_Click(object sender, EventArgs e)
        {
            CellUnit();
        }

        //添加状态
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //添加状态
            txtBZ.SelectedIndex = 0;
            txtBZ.Enabled = true;
            txtValue.Enabled = true;
            dtpDatetime.Enabled = true;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            btnAdd.Enabled = false;
        }
        //取消状态
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //取消状态
            txtBZ.SelectedIndex = 0;
            txtBZ.Enabled = false;
            txtValue.Enabled = false;
            dtpDatetime.Enabled = false;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            btnAdd.Enabled = true;
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            /*
             * 1.判断当前心电值是否有 
             * 2.判断当前记录是否是在数据库里面存在，存在的话就修改数据
             * 3.没有的话就想数据库里面插入数据
             */
            int PIC_number = -1;//心电示波值
            try
            {
                PIC_number = Convert.ToInt32(txtValue.Text.ToString());
            }
            catch
            {
                App.Msg("心电示波的结果值只能输入数值类型");
                txtValue.Focus();
                txtValue.Clear();
                return;
            }
            string Date = dtpDatetime.Value.ToString("yyyy-MM-dd HH:mm");
            string SQL = "";
            ID = App.GenId("t_Heart_Pic", "ID").ToString();
            string IDP = isExisitDate(Date);
            //if (IDP == "0")//插入
            //{
            if (IDP != "0")
            {
                App.Ask("该时间段已经存在一条记录，是否继续加入当前记录？");
                {
                    SQL = "insert into t_Heart_Pic (id,record_time,heart_val,bz,create_id,sing_name,pid)values('" + ID + "',to_timestamp('" + Date + "','syyyy-mm-dd hh24:mi:ss.ff9'),'" + txtValue.Text + "','" + txtBZ.Text + "','" + App.UserAccount.UserInfo.User_id + "','" + App.UserAccount.UserInfo.User_name + "','" + pid + "')";
                    if (App.ExecuteSQL(SQL) > 0)
                    {
                        App.Msg("新增记录成功！");
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
                    App.Msg("新增记录成功！");
                    ucHeart_PIC_Load(sender, e);
                    //refersh();
                }
 
            }
            //}
            //else//修改
            //{
            //    SQL = "update t_Heart_Pic set heart_val='" + txtValue.Text + "',bz='" + txtBZ.Text + "' where id='" + IDP + "'";
            //    App.Ask("当前时间已经存在一条记录，是否覆盖掉？");
            //    {
            //        if (App.ExecuteSQL(SQL) > 0)
            //        {
            //            App.Msg("操作已成功！");
            //            ucHeart_PIC_Load(sender, e);
            //            //refersh();
            //        }
            //    }

            //}
            

        }
        /// <summary>
        /// 判断是否出现重名
        /// </summary>
        /// <param Name="Date">当前时间</param>
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
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            string sql = "select to_char(t.record_time,'yyyy-mm-dd') as 日期,to_char(t.record_time,'HH24:mi') as 时间,t.heart_val as 心电示波值,t.bz as 心电示波情况,t.sing_name as 签字 from t_heart_pic t where t.pid='"+pid+"'";
            DataSet ds = App.GetDataSet(sql);
            DataSet dss = new DataSet();
            if (ds != null)
            {
                ArrayList lists = new ArrayList();
                lists.Clear();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Class_Heart_PIC hpic = new Class_Heart_PIC();
                    hpic.Date = ds.Tables[0].Rows[i]["日期"].ToString();
                    hpic.Time = ds.Tables[0].Rows[i]["时间"].ToString();
                    hpic.Value_val = ds.Tables[0].Rows[i]["心电示波值"].ToString();
                    hpic.BZ = ds.Tables[0].Rows[i]["心电示波情况"].ToString();
                    hpic.Create_Name = ds.Tables[0].Rows[i]["签字"].ToString();
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
        /// 双击修改删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flgView_DoubleClick(object sender, EventArgs e)
        {
            if (flgView[flgView.RowSel, flgView.ColSel].ToString() == "")
            {
                App.Msg("此处空值，不能进行修改操作！");
                flgView.Focus();
                return;
            }
            if (flgView.RowSel > 0)
            {
                string data = flgView[flgView.RowSel, 0].ToString();//日期
                string time = flgView[flgView.RowSel, 1].ToString();//时间
                string value_val = flgView[flgView.RowSel, 2].ToString();//心电示波值
                string sign_name = flgView[flgView.RowSel, 4].ToString();//执行者签名
                string bz = flgView[flgView.RowSel, 3].ToString();//备注

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
                if (App.UserAccount.UserInfo.U_position_name != "护士长")
                {
                    if (App.UserAccount.UserInfo.User_name != record_name)
                    {
                        App.Msg("只有创建人和护士长才能修改该数据！");
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
