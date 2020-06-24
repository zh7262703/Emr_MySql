using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using System.Collections;
using System.Threading;
using DevComponents.DotNetBar;
using Base_Function.BASE_COMMON;
using QualityControl;
using Base_Function.BLL_MANAGEMENT.NURSE_MANAGE;
//using Bifrost_ThreadManagement.WebReference;

namespace Base_Function.BLL_MANAGEMENT
{
    public partial class ucUCEParam : UserControl
    {
        private DataTable dataTable;
        private DataRow newrow;
        private string sqlflag = "select * from QUALITY_VAR_HLB_VIEW";
       
     

        Hashtable mapItemToQualitys = new Hashtable();
        Class_Quality_Var_HLB chp = new Class_Quality_Var_HLB();        
        Class_Quality_HLB_View[] qhv;
        private ArrayList tempList = new ArrayList();

        DataSet dsTemperature = App.GetDataSet("select * from T_TEMPERATURE_MONITORING");//体温监测
        bool flagTemperature = false;
        Class_Temperature_Monitoring ctm = new Class_Temperature_Monitoring();
        
        DataSet CBO_DS;// 初始化下拉列表框数据集

        bool updateFlag = false;

        public ucUCEParam()
        {           
            InitializeComponent();
            try
            {
                InitCombobox();
                //延安妇幼屏蔽老版质控
                //QualityView();
            }
            catch
            { }
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitCombobox()
        {
           
            Class_Table[] cboTables = new Class_Table[4];

            //初始化文书类型
            cboTables[0] = new Class_Table();
            cboTables[0].Sql = "select * from t_data_code ta where ta.type=18 and ta.name in('体温单','体温单其他')";//,'危重护理记录'
            cboTables[0].Tablename = "TextKind";

            //监控患者类型
            cboTables[1] = new Class_Table();
            cboTables[1].Sql = "select * from t_data_code where type=27";
            cboTables[1].Tablename = "MonitorType";

            //参考时间
            cboTables[2] = new Class_Table();
            cboTables[2].Sql = "select * from t_data_code where type=28 and enable='Y'";
            cboTables[2].Tablename = "CKTime";

            //监控子项
            cboTables[3] = new Class_Table();
            cboTables[3].Sql = "select * from t_data_code where type=29 and enable='Y'";
            cboTables[3].Tablename = "Monitoring";

            CBO_DS = App.GetDataSet(cboTables);

            //初始化文书类型
            dataTable = CBO_DS.Tables["TextKind"];
            newrow = dataTable.NewRow();
            newrow[1] = "请选择...";
            dataTable.Rows.InsertAt(newrow, 0);
            this.cboTextKind.DataSource = CBO_DS.Tables["TextKind"].DefaultView;
            this.cboTextKind.ValueMember = "ID";
            this.cboTextKind.DisplayMember = "Name";

            //监控子项           
            dataTable = CBO_DS.Tables["Monitoring"];
            newrow = dataTable.NewRow();
            newrow[1] = "请选择...";
            dataTable.Rows.InsertAt(newrow, 0);
            this.cboMonitoring.DataSource = CBO_DS.Tables["Monitoring"].DefaultView;
            this.cboMonitoring.ValueMember = "ID";
            this.cboMonitoring.DisplayMember = "Name";

            //监控患者类型
            dataTable = CBO_DS.Tables["MonitorType"];
            newrow = dataTable.NewRow();
            newrow[1] = "请选择...";
            dataTable.Rows.InsertAt(newrow, 0);
            this.cboMonitorType.DataSource = CBO_DS.Tables["MonitorType"].DefaultView;
            this.cboMonitorType.ValueMember = "ID";
            this.cboMonitorType.DisplayMember = "Name";

            //参考时间
            dataTable = CBO_DS.Tables["CKTime"];
            newrow = dataTable.NewRow();
            newrow[1] = "请选择...";
            dataTable.Rows.InsertAt(newrow, 0);
            this.cboCKTime.DataSource = CBO_DS.Tables["CKTime"].DefaultView;
            this.cboCKTime.ValueMember = "ID";
            this.cboCKTime.DisplayMember = "Name";

            //---------------------------体温监测--------------------------------
            int count=dsTemperature.Tables[0].Rows.Count;
            if (count >= 1)
            {
                flagTemperature = true;

                this.txtTemperatureMax.Text = dsTemperature.Tables[0].Rows[0]["TEMPERATUREMAX"].ToString();
                this.txtTemperatureMin.Text = dsTemperature.Tables[0].Rows[0]["TEMPERATUREMIN"].ToString();
                this.txtPulseMax.Text = dsTemperature.Tables[0].Rows[0]["PULSEMAX"].ToString();
                this.txtPulseMin.Text = dsTemperature.Tables[0].Rows[0]["PULSEMIN"].ToString();
                this.txtBreathMax.Text = dsTemperature.Tables[0].Rows[0]["BREATHMAX"].ToString();
                this.txtBreathMin.Text = dsTemperature.Tables[0].Rows[0]["BREATHMIN"].ToString();

                this.txtSBPMax.Text = dsTemperature.Tables[0].Rows[0]["SBPMAX"].ToString();
                this.txtSBPMin.Text = dsTemperature.Tables[0].Rows[0]["SBPMIN"].ToString();

                this.txtDBPMax.Text = dsTemperature.Tables[0].Rows[0]["DBPMAX"].ToString();
                this.txtDBPMin.Text = dsTemperature.Tables[0].Rows[0]["DBPMIN"].ToString();

                this.txtStoolMax.Text = dsTemperature.Tables[0].Rows[0]["STOOLMAX"].ToString();
                this.txtStoolMin.Text = dsTemperature.Tables[0].Rows[0]["STOOLMIN"].ToString();
            }


            //ucRecordMonitor hlb = new ucRecordMonitor("护理部",CBO_DS.Tables["TextKind"].DefaultView);
            //延安妇幼老版质控屏蔽
            ////管床医生监控列表
            //ucRecordMonitor ucRecord = new ucRecordMonitor("护理部", CBO_DS.Tables["TextKind"].DefaultView,false);
            //tabControlPanel4.Controls.Add(ucRecord);
            //ucRecord.Dock = System.Windows.Forms.DockStyle.Fill;


      
        }

        /// <summary>
        /// “文书类型”Combobox改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboTextKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboTextKind.Text != "请选择..." && 
                !string.IsNullOrEmpty(this.cboTextKind.Text)) //体温单
            {
                this.cboMonitoring.Enabled = true;
                
            }
            else
            {
                this.cboMonitoring.Enabled = false;
                this.txtExecCycles.Enabled = true;
                this.cboCyclesUnit.Enabled = true;              
                Con_ClearCntrValue.ClearCntrValue(this.gpbFixTime, true);
            }
        }

        /// <summary>
        /// 保存参数设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!updateFlag)
            {
                ////ID自增设置
                chp.Id = App.GenId("T_QUALITY_VAR_HLB", "ID");
            }

            //文书类型
            if (cboTextKind.SelectedIndex != 0)
            {
                chp.Document_Type = Convert.ToInt32(this.cboTextKind.SelectedValue.ToString());
            }
            else
            {
                App.MsgErr("请选择文书类型");
                return;
            }

            //监控子项
            if (this.cboMonitoring.Enabled == false)
            {
                chp.Sub_Item = 0;
            }
            else
            {
                chp.Sub_Item = Convert.ToInt32(this.cboMonitoring.SelectedValue.ToString());
            }

            //监控患者类型
            if (cboMonitorType.SelectedIndex != 0)
            {
                chp.Inpatient_Type = Convert.ToInt32(this.cboMonitorType.SelectedValue.ToString());
            }
            else
            {
                App.MsgErr("请选择监控患者类型");
                return;
            }

            //执行周期
            if (txtExecCycles.Enabled == true && cboCyclesUnit.Enabled == true)
            {
                if (txtExecCycles.Text == "" || txtExecCycles.Text == null || cboCyclesUnit.SelectedItem.ToString() == "" || cboCyclesUnit.SelectedItem.ToString() == null)
                {
                    App.MsgErr("请输入执行周期");
                    return;
                }
                chp.Runcycle = Convert.ToInt32(txtExecCycles.Text);
                chp.Runcycleunit = cboCyclesUnit.SelectedItem.ToString();
            }
            else
            {                
                chp.Runcycle = 0;
                chp.Runcycleunit = "";
            }

            //参考时间
            if (cboCKTime.SelectedIndex != 0)
            {
                chp.Base_Time = Convert.ToInt32(this.cboCKTime.SelectedValue.ToString());
            }
            else
            {
                App.MsgErr("请选择参考时间");
                return;
            }


            //是否预警
            if (this.rdoIsOverAlert.Checked == true)
            {
                chp.Isprealert= 'Y';
               
            }
            else
            {
                chp.Isprealert = 'N';
               
            }


            //超时补上是否扣分
            if (this.rdoIsMend.Checked == true)
            {
                chp.Is_Renew = 'Y';
                
            }
            else
            {
                chp.Is_Renew = 'N';
               
            }

            //是否当天检查一次
            if (this.rdoIsCheck.Checked == true)
            {
                chp.Istoday = 'Y'; //是
            }
            else
            {
                chp.Istoday = 'N';
            }

            

            if (this.txtPrealertTime.Enabled == true)
            {
                //预警时间
                if (this.txtPrealertTime.Text != "")
                {
                    chp.Prealerttime = Convert.ToInt32(this.txtPrealertTime.Text);//预警时间
                    chp.Pretimeunit = this.cboPrealertUnit.SelectedItem.ToString();//预警单位     
                   
                }
                else
                {
                    App.Msg("请输入预警时间");          
                }
            }
            else
            {
                chp.Prealerttime = 0;//预警时间
                chp.Pretimeunit = "";//预警单位
            }

          

            //扣分值
            if (txtDeduction.Enabled == true)
            {
                chp.Take_Grade = Convert.ToDouble(this.txtDeduction.Text);
            }

            //是否提醒
           
           if (this.rdoIsNotice.Checked == true)
            {
                chp.Is_Notice = 'Y';
                
            }
            else
            {
                chp.Is_Notice = 'N';
                
            }

            chp.Isoveralert = 'Y';//警告
            chp.Overalerttime = 0;//报警提前时间(超过)
            chp.Overtimeunit = "";//报警提前时间单位(超过)
            chp.ThreadState = 1;//线程状态-----------默认为1，启动
            chp.Fix_Time=Con_CheckBoxListUtil.GetCheckedItems(this.gpbFixTime);//固定执行时间点

            if (txtItemMax.Text != "")
            {
                chp.Item_Max = float.Parse(txtItemMax.Text);
            }
            else
            {
                chp.Item_Max = 0f;
            }

            if (txtItemMin.Text != "")
            {
                chp.Item_Min = float.Parse(txtItemMin.Text);
            }
            else
            {
                chp.Item_Min = 0f;
            }

            if (this.txtExceTimes.Text == null || this.txtExceTimes.Text == "")
            {
                chp.ExceTimes = 1;
            }
            else
            {
                chp.ExceTimes = Convert.ToInt32(this.txtExceTimes.Text);
            }



            if (updateFlag)//=true 修改
            {
                string temp = "update t_quality_var_hlb hlb set hlb.document_type=" + chp.Document_Type + ",hlb.sub_item=" + chp.Sub_Item + ",hlb.inpatient_type=" + chp.Inpatient_Type + ",hlb.base_time=" + chp.Base_Time + ",hlb.runcycle=" + chp.Runcycle + ",hlb.runcycleunit='" + chp.Runcycleunit + "',hlb.isprealert='" + chp.Isprealert + "',hlb.prealerttime=" + chp.Prealerttime + ",hlb.pretimeunit='" + chp.Pretimeunit + "',hlb.isoveralert='" + chp.Isoveralert + "',hlb.overalerttime=" + chp.Overalerttime + ",hlb.overtimeunit='" + chp.Overtimeunit + "',hlb.take_grade=" + chp.Take_Grade + ",hlb.is_notice='" + chp.Is_Notice + "',hlb.is_renew='" + chp.Is_Renew + "',hlb.fix_time='" + chp.Fix_Time + "',hlb.istoday='" + chp.Istoday + "',hlb.excetimes=" + chp.ExceTimes + ",hlb.threadstate=" + chp.ThreadState + ",hlb.item_max=" + chp.Item_Max + ",hlb.item_min=" + chp.Item_Min+"where hlb.id="+chp.Id;

                int i = 0;
                DialogResult result = MessageBox.Show("数据已修改，确认要保存？", "消息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    i = App.ExecuteSQL(temp);
                }
                else
                {
                    return;
                }


                if (i > 0)
                {

                    App.Msg("修改成功！");
                    QualityView();
                    ResetAll();
                }
                else
                {
                    App.MsgErr("修改失败！");
                }
            }
            else //新增
            {

                string temp = "insert into T_QUALITY_VAR_HLB values(" + chp.Id + "," + chp.Document_Type + "," + chp.Sub_Item + ","
              + "" + chp.Inpatient_Type + "," + chp.Base_Time + "," + chp.Runcycle + ","
              + "'" + chp.Runcycleunit + "','" + chp.Isprealert + "'," + chp.Prealerttime + ",'" + chp.Pretimeunit + "',"
              + "'" + chp.Isoveralert + "'," + chp.Overalerttime + ",'" + chp.Overtimeunit + "',"
              + "" + chp.Take_Grade + ",'" + chp.Is_Notice + "','" + chp.Is_Renew + "',"
              + "'" + chp.Fix_Time + "','" + chp.Istoday + "'," + chp.ExceTimes + "," + chp.ThreadState + "," + chp.Item_Max + "," + chp.Item_Min + ")";


                int i = 0;
                DialogResult result = MessageBox.Show("确认要保存数据？", "消息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    i = App.ExecuteSQL(temp);
                }
                else
                {
                    return;
                }


                if (i > 0)
                {

                    App.Msg("添加成功！");
                    QualityView();
                    ResetAll();

                }
                else
                {
                    App.MsgErr("添加失败！");
                }
            }

        }

        private void rdoIsOverAlert_CheckedChanged(object sender, EventArgs e)
        {
            //是否预警
            if (this.rdoIsOverAlert.Checked == true)
            {
                this.IsOverAlert(true);
            }
            else
            {
                this.IsOverAlert(false);
            }
        }

        private void rdoIsMend_CheckedChanged(object sender, EventArgs e)
        {
            //超时补上是否扣分
            if (this.rdoIsMend.Checked == true)
            {
                txtDeduction.Enabled = true;//扣分值
            }
            else
            {
                txtDeduction.Enabled = false;
            }
        }

        
        /// <summary>
        /// 执行时间点的复选框控制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdoDouble_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoDouble.Checked == false)
            {
                ControlEnable(true, 1, false);
                
            }
            else if(this.rdoSingle.Checked==false)
            {
                ControlEnable(false, 1, true);
            }
        }

        /// <summary>
        /// 监控子项的下拉列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboMonitoring_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (this.cboMonitoring.Text != "体重")//等于T-P-R
            //{                
            //    Con_ClearCntrValue.ClearCntrValue(this.gpbFixTime, true);
            //    this.txtExecCycles.Enabled = true;
            //    this.cboCyclesUnit.Enabled = false;
            //    this.txtExceTimes.Enabled = true;
            //}
            //else
            //{               
            //    Con_ClearCntrValue.ClearCntrValue(this.gpbFixTime,false);            
            //    this.txtExceTimes.Enabled = false;

            //    if (this.cboMonitoring.SelectedIndex == 3)
            //    {
            //        this.txtExecCycles.Enabled = false;
            //        this.cboCyclesUnit.Enabled = false;
            //    }
            //    else
            //    {
            //        this.txtExecCycles.Enabled = true;
            //        this.cboCyclesUnit.Enabled = true;
            //        this.txtExceTimes.Enabled = false;
            //    }
            //}

            //if (this.cboMonitoring.Text == "复测" || this.cboMonitoring.Text == "降温")//等于复测
            //{

            //    this.txtItemMin.Enabled = true;
            //    this.txtItemMax.Enabled = true;

            //}
            //else
            //{
            //    this.txtItemMin.Enabled = false;
            //    this.txtItemMax.Enabled = false;
            //}

        }


        /// <summary>
        /// 控件的可用性设置
        /// </summary>
        /// <param name="flag"></param>
        private void ControlEnable(bool flag,int temp,bool chk)
        {
            if (temp == 1)
            {
                this.chk1am.Enabled = flag;


                this.chk1am.Checked = flag;
               
                this.chk2am.Enabled = chk;
                this.chk6am.Enabled = chk;
                this.chk10am.Enabled = chk;
                this.chk2pm.Enabled = chk;
                this.chk6pm.Enabled = chk;
                this.chk10pm.Enabled = chk;

                this.chk2am.Checked = chk;
                this.chk6am.Checked = chk;
                this.chk10am.Checked = chk;
                this.chk2pm.Checked = chk;
                this.chk6pm.Checked = chk;
                this.chk10pm.Checked = chk;
            }
        }

        /// <summary>
        /// 是否预警显示控制
        /// </summary>
        /// <param name="flag"></param>
        private void IsOverAlert(bool flag)
        {
            this.cboPrealertUnit.Enabled = flag;
            this.txtPrealertTime.Enabled = flag;
        }

        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetAll();
        }

        /// <summary>
        /// 重设方法
        /// </summary>
        public void ResetAll()
        {
            Con_ClearCntrValue.ClearCntrValue(this.groupBox1, true);
            updateFlag = false;
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (lvwQualitys.SelectedItems.Count > 0)
            {
                if (App.Ask("你是否要删除"))
                {
                    Class_Quality_HLB_View q = (Class_Quality_HLB_View)lvwQualitys.SelectedItems[0].Tag;
                    string sqlDel = "delete from t_quality_var_hlb where ID=" + q.Id;
                    lvwQualitys.SelectedItems[0].Remove();
                    int i = App.ExecuteSQL(sqlDel);
                    if (i > 0)
                    {
                        App.Msg("删除成功！");
                    }
                }
            }
            else
            {
                App.MsgErr("请选择一条需要删除的记录");
            }
        }

    

       

     

        /// <summary>
        /// 质控规则显示列表
        /// </summary>
        private void QualityView()
        {
            tempList.Clear();
//            string sqltemp1 = "select * from QUALITY_VAR_HLB_VIEW where 监控子项='T-P-R' order by id desc";
//            string sqltemp2 = "select * from QUALITY_VAR_HLB_VIEW where 监控子项 in('复测','降温') order by id desc";
//            string sqltemp3 = "select * from QUALITY_VAR_HLB_VIEW where 监控子项 in('体重','血压') order by id desc";
//            string sqltemp4 = "select * from QUALITY_VAR_HLB_VIEW where  监控子项 in('灌肠','大便') order by id desc";
//            string sqltemp5 = "select * from QUALITY_VAR_HLB_VIEW where 监控子项='小儿体温' order by id desc";

            string sqltemp1 = "select * from QUALITY_VAR_HLB_VIEW where 监控子项='T-P-R' order by id desc";
            string sqltemp2 = "select * from QUALITY_VAR_HLB_VIEW where 监控子项 in('身高','体重') order by id desc";
            string sqltemp3 = "select * from QUALITY_VAR_HLB_VIEW where 监控子项 in('大便','小便','呼吸') order by id desc";
            string sqltemp4 = "select * from QUALITY_VAR_HLB_VIEW where  监控子项 in('血压') order by id desc";
            string sqltemp5 = "select * from QUALITY_VAR_HLB_VIEW where 监控子项 in('复测','降温') order by id desc";
           // string sqltemp5 = "select * from QUALITY_VAR_HLB_VIEW where 监控子项='小儿体温' order by id desc";
            
            lvwQualitys.Items.Clear();

            QualitySelectView(sqltemp1, "group1");
            QualitySelectView(sqltemp2, "group2");
            QualitySelectView(sqltemp3, "group3");
            QualitySelectView(sqltemp4, "group4");
            QualitySelectView(sqltemp5, "group5");
           


            for (int k = 0; k < tempList.Count; k++)
            {
                lvwQualitys.Items[k].Tag = tempList[k];
            }
        }

        private void QualitySelectView(string sqltemp,string group)
        {                        
            DataSet dataSet = App.GetDataSet(sqltemp);
            ListViewItem[] item = new ListViewItem[dataSet.Tables[0].Rows.Count];
            qhv = new Class_Quality_HLB_View[dataSet.Tables[0].Rows.Count];
            
            string str = "";
            for (int i = 0; i <= dataSet.Tables[0].Rows.Count - 1; i++)
            {
                //====================用于界面上显示
                qhv[i] = new Class_Quality_HLB_View();
                qhv[i].Id = Convert.ToInt32(dataSet.Tables[0].Rows[i]["ID"].ToString());
                qhv[i].Inpatient_Type = dataSet.Tables[0].Rows[i]["病人类型"].ToString();
                qhv[i].Base_Time = dataSet.Tables[0].Rows[i]["参考时间"].ToString();
                qhv[i].Runcycle = Convert.ToInt32(dataSet.Tables[0].Rows[i]["执行周期"].ToString());
                qhv[i].Runcycleunit = dataSet.Tables[0].Rows[i]["执行周期单位"].ToString();
                qhv[i].Fix_Time = SortString(dataSet.Tables[0].Rows[i]["固定执行时间点"].ToString());
                qhv[i].Take_Grade = Convert.ToDouble(dataSet.Tables[0].Rows[i]["扣分值"].ToString());
                qhv[i].ExceTimes = Convert.ToInt32(dataSet.Tables[0].Rows[i]["执行次数"].ToString());
                qhv[i].Item_Max = dataSet.Tables[0].Rows[i]["项目最大值"].ToString()==""?0f:float.Parse(dataSet.Tables[0].Rows[i]["项目最大值"].ToString());
                qhv[i].Item_Min = dataSet.Tables[0].Rows[i]["项目最小值"].ToString()==""?0f:float.Parse(dataSet.Tables[0].Rows[i]["项目最小值"].ToString());

                //=====================用于线程处理
                qhv[i].Document_Type = dataSet.Tables[0].Rows[i]["文档类型"].ToString();
                qhv[i].Sub_Item = dataSet.Tables[0].Rows[i]["监控子项"].ToString();
                qhv[i].Isprealert = dataSet.Tables[0].Rows[i]["是否预警"].ToString();
                qhv[i].Prealerttime = Convert.ToInt32(dataSet.Tables[0].Rows[i]["报警提前时间"].ToString());
                qhv[i].Pretimeunit = dataSet.Tables[0].Rows[i]["报警提前时间单位"].ToString();
                qhv[i].Isoveralert = dataSet.Tables[0].Rows[i]["是否警告"].ToString();
                qhv[i].Overalerttime = Convert.ToInt32(dataSet.Tables[0].Rows[i]["报警提前时间超过"].ToString());
                qhv[i].Overtimeunit = dataSet.Tables[0].Rows[i]["报警提前时间超过单位"].ToString();
                qhv[i].Is_Notice = dataSet.Tables[0].Rows[i]["是否提醒"].ToString();
                qhv[i].Is_Renew = dataSet.Tables[0].Rows[i]["超时补上是否扣分"].ToString();
                qhv[i].Istoday = dataSet.Tables[0].Rows[i]["是否当天检查一次"].ToString();
                qhv[i].ThreadState = dataSet.Tables[0].Rows[i]["线程状态"].ToString();

                if (group != "group4")
                {
                    str = ShowViewSet(group, qhv[i]);

                }
                else
                {
                    qhv[i].Sub_Item = dataSet.Tables[0].Rows[i]["监控子项"].ToString();
                    str = ShowViewSet(group, qhv[i]);
                }

                
                lvwQualitys.Groups[group].Items.Add(str);
                
                tempList.Add(qhv[i]);
                item[i] = new ListViewItem(new string[] { str, qhv[i].ThreadState}, 0, lvwQualitys.Groups[group]);
            
                mapItemToQualitys[str] =qhv[i];
                
                lvwQualitys.Items.AddRange(new ListViewItem[] { item[i] });
            }      
          
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvwQualitys.SelectedItems.Count > 0)
            {
                Class_Quality_HLB_View q = (Class_Quality_HLB_View)lvwQualitys.SelectedItems[0].Tag;
                string sqlDel = "delete from t_quality_var_hlb where ID=" + q.Id;
                lvwQualitys.SelectedItems[0].Remove();
                int i = App.ExecuteSQL(sqlDel);
                if (i > 0)
                {
                    App.Msg("删除成功！");

                }
            }
            else
            {
                App.MsgErr("请选择一条需要删除的记录");
            }
           
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateFlag = true;

            Con_ClearCntrValue.ClearCntrValue(this.gpbFixTime, true);

            if (lvwQualitys.SelectedItems.Count > 0)
            {
                Class_Quality_HLB_View q = (Class_Quality_HLB_View)lvwQualitys.SelectedItems[0].Tag;
                chp.Id = q.Id;
                cboTextKind.Text = q.Document_Type;//文书类型
                cboMonitoring.Text = q.Sub_Item;//监控子项
                cboMonitorType.Text = q.Inpatient_Type;//患者类型
                txtExceTimes.Text = q.ExceTimes.ToString();//执行次数
                cboCKTime.Text = q.Base_Time;//参考时间
                txtExecCycles.Text = q.Runcycle.ToString();//执行周期
                cboCyclesUnit.Text = q.Runcycleunit;//执行周期单位
                txtItemMax.Text = q.Item_Max.ToString();//项目最大值
                txtItemMin.Text = q.Item_Min.ToString();//项目最小值

                if (q.Isprealert == "是")
                {
                    rdoIsOverAlert.Checked = true;
                    rdoIsOverAlertF.Checked = false;
                    txtPrealertTime.Text = q.Prealerttime.ToString();//预警时间
                    cboPrealertUnit.Text = q.Pretimeunit;//单位
                }
                else
                {
                    rdoIsOverAlert.Checked = false;
                    rdoIsOverAlertF.Checked = true;
                }

                if (q.Is_Renew == "是")
                {
                    rdoIsMend.Checked = true;
                    rdoIsMendF.Checked = false;
                    txtDeduction.Text = q.Take_Grade.ToString();//扣分值

                }
                else
                {
                    rdoIsMend.Checked = false;
                    rdoIsMendF.Checked = true;
                }

                if (q.Is_Notice == "是")
                {
                    rdoIsNotice.Checked = true;//是否提醒
                }
                else
                {
                    rdoIsNotice.Checked = false;
                }


                if (q.Istoday == "是")
                {
                    rdoIsCheck.Checked = true;//是否当天检查一次
                }
                else
                {
                    rdoIsCheck.Checked = false;
                }

                if (txtExceTimes.Text != "")
                {
                    txtExceTimes.Enabled = true;
                }

                Con_CheckBoxListUtil.SetCheck(gpbFixTime, q.Fix_Time);

            }
            else
            {
                App.MsgErr("请选择一条修改的记录");
                ResetAll();
            }

        }




        /// <summary>
        ///  保存监测值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveJC_Click(object sender, EventArgs e)
        {
            

            if (flagTemperature)
            {
                GetMonitoringTextBoxValue();
                //血压没有起作用，同样屏蔽掉
                //string tempSQL = "update T_TEMPERATURE_MONITORING t set t.TemperatureMax=" + ctm.TemperatureMax + ",t.TemperatureMin=" + ctm.TemperatureMin + ",t.PulseMax=" + ctm.PulseMax + ",t.PulseMin=" + ctm.PulseMin + ",t.BreathMax=" + ctm.BreathMax + ",t.BreathMin=" + ctm.BreathMin + ",t.SBPMax=" + ctm.SBPMax + ",t.SBPMin=" + ctm.SBPMin + ",t.DBPMax=" + ctm.DBPMax + ",t.DBPMin=" + ctm.DBPMin + ",t.StoolMax=" + ctm.StoolMax + ",t.StoolMin=" + ctm.StoolMin;
                string tempSQL = "update T_TEMPERATURE_MONITORING t set t.TemperatureMax=" + ctm.TemperatureMax + ",t.TemperatureMin=" + ctm.TemperatureMin + ",t.PulseMax=" + ctm.PulseMax + ",t.PulseMin=" + ctm.PulseMin + ",t.BreathMax=" + ctm.BreathMax + ",t.BreathMin=" + ctm.BreathMin + ",t.StoolMax=" + ctm.StoolMax + ",t.StoolMin=" + ctm.StoolMin;
                int i = 0;
                DialogResult result = MessageBox.Show("确认要保存已修改的数据？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.OK)
                {
                    i = App.ExecuteSQL(tempSQL);
                }
                else
                {
                    return;
                }


                if (i > 0)
                {

                    App.Msg("数据修改成功！");
                    QualityView();

                }
                else
                {
                    App.MsgErr("数据修改失败！");
                }


            }else{

                if (Con_ClearCntrValue.IsNotNull(grpMonitoring))
                {
                    return;
                }
                else
                {

                    GetMonitoringTextBoxValue();

                    string tempSQL = "insert into T_TEMPERATURE_MONITORING values(" + ctm.TemperatureMax + "," + ctm.TemperatureMin + "," + ctm.PulseMax + "," + ctm.PulseMin + "," + ctm.BreathMax + "," + ctm.BreathMin + "," + ctm.SBPMax + "," + ctm.SBPMin + "," + ctm.DBPMin + "," + ctm.DBPMax + "," + ctm.StoolMax + "," + ctm.StoolMin + ")";

                    int i = 0;
                    DialogResult result = MessageBox.Show("确认要保存数据？", "消息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                    {
                        i = App.ExecuteSQL(tempSQL);
                    }
                    else
                    {
                        return;
                    }


                    if (i > 0)
                    {

                        App.Msg("添加成功！");
                        QualityView();

                    }
                    else
                    {
                        App.MsgErr("添加失败！");
                    }

                }

            }

        }


        /// <summary>
        /// 获取监测值中的TextBox数据
        /// </summary>
        private void GetMonitoringTextBoxValue()
        {
            // 体温
            ctm.TemperatureMax = Convert.ToDouble(this.txtTemperatureMax.Text);
            ctm.TemperatureMin = Convert.ToDouble(this.txtTemperatureMin.Text);

            //脉搏
            ctm.PulseMax = Convert.ToDouble(this.txtPulseMax.Text);
            ctm.PulseMin = Convert.ToDouble(this.txtPulseMin.Text);


            //呼吸
            ctm.BreathMax = Convert.ToDouble(this.txtBreathMax.Text);
            ctm.BreathMin = Convert.ToDouble(this.txtBreathMin.Text);

            //收缩压 
            ctm.SBPMax = Convert.ToDouble(this.txtSBPMax.Text);
            ctm.SBPMin = Convert.ToDouble(this.txtSBPMin.Text);

            //舒张压
            ctm.DBPMax = Convert.ToDouble(this.txtDBPMax.Text);
            ctm.DBPMin = Convert.ToDouble(this.txtDBPMin.Text);

            //大便
            ctm.StoolMax = Convert.ToDouble(this.txtStoolMax.Text);
            ctm.StoolMin = Convert.ToDouble(this.txtStoolMin.Text);
        }


        /// <summary>
        /// 显示列表值设置
        /// </summary>
        public string ShowViewSet(string group,Class_Quality_HLB_View qhv)
        {
            string temp="";

            switch(group)
            {
                case "group1":
                    switch (qhv.Inpatient_Type)//一般，发热
                    {
                        case "所有患者":
                            temp = qhv.Inpatient_Type + "：参考时间：" + qhv.Base_Time + "   新入院病人连续测3天,每天：" + qhv.ExceTimes + " 次" + "     测试时间点有：" + qhv.Fix_Time + "     超时补上是否扣分：" + qhv.Is_Renew + "     扣分值：" + qhv.Take_Grade + " 分";
                            break;

                        case "手术患者":
                            string shousTime = qhv.Base_Time.Substring(5,2);
                            temp = qhv.Inpatient_Type + "：参考时间：" + qhv.Base_Time + "   " + shousTime + "术后3天,每天测：" + qhv.ExceTimes + " 次" + "     测试时间点有：" + qhv.Fix_Time + "     超时补上是否扣分：" + qhv.Is_Renew + "     扣分值：" + qhv.Take_Grade + " 分";
                            break;

                        case "转入患者":
                            temp = qhv.Inpatient_Type + "：参考时间：" + qhv.Base_Time + "   转入后连续测：" + qhv.ExceTimes + " 次" + "     测试时间点有：" + qhv.Fix_Time + "     超时补上是否扣分：" + qhv.Is_Renew + "     扣分值：" + qhv.Take_Grade + " 分";
                            break;

                        case "一般患者":
                            temp = qhv.Inpatient_Type + "：体温正常，T≤37.5℃ 参考时间：" + qhv.Base_Time + "   每天至少测：" + qhv.ExceTimes + " 次" + "     测试时间点有：" + qhv.Fix_Time + "     超时补上是否扣分：" + qhv.Is_Renew + "     扣分值：" + qhv.Take_Grade + " 分";
                            break;

                        case "发热患者":
                            if (qhv.Item_Min >=38)
                            {

                                string pointMin= Temperature(qhv.Item_Min.ToString());

                                temp = qhv.Inpatient_Type + "：参考时间：" + qhv.Base_Time + "   T≥" + pointMin + "   每天测" + qhv.ExceTimes + " 次  体温正常后连续测3天,每天3次" + "     测试时间点有：" + qhv.Fix_Time + "     超时补上是否扣分：" + qhv.Is_Renew + "     扣分值：" + qhv.Take_Grade + " 分";
                            }
                            else if (qhv.Item_Min == 37.5)
                            {
                                string pointMin = Temperature(qhv.Item_Min.ToString());
                                string pointMax = Temperature(qhv.Item_Max.ToString());

                                temp = qhv.Inpatient_Type + "：参考时间：" + qhv.Base_Time + "   " + pointMin + "<T≤" + pointMax + "   每天测" + qhv.ExceTimes + "次  体温正常后连续测3天,每天3次" + "     测试时间点有:" + qhv.Fix_Time + "     超时补上是否扣分:" + qhv.Is_Renew + "     扣分值:" + qhv.Take_Grade + "分";
                            }
                            else
                            {
                                string pointMin = Temperature(qhv.Item_Min.ToString());
                                string pointMax = Temperature(qhv.Item_Max.ToString());

                                temp = qhv.Inpatient_Type + "：参考时间：" + qhv.Base_Time + "   " + pointMin + "≤T≤" + pointMax + "   每天测" + qhv.ExceTimes + "次  体温正常后连续测3天,每天3次" + "     测试时间点有:" + qhv.Fix_Time + "     超时补上是否扣分:" + qhv.Is_Renew + "     扣分值:" + qhv.Take_Grade + "分";
                            }
                            break;
                    }
                    break;

                //case "group2":
                //    if (qhv.Sub_Item == "复测")
                //    {
                //        temp = qhv.Inpatient_Type + "：参考时间：" + qhv.Base_Time + "   体温与前一次相比突升幅度≥" + Temperature(qhv.Item_Max.ToString()) + "     体温与前一次相比突降幅度≥" + Temperature(qhv.Item_Min.ToString()) + " 提醒用户加复测标志" + "     扣分值：" + qhv.Take_Grade + " 分"; ;
                //    }
                //    else //降温
                //    {
                //        temp = qhv.Inpatient_Type + "：参考时间：" + qhv.Base_Time + "   体温大于≥" + Temperature(qhv.Item_Min.ToString()) + "   提醒用户降温" + "     扣分值：" + qhv.Take_Grade + " 分"; ;
                //    }
                //    break;

                case "group2": //身高，体重
                    //if (qhv.Base_Time != "日常时间")
                    //{
                        //string baseTime1 = qhv.Base_Time.Substring(0, 2);

                        //temp = qhv.Inpatient_Type + "：参考时间：" + qhv.Base_Time + "   " + qhv.Sub_Item + "： " + baseTime1 + "当天测试 " + qhv.ExceTimes + " 次     超时补上是否扣分：" + qhv.Is_Renew + "     扣分值：" + qhv.Take_Grade + "分";
                   // }
                    //else
                    //{
                        //temp = qhv.Inpatient_Type + "：参考时间：" + qhv.Base_Time + "   " + qhv.Sub_Item + "： 体温单换页的 "+qhv.Runcycle +" "+ qhv.Runcycleunit+" 内需记录 " + qhv.ExceTimes + " 次  黄灯提醒时间: "+qhv.Fix_Time+"    超时补上是否扣分：" + qhv.Is_Renew + "     扣分值：" + qhv.Take_Grade + "分";
                   // }
				   //if (qhv.Sub_Item == "身高")
                    //{
                        temp = qhv.Inpatient_Type + "：参考时间：" + qhv.Base_Time + "   " + qhv.Sub_Item + "：入院当天记录 " + 
							qhv.ExceTimes + " 次。入区后即亮黄灯，23:59亮红灯    超时补上是否扣分：" + qhv.Is_Renew + "     扣分值：" + qhv.Take_Grade + " 分";
                    //}
                    //else
                    //{
                        //temp = qhv.Inpatient_Type + "：参考时间：" + qhv.Base_Time + "   " + qhv.Sub_Item + "：每天记录 " + qhv.ExceTimes + " 次。入区后即亮黄灯，23:59亮红灯    超时补上是否扣分：" + qhv.Is_Renew + "     扣分值：" + qhv.Take_Grade + " 分";
                    //}
                    break;

                case "group3"://大小便
                    //if (qhv.Sub_Item == "灌肠")
                    //{
                        //temp = qhv.Inpatient_Type + "：参考时间：" + qhv.Base_Time + "   " + qhv.Sub_Item + "：   " + qhv.Runcycle + " " + qhv.Runcycleunit + "一次　大便连续3天为0，提醒用户进行灌肠。     超时补上是否扣分：" + qhv.Is_Renew + "     扣分值：" + qhv.Take_Grade + " 分";
                    //}
                    //else
                    //{

                        //temp = qhv.Inpatient_Type + "：参考时间：" + qhv.Base_Time + "   " + qhv.Sub_Item + "：每天记录 " + qhv.ExceTimes + " 次。入区后每天 " + qhv.Fix_Time + " 亮黄灯    超时补上是否扣分：" + qhv.Is_Renew + "     扣分值：" + qhv.Take_Grade + " 分";
                    //}
					 temp = qhv.Inpatient_Type + "：参考时间：" + qhv.Base_Time + "   " + qhv.Sub_Item + "：每天记录 " +
                            qhv.ExceTimes + " 次。入区后每天12:00亮黄灯，23:59亮红灯    超时补上是否扣分：" + qhv.Is_Renew + "     扣分值：" + qhv.Take_Grade + " 分";
                    break;

                case "group4"://血压
				 if (qhv.Inpatient_Type == "手术患者")
                    {
                        temp = qhv.Inpatient_Type + "：参考时间：" + qhv.Base_Time + "   " + qhv.Sub_Item + "：   手术当天记录 " + 
							qhv.ExceTimes + " 次。　手术开始即亮黄灯，23:59亮红灯。    超时补上是否扣分：" + qhv.Is_Renew + "     扣分值：" + qhv.Take_Grade + " 分";
                    }
                    else
                    {
                       temp = qhv.Inpatient_Type + "：参考时间：" + qhv.Base_Time + "   " + qhv.Sub_Item + "：入院当天记录 " + 
							qhv.ExceTimes + " 次。入区后即亮黄灯，23:59亮红灯    超时补上是否扣分：" + qhv.Is_Renew + "     扣分值：" + qhv.Take_Grade + " 分";
                    }
                    break;
                    //switch (qhv.Inpatient_Type)
                    //{
                        //case "一般患者":
                           // temp = qhv.Inpatient_Type + "：参考时间：" + qhv.Base_Time + "   10岁以下小儿入区后   每天测 " + qhv.ExceTimes + "次     超时补上是否扣分：" + qhv.Is_Renew + "     扣分值：" + qhv.Take_Grade + " 分 ";
                            //break;

                       // case "发热患者":
                           // string pointMin = Temperature(qhv.Item_Min.ToString());
                            //temp = qhv.Inpatient_Type + "：参考时间：" + qhv.Base_Time + "   10岁以下小儿体温≥ " + pointMin + "   每天 " + qhv.ExceTimes+" 次      超时补上是否扣分：" + qhv.Is_Renew + "     扣分值：" + qhv.Take_Grade + " 分 ";
                            //break;
                    //}
                    

                    //break;

              
                             
            }
            return temp;
        }

        /// <summary>
        /// 监控患者改变时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboMonitorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboMonitoring.Text == "复测")//发热患者
            {

                this.txtItemMin.Enabled = true;
                this.txtItemMax.Enabled = true;
                this.lblItemMin.Text="突升幅度";
                this.lblItemMax.Text = "突降幅度";
            }
            else if (this.cboMonitoring.Text == "T-P-R"||this.cboMonitoring.Text == "降温")
            {
                this.txtItemMin.Enabled = true;
                this.txtItemMax.Enabled = true;

                this.lblItemMin.Text = "项目最小值";
                this.lblItemMax.Text = "项目最大值";
            }
            else if (this.cboMonitoring.Text == "小儿体温"&&this.cboMonitorType.Text=="发热患者")
            {
                this.txtItemMin.Enabled = true;
                this.txtItemMax.Enabled = true;

                this.lblItemMin.Text = "项目最小值";
                this.lblItemMax.Text = "项目最大值";
            }
            else
            {
                this.txtItemMin.Enabled = false;
                this.txtItemMax.Enabled = false;

                this.lblItemMin.Text = "项目最小值";
                this.lblItemMax.Text = "项目最大值";
            }
        }


        /// <summary>
        /// 验证体温数据如果后面有.的话，就默认为一位小数，如果是整数的话，就添加.0
        /// </summary>
        /// <param name="newValue">体温数据</param>
        /// <returns></returns>
        public string Temperature(string newValue)
        {
            if (newValue.ToString().Contains("."))
            {
                int index = newValue.ToString().IndexOf('.');
                newValue = newValue.ToString().Substring(0, index + 2);

            }
            else
            {
                newValue = newValue.ToString() + ".0";
            }
            if (newValue == "0.0")
            {
                newValue = "";
            }
            return newValue;
        }

        /// <summary>
        /// 字符串倒叙序
        /// </summary>
        /// <returns></returns>
        public string SortString(string str)
        {
            string[] strtemp = str.Split(',');
            string resultList = "";


            Array.Reverse(strtemp);
            for (int i = 0; i < strtemp.Length; i++)
            {
                resultList += string.Format("{0},", strtemp[i]);
            }
                       
            return resultList.Trim(',');
        }

        private void frmUCEParam_Load(object sender, EventArgs e)
        {
            try
            {
                App.SetToolButtonByUser("ttsbtnPrint", false);
                App.SetToolButtonByUser("ttsbtnPrintContinue", false);
                App.SetToolButtonByUser("tsbtnTempSave", false);
                App.SetToolButtonByUser("tsbtnCommit", false);
                App.SetToolButtonByUser("tsbtnSmallTemplateSave", false);
                App.SetToolButtonByUser("tsbtnTemplateSave", false);//保存模版
                //病案查阅
                UserfrmQueryLevy ucQueryLevy = new UserfrmQueryLevy();

                ucQueryLevy.Dock = System.Windows.Forms.DockStyle.Fill;
                ucQueryLevy.Location = new System.Drawing.Point(3, 3);
                ucQueryLevy.Name = "ucQueryLevy";
                ucQueryLevy.Size = new System.Drawing.Size(940, 698);
                ucQueryLevy.TabIndex = 0;
                App.UsControlStyle(ucQueryLevy);
                //tabPage4.Controls.Add(ucQueryLevy);
                tabControlPanel1.Controls.Add(ucQueryLevy);


                ucDocument_statistics ucDs = new ucDocument_statistics();
                tabControlPanel6.Controls.Add(ucDs);
                ucDs.Dock = System.Windows.Forms.DockStyle.Fill;



                ////管床医生监控列表
                //ucRecordMonitor hlb = new ucRecordMonitor("护理部", CBO_DS.Tables["TextKind"].DefaultView, false);
                //tabControlPanel4.Controls.Add(hlb);
                //hlb.Dock = System.Windows.Forms.DockStyle.Fill;

                //客观评分 郧西妇幼该功能不显示
                //UcSpotcheck ucRecord = new UcSpotcheck();

                //ucRecord.Dock = System.Windows.Forms.DockStyle.Fill;
                //ucRecord.Location = new System.Drawing.Point(3, 3);
                //ucRecord.Name = "ucRecord";
                //ucRecord.Size = new System.Drawing.Size(940, 698);
                //ucRecord.TabIndex = 0;
                //App.UsControlStyle(ucRecord);
                //tabControlPanel5.Controls.Add(ucRecord);


                //延安妇幼-新版质控报表
                QualityControl.UcNurse ucQuality = new QualityControl.UcNurse();

                ucQuality.Dock = System.Windows.Forms.DockStyle.Fill;
                ucQuality.Name = "ucQuality";
                tabControlPanel8.Controls.Add(ucQuality);
               
            }
            catch { }
  
        }
       
    }
}