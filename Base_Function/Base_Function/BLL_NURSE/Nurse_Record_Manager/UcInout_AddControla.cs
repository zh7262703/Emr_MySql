//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using System.Collections;
using Bifrost.WebReference;
using System.Text.RegularExpressions;
//using Bifrost_Hospital_Management;
using System;
using Base_Function.BASE_COMMON;
using Base_Function.BLL_NURSE.Nereuse_record;
namespace Base_Function.BLL_NURSE.Nurse_Record_Manager
{
    public partial class UcInout_AddControla : DevComponents.DotNetBar.Office2007Form
    {
        //按钮权限类
        UserRights userRights1 = new UserRights();
        /// <summary>
        /// 定义委托重新排版
        /// </summary>
        private delegate void RefLocation();
        /// <summary>
        /// 第一次添加ucInout_Amount 的标志。
        /// </summary>
        public static bool flag = false;
        /// 查出所有项目类型
        /// </summary>
        private string Sql_Codetype = "select id ,name from t_data_code where id = 109 or id =110";
        /// <summary>
        /// 查出所有出入液量记录单信息
        /// </summary>
        private string Sql_amount_dict = "select * from t_inout_amount_dict";
        /// <summary>
        /// 查出入量方式的sql语句
        /// </summary>
        private string Sql_Code_Way = "select id ,name from t_data_code where id between 111 and 113";
        public static Panel addpan;
        public static int i = 0;
        string Pid;
        string Patient_Id;
        private UcInout_Amount_Dist UCAT;
        public static int y = 0, x = 0;
        public static Panel Pal=new Panel();
        public UcInout_AddControla(UcInout_Amount_Dist ucaT,string pid, string patientId)
        {
            Pid = pid;
            Patient_Id = patientId;
            UCAT = ucaT;
            InitializeComponent();
        }
        public UcInout_AddControla()
        {
            InitializeComponent();
            
        }
        /// <summary>
        /// 初始化树
        /// </summary>
        private void InitTree()
        {
            DataSet ds_type = App.GetDataSet(Sql_Codetype);
            DataSet ds_amount_dist = App.GetDataSet(Sql_amount_dict);
            //TreeNode parentNode = new TreeNode();
            //parentNode.Text = "出入液量";
            if (ds_type != null)
            {
                DataTable dt = ds_type.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow rowTemp in dt.Rows)
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
                                            cnode.Name = dist.Id.ToString();
                                            if (dist.Item_type == 109)
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
                                        cnode.Name = dist.Id.ToString();
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
                        treeView1.Nodes.Add(tempNode);
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            x = 0;
            y = 0;
            dtpCheckDate.Value = App.GetSystemTime();// Convert.ToDateTime(App.GetSystemTime().ToString("yyyy-MM-dd HH:mm"));
            //清空Panel2里面所有的项目
            ClearPanl(this.panel2);
            InitTree();
            treeView1.ExpandAll();
            ////设置按钮不可见
            //btncad.Visible = false;
            //btncad4.Visible = false;
            //btncad17.Visible = false;
            //btncad30.Visible = false;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            DisProjList(treeView1.Nodes); //根据树实例化panel2
        }

        ///// <summary>
        ///// 删除后重新排列Panel的控件的位置
        ///// </summary>
        ///// <param name="ucAmount"></param>
        //private void Reflocation(UcInout_AmountC ucAmount)
        //{
        //    x = 0;
        //    y = 0;
        //    flag = false;

        //    this.panel2.Controls.Remove(ucAmount);
        //    foreach (Control control in panel2.Controls)
        //    {
        //        if (!control.GetType().FullName.Contains("ButtonX"))
        //        {
        //            UcInout_AmountC amount = control as UcInout_AmountC;
        //            if (flag)
        //                y = y + amount.Height;
        //            amount.Location = new System.Drawing.Point(x, y);
        //            flag = true;
        //        }
        //    }
        //    foreach (Control control in panel2.Controls)
        //    {

        //        if (!control.GetType().FullName.Contains("ButtonX"))
        //        {
        //            UcInout_AmountC useac = control as UcInout_AmountC;
        //            if (useac.Tag.ToString() == "其它4")
        //            {
        //                btncad4.Visible = true;
        //                btncad4.Location = new System.Drawing.Point(control.Location.X + 265, control.Location.Y);
        //            }
        //            if (useac.Tag.ToString() == "其它8")
        //            {
        //                btncad.Visible = true;
        //                btncad.Location = new System.Drawing.Point(control.Location.X + 265, control.Location.Y);
        //            }
        //            if (useac.Tag.ToString() == "其它17")
        //            {
        //                btncad17.Visible = true;
        //                btncad17.Location = new System.Drawing.Point(control.Location.X + 265, control.Location.Y);
        //            }
        //            if (useac.Tag.ToString() == "其它30")
        //            {
        //                btncad30.Visible = true;
        //                btncad30.Location = new System.Drawing.Point(control.Location.X + 265, control.Location.Y);
        //            }
        //        }
        //    }

        //    int c = 0;
        //    int d = 0;
        //    int e = 0;
        //    int f = 0;
        //    foreach (Control control in panel2.Controls)
        //    {
        //        if (!control.GetType().FullName.Contains("ButtonX"))
        //        {
        //            UcInout_AmountC useac = control as UcInout_AmountC;
        //            if (useac.Tag.ToString() == "其它4")
        //            {
        //                c++;
        //            }

        //            if (useac.Tag.ToString() == "其它8")
        //            {
        //                d++;
        //            }

        //            if (useac.Tag.ToString() == "其它17")
        //            {
        //                e++;
        //            }
        //            if (useac.Tag.ToString() == "其它30")
        //            {
        //                f++;
        //            }
        //        }

        //    }
        //    if (c == 1)
        //    {
        //        btncad4.Visible = true;
        //    }
        //    else
        //    {
        //        btncad4.Visible = false;
        //    }
        //    if (d == 1)
        //    {
        //        btncad.Visible = true;
        //    }
        //    else
        //    {
        //        btncad.Visible = false;
        //    }
        //    if (e == 1)
        //    {
        //        btncad17.Visible = true;
        //    }
        //    else
        //    {
        //        btncad17.Visible = false;
        //    }
        //    if (f == 1)
        //    {
        //        btncad30.Visible = true;
        //    }
        //    else
        //    {
        //        btncad30.Visible = false;
        //    }

        //}


        //刷新pane２

        //刷新panel  delegate
        public delegate void RefPanel(UcInout_Amount ucAmount);
        //public delegate void RefPanel(UcInout_AmountC ucAmount);
        /// <summary>
        /// 显示项目编辑列表
        /// </summary>
        private void DisProjList(TreeNodeCollection nodes)
        {
            foreach (TreeNode Pnode in nodes)
            {
                if (Pnode.Tag != null)
                {
                    if (Pnode.Checked == true)
                    {
                        if (!IsSameItem(Pnode))
                        {
                            Inout_amount_dist dist = (Inout_amount_dist)Pnode.Tag;

                            UcInout_Amount amount = new UcInout_Amount(Pnode.Text, dist.Id.ToString(), dist.Item_type.ToString(),dist.Item_mode.ToString());
                                //订阅事件
                                amount.EventRef += new RefPanel(Reflocation);
                                amount.Name = dist.Id.ToString();
                                if (flag)
                                    y = y + amount.Height;
                                amount.Location = new System.Drawing.Point(x, y);
                                if (y > 325)
                                {
                                    Pal.Size = new System.Drawing.Size(349, y + 5);
                                }
                                Pal = panel2;
                                Pal.Controls.Add(amount);
                                flag = true;
                            //Inout_amount_dist dist = (Inout_amount_dist)Pnode.Tag;
                            //UcInout_AmountC amount = new UcInout_AmountC(Pnode.Text, dist.Id.ToString());
                            //amount.Tag = Pnode.Text.ToString() + dist.Id.ToString();
                            ////订阅事件
                            //amount.EventRef += new RefPanel(Reflocation);
                            //amount.Name = dist.Id.ToString();
                            //if (flag)
                            //    amount.Location = new System.Drawing.Point(x, y);
                            //panel2.Controls.Add(amount);
                            
                            ////按钮位置判断
                            //if (Pnode.Text == "其它" && dist.Id.ToString() == "4")
                            //{
                            //    btncad4.Visible = true;
                            //    ax = x + 265;
                            //    ay = y;
                            //    btncad.Location = new System.Drawing.Point(ax, ay);

                            //}
                            //if (Pnode.Text == "其它" && dist.Id.ToString() == "8")
                            //{
                            //    btncad.Visible = true;
                            //    ax = x + 265;
                            //    ay = y;
                            //    btncad4.Location = new System.Drawing.Point(ax, ay);
                            //}
                            //if (Pnode.Text == "其它" && dist.Id.ToString() == "17")
                            //{
                            //    btncad17.Visible = true;
                            //    ax = x + 265;
                            //    ay = y;
                            //    btncad17.Location = new System.Drawing.Point(ax, ay);
                            //}
                            //if (Pnode.Text == "其它" && dist.Id.ToString() == "30")
                            //{
                            //    btncad30.Visible = true;
                            //    ax = x + 265;
                            //    ay = y;
                            //    btncad30.Location = new System.Drawing.Point(ax, ay);
                            //}
                            //y = y + amount.Height;
                            //flag = true;
                        }
                    }
                }
                if (Pnode.Nodes.Count > 0)
                    DisProjList(Pnode.Nodes);
            }
        }
        /// <summary>
        /// 添加其他项
        /// </summary>
        /// <param name="Itemname"></param>
        /// <param name="Itemcode"></param>
        public  static void OtherName(string Itemname,string Itemcode)
        {
            UcInout_Amount amounts = new UcInout_Amount(Itemname, Itemcode,false);
            //订阅事件
            amounts.EventRef += new RefPanel(Reflocation);
            amounts.Name = Itemcode;
            y = y + amounts.Height;
            amounts.Location = new System.Drawing.Point(x, y);
            if (y > 325)
            {
                Pal.Size = new System.Drawing.Size(349, y + 5);
            }
            Pal.Controls.Add(amounts);
            //int ys = 0;
            //foreach (Control control in Pal.Controls)
            //{
            //    UcInout_Amount amount = control as UcInout_Amount;
            //    if (amount.Item_code == amounts.Name)
            //    {
            //        ys = ys + amount.Height;
            //        if (y > 325)
            //        {
            //            Pal.Size = new System.Drawing.Size(349, ys + 5);
            //        }
            //        amount.Location = new System.Drawing.Point(x, ys);
            //        ys = ys + amount.Height;
            //        amounts.Location = new System.Drawing.Point(x, ys);
            //        Pal.Controls.Add(amounts);

            //    }
            //    else
            //    {
            //        ys = ys + amount.Height;
            //        if (y > 325)
            //        {
            //            Pal.Size = new System.Drawing.Size(349, y + 5);
            //        }
            //        amount.Location = new System.Drawing.Point(x, y);
            //    }
              
            //}
            
           
            
          

        }
        public static void Reflocation(UcInout_Amount ucAmount)
        {
            x = 0;
            y = 0;
            flag = false;
            Pal.Controls.Remove(ucAmount);
            foreach (Control control in Pal.Controls)
            {
                UcInout_Amount amount = control as UcInout_Amount;
                if (flag)
                    y = y + amount.Height;
                amount.Location = new System.Drawing.Point(x, y);
                flag = true;
            }
        }
        /// <summary>
        /// 判断当前选中的节点在Panel２里面是否已经存在，存在不做任何操作，不存在添加到Panel1
        /// </summary>
        /// <param name="node">当前选中的节点</param>
        /// <returns>true 已经存在，false 不存在</returns>
        private bool IsSameItem(TreeNode node)
        {
            bool flag = false;
            foreach (Control control in panel2.Controls)
            {
                if (!control.GetType().FullName.Contains("ButtonX"))
                {
                    UcInout_Amount Ucamount = control as UcInout_Amount;
                    if (Ucamount != null)
                    {
                        if (node.Name == Ucamount.Item_code)
                        {
                            flag = true;
                            break;
                        }
                    }
                }

            }
            return flag;
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

        private void btnCancle_Click(object sender, EventArgs e)
        {
            x = 0;
            y = 0;
            //清空Panel2里面所有的项目
            //this.panel2.Controls.Clear();
            ClearPanl(this.panel2);
            //取消树选中的check的状态为false
            RefTreeview(treeView1.Nodes);
            this.Close();
            //btncad.Visible = true;
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            ArrayList Sqls = new ArrayList();
            Sqls.Clear();
             string sql = "";
             //string Sql = "select * from t_inout_summ t where PATIENT_ID='" + Pid + "' and to_char(start_time,'yyyy-MM-dd hh24:mi')<='" + RecodeTime + "' and  '" + RecodeTime + "'<=to_char(end_time,'yyyy-MM-dd hh24:mi')";
             //DataSet ds = App.GetDataSet(Sql);
            if (panel2.Controls.Count > 0)
            {
                foreach (Control control in panel2.Controls)
                {
                    if (!control.GetType().FullName.Contains("ButtonX"))
                    {
                        UcInout_Amount amount = (UcInout_Amount)control;
                        if (amount.txtValue.Text != "" && amount.txtValue.Text != null && IsFloat(amount.txtValue.Text))
                        {
                            if (amount.Name != "" && amount.Name != null)
                            {
                                string userName = null;
                                string userId = null;
                                if (App.UserAccount.UserInfo != null)
                                {
                                    userName = App.UserAccount.UserInfo.User_name;
                                    userId = App.UserAccount.UserInfo.User_id;
                                }
                                string sqlSelect = string.Format(@"select count(id) count from t_inout_amount_record t where t.patient_id={0} 
                                    and to_char(t.record_time,'yyyy-MM-dd hh24:mi')='{1}' and t.item_name='{2}' and t.item_value='{3}'",
                                   Patient_Id, dtpCheckDate.Value.ToString("yyyy-MM-dd HH:mm"), amount.Name, amount.txtValue.Text);
                                string result = App.ReadSqlVal(sqlSelect, 0, "count");
                                if (result == "1")
                                {
                                    continue;
                                }
                                else
                                {
                                    sql = "insert into t_inout_amount_record (pid,record_time,record_id,record_name,item_code,item_value,patient_Id,Item_Name)" +
                                                 " values('" + Pid + "',to_timestamp('" + dtpCheckDate.Value.ToString("yyyy-MM-dd HH:mm") + "','yyyy-MM-dd hh24:mi'),'" + userId + "'," +
                                                 "'" + userName + "','" + amount.Item_code + "','" + amount.txtValue.Text + "'," + Patient_Id + ",'" + amount.Name + "')";
                                    Sqls.Add(sql);
                                    string RecodeTime = dtpCheckDate.Value.ToString("yyyy-MM-dd HH:mm");


                                    string Sql = "select * from t_inout_summ t where PATIENT_ID=" + Patient_Id + " and to_char(start_time,'yyyy-MM-dd hh24:mi')<='" + RecodeTime + "' and  '" + RecodeTime + "'<=to_char(end_time,'yyyy-MM-dd hh24:mi')";
                                    DataSet ds = App.GetDataSet(Sql);
                                    if (ds.Tables[0].Rows.Count > 0 && ds != null)
                                    {
                                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                        {

                                            string sumid = ds.Tables[0].Rows[i]["id"].ToString();
                                            /*
                                             * 109 入量 110出量
                                             */
                                            string ItemSql = "";//更新的SQL语句
                                            int currentSumIn = 0;//当前总入量
                                            int cuttrntMOUTH_IN_SUM = 0;//当前口入量
                                            int cuttrntPIPE_IN_SUM = 0;//当前管入量
                                            int cuttrntVEIN_IN_SUM = 0;//当前静脉入量
                                            int newMOUTH_IN_SUM = 0;//新的口入量
                                            int newPIPE_IN_SUM = 0;//新的管入量
                                            int newVEIN_IN_SUM = 0;//新的静脉入量
                                            int newSumIn = 0;//新的总入量
                                            int currentoutSum = 0;//当前总出量
                                            int newoutSum = 0;//新的总出量
                                            int currentniao = 0;//尿的总量
                                            int currentdabian = 0;//大便总量
                                            int currentoutu = 0;//呕吐总量
                                            int currentxueye = 0;//渗血渗液总量 
                                            int newniao = 0;//新的尿量
                                            int newdabian = 0;//新的大便量
                                            int newoutu = 0;//新的呕吐量
                                            int newxueye = 0;//新的渗血渗液总量
                                            int currentSumyinliu = 0;//当前的引流总量
                                            int newyinliu = 0;//新的引流总量
                                            if (amount.ItemType.ToString() == "109")
                                            {

                                                //总入量
                                                if (ds.Tables[0].Rows[i]["SUM_IN"].ToString().Trim() != "")
                                                {
                                                    currentSumIn = Convert.ToInt32(ds.Tables[0].Rows[i]["SUM_IN"].ToString());
                                                    newSumIn = currentSumIn + Convert.ToInt32(amount.txtValue.Text);
                                                }
                                                //具体项入量
                                                if (amount.ItemMode.ToString() == "111")
                                                {
                                                    if (ds.Tables[0].Rows[i]["MOUTH_IN_SUM"] != null && ds.Tables[0].Rows[i]["MOUTH_IN_SUM"].ToString()!="")
                                                    cuttrntMOUTH_IN_SUM = Convert.ToInt32(ds.Tables[0].Rows[i]["MOUTH_IN_SUM"]);
                                                    newMOUTH_IN_SUM = cuttrntMOUTH_IN_SUM + Convert.ToInt32(amount.txtValue.Text);
                                                    ItemSql = "update T_INOUT_SUMM set SUM_IN=" + newSumIn.ToString() + ",MOUTH_IN_SUM=" + newMOUTH_IN_SUM.ToString() + " where ID=" + sumid + "";
                                                }
                                                else if (amount.ItemMode.ToString() == "112")
                                                {
                                                    if (ds.Tables[0].Rows[i]["PIPE_IN_SUM"] != null && ds.Tables[0].Rows[i]["PIPE_IN_SUM"].ToString()!="")
                                                    cuttrntPIPE_IN_SUM = Convert.ToInt32(ds.Tables[0].Rows[i]["PIPE_IN_SUM"]);

                                                    newPIPE_IN_SUM = cuttrntPIPE_IN_SUM + Convert.ToInt32(amount.txtValue.Text);
                                                    ItemSql = "update T_INOUT_SUMM set SUM_IN=" + newSumIn.ToString() + ",PIPE_IN_SUM=" + newPIPE_IN_SUM.ToString() + " where ID=" + sumid + "";
                                                }
                                                else if (amount.ItemMode.ToString() == "113")
                                                {
                                                    if (ds.Tables[0].Rows[i]["VEIN_IN_SUM"] != null && ds.Tables[0].Rows[i]["VEIN_IN_SUM"].ToString()!="")
                                                    cuttrntVEIN_IN_SUM = Convert.ToInt32(ds.Tables[0].Rows[i]["VEIN_IN_SUM"]);

                                                    newVEIN_IN_SUM = cuttrntVEIN_IN_SUM + Convert.ToInt32(amount.txtValue.Text);
                                                    ItemSql = "update T_INOUT_SUMM set SUM_IN=" + newSumIn.ToString() + ",VEIN_IN_SUM=" + newVEIN_IN_SUM.ToString() + " where ID=" + sumid + "";
                                                }
                                                Sqls.Add(ItemSql);
                                            }
                                            else
                                            {
                                                //总出量
                                                if (ds.Tables[0].Rows[i]["sum_out"].ToString().Trim() != "")
                                                {
                                                    currentoutSum = Convert.ToInt32(ds.Tables[0].Rows[i]["sum_out"]);

                                                    newoutSum = currentoutSum + Convert.ToInt32(amount.txtValue.Text);
                                                }
                                                if (amount.Name == "尿")
                                                {
                                                    if (ds.Tables[0].Rows[i]["urine_amount_sum"] != null && ds.Tables[0].Rows[i]["urine_amount_sum"].ToString()!="")
                                                    currentniao = Convert.ToInt32(ds.Tables[0].Rows[i]["urine_amount_sum"]);
                                                    newniao = currentniao + Convert.ToInt32(amount.txtValue.Text);
                                                    ItemSql = "update T_INOUT_SUMM set sum_out='" + newoutSum.ToString() + "',urine_amount_sum='" + newniao.ToString() + "' where ID=" + sumid + "";
                                                }
                                                else if (amount.Name == "大便")
                                                {
                                                    if (ds.Tables[0].Rows[i]["faceces_amount_sum"] != null && ds.Tables[0].Rows[i]["faceces_amount_sum"].ToString()!="")
                                                    currentdabian = Convert.ToInt32(ds.Tables[0].Rows[i]["faceces_amount_sum"]);

                                                    newdabian = currentdabian + Convert.ToInt32(amount.txtValue.Text);
                                                    ItemSql = "update T_INOUT_SUMM set sum_out='" + newoutSum.ToString() + "',faceces_amount_sum='" + newdabian.ToString() + "' where ID=" + sumid + "";
                                                }
                                                else if (amount.Name == "呕吐")
                                                {
                                                    if (ds.Tables[0].Rows[i]["vomit_amount_sum"] != null && ds.Tables[0].Rows[i]["vomit_amount_sum"].ToString()!="")
                                                    currentoutu = Convert.ToInt32(ds.Tables[0].Rows[i]["vomit_amount_sum"]);

                                                    newoutu = currentoutu + Convert.ToInt32(amount.txtValue.Text);
                                                    ItemSql = "update T_INOUT_SUMM set sum_out='" + newoutSum.ToString() + "',vomit_amount_sum='" + newoutu.ToString() + "' where ID=" + sumid + "";
                                                }
                                                else if (amount.Name == "渗血渗液")
                                                {
                                                    if (ds.Tables[0].Rows[i]["oozingandexudate_sum"] != null && ds.Tables[0].Rows[i]["oozingandexudate_sum"].ToString()!="")
                                                    currentxueye = Convert.ToInt32(ds.Tables[0].Rows[i]["oozingandexudate_sum"]);

                                                    newxueye = currentxueye + Convert.ToInt32(amount.txtValue.Text);
                                                    ItemSql = "update T_INOUT_SUMM set sum_out='" + newoutSum.ToString() + "',oozingandexudate_sum='" + newxueye.ToString() + "' where ID=" + sumid + "";
                                                }
                                                else if (amount.ItemType == "110" && amount.ItemMode == "0")
                                                {
                                                    if (ds.Tables[0].Rows[i]["drainage_amount_sum"] != null && ds.Tables[0].Rows[i]["drainage_amount_sum"].ToString()!="")
                                                    currentSumyinliu = Convert.ToInt32(ds.Tables[0].Rows[i]["drainage_amount_sum"]);

                                                    newyinliu = currentSumyinliu + Convert.ToInt32(amount.txtValue.Text);
                                                    ItemSql = "update T_INOUT_SUMM set sum_out='" + newoutSum.ToString() + "',drainage_amount_sum='" + newyinliu.ToString() + "' where ID=" + sumid + "";
                                                }
                                            }
                                            Sqls.Add(ItemSql);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (Sqls.Count > 0)
                {
                    string[] strsqls = new string[Sqls.Count];
                    for (int i = 0; i < Sqls.Count; i++)
                    {
                        strsqls[i] = Sqls[i].ToString();
                    }
                    if (App.ExecuteBatch(strsqls) > 0)
                    {
                        App.Msg("保存成功！");
                        UCAT.UcInout_Amount_Dist_Load(sender, e);
                        btnReset_Click(sender, e);
                    }
                    else
                    {
                        App.Msg("保存失败！");
                    }
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            x = 0;
            y = 0;
            Control.CheckForIllegalCrossThreadCalls = false;
            dtpCheckDate.Value = Convert.ToDateTime(App.GetSystemTime().ToString("yyyy-MM-dd HH:mm"));
            //清空Panel1里面所有的项目
            //this.panel2.Controls.Clear();
            ClearPanl(this.panel2);
            //取消树选中的check的状态为false
            RefTreeview(treeView1.Nodes);
        }
        public static void ClearPanl(Panel panel2)
        {
            panel2.Controls.Clear();
            ////添加按钮
            //panel2.Controls.Add(btncad);
            //panel2.Controls.Add(btncad4);
            //panel2.Controls.Add(btncad17);
            //panel2.Controls.Add(btncad30);
            ////button按钮不可见
            //btncad.Visible = false;
            //btncad4.Visible = false;
            //btncad17.Visible = false;
            //btncad30.Visible = false;
        }

        //private void Reflocation()
        //{
        //    x = 0;
        //    y = 0;
        //    flag = false;

        //    for (int i = 0; i < panel2.Controls.Count; i++)
        //    {
        //        if (!panel2.Controls[i].GetType().FullName.Contains("ButtonX"))
        //        {
        //            if (flag)
        //                y = y + panel2.Controls[i].Height;
        //            panel2.Controls[i].Location = new Point(x, y);
        //            flag = true;
        //        }
        //    }
        //    int b = 0;

        //    foreach (Control control in panel2.Controls)
        //    {

        //        if (!control.GetType().FullName.Contains("ButtonX"))
        //        {
        //            UcInout_AmountC useac = control as UcInout_AmountC;
        //            if (useac.Tag.ToString() == "其它4")
        //            {
        //                btncad4.Visible = true;
        //                btncad4.Location = new System.Drawing.Point(control.Location.X + 265, control.Location.Y);
        //            }
        //            if (useac.Tag.ToString() == "其它8")
        //            {
        //                btncad.Visible = true;
        //                btncad.Location = new System.Drawing.Point(control.Location.X + 265, control.Location.Y);
        //            }
        //            if (useac.Tag.ToString() == "其它17")
        //            {
        //                btncad17.Visible = true;
        //                btncad17.Location = new System.Drawing.Point(control.Location.X + 265, control.Location.Y);
        //            }
        //            if (useac.Tag.ToString() == "其它30")
        //            {
        //                btncad30.Visible = true;
        //                btncad30.Location = new System.Drawing.Point(control.Location.X + 265, control.Location.Y);
        //            }
        //        }
        //    }
        //    int c = 0;
        //    int d = 0;
        //    int e = 0;
        //    int f = 0;
        //    foreach (Control control in panel2.Controls)
        //    {
        //        if (!control.GetType().FullName.Contains("ButtonX"))
        //        {
        //            UcInout_AmountC useac = control as UcInout_AmountC;
        //            if (useac.Tag.ToString() == "其它4")
        //            {
        //                c++;
        //            }

        //            if (useac.Tag.ToString() == "其它8")
        //            {
        //                d++;
        //            }

        //            if (useac.Tag.ToString() == "其它17")
        //            {
        //                e++;
        //            }
        //            if (useac.Tag.ToString() == "其它30")
        //            {
        //                f++;
        //            }
        //        }

        //    }
        //    //判断按钮是否可见

        //    if (c == 1)
        //    {
        //        btncad4.Visible = true;
        //    }
        //    else
        //    {
        //        btncad4.Visible = false;
        //    }
        //    if (d == 1)
        //    {
        //        btncad.Visible = true;
        //    }
        //    else
        //    {
        //        btncad.Visible = false;
        //    }
        //    if (e == 1)
        //    {
        //        btncad17.Visible = true;
        //    }
        //    else
        //    {
        //        btncad17.Visible = false;
        //    }
        //    if (f == 1)
        //    {
        //        btncad30.Visible = true;
        //    }
        //    else
        //    {
        //        btncad30.Visible = false;
        //    }

        //}

        //private void btncad_Click_1(object sender, EventArgs e)
        //{
        //    addcont();
        //    Sortpanel();
        //}


        //private void btncad30_Click(object sender, EventArgs e)
        //{
        //    addcont30();
        //    Sortpanel();
        //}

        //private void btncad4_Click(object sender, EventArgs e)
        //{
        //    addcont4();
        //    Sortpanel();
        //}

        //private void btncad17_Click(object sender, EventArgs e)
        //{
        //    addcont17();
        //    Sortpanel();
        //}

        ///// <summary>
        ///// 管入
        ///// </summary>
        //public void addcont()
        //{
        //    //addpan = new Panel();
        //    //addpan.AutoSize = true;
        //    btncad.Visible = true;
        //    UcInout_AmountC ad = new UcInout_AmountC("其它", "8");
        //    ad.Tag = "管入其它";
        //    ad.EventRef += new RefPanel(Reflocation);
        //    addpan.Controls.Add(ad);
        //    ad.Focus();
        //}
        ///// <summary>
        ///// 口入
        ///// </summary>
        //public void addcont4()
        //{
        //    addpan = new Panel();
        //    addpan.AutoSize = true;
        //    btncad4.Visible = true;
        //    UcInout_AmountC ad = new UcInout_AmountC("其它", "4");
        //    ad.Tag = "口入其它";
        //    ad.EventRef += new RefPanel(Reflocation);
        //    addpan.Controls.Add(ad);
        //    ad.Focus();
        //}
        ///// <summary>
        ///// 静脉
        ///// </summary>
        //public void addcont17()
        //{
        //    addpan = new Panel();
        //    addpan.AutoSize = true;
        //    btncad17.Visible = true;
        //    UcInout_AmountC ad = new UcInout_AmountC("其它", "17");
        //    ad.Tag = "静脉其它";
        //    ad.EventRef += new RefPanel(Reflocation);
        //    addpan.Controls.Add(ad);
        //    ad.Focus();
        //}
        ///// <summary>
        ///// 引流
        ///// </summary>
        //public void addcont30()
        //{
        //    addpan = new Panel();
        //    addpan.AutoSize = true;
        //    btncad30.Visible = true;
        //    UcInout_AmountC ad = new UcInout_AmountC("其它", "30");
        //    ad.Tag = "引流其它";
        //    ad.EventRef += new RefPanel(Reflocation);
        //    addpan.Controls.Add(ad);
        //    ad.Focus();
        //}
        /// <summary>
        /// panel2中的controls排序
        /// </summary>
        //private void Sortpanel()
        //{
        //    for (int i = 0; i < addpan.Controls.Count; i++)
        //    {
        //        addpan.Controls[i].Location = new System.Drawing.Point(x, y);
        //        panel2.Controls.Add(addpan.Controls[i]);
        //        y += panel2.Controls[panel2.Controls.Count - 1].Height;
        //    }
        //    addpan.Controls.Clear();
        //    //Reflocation();
        //}
    }
}