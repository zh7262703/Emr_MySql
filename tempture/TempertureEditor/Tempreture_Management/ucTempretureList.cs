using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Reflection;
using Bifrost;
using TempertureEditor.Util;
using TempertureEditor.Tempreture_Management;
using TempertureEditor.Model;
using System.Drawing.Printing;
using TempertureEditor.Controls;

namespace TempertureEditor
{
    public partial class ucTempretureList : UserControl
    {
        #region 本类用到的静态工具类方法
        /// <summary>
        /// 通过vValue，找到字典key(如果有多个相同vValue,只返回第一个找到的key)
        /// </summary>
        /// <param name="vDic"></param>
        /// <param name="vValue"></param>
        /// <returns></returns>
        private string GetDicKey(Dictionary<string, string> vDic, string vValue)
        {
            foreach (KeyValuePair<string, string> kvp in vDic)
            {
                if (kvp.Value.Equals(vValue))
                {
                    return kvp.Key;
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// 比较double类型数值是否在上下限范围内
        /// </summary>
        /// <param name="vMax"></param>
        /// <param name="vMin"></param>
        /// <param name="value"></param>
        /// <param name="IsContainBorder">是否包括边界值</param>
        /// <returns></returns>
        internal static bool doubleValueInScope(double vMax, double vMin, double value, bool IsContainBorder)
        {
            if (IsContainBorder && value <= vMax && value >= vMin)
            {
                return true;
            }
            if (!IsContainBorder && value < vMax && value > vMin)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 替换sql语句中的@打头的特殊变量
        /// </summary>
        /// <param name="vSql"></param>
        /// <param name="vDic"></param>
        /// <returns></returns>
        internal static string GetSql(string vSql, Dictionary<string, object> vDic)
        {
            foreach (var item in vDic)
            {
                string vParaName = "@" + item.Key;
                object vParaValue = item.Value;
                vSql = vSql.Replace(vParaName, vParaValue.ToString());
            }
            return vSql;
        }
        /// <summary>
        /// 录入的值是否需要提示异常信息
        /// </summary>
        /// <param name="Sign"></param>
        /// <param name="SignValue"></param>
        /// <param name="Msg"></param>
        /// <returns></returns>
        internal static bool IsNeedRemind(string Sign, string SignValue, ref string Msg)
        {
            bool b = false;
            switch (Sign)
            {
                case "T":
                    double t = 0;
                    double.TryParse(SignValue, out t);
                    if (t < dTmin || t > dTmax)
                    {
                        b = true;
                        Msg = "患者体温必须在" + dTmin.ToString() + "和" + dTmax.ToString() + "之间";
                    }
                    else
                        b = false;
                    break;
                case "R":
                    int r = 0;
                    int.TryParse(SignValue, out r);
                    if (r < iRmin || r > iRmax)
                    {
                        b = true;
                        Msg = "患者呼吸必须在" + iRmin.ToString() + "和" + iRmax.ToString() + "之间";
                    }
                    else
                        b = false;
                    break;
                case "P":
                    int p = 0;
                    int.TryParse(SignValue, out p);
                    if (p < iPmin || p > iPmax)
                    {
                        b = true;
                        Msg = "患者脉搏或心率必须在" + iPmin.ToString() + "和" + iPmax.ToString() + "之间";
                    }
                    else
                        b = false;
                    break;
                default:
                    b = false;
                    break;
            }
            return b;
        }

        /// <summary>
        /// 将字典插入到目标字典后面
        /// </summary>
        /// <param name="vDicBase"></param>
        /// <param name="vDicParas"></param>
        internal static Dictionary<string, string> AddDic(Dictionary<string, string> vDicBase, params Dictionary<string, string>[] vDicParas)
        {
            Dictionary<string, string> vDic = new Dictionary<string, string>();
            foreach (var item in vDicBase)
            {
                vDic.Add(item.Key, item.Value);
            }
            foreach (Dictionary<string, string> Dic in vDicParas)
            {
                foreach (var item1 in Dic)
                {
                    vDic.Add(item1.Key, item1.Value);
                }
            }

            return vDic;
        }

        /// <summary>
        /// 在目标字典的key值后添加
        /// </summary>
        /// <param name="vDicBase"></param>
        /// <param name="vDicPara"></param>
        /// <param name="vKey"></param>
        internal static Dictionary<string, string> AddDic(Dictionary<string, string> vDicBase, Dictionary<string, string> vDicPara, string vAfterKey)
        {
            Dictionary<string, string> vDic = new Dictionary<string, string>();
            foreach (var item in vDicBase)
            {
                vDic.Add(item.Key, item.Value);
                if (vAfterKey != null && vAfterKey.Equals(item.Key))
                {
                    foreach (var item1 in vDicPara)
                    {
                        vDic.Add(item1.Key, item1.Value);
                    }
                }
            }
            return vDic;
        }

        /// <summary>
        /// treeview 添加节点
        /// </summary>
        /// <param name="vNotes"></param>
        /// <param name="vDic"></param>
        internal static void AddNotes(TreeNodeCollection vNotes, Dictionary<string, string> vDic)
        {
            foreach (var item in vDic)
            {
                TreeNode vNote = new TreeNode();
                vNote.Text = item.Value;
                vNote.Name = item.Key;
                vNotes.Add(vNote);
            }
        }

        /// <summary>
        /// 比较两个字符串是否相等
        /// </summary>
        /// <param name="string1">字符串1</param>
        /// <param name="string2">字符串2</param>
        /// <param name="ignoreCase">是否区分大小写</param>
        /// <returns>比较结果</returns>
        internal static bool SafeCompare(string string1, string string2, bool ignoreCase)
        {
            return string1 != null
                && string2 != null
                && string1.Length == string2.Length
                && string.Compare(string1, string2, ignoreCase, CultureInfo.InvariantCulture) == 0;
        }
        #endregion

        DataGridViewPrint dataGridViewPrint;
    
        private List<int> m_updateRows = new List<int>();             //存储数值被改动的行号index(0-n)
        private List<int> m_exceptionRows = new List<int>(); //存储存在监测异常值的行号index(0-n)
        private string[] m_Times = null;
        public TemperatureMonitoring m_Monitoring = null;

        private string m_OperateUserId = "";
        private int m_SickAreaID = 0;
        private string _templateType = "";
        private string _splitChildPid = "";
        string m_SickareaName = string.Empty;
        string m_SectionName = string.Empty;
        Dictionary<string, string> m_DicTPR = null;
        Dictionary<string, string> m_DicSaveAsDayColumn = null;          //可编辑按天保存列,保存时使用
        //所有显示列信息字典m_vDicAllShow
        Dictionary<string, string> m_vDicAllShow = null;

        string m_cellOldValue = ""; //用于临时存储修改前的单元格数值

        /// <summary>
        /// TPR的可录入值上限值，下限值
        /// </summary>
        const int dTmin = 34;
        const int dTmax = 43;
        const int iRmin = 1;
        const int iRmax = 100;
        const int iPmin = 0;
        const int iPmax = 190;

        /// <summary>
        /// 体温单群录构造方法
        /// </summary>
        /// <param name="templateType">体温单类型tempetureDataComm.TEMPLATE_CHILD-新生儿、 tempetureDataComm.TEMPLATE_NORMA-普通</param>
        /// <param name="sickId">病区id</param>
        /// <param name="splitChildPid">新生儿住院号分隔符,如果为空,不起作用</param>
        public ucTempretureList(string templateType, int sickId, string splitChildPid, string operateUserId)
        {
            InitializeComponent();

            _templateType = templateType;
            m_SickAreaID = sickId;
            _splitChildPid = splitChildPid;
            m_OperateUserId = operateUserId;

            App.Ini();

            Init(_templateType);

        }

        #region 事件辅助函数

        /// <summary>
        /// 确认指定单元格里的数值是否异常，并红色字体显示
        /// </summary>
        private void CheckCellException(DataGridViewCell vCell)
        {
            string columnHeaderText = vCell.OwningColumn.HeaderText;

            if (columnHeaderText != "T" && columnHeaderText != "P" && columnHeaderText != "R")
                return;
            string cellValue = StringHelper.GetString(vCell.Value);

            // 异常值，标红显示
            if (cellValue != "" && m_Monitoring != null)
            {
                double vMax = 0.0;
                double vMin = 0.0;
                if (columnHeaderText == "T")
                {
                    vMax = this.m_Monitoring.TEMPERATUREMAX;
                    vMin = this.m_Monitoring.TEMPERATUREMIN;
                }
                else if (columnHeaderText == "P")
                {
                    vMax = this.m_Monitoring.PULSEMAX;
                    vMin = this.m_Monitoring.PULSEMIN;
                }
                else if (columnHeaderText == "R")
                {
                    vMax = this.m_Monitoring.BREATHMAX;
                    vMin = this.m_Monitoring.BREATHMIN;
                }

                if (!doubleValueInScope(vMax, vMin, double.Parse(cellValue), true))
                {
                    vCell.Style.ForeColor = Color.Red;
                    if (!m_exceptionRows.Exists(index => index.Equals(vCell.RowIndex)))
                        m_exceptionRows.Add(vCell.RowIndex);
                }
                else
                {
              
                    vCell.Style.ForeColor = Color.FromArgb(0, 0, 0);
                }
            }
        }
        private void CheckAllCellException()
        {
            m_exceptionRows.Clear();    //清空异常行
            int vRowCount = this.dgv_Tempreturelist.Rows.Count;
            for (int i = 0; i < vRowCount; i++)
            {
                for (int j = 0; j <  dgv_Tempreturelist.Columns.Count; j++)
                {
                    CheckCellException(this.dgv_Tempreturelist.Rows[i].Cells[j]);
                }
            }
        }

        /// <summary>
        /// 获取监控值
        /// </summary>
        private void GetMoniter()
        {
            string vSql = "select * from T_TEMPERATURE_MONITORING";
            DataSet vDsmoniter = App.GetDataSet(vSql);
            if (vDsmoniter.Tables.Count > 0 && vDsmoniter.Tables[0] != null && vDsmoniter.Tables[0].Rows!= null && vDsmoniter.Tables[0].Rows.Count > 0)
            {
                m_Monitoring = ObjectHelper.Convert<TemperatureMonitoring>(vDsmoniter.Tables[0].Rows[0]);
            }
        }

        /// <summary>
        /// 列表初始化
        /// </summary>
        public void Init(string sTemplateType)
        {
            m_updateRows.Clear();
            m_exceptionRows.Clear();

            //录入时间点
            m_Times = tempetureDataComm.GetTemperatureWriteTime(sTemplateType);

            Dictionary<string, string> vDicTime = new Dictionary<string, string>();

            foreach (string time in m_Times)
            {
                string hm = time;
                if (hm == "24:00")
                {
                    hm = "00:00";
                }
                string vKey = string.Format("Time_{0}", hm);
                string vValue = time; ;
                vDicTime.Add(vKey, vValue);
            }

            //生命体征大项
            if (_templateType == tempetureDataComm.TEMPLATE_CHILD)
            {
                m_DicTPR = new Dictionary<string, string>() {
                   {"T","腋温"},
                   {"P","心率"},
                   {"R","呼吸次数"}
                };
            }
            else
            {
                m_DicTPR = new Dictionary<string, string>() {
                   {"T","腋温"},
                   {"P","脉搏"},
                   {"R","呼吸次数"}
                };
            }
            //基础显示信息
            Dictionary<string, string> vDicBaseShow = new Dictionary<string, string>() {
                {"Id","编号"},
                {"Bed","床位"},
                {"PatientName","姓名"},
                {"zyts","住院\r\n天数"},
                {"dy","打印"},
                {"IsEdit","编辑"}
            };

            //模板共有的部分
            Dictionary<string, string> vDicCommon = new Dictionary<string, string>() {
                //{"小便次数","小便\r\n次数"}
                {"血压","血压"},
                {"总入量","总入量"},
                {"总出量","总出量"},
                //{"引流量","引流量"},
                {"体重","体重"},
                 {"身高","身高"}
            };

            //普通体温单模板，多出列
            Dictionary<string, string> vDicCommon1 = new Dictionary<string, string>() {
                {"大便次数","大便\r\n次数"}
            };

            //新生儿体温单模板，多出列
            Dictionary<string, string> vDicCommon2 = new Dictionary<string, string>()
            {
                {"输入量","输入量"},
                {"口入量","口入量"},
                {"尿量","尿量"},
                 {"大便次数","大便\r\n次数"},
                {"大便量","大便量"}
            };

            
            //基础显示信息列外的额外显示列vDicOtherShow
            Dictionary<string, string> vDicOtherShow = null;
            if (sTemplateType == tempetureDataComm.TEMPLATE_NORMAL)
            {
                m_DicSaveAsDayColumn = AddDic(vDicCommon, vDicCommon1);
            }
            else
            {
                m_DicSaveAsDayColumn = AddDic(vDicCommon, vDicCommon2);
            }

            vDicOtherShow = AddDic(vDicTime, m_DicSaveAsDayColumn);
            //血压子项,此项不加到vDicOtherShow中
            Dictionary<string, string> vDicSubBP = new Dictionary<string, string>()
            {
                { "血压1","早"},
                { "血压2","晚"}
            };
            m_DicSaveAsDayColumn = AddDic(m_DicSaveAsDayColumn, vDicSubBP);
            //重新组织显示顺序(把vDicOtherShow插入到vDicBaseShow的调整位置， 返回所有显示列)
            m_vDicAllShow = AddDic(vDicBaseShow, vDicOtherShow, "PatientName");
            
            //创建表头
            TreeView trHead = new TreeView();
            AddNotes(trHead.Nodes, m_vDicAllShow);

            //添加到血压父节点
            TreeNode[] vBpNodes = trHead.Nodes.Find("血压", false);
            if (vBpNodes.Length > 0 && vBpNodes[0] != null)
            {
                AddNotes(vBpNodes[0].Nodes, vDicSubBP);
                m_vDicAllShow = AddDic(m_vDicAllShow, vDicSubBP, "血压");
            }

            //
            //温度节点下添加子节点
            Dictionary<string, string> vDicAllTPR = new Dictionary<string, string>();
            Dictionary<string, string> vDicTimeSubTPR = new Dictionary<string, string>();
            foreach (var time in vDicTime)
            {
                //首先找到父节点
                TreeNode[] vNodes = trHead.Nodes.Find(time.Key, false);
                if(vNodes.Length > 0 && vNodes[0] != null)
                {
                    vDicTimeSubTPR.Clear();
                    //在相应的录入时间点下，添加子项TPR
                    foreach (var TPR in m_DicTPR)
                    {

                        string key = String.Format("{0}_{1}", TPR.Key, time.Key.Split('_')[1]);
                        string value = TPR.Key;
                        vDicTimeSubTPR.Add(key, value);
                    }
                    AddNotes(vNodes[0].Nodes, vDicTimeSubTPR);
                    vDicAllTPR = AddDic(vDicAllTPR, vDicTimeSubTPR);
                }
            }
            m_vDicAllShow = AddDic(m_vDicAllShow, vDicAllTPR, "PatientName");
            InitGridColumns(m_vDicAllShow, vDicBaseShow, m_DicTPR);  //创建列项
            
            dgv_Tempreturelist.myColHeaderTreeView = trHead;

            this.dgv_Tempreturelist.AllowUserToAddRows = false;
            this.dgv_Tempreturelist.AutoGenerateColumns = false;
            lblDatePriview.Text = dtpDate.Value.AddDays(-1).ToShortDateString() + "<<";
            lblDateNext.Text = ">>" + dtpDate.Value.AddDays(1).ToShortDateString();
        }

       /// <summary>
       /// 初始化表头列项
       /// </summary>
       /// <param name="vDic"></param>
       /// <param name="vDicReadOnly"></param>
       /// <param name="vDicTPR"></param>
        private void InitGridColumns(Dictionary<string, string> vDic, Dictionary<string, string>vDicReadOnly, Dictionary<string, string> vDicTPR)
        {
            this.dgv_Tempreturelist.Columns.Clear();
           // dgv_Tempreturelist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;// 设定包括Header和所有单元格的列宽自动调整
            foreach (var item in vDic)
            {
                if (item.Key.ToUpper() == "DY")
                {
                    string vColName = string.Format("Col_{0}", item.Key.ToUpper());
                    DataGridViewImageColumn vColumn = new DataGridViewImageColumn();
                    vColumn.DataPropertyName = item.Key.ToUpper();
                    vColumn.HeaderText = item.Value;
                    vColumn.Image = TempertureEditor.Properties.Resources.ptRowTipIcon;
                    vColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
                    vColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
                    vColumn.Name = vColName;
                    vColumn.Width = 30;
                    vColumn.MinimumWidth = 5;
                   
                    this.dgv_Tempreturelist.Columns.Add(vColumn);
                }
                else if (!item.Key.ToUpper().Contains("TIME") && item.Key != "血压")
                {
                    string vColName = string.Format("Col_{0}", item.Key.ToUpper());
                    DataGridViewTextBoxColumn vColumn = new DataGridViewTextBoxColumn();
                    vColumn.DataPropertyName = item.Key.ToUpper();
                    vColumn.HeaderText = item.Value;
                    vColumn.Name = vColName;
                    
                    if (item.Value == "姓名" || item.Value == "床位")
                    {
                        vColumn.Width = 60;
                    }
                    else if (item.Value.Length == 3)
                    {
                        vColumn.Width = 40;
                    }
                    else if (item.Value.ToUpper() == "早" || item.Value.ToUpper() == "晚")
                    {
                        vColumn.Width = 50;
                    }
                    else 
                    {
                        vColumn.Width = 32;
                    }
                    
                    vColumn.MinimumWidth = 5;
                    if (item.Key.ToUpper() == "ID" || item.Key.ToUpper() == "ISEDIT")
                        vColumn.Visible = false;

                    if (vDicReadOnly.ContainsKey(item.Key))
                        vColumn.ReadOnly = true;
                    else
                        vColumn.ReadOnly = false;
                    this.dgv_Tempreturelist.Columns.Add(vColumn);
                }
            }

            /*
            Dictionary<string, bool> dicState = new Dictionary<string, bool>();
            dgv_Tempreturelist.Visible = false;
            DataGridView dgv = new DataGridView();
            dgv.Dock = DockStyle.Fill;
            pn_Content.Controls.Add(dgv);
            DgvTools.InitDgvDoubleInputColumn(dgv, DataGridViewContentAlignment.MiddleCenter, "Hello", "hello", "hello", "world", "F2", true, false, true, false, Color.White, ref dicState);
            dgv.Rows.Add(5);
            */
        }

        public void Query()
        {
            string pKey = "脉搏";
            if (_templateType == tempetureDataComm.TEMPLATE_CHILD)
            {
                pKey = "心率";
            }

            DateTime curdate = dtpDate.Value.Date;
            StringBuilder vSb = new StringBuilder();

            vSb.Append(@"select ");
            vSb.Append("a.id as ID,");
            vSb.Append("a.sick_bed_no as BED,");
            vSb.Append("a.patient_name as PATIENTNAME,");
            vSb.Append("a.sick_area_name,");
            vSb.Append("a.section_name,");
            //vSb.Append("round(to_number(To_date('@CurrentDate','yyyy-mm-dd hh24:mi:ss') - Cast(a.in_time As Date))) as ZYTS,");
            vSb.Append("(to_number(To_date('@CurrentDate','yyyy-mm-dd  hh24:mi:ss') - trunc(Cast(a.in_time As Date)) + 1)) as ZYTS,");
            vSb.Append("wmsys.wm_concat(to_char(ttr1.measure_time,'yyyy-mm-dd hh24:mi:ss')) as measure_time,");
            vSb.Append("wmsys.wm_concat(ttr1.valtype) as valtype,");
            vSb.Append("wmsys.wm_concat(nvl(ttr1.t_val,' ')) as t_val ");
            vSb.Append("from t_in_patient a ");
            vSb.Append("inner join t_inhospital_action b on a.id=b.patient_id and b.next_id=0 and b.action_type<>'出区' ");
            vSb.Append("LEFT JOIN t_temperature_record ttr1 on ttr1.patient_id = a.id and ttr1.measure_time between to_date('@StartTime','yyyy-MM-dd hh24:mi:ss') and " +
                       "to_date('@EndTime','yyyy-MM-dd hh24:mi:ss') and ttr1.template_type='@TemplateType' ");
            vSb.Append("where  a.sick_area_id= @SickAreaID ");

            if (_splitChildPid != "")
            {
                if (_templateType == tempetureDataComm.TEMPLATE_CHILD)
                    vSb.Append("and a.pid like '%*" + _splitChildPid + "%' escape '*' ");
                else
                    vSb.Append("and a.pid  not like '%*" + _splitChildPid + "%' escape '*' ");
            }
            vSb.Append(@"group by a.id,a.sick_bed_no,a.patient_name,a.in_time,a.sick_area_name,a.section_name " +
                        "order by case when regexp_like(a.sick_bed_no,'^[[:digit:]]+$') then to_number(a.sick_bed_no) else 999 end,a.sick_bed_no");

            string vSql = GetSql(vSb.ToString(), new Dictionary<string, object>() {
                {"SickAreaID",this.m_SickAreaID},
                {"CurrentDate",curdate.ToString("yyyy-MM-dd HH:mm:ss")},
                {"StartTime",curdate.ToString("yyyy-MM-dd ") +  " 00:00:00"},
                {"EndTime",curdate.ToString("yyyy-MM-dd ") + " 23:59:59"},
                {"TemplateType", _templateType}
            });     
            DataTable vInfo = App.GetDataSet(vSql).Tables[0];

            if (vInfo.Rows.Count > 0)
            {
                this.m_SickareaName = RowHelper.GetString(vInfo.Rows[0], "sick_area_name");
                this.m_SectionName = RowHelper.GetString(vInfo.Rows[0], "section_name");
            }
            //解析字段值
            List<string> vCols = new List<string>();
            foreach (var item in m_vDicAllShow)
            {
                vCols.Add(item.Key.ToUpper());
            }
            RowHelper.AddColumn(vInfo, vCols.ToArray());

            for (int i = 0; i < vInfo.Rows.Count; i++)
            {
                DataRow vRow = vInfo.Rows[i];
                string measure_time = vRow["measure_time"].ToString();
                string valtype = vRow["valtype"].ToString();
                string t_val = vRow["t_val"].ToString();
                string[] vTimes = measure_time.Split(',');
                string[] vTypes = valtype.Split(',');
                string[] vValues = t_val.Split(',');
                if (!string.IsNullOrEmpty(measure_time))
                {
                    for (int j = 0; j < vTimes.Length; j++)
                    {
                        if (vTimes[j] == null || vTimes[j].ToString() == "")
                            continue;
                        DateTime dt = Convert.ToDateTime(vTimes[j].ToString());
                        string T = "T_" + dt.ToString("HH:mm");
                        string P = "P_" + dt.ToString("HH:mm");
                        string R = "R_" + dt.ToString("HH:mm");

                        if (vInfo.Columns.Contains(T) && vTypes[j].Contains("腋温"))
                            vRow[T] = vValues[j];
                        else if (vInfo.Columns.Contains(P) && vTypes[j].Contains(pKey))
                            vRow[P] = vValues[j];
                        else if (vInfo.Columns.Contains(R) && vTypes[j].Contains("呼吸"))
                            vRow[R] = vValues[j];
                        else if (vInfo.Columns.Contains(vTypes[j]))
                        {
                            vRow[vTypes[j]] = vValues[j];
                        }

                    }
                }
            }
            //移除多余的列
            dgv_Tempreturelist.DataSource = vInfo;
            CheckAllCellException();
        }
        private void Save()
        {
            if (m_updateRows.Count < 1)
            {
                App.Msg("请至少修改一行数据才能进行保存！");
                return;
            }

            string ctype = "";
            string l_val = "";
            string lsql = "";
            string tmpVal = "";
            List<string> sqls = new List<string>();

            DateTime dtGridNow = DateTime.Parse(dtpDate.Value.Date.ToString("yyyy-MM-dd ") + App.GetSystemTime().ToString("HH:mm"));
            DateTime dtMeasure = tempetureDataComm.GetInsertDateTime(dtGridNow, _templateType);     //通过dtGridNow,获取最近的录入时间点
            DateTime dtDayMeasure = Convert.ToDateTime(dtpDate.Value.Date.ToString("yyyy-MM-dd"));
            try
            {
                foreach (int i in m_updateRows)
                {
                    /*
                    //当行数据修改过才进行保存
                    bool IsEdit = StringHelper.GetBoolean(this.dgv_Tempreturelist.Rows[i].Cells["Col_IsEdit"].Value, false);
                    if (!IsEdit)
                    {
                        continue;
                    }
                    */
                    int vID = StringHelper.GetInt(this.dgv_Tempreturelist.Rows[i].Cells["Col_ID"].Value);
                    string vSickBedNo = StringHelper.GetString(this.dgv_Tempreturelist.Rows[i].Cells["Col_BED"].Value);

                  

                    for (int j = 0; j < dgv_Tempreturelist.Columns.Count; j++)
                    {
                        DataGridViewCell vCell = this.dgv_Tempreturelist.Rows[i].Cells[j];
                        string columnHeaderText = vCell.OwningColumn.HeaderText;

                        if (columnHeaderText == "T" || columnHeaderText == "P" || columnHeaderText == "R")  //按时间点录入数据
                        {
                            string[] strs = vCell.OwningColumn.DataPropertyName.Split('_');
                            
                            string dtStr = dtpDate.Value.Date.ToString("yyyy-MM-dd") + " " + strs[1];
                            ctype = DictionaryHelper.Get(m_DicTPR, strs[0]);
                            lsql = "delete from t_temperature_record where patient_id=" + vID.ToString() +
                                       " and template_type='" + _templateType + "' and to_char(MEASURE_TIME,'yyyy-MM-dd hh24:mi')='" + dtStr + "' and VALTYPE='" + ctype + "'";
                            sqls.Add(lsql);
                            tmpVal = StringHelper.GetString(vCell.Value).Trim();
                            if (tmpVal != "")
                            {
                                l_val = tmpVal;
                                sqls.Add(tempetureDataComm.GetInsertSql(vID, vSickBedNo, m_SickareaName, m_SectionName, DateTime.Parse(dtStr), ctype, l_val, DateTime.Parse(dtStr), _templateType, m_OperateUserId));
                            }

                        }
                        else if (m_DicSaveAsDayColumn.ContainsKey(vCell.OwningColumn.DataPropertyName))//按天录入数据
                        {
                            ctype = vCell.OwningColumn.DataPropertyName;
                            lsql = "delete from t_temperature_record where patient_id=" + vID.ToString() +
                                       " and template_type='" + _templateType + "' and to_char(MEASURE_TIME,'yyyy-MM-dd')='" + dtpDate.Value.Date.ToString("yyyy-MM-dd") + "' and VALTYPE='" + ctype + "'";
                            sqls.Add(lsql);
                            tmpVal = StringHelper.GetString(vCell.Value).Trim();
                            if (tmpVal != "")
                            {
                                l_val = tmpVal;
                                sqls.Add(tempetureDataComm.GetInsertSql(vID, vSickBedNo, m_SickareaName, m_SectionName, dtDayMeasure, ctype, l_val, dtMeasure, _templateType, m_OperateUserId));
                            }
                        }
                       
                    }

                }
                if (sqls.Count > 0)
                {
                    int count = App.ExecuteBatch(sqls.ToArray());
                    if (count > 0)
                    {
                        m_updateRows.Clear();
                        App.Msg("操作成功！");
                        Query();
                    }
                    else
                    {
                        App.Msg("操作失败！");
                    }
                }
            }
            catch (Exception ex)
            {
                App.MsgErr("操作失败：" + ex.Message);
            }
        }
        #endregion

        #region 页面事件

        private void ucTempretureList_Load(object sender, EventArgs e)
        {          
            GetMoniter();       //获取质控监测数据异常值范围   
            dtpDate.Value = App.GetSystemTime();
           // Query();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Save();
        }
        
        private void btnTemperaturePaint_Click(object sender, EventArgs e)
        {
            MultiColHeaderDgv printTempreturelist = dgv_Tempreturelist;
            /*
            MultiColHeaderDgv printTempreturelist = new MultiColHeaderDgv();

            int count = dgv_Tempreturelist.Columns.Count;
            
            DataGridViewColumn[] columns = new DataGridViewColumn[count];
            dgv_Tempreturelist.Columns.CopyTo(columns, 0);
            printTempreturelist.Columns.AddRange(columns);
          
            printTempreturelist.DataSource = dgv_Tempreturelist.DataSource;
            */

            printTempreturelist.Columns["Col_DY"].Visible = false;
            printDocument1.DocumentName = "打印记录体温单";
            printDocument1.PrinterSettings = printDialog1.PrinterSettings;
            printDocument1.DefaultPageSettings = printDialog1.PrinterSettings.DefaultPageSettings;
            printDocument1.DefaultPageSettings.Margins = new Margins(30, 30, 30, 30);
            dataGridViewPrint = new DataGridViewPrint(printTempreturelist, printDocument1, true, false, "", new Font("黑体", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Blue, false);

            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument1;
            printPreviewDialog.ShowDialog();
            printTempreturelist.Columns["Col_DY"].Visible = true;
        }

        private void btnExTemperaturePaint_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
            return;
            MultiColHeaderDgv printTempreturelist = dgv_Tempreturelist;
            /*
            MultiColHeaderDgv printTempreturelist = new MultiColHeaderDgv();

            int count = dgv_Tempreturelist.Columns.Count;
            DataGridViewColumn[] columns = new DataGridViewColumn[count];

            dgv_Tempreturelist.Columns.CopyTo(columns, 0);
            printTempreturelist.Columns.AddRange(columns);
            printTempreturelist.DataSource = dgv_Tempreturelist.DataSource;
            */
            printTempreturelist.Columns["Col_DY"].Visible = false;
            
            CheckAllCellException();

            foreach (DataGridViewRow row in dgv_Tempreturelist.Rows)
            {
                if (m_exceptionRows.Exists(exception => exception.Equals(row.Index)))
                    row.Visible = true;
                else
                    row.Visible = false;
            }
            printDocument1.DocumentName = "打印记录体温单";
            printDocument1.PrinterSettings = printDialog1.PrinterSettings;
            printDocument1.DefaultPageSettings = printDialog1.PrinterSettings.DefaultPageSettings;
            printDocument1.DefaultPageSettings.Margins = new Margins(30, 30, 30, 30);
            dataGridViewPrint = new DataGridViewPrint(printTempreturelist, printDocument1, true, false, "", new Font("黑体", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Blue, false);
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument1;
            printPreviewDialog.ShowDialog();

            printTempreturelist.Columns["Col_DY"].Visible = true;
            foreach (DataGridViewRow row in dgv_Tempreturelist.Rows)
            {
                row.Visible = true;
            }
        }

        private void lblDatePriview_Click(object sender, EventArgs e)
        {
            dtpDate.Value = Convert.ToDateTime(dtpDate.Value.AddDays(-1));
            lblDatePriview.Text = dtpDate.Value.AddDays(-1).ToShortDateString() + "<<";
        }

        private void lblDateNext_Click(object sender, EventArgs e)
        {
            dtpDate.Value = Convert.ToDateTime(dtpDate.Value.AddDays(1));
            lblDateNext.Text = ">>" + dtpDate.Value.AddDays(1).ToShortDateString();
        }


        private void dgv_Tempreturelist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgv_Tempreturelist.Rows[e.RowIndex].Cells[e.ColumnIndex].OwningColumn.HeaderText == "打印")
            {
                if (m_updateRows.Count > 0)
                {
                    App.Msg("有数据修改，请先保存！");
                    return;
                }

                InPatientInfo info = tempetureDataComm.GetInpatientInfoByPid(dgv_Tempreturelist.Rows[e.RowIndex].Cells["Col_ID"].Value.ToString());

                ucTempraute tp = new ucTempraute(info, _templateType, false);
                tp.Dock = DockStyle.Fill;
                Form frm = new Form();
                frm.Controls.Add(tp);
                frm.WindowState = FormWindowState.Maximized;
                frm.ShowDialog();
            }

        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            if (m_updateRows.Count > 0)
            {
                App.Msg("有数据修改，请先保存！");
                return;
            }
            lblDatePriview.Text = dtpDate.Value.AddDays(-1).ToShortDateString() + "<<";
            lblDateNext.Text = ">>" + dtpDate.Value.AddDays(1).ToShortDateString();

            this.Query();
        }

        /*
        private void dgv_Tempreturelist_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgv_Tempreturelist.CurrentCell.OwningColumn.Name.Contains("Col_T_"))
            {
                string AstrictChar = "0123456789";
                if ( (((DataGridViewCell)sender).Value == null || ((DataGridViewCell)sender).Value.ToString() == "") && (Keys)(e.KeyChar) == Keys.Delete)
                {
                    e.Handled = true;
                    return;
                }

                if ((Keys)(e.KeyChar) == Keys.Delete)
                {
                    if ((sender as TextBox).Text.Split('.').Length >= 2)
                    {
                        e.Handled = true;
                        return;
                    }
                }

                if ((Keys)(e.KeyChar) == Keys.Back || (Keys)(e.KeyChar) == Keys.Delete)
                {
                    return;
                }

                if (AstrictChar.IndexOf(e.KeyChar.ToString()) == -1)
                {
                    e.Handled = true;
                    return;
                }
            }
            else if (dgv_Tempreturelist.CurrentCell.OwningColumn.Name.Contains("Col_P_") || dgv_Tempreturelist.CurrentCell.OwningColumn.Name.Contains("Col_R_"))
            {
                string AstrictChar = "0123456789";
                if ((((DataGridViewCell)sender).Value == null || ((DataGridViewCell)sender).Value.ToString() == "") && (Keys)(e.KeyChar) == Keys.Delete)
                {
                    e.Handled = true;
                    return;
                }
                if ((Keys)(e.KeyChar) == Keys.Back)
                {
                    return;
                }

                if (AstrictChar.IndexOf(e.KeyChar.ToString()) == -1)
                {
                    e.Handled = true;
                    return;
                }
            }
        }
        */

        private void dgv_Tempreturelist_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            m_cellOldValue = StringHelper.GetString(this.dgv_Tempreturelist.CurrentCell.Value);
        }
        private void dgv_Tempreturelist_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string cellValue = StringHelper.GetString(this.dgv_Tempreturelist.CurrentCell.Value);
            string columnHeaderText = dgv_Tempreturelist.CurrentCell.OwningColumn.HeaderText;
            string msg = "";

            if (!string.IsNullOrEmpty(cellValue))
            {
                if (columnHeaderText == "T")
                {
                    float f = 0;
                    if (!float.TryParse(cellValue, out f))
                    {
                        App.Msg("患者体温必须为数值型!");
                        this.dgv_Tempreturelist.CurrentCell.Value = m_cellOldValue;
                        return;
                    }
                    if (IsNeedRemind("T", f.ToString(), ref msg))
                    {
                        App.Msg(msg);
                        this.dgv_Tempreturelist.CurrentCell.Value = m_cellOldValue;
                        return;
                    }
                }
                else if (columnHeaderText == "P")
                {
                    int i = 0;
                    if (!int.TryParse(cellValue, out i))
                    {
                        App.Msg("患者脉搏或心率必须为整数!");
                        this.dgv_Tempreturelist.CurrentCell.Value = m_cellOldValue;
                        return;
                    }
                    if (IsNeedRemind("P", i.ToString(), ref msg))
                    {
                        App.Msg(msg);
                        this.dgv_Tempreturelist.CurrentCell.Value = m_cellOldValue;
                        return;
                    }

                }
                else if (columnHeaderText == "R")
                {
                    int i = 0;
                    if (!int.TryParse(cellValue, out i))
                    {
                        App.Msg("患者呼吸必须为整数!");
                        this.dgv_Tempreturelist.CurrentCell.Value = m_cellOldValue;
                        return;
                    }
                    if (IsNeedRemind("R", i.ToString(), ref msg))
                    {
                        App.Msg(msg);
                        this.dgv_Tempreturelist.CurrentCell.Value = m_cellOldValue;
                        return;
                    }
                }
            }

            //确认监测数据异常值，红色显示提醒
            CheckCellException(this.dgv_Tempreturelist.CurrentCell);

            if (cellValue != m_cellOldValue)
            {
                //更改行编辑标志
                int vCurRowIndex = this.dgv_Tempreturelist.CurrentCell.RowIndex;
                this.m_updateRows.Add(vCurRowIndex);
                //this.dgv_Tempreturelist.Rows[vCurRowIndex].Cells["Col_IsEdit"].Value = true;
            }
        }

        private void dgv_Tempreturelist_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_Tempreturelist_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void dgv_Tempreturelist_MouseDoubleClick(object sender, MouseEventArgs e)
        {
          
        }
        #endregion

        private void dgv_Tempreturelist_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_Tempreturelist.Columns[e.ColumnIndex].HeaderText == "打印")
            {
                if (Convert.ToInt32(dgv_Tempreturelist.Rows[e.RowIndex].Cells["Col_ZYTS"].Value) % 7 == 0)
                {
                    e.Value = Properties.Resources.ptRowTipIcon;
                }
                else
                {
                    e.Value = Properties.Resources.ptRowIcon;
                }
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
            //true表示还有数据行没有打印完,则继续打
            bool more = dataGridViewPrint.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;
        }

        private void dgv_Tempreturelist_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_Tempreturelist_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != -1)
                return;
            if (m_updateRows.Count > 0)
            {
                App.Msg("有数据修改，请先保存！");
                return;
            }


            InPatientInfo info = tempetureDataComm.GetInpatientInfoByPid(dgv_Tempreturelist.Rows[e.RowIndex].Cells["Col_ID"].Value.ToString());

            ucTempraute tp = new ucTempraute(info, _templateType, true);

            tp.Dock = DockStyle.Fill;
            Form frm = new Form();
            frm.Controls.Add(tp);
            frm.WindowState = FormWindowState.Maximized;
            frm.ShowDialog();
            //App.UsControlStyle(tp);
            //App.AddNewBusUcControl(tp, dgv_Tempreturelist.Rows[dgv_Tempreturelist.CurrentCell.RowIndex].Cells["Col_PATIENTNAME"].ToString() + "-体温单信息");
            Query();    //进入单录后返回时，数据可能被编辑，自动刷新下群录界面。
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Query();
        }

    }
}
