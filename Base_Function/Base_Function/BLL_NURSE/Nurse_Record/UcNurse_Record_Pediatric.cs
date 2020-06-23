using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using C1.Win.C1FlexGrid;
using Base_Function.BLL_NURSE.Nereuse_record;
using System.Collections.Specialized;
using Base_Function.MODEL;
using System.Collections;
using Base_Function.BLL_NURSE.Nurse_Record.NurseItmeControls;
using System.Threading;

namespace Base_Function.BLL_NURSE.Nurse_Record
{
    public partial class UcNurse_Record_Pediatric : UserControl
    {
        /// <summary>
        /// 列名称字典
        /// 键:列索引
        /// 值:项目名称
        /// </summary>
        Dictionary<int, string> dictColumnName = new Dictionary<int, string>();
        ColumnInfo[] cols = new ColumnInfo[28];
        /// <summary>
        /// 护理记录单行对象的集合
        /// </summary>
        ArrayList nurses = new ArrayList();
        ArrayList SumNusers = new ArrayList();
        ArrayList SumNusersRecords = new ArrayList();
        
        #region 字典
        ListDictionary ldSickLevel = new ListDictionary();//病情程度
        ListDictionary ldConsciousness = new ListDictionary();//意识字典
        ListDictionary ldDuct_name = new ListDictionary();//各种管道名称字典
        ListDictionary ldDuct_values = new ListDictionary();//各种管道情况字典 
        ListDictionary ldSafenurse = new ListDictionary();//安全护理
        ListDictionary ldSkin = new ListDictionary();//皮肤
        ListDictionary ldXY = new ListDictionary();//吸氧
        ListDictionary ldNurseLevel = new ListDictionary();//护理级别
        #endregion

        #region 自定义值
        //入量自定义值
        public string pipe1 = "";
        //出量自定义值
        public string pipe2 = "";
        #endregion
        /// <summary>
        /// 诊断
        /// </summary>
        public string diagnose = "";
        /// <summary>
        /// 入量名称
        /// </summary>
        private string oldInputName = "";

        /// <summary>
        /// 当前病人
        /// </summary>
        InPatientInfo currentPatient = null;

        /// <summary>
        /// 护理记录单类型
        /// </summary>
        private string strType;

        Class_Take_over_SEQ[] Take_over_seq;

        public UcNurse_Record_Pediatric()
        {
            InitializeComponent();
        }

        public UcNurse_Record_Pediatric(InPatientInfo patient)
        {
            InitializeComponent();
            strType = "C";
            currentPatient = patient;
            Take_over_SEQ();//绑定班次
            SetCellData();//绑定单元格数据
            LoadDiagnose();
        }

        private void UcNurse_Record_Pediatric_Load(object sender, EventArgs e)
        {
            lblDatePriview.Text = App.GetSystemTime().AddDays(-1).ToShortDateString() + "<<";
            lblDateNext.Text = ">>" + App.GetSystemTime().AddDays(1).ToShortDateString();
            bindColData();
            SetDictionaryForItem();
            cboTiming_SelectedIndexChanged(sender, e);//加载统计项时间
            btnSearch_Click(sender, e);
            ShowMsg();
        }

        /// <summary>
        /// 绑定班次表
        /// </summary>
        private void Take_over_SEQ()
        {
            //DataSet ds = App.GetDataSet("select * from T_TAKE_OVER_SEQ where id<7 or id=11 order by ID asc");
            DataSet ds = App.GetDataSet("select * from T_TAKE_OVER_SEQ order by SEQ asc");
            Take_over_seq = new Class_Take_over_SEQ[ds.Tables[0].Rows.Count];
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Take_over_seq[i] = new Class_Take_over_SEQ();
                Take_over_seq[i].Id = ds.Tables[0].Rows[i]["id"].ToString();
                Take_over_seq[i].Seq = ds.Tables[0].Rows[i]["SEQ"].ToString();
                Take_over_seq[i].Begin_time = ds.Tables[0].Rows[i]["BEGIN_TIME"].ToString();
                Take_over_seq[i].End_time = ds.Tables[0].Rows[i]["END_TIME"].ToString();
                Take_over_seq[i].Begin_logic = ds.Tables[0].Rows[i]["BEGIN_LOGIC"].ToString();
                Take_over_seq[i].End_logic = ds.Tables[0].Rows[i]["END_LOGIC"].ToString();
                cboTiming.Items.Add(Take_over_seq[i]);
                cboTiming.DisplayMember = "SEQ";
            }
            if (cboTiming.Items.Count > 0)
            {
                cboTiming.SelectedIndex = 0;
            }
            //cboTiming.Text = "24小时出入量";
        }

        /// <summary>
        /// 设置项目字典
        /// </summary>
        public void SetDictionaryForItem()
        {
            dictColumnName.Add(0, "日期时间");
            dictColumnName.Add(1, "病情程度");
            dictColumnName.Add(2, "护理级别");
            dictColumnName.Add(3, "意识");
            dictColumnName.Add(4, "左");
            dictColumnName.Add(5, "右");
            dictColumnName.Add(6, "T");
            dictColumnName.Add(7, "P");
            dictColumnName.Add(8, "HR");
            dictColumnName.Add(9, "R");
            dictColumnName.Add(10, "BP");
            dictColumnName.Add(11, "血氧饱和度");
            dictColumnName.Add(12, "入量名称");
            dictColumnName.Add(13, "入量量");
            dictColumnName.Add(14, "入量自定义值");
            dictColumnName.Add(15, "大便");
            dictColumnName.Add(16, "小便");
            dictColumnName.Add(17, "出量其它");
            dictColumnName.Add(18, "出量自定义值");
            dictColumnName.Add(19, "管道名称");
            dictColumnName.Add(20, "管道情况");
            dictColumnName.Add(21, "皮肤");
            dictColumnName.Add(22, "吸氧方式");
            dictColumnName.Add(23, "吸氧流量");
            dictColumnName.Add(24, "安全护理");
            dictColumnName.Add(25, "备注");
            dictColumnName.Add(26, "签名");
        }

        #region 表格设置
        /// <summary>
        /// 绑定数据
        /// </summary>
        public void ShowData()
        {
            //SetTable();
            nurses.Clear();
            pipe1 = "";
            pipe2 = "";

            #region 数据加载
            string dateTime = dtpDate.Value.ToString("yyyy-MM-dd HH:mm");
            //or to_char(a.id)=t.item_code
            string sql_time = "select distinct to_char(t.measure_time,'yyyy-mm-dd hh24:mi') as DATETIMEVAL from T_NURSE_RECORD t where RECORD_TYPE='"+strType+"' and t.patient_Id=" + currentPatient.Id + " and to_char(t.measure_time,'yyyy-MM-dd')='" + dtpDate.Value.ToString("yyyy-MM-dd") + "' order by DATETIMEVAL asc";
            string sql_set = "select t.id,to_char(t.measure_time,'yyyy-mm-dd hh24:mi') as DATETIMEVAL,t.item_code,a.item_name,t.item_show_name,a.item_attribute,t.item_value,t.other_name,a.item_type,t.status_measure,t.creat_id,d.user_name,t.diagnose_name,PATIENT_ID from T_NURSE_RECORD t " +
                            " left join t_nurse_record_dict a on  a.item_code=t.item_code  left join T_DATA_CODE b on a.item_attribute=b.id inner " +
                            " join T_ACCOUNT_USER c on t.creat_id=c.user_id inner join T_USERINFO d on d.user_id=c.user_id where RECORD_TYPE='"+strType+"' and patient_Id=" + currentPatient.Id + " order by t.create_time asc ";
            //时间集合
            DataSet ds_time_sets = App.GetDataSet(sql_time);
            //项目集合
            DataSet ds_values_sets = App.GetDataSet(sql_set);

            DataTable dt_time = ds_time_sets.Tables[0];
            DataTable dt_sets = ds_values_sets.Tables[0];
            if (dt_time != null)
            {
                for (int i = 0; i < dt_time.Rows.Count; i++)
                {
                    string dateTimeValue = dt_time.Rows[i]["DATETIMEVAL"].ToString();

                    //常用项目数组
                    DataRow[] dr_Values = dt_sets.Select(" DATETIMEVAL='" + dateTimeValue + "'");

                    //入量
                    DataRow[] drinput = dt_sets.Select("item_show_name='入量' and DATETIMEVAL='" + dateTimeValue + "'");
                    int index = drinput.Length;
                    if (index == 0)
                    {
                        index = 1;
                    }
                    for (int j = 0; j < index; j++)
                    {
                        Class_Nurse_Record_Pediatric temp = new Class_Nurse_Record_Pediatric();
                        temp.DateTime = dateTimeValue;
                        if (drinput.Length > 0)
                        {
                            temp.Inputname = drinput[j]["item_code"].ToString();
                            temp.Inputvalue = drinput[j]["item_value"].ToString();
                            temp.Number = drinput[j]["id"].ToString();
                        }

                        for (int k = 0; k < dr_Values.Length; k++)
                        {
                            if (j == 0)//非入量项目只在第一行显示
                            {
                                if (dr_Values[k]["item_show_name"].ToString() == "病情程度")
                                {
                                    temp.Sick_level = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "护理级别")
                                {
                                    temp.Nurse_level = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "意识")
                                {
                                    temp.Consciousness = dr_Values[k]["item_code"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "左")
                                {
                                    temp.Left = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "右")
                                {
                                    temp.Right = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "T")
                                {
                                    temp.T = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "P")
                                {
                                    temp.P = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "HR")
                                {
                                    temp.HR = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "R")
                                {
                                    temp.R = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "BP")
                                {
                                    temp.Bp = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "血氧饱和度")
                                {
                                    temp.Oxygen_saturation = dr_Values[k]["item_value"].ToString();
                                }
                                //else if (dr_Values[k]["item_show_name"].ToString() == "入量")
                                //{
                                //    temp.Inputname = dr_Values[k]["item_code"].ToString();
                                //    temp.Inputvalue = dr_Values[k]["item_value"].ToString();
                                //}
                                else if (dr_Values[k]["item_show_name"].ToString() == "入量自定义值")
                                {
                                    temp.Inputother = dr_Values[k]["item_value"].ToString();
                                    pipe1 = dr_Values[k]["other_name"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "大便")
                                {
                                    temp.Shit = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "小便")
                                {
                                    temp.Urine = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "出量其它")
                                {
                                    temp.Outother = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "出量自定义值")
                                {
                                    temp.Out_item_name = dr_Values[k]["item_value"].ToString();
                                    pipe2 = dr_Values[k]["other_name"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "管道")
                                {
                                    temp.Duct_item_name = dr_Values[k]["item_code"].ToString();
                                    temp.Duct_item_values = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "皮肤")
                                {
                                    temp.Skin = dr_Values[k]["item_code"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "安全护理")
                                {
                                    temp.Safenurse = dr_Values[k]["item_code"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "吸氧")
                                {
                                    temp.Oxygen = dr_Values[k]["item_code"].ToString();
                                    temp.Oxygen_value = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "备注")
                                {
                                    temp.Nurse_result = dr_Values[k]["item_value"].ToString();
                                }
                                
                            }
                            if (j == index - 1)
                            {
                                temp.Signature = dr_Values[k]["user_name"].ToString();
                            }
                        }
                        nurses.Add(temp);
                    }
                }

                //过滤相同的时间
                string tempDateTime = null;
                Class_Nurse_Record_Pediatric[] nurse = new Class_Nurse_Record_Pediatric[nurses.Count];
                for (int i = 0; i < nurses.Count; i++)
                {
                    nurse[i] = new Class_Nurse_Record_Pediatric();
                    nurse[i] = nurses[i] as Class_Nurse_Record_Pediatric;

                    if (tempDateTime == null)
                    {
                        tempDateTime = nurse[i].DateTime;
                    }
                    else if (tempDateTime != null)
                    {
                        if (nurse[i].DateTime == tempDateTime)//相同的时间不显示
                        {
                            nurse[i].DateTime = null;
                        }
                        else
                        {
                            tempDateTime = nurse[i].DateTime;
                        }

                    }
                }
                SetTable();
                try
                {
                    if (nurse.Length != 0)
                    {
                        //nurse[nurse.Length - 1] = new Class_Nurse_Record_Pediatric();
                        App.ArrayToGrid(this.flgView, nurse, cols, 3);
                    }
                    else
                    {
                        this.flgView.Rows.Count = 3;
                    }
                }
                catch
                {
                }
                CellUnit(pipe1, pipe2);
                //this.flgView.Refresh();
                this.flgView.AutoSizeCols();
                this.flgView.AutoSizeRows();
            }

            #endregion

        }

        /// <summary>
        /// 表头设置
        /// </summary>
        private void SetTable()
        {
            
            this.flgView.Cols.Count = 28;
            this.flgView.Rows.Count = 4 + nurses.Count;
            this.flgView.Rows.Fixed = 3;
            //表头设置
            cols[0].Name = "日期时间";
            cols[0].Field = "dateTime";
            cols[0].Index = 1;
            cols[0].visible = true;

            //病情程度
            cols[1].Name = "病情程度";
            cols[1].Field = "sick_level";
            cols[1].Index = 2;
            cols[1].visible = true;

            //护理级别
            cols[2].Name = "护理级别";
            cols[2].Field = "nurse_level";
            cols[2].Index = 3;
            cols[2].visible = true;

            //意识
            cols[3].Name = "意识";
            cols[3].Field = "consciousness";
            cols[3].Index = 4;
            cols[3].visible = true;

            //瞳孔左
            cols[4].Name = "左";
            cols[4].Field = "left";
            cols[4].Index = 5;
            cols[4].visible = true;

            //瞳孔右
            cols[5].Name = "右";
            cols[5].Field = "right";
            cols[5].Index = 6;
            cols[5].visible = true;

            //体温
            cols[6].Name = "T";
            cols[6].Field = "t";
            cols[6].Index = 7;
            cols[6].visible = true;

            //脉搏
            cols[7].Name = "P";
            cols[7].Field = "p";
            cols[7].Index = 8;
            cols[7].visible = true;

            //心率
            cols[8].Name = "HR";
            cols[8].Field = "hr";
            cols[8].Index = 9;
            cols[8].visible = true;

            //呼吸
            cols[9].Name = "R";
            cols[9].Field = "r";
            cols[9].Index = 10;
            cols[9].visible = true;

            //血压
            cols[10].Name = "BP";
            cols[10].Field = "bp";
            cols[10].Index = 11;
            cols[10].visible = true;

            //血氧饱和度
            cols[11].Name = "血氧饱和度";
            cols[11].Field = "oxygen_saturation";
            cols[11].Index = 12;
            cols[11].visible = true;

            //入量名称
            cols[12].Name = "入量名称";
            cols[12].Field = "inputname";
            cols[12].Index = 13;
            cols[12].visible = true;

            //入量量
            cols[13].Name = "入量量";
            cols[13].Field = "inputvalue";
            cols[13].Index = 14;
            cols[13].visible = true;

            //入量自定义项
            cols[14].Name = "入量自定义值";
            cols[14].Field = "inputother";
            cols[14].Index = 15;
            cols[14].visible = true;

            //大便
            cols[15].Name = "大便";
            cols[15].Field = "shit";
            cols[15].Index = 16;
            cols[15].visible = true;

            //小便
            cols[16].Name = "小便";
            cols[16].Field = "urine";
            cols[16].Index = 17;
            cols[16].visible = true;

            //出量其它
            cols[17].Name = "出量其它";
            cols[17].Field = "outother";
            cols[17].Index = 18;
            cols[17].visible = true;

            //出量自定义值
            cols[18].Name = "出量自定义值";
            cols[18].Field = "out_item_name";
            cols[18].Index = 19;
            cols[18].visible = true;

            //管道名称
            cols[19].Name = "管道名称";
            cols[19].Field = "duct_item_name";
            cols[19].Index = 20;
            cols[19].visible = true;

            //管道情况
            cols[20].Name = "管道情况";
            cols[20].Field = "duct_item_values";
            cols[20].Index = 21;
            cols[20].visible = true;

            //皮肤
            cols[21].Name = "皮肤";
            cols[21].Field = "skin";
            cols[21].Index = 22;
            cols[21].visible = true;

            //吸氧
            cols[22].Name = "吸氧方式";
            cols[22].Field = "oxygen";
            cols[22].Index = 23;
            cols[22].visible = true;

            //流量
            cols[23].Name = "吸氧流量";
            cols[23].Field = "oxygen_value";
            cols[23].Index = 24;
            cols[23].visible = true;

            //安全护理
            cols[24].Name = "安全护理";
            cols[24].Field = "safenurse";
            cols[24].Index = 25;
            cols[24].visible = true;
            
            //备注
            cols[25].Name = "备注";
            cols[25].Field = "nurse_result";
            cols[25].Index = 26;
            cols[25].visible = true;

            //签名
            cols[26].Name = "签名";
            cols[26].Field = "signature";
            cols[26].Index = 27;
            cols[26].visible = true;

            cols[27].Name = "SumID";
            cols[27].Field = "Number";
            cols[27].Index = 28;
            cols[27].visible = false;
        }

        /// <summary>
        /// 单元格合并和设置 
        /// </summary>
        /// <param name="pipe1">xx入量自定义1</param>
        /// <param name="pipe2">xx出量自定义2</param>
        private void CellUnit(string pipe1, string pipe2)
        {
            this.flgView.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            this.flgView.Cols.Fixed = 0;

            C1.Win.C1FlexGrid.CellRange cr;
            cr = this.flgView.GetCellRange(0, 0, 2, 0);
            cr.Data = "日 时\r\n/\r\n期 间";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(0, 1, 2, 1);
            cr.Data = "病\r\n情\r\n程\r\n度";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(0, 2, 2, 2);
            cr.Data = "护\r\n理\r\n级\r\n别";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(0, 3, 2, 3);
            cr.Data = "意\r\n识";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(0, 4, 0, 5);
            cr.Data = "瞳  孔";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(1, 4, 2, 4);
            cr.Data = "左";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(1, 5, 2, 5);
            cr.Data = "右";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            //生命体征
            cr = this.flgView.GetCellRange(0, 6, 0, 10);
            cr.Data = "生命体征";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(1, 6, 2, 6);
            cr.Data = "T";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(1, 7, 2, 7);
            cr.Data = "P";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(1, 8, 2, 8);
            cr.Data = "HR";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(1, 9, 2, 9);
            cr.Data = "R";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(1, 10, 2, 10);
            cr.Data = "BP";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(0, 11, 2, 11);
            cr.Data = "血氧\r\n饱和\r\n度";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            //入量
            cr = this.flgView.GetCellRange(0,12, 0, 14);
            cr.Data = "入量(ml)";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(1, 12, 2, 12);
            cr.Data = "名称";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(1, 13, 2, 13);
            cr.Data = "量";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(1, 14, 2, 14);
            cr.Data = pipe1;
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);


            //出量
            cr = this.flgView.GetCellRange(0, 15, 0, 18);
            cr.Data = "出量(ml)";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(1, 15, 2, 15);
            cr.Data = "大便";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(1, 16, 2, 16);
            cr.Data = "小便";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(1, 17, 2, 17);
            cr.Data = "其它";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(1, 18, 2, 18);
            cr.Data = pipe2;
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            //各种管道
            cr = this.flgView.GetCellRange(0, 19, 0, 20);
            cr.Data = "管道";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(1, 19, 2, 19);
            cr.Data = "名称";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(1, 20, 2, 20);
            cr.Data = "情况";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(0, 21, 2, 21);
            cr.Data = "皮\r\n肤";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(0, 22, 2, 22);
            cr.Data = "吸\r\n氧";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(0, 23, 2, 23);
            cr.Data = "氧\r\n流\r\n量";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(0, 24, 2, 24);
            cr.Data = "安\r\n全\r\n护\r\n理";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(0, 25, 2, 25);
            cr.Data = "备注";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            cr = this.flgView.GetCellRange(0, 26, 2, 26);
            cr.Data = "签名";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            this.flgView.MergedRanges.Add(cr);

            flgView.Cols[1].Width = 35;
            flgView.Cols[22].Width = 35;
            flgView.Cols[25].Width = 100;

        }

        private void SetCellData()
        {
            //护理字典：927吸氧方式
            string sql_Nurse = "select item_code,item_name,item_type,item_unit from t_nurse_record_dict where item_type=927";
            DataSet ds_Nurse = App.GetDataSet(sql_Nurse);
            //数据字典：儿童意识 205       各类管道名称 203   各类管道情况 204 吸氧方式927
            string sql_Data = "select code,name,type from t_data_code where type in(196,197,203,204,927) order by id asc";
            try
            {
                DataSet ds_Data = App.GetDataSet(sql_Data);

                if (ds_Data != null&&ds_Nurse!=null)
                {
                    //意识
                    DataRow[] dr = ds_Data.Tables[0].Select("type='196'");
                    for (int i = 0; i < dr.Length; i++)
                    {
                        ldConsciousness.Add(dr[i]["code"].ToString(), dr[i]["name"].ToString());
                    }
                    ldConsciousness.Add("nul", " ");
                    //吸氧方式
                    dr = ds_Nurse.Tables[0].Select("item_type='927'");
                    for (int i = 0; i < dr.Length; i++)
                    {
                        ldXY.Add(dr[i]["item_code"].ToString(), dr[i]["item_name"].ToString());
                    }
                    ldXY.Add("nul", " ");
                    //病情程度
                    ldSickLevel.Add("0", "病危");
                    ldSickLevel.Add("1", "病重");
                    ldSickLevel.Add("2", "一般");
                    ldSickLevel.Add("nul", " ");
                    //护理级别
                    //ldNurseLevel.Add("0", "I");
                    //ldNurseLevel.Add("1", "II");
                    //ldNurseLevel.Add("2", "III");
                    //ldNurseLevel.Add("3", "特");
                    //ldNurseLevel.Add("nul", " ");
                    //护理级别
                    dr = ds_Data.Tables[0].Select("type='197'");
                    for (int i = 0; i < dr.Length; i++)
                    {
                        ldNurseLevel.Add(dr[i]["code"].ToString(), dr[i]["name"].ToString());
                    }
                    ldNurseLevel.Add("nul", " ");
                    //安全护理
                    ldSafenurse.Add("0", "√");;
                    ldSafenurse.Add("nul", " ");
                    //皮肤
                    ldSkin.Add("0", "√");
                    ldSkin.Add("1", "×");
                    ldSkin.Add("nul", " ");
                }

            }
            catch (Exception ex)
            {
                App.Msg("注意:儿科护理记录单数据字典加载失败!");
            }
        }

        /// <summary>
        /// 绑定表格数据
        /// </summary>
        private void bindColData()
        {
            try
            {
                //病情程度
                this.flgView.Cols[1].DataMap = ldSickLevel;
                //护理级别
                this.flgView.Cols[2].DataMap = ldNurseLevel;
                //意识
                this.flgView.Cols[3].DataMap = ldConsciousness;

                //吸氧方式
                this.flgView.Cols[22].DataMap = ldXY;

                //皮肤
                this.flgView.Cols[21].DataMap = ldSkin;

                //安全护理
                this.flgView.Cols[24].DataMap = ldSafenurse;


            }
            catch
            { }
        }
        #endregion

        #region 打印排版设置
        /// <summary>
        /// 根据打印时需要到单元格宽度换行
        /// </summary>
        /// <param name="ds"></param>
        public DataSet ReSetPrintDataSet(DataSet ds)
        {
            ArrayList DataRows = new ArrayList();          
            int maxcount = 0;
            string sql_time = "select distinct to_char(t.measure_time,'yyyy-mm-dd hh24:mi') as DATETIMEVAL from T_NURSE_RECORD t where t.patient_Id=" + currentPatient.Id + " and RECORD_TYPE='" + strType + "' order by DATETIMEVAL asc";
            DataSet ds_Time = App.GetDataSet(sql_time);
            if (ds_Time != null)
            {
                for (int i = 0; i < ds_Time.Tables[0].Rows.Count; i++)
                {
                    ArrayList drDatarows = new ArrayList();
                    for (int i1 = 0; i1 < ds.Tables[0].Rows.Count; i1++)
                    {
                        if (!ds.Tables[0].Rows[i1]["inputname"].ToString().Contains("小结") &&
                           !ds.Tables[0].Rows[i1]["inputname"].ToString().Contains("出入量") &&
                           !ds.Tables[0].Rows[i1]["inputname"].ToString().Contains("总结"))
                        {

                            if (ds.Tables[0].Rows[i1]["datetime"].ToString() == ds_Time.Tables[0].Rows[i]["datetimeval"].ToString())
                            {
                                drDatarows.Add(ds.Tables[0].Rows[i1]);
                            }
                        }
                    }

                    DataRow[] drArray = new DataRow[drDatarows.Count];
                    for (int i1 = 0; i1 < drDatarows.Count; i1++)
                    {
                        drArray[i1] = (DataRow)drDatarows[i1];
                    }
                    if (drArray.Length != 0)
                    {
                        //计算备注换行
                        int rownurseresult = 33;//打印时备注显示的字符个数
                        List<string> nurseresultlist = new List<string>();
                        
                        string signature = "";
                        maxcount = drArray.Length;
                        if (drArray[0]["nurse_result"] != null && drArray[0]["nurse_result"].ToString().Length>0)
                        {
                            GetRowNurseResult(drArray[0]["nurse_result"].ToString(), rownurseresult, ref nurseresultlist);
                            maxcount = (maxcount > nurseresultlist.Count ? maxcount : nurseresultlist.Count);
                        }
                        for (int j = 0; j < maxcount; j++)
                        {
                            //备注自动换行
                            if (j <= drArray.Length - 1)
                            {
                                //清空签名
                                if (drArray[j]["Signature"].ToString() != "")
                                {
                                    signature = drArray[j]["Signature"].ToString();
                                    drArray[j]["Signature"] = "";
                                }
                                if (j <= nurseresultlist.Count - 1)
                                    drArray[j]["nurse_result"] = nurseresultlist[j];
                                if (j == maxcount - 1)
                                    drArray[j]["Signature"] = signature;
                                DataRows.Add(drArray[j]);
                            }
                            else
                            {
                                if (j == maxcount - 1)
                                {
                                    DataRow dr = ds.Tables[0].NewRow();
                                    dr["Signature"] = signature;
                                    if (j <= nurseresultlist.Count - 1)
                                    {
                                        dr["nurse_result"] = nurseresultlist[j];
                                    }
                                    DataRows.Add(dr);
                                }
                                else
                                {
                                    DataRow dr = ds.Tables[0].NewRow();
                                    dr["Signature"] = "";
                                    if (j <= nurseresultlist.Count - 1)
                                    {
                                        dr["nurse_result"] = nurseresultlist[j];
                                    }
                                    DataRows.Add(dr);
                                }
                            }
                        }
                    }

                }
            }
            

            /*
             * 重置数据集合
             */
            DataTable dd = new DataTable();
            for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
            {
                dd.Columns.Add(ds.Tables[0].Columns[i].ColumnName);
            }

            for (int i = 0; i < DataRows.Count; i++)
            {
                DataRow temprow1 = dd.NewRow();
                for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                {

                    DataRow norow = (DataRow)DataRows[i];
                    string t = norow[ds.Tables[0].Columns[j].ColumnName].ToString();


                    if (norow[ds.Tables[0].Columns[j].ColumnName].ToString().IndexOf('@') > -1)
                    {

                        temprow1[ds.Tables[0].Columns[j].ColumnName] = norow[ds.Tables[0].Columns[j].ColumnName].ToString().Split('@')[0].ToString();
                    }
                    else
                    {
                        temprow1[ds.Tables[0].Columns[j].ColumnName] = norow[ds.Tables[0].Columns[j].ColumnName].ToString();
                    }
                }
                dd.Rows.Add(temprow1);
            }


            #region 插入汇总
            string currentTime = "";
            for (int i = 0; i < dd.Rows.Count; i++)
            {
                if (dd.Rows[i]["datetime"].ToString() != "")
                {
                    currentTime = dd.Rows[i]["datetime"].ToString();
                }
                else
                {
                    dd.Rows[i]["datetime"] = currentTime;
                }
            }

            DataRow[] drSum = ds.Tables[0].Select("inputname like '%出入量%' or inputname like '%小结%' or inputname like '%总结%'");
            for (int i = 0; i < drSum.Length; i++)
            {
                string endLogic = App.ReadSqlVal("select end_logic from T_TAKE_OVER_SEQ a inner join t_nurse_dangery_inout_sum_h b on a.id=b.seq_id where b.id=" + drSum[i]["number"].ToString(), 0, "end_logic");
                //dd.ImportRow(drSum[i]);
                DateTime sumTime = Convert.ToDateTime(drSum[i]["datetime"]);
                for (int j = 0; j < dd.Rows.Count; j++)
                {
                    DateTime itemTime = Convert.ToDateTime(dd.Rows[j]["datetime"]);
                    if (itemTime == sumTime)
                    {
                        if (endLogic == "0")
                        {
                            DataRow dr = dd.NewRow();
                            dr.ItemArray = drSum[i].ItemArray;
                            dd.Rows.InsertAt(dr, j);
                            break;
                        }
                        else
                        {
                            if (j < dd.Rows.Count - 1)
                            {
                                DateTime nextTime = Convert.ToDateTime(dd.Rows[j + 1]["datetime"]);
                                if (nextTime != itemTime)
                                {
                                    DataRow dr = dd.NewRow();
                                    dr.ItemArray = drSum[i].ItemArray;
                                    dd.Rows.InsertAt(dr, j + 1);
                                    break;
                                }
                            }
                        }
                    }
                    else if (itemTime > sumTime)
                    {
                        DataRow dr = dd.NewRow();
                        dr.ItemArray = drSum[i].ItemArray;
                        dd.Rows.InsertAt(dr, j);
                        break;
                    }
                    if (j == dd.Rows.Count - 1)
                    {
                        DataRow dr = dd.NewRow();
                        dr.ItemArray = drSum[i].ItemArray;
                        dd.Rows.InsertAt(dr, j + 1);
                        break;
                    }
                }
            }
            //dd.DefaultView.Sort = "datetime asc";
            //dd = dd.DefaultView.ToTable();
            #endregion
            #region 设置时间格式

            string tempDate = "";//日期
            string tempTime = "";//时间
            int pageRows=21;
            DataColumn dc = new DataColumn("Date");
            dd.Columns.Add(dc);
            dc = new DataColumn("Time");
            dd.Columns.Add(dc);
            //设置时间显示格式,日期相同只显示第一行日期，分相同只显示第一行分
            for (int i = 0; i < dd.Rows.Count; i++)
            {
                if (i % pageRows == 0)
                {
                    if (dd.Rows[i]["datetime"].ToString() != "")
                    {
                        DateTime currDate = Convert.ToDateTime(dd.Rows[i]["datetime"].ToString());
                        //dd.Rows[i]["datetime"] = currDate.ToString("yyyy-MM-dd HH:mm");
                        dd.Rows[i]["Date"] = currDate.ToString("yyyy-MM-dd");
                        dd.Rows[i]["Time"] = currDate.ToString("HH:mm");
                        tempDate = currDate.ToString("yyyy-MM-dd");
                        tempTime = currDate.ToString("HH:mm");
                    }
                    continue;
                }
                if (!dd.Rows[i]["inputname"].ToString().Contains("小结") &&
                    !dd.Rows[i]["inputname"].ToString().Contains("总结") &&
                    !dd.Rows[i]["inputname"].ToString().Contains("出入量"))
                {
                    if (dd.Rows[i]["datetime"].ToString() != "")
                    {
                        DateTime currDate = Convert.ToDateTime(dd.Rows[i]["datetime"].ToString());
                        if (tempDate == "")
                        {
                            //dd.Rows[i]["datetime"] = currDate.ToString("yyyy-MM-dd HH:mm");
                            dd.Rows[i]["Date"] = currDate.ToString("yyyy-MM-dd");
                            dd.Rows[i]["Time"] = currDate.ToString("HH:mm");
                            tempDate = currDate.ToString("yyyy-MM-dd");
                            tempTime = currDate.ToString("HH:mm");
                            continue;
                        }
                        if (tempDate == currDate.ToString("yyyy-MM-dd") && tempTime == currDate.ToString("HH:mm"))//日期与时间都相同，不现实
                        {
                            //dd.Rows[i]["datetime"] = "";
                            dd.Rows[i]["Date"] = "";
                            dd.Rows[i]["Time"] = "";
                        }
                        else if (tempDate == currDate.ToString("yyyy-MM-dd"))//日期相同，显示小时和分
                        {
                            //dd.Rows[i]["datetime"] = currDate.ToString("HH:mm");
                            dd.Rows[i]["Date"] = "";
                            dd.Rows[i]["Time"] = currDate.ToString("HH:mm");
                            tempTime = currDate.ToString("HH:mm");
                        }
                        else//不同日期显示日期 小时 分
                        {
                            //dd.Rows[i]["datetime"] = currDate.ToString("MM-dd HH:mm");
                            dd.Rows[i]["Date"] = currDate.ToString("yyyy-MM-dd");
                            dd.Rows[i]["Time"] = currDate.ToString("HH:mm");
                            tempDate = currDate.ToString("yyyy-MM-dd");
                            tempTime = currDate.ToString("HH:mm");
                        }
                    }
                }
                else
                {
                    if (dd.Rows[i]["datetime"].ToString() != "")
                    {
                        DateTime currDate = Convert.ToDateTime(dd.Rows[i]["datetime"].ToString());
                        //dd.Rows[i]["datetime"] = currDate.ToString("yyyy-MM-dd HH:mm");
                        dd.Rows[i]["Date"] = currDate.ToString("yyyy-MM-dd");
                        dd.Rows[i]["Time"] = currDate.ToString("HH:mm");
                        tempDate = currDate.ToString("yyyy-MM-dd");
                        tempTime = currDate.ToString("HH:mm");
                    }
                    continue;
                }
            }
            #endregion
            DataSet ds2 = new DataSet();
            ds2.Tables.Add(dd);
            return ds2;
        }

        /// <summary>
        /// 根据备注的长度返回string类型数组
        /// </summary>
        /// <param name="remark">备注内容</param>
        /// <returns></returns>
        private string[] RemarkArray(string remark)
        {

            Graphics graphics = CreateGraphics();
            SizeF sizeF = graphics.MeasureString(remark, new Font("宋体", 8));
            //备注所占行数
            int remarkRowCount = Convert.ToInt32(Math.Ceiling(sizeF.Width / (45 * 8)));//Convert.ToInt32(sizeF.Width / (28.3465 * 8)) < (sizeF.Width / (28.3465 * 8)) ? Convert.ToInt32(sizeF.Width / (28.3465 * 8)) + 1 : Convert.ToInt32(sizeF.Width / (28.3465 * 8));
            string[] strArr = new string[remarkRowCount];
            string tempperval = "";
            int index = 0;//数组递增索引
            for (int j = 0; j < remark.Length; j++)
            {
                sizeF = graphics.MeasureString(tempperval, new Font("宋体", 8));
                if (sizeF.Width <= 45 * 8)
                {
                    if (tempperval == "")
                    {
                        tempperval = remark[j].ToString();
                    }
                    else
                    {
                        tempperval += remark[j];
                    }

                    if (j == remark.Length - 1)
                    {
                        strArr[index] = tempperval;
                        index++;
                        tempperval = "";
                        //j--;
                    }
                }
                else
                {
                    strArr[index] = tempperval;
                    index++;
                    tempperval = "";
                    j--;
                }
            }

            return strArr;
        }
        /// <summary>
        /// 根据数据值算出最大行数
        /// </summary>
        /// <param name="temprow"></param>
        /// <returns></returns>
        private int MaxRowsCount(DataRow temprow)
        {
            Graphics graphics = CreateGraphics();
            int count = 0;
            double widthindex = 10;
            int MaxRowCount = 0;
            for (int i = 0; i < temprow.Table.Columns.Count; i++)
            {

                string perval = "";
                if (temprow.Table.Columns[i].ColumnName.ToLower() == "date" && temprow[i].ToString() != "")
                {

                    temprow[i] = DateTime.Parse(temprow[i].ToString()).ToString("yy/MM/dd");
                }
                for (int j = 0; j < temprow[i].ToString().Length; j++)
                {
                    if (temprow.Table.Columns[i].ColumnName.ToLower() == "remark")
                    {
                        widthindex = 9.1;
                    }


                    //if (temprow.Table.Columns[i].ColumnName.ToLower() == "temperature")
                    //{
                    //    widthindex = 1.5;
                    //}

                    //if (temprow.Table.Columns[i].ColumnName.ToLower() == "date")
                    //{

                    //    widthindex = 2;
                    //}
                    //if (temprow.Table.Columns[i].ColumnName.ToLower() == "pathograhy")
                    //{
                    //    widthindex = 6.7;
                    //}
                    //else if (temprow.Table.Columns[i].ColumnName.ToLower() == "signature")
                    //{
                    //    widthindex = 6.7;
                    //}
                    //else if (temprow.Table.Columns[i].ColumnName.ToLower() == "blood_pressure"
                    //    // || temprow.Table.Columns[i].ColumnName.ToLower() == "r_eat_item_name"
                    //    //|| temprow.Table.Columns[i].ColumnName.ToLower() == "c_item_name"
                    //    )
                    //{
                    //    widthindex = 1.5;
                    //}

                    //else if (temprow.Table.Columns[i].ColumnName.ToLower() == "r_medicine_item_name")
                    //{
                    //    widthindex = 2.6;
                    //    //continue;
                    //}
                    //else if (temprow.Table.Columns[i].ColumnName.ToLower() == "r_eat_item_name")
                    //{
                    //    widthindex = 2;
                    //}
                    string tempperval = "";

                    tempperval = perval + temprow[i].ToString()[j];

                    SizeF sizeF = graphics.MeasureString(tempperval, new Font("宋体", 8));

                    if (sizeF.Width <= widthindex * 28.3465)
                    {
                        perval = tempperval;
                        if (j == temprow[i].ToString().Length - 1)
                        {
                            if (perval.Trim() != "")
                            {
                                perval = "";
                                count++;
                            }
                        }

                    }
                    else
                    {
                        perval = "";
                        count++;
                        j = j - 1;
                    }


                }
                if (MaxRowCount < count)
                {
                    MaxRowCount = count;
                }
                count = 0;
            }
            return MaxRowCount;
        }

        string toDay = string.Empty;
        int totalIndex = 0;
        /// <summary>
        /// 绑定值
        /// </summary>
        /// <param name="temprow">需要绑定的行</param>
        /// <param name="index">索引</param>
        /// <param name="olddatarow">原始数据行</param>
        /// <returns></returns>
        private void BindVal(ref DataRow temprow, int index, DataRow olddatarow)
        {
            Graphics graphics = CreateGraphics();
            int count = 0;
            double widthindex = 10;

            for (int i = 0; i < temprow.Table.Columns.Count; i++)
            {
                string perval = "";
                for (int j = 0; j < olddatarow[i].ToString().Length; j++)
                {
                    if (olddatarow.Table.Columns[i].ColumnName.ToLower() == "remark")
                    {
                        widthindex = 9.1;
                    }

                    //if (olddatarow.Table.Columns[i].ColumnName.ToLower() == "pathograhy")
                    //{
                    //    widthindex = 6.7;
                    //}
                    ////else if (olddatarow.Table.Columns[i].ColumnName.ToLower() == "signature")
                    ////{
                    ////    widthindex = 6.7;
                    ////}
                    //else if (olddatarow.Table.Columns[i].ColumnName.ToLower() == "blood_pressure"
                    //    )
                    //{
                    //    widthindex = 1.5;
                    //}
                    //else if (olddatarow.Table.Columns[i].ColumnName.ToLower() == "r_medicine_item_name")
                    //{
                    //    widthindex = 2.4;
                    //    //continue;
                    //}

                    //else if (olddatarow.Table.Columns[i].ColumnName.ToLower() == "date")
                    //{
                    //    widthindex = 2;
                    //}
                    //else if (olddatarow.Table.Columns[i].ColumnName.ToLower() == "r_eat_item_name")
                    //{
                    //    widthindex = 2;
                    //}
                    if (temprow.Table.Columns[i].ColumnName.ToLower() != "number")//number
                    {
                        string tempperval = "";
                        //if (i == 20)
                        //{
                        //    tempperval = perval + olddatarow[i].ToString()[j];
                        //}
                        //else
                        //{
                        tempperval = perval + olddatarow[i].ToString()[j];
                        //}

                        SizeF sizeF = graphics.MeasureString(tempperval, new Font("宋体", 8));
                        if (sizeF.Width <= widthindex * 28.3465)
                        {
                            perval = tempperval;
                            if (j == olddatarow[i].ToString().Length - 1)
                            {
                                //if (i == 20)
                                //{

                                //}
                                if (perval.Trim() != "")
                                {
                                    if (count == index)
                                    {

                                        temprow[i] = perval;
                                        totalIndex++;
                                    }
                                    perval = "";
                                }
                            }
                        }
                        else
                        {
                            if (count == index)
                            {
                                if (perval.EndsWith("@"))
                                {
                                    perval = perval.Substring(0, perval.Length - 1);
                                    j = j - 1;
                                    //count--;
                                }
                                //if (i == 21)
                                //{
                                //    temprow[i] = olddatarow[i].ToString();
                                //}
                                temprow[i] = perval;
                                totalIndex++;
                            }
                            perval = "";
                            count++;
                            j = j - 1;
                        }
                    }
                }
                count = 0;
            }
        }

        /// <summary>
        /// 把备注记录按照指定长度截取
        /// </summary>
        /// <param name="strNurseResult"></param>
        /// <param name="rowlenth"></param>
        /// <returns></returns>
        private void GetRowNurseResult(string strNurseResult, int rowlenth, ref List<string> list)
        {

            int lenth = Encoding.Default.GetByteCount(strNurseResult);
            if (lenth <= rowlenth)
            {
                list.Add(strNurseResult);
            }
            else
            {
                int i = ((rowlenth > strNurseResult.Length) ? strNurseResult.Length : rowlenth);                
                while (Encoding.Default.GetByteCount(strNurseResult.Substring(0, i)) > rowlenth)
                {
                    i--;
                }
                list.Add(strNurseResult.Substring(0, i));
                strNurseResult = strNurseResult.Remove(0, i);
                GetRowNurseResult(strNurseResult, rowlenth,ref list);
            }
        }

        private static void FormatDisplay(ArrayList DataRows)
        {
            string topTime = string.Empty;
            string date = string.Empty;
            string topDate = string.Empty;
            int year = 0;
            string time = string.Empty;
            string sign = string.Empty;
            string formTime = string.Empty;

            for (int i = 0; i < DataRows.Count; i++)
            {
                DataRow drTemp = DataRows[i] as DataRow;

                string souDate = drTemp[0].ToString();
                if (!string.IsNullOrEmpty(souDate))
                {
                    topDate = souDate;
                    year = Convert.ToInt32(souDate.Substring(0, 2));
                }
                if ((i) % 30 != 0 || i == 1 || i == 0)
                {
                    //没有换页
                    formTime = string.IsNullOrEmpty(drTemp[1].ToString()) ? formTime : drTemp[1].ToString();
                    if (string.IsNullOrEmpty(topTime))
                    {
                        topTime = formTime;
                    }
                    if (i == 0)
                    {
                        (DataRows[i] as DataRow)[0] = topDate;
                    }
                    if (date == souDate)
                    {
                        (DataRows[i] as DataRow)[0] = "";
                    }
                    else
                    {

                        if (!string.IsNullOrEmpty(souDate))
                        {
                            if (!string.IsNullOrEmpty(date))
                            {
                                if (year == Convert.ToInt32(date.Substring(0, 2)))
                                {
                                    (DataRows[i] as DataRow)[0] = souDate.Substring(3, souDate.Length - 3);
                                }
                                else
                                {
                                    (DataRows[i] as DataRow)[0] = souDate;
                                }
                            }
                            else
                            {
                                if (i != 0)
                                {
                                    (DataRows[i] as DataRow)[0] = souDate.Substring(3, souDate.Length - 3);
                                }
                            }
                        }

                    }
                    if (!string.IsNullOrEmpty(souDate))
                    {
                        if (string.IsNullOrEmpty(date))
                        {
                            date = souDate;
                        }
                        else
                        {
                            int dYear = Convert.ToInt32(date.Substring(0, 2));
                            if (year > dYear)
                            {
                                date = year + souDate.Substring(2, souDate.Length - 2);
                            }
                            else
                            {

                                date = souDate;
                            }
                        }
                    }
                }
                else
                {


                    topDate = topDate.Substring(3, topDate.Length - 3);

                    (DataRows[i] as DataRow)[0] = topDate;

                    (DataRows[i] as DataRow)[1] = string.IsNullOrEmpty((DataRows[i] as DataRow)[1].ToString()) ? formTime : (DataRows[i] as DataRow)[1];
                }

                int index = i;
                if (i + 1 == DataRows.Count)
                {
                    continue;
                }
                string currentTime = drTemp[1].ToString();
                string nextTime = string.Empty;
                string nextDate = string.Empty;
                DataRow nextRow = DataRows[index + 1] as DataRow;
                nextTime = nextRow[1].ToString();
                nextDate = nextRow[0].ToString();
                if (string.IsNullOrEmpty(nextTime))
                {
                    time = currentTime;
                    string drugName = string.Empty;
                    drugName = nextRow[11].ToString();
                    if (!string.IsNullOrEmpty(drugName))
                    {
                        sign = (DataRows[index] as DataRow)[17].ToString();
                        (DataRows[index] as DataRow)[17] = string.Empty;
                        (DataRows[index + 1] as DataRow)[17] = sign;
                    }
                }
                else
                {

                    if (nextTime == currentTime)
                    {
                        sign = (DataRows[index] as DataRow)[17].ToString();
                        (DataRows[index] as DataRow)[17] = string.Empty;
                        (DataRows[index + 1] as DataRow)[17] = sign;

                    }
                    if (nextTime == time)
                    {
                        string drugName = drTemp[11].ToString();
                        string undersign = drTemp[17].ToString();
                        if (!string.IsNullOrEmpty(drugName) && !string.IsNullOrEmpty(undersign))
                        {
                            sign = (DataRows[index] as DataRow)[17].ToString();
                            (DataRows[index] as DataRow)[17] = string.Empty;
                            (DataRows[index + 1] as DataRow)[17] = sign;
                        }
                    }

                }

                if (topTime == nextTime)
                {
                    if (topDate == nextDate)
                    {
                        (DataRows[index + 1] as DataRow)[1] = string.Empty;
                    }
                }
                else
                {
                    topTime = string.IsNullOrEmpty(nextTime) ? topTime : nextTime;
                }

            }
        }
        #endregion

        #region 打印
        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataSet ds = GetNusersRecords();
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count == 0)
                {
                    App.MsgWaring("当前病人没有护理记录数据！");
                    return;
                }
            }
            else
            {
                App.MsgWaring("当前病人没有护理记录数据！");
                return;
            }
            //获取诊断
            if (diagnose == "" || diagnose == null)
            {
                diagnose = App.ReadSqlVal("select diagnose_name from T_NURSE_RECORD where RECORD_TYPE='C' and Patient_Id =" + currentPatient.Id, 0, "diagnose_name");//自己修改的护理
            }
            if (diagnose == "" || diagnose == null)
            {
                diagnose = App.ReadSqlVal("select diagnose_name from t_diagnose_item where diagnose_type='403' and Patient_Id =" + currentPatient.Id, 0, "diagnose_name");//初步诊断
            }
            if (diagnose == "" || diagnose == null)
            {
                diagnose = App.ReadSqlVal("select diagnose_name from t_diagnose_item where diagnose_type='408' and Patient_Id =" + currentPatient.Id, 0, "diagnose_name");//初步诊断
            }
            if (diagnose == null)
            {
                diagnose = "";
            }
            frmNursePrint_Records ff = new frmNursePrint_Records(ReSetPrintDataSet(ds), currentPatient,diagnose,strType, pipe1, pipe2);
            ff.Show();
        }

        public DataSet GetNusersRecords()
        {
            DataSet ds = null;
            ShowDatas();
            SumInOrOutRecordSets();
            Class_Nurse_Record_Pediatric[] cNurse = new Class_Nurse_Record_Pediatric[nurses.Count];
            for (int i = 0; i < nurses.Count; i++)
            {
                cNurse[i] = new Class_Nurse_Record_Pediatric();
                cNurse[i] = nurses[i] as Class_Nurse_Record_Pediatric;
                //代码转换成类型名称
                if (cNurse[i].Consciousness != null)
                    cNurse[i].Consciousness = ldConsciousness[cNurse[i].Consciousness].ToString();
                if (cNurse[i].Skin != null && ldSkin[cNurse[i].Skin]!=null)
                    cNurse[i].Skin = ldSkin[cNurse[i].Skin].ToString();
                if (cNurse[i].Oxygen != null && ldXY[cNurse[i].Oxygen] != null)
                    cNurse[i].Oxygen = ldXY[cNurse[i].Oxygen].ToString();
                if (cNurse[i].Safenurse != null && ldSafenurse[cNurse[i].Safenurse] != null)
                    cNurse[i].Safenurse = ldSafenurse[cNurse[i].Safenurse].ToString();
                
            }
            //string tempDate = "";//日期
            //string tempTime = "";//时间
            ////设置时间显示格式,日期相同只显示第一行日期，分相同只显示第一行分
            //for (int i = 0; i < cNurse.Length; i++)
            //{
            //    DateTime currDate = Convert.ToDateTime(cNurse[i].DateTime);
            //    if (tempDate == "")
            //    {
            //        cNurse[i].DateTime = currDate.ToString("MM-dd HH:mm");
            //        tempDate = currDate.ToString("MM-dd");
            //        tempTime = currDate.ToString("HH:mm");
            //        continue;
            //    }
            //    if (tempDate == currDate.ToString("MM-dd") && tempTime == currDate.ToString("HH:mm"))//日期与时间都相同，不现实
            //    {
            //        cNurse[i].DateTime = "";
            //    }
            //    else if (tempDate == currDate.ToString("MM-dd"))//日期相同，显示小时和分
            //    {
            //        cNurse[i].DateTime = currDate.ToString("HH:mm");
            //        tempTime = currDate.ToString("HH:mm");
            //    }
            //    else//不同日期显示日期 小时 分
            //    {
            //        cNurse[i].DateTime = currDate.ToString("MM-dd HH:mm");
            //        tempDate = currDate.ToString("MM-dd");
            //    }

            //}
            ds = App.ObjectArrayToDataSet(cNurse);
            return ds;
        }

        /// <summary>
        /// 绑定打印数据
        /// </summary>
        public void ShowDatas()
        {
            nurses.Clear();
            pipe1 = "";
            pipe2 = "";
            //SetTable();
            #region 数据加载
            string dateTime = dtpDate.Value.ToString("yyyy-MM-dd HH:mm");

            string sql_time = "select distinct to_char(t.measure_time,'yyyy-mm-dd hh24:mi') as DATETIMEVAL from T_NURSE_RECORD t where RECORD_TYPE='C' and  t.patient_Id=" + currentPatient.Id + " order by DATETIMEVAL asc";
            string sql_set = "select t.id,to_char(t.measure_time,'yyyy-mm-dd hh24:mi') as DATETIMEVAL,t.item_code,a.item_name,t.item_show_name,a.item_attribute,t.item_value,t.other_name,a.item_type,t.status_measure,t.creat_id,d.user_name,t.diagnose_name,PATIENT_ID from T_NURSE_RECORD t " +
                            " left join t_nurse_record_dict a on a.item_code=t.item_code  left join T_DATA_CODE b on a.item_attribute=b.id inner " +
                            " join T_ACCOUNT_USER c on t.creat_id=c.user_id inner join T_USERINFO d on d.user_id=c.user_id where RECORD_TYPE='C' and patient_Id=" + currentPatient.Id + " order by t.create_time asc ";
            //时间集合
            DataSet ds_time_sets = App.GetDataSet(sql_time);
            //项目集合
            DataSet ds_values_sets = App.GetDataSet(sql_set);

            DataTable dt_time = ds_time_sets.Tables[0];
            DataTable dt_sets = ds_values_sets.Tables[0];
            if (dt_time != null)
            {
                for (int i = 0; i < dt_time.Rows.Count; i++)
                {
                    string dateTimeValue = dt_time.Rows[i]["DATETIMEVAL"].ToString();

                    //常用项目数组
                    DataRow[] dr_Values = dt_sets.Select(" DATETIMEVAL='" + dateTimeValue + "'");

                    //入量
                    DataRow[] drinput = dt_sets.Select("item_show_name='入量' and DATETIMEVAL='" + dateTimeValue + "'");
                    int index = drinput.Length;
                    if (index == 0)
                    {
                        index = 1;
                    }
                    for (int j = 0; j < index; j++)
                    {
                        Class_Nurse_Record_Pediatric temp = new Class_Nurse_Record_Pediatric();
                        temp.DateTime = dateTimeValue;
                        if (drinput.Length > 0)
                        {
                            temp.Inputname = drinput[j]["item_code"].ToString();
                            temp.Inputvalue = drinput[j]["item_value"].ToString();
                            temp.Number = drinput[j]["id"].ToString();
                        }

                        for (int k = 0; k < dr_Values.Length; k++)
                        {
                            if (j == 0)//非入量项目只在第一行显示
                            {
                                if (dr_Values[k]["item_show_name"].ToString() == "病情程度")
                                {
                                    temp.Sick_level = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "护理级别")
                                {
                                    temp.Nurse_level = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "意识")
                                {
                                    temp.Consciousness = dr_Values[k]["item_code"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "左")
                                {
                                    temp.Left = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "右")
                                {
                                    temp.Right = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "T")
                                {
                                    temp.T = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "P")
                                {
                                    temp.P = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "HR")
                                {
                                    temp.HR = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "R")
                                {
                                    temp.R = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "BP")
                                {
                                    temp.Bp = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "血氧饱和度")
                                {
                                    temp.Oxygen_saturation = dr_Values[k]["item_value"].ToString();
                                }
                                //else if (dr_Values[k]["item_show_name"].ToString() == "入量")
                                //{
                                //    temp.Inputname = dr_Values[k]["item_code"].ToString();
                                //    temp.Inputvalue = dr_Values[k]["item_value"].ToString();
                                //}
                                else if (dr_Values[k]["item_show_name"].ToString() == "入量自定义值")
                                {
                                    temp.Inputother = dr_Values[k]["item_value"].ToString();
                                    pipe1 = dr_Values[k]["other_name"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "大便")
                                {
                                    temp.Shit = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "小便")
                                {
                                    temp.Urine = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "出量其它")
                                {
                                    temp.Outother = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "出量自定义值")
                                {
                                    temp.Out_item_name = dr_Values[k]["item_value"].ToString();
                                    pipe2 = dr_Values[k]["other_name"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "管道")
                                {
                                    temp.Duct_item_name = dr_Values[k]["item_code"].ToString();
                                    temp.Duct_item_values = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "皮肤")
                                {
                                    temp.Skin = dr_Values[k]["item_code"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "安全护理")
                                {
                                    temp.Safenurse = dr_Values[k]["item_code"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "吸氧")
                                {
                                    temp.Oxygen = dr_Values[k]["item_code"].ToString();
                                    temp.Oxygen_value = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "备注")
                                {
                                    temp.Nurse_result = dr_Values[k]["item_value"].ToString();
                                }

                            }
                            if (j == index - 1)
                            {
                                temp.Signature = dr_Values[k]["user_name"].ToString();
                            }
                        }
                        nurses.Add(temp);
                    }
                }


            }

            #endregion

        }
        /// <summary>
        /// 重置计算出入量汇总
        /// </summary>
        private void SumInOrOutRecordSets()
        {
            SumInOrOutRecordSet(false);
        }
        #endregion

        
        /// <summary>
        /// 获取项目的创建时间
        /// </summary>
        /// <param name="rowSel">项目的行索引</param>
        /// <returns></returns>
        private string GetTime(int rowSel)
        {
            string dateTime = "";
            if (this.flgView[rowSel, 0] != null && this.flgView[rowSel, 0].ToString() != "")
            {
                dateTime = this.flgView[rowSel, 0].ToString();
            }
            else
            {
                dateTime = GetTime(rowSel - 1);
            }

            return dateTime;
        }
        
        #region 表格相关操作
        private void flgView_CellChanged(object sender, RowColEventArgs e)
        {
            if (e.Col != 1 || e.Col != 22)
            {
                this.flgView.AutoSizeCol(e.Col);
            }

        }
        //ComboBox cb = null;
        private void flgView_StartEdit(object sender, RowColEventArgs e)
        {
            int id = 0;
            if (flgView[e.Row, 27] != null && flgView[e.Row, 27].ToString().Length > 0)
            {
                try
                {
                    id = int.Parse(flgView[e.Row, 27].ToString());
                }
                catch { }
            }
            if (this.flgView[e.Row, 12] != null && (this.flgView[e.Row, 12].ToString().Contains("小结")
                || this.flgView[e.Row, 12].ToString().Contains("总结")))
            {
                if (id == 0)
                {
                    e.Cancel = true;
                    return;
                }
            }
            if (this.flgView[e.Row, 0] == null && e.Col == 12)
            {
                string measureTime = GetTime(e.Row);
                //验证权限
                DateTime objdt;
                if (measureTime != "")//时间为空说明是添加数据，不用验证权限
                {
                    if(!DateTime.TryParse(measureTime,out objdt))
                    {
                        FrmSetDatetime fsd = new FrmSetDatetime(dtpDate.Value, currentPatient.Id.ToString(), strType);
                        fsd.ShowDialog();
                        if (fsd.flag)
                            this.flgView[e.Row, 0] = fsd.Date.ToString("yyyy-MM-dd HH:mm");
                        this.flgView.Col = 0;
                        //e.Cancel = true;
                        return;
                    }
                    string operateId = App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='" + strType + "' and patient_id=" + currentPatient.Id, 0, "creat_id");
                    if (!ValidateUser(operateId))
                    {
                        App.Msg("权限不足！");
                        e.Cancel = true;
                        return;
                    }
                }
            }
            else if ((this.flgView[e.Row, 0] != null && this.flgView[e.Row, 0].ToString() != ""))
            {
                string measureTime = GetTime(e.Row);
                int num = Convert.ToInt32(App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='" + strType + "' and patient_id=" + currentPatient.Id, 0, "count(*)"));
                if (num > 0)
                {
                    //验证权限
                    DateTime objdt;
                    if (measureTime != ""&&DateTime.TryParse(measureTime,out objdt))//时间为空说明是添加数据，不用验证权限
                    {
                        string operateId = App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='" + strType + "' and patient_id=" + currentPatient.Id, 0, "creat_id");
                        if (!ValidateUser(operateId))
                        {
                            App.Msg("权限不足！");
                            e.Cancel = true;
                            return;
                        }
                    }
                }
            }
            //if (((this.flgView[e.Row, 0] == null && e.Col != 12) || (this.flgView[e.Row, 0] == null && e.Col != 13)) || e.Row != this.flgView.Rows.Count - 2)
            //{
            //    e.Cancel = true;
            //    return;
            //}
            if ((this.flgView[e.Row, 0] == null || this.flgView[e.Row, 0].ToString() == "") &&
                e.Col != 12 && e.Col != 13 && e.Row != this.flgView.Rows.Count - 1 && this.flgView[e.Row, 12] != null)
            {
                e.Cancel = true;
                return;
            }

            //3体温单元格中的值不是数值类型，则该行是汇总数据，取消编辑
            //if (this.flgView[e.Row, 3] != null && !App.IsNumeric(this.flgView[e.Row, 3].ToString()))
            //{
            //    e.Cancel = true;
            //    return;
            //}
            //签名禁止编辑
            if (e.Col == 26)
            {
                e.Cancel = true;
                return;
            }
            if ((e.Col != 12 && e.Col != 13) || e.Col == 0)
            {
                //if (this.flgView[e.Row, 0] == null || this.flgView[e.Row, 0].ToString() == "")
                //{
                if (this.flgView[e.Row, 0] == null || this.flgView[e.Row, 0].ToString() == "")
                {
                    //App.Msg("请选择测量时间！");
                    FrmSetDatetime fsd = new FrmSetDatetime(dtpDate.Value, currentPatient.Id.ToString(), strType);
                    fsd.ShowDialog();
                    if (fsd.flag)
                        this.flgView[e.Row, 0] = fsd.Date.ToString("yyyy-MM-dd HH:mm");
                    this.flgView.Col = 0;
                    e.Cancel = true;
                    return;
                    //}
                }
                else
                {
                    if (e.Col == 0)
                    {
                        DateTime dt = Convert.ToDateTime(flgView[e.Row, 0].ToString());
                        string operateId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + dt.ToString("yyyy-MM-dd HH:mm") + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='" + strType + "' and patient_id=" + currentPatient.Id + " and rownum=1 order by id", 0, "creat_id"));

                        if (ValidateUser(operateId) || operateId == null)
                        {
                            FrmSetDatetime fsd = new FrmSetDatetime(dt, currentPatient.Id.ToString(),"C");
                            fsd.ShowDialog();
                            if (fsd.flag)
                            {
                                flgView[e.Row, 0] = fsd.Date.ToString("yyyy-MM-dd HH:mm");
                                //flgView.Col = 1;

                                /*
                                 *修改日期的时候，所有对应的护理记录都要修改时间
                                 */
                                string sql = "update t_nurse_record t set  t.measure_time=to_timestamp('" +
                                    fsd.Date.ToString("yyyy-MM-dd HH:mm") + "','syyyy-mm-dd hh24:mi:ss.ff9') where measure_time=to_timestamp('" +
                                    dt.ToString("yyyy-MM-dd HH:mm") + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='C' and patient_id=" + currentPatient.Id.ToString() + "";

                                if (App.ExecuteSQL(sql) == 0 && operateId != null)
                                {
                                    App.MsgErr("修改时间没有修改成功！");
                                }
                            }
                        }
                        else
                        {
                            App.Msg("修改权限不足！");
                        }

                        e.Cancel = true;
                        return;
                    }

                }

            }
            //验证出入量的标题是否输入
            if (e.Col == 14 || e.Col == 18)
            {
                if (this.flgView[1, e.Col] == null || this.flgView[1, e.Col].ToString() == "")
                {
                    修改标题ToolStripMenuItem_Click(sender, e);
                }
            }

            //if (flgView.Col == 25)
            //{
            //    this.提取备注模板ToolStripMenuItem_Click(sender, e);
            //    return;
            //}

            //入量输入验证，先输入入量类型，再输入数值
            if (e.Col == 13)
            {
                if (this.flgView[e.Row, e.Col - 1] == null || this.flgView[e.Row, e.Col - 1].ToString() == "")
                {
                    App.Msg("请输入入量名称！");
                    this.flgView.Col = 12;
                    return;
                }
            }
            if (e.Col == 23)
            {
                if (this.flgView[e.Row, e.Col - 1] == null || this.flgView[e.Row, e.Col - 1].ToString() == "")
                {
                    App.Msg("请先选择吸氧方式！");
                    this.flgView.Col = 22;
                    return;
                }
            }
            if (e.Col == 20)
            {
                if (this.flgView[e.Row, e.Col - 1] == null || this.flgView[e.Row, e.Col - 1].ToString() == "")
                {
                    App.Msg("请先选择管道名称！");
                    this.flgView.Col = 19;
                    return;
                }
            }

            //编辑瞳孔
            if (e.Col == 4 || e.Col == 5)
            {
                if (flgView[e.Row, e.Col] == null || flgView[e.Row, e.Col].ToString() == "")
                {
                    FrmPupilSet frm = new FrmPupilSet();
                    frm.ShowDialog();
                    if (frm.flag)
                    {
                        flgView[e.Row, e.Col] = frm.returnValue;
                        //flgView.Editor = null;
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                else
                {
                    FrmPupilSet frm = new FrmPupilSet(flgView[e.Row, e.Col].ToString());
                    frm.ShowDialog();
                    if (frm.flag)
                    {
                        flgView[e.Row, e.Col] = frm.returnValue;
                        //flgView.Editor = null;
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }

        }
        #endregion

        private void flgView_KeyPressEdit(object sender, KeyPressEditEventArgs e)
        {
            if (e.Col == 0 )//|| e.Col == 25)//时间日期,备注禁止手动输入
            {
                e.Handled = true;
            }
            //入量值
            if (e.Col == 13)
            {
                if (!Char.IsNumber(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.'&&e.KeyChar!='-')
                {
                    e.Handled = true;
                }
                if (e.KeyChar=='-'&&flgView.Editor.Text.Contains("-"))
                {
                    e.Handled = true;
                }
            }
            if ((e.Col > 6 && e.Col < 12&&e.Col!=10) || e.Col == 16 || e.Col == 23)//生命体征,血氧饱和度，入量，小便，吸氧流量
            {
                if (!Char.IsNumber(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
                {
                    e.Handled = true;
                }
            }
            if (e.Col == 15)//大便可输入g ,默认ml
            {
                if (!Char.IsNumber(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.' && Char.ToLower(e.KeyChar) != 'g')
                {
                    e.Handled = true;
                }
                else if (Char.ToLower(e.KeyChar) == 'g')
                {
                    //判断是否已经输入过单位:g
                    if (flgView.Editor.Text.ToLower().Contains("g") || flgView.Editor.Text == "")
                    {
                        e.Handled = true;
                    }
                }
            }
            if (e.Col == 10)//血压
            {
                if (!Char.IsNumber(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.' && e.KeyChar != '/')
                {
                    e.Handled = true;
                }
                if (e.KeyChar == '/' && flgView.Editor.Text.ToLower().Contains("/"))
                {
                    e.Handled = true;
                }
            }
        }
        /// <summary>
        /// 设置编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flgView_SetupEditor(object sender, RowColEventArgs e)
        {
            if (e.Col == 12 && this.flgView[e.Row, e.Col] != null && this.flgView[e.Row, e.Col].ToString() != "")//入量名称列
            {
                //保存修改前的入量名称
                oldInputName = this.flgView[e.Row, e.Col].ToString();
                //oldDuct_values = this.flgView[e.Row, e.Col].ToString();
            }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            oldInputName= "";
            ShowData();
            SumInOrOutRecordSet(true);
            ShowSumDataGrid();
            //flgView.AutoSizeCols();
            flgView.Cols[25].Width = 100;
            flgView.Cols[1].Width = 35;
            flgView.Cols[22].Width = 35;
            flgView.AutoSizeRows();
        }
        /// <summary>
        /// 结束编辑后，保存单元格的内容到数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flgView_AfterEdit(object sender, RowColEventArgs e)
        {

            #region 验证
            if (this.flgView[e.Row, 0] != null && this.flgView[e.Row, 0].ToString() != "")
            {
                string currentRowTime = this.flgView[e.Row, 0].ToString();
                //验证重复时间
                for (int i = 3; i < this.flgView.Rows.Count; i++)
                {
                    if (i != e.Row)
                    {
                        if (this.flgView[i, 0] != null && this.flgView[i, 0].ToString() == currentRowTime)
                        {
                            this.flgView[e.Row, 0] = null;
                            App.Msg("不能录入相同的时间！");
                            return;
                        }
                    }
                }

                //验证时间范围是否和查询条件日期相同
                if (dtpDate.Value.ToString("yyyy-MM-dd") != Convert.ToDateTime(currentRowTime).ToString("yyyy-MM-dd"))
                {
                    this.flgView[e.Row, 0] = null;
                    App.Msg("您选择的时间超出了查询日期！");
                    return;
                }
            }
            #endregion

            #region 保存数据
            if (this.flgView[e.Row, e.Col] != null && this.flgView[e.Row, e.Col].ToString() != "")
            {
                string measureTime = GetTime(e.Row);
                string itemCode = "";
                string itemValue = "";
                string itemName = "";
                string otherName = "";
                int id = 0;
                if (e.Col==1||e.Col==2||e.Col == 3 ||e.Col==21|| e.Col == 24)
                {
                    ListDictionary ldCommon = GetDictionaryByColIndex(e.Col);
                    itemValue = ldCommon[this.flgView[e.Row, e.Col].ToString()].ToString();
                    itemCode = this.flgView[e.Row, e.Col].ToString();
                    itemName = dictColumnName[e.Col];
                }
                else if (e.Col == 13||e.Col==12)//入量
                {
                    itemCode = flgView[e.Row, 12] == null ? "" : flgView[e.Row, 12].ToString();
                    itemValue = flgView[e.Row, 13] == null ? "" : flgView[e.Row, 13].ToString();
                    itemName = "入量";
                    //if (e.Col == 12)
                    //{
                    //    string s = App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and item_show_name='" + itemName + "' and item_code='" + itemCode + "' and patient_id=" + currentPatient.Id, 0, "count(*)");
                    //    if (s != "0")
                    //    {
                    //        App.Msg("入量项目重复!");
                    //        this.flgView[e.Row, e.Col] = oldInputName;
                    //        this.flgView.Col = e.Col;
                    //        return;
                    //    }
                    //}
                    if(flgView[e.Row,27]!=null&&flgView[e.Row,27].ToString().Length>0)
                    {
                        try
                        {
                            id = int.Parse(flgView[e.Row, 27].ToString());
                        }
                        catch{}
                    }
                }
                else if (e.Col == 19||e.Col==20)//管道
                {
                    itemValue = flgView[e.Row, 20] == null ? "" : flgView[e.Row, 20].ToString();
                    itemCode = flgView[e.Row, 19] == null ? "" : flgView[e.Row, 19].ToString();
                    itemName = "管道";
                }
                else if (e.Col == 14 || e.Col == 18)//手工输入的入,出量列名数据
                {
                    switch (e.Col)
                    {
                        case 14:
                            itemName = "入量自定义值";
                            break;
                        case 18:
                            itemName = "出量自定义值";
                            break;
                    }
                    itemValue = this.flgView[e.Row, e.Col].ToString();
                    otherName = this.flgView[1, e.Col].ToString();
                    //itemCode = e.Col.ToString();
                }
                else if (e.Col == 23||e.Col==22)//吸氧
                {
                    //ListDictionary ldCommon = GetDictionaryByColIndex(22);
                    //otherName = ldCommon[flgView[e.Row, 22].ToString()].ToString();
                    itemValue = flgView[e.Row, 23] == null ? "" : flgView[e.Row, 23].ToString();
                    itemCode = flgView[e.Row, 22] == null ? "" : flgView[e.Row, 22].ToString();
                    itemName = "吸氧";
                }
                else
                {
                    itemValue = this.flgView[e.Row, e.Col].ToString();
                    if (e.Col == 25)//备注，验证字符长度
                    {
                        int length = getStringLength(itemValue);
                        if (length > 600)
                        {
                            App.Msg("您输入的内容超过600字节了!");
                            return;
                        }
                    }
                    itemName = dictColumnName[e.Col];
                    itemCode = App.ReadSqlVal("select item_code from t_nurse_record_dict where item_type in(19802,19804,19805,19807,19808,19809,19810) and  item_name='" + itemName + "'", 0, "item_code");

                }
                //取当前日期时间最早的创建者id
                string userId = "";
                try
                {
                    userId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and patient_id=" + currentPatient.Id + " and rownum=1 order by id", 0, "creat_id"));
                    if (userId == null || userId == "")
                    {
                        userId = App.UserAccount.UserInfo.User_id;
                    }
                }
                catch (System.Exception ex)
                {
                    userId = App.UserAccount.UserInfo.User_id;
                }
                //判断是新增还是修改:返回值大于0是修改，等于0是新增
                int itemCount = 0;
                if (e.Col != 13 && e.Col != 12)
                {
                    itemCount = Convert.ToInt32(App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and item_show_name='" + itemName + "' and patient_id=" + currentPatient.Id, 0, "count(*)"));
                }
                else //入量验证条件增加othername
                {
                    if (itemName == "入量")
                    {
                        if (id > 0)
                        {
                            itemCount = 1;
                        }
                    }
                    else
                    {
                        itemCount = Convert.ToInt32(App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and item_show_name='" + itemName + "' and item_code='" + itemCode + "'  and patient_id=" + currentPatient.Id, 0, "count(*)"));
                    }
                }
                string sql = "";
                if (itemCount == 0)
                {
                    if (otherName == "")
                    {
                        sql = "insert into t_nurse_record" +
                                     "( bed_no, pid, measure_time, item_code, item_value, creat_id, create_time, patient_id, item_show_name,RECORD_TYPE)values" +
                                     "( '" + currentPatient.Sick_Bed_Name + "', '" + currentPatient.PId + "', to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9'), '" +
                                     itemCode + "', '" + itemValue + "', '" + userId + "', sysdate, " + currentPatient.Id + ", '" + itemName + "','"+strType+"')";
                    }
                    else
                    {
                        sql = "insert into t_nurse_record" +
                                     "( bed_no, pid, measure_time, item_code, item_value, creat_id, create_time, patient_id, item_show_name,other_name,RECORD_TYPE)values" +
                                     "( '" + currentPatient.Sick_Bed_Name + "', '" + currentPatient.PId + "', to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9'), '" +
                                     itemCode + "', '" + itemValue + "', '" + userId + "', sysdate, " + currentPatient.Id + ", '" + itemName + "','" + otherName + "','"+strType+"')";
                    }
                }
                else
                {
                    sql = "update t_nurse_record set item_code='" + itemCode + "',item_value='" + itemValue + "',update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate";
                    if (itemName == "入量" && id > 0)
                    {
                        sql += " where id=" + id;
                    }
                    else
                    {
                        sql += " where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and item_show_name='" + itemName + "' and patient_id=" + currentPatient.Id;
                        ////}
                        //if (!string.IsNullOrEmpty(itemCode))
                        //{
                        //    if (itemName.Equals("入量"))
                        //    {
                        //        sql = sql + " and item_code='" + (oldInputName == "" ? itemCode : oldInputName) + "'";
                        //    }
                        //}
                    }
                }
                int num = App.ExecuteSQL(sql);
                if (num > 0)
                {
                    timer1.Start();
                    operateFlag = true;
                    if (flgView[e.Row, 0] != null && flgView[e.Row, 0].ToString() != "" && flgView[e.Row, 20] == null && sql.Contains("insert"))
                        flgView[e.Row, 26] = App.UserAccount.UserInfo.User_name;
                    if (id == 0 && itemName == "入量" && sql.ToLower().Contains("insert"))
                    {
                        btnSearch_Click(sender, e);
                    }
                    //App.Msg("操作成功！");
                    //App.ExecuteSQL("update t_nurse_record set creat_id='" + App.UserAccount.UserInfo.User_id + "',create_time=sysdate, update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and patient_id=" + currentPatient.Id);
                    //btnSearch_Click(sender, e);
                }
                //}
                //else if (e.Col == 12) //更新各种管道名称
                //{

                //    //验证是否重复

                //    itemName = ldDuct_name[this.flgView[e.Row, 12]].ToString();
                //    int itemCount = Convert.ToInt32(App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='各种管道' and other_name='" + itemName + "' and patient_id=" + currentPatient.Id, 0, "count(*)"));
                //    if (itemCount > 0 && itemName != oldDuct_name)
                //    {
                //        App.Msg("管道名称重复！");
                //        this.flgView[e.Row, e.Col] = oldDuct_values;
                //        //btnSearch_Click(sender, e);
                //        return;
                //    }

                //    itemCount = Convert.ToInt32(App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='各种管道' and other_name='" + oldDuct_name + "' and patient_id=" + currentPatient.Id, 0, "count(*)"));

                //    //如果当前项目已存在则修改当前值的入量类型
                //    if (oldDuct_name != "")
                //    {
                //        if (itemCount > 0 && this.flgView[e.Row, 13] != null)
                //        {
                //            otherName = ldDuct_name[this.flgView[e.Row, 12].ToString()].ToString();
                //            itemCode = this.flgView[e.Row, 12].ToString();
                //            string sql = "update t_nurse_record set item_code='" + itemCode + "',other_name='" + otherName + "',update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='各种管道' and other_name='" + oldDuct_name + "' and patient_id=" + currentPatient.Id;
                //            int num = App.ExecuteSQL(sql);
                //            if (num > 0)
                //            {
                //                timer1.Start();
                //                //App.Msg("操作成功！");
                //                operateFlag = true;
                //                //App.ExecuteSQL("update t_nurse_record set creat_id='" + App.UserAccount.UserInfo.User_id + "'，create_time=sysdate, update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and patient_id=" + currentPatient.Id);
                //                //btnSearch_Click(sender, e);
                //            }
                //        }

                //    }

                //}
            }
            #endregion


        }

        /// <summary>
        /// 根据列的索引获得对应的字典集合
        /// </summary>
        /// <returns>类型字典</returns>
        private ListDictionary GetDictionaryByColIndex(int col)
        {
            if (col == 2)
            {
                return ldNurseLevel;
            }
            else if (col == 3)//意识
            {
                return ldConsciousness;
            }
            else if (col == 1)
            {
                return ldSickLevel;
            }
            else if (col == 21)//皮肤
            {
                return ldSkin;
            }
            else if (col == 24)//安全护理
            {
                return ldSafenurse;
            }
            else if (col == 22)//吸氧
            {
                return ldXY;
            }
            return null;
        }

        private void 修改标题ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string titleName = "";
            titleName = this.flgView[1, this.flgView.Col].ToString();
            FrmModifyTitle frm = new FrmModifyTitle(titleName);
            frm.ShowDialog();

            string pipeIndex = "";//当前选中表格的位置
            //设置表头入量,出量的自定义名字
            if (this.flgView.Col == 14)
            {
                this.flgView[1, 14] = frm.tName;
                pipeIndex = "入量自定义值";
            }
            else if (this.flgView.Col == 18 )
            {
                this.flgView[1, 18] = frm.tName;
                pipeIndex = "出量自定义值";
            }
            //更新入量,出量的自定义名字
            string sql = "update t_nurse_record set other_name='" + frm.tName + "' where patient_id=" + currentPatient.Id + " and record_type='" + strType + "' and item_show_name like '%" + pipeIndex + "%'";
            try
            {
                App.ExecuteSQL(sql);
            }
            catch
            {

            }

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (this.flgView.Col == 14 || this.flgView.Col == 18)
            {
                修改标题ToolStripMenuItem.Visible = true;
            }
            else
            {
                修改标题ToolStripMenuItem.Visible = false;
            }
            if (flgView.Col == 25)
            {
                提取备注模板ToolStripMenuItem.Visible = true;
                if (flgView[flgView.Row, flgView.Col] != null)
                {
                    添加备注模板ToolStripMenuItem.Visible = true;
                }
                else
                {
                    添加备注模板ToolStripMenuItem.Visible = false;
                }
            }
            else
            {
                添加备注模板ToolStripMenuItem.Visible = false;
                提取备注模板ToolStripMenuItem.Visible = false;
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
        }

        #region 汇总
        private void cboTiming_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtpBeginTime.Enabled = false;
            dtpEndTime.Enabled = false;
            dtpDateSelect.Enabled = true;
            Class_Take_over_SEQ tempSeq = null;
            if (cboTiming.SelectedItem != null)
            {
                tempSeq = (Class_Take_over_SEQ)cboTiming.SelectedItem;
            }
            if (cboTiming.Text.Contains("阶段性"))
            {
                string tHour;
                TimeSpan sp = new TimeSpan();
                sp = dtpEndTime.Value - dtpBeginTime.Value;
                tHour = Convert.ToString(sp.Days * 24 + sp.Hours) + "h";
                tHour += sp.Minutes == 0 ? "" : sp.Minutes.ToString() + "′";
                lblTatolTime.Text = tHour;
                dtpBeginTime.Enabled = true;
                dtpEndTime.Enabled = true;
                dtpDateSelect.Enabled = false;
            }
            else
            {
                if (tempSeq != null)
                {
                    dtpBeginTime.Value = Convert.ToDateTime(dtpDateSelect.Value.ToShortDateString() + " " + tempSeq.Begin_time);
                    dtpEndTime.Value = Convert.ToDateTime(dtpDateSelect.Value.ToShortDateString() + " " + tempSeq.End_time);
                    if (Convert.ToDateTime(App.GetSystemTime().ToShortDateString() + " " + tempSeq.Begin_time) >= Convert.ToDateTime(App.GetSystemTime().ToShortDateString() + " " + tempSeq.End_time))
                        dtpBeginTime.Value = dtpBeginTime.Value.AddDays(-1);
                    string tHour;
                    TimeSpan sp = new TimeSpan();
                    sp = dtpEndTime.Value - dtpBeginTime.Value;
                    tHour = Convert.ToString(sp.Days * 24 + sp.Hours) + "h";
                    tHour += sp.Minutes == 0 ? "" : sp.Minutes.ToString() + "′";
                    lblTatolTime.Text = tHour;
                }
            }
        }

        /// <summary>
        /// 确认计算
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHus_sum_Click(object sender, EventArgs e)
        {
            string sum_id = SumInOrOut();
            if (cboTiming.Text.Contains("小结"))
            {
                FrmSumItem sum_item = new FrmSumItem(sum_id,strType);
                sum_item.ShowDialog();
                if (!sum_item.successflag)
                {//没有操作成功,清除这条统计记录
                    string del = "delete from t_nurse_dangery_inout_sum_h where id=" + sum_id + " and record_type='"+strType+"' and patient_id=" + currentPatient.Id;
                    if (App.ExecuteSQL(del) > 0)
                    {//不用做刷新操作了
                        return;
                    }
                }
            }
            btnSearch_Click(sender, e);
        }

        /// <summary>
        /// 计算出入量汇总
        /// </summary>
        private string SumInOrOut()
        {
            string sum_id = null;
            string sum_Name;
            if (cboTiming.Text == "阶段性总结")
            {
                sum_Name = lblTatolTime.Text + "总结";
            }
            else if (cboTiming.Text == "阶段性小结")
            {
                sum_Name = lblTatolTime.Text + "小结";
            }
            else
            {
                sum_Name = cboTiming.Text;
            }

            int id = App.GenId("t_nurse_dangery_inout_sum_h", "ID");//获取id
            Class_Take_over_SEQ take_Seq = cboTiming.SelectedItem as Class_Take_over_SEQ;

            if (take_Seq != null)
            {
                string inserSumSql = "insert into t_nurse_dangery_inout_sum_h(ID,PID,CALC_DATE,START_TIME,END_TIME,OPER_METHOD,patient_Id,seq_id,SIGNATURE,RECORD_TYPE)values(" +
                id.ToString() + ",'" + currentPatient.PId + "',sysdate,to_timestamp('" +
                dtpBeginTime.Value.ToString("yyyy-MM-dd HH:mm") + "','yyyy-MM-dd HH24:mi'),to_timestamp('" +
                dtpEndTime.Value.ToString("yyyy-MM-dd HH:mm") + "','yyyy-MM-dd HH24:mi'),'" + sum_Name + "'," + currentPatient.Id + "," + take_Seq.Id + ",'" + App.UserAccount.UserInfo.User_name + "','"+strType+"')";

                if (App.ExecuteSQL(inserSumSql) > 0)
                {
                    sum_id = id.ToString();
                }
            }
            return sum_id;          
        }

        /// <summary>
        /// 表格的汇总计算刷新
        /// </summary>
        private void ShowSumDataGrid()
        {
            string TempDateTime = null;
            Class_Nurse_Record_Pediatric[] Nusers_objs = new Class_Nurse_Record_Pediatric[nurses.Count];
            for (int i = 0; i < nurses.Count; i++)
            {

                Nusers_objs[i] = new Class_Nurse_Record_Pediatric();
                Nusers_objs[i] = (Class_Nurse_Record_Pediatric)nurses[i];
                
            }
            SetTable();//表头设置
            if (Nusers_objs.Length != 0)
            {
                //Nusers_objs[Nusers_objs.Length - 1] = new Class_Nurse_Record_Pediatric();
                App.ArrayToGrid(this.flgView, Nusers_objs, cols, 3);
            }


            //给汇总计算的行插入ID
            for (int i = 0; i < Nusers_objs.Length; i++)
            {
                if (Nusers_objs[i].Number != null)
                {
                    this.flgView[i + 3, 27] = Nusers_objs[i].Number;
                }
            }

            //单元格合并和设置
            CellUnit(pipe1, pipe2);
            this.flgView.AutoSizeCols();
            this.flgView.AutoSizeRows();
            for (int i = 3; i < this.flgView.Rows.Count; i++)
            {
                if (this.flgView[i, 6] != null)
                {
                    bool isC = false;
                    for (int j = 0; j < Take_over_seq.Length; j++)
                    {
                        int id = 0;
                        if (flgView[flgView.Row, 27] != null && flgView[flgView.Row, 27].ToString().Length > 0)
                        {
                            try
                            {
                                id = int.Parse(flgView[flgView.Row, 27].ToString());
                            }
                            catch { }
                        }
                        if (this.flgView[i, 6].ToString().Contains(Take_over_seq[j].Seq) || this.flgView[i, 6].ToString().Contains("出入量"))
                        {//对比汇总的班次
                            if (id == 0)
                            {
                                this.flgView.Rows[i].AllowEditing = false;
                                isC = true;
                                break;
                            }
                        }
                    }
                    if (!isC)
                    {
                        this.flgView.Rows[i].AllowEditing = true;
                    }
                }
            }
            
        }

        
        private void dtpBeginTime_ValueChanged(object sender, EventArgs e)
        {
            string tHour;
            TimeSpan sp = new TimeSpan();
            sp = dtpEndTime.Value - dtpBeginTime.Value;
            tHour = Convert.ToString(sp.Days * 24 + sp.Hours) + "h";
            tHour += sp.Minutes == 0 ? "" : sp.Minutes.ToString() + "′";
            lblTatolTime.Text = tHour;
        }

        private void dtpEndTime_ValueChanged(object sender, EventArgs e)
        {
            string tHour;
            TimeSpan sp = new TimeSpan();
            sp = dtpEndTime.Value - dtpBeginTime.Value;
            tHour = Convert.ToString(sp.Days * 24 + sp.Hours) + "h";
            tHour += sp.Minutes == 0 ? "" : sp.Minutes.ToString() + "′";
            lblTatolTime.Text = tHour;
        }
        
        private void dtpDateSelect_ValueChanged(object sender, EventArgs e)
        {
            cboTiming_SelectedIndexChanged(sender, e);
        }

        /// <summary>
        /// 计算出入量总量
        /// </summary>
        /// <param name="IsToDay">true 计算当前天，false 计算全部</param>
        private void SumInOrOutRecordSet(bool IsToDay)
        {
            string BeginTime, EndTime, Item_name;
            string Number = "";//号码
            string seq_id = "";//统计类型ID
            string singsure = ""; //签名

            SumNusersRecords.Clear();  
            string sql_date = "select * from t_nurse_dangery_inout_sum_h where patient_Id=" + currentPatient.Id ;
            if(IsToDay)
            {
                string date = dtpDate.Value.ToString("yyyy-MM-dd");
                sql_date+=" and  to_char(end_time,'yyyy-MM-dd')='" + date + "'"; 
            }
            sql_date+=" and record_type='"+strType+"'";
            sql_date += " order by end_time";
            DataSet ds_sum_oper = App.GetDataSet(sql_date);

            for (int i = 0; i < ds_sum_oper.Tables[0].Rows.Count; i++)
            {
                //SumNusersRecords.Add(ds_sum_oper.Tables[0].Rows[i]["start_time"].ToString() + "," + ds_sum_oper.Tables[0].Rows[i]["end_time"].ToString() + "," + ds_sum_oper.Tables[0].Rows[i]["oper_method"].ToString().Replace("小时出入量", "h总结") + "," + ds_sum_oper.Tables[0].Rows[i]["ID"].ToString() + "," + ds_sum_oper.Tables[0].Rows[i]["seq_id"] + "," + ds_sum_oper.Tables[0].Rows[i]["SIGNATURE"] + "," + ds_sum_oper.Tables[0].Rows[i]["SUM_ITEM"]);
                SumNusersRecords.Add(ds_sum_oper.Tables[0].Rows[i]["start_time"].ToString() + "," + ds_sum_oper.Tables[0].Rows[i]["end_time"].ToString() + "," + ds_sum_oper.Tables[0].Rows[i]["oper_method"].ToString().Replace("小时出入量", "h总结") + ",0," + ds_sum_oper.Tables[0].Rows[i]["seq_id"] + "," + ds_sum_oper.Tables[0].Rows[i]["SIGNATURE"] + "," + ds_sum_oper.Tables[0].Rows[i]["SUM_ITEM"]);
            }

            for (int i1 = 0; i1 < SumNusersRecords.Count; i1++)
            {
                double din = 0;//入量和
                double dinother = 0;//入量自定义值和
                double dinsum = 0;//入量总和
                double dshit = 0;//大便和
                double durine = 0;//小便和
                double doutother = 0;//出量其它和
                double doutother2 = 0;//出量自定义值和
                double doutsum = 0;//出量总和
                             
                BeginTime = SumNusersRecords[i1].ToString().Split(',')[0];
                EndTime = SumNusersRecords[i1].ToString().Split(',')[1];
                Item_name = SumNusersRecords[i1].ToString().Split(',')[2];
                Number = SumNusersRecords[i1].ToString().Split(',')[3];
                seq_id = SumNusersRecords[i1].ToString().Split(',')[4];
                //creatID = SumNusersRecords[i1].ToString().Split(',')[4];+ "," + ds_sum_oper.Tables[0].Rows[i]["CREAT_ID"].ToString()
                singsure = SumNusersRecords[i1].ToString().Split(',')[5];
                string [] sum_item=SumNusersRecords[i1].ToString().Split(',')[6].Split('|');
                SumNusers.Clear();
                Class_Nurse_Record_Pediatric sumtemp = new Class_Nurse_Record_Pediatric();

                string beginSgin = ">=";

                string endSgin = "<=";

                Class_Take_over_SEQ tempSeq = null;
                for (int i = 0; i < cboTiming.Items.Count; i++)
                {
                    tempSeq = cboTiming.Items[i] as Class_Take_over_SEQ;
                    if (tempSeq != null && tempSeq.Id == seq_id)
                    {
                        if (tempSeq.Begin_logic == "0")
                        {
                            beginSgin = ">";
                        }
                        if (tempSeq.End_logic == "0")
                        {
                            endSgin = "<";
                        }
                        break;
                    }
                } 

                StringBuilder sbSum = new StringBuilder("select item_show_name as ItemName,a.item_value as ItemValue,a.item_code as ItemCode from t_nurse_record a");
                sbSum.Append(" where 1=1");
                sbSum.Append(" and MEASURE_TIME" + beginSgin + "to_timestamp('" + BeginTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME");
                sbSum.Append(" " + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id);
                sbSum.Append(" and a.record_type='" + strType + "'");
                sbSum.Append(" and item_show_name in('入量','入量自定义值','大便','小便','出量其它','出量自定义值')");

                //处理开始时间点的余液
                sbSum.Append(" Union all");
                sbSum.Append(" select item_show_name as ItemName,a.item_value as ItemValue,'余液+' as ItemCode from t_nurse_record a");
                sbSum.Append(" where  1=1");
                sbSum.Append(" and to_char(MEASURE_TIME,'yyyy-mm-dd hh24:mi')='" + Convert.ToDateTime(BeginTime).ToString("yyyy-MM-dd HH:mm") + "'");
                sbSum.Append(" and patient_Id=" + currentPatient.Id);
                sbSum.Append(" and record_type='" + strType + "'");
                sbSum.Append(" and item_show_name='药物'");
                sbSum.Append(" and other_name='余液'");

                //处理结束时间点的余液
                sbSum.Append(" Union all");
                sbSum.Append(" select item_show_name as ItemName,a.item_value as ItemValue,'余液-' as ItemCode from t_nurse_record a");
                sbSum.Append(" where  1=1");
                sbSum.Append(" and to_char(MEASURE_TIME,'yyyy-mm-dd hh24:mi')='" + Convert.ToDateTime(EndTime).ToString("yyyy-MM-dd HH:mm") + "'");
                sbSum.Append(" and patient_Id=" + currentPatient.Id);
                sbSum.Append(" and record_type='" + strType + "'");
                sbSum.Append(" and item_show_name='药物'");
                sbSum.Append(" and other_name='余液'");

                DataSet dsSum = App.GetDataSet(sbSum.ToString());
                if (dsSum.Tables.Count > 0 && dsSum.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drSum in dsSum.Tables[0].Rows)
                    {
                        double dtmp = 0;
                        string strTempName = drSum["ItemName"].ToString();
                        string strTempValue=drSum["ItemValue"].ToString();
                        string strTempCode = drSum["ItemCode"].ToString();
                        if (Double.TryParse(strTempValue, out dtmp))
                        {
                            switch (strTempName)
                            {
                                case "入量":
                                    if (strTempCode.Contains("弃液"))
                                    {
                                        dtmp = -Math.Abs(dtmp);
                                    }
                                    else if (strTempCode.Equals("余液"))
                                    {
                                        dtmp = 0;
                                    }
                                    else if(strTempCode.Equals("余液+"))
                                    {
                                        dtmp = Math.Abs(dtmp);
                                    }
                                    else if (strTempCode.Equals("余液-"))
                                    {
                                        dtmp = -Math.Abs(dtmp);
                                    }
                                    din+=dtmp;
                                    break;
                                case "入量自定义值":
                                    dinother+=dtmp;
                                    break;
                                case "大便":
                                    dshit += dtmp;
                                    break;
                                case "小便":
                                    durine += dtmp;
                                    break;
                                case "出量其它":
                                    doutother += dtmp;
                                    break;
                                case "出量自定义值":
                                    doutother2 += dtmp;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
                #region 计算出入总量
                dinsum = din + dinother;
                doutsum = dshit + durine + doutother + doutother2;
                #endregion
                sumtemp.DateTime = Convert.ToDateTime(EndTime).ToString("yyyy-MM-dd HH:mm");
                sumtemp.Inputname = Item_name;
                sumtemp.Number = Number;
                //统计值为0的均不显示
                if (Item_name.Contains("总结"))
                {
                    if (dinsum > 0)
                    {
                        sumtemp.Inputvalue = dinsum.ToString();
                    }
                    if (doutsum > 0)
                    {
                        sumtemp.Urine = doutsum.ToString();
                    }
                }
                else
                {
                    for (int isum = 0; isum < sum_item.Length; isum++)
                    {
                        switch (sum_item[isum].Trim())
                        {
                            case"入量":
                                if (din > 0)
                                {
                                    sumtemp.Inputvalue = din.ToString();
                                }
                                break;
                            case"入量自定义列":
                                if (dinother > 0)
                                {
                                    sumtemp.Inputother = dinother.ToString();
                                }
                                break;
                            case"大便":
                                if (dshit > 0)
                                {
                                    sumtemp.Shit = dshit.ToString();
                                }
                                break;
                            case"小便":
                                if (durine > 0)
                                {
                                    sumtemp.Urine = durine.ToString();
                                }
                                break;
                            case"出量其它":
                                if (doutother > 0)
                                {
                                    sumtemp.Outother = doutother.ToString();
                                }
                                break;
                            case"出量自定义列":
                                if (doutother2 > 0)
                                {
                                    sumtemp.Out_item_name = doutother2.ToString();
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
                if (singsure == "")
                {
                    if (App.UserAccount.UserInfo != null)
                        sumtemp.Signature = App.UserAccount.UserInfo.User_name;//签名
                }
                else
                {
                    sumtemp.Signature = singsure;//签名
                }
                DateTime TempDate = new DateTime();
                bool flag = false;//汇总对象是否已添加标志

                if (nurses.Count == 0)
                {
                    SumNusers.Add(sumtemp);
                }
                //将汇总记录插到对象集合中去
                for (int i = 0; i < nurses.Count; i++)
                {
                    Class_Nurse_Record_Pediatric temp_nuser = (Class_Nurse_Record_Pediatric)nurses[i];
                    if (temp_nuser.DateTime != null)
                    {
                        TempDate = Convert.ToDateTime(temp_nuser.DateTime);
                    }
                    else
                    {
                        SumNusers.Add(temp_nuser);
                        continue;
                    }

                    if (TempDate >= Convert.ToDateTime(EndTime) && !flag)//汇总结束时间小于测量时间时，先添加汇总对象
                    {
                        SumNusers.Add(sumtemp);
                        SumNusers.Add(temp_nuser);
                        flag = true;
                    }
                    else
                    {
                        SumNusers.Add(temp_nuser);
                    }
                }

                if (SumNusers.Count == nurses.Count)
                {
                    SumNusers.Add(sumtemp);
                }

                nurses.Clear();
                for (int i = 0; i < SumNusers.Count; i++)
                {
                    nurses.Add(SumNusers[i]);
                }


            }
            //ShowSumDataGrid();
        }
        #endregion

        private void 添加空行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.flgView.Rows.Insert(this.flgView.RowSel);
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.flgView[this.flgView.Row, this.flgView.Col] != null && this.flgView[this.flgView.Row, this.flgView.Col].ToString() != "")
                {
                    string measureTime = GetTime(this.flgView.Row);
                    string itemName = dictColumnName[this.flgView.Col];
                    string otherName = "";
                    string sql = "";//删除语句
                    int id = 0;
                    bool isC = false;
                    if (flgView[flgView.Row, 27] != null && flgView[flgView.Row, 27].ToString().Length > 0)
                    {
                        try
                        {
                            id = int.Parse(flgView[flgView.Row, 27].ToString());
                        }
                        catch { }
                    }
                    if (id==0&&this.flgView[this.flgView.Row, 12] != null && (this.flgView[this.flgView.Row, 12].ToString().Contains("小结") || this.flgView[this.flgView.Row, 12].ToString().Contains("总结")))//删除汇总
                    {
                        //string operateId = App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='" + itemName + "' and patient_id=" + currentPatient.Id, 0, "creat_id");
                        string signature = App.ReadSqlVal("select signature from t_nurse_dangery_inout_sum_h where oper_method='" + flgView[flgView.Row, 12].ToString() + "' and end_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and patient_id=" + currentPatient.Id, 0, "signature");
                        if (App.UserAccount.UserInfo.User_name == signature || signature == null || signature == ""||App.UserAccount.CurrentSelectRole.Role_name.Equals("护士长"))
                        {
                            sql = "delete from t_nurse_dangery_inout_sum_h where oper_method='" + this.flgView[this.flgView.Row, 12].ToString() + "' and end_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='"+strType+"' and patient_id=" + currentPatient.Id;
                        }
                        else
                        {
                            App.Msg("权限不足！");
                            return;
                        }
                    }
                    else
                    {
                        id = 0;
                        bool isdel = true;//删除还是更新
                        string stritemcode = "";
                        if (itemName.Contains("管道"))
                        {
                            if (itemName.Contains("情况"))
                            {
                                isdel = false;
                                stritemcode = flgView[flgView.Row, flgView.Col - 1].ToString();
                            }
                            itemName = "管道";
                        }
                        if (itemName.Contains("入量")&&itemName!="入量自定义值")
                        {
                            if (itemName.Contains("入量量"))
                            {
                                isdel = false;
                                stritemcode = flgView[flgView.Row, flgView.Col - 1].ToString();
                            }
                            else
                            {
                                stritemcode = flgView[flgView.Row, flgView.Col].ToString();
                            }
                            if (flgView[flgView.Row, 27] != null && flgView[flgView.Row, 27].ToString().Length > 0)
                            {
                                try
                                {
                                    id = int.Parse(flgView[flgView.Row, 27].ToString());
                                }
                                catch { }
                            }
                            itemName = "入量";
                        }
                        if (itemName.Contains("吸氧"))
                        {
                            if (itemName.Contains("流量"))
                            {
                                isdel = false;
                                stritemcode = flgView[flgView.Row, flgView.Col - 1].ToString();
                            }
                            itemName = "吸氧";
                        }
                        if (this.flgView.Col != 0)//删除单独项
                        {
                            if (otherName == "")
                            {
                                string operateId = App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and item_show_name='" + itemName + "' and patient_id=" + currentPatient.Id, 0, "creat_id");
                                if (id > 0)
                                {
                                    operateId = App.ReadSqlVal("select creat_id from t_nurse_record where id=" + id, 0, "creat_id");
                                }
                                if (App.UserAccount.UserInfo.User_id == operateId || App.UserAccount.CurrentSelectRole.Role_name.Equals("护士长"))
                                {
                                    if (isdel)
                                    {
                                        if (id > 0)
                                        {
                                            sql = "delete from t_nurse_record where id=" + id;
                                        }
                                        else
                                        {
                                            sql = "delete from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and item_show_name='" + itemName + "' and patient_id=" + currentPatient.Id;
                                            if (stritemcode.Trim().Length > 0)
                                            {
                                                sql = sql + " and item_code='" + stritemcode + "'";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (id > 0)
                                        {
                                            sql = "update t_nurse_record set item_value=null where id=" + id;
                                        }
                                        else
                                        {
                                            sql = "update t_nurse_record set item_value=null where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and item_show_name='" + itemName + "' and item_code='" + stritemcode + "' and patient_id=" + currentPatient.Id;
                                        }
                                    }
                                }
                                else
                                {
                                    App.Msg("权限不足！");
                                    return;
                                }
                            }
                            else
                            {
                                string operateId = App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and item_show_name='" + itemName + "' and other_name='" + otherName + "' and patient_id=" + currentPatient.Id, 0, "creat_id");
                                if (id > 0)
                                {
                                    operateId = App.ReadSqlVal("select creat_id from t_nurse_record where id=" + id, 0, "creat_id");
                                }
                                if (App.UserAccount.UserInfo.User_id == operateId || App.UserAccount.CurrentSelectRole.Role_name.Equals("护士长"))
                                {
                                    if (id > 0)
                                    {
                                        sql = "delete from t_nurse_record where id=" + id;
                                    }
                                    else
                                    {
                                        sql = "delete from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and item_show_name='" + itemName + "' and other_name='" + otherName + "' and patient_id=" + currentPatient.Id;
                                    }
                                }
                                else
                                {
                                    App.Msg("权限不足！");
                                    return;
                                }
                            }
                        }
                        else//删除当前行的所有项目
                        {
                            string operateId = App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and patient_id=" + currentPatient.Id, 0, "creat_id");
                            if (App.UserAccount.UserInfo.User_id == operateId || App.UserAccount.CurrentSelectRole.Role_name.Equals("护士长"))
                            {
                                sql = "delete from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and patient_id=" + currentPatient.Id;
                            }
                            else
                            {
                                App.Msg("权限不足！");
                                return;
                            }
                        }
                    }


                    int num = App.ExecuteSQL(sql);
                    if (num > 0)
                    {
                        operateFlag = true;
                        timer1.Start();
                        //App.Msg("删除成功！");
                        //更新创建者
                        //App.ExecuteSQL("update t_nurse_record set creat_id='" + App.UserAccount.UserInfo.User_id + "'，create_time=sysdate, update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and patient_id=" + currentPatient.Id);
                        btnSearch_Click(sender, e);
                    }
                }

            }
            catch (Exception ex)
            {
                
            }
        }




        private bool ValidateUser(string operateId)
        {
            try
            {

                //当前登陆者的信息
                string strUpdateName = App.UserAccount.UserInfo.User_name.ToString();//记录当前登陆用户名称
                string strUpdateUserId = App.UserAccount.UserInfo.User_id.ToString();//记录当前登陆用户id
                string strUpdateZC = "";//记录当前登陆用户职称
                string strUpdateZCcode = App.UserAccount.UserInfo.U_tech_post.ToString();//记录当前登陆用户职称的code
                if (strUpdateZCcode != "")
                {
                    strUpdateZC = App.ReadSqlVal("select name from t_data_code t where t.id='" + strUpdateZCcode + "'", 0, "name");//通过用户职称的code取到职称
                }
                string strUpdateRole = App.UserAccount.CurrentSelectRole.Role_name.ToString();//记录当前登陆用户角色
                string strUpdatedDQZC = "";//登陆者的当前职称
                if (strUpdateZC == "实习护士" || strUpdateRole == "实习护士")
                {
                    strUpdatedDQZC = "1";
                }
                if (strUpdateZC == "护士" || strUpdateRole == "护士")
                {
                    strUpdatedDQZC = "2";
                }
                if (strUpdateZC == "护师" || strUpdateRole == "护师")
                {
                    strUpdatedDQZC = "3";
                }
                if (strUpdateZC == "主管护师" || strUpdateRole == "主管护师")
                {
                    strUpdatedDQZC = "4";
                }
                if (strUpdateZC == "副主任护师" || strUpdateRole == "副主任护师")
                {
                    strUpdatedDQZC = "5";
                }
                if (strUpdateZC == "主任护师" || strUpdateRole == "主任护师")
                {
                    strUpdatedDQZC = "6";
                }
                if (strUpdateZC == "护士长" || strUpdateRole == "护士长")
                {
                    strUpdatedDQZC = "7";
                }
                //数据创建者的信息
                string strCreateName = App.ReadSqlVal("select user_name  from t_Userinfo t  where t.user_id='" + operateId + "'", 0, "user_name");//取到创建者的名称
                string strCreateCode = App.ReadSqlVal("select u_tech_post  from t_Userinfo t  where t.user_id='" + operateId + "'", 0, "u_tech_post");//取到创建者的code
                string strCreateZC = "";//用来记录创建者的职称
                if (strCreateCode != "")
                {
                    strCreateZC = App.ReadSqlVal("select name from t_data_code t where t.id='" + strCreateCode + "'", 0, "name");//取到创建者的职称
                }
                string strCreateRole = "";//用来接收创建者的较色
                DataSet ds = new DataSet();
                ds = App.GetDataSet("select t4.role_name from t_userinfo t1, t_account_user t2, t_acc_role t3,t_role t4" +
                           @" where t1.user_id = t2.user_id  and t2.account_id = t3.account_id and t3.role_id = t4.role_id and t1.user_id='" + operateId + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    strCreateRole = ds.Tables[0].Rows[0]["role_name"].ToString();//取到创建者的角色
                }
                string strCreateDQZC = "";
                if (strCreateZC == "实习护士" || strCreateRole == "实习护士")
                {
                    strCreateDQZC = "1";
                }
                if (strCreateZC == "护士" || strCreateRole == "护士")
                {
                    strCreateDQZC = "2";
                }
                if (strCreateZC == "护师" || strCreateRole == "护师")
                {
                    strCreateDQZC = "3";
                }
                if (strCreateZC == "主管护师" || strCreateRole == "主管护师")
                {
                    strCreateDQZC = "4";
                }
                if (strCreateZC == "副主任护师" || strCreateRole == "副主任护师")
                {
                    strCreateDQZC = "5";
                }
                if (strCreateZC == "主任护师" || strCreateRole == "主任护师")
                {
                    strCreateDQZC = "6";
                }
                if (strCreateZC == "护士长" || strCreateRole == "护士长")
                {
                    strCreateDQZC = "7";
                }
                //当前登陆者和创建者权限的比较
                if (Convert.ToInt32(strUpdatedDQZC) > Convert.ToInt32(strCreateDQZC))//当前登陆者的权限高于创建者，返回true值
                {
                    return true;
                }
                else if (strUpdatedDQZC == strCreateDQZC)//登陆者的当前职称和创建者的当前职称相等，继而判断姓名是否相同
                {
                    if (strUpdateName == strCreateName)//姓名相同，继而判断user_id是否相同
                    {
                        if (strUpdateUserId == operateId)//user_id相同，返回true值
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private void lblDatePriview_Click(object sender, EventArgs e)
        {
            dtpDate.Value = Convert.ToDateTime(dtpDate.Value.AddDays(-1));
            lblDatePriview.Text = dtpDate.Value.AddDays(-1).ToShortDateString() + "<<";
            lblDateNext.Text = ">>" + dtpDate.Value.AddDays(1).ToShortDateString();
        }

        private void lblDateNext_Click(object sender, EventArgs e)
        {
            dtpDate.Value = Convert.ToDateTime(dtpDate.Value.AddDays(1));
            lblDateNext.Text = ">>" + dtpDate.Value.AddDays(1).ToShortDateString();
            lblDatePriview.Text = dtpDate.Value.AddDays(-1).ToShortDateString() + "<<";
            //btnSelect_Click(sender, e);
        }

        /// <summary>
        /// 获取中英文混排字符串的实际长度(字节数)
        /// </summary>
        /// <param name="str">要获取长度的字符串</param>
        /// <returns>字符串的实际长度值（字节数）</returns>
        public int getStringLength(string str)
        {
            if (str.Equals(string.Empty))
                return 0;
            int strlen = 0;
            ASCIIEncoding strData = new ASCIIEncoding();
            //将字符串转换为ASCII编码的字节数字
            byte[] strBytes = strData.GetBytes(str);
            for (int i = 0; i <= strBytes.Length - 1; i++)
            {
                if (strBytes[i] == 63)  //中文都将编码为ASCII编码63,即"?"号
                    strlen++;
                strlen++;
            }
            return strlen;
        }

        bool operateFlag = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (operateFlag)
            {
                lblOperate.Visible = true;
                operateFlag = false;
                timer1.Interval = 1500;
            }
            else
            {
                lblOperate.Visible = false;
                timer1.Interval = 1;
                timer1.Stop();
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            //诊断名称
            diagnose = txtDiagnose.Text.Trim();
            string update_Sql = @"update t_nurse_record set diagnose_name='" + diagnose + "' where patient_id='" + this.currentPatient.Id + "' and record_type='" + strType + "'";
            int count = 0;
            try
            {
                count = App.ExecuteSQL(update_Sql);
            }
            catch (Exception)
            {

                //throw;
            }
            if (count > 0)
            {
                App.Msg("保存成功！");
                //this.Close();
            }
        }

        /// <summary>
        ///加载诊断
        /// </summary>
        private void LoadDiagnose()
        {
            //获取诊断
            if (diagnose == "" || diagnose == null)
            {
                diagnose = App.ReadSqlVal("select diagnose_name from T_NURSE_RECORD where Patient_Id =" + currentPatient.Id+" and record_type='"+strType+"'", 0, "diagnose_name");//自己修改的护理
            }
            if (diagnose == "" || diagnose == null)
            {
                diagnose = App.ReadSqlVal("select diagnose_name from t_diagnose_item where diagnose_type='403' and Patient_Id =" + currentPatient.Id, 0, "diagnose_name");//初步诊断
            }
            if (diagnose == "" || diagnose == null)
            {
                diagnose = App.ReadSqlVal("select diagnose_name from t_diagnose_item where diagnose_type='408' and Patient_Id =" + currentPatient.Id, 0, "diagnose_name");//初步诊断
            }
            if (diagnose == null)
            {
                diagnose = "";
            }
            txtDiagnose.Text = diagnose;
        }

        private void flgView_ChangeEdit(object sender, EventArgs e)
        {
            using (Graphics g = flgView.CreateGraphics())
            {
                if (flgView.Col == 25)
                {
                    // measure text height
                    StringFormat sf = new StringFormat();
                    int wid = flgView.Cols[25].WidthDisplay;
                    string text = flgView.Editor.Text;
                    SizeF sz = g.MeasureString(text, flgView.Font, wid, sf);
                    // adjust row height if necessary
                    C1.Win.C1FlexGrid.Row row = flgView.Rows[flgView.Row];
                    if (sz.Height + 4 > row.HeightDisplay)
                        row.HeightDisplay = (int)sz.Height + 4;
                }
            }
        }

        private void 提取备注模板ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Base_Function.BLL_NURSE.NurseTemplate.frmTemplateList fc = new Base_Function.BLL_NURSE.NurseTemplate.frmTemplateList();
                fc.ShowDialog();
                //赋值
                if (fc.nursecomplate != null && fc.nursecomplate != "")
                {
                    this.flgView[flgView.Row, flgView.Col] = fc.nursecomplate;
                    RowColEventArgs ea = new RowColEventArgs(flgView.Row, flgView.Col);
                    this.flgView_AfterEdit(flgView, ea);
                    this.flgView.Select(flgView.Row, flgView.Col);
                }
            }
            catch (Exception)
            {
            }
        }

        private void 添加备注模板ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (flgView[flgView.Row, flgView.Col] != null)
            {
                Base_Function.BLL_NURSE.NurseTemplate.frmTemplateAdd fc = new Base_Function.BLL_NURSE.NurseTemplate.frmTemplateAdd(flgView[flgView.Row, flgView.Col].ToString());
                fc.ShowDialog();
            }
        }

        private int PageRowCount = 21;
        private void ShowMsg()
        {
            #region 护理记录单满页提醒
            //DataSet ds = GetNusersRecords() == null ? null : ReSetPrintDataSet(GetNusersRecords());
            DataSet ds = GetNusersRecords();
            if (ds != null)
            {
                ds = ReSetPrintDataSet(ds);
            }
            int PageCount = 0;
            int FullLastPage = 0;
            if (ds == null || ds.Tables == null || ds.Tables[0].Rows.Count == 0)
            {
                lmsg1.Text = "此患者没有护理记录信息";
                lmsg2.Text = "";
            }
            else
            {
                int nrow = ds.Tables[0].Rows.Count;
                if (nrow % PageRowCount == 0)
                {
                    PageCount = nrow / PageRowCount;
                    FullLastPage = PageCount;
                }
                else
                {
                    PageCount = nrow / PageRowCount + 1;
                    FullLastPage = PageCount - 1;
                }
                lmsg1.Text = "共" + PageCount.ToString() + "页,";
                if (FullLastPage > 0)
                {
                    int fullpagerowindex = FullLastPage * PageRowCount - 1;
                    DateTime dtime = new DateTime();
                    string stime = ds.Tables[0].Rows[fullpagerowindex]["DateTime"].ToString();
                    while (!DateTime.TryParse(stime, out dtime))
                    {
                        fullpagerowindex--;
                        stime = ds.Tables[0].Rows[fullpagerowindex]["DateTime"].ToString();
                    }
                    lmsg1.Text += "第" + FullLastPage.ToString() + "页已满页";
                    //while (stime.Length < 10)
                    //{
                    //    fullpagerowindex--;
                    //    stime = ds.Tables[0].Rows[fullpagerowindex]["DateTime"].ToString();
                    //}
                    lmsg2.Text = "满页记录时间为：" + dtime.ToString("yyyy-MM-dd HH:mm");
                }
                else
                {
                    lmsg2.Text = "无满页信息";
                }

            }
            #endregion

            #region 病危提示
            if (!string.IsNullOrEmpty(currentPatient.Die_flag.ToString()))
            {
                if (currentPatient.Sick_Degree == "3")
                {
                    lmsg3.Visible = true;
                }
                else if (currentPatient.Sick_Degree == "2")
                {
                    lmsg3.Text = "病重患者护理记录每天至少一次";
                    lmsg3.Visible = true;
                }
                else
                {
                    lmsg3.Visible = false;
                }
            }


            #endregion
        }
    }
}
