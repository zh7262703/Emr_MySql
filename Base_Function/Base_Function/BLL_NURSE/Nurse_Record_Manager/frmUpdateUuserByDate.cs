using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BLL_NURSE.Nurse_Record_Manager
{
    public partial class frmUpdateUuserByDate : DevComponents.DotNetBar.Office2007Form
    {
        private string Date = null;
        private StringBuilder strBuilder = new StringBuilder();
        public bool IsSuccess = false; //操作是否成功

        string ItemVal = "";  //当前操作的记录的值
        string ItemCode = ""; //当前操作记录的代码
        string RecodeTime = ""; //项目记录时间
        

        public frmUpdateUuserByDate()
        {
            InitializeComponent();
        }
        public frmUpdateUuserByDate(string date)
        {
            InitializeComponent();
            this.Date = date;
        }
        DataTable dt = null;
        DataSet ds = null;
        string pID = "";
        string dateTimes;
        public void SetPID(string pid, string dateTime)
        {
            this.pID = pid;
            this.dateTimes = dateTime;
        }
        private void frmUpdateUuserByDate_Load(object sender, EventArgs e)
        {
            this.btnOk.Enabled = false;
            if (Date != null)
            {
                string sql = " select a.id,a.item_code,a.item_name 项目名称,a.item_value 项目值,to_char(a.record_time,'yyyy-MM-dd hh24:mi') 时间,b.ITEM_TYPE 类型,b.ITEM_MODE 模式 from  t_inout_amount_record a" +
                        " inner join  t_inout_amount_dict b on a.item_code=b.id" +
                        " where to_char(a.record_time,'yyyy-MM-dd hh24:mi')='" + Date + "'";
                ds = App.GetDataSet(sql);
                if (ds != null)
                {
                    dt = ds.Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        flgGrid.DataSource = dt.DefaultView;
                        flgGrid.Cols["item_code"].Visible = false;
                        flgGrid.Cols["id"].Visible = false;
                        lblName.Text = flgGrid[flgGrid.RowSel, "项目名称"].ToString();
                        txtValue.Text = flgGrid[flgGrid.RowSel, "项目值"].ToString();
                        dtpTime.Text = flgGrid[flgGrid.RowSel, "时间"].ToString();
                    }
                }
            }
        }

        private void flgGrid_Click(object sender, EventArgs e)
        {
            lblName.Text = flgGrid[flgGrid.RowSel, "项目名称"].ToString();
            txtValue.Text = flgGrid[flgGrid.RowSel, "项目值"].ToString();
            dtpTime.Value =Convert.ToDateTime(flgGrid[flgGrid.RowSel, "时间"].ToString());
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Setflgview()
        {
            ItemVal = flgGrid[flgGrid.RowSel, "项目值"].ToString();
            ItemCode = flgGrid[flgGrid.RowSel, "item_code"].ToString();
            RecodeTime = flgGrid[flgGrid.RowSel, "时间"].ToString();

            string ItemName = flgGrid[flgGrid.RowSel, "项目名称"].ToString();
            string ItemType = flgGrid[flgGrid.RowSel, "类型"].ToString();
            string ItemMode = flgGrid[flgGrid.RowSel, "模式"].ToString();

            string Sql = "select * from t_inout_summ t where PATIENT_ID='" + this.pID + "' and to_char(start_time,'yyyy-MM-dd hh24:mi')<='" + RecodeTime + "' and  '" + RecodeTime + "'<=to_char(end_time,'yyyy-MM-dd hh24:mi')";
            DataSet ds = App.GetDataSet(Sql);

            ArrayList Sqls = new ArrayList();

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
                if (ItemType == "109")
                {

                    //总入量
                    if (ds.Tables[0].Rows[i]["SUM_IN"].ToString().Trim() != "")
                    {
                        currentSumIn = Convert.ToInt32(ds.Tables[0].Rows[i]["SUM_IN"].ToString());
                        if (ItemVal.Trim() == "")
                        {
                            ItemVal = "0";
                        }
                        newSumIn = currentSumIn - Convert.ToInt32(ItemVal) + Convert.ToInt32(txtValue.Text);
                    }
                    //具体项入量
                    if (ItemMode == "111")
                    {
                        cuttrntMOUTH_IN_SUM = Convert.ToInt32(ds.Tables[0].Rows[i]["MOUTH_IN_SUM"].ToString());
                        if (ItemVal.Trim() == "")
                        {
                            ItemVal = "0";
                        }
                        newMOUTH_IN_SUM = cuttrntMOUTH_IN_SUM - Convert.ToInt32(ItemVal) + Convert.ToInt32(txtValue.Text);
                        ItemSql = "update T_INOUT_SUMM set SUM_IN=" + newSumIn.ToString() + ",MOUTH_IN_SUM=" + newMOUTH_IN_SUM.ToString() + " where ID=" + sumid + "";
                    }
                    else if (ItemMode == "112")
                    {
                        cuttrntPIPE_IN_SUM = Convert.ToInt32(ds.Tables[0].Rows[i]["PIPE_IN_SUM"].ToString());
                        if (ItemVal.Trim() == "")
                        {
                            ItemVal = "0";
                        }
                        newPIPE_IN_SUM = cuttrntPIPE_IN_SUM - Convert.ToInt32(ItemVal) + Convert.ToInt32(txtValue.Text);
                        ItemSql = "update T_INOUT_SUMM set SUM_IN=" + newSumIn.ToString() + ",PIPE_IN_SUM=" + newPIPE_IN_SUM.ToString() + " where ID=" + sumid + "";
                    }
                    else if (ItemMode == "113")
                    {
                        cuttrntVEIN_IN_SUM = Convert.ToInt32(ds.Tables[0].Rows[i]["VEIN_IN_SUM"].ToString());
                        if (ItemVal.Trim() == "")
                        {
                            ItemVal = "0";
                        }
                        newVEIN_IN_SUM = cuttrntVEIN_IN_SUM - Convert.ToInt32(ItemVal) + Convert.ToInt32(txtValue.Text);
                        ItemSql = "update T_INOUT_SUMM set SUM_IN=" + newSumIn.ToString() + ",VEIN_IN_SUM=" + newVEIN_IN_SUM.ToString() + " where ID=" + sumid + "";
                    }
                    Sqls.Add(ItemSql);
                }
                else
                {
                    //总出量
                    if (ds.Tables[0].Rows[i]["sum_out"].ToString().Trim() != "")
                    {
                        currentoutSum = Convert.ToInt32(ds.Tables[0].Rows[i]["sum_out"].ToString());
                        if (ItemVal.Trim() == "")
                        {
                            ItemVal = "0";
                        }
                        newoutSum = currentoutSum - Convert.ToInt32(ItemVal) + Convert.ToInt32(txtValue.Text);
                    }
                    if (ItemName == "尿")
                    {
                        //currentoutSum = Convert.ToInt32(ds.Tables[0].Rows[i]["sum_out"].ToString());
                        currentniao = Convert.ToInt32(ds.Tables[0].Rows[i]["urine_amount_sum"].ToString());
                        //newoutSum=currentoutSum-Convert.ToInt32(ItemVal);
                        if (ItemVal.Trim() == "")
                        {
                            ItemVal = "0";
                        }
                        newniao = currentniao - Convert.ToInt32(ItemVal) + Convert.ToInt32(txtValue.Text);
                        ItemSql = "update T_INOUT_SUMM set sum_out='" + newoutSum.ToString() + "',urine_amount_sum='" + newniao.ToString() + "' where ID=" + sumid + "";
                    }
                    else if (ItemName == "大便")
                    {
                        //currentoutSum = Convert.ToInt32(ds.Tables[0].Rows[i]["sum_out"].ToString());
                        currentdabian = Convert.ToInt32(ds.Tables[0].Rows[i]["faceces_amount_sum"].ToString());
                        //newoutSum = currentoutSum - Convert.ToInt32(ItemVal);
                        if (ItemVal.Trim() == "")
                        {
                            ItemVal = "0";
                        }
                        newdabian = currentdabian - Convert.ToInt32(ItemVal) + Convert.ToInt32(txtValue.Text);
                        ItemSql = "update T_INOUT_SUMM set sum_out='" + newoutSum.ToString() + "',faceces_amount_sum='" + newdabian.ToString() + "' where ID=" + sumid + "";
                    }
                    else if (ItemName == "呕吐")
                    {
                        //currentoutSum = Convert.ToInt32(ds.Tables[0].Rows[i]["sum_out"].ToString());
                        currentoutu = Convert.ToInt32(ds.Tables[0].Rows[i]["vomit_amount_sum"].ToString());
                        //newoutSum = currentoutSum - Convert.ToInt32(ItemVal);
                        if (ItemVal.Trim() == "")
                        {
                            ItemVal = "0";
                        }
                        newoutu = currentoutu - Convert.ToInt32(ItemVal) + Convert.ToInt32(txtValue.Text);
                        ItemSql = "update T_INOUT_SUMM set sum_out='" + newoutSum.ToString() + "',vomit_amount_sum='" + newoutu.ToString() + "' where ID=" + sumid + "";
                    }
                    else if (ItemName == "渗血渗液")
                    {
                        //currentoutSum = Convert.ToInt32(ds.Tables[0].Rows[i]["sum_out"].ToString());
                        currentxueye = Convert.ToInt32(ds.Tables[0].Rows[i]["oozingandexudate_sum"].ToString());
                        //newoutSum = currentoutSum - Convert.ToInt32(ItemVal);
                        if (ItemVal.Trim() == "")
                        {
                            ItemVal = "0";
                        }
                        newxueye = currentxueye - Convert.ToInt32(ItemVal) + Convert.ToInt32(txtValue.Text);
                        ItemSql = "update T_INOUT_SUMM set sum_out='" + newoutSum.ToString() + "',oozingandexudate_sum='" + newxueye.ToString() + "' where ID=" + sumid + "";
                    }
                    else if (ItemType == "110" && ItemMode == "0")
                    {
                        currentSumyinliu = Convert.ToInt32(ds.Tables[0].Rows[i]["drainage_amount_sum"].ToString());
                        if (ItemVal.Trim() == "")
                        {
                            ItemVal = "0";
                        }
                        newyinliu = currentSumyinliu - Convert.ToInt32(ItemVal) + Convert.ToInt32(txtValue.Text);
                        ItemSql = "update T_INOUT_SUMM set sum_out='" + newoutSum.ToString() + "',drainage_amount_sum='" + newyinliu.ToString() + "' where ID=" + sumid + "";
                    }
                }
                Sqls.Add(ItemSql);
            }
            string[] strsqls = new string[Sqls.Count];
            for (int i = 0; i < Sqls.Count; i++)
            {
                strsqls[i] = Sqls[i].ToString();
            }
            App.ExecuteBatch(strsqls);
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (strBuilder.Length > 0)
            {
                string[] arrs = strBuilder.ToString().Substring(0, strBuilder.Length - 1).Split('.');
                int count = App.ExecuteBatch(arrs);
                if (count > 0)
                {
                    Setflgview();
                    IsSuccess = true;

                    App.Msg("修改成功！");
                }
            }
            this.Close();
        }
        private void tsmtDelete_Click(object sender, EventArgs e)
        {
            //string sql = "Update t_inout_summ set vein_in_sum =vein_in_sum -'" + this.flgGrid[this.flgGrid.RowSel, "项目值"] + "' where pid = '" + this.pID + "' And to_char(calc_date,'yyyy-MM-dd hh24:mi')='" + dateTimes + "'";   //pid,calc_date,
            string sql = "delete t_inout_amount_record where item_name='" + flgGrid[flgGrid.RowSel, "项目名称"] + "' and to_char(record_time,'yyyy-MM-dd hh24:mi')='" + flgGrid[flgGrid.RowSel, "时间"] + "'and  PATIENT_ID=" + pID + "";

            int count = App.ExecuteSQL(sql);
            if (count > 0)
            {

                ItemVal = flgGrid[flgGrid.RowSel, "项目值"].ToString();//要删除或修改的项目的值 123
                ItemCode = flgGrid[flgGrid.RowSel, "item_code"].ToString();//要删除或修改的项目的编码 28
                RecodeTime = flgGrid[flgGrid.RowSel, "时间"].ToString();//要删除或修改的项目的时间 2010-07-21 10:20

                string ItemName = flgGrid[flgGrid.RowSel, "项目名称"].ToString();//要删除或修改的项目的名称 皮下引流
                string ItemType = flgGrid[flgGrid.RowSel, "类型"].ToString();//要删除或修改的项目的类型 110
                string ItemMode = flgGrid[flgGrid.RowSel, "模式"].ToString();//要删除或修改的项目的模式 0

                string Sql = "select * from t_inout_summ t where PATIENT_ID='" + this.pID + "' and to_char(start_time,'yyyy-MM-dd hh24:mi')<='" + RecodeTime + "' and  '" + RecodeTime + "'<=to_char(end_time,'yyyy-MM-dd hh24:mi')";
                DataSet ds = App.GetDataSet(Sql);

                ArrayList Sqls = new ArrayList();

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
                    if (ItemType == "109")
                    {

                        //总入量
                        if (ds.Tables[0].Rows[i]["SUM_IN"].ToString().Trim() != "")
                        {
                            currentSumIn = Convert.ToInt32(ds.Tables[0].Rows[i]["SUM_IN"].ToString());
                            if (ItemVal.Trim() == "")
                            {
                                ItemVal = "0";
                            }
                            newSumIn = currentSumIn - Convert.ToInt32(ItemVal);
                        }


                        //具体项入量
                        if (ItemMode == "111")
                        {
                            cuttrntMOUTH_IN_SUM = Convert.ToInt32(ds.Tables[0].Rows[i]["MOUTH_IN_SUM"].ToString());
                            if (ItemVal.Trim() == "")
                            {
                                ItemVal = "0";
                            }
                            newMOUTH_IN_SUM = cuttrntMOUTH_IN_SUM - Convert.ToInt32(ItemVal);
                            ItemSql = "update T_INOUT_SUMM set SUM_IN=" + newSumIn.ToString() + ",MOUTH_IN_SUM=" + newMOUTH_IN_SUM.ToString() + " where ID=" + sumid + "";
                        }
                        else if (ItemMode == "112")
                        {
                            cuttrntPIPE_IN_SUM = Convert.ToInt32(ds.Tables[0].Rows[i]["PIPE_IN_SUM"].ToString());
                            if (ItemVal.Trim() == "")
                            {
                                ItemVal = "0";
                            }
                            newPIPE_IN_SUM = cuttrntPIPE_IN_SUM - Convert.ToInt32(ItemVal);
                            ItemSql = "update T_INOUT_SUMM set SUM_IN=" + newSumIn.ToString() + ",PIPE_IN_SUM=" + newPIPE_IN_SUM.ToString() + " where ID=" + sumid + "";
                        }
                        else if (ItemMode == "113")
                        {
                            cuttrntVEIN_IN_SUM = Convert.ToInt32(ds.Tables[0].Rows[i]["VEIN_IN_SUM"].ToString());
                            if (ItemVal.Trim() == "")
                            {
                                ItemVal = "0";
                            }
                            newVEIN_IN_SUM = cuttrntVEIN_IN_SUM - Convert.ToInt32(ItemVal);
                            ItemSql = "update T_INOUT_SUMM set SUM_IN=" + newSumIn.ToString() + ",VEIN_IN_SUM=" + newVEIN_IN_SUM.ToString() + " where ID=" + sumid + "";
                        }

                        Sqls.Add(ItemSql);
                    }
                    else
                    {
                        //总出量

                        if (ds.Tables[0].Rows[i]["sum_out"].ToString().Trim() != "")
                        {
                            currentoutSum = Convert.ToInt32(ds.Tables[0].Rows[i]["sum_out"].ToString());
                            if (ItemVal.Trim() == "")
                            {
                                ItemVal = "0";
                            }
                            newoutSum = currentoutSum - Convert.ToInt32(ItemVal);
                        }
                        if (ItemName == "尿")
                        {
                            //currentoutSum = Convert.ToInt32(ds.Tables[0].Rows[i]["sum_out"].ToString());
                            currentniao = Convert.ToInt32(ds.Tables[0].Rows[i]["urine_amount_sum"].ToString());
                            //newoutSum=currentoutSum-Convert.ToInt32(ItemVal);
                            if (ItemVal.Trim() == "")
                            {
                                ItemVal = "0";
                            }
                            newniao = currentniao - Convert.ToInt32(ItemVal);
                            ItemSql = "update T_INOUT_SUMM set sum_out='" + newoutSum.ToString() + "',urine_amount_sum='" + newniao.ToString() + "' where ID=" + sumid + "";
                        }
                        else if (ItemName == "大便")
                        {
                            //currentoutSum = Convert.ToInt32(ds.Tables[0].Rows[i]["sum_out"].ToString());
                            currentdabian = Convert.ToInt32(ds.Tables[0].Rows[i]["faceces_amount_sum"].ToString());
                            //newoutSum = currentoutSum - Convert.ToInt32(ItemVal);
                            if (ItemVal.Trim() == "")
                            {
                                ItemVal = "0";
                            }
                            newdabian = currentdabian - Convert.ToInt32(ItemVal);
                            ItemSql = "update T_INOUT_SUMM set sum_out='" + newoutSum.ToString() + "',faceces_amount_sum='" + newdabian.ToString() + "' where ID=" + sumid + "";
                        }
                        else if (ItemName == "呕吐")
                        {
                            //currentoutSum = Convert.ToInt32(ds.Tables[0].Rows[i]["sum_out"].ToString());
                            currentoutu = Convert.ToInt32(ds.Tables[0].Rows[i]["vomit_amount_sum"].ToString());
                            //newoutSum = currentoutSum - Convert.ToInt32(ItemVal);
                            if (ItemVal.Trim() == "")
                            {
                                ItemVal = "0";
                            }
                            newoutu = currentoutu - Convert.ToInt32(ItemVal);
                            ItemSql = "update T_INOUT_SUMM set sum_out='" + newoutSum.ToString() + "',vomit_amount_sum='" + newoutu.ToString() + "' where ID=" + sumid + "";
                        }
                        else if (ItemName == "渗血渗液")
                        {
                            //currentoutSum = Convert.ToInt32(ds.Tables[0].Rows[i]["sum_out"].ToString());
                            currentxueye = Convert.ToInt32(ds.Tables[0].Rows[i]["oozingandexudate_sum"].ToString());
                            //newoutSum = currentoutSum - Convert.ToInt32(ItemVal);
                            if (ItemVal.Trim() == "")
                            {
                                ItemVal = "0";
                            }
                            newxueye = currentxueye - Convert.ToInt32(ItemVal);
                            ItemSql = "update T_INOUT_SUMM set sum_out='" + newoutSum.ToString() + "',oozingandexudate_sum='" + newxueye.ToString() + "' where ID=" + sumid + "";
                        }
                        else if (ItemType == "110" && ItemMode=="0")
                        {
                            currentSumyinliu = Convert.ToInt32(ds.Tables[0].Rows[i]["drainage_amount_sum"].ToString());
                            if (ItemVal.Trim() == "")
                            {
                                ItemVal = "0";
                            }
                            newyinliu = currentSumyinliu - Convert.ToInt32(ItemVal);
                            ItemSql = "update T_INOUT_SUMM set sum_out='" + newoutSum.ToString() + "',drainage_amount_sum='"+newyinliu.ToString()+"'  where ID=" + sumid + "";
                        }
                    }
                    Sqls.Add(ItemSql);
                }
                string[] strsqls = new string[Sqls.Count];
                for (int i = 0; i < Sqls.Count; i++)
                {
                    strsqls[i] = Sqls[i].ToString();
                }
                App.ExecuteBatch(strsqls);
                IsSuccess = true;
                flgGrid.Rows.Remove(flgGrid.RowSel);
            }
        }
        private void txtValue_Leave(object sender, EventArgs e)
        {
             //btnOk.Enabled = false;
            if (flgGrid[flgGrid.RowSel, "项目值"].ToString() != txtValue.Text.Trim())
            {
                int num = -1;
                int.TryParse(txtValue.Text, out num);
                if (txtValue.Text != "" && num > 0)
                {
                    string sql = "update t_inout_amount_record set item_value='" + txtValue.Text + "'" +
                                 " where id='" + flgGrid[flgGrid.RowSel, "id"] + "' " +
                                 " and to_char(record_time,'yyyy-MM-dd hh24:mi')='" + flgGrid[flgGrid.RowSel, "时间"] + "'and PATIENT_ID='" + pID + "'";
                    strBuilder.Append(sql + ".");
                }
                else
                {
                    App.Msg("请输入大于零的数字！");
                }
            }
        }
        //private void txtValue_TextChanged(object sender, EventArgs e)
        //{
        //    btnOk.Enabled = true;
        //}

        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            btnOk.Enabled = true;
        }

        
    }
}