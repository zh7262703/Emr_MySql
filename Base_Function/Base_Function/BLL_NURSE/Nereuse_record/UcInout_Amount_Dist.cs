using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using System.Collections;

using System.Text.RegularExpressions;
using C1.Win.C1FlexGrid;
using Base_Function.BASE_COMMON;
using Base_Function.BLL_NURSE.Nurse_Record_Manager;

namespace Base_Function.BLL_NURSE.Nereuse_record
{
    public partial class UcInout_Amount_Dist : UserControl
    {
        UserRights userRights1 = new UserRights();
       
        /// <summary>
        /// 第一次添加ucInout_Amount 的标志。
        /// </summary>
        private bool flag = false;
        /// <summary>
        /// 记录当前汇总记录的所在行
        /// </summary>
        private int index = 0; 
        /// <summary>
        /// 记录当前的选中的行
        /// </summary>
        string datatime;
        private int CurrentIndex = 0;
        /// <summary>
        /// 列的集合
        /// </summary>
        ColumnInfo[] cols = new ColumnInfo[13];
        bool F = false;
        /// <summary>
        /// 查出所有项目类型
        /// </summary>
        private string Sql_Codetype = "select id ,name from t_data_code where id = 109 or id =110";
        /// <summary>
        /// 查出所有出入液量记录单信息
        /// </summary>
        private string Sql_amount_dict = "select * from t_inout_amount_dict";

        private string Sql_Code_Way = "select id ,name from t_data_code where id between 111 and 113";

        private InPatientInfo inpatientInfo;
        ArrayList ListCount = new ArrayList();
        ArrayList ITemLiat = new ArrayList();
        
        public UcInout_Amount_Dist(InPatientInfo inPatientInfo)
        {
            InitializeComponent();
            inpatientInfo = inPatientInfo;
            //lblBedNumber.Text = inpatientInfo.In_Bed_Name;
           
        }

        public UcInout_Amount_Dist(InPatientInfo inPatientInfo,ArrayList arraylist)
        {
            InitializeComponent();
            inpatientInfo = inPatientInfo;
            //setTableHeader();
            //lblBedNumber.Text = inpatientInfo.In_Bed_Name;
            this.btnPrint.Enabled = false;//打印
            //this.btnSave.Enabled = false;//保存
            //this.btnCancle.Enabled = false;//取消
            this.btncalCulating.Enabled = false;//计算

            //查看的权利
            if (userRights1.isExistRole("tsbtnLook", arraylist))
            {
                this.btncalCulating.Enabled = true;
            }

            ////书写的权利
            //if (userRights1.isExistRole("tsbtnWrite", arraylist))
            //{
            //    this.btnSave.Enabled = true;
            //    this.btnCancle.Enabled = true;
            //}

            //打印权限
            if (userRights1.isExistRole("ttsbtnPrint", arraylist))
            {
                btnPrint.Enabled = true;
            }
            
        }



        //保存表格数据
        private List<NuserInout_show> list = new List<NuserInout_show>();
        //临时保存数据
        private List<NuserInout_show> SumNusers = new List<NuserInout_show>();
        private int Rowindex = 0;
        private int Colindex = 0;
        private string SelectCellVal = "无值";
        private ArrayList arrayList = new ArrayList();
        //当前病人

     
        public UcInout_Amount_Dist()
        {
            InitializeComponent();
            //setTableHeader();
        }
        public void UcInout_Amount_Dist_Load(object sender, EventArgs e)
        {
            lblHour.Text = "";
            //cboBeds.Items.Clear();
            BedNames();
            //InitTree();
            comboBoxIni();
            //setTableHeader();
            cboBeds.SelectedValue = inpatientInfo.Id;
            cboBeds.Text = inpatientInfo.Sick_Bed_Name;
            ShowSumGrid();
            //flgView.Cols[0].AllowEditing = false;
            //flgView.Cols[1].AllowEditing = false;
            //flgView.Cols[2].AllowEditing = false;
            //flgView.Cols[3].AllowEditing = false;
            //flgView.Cols[4].AllowEditing = false;
            //flgView.Cols[9].AllowEditing = false;
            //flgView.Cols[12].AllowEditing = false;
            cbxTotal.SelectedIndex = 0;
            //treeView1.ExpandAll();
            //setTableHeader();
            ListCount.Clear();
            ITemLiat.Clear();
            //F = true;
            //flgView.KeyDown +=new KeyEventHandler(flgView_KeyDown);

            if (App.UserAccount.CurrentSelectRole.Role_type != "N")
            {
                btnAdds.Enabled = false;
            }
        }
        private void BedNames()
        {
            string sql = @"select a.id,patient_name,case when gender_code=0 then '男' else '女' end gender_code,birthday,a.pid,age,age_unit,sick_doctor_id," +
                        @"sick_doctor_name,sick_area_id,sick_area_name,section_id,section_name,a.in_time,a.state,a.sick_bed_id,a.SICK_BED_NO from t_in_patient a  " +
                        @"inner join t_inhospital_action b on a.id=b.patient_id inner join t_sickbedinfo c on a.sick_bed_id=c.bed_id  where  a.SICK_AREA_ID=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " and  b.action_state=4  and  a.SICK_BED_NO is not null and  b.id in (select max(id) from t_inhospital_action group by patient_id) order by sick_bed_no ";
            if(App.UserAccount.CurrentSelectRole.Sickarea_Id=="")
                sql = @"select a.id,patient_name,case when gender_code=0 then '男' else '女' end gender_code,birthday,a.pid,age,age_unit,sick_doctor_id," +
                        @"sick_doctor_name,sick_area_id,sick_area_name,section_id,section_name,a.in_time,a.state,a.sick_bed_id,a.SICK_BED_NO from t_in_patient a  " +
                        @"inner join t_inhospital_action b on a.id=b.patient_id inner join t_sickbedinfo c on a.sick_bed_id=c.bed_id  where b.action_state=4  and  a.SICK_BED_NO is not null and  b.id in (select max(id) from t_inhospital_action group by patient_id) order by sick_bed_no ";
            DataSet ds = App.GetDataSet(sql);
            cboBeds.DataSource = ds.Tables[0].DefaultView;
            cboBeds.ValueMember = "ID";
            cboBeds.DisplayMember = "SICK_BED_NO";
        }
        ///// <summary>
        ///// 初始化树
        ///// </summary>
        //private void InitTree()
        //{
        //    DataSet ds_type = App.GetDataSet(Sql_Codetype);
        //    DataSet ds_amount_dist = App.GetDataSet(Sql_amount_dict);
        //    //TreeNode parentNode = new TreeNode();
        //    //parentNode.Text = "出入液量";
        //    if (ds_type != null)
        //    {
        //        DataTable dt = ds_type.Tables[0];
        //        if (dt.Rows.Count > 0)
        //        {
        //            foreach (DataRow rowTemp in dt.Rows)
        //            {
        //                //父节点
        //                TreeNode tempNode = new TreeNode();
        //                //子节点  入液量方式
        //                TreeNode childNode = new TreeNode();
        //                childNode.Text = "入液量方式";
        //                TreeNode Yinliunode = new TreeNode();
        //                Yinliunode.Text = "引流";
        //                tempNode.Name = rowTemp[0].ToString();
        //                tempNode.Text = rowTemp[1].ToString();
        //                if (rowTemp[1].ToString().Equals("入液量"))
        //                {
        //                    DataSet ds = App.GetDataSet(Sql_Code_Way);
        //                    DataTable dt1 = ds.Tables[0];
        //                    foreach (DataRow row1 in dt1.Rows)
        //                    {
        //                        TreeNode node = new TreeNode();
        //                        node.Text = row1[1].ToString();
        //                        node.Name = row1[0].ToString();
        //                        if (ds_amount_dist != null)
        //                        {
        //                            DataTable dt_amount_dist = ds_amount_dist.Tables[0];
        //                            if (dt_amount_dist.Rows.Count > 0)
        //                            {
        //                                foreach (DataRow row in dt_amount_dist.Rows)
        //                                {
        //                                    Inout_amount_dist dist = new Inout_amount_dist();
        //                                    dist.Id = Convert.ToInt32(row["id"]);
        //                                    dist.Item_code = row["item_code"].ToString();
        //                                    dist.Item_name = row["item_name"].ToString();
        //                                    dist.Item_value_type = row["item_value_type"].ToString();
        //                                    dist.Item_unit = row["item_unit"].ToString();
        //                                    if (row["display_seq"].ToString() != "")
        //                                    {
        //                                        dist.Display_seq = Convert.ToInt32(row["display_seq"].ToString());
        //                                    }
        //                                    dist.Amount_flag = row["amount_flag"].ToString();
        //                                    dist.Item_type = Convert.ToInt32(row["item_type"]);
        //                                    dist.Item_mode = Convert.ToInt32(row["item_mode"]);
        //                                    dist.Drainage_attribute = Convert.ToInt32(row["drainage_attribute"]);
        //                                    TreeNode cnode = new TreeNode();
        //                                    cnode.Text = dist.Item_name;
        //                                    cnode.Tag = dist as object;
        //                                    cnode.Name = dist.Id.ToString();
        //                                    if (dist.Item_type == 109)
        //                                    {
        //                                        if (dist.Item_mode.ToString() == node.Name)
        //                                        {
        //                                            node.Nodes.Add(cnode);
        //                                        }
        //                                    }
        //                                }
        //                            }
        //                        }
        //                        childNode.Nodes.Add(node);
        //                    }
        //                    tempNode.Nodes.Add(childNode);
        //                }
        //                else
        //                {
        //                    if (ds_amount_dist != null)
        //                    {
        //                        DataTable dt_amount_dist = ds_amount_dist.Tables[0];
        //                        if (dt_amount_dist.Rows.Count > 0)
        //                        {
        //                            foreach (DataRow row in dt_amount_dist.Rows)
        //                            {
        //                                Inout_amount_dist dist = new Inout_amount_dist();
        //                                dist.Id = Convert.ToInt32(row["id"]);
        //                                dist.Item_code = row["item_code"].ToString();
        //                                dist.Item_name = row["item_name"].ToString();
        //                                dist.Item_value_type = row["item_value_type"].ToString();
        //                                dist.Item_unit = row["item_unit"].ToString();
        //                                if (row["display_seq"].ToString() != "")
        //                                {
        //                                    dist.Display_seq = Convert.ToInt32(row["display_seq"].ToString());
        //                                }
        //                                dist.Amount_flag = row["amount_flag"].ToString();
        //                                dist.Item_type = Convert.ToInt32(row["item_type"]);
        //                                dist.Item_mode = Convert.ToInt32(row["item_mode"]);
        //                                dist.Drainage_attribute = Convert.ToInt32(row["drainage_attribute"]);
        //                                TreeNode cnode = new TreeNode();
        //                                cnode.Text = dist.Item_name;
        //                                cnode.Name = dist.Id.ToString();
        //                                cnode.Tag = dist as object;
        //                                if (dist.Item_type == 110)
        //                                {
        //                                    if (dist.Drainage_attribute != 1)
        //                                    {
        //                                        Yinliunode.Nodes.Add(cnode);
        //                                    }
        //                                    else
        //                                    {
        //                                        tempNode.Nodes.Add(cnode);
        //                                    }
        //                                }
        //                            }
        //                        }
        //                    }
        //                    tempNode.Nodes.Add(Yinliunode);
        //                }
        //                treeView1.Nodes.Add(tempNode);
        //            }
        //        }
        //    }
        //}

        int y = 0, x = 0;
        ///// <summary>
        ///// 显示项目编辑列表
        ///// </summary>
        //private void DisProjList(TreeNodeCollection nodes)
        //{
        //    foreach (TreeNode Pnode in nodes)
        //    {
        //        if (Pnode.Tag != null)
        //        {
        //            if (Pnode.Checked == true)
        //            {
        //                if (!IsSameItem(Pnode))
        //                {
        //                    Inout_amount_dist dist = (Inout_amount_dist)Pnode.Tag;
        //                    UcInout_Amount amount = new UcInout_Amount(Pnode.Text, dist.Id.ToString());
        //                    //订阅事件
        //                    amount.EventRef += new RefPanel(Reflocation);
        //                    amount.Name = dist.Id.ToString();
        //                    if (flag)
        //                        y = y + amount.Height;
        //                    amount.Location = new System.Drawing.Point(x, y);
        //                    panel1.Controls.Add(amount);
        //                    flag = true;
        //                }
        //            }
        //        }
        //        if (Pnode.Nodes.Count > 0)
        //            DisProjList(Pnode.Nodes);
        //    }
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    flag = false;
        //    x = 0;
        //    y = 0;
        //    panel1.Controls.Clear();
        //    DisProjList(treeView1.Nodes);
        //}

        ///// <summary>
        ///// 添加项目
        ///// </summary>
        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    int count = 0;
        //    if (panel1.Controls.Count > 0)
        //    {
        //        foreach (Control control in panel1.Controls)
        //        {
        //            UcInout_Amount amount = (UcInout_Amount)control;
        //            if (amount.txtValue.Text != "" && IsFloat(amount.txtValue.Text))
        //            {
        //                string userName = null;
        //                string userId = null;
        //                if (App.UserAccount.UserInfo != null)
        //                {
        //                    userName = App.UserAccount.UserInfo.User_name;
        //                    userId = App.UserAccount.UserInfo.User_id;
        //                }
        //                string sql = "insert into t_inout_amount_record (pid,record_time,record_id,record_name,item_code,item_value,patient_Id)" +
        //                             " values('" + inpatientInfo.PId + "',to_timestamp(to_char(sysdate,'yyyy-MM-dd hh24:mi'),'yyyy-MM-dd hh24:mi'),'" + userId + "'," +
        //                             "'" + userName + "','" + amount.Item_code + "','" + amount.txtValue.Text + "'," + inpatientInfo.Patient_Id + ")";
        //                try
        //                {
        //                    count += App.ExecuteSQL(sql);
        //                }
        //                catch
        //                {

        //                }
        //            }
        //            else
        //            {
        //                App.MsgErr("请输入大于的数字！");
        //            }
        //        }
        //        if (count > 0)
        //        {
        //            App.Msg("保存成功！");
        //            ShowSumGrid();
        //        }
        //        else
        //        {
        //            App.Msg("保存失败！");
        //        }
        //    }
        //}
        

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

            string sqls = "select to_char(t.record_time,'yyyy-mm-dd') as DATEVAL,to_char(t.record_time,'hh24:mi') as TIMERVAR," +
                @"t.item_code,t.item_value,t.item_attribute,t.item_name,t.patient_id," +
                @"d.item_type,d.drainage_attribute,d.item_mode,u.user_name from t_inout_amount_record t  inner join t_inout_amount_dict d on d.id=t.item_code  " +
                 @" inner join t_userinfo u on u.user_id=t.record_id where t.PATIENT_ID=" + inpatientInfo.Id + " order by record_time";
            string sql_time = "select distinct to_char(t.record_time,'yyyy-mm-dd') as DATEVAL,to_char(t.record_time,'hh24:mi') as TIMERVAR from t_inout_amount_record t where t.patient_Id=" + inpatientInfo.Id + "   order by DATEVAL,TIMERVAR asc";
            DataSet ds_time_sets = App.GetDataSet(sql_time);
            DataSet ds_values_sets = App.GetDataSet(sqls);
            DataTable dt_time = ds_time_sets.Tables[0];
            DataTable dt_sets = ds_values_sets.Tables[0];
            if (dt_time != null)
            {
                for (int i = 0; i < dt_time.Rows.Count; i++)
                {
                    string DateVale = Convert.ToDateTime(dt_time.Rows[i]["DATEVAL"].ToString()).ToString("yyyy-MM-dd");
                    string TimeValue = dt_time.Rows[i]["TIMERVAR"].ToString();
                    DataRow[] dt_values = dt_sets.Select(" DATEVAL='" + DateVale + "' and TIMERVAR='" + TimeValue + "'");
                    for (int k = 0; k < dt_values.Length; k++)
                    {
                        NuserInout_show nurserInout = new NuserInout_show();
                        nurserInout.Date = dt_values[k]["DATEVAL"].ToString();
                        nurserInout.Time = dt_values[k]["TIMERVAR"].ToString();
                        //if (item_code == "8")
                        //{
                        //    lblName.Text = "管入";     //项目名称
                        //}
                        //else if (item_code == "4")
                        //{
                        //    lblName.Text = "口入";
                        //}
                        //else if (item_code == "17")
                        //{
                        //    lblName.Text = "经静脉入";
                        //}
                        //else if (item_code == "30")
                        //{
                        //    lblName.Text = "引流";
                        //}
                        if (dt_values[k]["item_type"].ToString() == "109")//
                        {
                            if (dt_values[k]["item_mode"].ToString() == "111")//口入
                            {
                                nurserInout.Item_Mouth = dt_values[k]["item_name"].ToString();
                            }
                            if (dt_values[k]["item_mode"].ToString() == "112")//管入
                            {
                                nurserInout.Item_Tube = dt_values[k]["item_name"].ToString();
                            }
                            if (dt_values[k]["item_mode"].ToString() == "113")//经静脉入
                            {
                                nurserInout.Imte_Intravenous = dt_values[k]["item_name"].ToString();
                            }
                            if (dt_values[k]["item_value"].ToString() != "")
                                nurserInout.The_Real = (Convert.ToInt32(dt_values[k]["item_value"])).ToString();
                        }
                        if (dt_values[k]["item_type"].ToString() == "110")//
                        {
                            if (dt_values[k]["item_code"].ToString() == "18")//尿
                            {
                                nurserInout.Urine = dt_values[k]["item_value"].ToString();
                            }
                            else if (dt_values[k]["item_code"].ToString() == "19")//大便
                            {
                                nurserInout.Defecate = dt_values[k]["item_value"].ToString();
                            }
                            else if (dt_values[k]["item_code"].ToString() == "20")//呕吐
                            {
                                nurserInout.Vomiting = dt_values[k]["item_value"].ToString();
                            }
                            else if (dt_values[k]["item_code"].ToString() == "21")//渗血渗液
                            {
                                nurserInout.Oozing_drainage = dt_values[k]["item_value"].ToString();
                            }
                            else
                            {
                                nurserInout.Drainage = dt_values[k]["item_name"].ToString();
                                if (dt_values[k]["item_value"].ToString() != "")
                                    nurserInout.Drainage_value = (Convert.ToInt32(dt_values[k]["item_value"])).ToString();
                             }
                        }
                        nurserInout.Operater = dt_values[k]["user_name"].ToString();
                        list.Add(nurserInout);
                    }
                }
            }
            //string sql = "select * from inout_record_view where patient_id='" + inpatientInfo.Id + "'";
            //DataSet ds = App.GetDataSet(sql);
            //if (ds != null)
            //{
            //    DataTable dt = ds.Tables[0];
            //    if (dt.Rows.Count > 0)
            //    {
            //        foreach (DataRow row in dt.Rows)
            //        {
            //            NuserInout_show nurserInout = new NuserInout_show();
            //            nurserInout.Date = row["日期"].ToString();
            //            nurserInout.Time = row["时间"].ToString();
            //            nurserInout.Item_Mouth = row["口入"].ToString();
            //            nurserInout.Item_Tube = row["管入"].ToString();
            //            nurserInout.Imte_Intravenous = row["经静脉入"].ToString();
            //            if (row["实入量"].ToString() != "")
            //                nurserInout.The_Real = (Convert.ToInt32(row["实入量"])).ToString();
            //            nurserInout.Urine = row["尿"].ToString();
            //            nurserInout.Defecate = row["大便"].ToString();
            //            nurserInout.Vomiting = row["呕吐"].ToString();
            //            nurserInout.Drainage = row["引流"].ToString();
            //            if (row["引流出量"].ToString() != "")
            //                nurserInout.Drainage_value = (Convert.ToInt32(row["引流出量"])).ToString();
            //            nurserInout.Oozing_drainage = row["渗血渗液"].ToString();
            //            nurserInout.Operater = row["记录人"].ToString();
            //            list.Add(nurserInout);
            //        }
                    //string date = null;           //日期
                    //string time = null;          //时间
                    //string RecordName = null;   //记录人
                    //NuserInout_show [] nusers = new NuserInout_show[list.Count];
                    //for (int i = 0; i < list.Count;i++)
                    //{
                    //     nusers[i]=new NuserInout_show();
                    //     nusers[i] = list[i];
                    //     if (date == null)
                    //     {
                    //         RecordName = nusers[i].Operater;
                    //         date = nusers[i].Date;
                    //         time = nusers[i].Time;
                    //         nusers[i].Operater = null;
                    //     }
                    //     else
                    //     {
                    //         if (nusers[i].Date != date)
                    //         {
                    //             RecordName = nusers[i].Operater;
                    //             nusers[i-1].Operater = RecordName;
                    //             date = nusers[i].Date;
                    //             time = nusers[i].Time;
                    //             nusers[i].Operater = null;
                    //         }
                    //         else
                    //         {
                    //             nusers[i].Date = null;
                    //             if (nusers[i].Time != time)
                    //             {
                    //                 RecordName = nusers[i].Operater;
                    //                 nusers[i-1].Operater = RecordName;
                    //                 time = nusers[i].Time;
                    //                 RecordName = null;
                    //                 nusers[i].Operater = null;
                    //             }
                    //             else
                    //             {
                    //                 nusers[i].Operater = null;
                    //                 nusers[i].Time = null;
                    //             }
                    //         }
                    //     }

                    //}
                    //nusers[list.Count - 1].Operater = RecordName; 
                    //App.ArrayToGrid(flgView, nusers, cols, 2);                    
                    //CellMerge();

            //    }
            //}

        }
        /// <summary>
        /// 显示表格数据
        /// </summary>
        public void ShowGridD()
        {
            list.Clear();
            setTableHeader();
            string sqls = "select to_char(t.record_time,'yyyy-mm-dd') as DATEVAL,to_char(t.record_time,'hh24:mi') as TIMERVAR," +
                @"t.item_code,t.item_value,t.item_attribute,t.item_name,t.patient_id," +
                @"d.item_type,d.drainage_attribute,d.item_mode,u.user_name from t_inout_amount_record t  inner join t_inout_amount_dict d on d.id=t.item_code  " +
                 @" inner join t_userinfo u on u.user_id=t.record_id where t.PATIENT_ID=" + inpatientInfo.Id + " order by record_time";
            string sql_time = "select distinct to_char(t.record_time,'yyyy-mm-dd') as DATEVAL,to_char(t.record_time,'hh24:mi') as TIMERVAR from t_inout_amount_record t where t.patient_Id=" + inpatientInfo.Id + "   order by DATEVAL,TIMERVAR asc";
            DataSet ds_time_sets = App.GetDataSet(sql_time);
            DataSet ds_values_sets = App.GetDataSet(sqls);
            DataTable dt_time = ds_time_sets.Tables[0];
            DataTable dt_sets = ds_values_sets.Tables[0];
            if (dt_time != null)
            {
                for (int i = 0; i < dt_time.Rows.Count; i++)
                {
                    string DateVale = Convert.ToDateTime(dt_time.Rows[i]["DATEVAL"].ToString()).ToString("yyyy-MM-dd");
                    string TimeValue = dt_time.Rows[i]["TIMERVAR"].ToString();
                    DataRow[] dt_values = dt_sets.Select(" DATEVAL='" + DateVale + "' and TIMERVAR='" + TimeValue + "'");
                    for (int k = 0; k < dt_values.Length; k++)
                    {
                        NuserInout_show nurserInout = new NuserInout_show();
                        nurserInout.Date = dt_values[k]["DATEVAL"].ToString();
                        nurserInout.Time = dt_values[k]["TIMERVAR"].ToString();
                        if (dt_values[k]["item_type"].ToString() == "109")//
                        {
                            if (dt_values[k]["item_mode"].ToString() == "111")//口入
                            {
                                nurserInout.Item_Mouth = dt_values[k]["item_name"].ToString();
                            }
                            if (dt_values[k]["item_mode"].ToString() == "112")//管入
                            {
                                nurserInout.Item_Tube = dt_values[k]["item_name"].ToString();
                            }
                            if (dt_values[k]["item_mode"].ToString() == "113")//经静脉入
                            {
                                nurserInout.Imte_Intravenous = dt_values[k]["item_name"].ToString();
                            }
                            if (dt_values[k]["item_value"].ToString() != "")
                                nurserInout.The_Real = (Convert.ToInt32(dt_values[k]["item_value"])).ToString();
                        }
                        if (dt_values[k]["item_type"].ToString() == "110")//
                        {
                            if (dt_values[k]["item_code"].ToString() == "18")//尿
                            {
                                nurserInout.Urine = dt_values[k]["item_value"].ToString();
                            }
                            else if (dt_values[k]["item_code"].ToString() == "19")//大便
                            {
                                nurserInout.Defecate = dt_values[k]["item_value"].ToString();
                            }
                            else if (dt_values[k]["item_code"].ToString() == "20")//呕吐
                            {
                                nurserInout.Vomiting = dt_values[k]["item_value"].ToString();
                            }
                            else if (dt_values[k]["item_code"].ToString() == "21")//渗血渗液
                            {
                                nurserInout.Oozing_drainage = dt_values[k]["item_value"].ToString();
                            }
                            else
                            {
                                nurserInout.Drainage = dt_values[k]["item_name"].ToString();
                                if (dt_values[k]["item_value"].ToString() != "")
                                    nurserInout.Drainage_value = (Convert.ToInt32(dt_values[k]["item_value"])).ToString();
                            }
                        }
                        nurserInout.Operater = dt_values[k]["user_name"].ToString();
                        list.Add(nurserInout);
                    }
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

            //cols[12].Name = "病人住院号";
            //cols[12].Field = "Pid";
            //cols[12].Index = 14;
            //cols[12].visible = true;
            //for (int i = 0; i < 12; i++)
            //{
            //    flgView.AutoSizeCols(50) ;
            //}
            flgView.Cols[0].Width = 50;
            flgView.Cols[1].Width = 50;
            flgView.Cols[2].Width = 50;
            flgView.Cols[3].Width = 50;
            flgView.Cols[4].Width = 50;
            flgView.Cols[5].Width = 50;
            flgView.Cols[6].Width = 50;
            flgView.Cols[7].Width = 50;
            flgView.Cols[8].Width = 50;
            flgView.Cols[9].Width = 50;
            flgView.Cols[10].Width = 50;
            flgView.Cols[11].Width = 50;
            flgView.Cols[12].Width = 50;
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

            cr = flgView.GetCellRange(0, 2, 0, 5);
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
            string name = null;
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



        private void btncalCulating_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 将汇总记录添加到数据库
        /// </summary>
        private void addSum()
        {
            //MySqlDBParameter[] parameters = new MySqlDBParameter[6];
            //parameters[0] = new MySqlDBParameter();
            //parameters[0].ParameterName = "pid";
            //parameters[0].DBType = MySqlDbType.VarChar;
            //parameters[0].Value = inpatientInfo.PId;
            //parameters[0].Size = 20;

            //parameters[1] = new MySqlDBParameter();
            //parameters[1].ParameterName = "Total_time";
            //parameters[1].DBType = MySqlDbType.Timestamp;
            //parameters[1].Value = App.GetSystemTime().ToString("yyyy-MM-dd HH:mm");

            //parameters[2] = new MySqlDBParameter();
            //parameters[2].ParameterName = "begin_time";
            //parameters[2].DBType = MySqlDbType.Timestamp;
            //parameters[2].Value =  dtpStart.Value.ToString("yyyy-MM-dd HH:mm");

            //parameters[3] = new MySqlDBParameter();
            //parameters[3].ParameterName = "end_time";
            //parameters[3].DBType = MySqlDbType.Timestamp;
            //parameters[3].Value =  dtpEnd.Value.ToString("yyyy-MM-dd HH:mm");


            //parameters[4] = new MySqlDBParameter();
            //parameters[4].ParameterName = "recordByid";
            //parameters[4].DBType = MySqlDbType.VarChar;
            //if (App.UserAccount.UserInfo != null)
            //{
            //    parameters[4].Value = App.UserAccount.UserInfo.User_id;
            //}
            //else
            //{
            //    parameters[4].Value = "";
            //}
            //parameters[4].Size = 20;

            //parameters[5] = new MySqlDBParameter();
            //parameters[5].ParameterName = "sum_type";
            //parameters[5].DBType = MySqlDbType.Number;
            //parameters[5].Value = cbxTotal.SelectedIndex;
            #region 汇总计算
            //:pid,:Total_time,:begin_time,:end_time,:recordByid,:sum_type
            string selectSQL = "select * from t_inout_summ where start_time=to_timestamp('" + dtpStart.Value.ToString("yyyy-MM-dd HH:mm") + "','yyyy-MM-dd hh24:mi') and End_time=to_timestamp('" + dtpEnd.Value.ToString("yyyy-MM-dd HH:mm") + "','yyyy-MM-dd hh24:mi') and PATIENT_ID='" + inpatientInfo.Id + "'";
            DataSet selectCount = App.GetDataSet(selectSQL);
            if (null != selectCount && selectCount.Tables[0].Rows.Count > 0)
            {
                string deleteSQL = "delete from t_inout_summ where start_time=to_timestamp('" + dtpStart.Value.ToString("yyyy-MM-dd HH:mm") + "','yyyy-MM-dd hh24:mi') and End_time=to_timestamp('" + dtpEnd.Value.ToString("yyyy-MM-dd HH:mm") + "','yyyy-MM-dd hh24:mi') and PATIENT_ID='" + inpatientInfo.Id + "'";
                App.ExecuteSQL(deleteSQL);
            }

            datatime = App.GetSystemTime().ToString("yyyy-MM-dd HH:mm");
            string Sql_sum = "insert into t_inout_summ(PATIENT_ID,calc_date,start_time,end_time,record_id,sum_in,sum_out,mouth_in_sum,pipe_in_sum," +
                               " vein_in_sum,urine_amount_sum,faceces_amount_sum,vomit_amount_sum,oozingandexudate_sum," +
                               "  drainage_amount_sum,sum_type)" +
                  " select '" + inpatientInfo.Id + "',to_timestamp('" + datatime + "','yyyy-MM-dd hh24:mi'),to_timestamp('" + dtpStart.Value.ToString("yyyy-MM-dd HH:mm") + "','yyyy-MM-dd hh24:mi')," +
                         " to_timestamp('" + dtpEnd.Value.ToString("yyyy-MM-dd HH:mm") + "','yyyy-MM-dd hh24:mi'),'" + App.UserAccount.UserInfo.User_id + "'," +
                         " sum(case b.item_type when 109 then a.item_value end) 总入量," +
                         " sum(case b.item_type when 110 then a.item_value end) 总出量," +
                         " sum(case b.item_mode when 111 then a.item_value end) 口入汇总," +
                         " sum(case b.item_mode when 112 then a.item_value end) 管入汇总," +
                         " sum(case b.item_mode when 113 then a.item_value end) 经静脉入汇总," +
                         " sum(case b.item_name when '尿' then a.item_value end) 尿量," +
                         " sum(case b.item_name when '大便' then a.item_value end) 大便汇总," +
                         " sum(case b.item_name when '呕吐' then a.item_value end) 呕吐汇总," +
                         " sum(case b.item_name when '渗血渗液' then a.item_value end) 渗血渗液汇总," +
                         " sum(case b.drainage_attribute when 0 then a.item_value end) 引流汇总, '" + cbxTotal.SelectedIndex + "'" +
                         " from t_inout_amount_record  a " +
                         " inner join t_inout_amount_dict b on a.item_code = b.id " +
                         " where a.record_time between to_timestamp('" + dtpStart.Value.ToString("yyyy-MM-dd HH:mm") + "','yyyy-MM-dd hh24:mi')" +
                         " and  to_timestamp('" + dtpEnd.Value.ToString("yyyy-MM-dd HH:mm") + "','yyyy-MM-dd hh24:mi') and a.PATIENT_ID='" + inpatientInfo.Id + "'";
            #endregion
            try
            {
                int count = App.ExecuteSQL(Sql_sum);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            //if(count>0)
            //{

            //}

        }
         /// <summary>
        /// 将重新会汇总记录添加到数据库
        /// </summary>
        private void addSumS()
        {
            List<string>  listT=new List<string>();
            listT.Clear();
            string Sql_sum = "";
            string selectSQL = "select * from t_inout_summ where PATIENT_ID=" + inpatientInfo.Id + ";";//start_time=to_timestamp('" + dtpStart.Value.ToString("yyyy-MM-dd HH:mm") + "','yyyy-MM-dd hh24:mi') and End_time=to_timestamp('" + dtpEnd.Value.ToString("yyyy-MM-dd HH:mm") + "','yyyy-MM-dd hh24:mi') and PATIENT_ID='" + inpatientInfo.Id + "'";
            DataSet selectCount = App.GetDataSet(selectSQL);
            if (null != selectCount && selectCount.Tables[0].Rows.Count > 0)
            {
                Sql_sum=@"update t_inout_summ  t set sum_in=sum(case b.item_type when 109 then a.item_value end),"+
                      "sum_out=sum(case b.item_type when 110 then a.item_value end),"+
                      "mouth_in_sum=sum(case b.item_mode when 111 then a.item_value end),"+
                      "pipe_in_sum=sum(case b.item_mode when 112 then a.item_value end),"+
                      "vein_in_sum=sum(case b.item_mode when 113 then a.item_value end),"+
                      "urine_amount_sum=sum(case b.item_name when '尿' then a.item_value end),"+
                      "faceces_amount_sum=sum(case b.item_name when '大便' then a.item_value end),"+
                      "vomit_amount_sum=sum(case b.item_name when '呕吐' then a.item_value end),"+
                "oozingandexudate_sum=sum(case b.item_name when '渗血渗液' then a.item_value end),"+
                "drainage_amount_sum=sum(case b.drainage_attribute when 0 then a.item_value end)  "+
                " inner join t_inout_amount_record a on a.item_code = b.id "+
                "inner join t_inout_amount_dict b on a.item_code = b.id where ";
                //string deleteSQL = "delete from t_inout_summ where start_time=to_timestamp('" + dtpStart.Value.ToString("yyyy-MM-dd HH:mm") + "','yyyy-MM-dd hh24:mi') and End_time=to_timestamp('" + dtpEnd.Value.ToString("yyyy-MM-dd HH:mm") + "','yyyy-MM-dd hh24:mi') and PATIENT_ID='" + inpatientInfo.Id + "'";
                //App.ExecuteSQL(deleteSQL);
            }

            ////datatime = App.GetSystemTime().ToString("yyyy-MM-dd HH:mm");
            //string Sql_sum = "insert into t_inout_summ(PATIENT_ID,
            //calc_date,start_time,end_time,record_id,sum_in,sum_out,
            //mouth_in_sum,pipe_in_sum," +
            //                   " vein_in_sum,urine_amount_sum,
            //faceces_amount_sum,vomit_amount_sum,oozingandexudate_sum," +
            //                   "  drainage_amount_sum,sum_type)" +
            //      " select '" + inpatientInfo.Id + "',
            //to_timestamp('" + datatime + "','yyyy-MM-dd hh24:mi'),
            //to_timestamp('" + dtpStart.Value.ToString("yyyy-MM-dd HH:mm") + "','yyyy-MM-dd hh24:mi')," +
            //             " to_timestamp('" + dtpEnd.Value.ToString("yyyy-MM-dd HH:mm") + "','yyyy-MM-dd hh24:mi'),
            //'" + App.UserAccount.UserInfo.User_id + "'," +
            //             " sum(case b.item_type when 109 then a.item_value end) 总入量," +
            //             " sum(case b.item_type when 110 then a.item_value end) 总出量," +
            //             " sum(case b.item_mode when 111 then a.item_value end) 口入汇总," +
            //             " sum(case b.item_mode when 112 then a.item_value end) 管入汇总," +
            //             " sum(case b.item_mode when 113 then a.item_value end) 经静脉入汇总," +
            //             " sum(case b.item_name when '尿' then a.item_value end) 尿量," +
            //             " sum(case b.item_name when '大便' then a.item_value end) 大便汇总," +
            //             " sum(case b.item_name when '呕吐' then a.item_value end) 呕吐汇总," +
            //             " sum(case b.item_name when '渗血渗液' then a.item_value end) 渗血渗液汇总," +
            //             " sum(case b.drainage_attribute when 0 then a.item_value end) 引流汇总, '" + cbxTotal.SelectedIndex + "'" +
            //             " from t_inout_amount_record  a " +
            //             " inner join t_inout_amount_dict b on a.item_code = b.id " +
            //             " where a.record_time between to_timestamp('" + dtpStart.Value.ToString("yyyy-MM-dd HH:mm") + "','yyyy-MM-dd hh24:mi')" +
            //             " and  to_timestamp('" + dtpEnd.Value.ToString("yyyy-MM-dd HH:mm") + "','yyyy-MM-dd hh24:mi') and a.PATIENT_ID='" + inpatientInfo.Id + "'";
            //try
            //{
            //    int count = App.ExecuteSQL(Sql_sum);
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show(e.ToString());
            //}
        }
        /// <summary>
        /// 显示汇总结果
        /// </summary>
        private DataTable Sumshow()
        {
            #region 汇总显示
            string sql_disp_sum = "select b.patient_name 病人,to_char(start_time,'yyyy-MM-dd hh24:mi') 起始时间," +
                                  "to_char(end_time,'yyyy-MM-dd hh24:mi') 结束时间,c.user_name 记录人,sum_in 入量汇总," +
                                  " sum_out 出量汇总,mouth_in_sum 口入汇总,pipe_in_sum 管入汇总,vein_in_sum 经静脉入汇总,urine_amount_sum 尿量汇总," +
                                  " faceces_amount_sum 大便汇总,vomit_amount_sum 呕吐汇总,oozingandexudate_sum 渗血渗液汇总,drainage_amount_sum 引流汇总," +
                                  " (case sum_type when 0 then '24小时汇总' else '随机汇总' end) 汇总类型 from t_inout_summ a" +
                                  " left join t_in_patient b on a.PATIENT_ID = b.id" +
                                  " left join t_userinfo c on a.record_id = c.user_id where a.PATIENT_ID = '" + inpatientInfo.Id + "'order by a.end_time";
            #endregion
            DataTable dt = new DataTable();
            DataSet ds = App.GetDataSet(sql_disp_sum);
            if (ds != null)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }

        private void ShowSumGrid()
        {
            arrayList.Clear();
            flgGgDisPlay.Clear();
            flgView.Clear();
            setTableHeader();
            ShowGrid();
            
            DataTable dt = Sumshow();
            if (dt != null)
            {
                flgGgDisPlay.DataSource = dt.DefaultView;
            }
            if (dt.Rows.Count > 0)
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
                    if (row["汇总类型"].ToString() == "随机汇总")
                    {
                        DateTime end = Convert.ToDateTime(row["结束时间"]);
                        DateTime start = Convert.ToDateTime(row["起始时间"]);
                        TimeSpan total = (end - start);
                        string sum = total.TotalHours.ToString().Split('.')[0];
                        SumInout.Item_Mouth = sum + "小时汇总" + " 总入量： " + row["入量汇总"].ToString();
                        SumInout.Drainage = "         " + "总出量：" + row["出量汇总"].ToString();
                    }
                    else
                    {
                        if (row["入量汇总"].ToString() == "")
                        {
                            SumInout.Item_Mouth = row["汇总类型"].ToString() + " " + "总入量：" + "0";
                        }
                        else
                        {
                            SumInout.Item_Mouth = row["汇总类型"].ToString() + " " + "总入量：" + row["入量汇总"].ToString();
                        }
                        if (row["出量汇总"].ToString() == "")
                        {
                            SumInout.Drainage = "         " + "总出量：" + "0";
                        }
                        else
                        {
                            SumInout.Drainage = "         " + "总出量：" + row["出量汇总"].ToString();
                        }
                    }
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
                        NuserInout_show temp_nuser = (NuserInout_show)list[i];
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

                            if (i == list.Count - 1 && !flag && TempDate < endTime && TempDate >= startTime)
                            {
                                list.Insert(i + 1, Sum_nuserInout);
                                list.Insert(i + 2, SumInout);
                                int j = i + 2;
                                string SumNuser = SumInout.Item_Mouth + "," + SumInout.Drainage + "," + j.ToString();
                                arrayList.Add(SumNuser);
                                flag = true;
                                break;
                            }
                            else if (i == list.Count - 1 && !flag && TempDate == endTime && TempDate >= startTime)
                            {
                                list.Insert(i + 1, Sum_nuserInout);
                                list.Insert(i + 2, SumInout);
                                int j = i + 2;
                                string SumNuser = SumInout.Item_Mouth + "," + SumInout.Drainage + "," + j.ToString();
                                arrayList.Add(SumNuser);
                                flag = true;
                                break;
                            }

                        }
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
            flgView.MergedRanges.Clear();
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
                    time = nusers[i].Time;
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
            if (nusers.Length != 0)
            {
                App.ArrayToGrid(flgView, nusers, cols, 2);
            }
            CellMerge();
            /*
             * 统计的行，合并单元格，并改变行的颜色为红色
             */
            //for (int k = 0; k < flgView.Rows.Count;k++ )
            //{
            //    if (flgView.Rows[k].StyleNew.ForeColor == Color.Red)
            //    {
            //        flgView.Rows[k].StyleNew.ForeColor = Color.Black;
            //    }
            //}
            for (int i = 0; i < arrayList.Count; i++)
            {
                int index = Convert.ToInt32(arrayList[i].ToString().Split(',')[2]);
                string SumIn = arrayList[i].ToString().Split(',')[0];
                string SumOut = arrayList[i].ToString().Split(',')[1];
                C1.Win.C1FlexGrid.CellRange cr;
                cr = flgView.GetCellRange(index + 2, 0, index + 2, 12);

                cr.Data = SumIn + SumOut;

                cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
                flgView.MergedRanges.Add(cr);

                //cr = flgView.GetCellRange(index + 2, 6, index + 2, 11);
                //cr.Data = SumOut;
                //cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
                //flgView.MergedRanges.Add(cr);
                flgView.Rows[index + 2].StyleNew.ForeColor = Color.Red;
                flgView.Rows[index + 1].StyleNew.ForeColor = Color.Red;
                /*
                 * 目前边框只有左右下边框，上边框没有，所以，只能找到前面一行的下边框作为当前行的上边框
                 */
                if (index >= 1)
                {
                    flgView.Rows[index].StyleNew.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Horizontal;
                    flgView.Rows[index].StyleNew.Border.Width = 3;
                    flgView.Rows[index].StyleNew.Border.Color = Color.Red;
                }
            }
            if (flgView.Rows.Count > 2)
            {
                Rowindex = 2;
            }

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
            for (int i = 0; i < list.Count; i++)
            {
                nuserInouts[i] = new NuserInout_show();
                nuserInouts[i] = (NuserInout_show)list[i];
            }
            //DataSet ds = App.ObjectArrayToDataSet(nuserInouts);
            frmPrintByInout_Amount print = new frmPrintByInout_Amount(App.ObjectArrayToDataSet(nuserInouts), inpatientInfo);
            print.ShowDialog();
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

        //private void cbxTotal_SelectedIndexChanged_1(object sender, EventArgs e)
        //{
        //    if (cbxTotal.SelectedIndex == 0)
        //    {
        //        lblHour.Text = "24";
        //        dtpEnd.Value = dtpStart.Value.AddDays(1);
        //    }
        //    else
        //    {
        //        TimeSpan sp = dtpEnd.Value - dtpStart.Value;
        //        double dHour = sp.TotalHours;
        //        lblHour.Text = dHour.ToString().Split('.')[0];
        //    }
        //}

        //private void dtpStart_ValueChanged_1(object sender, EventArgs e)
        //{
        //    if (cbxTotal.Text == "随机汇总")
        //    {
        //        TimeSpan sp = dtpEnd.Value - dtpStart.Value;
        //        double dHour = sp.TotalHours;
        //        if (dHour < 0)
        //        {
        //            App.MsgErr("您输入的起始时间大于截止时间！");
        //        }
        //        lblHour.Text = dHour.ToString().Split('.')[0];
        //    }
        //    else
        //    {
        //        dtpEnd.Value = dtpStart.Value.AddDays(1);
        //        TimeSpan sp = dtpEnd.Value - dtpStart.Value;
        //        double dHour = sp.TotalHours;
        //        if (dHour < 0)
        //        {
        //            App.MsgErr("您输入的起始时间大于截止时间！");
        //        }
        //        lblHour.Text = dHour.ToString().Split('.')[0];
        //    }
        //}

        //private void dtpEnd_ValueChanged_1(object sender, EventArgs e)
        //{
        //    if (cbxTotal.Text == "随机汇总")
        //    {
        //        TimeSpan sp = dtpEnd.Value - dtpStart.Value;
        //        double dHour = sp.TotalHours;
        //        if (dHour < 0)
        //        {
        //            App.MsgErr("您输入的起始时间大于截止时间！");
        //        }
        //        lblHour.Text = dHour.ToString().Split('.')[0];
        //    }
        //    else
        //    {
        //        dtpStart.Value = dtpEnd.Value.AddDays(-1);
        //        TimeSpan sp = dtpEnd.Value - dtpStart.Value;
        //        double dHour = sp.TotalHours;
        //        if (dHour < 0)
        //        {
        //            App.MsgErr("您输入的起始时间大于截止时间！");
        //        }
        //        lblHour.Text = dHour.ToString().Split('.')[0];
        //    }
        //}

        private void flgView_Click_1(object sender, EventArgs e)
        {
            try
            {
                ShowGrid();
                MouseEventArgs mouse = new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0);
                if (mouse.Button == MouseButtons.Left)
                {
                    if (flgView.Rows.Count > 2)
                    {
                      
                        if (SelectCellVal != flgView[Rowindex, Colindex].ToString() && SelectCellVal != "无值" && flgView.ColSel > 4)
                        {
                            if (flgView[1, flgView.ColSel].ToString().Equals("口入") ||
                          flgView[1, flgView.ColSel].ToString().Equals("管入") ||
                          flgView[1, flgView.ColSel].ToString().Equals("经静脉入") ||
                          flgView[1, flgView.ColSel].ToString().Equals("引流"))
                            {
                                resuleBox.Visible = false;
                                string DateT = GetSelectItemTime(Rowindex.ToString());
                                string ID = GetSelectItemId(ItemNameY, DateT);
                                string strDate = GetSelectItemTime();
                                string itemID = ItemNameID(flgView[Rowindex, Colindex].ToString());
                                string values = "";
                                if (flgView[1, flgView.ColSel].ToString() == "经静脉入")
                                {
                                    values = flgView[Rowindex, 10].ToString();
                                }
                                else
                                {
                                    values = flgView[Rowindex, 5].ToString();
                                }
                                if (App.Ask("单元格中的值已经被修改过，是否保存?"))
                                {
                                   
                                    string sql = "update  t_inout_amount_record set item_value='"+values+"',ITEM_CODE='"+itemID+"',"+
                                        "ITEM_NAME='" + flgView[Rowindex, Colindex].ToString() + "' where ID=" + ID + "";

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
                            }
                            SelectCellVal = "无值";
                        }
                       
                    }
                }
            }
            catch (Exception ex)
            {
                App.MsgErr(ex.Message);
            }


        }
        private TextBox resuleBox = new TextBox();
        bool IfItemName = false;//判断是否为固定项
        /// <summary>
        ///   绑定出量其他的值
        /// </summary>
        public void comboBoxIni()
        {

            resuleBox.Visible = false;
            resuleBox.KeyUp += new KeyEventHandler(resuleBox_KeyUp);
            this.flgView.Controls.Add(resuleBox);

        }
        private void resuleBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                App.SelectFastCodeCheck();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                App.HideFastCodeCheck();
            }
            else if(e.KeyCode == Keys.Enter)
            {

                if (!App.FastCodeFlag)
                {
                    string sql = "";
                    if (resuleBox.Text.Trim() != "")
                    {
                        if (IfItemName == true)
                        {
                            if (flgView[1, flgView.ColSel].ToString() == "口入")
                            {
                                //入量 口入
                                sql = "select ITEM_NAME as 名称 from t_inout_amount_dict t where t.item_type=109 and t.item_mode=111 order by id";
                            }
                            else if (flgView[1, flgView.ColSel].ToString() == "管入")
                            {
                                //入量 管入
                                sql = "select ITEM_NAME as 名称 from t_inout_amount_dict t where t.item_type=109 and t.item_mode=112 order by id";
                            }
                            else if (flgView[1, flgView.ColSel].ToString() == "经静脉入")
                            {
                                //入量  经静脉入
                                sql = "select ITEM_NAME as 名称 from t_inout_amount_dict t where t.item_type=109 and t.item_mode=113 order by id";
                            }
                            else if (flgView[1, flgView.ColSel].ToString() == "引流")
                            {
                                //出量 引流
                                sql = "select ITEM_NAME as 名称 from t_inout_amount_dict t where t.item_type=110 and t.drainage_attribute=0 order by id";
                            }
                        }
                        else
                        {
                            sql = "select ITEM_NAME as 名称 from t_inout_amount_dict t where t.item_type=110 and t.drainage_attribute=1 order by id";
                        }
                    }
                    else if (resuleBox.Text.Trim() == "")
                    {
                        if (IfItemName == true)
                        {
                            if (flgView[1, flgView.ColSel].ToString() == "口入")
                            {
                                //入量 口入
                                sql = "select ITEM_NAME as 名称 from t_inout_amount_dict t where t.item_type=109 and t.item_mode=111 order by id";
                            }
                            else if (flgView[1, flgView.ColSel].ToString() == "管入")
                            {
                                //入量 管入
                                sql = "select ITEM_NAME as 名称 from t_inout_amount_dict t where t.item_type=109 and t.item_mode=112 order by id";
                            }
                            else if (flgView[1, flgView.ColSel].ToString() == "经静脉入")
                            {
                                //入量  经静脉入
                                sql = "select ITEM_NAME as 名称 from t_inout_amount_dict t where t.item_type=109 and t.item_mode=113 order by id";
                            }
                            else if (flgView[1, flgView.ColSel].ToString() == "引流")
                            {
                                //出量 引流
                                sql = "select ITEM_NAME as 名称 from t_inout_amount_dict t where t.item_type=110 and t.drainage_attribute=0 order by id";
                            }
                        }
                        else
                        {
                            sql = "select ITEM_NAME as 名称 from t_inout_amount_dict t where t.item_type=110 and t.drainage_attribute=1 order by id";
                        }
                    }
                    App.FastCodeCheck(sql, resuleBox, "名称", "名称");
                    flgView[Rowindex, Colindex] = resuleBox.Text;
                }
                App.FastCodeFlag = false;
            }

        }

        string ItemNameY = "";//临时存取以前的项目名称
        private void flgView_DoubleClick_1(object sender, EventArgs e)
        {
            if (flgView.RowSel > 1)
            {
                Rowindex = flgView.RowSel;
                Colindex = flgView.ColSel;
                if (flgView.Rows[flgView.RowSel].StyleNew.ForeColor == Color.Red)
                {
                    App.MsgErr("汇总信息不能修改！");
                    flgView.Focus();
                    return;
                }
                else
                {
                    if (flgView[1, flgView.ColSel].ToString().Equals("口入") ||
                        flgView[1, flgView.ColSel].ToString().Equals("管入") ||
                        flgView[1, flgView.ColSel].ToString().Equals("经静脉入") ||
                        flgView[1, flgView.ColSel].ToString().Equals("引流"))
                    {
                        Rectangle rect = this.flgView.GetCellRect(this.flgView.RowSel, this.flgView.ColSel, false);
                        resuleBox.Left = rect.Left;
                        resuleBox.Top = rect.Top;
                        resuleBox.Width = rect.Width;
                        resuleBox.Height = rect.Height;
                        resuleBox.Visible = true;
                        resuleBox.Text = flgView[flgView.RowSel, flgView.ColSel].ToString();
                        ItemNameY = flgView[flgView.RowSel, flgView.ColSel].ToString();
                        string DateT = GetSelectItemTime(Rowindex.ToString());
                        IFStockItem(resuleBox.Text,DateT);
                    }
                    if (flgView[flgView.RowSel, flgView.ColSel].ToString() == "" && flgView.ColSel > 4)
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
                            if (date != "" && flgView.Rows[flgView.RowSel].StyleNew.ForeColor != Color.Red)
                            {
                                frmUpdateUuserByDate nuserBydate = new frmUpdateUuserByDate(date);
                                nuserBydate.SetPID(inpatientInfo.Id.ToString(), datatime);
                                nuserBydate.ShowDialog();
                                if (nuserBydate.IsSuccess)       //操作成功后，就刷新表格
                                {
                                    ShowSumGrid();
                                }
                                return;
                            }
                        }
                    }
                }
                SelectCellVal = flgView[flgView.RowSel, flgView.ColSel].ToString();
                
            }
        }
        /// <summary>
        /// 根据项目名称和时间判断是否是固定项，是返回false，不是返回true
        /// </summary>
        /// <param name="ItemName"></param>
        /// <param name="strtime"></param>
        /// <returns></returns>
        private void IFStockItem(string ItemName, string strtime)
        {
            IfItemName = true;
            string Sql = "select ITEM_CODE from t_inout_amount_record where item_name ='" + ItemName + "' and to_char(record_time,'yyyy-mm-dd hh24:mi')='" + strtime + "'";
            string ID = App.ReadSqlVal(Sql, 0, "ID");
            string sqls = "select ITEM_NAME from t_inout_amount_dict where id="+ID+"";
            string ItemNames = App.ReadSqlVal(Sql, 0, "ITEM_NAME");
            if (ItemNames == "其它")
            {
                IfItemName = false;
            }
        }
        /// <summary>
        /// 根据项目名称得到项目ID
        /// </summary>
        /// <param name="ItemName"></param>
        /// <param name="strtime"></param>
        /// <returns></returns>
        private string  ItemNameID(string ItemName)
        {
            string Sql="";
            if (IfItemName == true)
            {
               Sql = "select ID from t_inout_amount_dict where ITEM_NAME='" + ItemName + "' and item_type=110 and drainage_attribute!=1 order by id";
            }
            else
            {
                string sqls = "select ID from t_inout_amount_dict where ITEM_NAME='" + ItemName + "'";
                string ID = App.ReadSqlVal(Sql, 0, "ID");
                if (ID == "")
                {
                    if ((flgView[1, flgView.ColSel].ToString() == "口入"))
                    {

                        Sql = "select ID from t_inout_amount_dict where item_type=111 and ITEM_NAME='其它' order by id";
                    }
                    else if ((flgView[1, flgView.ColSel].ToString() == "管入"))
                    {
                        Sql = "select ID from t_inout_amount_dict where item_type=112 and ITEM_NAME='其它' order by id";
                    }
                    else if ((flgView[1, flgView.ColSel].ToString() == "经静脉入"))
                    {
                        Sql = "select ID from t_inout_amount_dict where item_type=113 and ITEM_NAME='其它' order by id";
                    }
                    else if ((flgView[1, flgView.ColSel].ToString() == "引流"))
                    {
                        Sql = "select ID from t_inout_amount_dict where item_type=110 and drainage_attribute!=1 and ITEM_NAME='其它' order by id";
                    }
                }
            }
            string IDs = App.ReadSqlVal(Sql, 0, "ID");
            return IDs;
        }
        bool errorflag = true;
        private void flgView_KeyUp(object sender, KeyEventArgs e)
        {
            if (flgView.Rows.Count > 2)
            {
                    errorflag = true;
                    if (errorflag == true)
                    {
                        if (e.Control == true && e.KeyCode == Keys.Up)
                        {
                            if (Rowcount > 2)
                            {
                                int ros = Rowcount - 1;
                                itemName(ros.ToString());
                            }
                            else
                            {
                                App.Msg("数据已经在第一行，不能向上移动了");
                            }
                        }
                        if (e.Control == true & e.KeyCode == Keys.Down)//向下移
                        {
                            if (Rowcount <= flgView.Rows.Count-2)
                            {
                                int ros = Rowcount + 1;
                                itemName(ros.ToString());
                            }
                            else
                            {
                                App.Msg("数据已经在最后一行，不能向下移动了");
                            }
                        }
                    }
                }
           
            errorflag = false;
        }
        private void itemName(string Rols)
        {
            int Rol = Convert.ToInt32(Rols);
            string Date = flgView[Rowcount, 0].ToString();
            string Time = flgView[Rowcount,1].ToString();
            string Item_Mouth = flgView[Rowcount,2].ToString();
            string Item_Tube = flgView[Rowcount,3].ToString();
            string Imte_Intravenous = flgView[Rowcount,4].ToString();
            string The_Real = flgView[Rowcount,5].ToString();
            string Urine = flgView[Rowcount,6].ToString();
            string Defecate = flgView[Rowcount,7].ToString();
            string Vomiting = flgView[Rowcount,8].ToString();
            string Drainage = flgView[Rowcount,9].ToString();
            string Drainage_value = flgView[Rowcount,10].ToString();
            string Oozing_drainage = flgView[Rowcount,11].ToString();
            string Operater = flgView[Rowcount,12].ToString();
            string sql = "";
            string sqls = "";
            string DateT = GetSelectItemTime(Rowcount.ToString());
            string ID = "";
            string IDS = "";

            DataSet ds = null;
            DataSet dst = null;
            if (Item_Mouth != "")
            {
                ID = GetSelectItemId(Item_Mouth, DateT);
            }
            else if (Item_Tube != "")
            {
                ID = GetSelectItemId(Item_Tube, DateT);
            }
            else if (Imte_Intravenous != "")
            {
                ID = GetSelectItemId(Imte_Intravenous, DateT);
            }
            else  if (Urine != "")
            {
                ID = GetSelectItemId("尿", DateT);
            }
            else if (Defecate != "")
            {
                ID = GetSelectItemId("大便", DateT);
            }
            else  if (Vomiting != "")
            {
                ID = GetSelectItemId("呕吐", DateT);
            }
            else if (Drainage != "")
            {
                ID = GetSelectItemId(Drainage, DateT);
            }
            else if (Oozing_drainage != "")
            {
                ID = GetSelectItemId("渗血渗液", DateT);
            }
            string DateTs = GetSelectItemTime(Rol.ToString());
            if (flgView[Rol, 2].ToString() != "")
            {
                IDS = GetSelectItemId(flgView[Rol, 2].ToString(), DateTs);
            }
            else if (flgView[Rol, 3].ToString() != "")
            {
                IDS = GetSelectItemId(flgView[Rol, 3].ToString(), DateTs);
            }
            else if (flgView[Rol, 4].ToString() != "")
            {
                IDS = GetSelectItemId(flgView[Rol, 4].ToString(), DateTs);
            }
            else if (flgView[Rol, 6].ToString() != "")
            {
                IDS = GetSelectItemId("尿", DateTs);
            }
            else if (flgView[Rol, 7].ToString() != "")
            {
                IDS = GetSelectItemId("大便", DateTs);
            }
            else if (flgView[Rol, 8].ToString() != "")
            {
                IDS = GetSelectItemId("呕吐", DateTs);
            }
            else if (flgView[Rol, 9].ToString() != "")
            {
                IDS = GetSelectItemId(flgView[Rol, 9].ToString(), DateTs);
            }
            else if (flgView[Rol, 11].ToString() != "")
            {
                IDS = GetSelectItemId("渗血渗液", DateTs);
            }

            flgView[Rowcount, 0] = flgView[Rol, 0].ToString();
            flgView[Rowcount, 1] = flgView[Rol, 1].ToString();
            flgView[Rowcount, 2] = flgView[Rol, 2].ToString();
            flgView[Rowcount, 3] = flgView[Rol, 3].ToString();
            flgView[Rowcount, 4] = flgView[Rol, 4].ToString();
            flgView[Rowcount, 5] = flgView[Rol, 5].ToString();
            flgView[Rowcount, 6] = flgView[Rol, 6].ToString();
            flgView[Rowcount, 7] = flgView[Rol, 7].ToString();
            flgView[Rowcount, 8] = flgView[Rol, 8].ToString();
            flgView[Rowcount, 9] = flgView[Rol, 9].ToString();
            flgView[Rowcount, 10] = flgView[Rol, 10].ToString();
            flgView[Rowcount, 11] = flgView[Rol, 11].ToString();
            flgView[Rowcount, 12] = flgView[Rol, 12].ToString();
              
            flgView[Rol, 0] = Date;
            flgView[Rol, 1] = Time;
            flgView[Rol, 2] = Item_Mouth;
            flgView[Rol, 3] = Item_Tube;
            flgView[Rol, 4] = Imte_Intravenous;
            flgView[Rol, 5] = The_Real;
            flgView[Rol, 6] = Urine;
            flgView[Rol, 7] = Defecate;
            flgView[Rol, 8] = Vomiting;
            flgView[Rol, 9] = Drainage;
            flgView[Rol, 10] = Drainage_value;
            flgView[Rol, 11] = Oozing_drainage;
            flgView[Rol, 12] = Operater;
            if (ID != "" && ID != null && IDS != "" && IDS != null)
            {
                string sTq = "select * from t_inout_amount_record where id=" + ID + "";
                ds = App.GetDataSet(sTq);

                string sTqs = "select * from t_inout_amount_record where id=" + IDS + "";
                dst = App.GetDataSet(sTqs);
                string staTime =ds.Tables[0].Rows[0]["RECORD_TIME"].ToString();
                string staTimes =dst.Tables[0].Rows[0]["RECORD_TIME"].ToString();
                sql = " update t_inout_amount_record set PID='" + ds.Tables[0].Rows[0]["PID"].ToString() + "',TAKE_OVER_SEQ='" + ds.Tables[0].Rows[0]["TAKE_OVER_SEQ"].ToString() + "'," +
                    "RECORD_TIME=to_timestamp('" + staTimes + "','yyyy-MM-dd hh24:mi:ss'),RECORD_ID='" + ds.Tables[0].Rows[0]["RECORD_ID"].ToString() + "',RECORD_NAME='" + ds.Tables[0].Rows[0]["RECORD_NAME"].ToString() + "'," +
                    "ITEM_CODE='" + ds.Tables[0].Rows[0]["ITEM_CODE"].ToString() + "',ITEM_VALUE='" + ds.Tables[0].Rows[0]["ITEM_VALUE"].ToString() + "',ITEM_ATTRIBUTE='" + ds.Tables[0].Rows[0]["ITEM_ATTRIBUTE"].ToString() + "'," +
                    "ITEM_NAME='" + ds.Tables[0].Rows[0]["ITEM_NAME"].ToString() + "',PATIENT_ID='" + ds.Tables[0].Rows[0]["PATIENT_ID"].ToString() + "' where id=" + IDS + "";

                sqls = " update t_inout_amount_record set PID='" + dst.Tables[0].Rows[0]["PID"].ToString() + "',TAKE_OVER_SEQ='" + dst.Tables[0].Rows[0]["TAKE_OVER_SEQ"].ToString() + "'," +
                    "RECORD_TIME=to_timestamp('" + staTime + "','yyyy-MM-dd hh24:mi:ss'),RECORD_ID='" + dst.Tables[0].Rows[0]["RECORD_ID"].ToString() + "',RECORD_NAME='" + dst.Tables[0].Rows[0]["RECORD_NAME"].ToString() + "'," +
                    "ITEM_CODE='" + dst.Tables[0].Rows[0]["ITEM_CODE"].ToString() + "',ITEM_VALUE='" + dst.Tables[0].Rows[0]["ITEM_VALUE"].ToString() + "',ITEM_ATTRIBUTE='" + dst.Tables[0].Rows[0]["ITEM_ATTRIBUTE"].ToString() + "'," +
                    "ITEM_NAME='" + dst.Tables[0].Rows[0]["ITEM_NAME"].ToString() + "',PATIENT_ID='" + dst.Tables[0].Rows[0]["PATIENT_ID"].ToString() + "' where id=" + ID + "";
                App.ExecuteSQL(sql);
                App.ExecuteSQL(sqls);
                ShowSumGrid();
                this.flgView.Rows[Rol].StyleNew.BackColor = ColorTranslator.FromHtml("#a8d4df");
                this.flgView.Rows[Rowcount].StyleNew.BackColor = flgView.BackColor;
                Rowcount = Rol;
            }
            #region 
            //string names = "";
            //NuserInout_show nurserInouts = new NuserInout_show();
            //for (int i = Rol; i < flgView.Rows.Count; i += max)
            //{

            //    bool ms = Countvalue(i);
            //    if (ms == true)
            //    {
            //        NuserInout_show nurserInout = new NuserInout_show();
            //        nurserInout.Date = flgView[flgView.RowSel, 0].ToString();
            //        nurserInout.Time = flgView[flgView.RowSel, 1].ToString();
            //        nurserInout.Item_Mouth = flgView[flgView.RowSel, 2].ToString();
            //        nurserInout.Item_Tube = flgView[flgView.RowSel, 3].ToString();
            //        nurserInout.Imte_Intravenous = flgView[flgView.RowSel, 4].ToString();
            //        nurserInout.The_Real = flgView[flgView.RowSel, 5].ToString();
            //        nurserInout.Urine = flgView[flgView.RowSel, 6].ToString();
            //        nurserInout.Defecate = flgView[flgView.RowSel, 7].ToString();
            //        nurserInout.Vomiting = flgView[flgView.RowSel, 8].ToString();
            //        nurserInout.Drainage = flgView[flgView.RowSel, 9].ToString();
            //        nurserInout.Drainage_value = flgView[flgView.RowSel, 10].ToString();
            //        nurserInout.Oozing_drainage = flgView[flgView.RowSel, 11].ToString();
            //        nurserInout.Operater = flgView[flgView.RowSel, 12].ToString();
            //        ITemLiat.Add(nurserInout);
            //    }
            //    if (i == Rol)
            //    {
            //        nurserInouts.Date = flgView[flgView.RowSel, 0].ToString();
            //        nurserInouts.Time = flgView[flgView.RowSel, 1].ToString();
            //        nurserInouts.Item_Mouth = flgView[flgView.RowSel, 2].ToString();
            //        nurserInouts.Item_Tube = flgView[flgView.RowSel, 3].ToString();
            //        nurserInouts.Imte_Intravenous = flgView[flgView.RowSel, 4].ToString();
            //        nurserInouts.The_Real = flgView[flgView.RowSel, 5].ToString();
            //        nurserInouts.Urine = flgView[flgView.RowSel, 6].ToString();
            //        nurserInouts.Defecate = flgView[flgView.RowSel, 7].ToString();
            //        nurserInouts.Vomiting = flgView[flgView.RowSel, 8].ToString();
            //        nurserInouts.Drainage = flgView[flgView.RowSel, 9].ToString();
            //        nurserInouts.Drainage_value = flgView[flgView.RowSel, 10].ToString();
            //        nurserInouts.Oozing_drainage = flgView[flgView.RowSel, 11].ToString();
            //        nurserInouts.Operater = flgView[flgView.RowSel, 12].ToString();
            //    }
            //}
            //ITemLiat.Add(nurserInouts);
            //NuserInout_show[] nusers = new NuserInout_show[ITemLiat.Count];
            //for (int i = 0; i < ITemLiat.Count; i++)
            //{
            //    nusers[i] = new NuserInout_show();
            //    nusers[i] = (NuserInout_show)ITemLiat[i];
            //    //if (nusers[i].Date == null)
            //    //{
            //    //flgView[Rol + i, 0] = nusers[i].Date;
            //    //flgView[Rol + i, 1] = nusers[i].Time;
            //    flgView[Rol + i, 2] = nusers[i].Item_Mouth;
            //    flgView[Rol + i, 3] = nusers[i].Item_Tube;
            //    flgView[Rol + i, 4] = nusers[i].Imte_Intravenous;
            //    flgView[Rol + i, 5] = nusers[i].The_Real;
            //    flgView[Rol + i, 6] = nusers[i].Urine;
            //    flgView[Rol + i, 7] = nusers[i].Defecate;
            //    flgView[Rol + i, 8] = nusers[i].Vomiting;
            //    flgView[Rol + i, 9] = nusers[i].Drainage;
            //    flgView[Rol + i, 10] = nusers[i].Drainage_value;
            //    flgView[Rol + i, 11] = nusers[i].Oozing_drainage;
            //    flgView[Rol + i, 12] = nusers[i].Operater;
            //    //}
            //}
            #endregion

        }
        /// <summary>
        /// 获取当前选中项的时间
        /// </summary>
        /// <returns></returns>
        private string GetSelectItemTime(string DTime)
        {
            int Timecount = Convert.ToInt32(DTime);
            if (Timecount > 1)
            {
                string strDate = "";//记录日期
                string strTime = "";//记录时间     

                //获取时间
                if (flgView[Timecount, 1].ToString() == string.Empty)
                {
                    for (int i = Timecount; i > 1; i--)
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
                    strTime = flgView[Timecount, 1].ToString();
                }

                if (flgView[Timecount, 0].ToString() == string.Empty)
                {
                    //获取日期
                    for (int i = Timecount; i > 1; i--)
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
                    strDate = flgView[Timecount, 0].ToString();
                }
                return strDate + " " + strTime;
            }
            return null;
        }
        /// <summary>
        /// 根据项目名称和日期时间获取相关记录的ID
        /// </summary>
        /// <param Name="ItemName">项目名称</param>
        /// <param Name="strtime">日期时间</param>
        /// <returns></returns>
        private string GetSelectItemId(string ItemName, string strtime)
        {
            string Sql = "select id from t_inout_amount_record where item_name ='" + ItemName + "' and to_char(record_time,'yyyy-mm-dd hh24:mi')='" + strtime + "'";
            //string Sql = "select id from t_inout_amount_record where item_code = (select id from t_inout_amount_dict where item_name ='" + ItemName + "') and to_char(record_time,'yyyy-mm-dd hh24:mi')='" + strtime + "'";
            string ID = App.ReadSqlVal(Sql, 0, "ID");
            return ID;
        }
        ///// <summary>
        ///// 比较是否与移动的行数相同
        ///// </summary>
        ///// <param name="c"></param>
        ///// <returns></returns>
        //private bool Countvalue(int c)
        //{ 
        //    bool counts=false;
        //    for(int i=0;i<ListCount.Count;i++)
        //    {
        //        if (c ==Convert.ToInt32(ListCount[i].ToString()))
        //        {
        //            counts = true;
        //        }
        //        else
        //        {
        //            counts = false;
        //        }
        //    }
        //    return counts;
        //}
        int Rowcount = 0;
        private void flgView_MouseClick(object sender, MouseEventArgs e)
        {
            errorflag = true;
           
            if (flgView.RowSel > 2)
            {
                if (flgView[1, flgView.ColSel].ToString().Equals("口入") ||
                      flgView[1, flgView.ColSel].ToString().Equals("管入") ||
                      flgView[1, flgView.ColSel].ToString().Equals("经静脉入") ||
                      flgView[1, flgView.ColSel].ToString().Equals("引流") ||
                      flgView[1, flgView.ColSel].ToString().Equals("尿量")||
                      flgView[1, flgView.ColSel].ToString().Equals("记录人")||
                      flgView[1, flgView.ColSel].ToString().Equals("大便")||
                      flgView[1, flgView.ColSel].ToString().Equals("呕吐")||
                      flgView[1, flgView.ColSel].ToString().Equals("渗血渗液"))
                {

                    int rows = this.flgView.RowSel;//定义选中的行号 
                    if (rows > 0)
                    {
                        if (rows != Rowcount)
                        {
                            //就改变背景色
                            this.flgView.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#a8d4df");
                            this.flgView.Rows[Rowcount].StyleNew.BackColor = flgView.BackColor;
                        }
                        else
                        {
                            this.flgView.Rows[rows].StyleNew.BackColor = ColorTranslator.FromHtml("#a8d4df");
                        }
                    }
                    Rowcount = rows;
                }
            }
        }
        

        ///// <summary>
        ///// 单元格变化快捷码显示
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void flgView_CellChanged(object sender, RowColEventArgs e)
        //{
        //    //if (flgView.RowSel > 1)
        //    //{
        //    //    if (flgView[flgView.RowSel, flgView.ColSel] != null)
        //    //    {
        //    //        if (flgView[flgView.RowSel, flgView.ColSel].ToString().Trim() != "")
        //    //        {
        //    //            if (flgView.RowSel > 1 && flgView.ColSel > 1)
        //    //            {
        //    //                string name = flgView[flgView.RowSel, flgView.ColSel].ToString();
        //    //                if (flgView[1, flgView.ColSel].ToString().Equals("口入") ||
        //    //                   flgView[1, flgView.ColSel].ToString().Equals("管入") ||
        //    //                   flgView[1, flgView.ColSel].ToString().Equals("经静脉入") ||
        //    //                   flgView[1, flgView.ColSel].ToString().Equals("引流") ||
        //    //                   flgView[1, flgView.ColSel].ToString().Equals("记录人"))
        //    //                {
        //    //                    //
        //    //                }
        //    //            }
        //    //        }
        //    //    }
        //    //}
        //}
        /// <summary>
        /// 计算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btncalCulating_Click_1(object sender, EventArgs e)
        {
            addSum();
            DataTable dt = Sumshow();
            if (dt != null)
            {
                flgGgDisPlay.DataSource = dt.DefaultView;
            }
            ShowSumGrid();
        }
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click_1(object sender, EventArgs e)
        {
            try
            {
                NuserInout_show[] nuserInouts = new NuserInout_show[list.Count];
                for (int i = 0; i < list.Count; i++)
                {
                    nuserInouts[i] = new NuserInout_show();
                    nuserInouts[i] = list[i];
                }               //将对象数组装为数据集
                DataSet ds = App.ObjectArrayToDataSet(nuserInouts);
                if (null != ds)
                {
                    frmPrintByInout_Amount print = new frmPrintByInout_Amount(ds, inpatientInfo);
                    print.ShowDialog();
                }
                else
                {
                    App.Msg("没有数据可以打印");
                    return;
                }
            }
            catch (Exception ee)
            {
  
            }
        }
        ////添加项目
        //private void button1_Click_1(object sender, EventArgs e)
        //{

        //    //x = 0;
        //    //y = 0;
        //    //panel1.Controls.Clear();
        //    DisProjList(treeView1.Nodes);
        //}
        ///// <summary>
        ///// 保存
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btnSave_Click_1(object sender, EventArgs e)
        //{
        //    int count = 0;
        //    if (panel1.Controls.Count > 0)
        //    {
        //        StringBuilder strBulider = new StringBuilder();
        //        foreach (Control control in panel1.Controls)
        //        {
        //            UcInout_Amount amount = (UcInout_Amount)control;
        //            if (amount.txtValue.Text != "")
        //            {
        //                if (IsFloat(amount.txtValue.Text))
        //                {
        //                    string Item_Name = amount.Name; ;
        //                    string userName = null;
        //                    string userId = null;
        //                    if (App.UserAccount.UserInfo != null)
        //                    {
        //                        userName = App.UserAccount.UserInfo.User_name;
        //                        userId = App.UserAccount.UserInfo.User_id;
        //                    }
        //                    string sql = "insert into t_inout_amount_record (pid,record_time,record_id,record_name,item_code,item_value,item_name)" +
        //                                 " values('" + inpatientInfo.PId + "',to_timestamp('" + dateTimePicker1.Value + "','yyyy-MM-dd hh24:mi:ss'),'" + userId + "'," +
        //                                 "'" + userName + "','" + amount.Item_code + "','" + amount.txtValue.Text + "','" + Item_Name + "')";
        //                    strBulider.Append(sql + ".");
        //                }
        //                else
        //                {
        //                    App.MsgErr("请输入大于的数字！");
        //                }
        //            }

        //        }
        //        if (strBulider.Length > 0)
        //        {
        //            string[] arrs = strBulider.ToString().Substring(0, strBulider.Length - 1).Split('.');
        //            try
        //            {
        //                int num = App.ExecuteBatch(arrs);
        //                if (num > 0)
        //                {
        //                    flgView.DataSource = null;
        //                    //重新刷新表格
        //                    //ShowGrid();
        //                    ShowSumGrid();
        //                    x = 0;
        //                    y = 0;
        //                    this.panel1.Controls.Clear();
        //                    dateTimePicker1.Value = App.GetSystemTime();
        //                    RefTreeview(treeView1.Nodes);
        //                }
        //            }
        //            catch
        //            {

        //            }
        //        }
        //    }
        //}
        /// <summary>
        /// 计算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btncalCulating_Click_2(object sender, EventArgs e)
        {
            //if()
            //{
            addSum();
            DataTable dt = Sumshow();
            if (dt != null)
            {
                flgGgDisPlay.DataSource = dt.DefaultView;
            }
            ShowSumGrid();
            //}
        }
        /// <summary>
        /// 计算类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxTotal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTotal.Text != "24小时汇总")  //0代表24小时汇总
            {
                dtpEnd.Enabled = true;
                dtpStart.Enabled = true;
                dtpcSelect.Enabled = false;
                lblHour.Text = "24";
                dtpEnd.Value = App.GetSystemTime();
                dtpStart.Value = App.GetSystemTime();
            }
            else
            {
                dtpEnd.Enabled = false;
                dtpStart.Enabled = false;
                dtpcSelect.Enabled = true;
                dtpEnd.Value = Convert.ToDateTime(dtpcSelect.Value.ToShortDateString() + " " + "7:00");
                dtpStart.Value = Convert.ToDateTime(dtpcSelect.Value.AddDays(-1).ToShortDateString() + " " + "7:01");
                TimeSpan sp = dtpEnd.Value - dtpStart.Value;
                double dHour = sp.TotalHours;
                lblHour.Text = dHour.ToString().Split('.')[0];
            }
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            if (cbxTotal.Text == "随机汇总")
            {
                dtpEnd.Enabled = true;
                TimeSpan sp = dtpEnd.Value - dtpStart.Value;
                double dHour = sp.TotalHours;
                if (dHour < 0)
                {
                    App.MsgErr("您输入的起始时间大于截止时间！");
                }
                lblHour.Text = dHour.ToString().Split('.')[0];
            }
            //else
            //{
            //    dtpEnd.Enabled = false;
            //    dtpEnd.Value = Convert.ToDateTime(dtpcSelect.Value.ToShortDateString() + " " + "7:00");
            //    dtpStart.Value = Convert.ToDateTime(dtpEnd.Value.AddDays(-1).ToShortDateString()+ " " + "7:01");
            //    TimeSpan sp = dtpEnd.Value - dtpStart.Value;
            //    double dHour = sp.TotalHours;
            //    if (dHour < 0)
            //    {
            //        App.MsgErr("您输入的起始时间大于截止时间！");
            //    }
            //    lblHour.Text = dHour.ToString().Split('.')[0];
            //}
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
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
            //else
            //{
            //    dtpEnd.Value = Convert.ToDateTime(dtpcSelect.Value.ToShortDateString() + " " + "7:00");
            //    dtpStart.Value = Convert.ToDateTime(dtpEnd.Value.AddDays(-1).ToShortDateString() + " " + "7:01");
            //    TimeSpan sp = dtpEnd.Value - dtpStart.Value;
            //    double dHour = sp.TotalHours;
            //    if (dHour < 0)
            //    {
            //        App.MsgErr("您输入的起始时间大于截止时间！");
            //    }
            //    lblHour.Text = dHour.ToString().Split('.')[0];
            //}
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool flag = false;
            flag = DeleteSum();
            if (flag)       //删除成功，则刷新表格。
            {
                flgView.Rows[CurrentIndex - 1].StyleNew.Clear();
                RemoveByIndex(CurrentIndex - 1);
                Rowindex = flgView.RowSel;
                ShowSumGrid();
                //flgView.Rows[flgView.RowSel].StyleNew.Clear();
                //flgView.Rows.RemoveRange(CurrentIndex, 2);
            }
        }
        /// <summary>
        /// 删除表格里面的错误项
        /// </summary>
        /// <returns>true or false </returns>
        private bool DeleteSum()
        {
            bool flag = false;
            if (flgView.Rows.Count > 2)
            {

                Color color = flgView.Rows[flgView.RowSel].StyleNew.ForeColor;
                string Sql_Delete = null;
                //int NextIndex = 0;
                if (color == Color.Red)            //删除会总记录
                {
                    if (App.Ask("确定要删除这天汇总计算的结果吗？"))
                    {
                        string Date = null;       //时间
                        string Sum_Type = null;   // 汇总类别
                        if (flgView[flgView.RowSel, 0].ToString().Contains("-"))
                        {
                            CurrentIndex = flgView.RowSel;
                            //NextIndex = flgView.RowSel + 1;
                            Date = flgView[flgView.RowSel, 0].ToString() + " " + flgView[flgView.RowSel, 1].ToString();
                            if (flgView[flgView.RowSel + 1, 0].ToString().Contains("24小时汇总"))
                            {
                                Sum_Type = "0";
                            }
                            else
                            {
                                Sum_Type = "1";
                            }
                        }
                        else
                        {
                            //-1                                          //-1
                            Date = flgView[flgView.RowSel, 0].ToString() + " " + flgView[flgView.RowSel, 1].ToString();
                            if (flgView[flgView.RowSel, flgView.ColSel].ToString().Contains("24小时汇总"))
                            {
                                Sum_Type = "0";
                            }
                            else
                            {
                                Sum_Type = "1";
                            }
                            //选择的是汇总的第二行，则记录到第一行。
                            CurrentIndex = flgView.RowSel - 1;
                            //NextIndex = flgView.RowSel-1;
                        }

                        /*
                         *删除汇总记录 
                         */
                        string tttt = GetSelectItemTime();
                        string aa = tttt.Split(' ')[0];
                        Sql_Delete = " delete t_inout_summ where pid = '" + inpatientInfo.PId + "' and  end_time=to_timestamp('" + Date + "','yyyy-MM-dd hh24:mi') and sum_type=" + Sum_Type + "";
                        if (App.ExecuteSQL(Sql_Delete) > 0)
                        {
                            flag = true;
                            App.Msg("操作已经成功！");
                        }
                        else
                        {
                            App.MsgErr("操作失败！");
                        }
                    }

                }
                else if (flgView[1, flgView.ColSel].ToString() == "时间")
                {
                    if (App.Ask("确定要删除这个时间段的所有信息吗？"))
                    {
                        string data = "";
                        for (int i = flgView.RowSel; i > 1; i--)
                        {
                            if (flgView[i, 0].ToString().Trim() != "")
                            {
                                data = flgView[i, 0].ToString().Trim();
                                break;
                            }
                        }
                        string strtime = data + " " + flgView[flgView.RowSel, 1].ToString().Trim();
                        string sql = "";
                        if (App.UserAccount.CurrentSelectRole.Role_name.Contains("护士长"))
                        {
                            sql = "delete from t_inout_amount_record where  RECORD_TIME=to_timestamp('" + strtime + "','syyyy-mm-dd hh24:mi:ss.ff9') and PATIENT_ID=" + inpatientInfo.Patient_Id + "";
                        }
                        else
                        {
                            sql = "delete from t_inout_amount_record where  RECORD_TIME=to_timestamp('" + strtime + "','syyyy-mm-dd hh24:mi:ss.ff9') and PATIENT_ID=" + inpatientInfo.Patient_Id + " and RECORD_ID=" + App.UserAccount.Account_id + "";
                        }

                        if (App.ExecuteSQL(sql) > 0)
                        {
                            flag = true;
                            App.Msg("操作已经成功！");
                        }
                        else
                        {
                            App.MsgErr("此记录只有添加者本人才能删除，或者有其他原因操作失败！");
                        }
                    }
                }
                else                //删除具体的项
                {
                    if (App.Ask("确定要删除这条信息吗？"))
                    {
                        Sql_Delete = "delete t_inout_amount_record where item_code = (select id from t_inout_amount_dict where item_name ='" + flgView[flgView.RowSel, flgView.ColSel] + "')";
                        //flgView.Rows.Remove(flgView.RowSel);
                        if (App.ExecuteSQL(Sql_Delete) > 0)
                        {
                            flag = true;
                            App.Msg("操作已经成功！");
                        }
                        else
                        {
                            App.MsgErr("操作失败！");
                        }
                    }
                }
                //int count = App.ExecuteSQL(Sql_Delete);
                //if (count > 0)
                //{
                //    flag = true;
                //    App.Msg("该记录已经删除成功！");
                //    //从第几行开始删除，要删除几行。
                //    flgView.Rows[CurrentIndex].StyleNew.Clear();
                //    //flgView.Rows[CurrentIndex+1]
                //    flgView.Rows.RemoveRange(CurrentIndex, 2);
                //}
                //else
                //{
                //    App.Msg("该记录删除失败！");
                //}
            }
            return flag;
        }

        private void ctmnspDelete_Opening(object sender, CancelEventArgs e)
        {
            if (flgView.Rows.Count > 2)
            {
                //Color color = flgView.Rows[flgView.RowSel].StyleNew.ForeColor;
                //if (color == Color.Red)
                //{
                    this.删除ToolStripMenuItem.Visible = true;
                //}
                //else
                //{
                //    this.删除ToolStripMenuItem.Visible = false;
                //}
            }
        }
        /// <summary>
        /// 移除当前会诊记录
        /// </summary>
        private void RemoveByIndex(int index)
        {
            for (int i = 0; i < arrayList.Count; i++)
            {
                if (Convert.ToInt32(arrayList[i].ToString().Split(',')[2]) == index)
                {
                    arrayList.RemoveAt(i);
                    break;
                }
            }
        }

        private void dtpcSelect_ValueChanged(object sender, EventArgs e)
        {
            cbxTotal_SelectedIndexChanged(sender,e);
        }
        /// <summary>
        /// 清空树当前选中的checkBox的状态为false
        /// </summary>
        /// <param name="nodes">当前的节点集合</param>
        private void RefTreeview(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.Checked == true)
                {
                    node.Checked = false;
                }
                if (node.Nodes.Count > 0)
                {
                    RefTreeview(node.Nodes);
                }
            }
        }

        private void btnAdds_Click(object sender, EventArgs e)
        {
            UcInout_AddControla inTD = new UcInout_AddControla(this, inpatientInfo.PId, inpatientInfo.Id.ToString());
            App.ButtonStytle(inTD, false);
            inTD.ShowDialog();
        }
        private void cboBeds_Click(object sender, EventArgs e)
        {
            //F = true;
        }
        private void cboBeds_SelectedValueChanged(object sender, EventArgs e)
        {
            
            try
            {
                if (F == true)
                {
                    if (cboBeds.Text != "")
                    {
                        string sqlInFo = @"select  a.* from t_in_patient a  inner join t_inhospital_action b on a.id=b.patient_id " +
                           @" inner join t_sickbedinfo c on a.sick_bed_id=c.bed_id  " +
                           @"where  a.SICK_AREA_ID=" + App.UserAccount.CurrentSelectRole.Sickarea_Id + " and  " +
                           @" b.action_state=4  and  a.SICK_BED_NO is not null and  " +
                           @" b.id in (select max(id) from t_inhospital_action group by patient_id) and a.id=" + cboBeds.SelectedValue + " order by sick_bed_no ";
                        DataSet ds = App.GetDataSet(sqlInFo);
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            inpatientInfo.Id =Convert.ToInt32(row["id"].ToString());
                            inpatientInfo.Marrige_State = row["Marriage_State"].ToString();
                            inpatientInfo.Medicare_no = row["Medicare_NO"].ToString();
                            inpatientInfo.Home_address = row["Home_Address"].ToString();
                            inpatientInfo.HomePostal_code = row["Homepostal_Code"].ToString();
                            inpatientInfo.Home_phone = row["Home_Phone"].ToString();
                            inpatientInfo.Office = row["Office"].ToString();
                            inpatientInfo.Office_address = row["Office_Address"].ToString();
                            inpatientInfo.Office_phone = row["Office_Phone"].ToString();
                            inpatientInfo.Relation = row["Relation"].ToString();
                            inpatientInfo.Relation_name = row["Relation_Name"].ToString();
                            inpatientInfo.Career = row["Career"].ToString();
                            inpatientInfo.Relation_address = row["Relation_Address"].ToString();
                            inpatientInfo.Relation_phone = row["Relation_Phone"].ToString();
                            inpatientInfo.RelationPos_code = row["RelationPOS_Code"].ToString();
                            inpatientInfo.OfficePos_code = row["OfficePOS_Code"].ToString();
                            if (row["InHospital_Count"].ToString() != "")
                                inpatientInfo.InHospital_count = Convert.ToInt32(row["InHospital_Count"].ToString());
                            inpatientInfo.Cert_Id = row["CERT_ID"].ToString();
                            inpatientInfo.Pay_Manager = row["Pay_Manner"].ToString();
                            inpatientInfo.In_Circs = row["IN_Circs"].ToString();
                            inpatientInfo.Natiye_place = row["native_place"].ToString();
                            inpatientInfo.Birth_place = row["Birth_Place"].ToString();
                            inpatientInfo.Folk_code = row["Folk_Code"].ToString();
                            inpatientInfo.Id = Int32.Parse(row["id"].ToString());
                            inpatientInfo.Patient_Name = row["patient_name"].ToString();
                            inpatientInfo.Gender_Code = row["gender_code"].ToString();
                            inpatientInfo.Birthday = row["birthday"].ToString();
                            inpatientInfo.PId = row["pid"].ToString();
                            if (row["insection_id"].ToString() != "")
                                inpatientInfo.Insection_Id = Convert.ToInt32(row["insection_id"]);
                            inpatientInfo.Insection_Name = row["insection_name"].ToString();
                            inpatientInfo.In_Area_Id = row["in_area_id"].ToString();
                            inpatientInfo.In_Area_Name = row["in_area_name"].ToString();
                            if (row["age"].ToString() != "")
                                inpatientInfo.Age = row["age"].ToString();
                            //inpatient.Action_State = row["action_state"].ToString();
                            inpatientInfo.Sick_Doctor_Id = row["sick_doctor_id"].ToString();
                            inpatientInfo.Sick_Doctor_Name = row["sick_doctor_name"].ToString();
                            if (row["sick_area_id"].ToString() != "")
                                inpatientInfo.Sike_Area_Id = row["sick_area_id"].ToString();
                            inpatientInfo.Sick_Area_Name = row["sick_area_name"].ToString();
                            if (row["section_id"].ToString() != "")
                                inpatientInfo.Section_Id = Int32.Parse(row["section_id"].ToString());
                            inpatientInfo.Section_Name = row["section_name"].ToString();
                            if (row["in_time"] != null)
                                inpatientInfo.In_Time = DateTime.Parse(row["in_time"].ToString());
                            inpatientInfo.State = row["state"].ToString();
                            if (row["sick_bed_id"].ToString() != "")
                                inpatientInfo.Sick_Bed_Id = Int32.Parse(row["sick_bed_id"].ToString());
                            inpatientInfo.Sick_Bed_Name = row["sick_bed_no"].ToString();
                            inpatientInfo.Age_unit = row["age_unit"].ToString();
                            inpatientInfo.Sick_Degree = Convert.ToString(row["Sick_Degree"]);
                            inpatientInfo.Nurse_Level = Convert.ToString(row["Nurse_Level"]);
                            if (row["Die_flag"].ToString() != "")
                                inpatientInfo.Die_flag = Convert.ToInt32(row["Die_flag"]);
                            if (row["Sick_Group_Id"].ToString() != "")
                                inpatientInfo.Sick_Group_Id = Convert.ToInt32(row["Sick_Group_Id"]);
                            inpatientInfo.Card_Id = row["card_id"].ToString();
                            inpatientInfo.Patient_Id = row["patient_Id"].ToString();
                        }
                        ShowSumGrid();

                    }
                }
                F = false;
            }
            catch
            {
            }
        }



     

    
        //private void cboBeds_SelectedValueChanged(object sender, EventArgs e)
        //{
        //    string sql = "select * from t_in_patient t  where t.id=" + cboBeds.SelectedValue+ "";
        //    DataSet ds = App.GetDataSet(sql);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {

        //    }
        //}



       

      



        ////取消
        //private void btnCancle_Click(object sender, EventArgs e)
        //{
        //    x = 0;
        //    y = 0;
        //    //清空Panel1里面所有的项目
        //    this.panel1.Controls.Clear();
        //    //取消树选中的check的状态为false
        //    RefTreeview(treeView1.Nodes);
        //}

        //private void Reflocation(UcInout_Amount ucAmount)
        //{
        //    x = 0;
        //    y = 0;
        //    flag = false;
        //    this.panel1.Controls.Remove(ucAmount);
        //    foreach (Control control in panel1.Controls)
        //    {
        //        UcInout_Amount amount = control as UcInout_Amount;
        //        if (flag)
        //            y = y + amount.Height;
        //        amount.Location = new System.Drawing.Point(x, y);
        //        flag = true;
        //    }
        //}

        ///// <summary>
        ///// 判断当前选中的节点在Panel1里面是否已经存在，存在不做任何操作，不存在添加到Panel1
        ///// </summary>
        ///// <param name="node">当前选中的节点</param>
        ///// <returns>true 已经存在，false 不存在</returns>
        //private bool IsSameItem(TreeNode node)
        //{
        //    bool flag = false;
        //    foreach (Control control in panel1.Controls)
        //    {
        //        UcInout_Amount Ucamount = control as UcInout_Amount;
        //        if (node.Name == Ucamount.Item_code)
        //        {
        //            flag = true;
        //            break;
        //        }
        //    }
        //    return flag;
        //}

      
      

    
    }
}
