using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;
using Bifrost;


using System.Collections;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace Base_Function.BLL_NURSE.Nurse_Record_Manager
{
    public partial class frmInout_Amount_Dist : DevComponents.DotNetBar.Office2007Form
    {
        //列的集合
        ColumnInfo[] cols = new ColumnInfo[13];
        private string Pid = null;
        //查出所有项目类型
        private string Sql_Codetype = "select id ,name from t_data_code where id = 109 or id =110";
        //查出所有出入液量记录单信息
        private string Sql_amount_dict = "select * from t_inout_amount_dict";

        private string Sql_Code_Way = "select id ,name from t_data_code where id between 111 and 113";

        #region 汇总计算
        //:pid,:Total_time,:begin_time,:end_time,:recordByid,:sum_type
        private string Sql_sum = "insert into t_inout_summ(pid,calc_date,start_time,end_time,record_id,sum_in,sum_out,mouth_in_sum,pipe_in_sum," +
                            " vein_in_sum,urine_amount_sum,faceces_amount_sum,vomit_amount_sum,oozingandexudate_sum," +
                            "  drainage_amount_sum,sum_type)" +
               " select :pid,to_timestamp(to_char(:Total_time,'yyyy-MM-dd hh24:mi'),'yyyy-MM-dd hh24:mi'),to_timestamp(to_char(:begin_time,'yyyy-MM-dd hh24:mi'),'yyyy-MM-dd hh24:mi')," +
                      " to_timestamp(to_char(:end_time,'yyyy-MM-dd hh24:mi'),'yyyy-MM-dd hh24:mi'),:recordByid," +
                      " sum(case b.item_type when 109 then a.item_value end) 总入量," +
                      " sum(case b.item_type when 110 then a.item_value end) 总入量," +
                      " sum(case b.item_mode when 111 then a.item_value end) 口入汇总," +
                      " sum(case b.item_mode when 112 then a.item_value end) 管入汇总," +
                      " sum(case b.item_mode when 113 then a.item_value end) 经静脉入汇总," +
                      " sum(case b.item_name when '尿' then a.item_value end) 尿量," +
                      " sum(case b.item_name when '大便' then a.item_value end) 大便汇总," +
                      " sum(case b.item_name when '呕吐' then a.item_value end) 呕吐汇总," +
                      " sum(case b.item_name when '渗血渗液' then a.item_value end) 渗血渗液汇总," +
                      " sum(case b.drainage_attribute when 0 then a.item_value end) 引流汇总, :sum_type" +
                      " from t_inout_amount_record  a " +
                      " inner join t_inout_amount_dict b on a.item_code = b.id " +
                      " where a.record_time between to_timestamp(to_char(:begin_time,'yyyy-MM-dd hh24:mi'),'yyyy-MM-dd hh24:mi')" +
                      " and  to_timestamp(to_char(:end_time,'yyyy-MM-dd hh24:mi'),'yyyy-MM-dd hh24:mi') ";
        #endregion

        #region 汇总显示
        private string sql_disp_sum = "select b.patient_name 病人编号,to_char(calc_date,'yyyy-MM-dd hh24:mi') 计算时间,to_char(start_time,'yyyy-MM-dd hh24:mi') 起始时间,to_char(end_time,'yyyy-MM-dd hh24:mi') 结束时间,c.user_name 记录人,sum_in 入量汇总," +
                             " sum_out 出量汇总,mouth_in_sum 口入汇总,pipe_in_sum 管入汇总,vein_in_sum 经静脉入汇总,urine_amount_sum 尿量汇总,"+
                             " faceces_amount_sum 大便汇总,vomit_amount_sum 呕吐汇总,oozingandexudate_sum 渗血渗液汇总,drainage_amount_sum 引流汇总,"+
                             " (case sum_type when 0 then '24小时汇总' else '随机汇总' end) 汇总类型 from t_inout_summ a"+
                             " left join t_in_patient b on a.pid = b.id"+
                             " left join t_userinfo c on a.record_id = c.user_id order by a.end_time";
        #endregion
        //保存表格数据
        private  List<NuserInout_show> list = new List<NuserInout_show>();
        //临时保存数据
        private List<NuserInout_show> SumNusers = new List<NuserInout_show>();
        private int Rowindex = 0;
        private int Colindex = 0;
        private string SelectCellVal = "无值";
        private ArrayList arrayList = new ArrayList();
        public frmInout_Amount_Dist()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 把pid传过来
        /// </summary>
        /// <param name="pid">病人id</param>
        public frmInout_Amount_Dist(string pid)
        {
            InitializeComponent();
            this.Pid = pid;
            lblHour.Text = "";
            InitTree();
            ShowSumGrid();
            flgView.Cols[0].AllowEditing = false;
            flgView.Cols[1].AllowEditing = false;
            flgView.Cols[2].AllowEditing = false;
            flgView.Cols[3].AllowEditing = false;
            flgView.Cols[4].AllowEditing = false;
            flgView.Cols[9].AllowEditing = false;
            flgView.Cols[12].AllowEditing = false;
            cbxTotal.SelectedIndex = 0;
            treeView1.ExpandAll();
        }
        private void frmInout_Amount_Dist_Load(object sender, EventArgs e)
        {
   
        }

        /// <summary>
        /// 初始化树
        /// </summary>
        public void InitTree()
        {
            DataSet ds_type = App.GetDataSet(Sql_Codetype);
            DataSet ds_amount_dist = App.GetDataSet(Sql_amount_dict);
            //TreeNode parentNode = new TreeNode();
            //parentNode.Text = "出入液量";
            if(ds_type!=null)
            {
                DataTable dt = ds_type.Tables[0];
                if(dt.Rows.Count>0)
                {
                    foreach(DataRow rowTemp in dt.Rows)
                    {
                        //父节点
                        TreeNode tempNode = new TreeNode();
                        //子节点  入液量方式
                        TreeNode childNode = new TreeNode();
                        childNode.Text = "入液量方式";
                        TreeNode Yinliunode = new TreeNode();
                        Yinliunode.Text = "引流";
                        tempNode.Name = rowTemp[0].ToString();
                        tempNode.Text = rowTemp[1].ToString();
                        if (rowTemp[1].ToString().Equals("入液量"))
                        {
                            DataSet ds = App.GetDataSet(Sql_Code_Way);
                            DataTable dt1 = ds.Tables[0];
                            foreach (DataRow row1 in dt1.Rows)
                            {
                                TreeNode node = new TreeNode();
                                node.Text = row1[1].ToString();
                                node.Name = row1[0].ToString();
                                if (ds_amount_dist != null)
                                {
                                    DataTable dt_amount_dist = ds_amount_dist.Tables[0];
                                    if (dt_amount_dist.Rows.Count > 0)
                                    {
                                        foreach (DataRow row in dt_amount_dist.Rows)
                                        {
                                            Inout_amount_dist dist = new Inout_amount_dist();
                                            dist.Id = Convert.ToInt32(row["id"]);
                                            dist.Item_code = row["item_code"].ToString();
                                            dist.Item_name = row["item_name"].ToString();
                                            dist.Item_value_type = row["item_value_type"].ToString();
                                            dist.Item_unit = row["item_unit"].ToString();
                                            if (row["display_seq"].ToString() != "")
                                            {
                                                dist.Display_seq = Convert.ToInt32(row["display_seq"].ToString());
                                            }
                                            dist.Amount_flag = row["amount_flag"].ToString();
                                            dist.Item_type = Convert.ToInt32(row["item_type"]);
                                            dist.Item_mode = Convert.ToInt32(row["item_mode"]);
                                            dist.Drainage_attribute = Convert.ToInt32(row["drainage_attribute"]);
                                            TreeNode cnode = new TreeNode();
                                            cnode.Text = dist.Item_name;
                                            cnode.Tag = dist as object;
                                            if(dist.Item_type==109)
                                            {
                                                if (dist.Item_mode.ToString() == node.Name)
                                                {
                                                    node.Nodes.Add(cnode);
                                                }
                                            }
                                        }
                                    }
                                }
                                childNode.Nodes.Add(node);
                            }
                            tempNode.Nodes.Add(childNode);
                        }
                        else
                        {
                            if (ds_amount_dist != null)
                            {
                                DataTable dt_amount_dist = ds_amount_dist.Tables[0];
                                if (dt_amount_dist.Rows.Count > 0)
                                {
                                    foreach (DataRow row in dt_amount_dist.Rows)
                                    {
                                        Inout_amount_dist dist = new Inout_amount_dist();
                                        dist.Id = Convert.ToInt32(row["id"]);
                                        dist.Item_code = row["item_code"].ToString();
                                        dist.Item_name = row["item_name"].ToString();
                                        dist.Item_value_type = row["item_value_type"].ToString();
                                        dist.Item_unit = row["item_unit"].ToString();
                                        if (row["display_seq"].ToString() != "")
                                        {
                                            dist.Display_seq = Convert.ToInt32(row["display_seq"].ToString());
                                        }
                                        dist.Amount_flag = row["amount_flag"].ToString();
                                        dist.Item_type = Convert.ToInt32(row["item_type"]);
                                        dist.Item_mode = Convert.ToInt32(row["item_mode"]);
                                        dist.Drainage_attribute = Convert.ToInt32(row["drainage_attribute"]);
                                        TreeNode cnode = new TreeNode();
                                        cnode.Text = dist.Item_name;
                                        cnode.Tag = dist as object;
                                        if (dist.Item_type == 110)
                                        {
                                            if (dist.Drainage_attribute != 1)
                                            {
                                                Yinliunode.Nodes.Add(cnode);
                                            }
                                            else
                                            {
                                                tempNode.Nodes.Add(cnode);
                                            }
                                        }
                                    }
                                }
                            }
                            tempNode.Nodes.Add(Yinliunode);
                        }

                        //parentNode.Nodes.Add(tempNode);
                        treeView1.Nodes.Add(tempNode);
                    }
                }
            }
        }

        int y = 0, x = 0;
        /// <summary>
        /// 显示项目编辑列表
        /// </summary>
        private void DisProjList(TreeNodeCollection nodes)
        {
            foreach (TreeNode Pnode in nodes)
             {
                if (Pnode.Tag != null)
                {
                    if(Pnode.Checked==true)
                    {
                         Inout_amount_dist dist=(Inout_amount_dist)Pnode.Tag;
                         //UcInout_Amount.UcInout_Amount amount = new Inhospital_Info.Nurse_Record_Manager.UcInout_Amount.UcInout_Amount(Pnode.Text,dist.Id.ToString());
                       // UcInout_Amount amount = new UcInout_Amount(Pnode.Text,dist.Id.ToString());
                        //if (x < panel1.Width)
                        //{
                        //    amount.Location = new System.Drawing.Point(x, y);
                        //    x = x + amount.Width + 6;
                        //    panel1.Controls.Add(amount);
                        //}
                        //else
                        //{
                            //x = 0;
                            //y = y + amount.Height;
                            //amount.Location = new System.Drawing.Point(x, y);
                            //panel1.Controls.Add(amount);
                        //}
                    }
                }
                //else
                //{
                //    DisProjList(Pnode.Nodes);
                //}
                if(Pnode.Nodes.Count>0)
                    DisProjList(Pnode.Nodes);
             }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            x = 0;
            y = 0;
            panel1.Controls.Clear();
            DisProjList(treeView1.Nodes);
        }

        /// <summary>
        /// 添加项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            int count=0;
            if(panel1.Controls.Count>0)
            {
                foreach(Control control in panel1.Controls)
                {
                    //UcInout_Amount.UcInout_Amount amount = (UcInout_Amount.UcInout_Amount)control;
                    UcInout_Amount amount = (UcInout_Amount)control;
                    if (amount.txtValue.Text != "" && IsFloat(amount.txtValue.Text))
                    {
                        string userName = null;
                        string userId = null;
                        if (App.UserAccount.UserInfo != null)
                        {
                            userName = App.UserAccount.UserInfo.User_name;
                            userId = App.UserAccount.UserInfo.User_id;
                        }
                        string sql = "insert into t_inout_amount_record (pid,record_time,record_id,record_name,item_code,item_value)" +
                                     " values('" + Pid + "',to_timestamp(to_char(sysdate,'yyyy-MM-dd hh24:mi'),'yyyy-MM-dd hh24:mi'),'" + userId + "'," +
                                     "'" + userName + "','" + amount.Item_code + "','" + amount.txtValue.Text + "')";
                        try
                        {
                            count += App.ExecuteSQL(sql);
                        }
                        catch
                        {

                        }
                    }
                    else
                    {
                        App.MsgErr("请输入大于的数字！");
                    }
                }
                if (count > 0)
                {
                    App.Msg("保存成功！");
                    ShowSumGrid();
                }
                else
                {
                    App.Msg("保存失败！");
                }
            }
        }

        /// <summary>
        /// 显示表格数据
        /// </summary>
        public void ShowGrid()
        {
            list.Clear();
            //setTableHeader();
            //将汇总记录添加到表格
            //ShowSumGrid();
            //表格显示的视图
            string sql = "select * from inout_record_view";
            DataSet ds = App.GetDataSet(sql);
            if(ds!=null)
            {
                DataTable dt = ds.Tables[0];
                if(dt.Rows.Count>0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        NuserInout_show nurserInout = new NuserInout_show();
                        nurserInout.Date = row["日期"].ToString();
                        nurserInout.Time = row["时间"].ToString();
                        nurserInout.Item_Mouth = row["口入"].ToString();
                        nurserInout.Item_Tube = row["管入"].ToString();
                        nurserInout.Imte_Intravenous = row["经静脉入"].ToString();
                        if (row["实入量"].ToString()!="")
                            nurserInout.The_Real =(Convert.ToInt32(row["实入量"])).ToString();
                        nurserInout.Urine = row["尿"].ToString();
                        nurserInout.Defecate = row["大便"].ToString();
                        nurserInout.Vomiting = row["呕吐"].ToString();
                        nurserInout.Drainage = row["引流"].ToString();
                        if (row["引流出量"].ToString()!="")
                            nurserInout.Drainage_value =(Convert.ToInt32(row["引流出量"])).ToString();
                        nurserInout.Oozing_drainage = row["渗血渗液"].ToString();
                        nurserInout.Operater = row["记录人"].ToString();
                        list.Add(nurserInout);
                    }
                    string date = null;
                    string time = null;
                    NuserInout_show [] nusers = new NuserInout_show[list.Count];
                    for (int i = 0; i < list.Count;i++)
                    {
                         nusers[i]=new NuserInout_show();
                         nusers[i] = list[i];
                         if (date == null)
                         {
                             date = nusers[i].Date;
                         }
                         else
                         {
                             if (nusers[i].Date != date)
                             {
                                 date = nusers[i].Date;
                                 time = nusers[i].Time;
                             }
                             else
                             {
                                 nusers[i].Date = null;
                                 if (nusers[i].Time != time)
                                 {
                                     time = nusers[i].Time;
                                 }
                                 else
                                 {
                                     nusers[i].Time = null;
                                 }
                             }
                         }
                    }
                     //App.ArrayToGrid(flgView, nusers, cols, 2);                    
                     //CellMerge();

                }
            }

        }

        /// <summary>
        /// 设置表头
        /// </summary>
        public void setTableHeader()
        {

            flgView.Cols.Count = 13;
            flgView.Rows.Count = 2;
            flgView.Rows.Fixed = 2;
            //表头设置
            cols[0].Name = "日期";
            cols[0].Field = "Date";
            cols[0].Index = 1;
            cols[0].visible = true;

            cols[1].Name = "时间";
            cols[1].Field = "Time";
            cols[1].Index = 2;
            cols[1].visible = true;

            cols[2].Name = "口入";
            cols[2].Field = "Item_Mouth";
            cols[2].Index = 3;
            cols[2].visible = true;

            cols[3].Name = "管入";
            cols[3].Field = "Item_Tube";
            cols[3].Index = 4;
            cols[3].visible = true;

            cols[4].Name = "经静脉入";
            cols[4].Field = "Imte_Intravenous";
            cols[4].Index = 5;
            cols[4].visible = true;

            cols[5].Name = "实入量";
            cols[5].Field = "The_Real";
            cols[5].Index = 6;
            cols[5].visible = true;

            cols[6].Name = "尿量";
            cols[6].Field = "Urine";
            cols[6].Index = 7;
            cols[6].visible = true;

            cols[7].Name = "大便";
            cols[7].Field = "Defecate";
            cols[7].Index = 8;
            cols[7].visible = true;

            cols[8].Name = "呕吐";
            cols[8].Field = "Vomiting";
            cols[8].Index = 9;
            cols[8].visible = true;

            cols[9].Name = "引流";
            cols[9].Field = "Drainage";
            cols[9].Index = 10;
            cols[9].visible = true;

            cols[10].Name = "引流出量";
            cols[10].Field = "Drainage_value";
            cols[10].Index = 11;
            cols[10].visible = true;

            cols[11].Name = "渗血渗液";
            cols[11].Field = "Oozing_drainage";
            cols[11].Index = 12;
            cols[11].visible = true;

            cols[12].Name = "记录人";
            cols[12].Field = "Operater";
            cols[12].Index = 13;
            cols[12].visible = true;
        }
        /// <summary>
        /// 单元格合并
        /// </summary>
        public void CellMerge()
        {

            //单元格合并和设置           
            flgView[1, 0] = "日期";
            flgView[1, 1] = "时间";
            flgView[1, 2] = "口入";
            flgView[1, 3] = "管入";
            flgView[1, 4] = "经静脉入";
            flgView[1, 5] = "实入量";
            flgView[1, 6] = "尿量";
            flgView[1, 7] = "大便";
            flgView[1, 8] = "呕吐";
            flgView[1, 9] = "引流";
            flgView[1, 10] = "引流出量";
            flgView[1, 11] = "渗血渗液";
            flgView[1, 12] = "记录人";
            
            flgView.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            flgView.Cols.Fixed = 0;


            C1.Win.C1FlexGrid.CellRange cr;
            cr = flgView.GetCellRange(0, 0, 1, 0);
            cr.Data = "日期";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 1, 1, 1);
            cr.Data = "时间";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0,2,0,5);
            cr.Data = "入量(ml)";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 6, 0, 11);
            cr.Data = "出量(ml)";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 12, 1, 12);
            cr.Data = "记录人";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);
        }

        private void flgView_DoubleClick(object sender, EventArgs e)
        {
            if (flgView.RowSel > 1)
            {
                if (flgView[1, flgView.ColSel].ToString().Equals("口入") ||
                    flgView[1, flgView.ColSel].ToString().Equals("管入") ||
                    flgView[1, flgView.ColSel].ToString().Equals("经静脉入")||
                    flgView[1, flgView.ColSel].ToString().Equals("引流") ||
                    flgView[1, flgView.ColSel].ToString().Equals("记录人"))
                {
                    App.MsgErr("口入、管入、，经静脉入、引流、记录人不能修改！");
                    flgView.Focus();
                    return;

                }
                else if (flgView[flgView.RowSel, flgView.ColSel].ToString() == "")
                {
                    App.MsgErr("只能对现有值进行修改！");
                    flgView.Focus();
                    return;

                }
                else
                {
                    if (flgView[1, flgView.ColSel].ToString().Trim() == "日期" ||
                        flgView[1, flgView.ColSel].ToString().Trim() == "时间")
                    {
                        string date = GetSelectItemTime();
                        if (date != "")
                        {
                            frmUpdateUuserByDate nuserBydate = new frmUpdateUuserByDate(date);
                            nuserBydate.ShowDialog();
                            ShowSumGrid();
                        }
                    }
                }
                Rowindex = flgView.RowSel;
                Colindex = flgView.ColSel;
                SelectCellVal = flgView[flgView.RowSel,flgView.ColSel].ToString();
            }

        }

        private void flgView_Click(object sender, EventArgs e)
        {
            if(SelectCellVal!=flgView[Rowindex,Colindex].ToString()&&SelectCellVal!="无值")
            {
                if (IsFloat(flgView[Rowindex, Colindex].ToString()))
                {
                    //this.flgView.CellChanged += new C1.Win.C1FlexGrid.RowColEventHandler(flgView_CellChanged);
                    if (App.Ask("单元格中的值已经被修改过，是否保存?"))
                    {
                        string strDate = GetSelectItemTime();
                        string item_name = GetSelectItemName();
                        string sql = "update  t_inout_amount_record set item_value='" + flgView[Rowindex, Colindex].ToString() + "' " +
                                   " where item_code =(select a.item_code from t_inout_amount_record a" +
                                   " inner join t_inout_amount_dict b on a.item_code = b.id" +
                                   " where b.item_name='" + item_name + "' and to_char(a.record_time,'yyyy-MM-dd hh24:mi')='" + strDate + "')" +
                                   " and to_char(record_time,'yyyy-MM-dd hh24:mi')='" + strDate + "'";
                        int count = App.ExecuteSQL(sql);
                        if (count > 0)
                        {
                            App.Msg("修改成功！");
                            ShowSumGrid();
                        }
                    }
                }
                else
                {
                    App.MsgErr("请输入大于零的数字！");
                    flgView[Rowindex, Colindex] = SelectCellVal as object;
                }
                SelectCellVal = "无值";
            }

        }

        /// <summary>
        /// 获取当前选中项的时间
        /// </summary>
        /// <returns></returns>
        private string GetSelectItemTime()
        {
            if (Rowindex > 1)
            {
                string strDate = "";//记录日期
                string strTime = "";//记录时间     

                //获取时间
                if (flgView[Rowindex, 1].ToString() == string.Empty)
                {
                    for (int i = Rowindex; i > 1; i--)
                    {
                        if (flgView[i, 1].ToString() != "")
                        {
                            strTime = flgView[i, 1].ToString();
                            break;
                        }
                    }
                }
                else
                {
                    strTime = flgView[Rowindex, 1].ToString();
                }

                if (flgView[Rowindex, 0].ToString() == string.Empty)
                {
                    //获取日期
                    for (int i = Rowindex; i > 1; i--)
                    {
                        if (flgView[i, 0].ToString() != "")
                        {
                            strDate = flgView[i, 0].ToString();
                            break;
                        }
                    }
                }
                else
                {
                    strDate = flgView[Rowindex, 0].ToString();
                }
                return strDate + " " + strTime;
            }
            return null;
        }
        /// <summary>
        /// 获取当前选中项的项目名称
        /// </summary>
        /// <returns></returns>
        private string GetSelectItemName()
        { 
            string name=null;
            if (flgView[1, Colindex].ToString().Equals("实入量"))
            {
                for (int i = Colindex; i > 1; i--)
                {
                    if (flgView[Rowindex, i].ToString() != "")
                    {
                        name = flgView[Rowindex, i].ToString();
                    }
                }
            }
            else if (flgView[1, Colindex].ToString().Equals("引流出量"))
            {
                name = flgView[Rowindex, Colindex - 1].ToString();
            }
            else
            {
                name = flgView[1, Colindex].ToString();
            }
            return name;
        }

        private void cbxTotal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTotal.SelectedIndex == 0)
            {
                lblHour.Text = "24";
                dtpEnd.Value = dtpStart.Value.AddDays(1);
            }
            else
            {
                TimeSpan sp = dtpEnd.Value - dtpStart.Value;
                double dHour = sp.TotalHours;
                lblHour.Text = dHour.ToString().Split('.')[0];
            }
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            if(cbxTotal.Text=="随机汇总")
            {
                TimeSpan sp = dtpEnd.Value - dtpStart.Value;
                double dHour = sp.TotalHours;
                if (dHour < 0)
                {
                    App.MsgErr("您输入的起始时间大于截止时间！");
                }
                lblHour.Text = dHour.ToString().Split('.')[0];
            }
            else
            {
                dtpStart.Value = dtpEnd.Value.AddDays(-1);
                TimeSpan sp = dtpEnd.Value - dtpStart.Value;
                double dHour = sp.TotalHours;
                if (dHour < 0)
                {
                    App.MsgErr("您输入的起始时间大于截止时间！");
                }
                lblHour.Text =dHour.ToString().Split('.')[0];
            }
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            if (cbxTotal.Text == "随机汇总")
            {
                TimeSpan sp = dtpEnd.Value - dtpStart.Value;
                double dHour = sp.TotalHours;
                if (dHour < 0)
                {
                    App.MsgErr("您输入的起始时间大于截止时间！");
                }
                lblHour.Text = dHour.ToString().Split('.')[0];
            }
            else
            {
                dtpEnd.Value = dtpStart.Value.AddDays(1);
                TimeSpan sp = dtpEnd.Value - dtpStart.Value;
                double dHour = sp.TotalHours;
                if (dHour < 0)
                {
                    App.MsgErr("您输入的起始时间大于截止时间！");
                }
                lblHour.Text = dHour.ToString().Split('.')[0];
            }
        }

        /// <summary>
        /// 计算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btncalCulating_Click(object sender, EventArgs e)
        {
           addSum();
           DataTable dt= Sumshow();
           if (dt != null)
           {
               flgGgDisPlay.DataSource = dt.DefaultView;
           }
            ShowSumGrid();
        }
        /// <summary>
        /// 将汇总记录添加到数据库
        /// </summary>
        private void addSum()
        {
            MySqlDBParameter[] parameters = new MySqlDBParameter[6];
            parameters[0] = new MySqlDBParameter();
            parameters[0].ParameterName = "pid";
            parameters[0].DBType = MySqlDbType.VarChar;
            parameters[0].Value = Pid;
            parameters[0].Size = 20;

            parameters[1] = new MySqlDBParameter();
            parameters[1].ParameterName = "Total_time";
            parameters[1].DBType = MySqlDbType.Timestamp;
            parameters[1].Value = App.GetSystemTime();

            parameters[2] = new MySqlDBParameter();
            parameters[2].ParameterName = "begin_time";
            parameters[2].DBType = MySqlDbType.Timestamp;
            parameters[2].Value = dtpStart.Value;

            parameters[3] = new MySqlDBParameter();
            parameters[3].ParameterName = "end_time";
            parameters[3].DBType = MySqlDbType.Timestamp;
            parameters[3].Value = dtpEnd.Value;


            parameters[4] = new MySqlDBParameter();
            parameters[4].ParameterName = "recordByid";
            parameters[4].DBType = MySqlDbType.VarChar;
            if (App.UserAccount.UserInfo != null)
            {
                parameters[4].Value = App.UserAccount.UserInfo.User_id;
            }
            else
            {

                parameters[4].Value = "";
            }
            parameters[4].Size = 20;

            parameters[5] = new MySqlDBParameter();
            parameters[5].ParameterName = "sum_type";
            parameters[5].DBType = MySqlDbType.Decimal;
            parameters[5].Value = cbxTotal.SelectedIndex;

            App.ExecuteSQL(Sql_sum, parameters);
        }

        /// <summary>
        /// 显示汇总结果
        /// </summary>
        private DataTable Sumshow()
        {
            DataTable dt = new DataTable();
            DataSet ds = App.GetDataSet(sql_disp_sum);
            if (ds != null)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        /// <summary>
        /// 将汇总记录添加到表格
        /// </summary>
        private void ShowSumGrid()
        {
            ShowGrid();
            DataTable dt = Sumshow();
            if(dt.Rows.Count>0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    // 显示总入量,总出量数据
                    NuserInout_show SumInout = new NuserInout_show();
                    //显示其他各项的时间段内的总数据
                    NuserInout_show Sum_nuserInout = new NuserInout_show();
                    Sum_nuserInout.Date = Convert.ToDateTime(row["结束时间"]).ToShortDateString();
                    Sum_nuserInout.Time = Convert.ToDateTime(row["结束时间"]).ToShortTimeString();
                    Sum_nuserInout.Item_Mouth = row["口入汇总"].ToString();
                    Sum_nuserInout.Item_Tube = row["管入汇总"].ToString();
                    Sum_nuserInout.Imte_Intravenous = row["经静脉入汇总"].ToString();
                    Sum_nuserInout.Urine = row["尿量汇总"].ToString();
                    Sum_nuserInout.Defecate = row["大便汇总"].ToString();
                    Sum_nuserInout.Vomiting = row["呕吐汇总"].ToString();
                    Sum_nuserInout.Oozing_drainage = row["渗血渗液汇总"].ToString();
                    Sum_nuserInout.Drainage_value = row["引流汇总"].ToString();
                    SumInout.Item_Mouth = row["汇总类型"].ToString() + " " + "总入量：" + row["入量汇总"].ToString();
                    SumInout.Drainage = row["汇总类型"].ToString() + " " + "总出量：" + row["出量汇总"].ToString();
                    Sum_nuserInout.Operater = row["记录人"].ToString();
                    //list.Add(Sum_nuserInout);
                    DateTime endTime = Convert.ToDateTime(Sum_nuserInout.Date + " " + Sum_nuserInout.Time);
                    DateTime startTime = Convert.ToDateTime(row["起始时间"]);
                    DateTime TempDate = new DateTime();
                    string strDate = "";
                    string strTime = "";
                    bool flag = false;
                    //将汇总记录插到对象集合中去
                    for (int i = 0; i < list.Count; i++)
                    {
                        NuserInout_show temp_nuser =list[i];
                        if (temp_nuser.Date != null)
                            strDate = temp_nuser.Date;
                        if (temp_nuser.Time != null)
                            strTime = temp_nuser.Time;
                        TempDate = Convert.ToDateTime(strDate + " " + strTime);

                        if (TempDate > endTime && !flag) //表格的当前时间大于计算时间，则插在该条记录前面
                        {
                            list.Insert(i, Sum_nuserInout);
                            list.Insert(i + 1, SumInout);
                            int j = i + 1;
                            string SumNuser = SumInout.Item_Mouth + "," + SumInout.Drainage + "," + j.ToString();
                            arrayList.Add(SumNuser);
                            flag = true;
                        }
                        else
                        {
                            if (i == list.Count - 1 && !flag&&TempDate<endTime&&TempDate>=startTime)
                            {
                                list.Insert(i+1, Sum_nuserInout);
                                list.Insert(i + 2, SumInout);
                                int j = i + 2;
                                string SumNuser = SumInout.Item_Mouth + "," + SumInout.Drainage + "," + j.ToString();
                                arrayList.Add(SumNuser);
                                flag = true;
                                break;
                            }
                        }

                        //else if (i == list.Count - 1 && TempDate < endTime) //如果表格里面所有的时间都小于计算时间，则把他插到最后面
                        //{
                        //    list.Insert(i, Sum_nuserInout);
                        //    list.Insert(i + 1, SumInout);
                        //    arrayList.Add(i + 1);
                        //    flag = true;
                        //    break;
                        //}

       
                    }
                }
            }

            RefSumGrid();
        }

        /// <summary>
        /// 汇总后重新刷表格
        /// </summary>
        private void RefSumGrid()
        {
            setTableHeader();
            string date = null;
            string time = null;
            NuserInout_show[] nusers = new NuserInout_show[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                nusers[i] = new NuserInout_show();
                nusers[i] = list[i];
                if (date == null)
                {
                    date = nusers[i].Date;
                }
                else
                {
                    if (nusers[i].Date != date)
                    {
                        date = nusers[i].Date;
                        time = nusers[i].Time;
                    }
                    else
                    {
                        nusers[i].Date = null;
                        if (nusers[i].Time != time)
                        {
                            time = nusers[i].Time;
                        }
                        else
                        {
                            nusers[i].Time = null;
                        }
                    }
                }
            }
            App.ArrayToGrid(flgView, nusers, cols, 2);
            CellMerge();
            for (int i = 0; i < arrayList.Count;i++ )
            {
                int index =Convert.ToInt32(arrayList[i].ToString().Split(',')[2]);
                string SumIn = arrayList[i].ToString().Split(',')[0];
                string SumOut = arrayList[i].ToString().Split(',')[1];
                C1.Win.C1FlexGrid.CellRange cr;
                cr = flgView.GetCellRange(index + 2, 0, index + 2, 5);
                cr.Data = SumIn;
                cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
                flgView.MergedRanges.Add(cr);

                cr = flgView.GetCellRange(index + 2, 6, index + 2, 11);
                cr.Data = SumOut;
                cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
                flgView.MergedRanges.Add(cr);
                flgView.Rows[index+2].StyleNew.ForeColor = Color.Red;
                flgView.Rows[index+1].StyleNew.ForeColor = Color.Red;
            }
            //for (int i = 0; i < flgView.Rows.Count; i++)
            //{
            //    //只要有小结和出入量这几个字的字体都变成蓝色
            //    if (flgView[i, 2].ToString().Contains("0123456789")|| 
            //        flgView[i, 3].ToString().Contains("0123456789")||
            //        flgView[i, 4].ToString().Contains("0123456789")||
            //        flgView[i, 5].ToString().Contains("总入量")||
            //        flgView[i, 5].ToString().Contains("总出量"))
            //    {
                    
            //        flgView.Rows[i].StyleNew.ForeColor = Color.Red;
            //        if (i > 0)
            //        {
            //            flgView.Rows[i-1].StyleNew.ForeColor = Color.Red;
            //        }
            //    }
            //    else
            //    {
            //        flgView.Rows[i].StyleNew.ForeColor = Color.Black;                    
            //    }
            //}
        }

        private string GetSumType(object obj)
        {
            string sumType = null;
            if (obj.Equals(1))
                sumType = "随机汇总";
            sumType = "24小时汇总";
            return sumType;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            NuserInout_show[] nuserInouts = new NuserInout_show[list.Count];
            for (int i = 0; i < list.Count;i++)
            {
                nuserInouts[i] = new NuserInout_show();
                nuserInouts[i] = list[i];
            }
            DataSet ds = App.ObjectArrayToDataSet(nuserInouts);
            //frmPrintByInout_Amount print = new frmPrintByInout_Amount(ds,inp);
            //print.ShowDialog();
        }


        /// <summary>
        /// 验证输入的是否是大于零的数字
        /// </summary>
        /// <param name="inString"></param>
        /// <returns></returns>
        public static bool IsFloat(string inString)
        {

            Regex regex = new Regex(@"^\d*\.?\d*$");

            return regex.IsMatch(inString.Trim());

        }

        //private void flgView_CellChanged(object sender, RowColEventArgs e)
        //{
        //    if (!IsFloat(flgView[Rowindex, Colindex].ToString()))
        //    {
        //        App.Msg("请输入大于零的数字！");

        //    }
        //}
    }
}