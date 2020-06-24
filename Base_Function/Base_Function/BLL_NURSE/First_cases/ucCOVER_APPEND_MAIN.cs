using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using Microsoft.ReportingServices.ReportRendering;

namespace Base_Function.BLL_NURSE.First_cases
{
    public partial class ucCOVER_APPEND_MAIN : UserControl
    {

        ucCover_Append_In temp_in;
        ucCover_Append_OPER temp_oper;
        ucCover_Append_ANTIBIOTICS temp_antibiotics;
        ucCover_Append_GRAVE temp_grave;
        ucCover_Append_PS temp_ps;
        ucCover_Append_DROP temp_drop;

        /// <summary>
        /// 读取病人信息表病人实例
        /// </summary>
        private InPatientInfo inPatientInfo;

        public ucCOVER_APPEND_MAIN()
        {
            InitializeComponent();

            cboType.SelectedIndex = 0;
        }

        public ucCOVER_APPEND_MAIN(InPatientInfo inpatientinfo)
        {
            InitializeComponent();

            cboType.SelectedIndex = 0;
            inPatientInfo = inpatientinfo;

            IniCovers();
        }

        /// <summary>
        /// 刷新附页列表
        /// </summary>
        private void IniCovers()
        {

            #region 初始化设置
            Class_Table[] tables=new Class_Table[6]; //6
            
            //住院附页
            tables[0] = new Class_Table();
            tables[0].Sql = "select id,CREATE_TIME from COVER_APPEND_IN where PATIENT_ID="+inPatientInfo.Id.ToString()+"";
            tables[0].Tablename = "APPEND_IN";

            //手术附页
            tables[1] = new Class_Table();
            tables[1].Sql = "select id,CREATE_TIME from COVER_APPEND_OPER where PATIENT_ID="+inPatientInfo.Id.ToString()+"";
            tables[1].Tablename = "APPEND_OPER";

            //抗生素附页
            tables[2] = new Class_Table();
            tables[2].Sql = "select id,CREATE_TIME from COVER_APPEND_ANTIBIOTICS where PATIENT_ID=" + inPatientInfo.Id.ToString() + "";
            tables[2].Tablename = "APPEND_ANTIBIOTICS";

            //重症医学附页
            tables[3] = new Class_Table();
            tables[3].Sql = "select id,CREATE_TIME from COVER_APPEND_GRAVE where PATIENT_ID=" + inPatientInfo.Id.ToString() + "";
            tables[3].Tablename = "APPEND_GRAVE";

            //压疮患者附页
            tables[4] = new Class_Table();
            tables[4].Sql = "select id,create_time from COVER_APPEND_PS where patient_id=" + inPatientInfo.Id.ToString() + "";
            tables[4].Tablename = "APPEND_PS";

            //跌倒/坠床等患者附页
            tables[5] = new Class_Table();
            tables[5].Sql = "select id,create_time from COVER_APPEND_DROP where patient_id=" + inPatientInfo.Id.ToString() + "";
            tables[5].Tablename = "APPEND_DROP";

            #endregion

            #region 初始化赋值
            DataSet ds = App.GetDataSet(tables);

            List<Cls_Cover_Append> Covers = new List<Cls_Cover_Append>();

            /*
             * 初始化住院附页数据
             */
            for (int i = 0; i < ds.Tables["APPEND_IN"].Rows.Count; i++)
            {
                Cls_Cover_Append temp = new Cls_Cover_Append();
                temp.Id = ds.Tables["APPEND_IN"].Rows[i]["id"].ToString();
                temp.Cover_name = "住院病案首页附页";
                temp.Cover_time = ds.Tables["APPEND_IN"].Rows[i]["CREATE_TIME"].ToString();
                temp.Cover_type = "COVER_APPEND_IN";
                Covers.Add(temp);
            }


            /*
             * 初始化手术附页数据
             */
            for (int i = 0; i < ds.Tables["APPEND_OPER"].Rows.Count; i++)
            {
                Cls_Cover_Append temp = new Cls_Cover_Append();
                temp.Id = ds.Tables["APPEND_OPER"].Rows[i]["id"].ToString();
                temp.Cover_name = "手术操作患者附页";
                temp.Cover_time = ds.Tables["APPEND_OPER"].Rows[i]["CREATE_TIME"].ToString();
                temp.Cover_type = "COVER_APPEND_OPER";
                Covers.Add(temp);
            }

            /*
            * 初始化抗生素使用患者附页数据
            */
            for (int i = 0; i < ds.Tables["APPEND_ANTIBIOTICS"].Rows.Count; i++)
            {
                Cls_Cover_Append temp = new Cls_Cover_Append();
                temp.Id = ds.Tables["APPEND_ANTIBIOTICS"].Rows[i]["id"].ToString();
                temp.Cover_name = "抗生素使用患者附页";
                temp.Cover_time = ds.Tables["APPEND_ANTIBIOTICS"].Rows[i]["CREATE_TIME"].ToString();
                temp.Cover_type = "COVER_APPEND_ANTIBIOTICS";
                Covers.Add(temp);
            }

            /*
            * 初始化重症医学科病历附页数据
            */
            for (int i = 0; i < ds.Tables["APPEND_GRAVE"].Rows.Count; i++)
            {
                Cls_Cover_Append temp = new Cls_Cover_Append();
                temp.Id = ds.Tables["APPEND_GRAVE"].Rows[i]["id"].ToString();
                temp.Cover_name = "重症医学科病历附页";
                temp.Cover_time = ds.Tables["APPEND_GRAVE"].Rows[i]["CREATE_TIME"].ToString();
                temp.Cover_type = "COVER_APPEND_GRAVE";
                Covers.Add(temp);
            }

            /*
            * 初始化压疮患者附页数据
            */
            for (int i = 0; i < ds.Tables["APPEND_PS"].Rows.Count; i++)
            {
                Cls_Cover_Append temp = new Cls_Cover_Append();
                temp.Id = ds.Tables["APPEND_PS"].Rows[i]["id"].ToString();
                temp.Cover_name = "压疮患者附页";
                temp.Cover_time = ds.Tables["APPEND_PS"].Rows[i]["CREATE_TIME"].ToString();
                temp.Cover_type = "COVER_APPEND_PS";
                Covers.Add(temp);
            }

            /*
            * 初始化跌倒/坠床等患者附页数据
            */
            for (int i = 0; i < ds.Tables["APPEND_DROP"].Rows.Count; i++)
            {
                Cls_Cover_Append temp = new Cls_Cover_Append();
                temp.Id = ds.Tables["APPEND_DROP"].Rows[i]["id"].ToString();
                temp.Cover_name = "跌倒/坠床等患者附页";
                temp.Cover_time = ds.Tables["APPEND_DROP"].Rows[i]["CREATE_TIME"].ToString();
                temp.Cover_type = "COVER_APPEND_DROP";
                Covers.Add(temp);
            }


            #endregion
            

            //将数据显示在列表中   
            dataGvAppendPages.DataSource = Covers;
            dataGvAppendPages.Columns["Id"].Visible = false;
            dataGvAppendPages.Columns["Cover_name"].HeaderText = "附页名称";
            dataGvAppendPages.Columns["Cover_time"].HeaderText = "创建时间";
            dataGvAppendPages.Columns["Cover_type"].Visible = false;
            dataGvAppendPages.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dataGvAppendPages.Refresh();                       
        }

        /// <summary>
        /// 删除当前选中的附页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("是否确认删除当前选中的附页？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                string[] sqls = new string[dataGvAppendPages.SelectedRows.Count];
                int index=0;
                foreach (DataGridViewRow gdvr in dataGvAppendPages.SelectedRows)
                {
                    string cover_id = gdvr.Cells["ID"].Value.ToString();//获取此行ID值                    
                    string cover_type = gdvr.Cells["Cover_type"].Value.ToString();//表名
                    string sql = "delete from {0} where id={1}";
                    sqls[index] = string.Format(sql, cover_type, cover_id);
                    index++;
                }
                
                if (App.ExecuteBatch(sqls) > 0)
                {
                    App.Msg("删除成功!");
                }
                else
                {
                    App.Msg("删除失败!");
                }
            }
            catch (Exception ex)
            {
                App.MsgErr("操作失败,原因:" + ex.Message);
            }
            finally 
            {
                IniCovers();
                groupPanel7.Controls.Clear();
            }
        }

       

        /// <summary>
        /// 添加附页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddAppendPage_Click(object sender, EventArgs e)
        {
            groupPanel7.Controls.Clear();
            if (cboType.SelectedIndex == 0)
            {
                if (GetSelectItemId("COVER_APPEND_IN", inPatientInfo.Id.ToString()) == false)
                {
                    //住院附页
                    temp_in = new ucCover_Append_In(inPatientInfo.Id.ToString());
                    App.UsControlStyle(temp_in);
                    // temp1.Dock = DockStyle.Fill;
                    temp_in.BackColor = System.Drawing.Color.Transparent;
                    groupPanel7.Controls.Add(temp_in);
                }
                
            }
            else if (cboType.SelectedIndex == 1)
            {
                //手术附页
                temp_oper = new ucCover_Append_OPER(inPatientInfo.Id.ToString());
                App.UsControlStyle(temp_oper);
                //temp1.Dock = DockStyle.Fill;
                temp_oper.BackColor = System.Drawing.Color.Transparent;
                groupPanel7.Controls.Add(temp_oper);
            }
            else if (cboType.SelectedIndex == 2)
            {//抗生素使用患者附页
                //if (GetSelectItemId("COVER_APPEND_ANTIBIOTICS", inPatientInfo.Id.ToString()) == false)
                //{
                    temp_antibiotics = new ucCover_Append_ANTIBIOTICS(inPatientInfo.Id.ToString());
                    App.UsControlStyle(temp_antibiotics);
                    temp_antibiotics.BackColor = System.Drawing.Color.Transparent;
                    groupPanel7.Controls.Add(temp_antibiotics);
                //}
            }
            else if (cboType.SelectedIndex == 3)
            {//重症医学科病历附页
                temp_grave = new ucCover_Append_GRAVE(inPatientInfo.Id.ToString());
                App.UsControlStyle(temp_grave);
                temp_grave.BackColor = System.Drawing.Color.Transparent;
                groupPanel7.Controls.Add(temp_grave);
            }
            else if (cboType.SelectedIndex == 4)
            {//压疮与坠床/跌倒附页
                if (GetSelectItemId("COVER_APPEND_PS", inPatientInfo.Id.ToString()) == false)
                {
                    temp_ps = new ucCover_Append_PS(inPatientInfo.Id.ToString());
                    App.UsControlStyle(temp_ps);
                    temp_ps.BackColor = System.Drawing.Color.Transparent;
                    groupPanel7.Controls.Add(temp_ps);
                }
            }
            else if (cboType.SelectedIndex == 5)
            {//坠床/跌倒附页
                if (GetSelectItemId("COVER_APPEND_DROP", inPatientInfo.Id.ToString()) == false)
                {
                    temp_drop = new ucCover_Append_DROP(inPatientInfo.Id.ToString());
                    App.UsControlStyle(temp_drop);
                    temp_drop.BackColor = System.Drawing.Color.Transparent;
                    groupPanel7.Controls.Add(temp_drop);
                }
            }

           
        }

        /// <summary>
        /// 是否存在这个附页
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="pid">病人ID</param>
        /// <returns></returns>
        private bool GetSelectItemId(string tablename,string pid)
        {
            try
            {
                string Sql = "select count(*) as num from " + tablename + "  where PATIENT_ID ='" + pid + "'";
                string num = App.ReadSqlVal(Sql, 0, "num");
                if (num != "")
                {
                    if (num == "0")
                    {
                        //无
                        return false;
                    }
                    else
                    {
                        //有
                        App.Msg("已经存在相同的附页,请勿重复添加!");
                        return true;
                    }
                }
                else
                {
                    return true;
                }

            }
            catch (Exception)
            {
                return true;
            }
        }

        /// <summary>
        /// 保存方法
        /// </summary>
        public void SaveConver()
        {
            bool b = true;
            if (cboType.SelectedIndex == 0)
            {//住院附页
                b=temp_in.SaveData();
                
            }
            else if (cboType.SelectedIndex == 1)
            {//手术操作患者附页
                b = temp_oper.SaveData();
            }
            else if (cboType.SelectedIndex == 2)
            {//抗生素使用患者附页
                b = temp_antibiotics.SaveData();
            }
            else if (cboType.SelectedIndex == 3)
            {//重症医学科病历附页
                b = temp_grave.SaveData();
            }
            else if (cboType.SelectedIndex == 4)
            {//压疮和坠床/跌倒附页
                b = temp_ps.SaveData();
            }
            else if (cboType.SelectedIndex == 5)
            {//压疮和坠床/跌倒附页
                b = temp_drop.SaveData();
            }
            if (b==true)
            {
                IniCovers();
                groupPanel7.Controls.Clear();
            }
            
        }

        /// <summary>
        /// 双击列表显示对应的附页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGvAppendPages_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {


                string cover_id = dataGvAppendPages["Id", dataGvAppendPages.CurrentRow.Index].Value.ToString();
                string cover_type = dataGvAppendPages["Cover_type", dataGvAppendPages.CurrentRow.Index].Value.ToString();

                groupPanel7.Controls.Clear();
                if (cover_type == "COVER_APPEND_IN")
                {
                    //住院附页
                    cboType.SelectedIndex = 0;
                    temp_in = new ucCover_Append_In(inPatientInfo.Id.ToString(), cover_id);
                    App.UsControlStyle(temp_in);
                    // temp1.Dock = DockStyle.Fill;
                    temp_in.BackColor = System.Drawing.Color.Transparent;
                    groupPanel7.Controls.Add(temp_in);
                }
                else if (cover_type == "COVER_APPEND_OPER")
                {
                    //手术附页
                    cboType.SelectedIndex = 1;                   
                    temp_oper = new ucCover_Append_OPER(inPatientInfo.Id.ToString(), cover_id);
                    //App.UsControlStyle(temp_oper);
                    //temp1.Dock = DockStyle.Fill;
                    temp_oper.BackColor = System.Drawing.Color.Transparent;
                    groupPanel7.Controls.Add(temp_oper);
                }
                else if (cover_type == "COVER_APPEND_ANTIBIOTICS")
                {//抗生素使用患者附页
                    cboType.SelectedIndex = 2;
                    temp_antibiotics = new ucCover_Append_ANTIBIOTICS(inPatientInfo.Id.ToString(), cover_id);
                    App.UsControlStyle(temp_antibiotics);
                    //temp1.Dock = DockStyle.Fill;
                    temp_antibiotics.BackColor = System.Drawing.Color.Transparent;
                    groupPanel7.Controls.Add(temp_antibiotics);
                }
                else if (cover_type == "COVER_APPEND_GRAVE")
                {//重症医学科病历附页 
                    cboType.SelectedIndex = 3;
                    temp_grave = new ucCover_Append_GRAVE(inPatientInfo.Id.ToString(), cover_id);
                    //App.UsControlStyle(temp_grave);
                    //temp1.Dock = DockStyle.Fill;
                    temp_grave.BackColor = System.Drawing.Color.Transparent;
                    groupPanel7.Controls.Add(temp_grave);
                }
                else if (cover_type == "COVER_APPEND_PS")
                {//压疮和坠床/跌倒附页 
                    cboType.SelectedIndex = 4;
                    temp_ps = new ucCover_Append_PS(inPatientInfo.Id.ToString(), cover_id);
                    //App.UsControlStyle(temp_grave);
                    //temp1.Dock = DockStyle.Fill;
                    temp_ps.BackColor = System.Drawing.Color.Transparent;
                    groupPanel7.Controls.Add(temp_ps);
                }
                else if (cover_type == "COVER_APPEND_DROP")
                {//压疮和坠床/跌倒附页 
                    cboType.SelectedIndex = 5;
                    temp_drop = new ucCover_Append_DROP(inPatientInfo.Id.ToString(), cover_id);
                    //App.UsControlStyle(temp_grave);
                    //temp1.Dock = DockStyle.Fill;
                    temp_drop.BackColor = System.Drawing.Color.Transparent;
                    groupPanel7.Controls.Add(temp_drop);
                }

            }
            catch
            {
                App.MsgWaring("请先选择要操作的记录!");
            }
        }

        private void button1_Click(object sender, EventArgs e)  //向上移动
        {
            int rowIndex = dataGvAppendPages.SelectedRows[0].Index;  //得到当前选中行的索引

            if (rowIndex == 0)
            {
                App.Msg("已经是第一行了!");
                return;
            }

            List<string> list = new List<string>();
            for (int i = 0; i < dataGvAppendPages.Columns.Count; i++)
            {
                list.Add(dataGvAppendPages.SelectedRows[0].Cells[i].Value.ToString());   //把当前选中行的数据存入list数组中
            }

            for (int j = 0; j < dataGvAppendPages.Columns.Count; j++)
            {
                dataGvAppendPages.Rows[rowIndex].Cells[j].Value = dataGvAppendPages.Rows[rowIndex - 1].Cells[j].Value;
                dataGvAppendPages.Rows[rowIndex - 1].Cells[j].Value = list[j].ToString();
            }
            dataGvAppendPages.Rows[rowIndex - 1].Selected = true;
            dataGvAppendPages.Rows[rowIndex].Selected = false;
        }

        private void button2_Click(object sender, EventArgs e)  //向下移动
        {
            int rowIndex = dataGvAppendPages.SelectedRows[0].Index;  //得到当前选中行的索引

            if (rowIndex == dataGvAppendPages.Rows.Count - 1)
            {
                App.Msg("已经是最后一行了!");
                return;
            }

            List<string> list = new List<string>();
            for (int i = 0; i < dataGvAppendPages.Columns.Count; i++)
            {
                list.Add(dataGvAppendPages.SelectedRows[0].Cells[i].Value.ToString());   //把当前选中行的数据存入list数组中
            }

            for (int j = 0; j < dataGvAppendPages.Columns.Count; j++)
            {
                dataGvAppendPages.Rows[rowIndex].Cells[j].Value = dataGvAppendPages.Rows[rowIndex + 1].Cells[j].Value;
                dataGvAppendPages.Rows[rowIndex + 1].Cells[j].Value = list[j].ToString();
            }
            dataGvAppendPages.Rows[rowIndex + 1].Selected = true;
            dataGvAppendPages.Rows[rowIndex].Selected = false;
        }


    }

    /// <summary>
    /// 附页对象
    /// </summary>
    public class Cls_Cover_Append
    {
        /// <summary>
        /// 附页主键
        /// </summary>
        private string id;
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// 附页名称
        /// </summary>
        private string cover_name;
        public string Cover_name
        {
            get { return cover_name; }
            set { cover_name = value; }
        }

        /// <summary>
        /// 附页创建时间
        /// </summary>
        private string cover_time;
        public string Cover_time
        {
            get { return cover_time; }
            set { cover_time = value; }
        }

        /// <summary>
        /// 附页类型
        /// </summary>
        private string cover_type;
        public string Cover_type
        {
            get { return cover_type; }
            set { cover_type = value; }
        }

    }


}
