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
using Base_Function.BASE_COMMON;

namespace Base_Function.BLL_NURSE.Nurse_Record
{
    public partial class UcNurse_Record : UserControl
    {
        /// <summary>
        /// 列名称字典
        /// 键:列索引
        /// 值:项目名称
        /// </summary>
        Dictionary<int, string> dictColumnName = new Dictionary<int, string>();
        ColumnInfo[] cols = new ColumnInfo[36];
        /// <summary>
        /// 护理记录单行对象的集合
        /// </summary>
        ArrayList nurses = new ArrayList();
        ArrayList SumNusers = new ArrayList();
        ArrayList SumNusersRecords = new ArrayList();

        #region 字典
        ListDictionary ldPathography = new ListDictionary();//病情程度
        ListDictionary ldNurseLevel = new ListDictionary();//护理级别字典
        ListDictionary ldConsciousness = new ListDictionary();//意识字典
        //ListDictionary ldInAmount = new ListDictionary();//入量字典
        ListDictionary ldXY = new ListDictionary();//吸氧字典
        ListDictionary ldNurseItem = new ListDictionary();//护理记录单项目字典
        ListDictionary ldOpreationSpecialCheck = new ListDictionary();//手术特检字典
        ListDictionary ldWoundSkin = new ListDictionary();//伤口皮肤字典
        ListDictionary ldSafeNurse = new ListDictionary();//安全护理
        #endregion
        /// <summary>
        /// 诊断
        /// </summary>
        public string diagnose = "";
        #region 管路名称
        public string pipe1 = "";
        public string pipe2 = "";
        public string pipe3 = "";
        public string pipe4 = "";
        public string pipe5 = "";
        #endregion

        /// <summary>
        /// 变更前的入量名称
        /// </summary>
        string oldInAmountName = "";

        /// <summary>
        /// 变更前的入量代码
        /// </summary>
        string oldInAmountCode = "";

        /// <summary>
        /// 当前病人
        /// </summary>
        InPatientInfo currentPatient = null;

        Class_Take_over_SEQ[] Take_over_seq;

        public UcNurse_Record()
        {
            InitializeComponent();
        }
        private string strType = "D";
        public UcNurse_Record(InPatientInfo patient)
        {
            InitializeComponent();
            currentPatient = patient;
            Take_over_SEQ();//绑定班次
            SetCellData();
            LoadDiagnose();
            //SetDictionaryForItem();
        }

        private void UcNurse_Record_Load(object sender, EventArgs e)
        {

            //SetCellData();//绑定单元格数据
            try
            {
                bindColData();
                SetDictionaryForItem();
                this.flgView.Styles.Normal.WordWrap = true;
                cboTiming_SelectedIndexChanged(sender, e);//加载统计项时间
                //ShowMsg();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            //btnSearch_Click(sender, e);
        }

        /// <summary>
        /// 绑定班次表
        /// </summary>
        private void Take_over_SEQ()
        {
            DataSet ds = App.GetDataSet("select * from T_TAKE_OVER_SEQ order by seq,ID asc");
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
            if (cboTiming.Items.Count>0)
            {
                cboTiming.SelectedIndex = 0;
            }
            
            //cboTiming.Text = "24h总结";
        }

        /// <summary>
        /// 设置项目字典
        /// </summary>
        public void SetDictionaryForItem()
        {
            dictColumnName.Add(0, "时间日期");
            dictColumnName.Add(1, "病情程度");
            dictColumnName.Add(2, "护理级别");
            dictColumnName.Add(3, "体温");
            dictColumnName.Add(4, "脉搏");
            dictColumnName.Add(5, "心率");
            dictColumnName.Add(6, "呼吸");
            dictColumnName.Add(7, "血压");
            dictColumnName.Add(8, "意识");
            dictColumnName.Add(9, "左");
            dictColumnName.Add(10, "右");
            dictColumnName.Add(11, "氧饱和度");
            dictColumnName.Add(12, "入量");
            dictColumnName.Add(13, "入量");
            dictColumnName.Add(14, "大便");
            dictColumnName.Add(15, "小便");
            dictColumnName.Add(16, "管1颜色");
            dictColumnName.Add(17, "管1量");
            dictColumnName.Add(18, "管2颜色");
            dictColumnName.Add(19, "管2量");
            dictColumnName.Add(20, "管3颜色");
            dictColumnName.Add(21, "管3量");
            dictColumnName.Add(22, "管4颜色");
            dictColumnName.Add(23, "管4量");
            dictColumnName.Add(24, "管5颜色");
            dictColumnName.Add(25, "管5量");
            dictColumnName.Add(26, "手术");
            dictColumnName.Add(27, "特检");
            dictColumnName.Add(28, "伤口");
            dictColumnName.Add(29, "皮肤");
            dictColumnName.Add(30, "吸氧");
            dictColumnName.Add(31, "吸氧");
            dictColumnName.Add(32, "安全护理");
            dictColumnName.Add(33, "备注");
            dictColumnName.Add(34, "签名");
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
            pipe3 = "";
            pipe4 = "";
            pipe5 = "";
            try
            {
                #region 数据加载
                string dateTime = dtpDate.Value.ToString("yyyy-MM-dd HH:mm");

                string sql_time = "select distinct to_char(t.measure_time,'yyyy-mm-dd hh24:mi') as DATETIMEVAL from T_NURSE_RECORD t where RECORD_TYPE in ('D',null) and t.patient_Id=" + currentPatient.Id + " and to_char(t.measure_time,'yyyy-MM-dd')='" + dtpDate.Value.ToString("yyyy-MM-dd") + "' order by DATETIMEVAL asc";
                string sql_set = "select to_char(t.measure_time,'yyyy-mm-dd hh24:mi') as DATETIMEVAL,t.id,t.item_code,a.item_name,t.item_show_name,a.item_attribute,t.item_value,t.other_name,a.item_type,t.status_measure,t.creat_id,d.user_name,t.diagnose_name,PATIENT_ID from T_NURSE_RECORD t " +
                                " left join t_nurse_record_dict a on  to_char(a.id)=t.item_code left join T_DATA_CODE b on a.item_attribute=b.id inner " +
                                " join T_ACCOUNT_USER c on t.creat_id=c.user_id inner join T_USERINFO d on d.user_id=c.user_id where RECORD_TYPE in ('D',null) and patient_Id=" + currentPatient.Id + " and to_char(t.measure_time,'yyyy-MM-dd')='" + dtpDate.Value.ToString("yyyy-MM-dd") + "' order by t.create_time asc ";
                //时间集合
                DataSet ds_time_sets = App.GetDataSet(sql_time);
                //项目集合
                DataSet ds_values_sets = App.GetDataSet(sql_set);

                DataTable dt_time = ds_time_sets.Tables[0];
                DataTable dt_sets = ds_values_sets.Tables[0];
                if (dt_sets.Rows.Count > 0)
                {
                    if (dt_sets.Rows[0]["diagnose_name"] != null)
                    {
                        diagnose = dt_sets.Rows[0]["diagnose_name"].ToString();
                    }
                }
                if (dt_time != null)
                {
                    for (int i = 0; i < dt_time.Rows.Count; i++)
                    {
                        string dateTimeValue = dt_time.Rows[i]["DATETIMEVAL"].ToString();

                        //常用项目数组
                        DataRow[] dr_Values = dt_sets.Select(" DATETIMEVAL='" + dateTimeValue + "'");

                        //入量
                        DataRow[] dr_InAmount = dt_sets.Select("item_show_name='入量' and DATETIMEVAL='" + dateTimeValue + "'", "id asc");
                        int index = dr_InAmount.Length;
                        if (index == 0)
                            index = 1;
                        for (int j = 0; j < index; j++)
                        {
                            Class_Nurse_Record temp = new Class_Nurse_Record();
                            temp.DateTime = dateTimeValue;
                            //if (j == 0)
                            //{
                            //入量
                            if (dr_InAmount.Length > 0 && j < dr_InAmount.Length)
                            {
                                temp.In_item_name = dr_InAmount[j]["item_code"].ToString();
                                temp.In_item_value = dr_InAmount[j]["item_value"].ToString();
                                temp.Number = dr_InAmount[j]["id"].ToString();
                            }

                            //}

                            for (int k = 0; k < dr_Values.Length; k++)
                            {
                                if (j == 0)//非入量的项目只在当前时间段的第一行显示
                                {
                                    if (dr_Values[k]["item_show_name"].ToString() == "病情程度")
                                    {
                                        temp.Pathography = dr_Values[k]["item_code"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "护理级别")
                                    {
                                        //switch (dr_Values[k]["item_value"].ToString())
                                        //{
                                        //    case "1":
                                        //        temp.NurseLevel = "0";
                                        //        break;
                                        //    case "2":
                                        //        temp.NurseLevel = "1";
                                        //        break;
                                        //    case "3":
                                        //        temp.NurseLevel = "2";
                                        //        break;
                                        //    case "特":
                                        //        temp.NurseLevel = "3";
                                        //        break;
                                        //    default:
                                        temp.NurseLevel = dr_Values[k]["item_code"].ToString();
                                        //        break;
                                        //}
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "体温")
                                    {
                                        temp.Temperature = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "脉搏")
                                    {
                                        temp.Pulse = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "心率")
                                    {
                                        temp.HeartRate = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "呼吸")
                                    {
                                        temp.Breathe = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "血压")
                                    {
                                        temp.Blood_pressure = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "意识")
                                    {
                                        temp.Consciousness = dr_Values[k]["item_code"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "左")
                                    {
                                        temp.Pupil_left = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "右")
                                    {
                                        temp.Pupil_right = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "氧饱和度")
                                    {
                                        temp.Bp_saturation = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "大便")
                                    {
                                        temp.Shit = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "小便")
                                    {
                                        temp.Urine = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "手术")
                                    {
                                        temp.Operation = dr_Values[k]["item_code"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "特检")
                                    {
                                        temp.SpecialCheck = dr_Values[k]["item_code"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "伤口")
                                    {
                                        temp.Wound = dr_Values[k]["item_code"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "皮肤")
                                    {
                                        temp.Skin = dr_Values[k]["item_code"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "吸氧")
                                    {
                                        temp.Xy = dr_Values[k]["item_code"].ToString();
                                        temp.Ll = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "安全护理")
                                    {
                                        temp.Safe_Nurse = dr_Values[k]["item_code"].ToString();
                                    }
                                    //else if (dr_Values[k]["status_measure"].ToString() != "")
                                    //{
                                    //    temp.Remark = dr_Values[k]["status_measure"].ToString().Split('@').GetValue(0).ToString();
                                    //}
                                    else if (dr_Values[k]["item_show_name"].ToString() == "备注")
                                    {
                                        temp.Remark = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "管1颜色")
                                    {
                                        temp.Pipe1_Color = dr_Values[k]["item_value"].ToString();
                                        pipe1 = dr_Values[k]["other_name"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "管1量")
                                    {
                                        temp.Pipe1_Value = dr_Values[k]["item_value"].ToString();
                                        pipe1 = dr_Values[k]["other_name"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "管2颜色")
                                    {
                                        temp.Pipe2_Color = dr_Values[k]["item_value"].ToString();
                                        pipe2 = dr_Values[k]["other_name"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "管2量")
                                    {
                                        temp.Pipe2_Value = dr_Values[k]["item_value"].ToString();
                                        pipe2 = dr_Values[k]["other_name"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "管3颜色")
                                    {
                                        temp.Pipe3_Color = dr_Values[k]["item_value"].ToString();
                                        pipe3 = dr_Values[k]["other_name"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "管3量")
                                    {
                                        temp.Pipe3_Value = dr_Values[k]["item_value"].ToString();
                                        pipe3 = dr_Values[k]["other_name"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "管4颜色")
                                    {
                                        temp.Pipe4_Color = dr_Values[k]["item_value"].ToString();
                                        pipe4 = dr_Values[k]["other_name"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "管4量")
                                    {
                                        temp.Pipe4_Value = dr_Values[k]["item_value"].ToString();
                                        pipe4 = dr_Values[k]["other_name"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "管5颜色")
                                    {
                                        temp.Pipe5_Color = dr_Values[k]["item_value"].ToString();
                                        pipe5 = dr_Values[k]["other_name"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "管5量")
                                    {
                                        temp.Pipe5_Value = dr_Values[k]["item_value"].ToString();
                                        pipe5 = dr_Values[k]["other_name"].ToString();
                                    }
                                    //temp.Number = dr_Values[k]["PATIENT_ID"].ToString();
                                    //temp.Signature = dr_Values[k]["user_name"].ToString();
                                }
                                if (j == index - 1)
                                {
                                    temp.Signature = dr_Values[0]["user_name"].ToString();
                                }
                            }
                            nurses.Add(temp);
                        }
                    }

                    //过滤相同的时间
                    string tempDateTime = null;
                    Class_Nurse_Record[] nurse = new Class_Nurse_Record[nurses.Count];
                    for (int i = 0; i < nurses.Count; i++)
                    {
                        nurse[i] = new Class_Nurse_Record();
                        nurse[i] = nurses[i] as Class_Nurse_Record;

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
                    //SetTable();
                    flgView.Rows.Count = 4 + nurses.Count;
                    try
                    {
                        if (nurse.Length != 0)
                        {
                            //nurse[nurse.Length - 1] = new Class_Nurse_Record();
                            App.ArrayToGrid(this.flgView, nurse, cols, 3);
                        }
                        else
                        {
                            flgView.Rows.Count = 3;
                        }
                    }
                    catch
                    {
                    }
                    //CellUnit(pipe1, pipe2, pipe3, pipe4);
                    //flgView.Refresh();
                    //flgView.AutoSizeCols();
                    //flgView.AutoSizeRows();
                }
                #endregion
            }
            catch (Exception ex)
            {
                App.MsgErr("数据加载错误!问题:" + ex.Message);
            }
            //flgView.Refresh();
            //flgView.AutoSizeCols();
            //flgView.AutoSizeRows();
        }

        /// <summary>
        /// 表头设置
        /// </summary>
        private void SetTable()
        {
            flgView.Cols.Count = 36;
            flgView.Rows.Count = 4 + nurses.Count;
            flgView.Rows.Fixed = 3;
            //表头设置
            cols[0].Name = "日期/时间";
            cols[0].Field = "dateTime";
            cols[0].Index = 1;
            cols[0].visible = true;

            //病情程度
            cols[1].Name = "病情程度";
            cols[1].Field = "pathography";
            cols[1].Index = 2;
            cols[1].visible = true;

            //护理级别
            cols[2].Name = "护理级别";
            cols[2].Field = "nurseLevel";
            cols[2].Index = 3;
            cols[2].visible = true;

            //体温
            cols[3].Name = "体温";
            cols[3].Field = "temperature";
            cols[3].Index = 4;
            cols[3].visible = true;

            //脉搏
            cols[4].Name = "脉搏/心率";
            cols[4].Field = "pulse";
            cols[4].Index = 5;
            cols[4].visible = true;

            //心率
            cols[5].Name = "脉搏/心率";
            cols[5].Field = "heartRate";
            cols[5].Index = 6;
            cols[5].visible = true;

            //呼吸
            cols[6].Name = "呼吸";
            cols[6].Field = "breathe";
            cols[6].Index = 7;
            cols[6].visible = true;

            //血压
            cols[7].Name = "血压";
            cols[7].Field = "blood_pressure";
            cols[7].Index = 8;
            cols[7].visible = true;

            //意识
            cols[8].Name = "意识";
            cols[8].Field = "consciousness";
            cols[8].Index = 9;
            cols[8].visible = true;

            //瞳孔左
            cols[9].Name = "左";
            cols[9].Field = "Pupil_left";
            cols[9].Index = 10;
            cols[9].visible = true;

            //瞳孔右
            cols[10].Name = "右";
            cols[10].Field = "Pupil_right";
            cols[10].Index = 11;
            cols[10].visible = true;

            //氧饱和度
            cols[11].Name = "氧饱和度";
            cols[11].Field = "bp_saturation";
            cols[11].Index = 12;
            cols[11].visible = true;

            //入量名称
            cols[12].Name = "名称";
            cols[12].Field = "in_item_name";
            cols[12].Index = 13;
            cols[12].visible = true;

            //入量数值
            cols[13].Name = "量";
            cols[13].Field = "in_item_value";
            cols[13].Index = 14;
            cols[13].visible = true;

            //大便
            cols[14].Name = "大便";
            cols[14].Field = "Shit";
            cols[14].Index = 15;
            cols[14].visible = true;

            //小便
            cols[15].Name = "小便";
            cols[15].Field = "Urine";
            cols[15].Index = 16;
            cols[15].visible = true;

            #region xx管 色/量
            cols[16].Name = "色1";
            cols[16].Field = "Pipe1_Color";
            cols[16].Index = 17;
            cols[16].visible = true;

            cols[17].Name = "量1";
            cols[17].Field = "Pipe1_Value";
            cols[17].Index = 18;
            cols[17].visible = true;

            cols[18].Name = "色2";
            cols[18].Field = "Pipe2_Color";
            cols[18].Index = 19;
            cols[18].visible = true;

            cols[19].Name = "量2";
            cols[19].Field = "Pipe2_Value";
            cols[19].Index = 20;
            cols[19].visible = true;

            cols[20].Name = "色3";
            cols[20].Field = "Pipe3_Color";
            cols[20].Index = 21;
            cols[20].visible = true;

            cols[21].Name = "量3";
            cols[21].Field = "Pipe3_Value";
            cols[21].Index = 22;
            cols[21].visible = true;

            cols[22].Name = "色4";
            cols[22].Field = "Pipe4_Color";
            cols[22].Index = 23;
            cols[22].visible = true;

            cols[23].Name = "量4";
            cols[23].Field = "Pipe4_Value";
            cols[23].Index = 24;
            cols[23].visible = true;

            cols[24].Name = "色5";
            cols[24].Field = "Pipe5_Color";
            cols[24].Index = 25;
            cols[24].visible = true;

            cols[25].Name = "量5";
            cols[25].Field = "Pipe5_Value";
            cols[25].Index = 26;
            cols[25].visible = true;
            #endregion

            //手术
            cols[26].Name = "手术";
            cols[26].Field = "Operation";
            cols[26].Index = 27;
            cols[26].visible = true;

            //特检
            cols[27].Name = "特检";
            cols[27].Field = "SpecialCheck";
            cols[27].Index = 28;
            cols[27].visible = true;

            //伤口
            cols[28].Name = "伤口";
            cols[28].Field = "Wound";
            cols[28].Index = 29;
            cols[28].visible = true;

            //皮肤
            cols[29].Name = "皮肤";
            cols[29].Field = "Skin";
            cols[29].Index = 30;
            cols[29].visible = true;

            //吸氧
            cols[30].Name = "吸氧";
            cols[30].Field = "Xy";
            cols[30].Index = 31;
            cols[30].visible = true;

            //流量
            cols[31].Name = "流量";
            cols[31].Field = "Ll";
            cols[31].Index = 32;
            cols[31].visible = true;

            //安全护理
            cols[32].Name = "安全护理";
            cols[32].Field = "Safe_Nurse";
            cols[32].Index = 33;
            cols[32].visible = true;

            //备注
            cols[33].Name = "备注";
            cols[33].Field = "Remark";
            cols[33].Index = 34;
            cols[33].visible = true;

            //签名
            cols[34].Name = "签名";
            cols[34].Field = "signature";
            cols[34].Index = 35;
            cols[34].visible = true;

            cols[35].Name = "SumID";
            cols[35].Field = "Number";
            cols[35].Index = 36;
            cols[35].visible = false;
        }

        /// <summary>
        /// 单元格合并和设置 
        /// </summary>
        /// <param name="pipe1">xx管名</param>
        /// <param name="pipe2">xx管名</param>
        /// <param name="pipe3">xx管名</param>
        /// <param name="pipe4">xx管名</param>
        private void CellUnit(string pipe1, string pipe2, string pipe3, string pipe4, string pipe5)
        {
            flgView.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            flgView.Cols.Fixed = 0;

            C1.Win.C1FlexGrid.CellRange cr;
            cr = flgView.GetCellRange(0, 0, 2, 0);
            cr.Data = "日期\r\n/\r\n时间";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 1, 2, 1);
            cr.Data = "病\r\n情\r\n程\r\n度";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 2, 2, 2);
            cr.Data = "护\r\n理\r\n级\r\n别";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 3, 2, 3);
            cr.Data = "体\r\n温";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 4, 2, 5);
            cr.Data = "脉搏\r\n/\r\n心率";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 6, 2, 6);
            cr.Data = "呼\r\n吸";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 7, 2, 7);
            cr.Data = "血\r\n压";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 8, 2, 8);
            cr.Data = "意\r\n识";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            //瞳孔
            cr = flgView.GetCellRange(0, 9, 0, 10);
            cr.Data = "瞳  孔";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 9, 2, 9);
            cr.Data = "左";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 10, 2, 10);
            cr.Data = "右";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 11, 2, 11);
            cr.Data = "氧\r\n饱\r\n和\r\n度";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            //入量
            cr = flgView.GetCellRange(0, 12, 0, 13);
            cr.Data = "入  量";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 12, 2, 12);
            cr.Data = "名称";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 13, 2, 13);
            cr.Data = "量";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            //出量
            cr = flgView.GetCellRange(0, 14, 0, 25);
            cr.Data = "出  量";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 14, 2, 14);
            cr.Data = "大便";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 15, 2, 15);
            cr.Data = "小便";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);
            #region 管 自定义项目
            //__管
            cr = flgView.GetCellRange(1, 16, 1, 17);
            cr.Data = pipe1;
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(2, 16, 2, 16);
            cr.Data = "色";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(2, 17, 2, 17);
            cr.Data = "量";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            //__管
            cr = flgView.GetCellRange(1, 18, 1, 19);
            cr.Data = pipe2;
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(2, 18, 2, 18);
            cr.Data = "色";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(2, 19, 2, 19);
            cr.Data = "量";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            //__管
            cr = flgView.GetCellRange(1, 20, 1, 21);
            cr.Data = pipe3;
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(2, 20, 2, 20);
            cr.Data = "色";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(2, 21, 2, 21);
            cr.Data = "量";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            //__管
            cr = flgView.GetCellRange(1, 22, 1, 23);
            cr.Data = pipe4;
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(2, 22, 2, 22);
            cr.Data = "色";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(2, 23, 2, 23);
            cr.Data = "量";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            //__管
            cr = flgView.GetCellRange(1, 24, 1, 25);
            cr.Data = pipe5;
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(2, 24, 2, 24);
            cr.Data = "色";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(2, 25, 2, 25);
            cr.Data = "量";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);
            #endregion

            cr = flgView.GetCellRange(0, 26, 2, 26);
            cr.Data = "手\r\n术";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 27, 2, 27);
            cr.Data = "特\r\n检";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 28, 2, 28);
            cr.Data = "伤\r\n口";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 29, 2, 29);
            cr.Data = "皮\r\n肤";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 30, 2, 31);
            cr.Data = "吸\r\n氧\r\n/\r\n流\r\n量";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            //cr = flgView.GetCellRange(0, 22, 2, 22);
            //cr.Data = "流\r\n量";
            //cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            //flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 32, 2, 32);
            cr.Data = "安\r\n全\r\n护\r\n理";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 33, 2, 33);
            cr.Data = "备  注";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 34, 2, 34);
            cr.Data = "签名";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            //flgView.AutoSizeCols();
            //flgView.Cols[31].Width = 50;
            //flgView.AutoSizeRows();
            
        }

        private void SetCellData()
        {
            //护理字典：96入量，吸氧927，
            string sql_Nurse = "select item_code,item_name,item_type from t_nurse_record_dict where item_type in(96,927)";
            DataSet ds_Nurse = App.GetDataSet(sql_Nurse);
            //数据字典：意识196，病情程度30,护理等级197
            string sql_Data = "select code,name,type from t_data_code where type in(30,197,196) order by code";
            DataSet ds_Data = App.GetDataSet(sql_Data);
            //时间日期
            //flgView.Cols[0].DataType = Type.GetType("System.DateTime");
            //flgView.Cols[0].Format = "yyyy-MM-dd HH:mm";

            if (sql_Nurse != null && ds_Data != null)
            {
                //病情程度
                DataRow[] dr = ds_Data.Tables[0].Select("type='30'");
                for (int i = 0; i < dr.Length; i++)
                {
                    ldPathography.Add(dr[i]["code"].ToString(), dr[i]["name"].ToString());
                }
                ldPathography.Add("nul", " ");

                //护理级别
                dr = ds_Data.Tables[0].Select("type='197'");

                for (int i = 0; i < dr.Length; i++)
                {
                    ldNurseLevel.Add(dr[i]["code"].ToString(), dr[i]["name"].ToString());
                }
                ldNurseLevel.Add("nul", " ");
                //ldNurseLevel.Add("0", "I");
                //ldNurseLevel.Add("1", "II");
                //ldNurseLevel.Add("2", "III");
                //ldNurseLevel.Add("3", "特");
                //ldNurseLevel.Add("nul", " ");

                //意识
                dr = ds_Data.Tables[0].Select("type='196'");
                for (int i = 0; i < dr.Length; i++)
                {
                    ldConsciousness.Add(dr[i]["code"].ToString(), dr[i]["name"].ToString());
                }
                ldConsciousness.Add("nul", " ");

                ////入量
                //dr = ds_Nurse.Tables[0].Select("item_type=96");
                //for (int i = 0; i < dr.Length; i++)
                //{
                //    ldInAmount.Add(dr[i]["item_code"].ToString(), dr[i]["item_name"].ToString());
                //}
                //flgView.Cols[12].DataMap = ldInAmount;

                //吸氧
                dr = ds_Nurse.Tables[0].Select("item_type=927");
                
                for (int i = 0; i < dr.Length; i++)
                {                  
                    ldXY.Add(dr[i]["item_code"].ToString(), dr[i]["item_name"].ToString());
                }
                ldXY.Add("nul", " ");

                //手术
                ldOpreationSpecialCheck.Add("0", " ");
                ldOpreationSpecialCheck.Add("1", "√");
              

                //伤口
                ldWoundSkin.Add("0", " ");
                ldWoundSkin.Add("1", "√");
                ldWoundSkin.Add("2", "×");
               


                //安全护理
                ldSafeNurse.Add("0", " ");
                ldSafeNurse.Add("1", "√");
               
            }
        }

        /// <summary>
        /// 绑定表格数据
        /// </summary>
        private void bindColData()
        {
            try
            {
                flgView.Cols[1].DataMap = ldPathography;//病情程度
                
                flgView.Cols[2].DataMap = ldNurseLevel;
                flgView.Cols[8].DataMap = ldConsciousness;//意识
                
                flgView.Cols[30].DataMap = ldXY;
                flgView.Cols[26].DataMap = ldOpreationSpecialCheck;
                //特检
                flgView.Cols[27].DataMap = ldOpreationSpecialCheck;
                flgView.Cols[32].DataMap = ldSafeNurse;
                flgView.Cols[28].DataMap = ldWoundSkin;
                //皮肤
                flgView.Cols[29].DataMap = ldWoundSkin;
            }
            catch
            { }
        }

        /// <summary>
        ///加载诊断
        /// </summary>
        private void LoadDiagnose()
        {
            //获取诊断
            if (diagnose == "" || diagnose == null)
            {
                diagnose = App.ReadSqlVal("select diagnose_name from T_NURSE_RECORD where RECORD_TYPE in ('D',null) and Patient_Id =" + currentPatient.Id, 0, "diagnose_name");//自己修改的护理
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
                diagnose = App.ReadSqlVal("select diagnose_name from T_NURSE_RECORD where (RECORD_TYPE='D' or RECORD_TYPE is null) and Patient_Id =" + currentPatient.Id, 0, "diagnose_name");//自己修改的护理
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
            frmNursePrint_Records ff = new frmNursePrint_Records(ReSetPrintDataSet(ds), currentPatient, diagnose, pipe1, pipe2, pipe3, pipe4, pipe5);
            ff.Show();
        }

        public DataSet GetNusersRecords()
        {
            DataSet ds = null;
            ShowDatas();
            SumInOrOutRecordSets();
            Class_Nurse_Record[] cNurse = new Class_Nurse_Record[nurses.Count];
            for (int i = 0; i < nurses.Count; i++)
            {
                cNurse[i] = new Class_Nurse_Record();
                cNurse[i] = nurses[i] as Class_Nurse_Record;
                if (cNurse[i].In_item_name==null)
                {
                    cNurse[i].In_item_name = "";
                }
                //代码转换成类型名称
                if (cNurse[i].Consciousness != null)
                    cNurse[i].Consciousness = ldConsciousness[cNurse[i].Consciousness].ToString();
                if (cNurse[i].In_item_name != null && App.IsNumeric(cNurse[i].In_item_name))
                {                    
                    cNurse[i].In_item_name = cNurse[i].In_item_name.ToString();                    
                }
                if (cNurse[i].NurseLevel != null)
                    cNurse[i].NurseLevel = ldNurseLevel[cNurse[i].NurseLevel].ToString();
                if (cNurse[i].Operation != null)
                    cNurse[i].Operation = ldOpreationSpecialCheck[cNurse[i].Operation].ToString();
                if (cNurse[i].SpecialCheck != null)
                    cNurse[i].SpecialCheck = ldOpreationSpecialCheck[cNurse[i].SpecialCheck].ToString();
                if (cNurse[i].Pathography != null)
                    cNurse[i].Pathography = ldPathography[cNurse[i].Pathography].ToString();
                if (cNurse[i].Safe_Nurse != null)
                    cNurse[i].Safe_Nurse = ldSafeNurse[cNurse[i].Safe_Nurse].ToString();
                if (cNurse[i].Wound != null)
                    cNurse[i].Wound = ldWoundSkin[cNurse[i].Wound].ToString();
                if (cNurse[i].Skin != null)
                    cNurse[i].Skin = ldWoundSkin[cNurse[i].Skin].ToString();
                if (cNurse[i].Xy != null)
                    cNurse[i].Xy = ldXY[cNurse[i].Xy].ToString();

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
            pipe3 = "";
            pipe4 = "";
            pipe5 = "";
            //SetTable();
            try
            {
                #region 数据加载
                string dateTime = dtpDate.Value.ToString("yyyy-MM-dd HH:mm");

                string sql_time = "select distinct to_char(t.measure_time,'yyyy-mm-dd hh24:mi') as DATETIMEVAL from T_NURSE_RECORD t where RECORD_TYPE in ('D',null) and t.patient_Id=" + currentPatient.Id + " order by DATETIMEVAL asc";
                string sql_set = "select to_char(t.measure_time,'yyyy-mm-dd hh24:mi') as DATETIMEVAL,t.id,t.item_code,a.item_name,t.item_show_name,a.item_attribute,t.item_value,t.other_name,a.item_type,t.status_measure,t.creat_id,d.user_name,t.diagnose_name,PATIENT_ID from T_NURSE_RECORD t " +
                                " left join t_nurse_record_dict a on  to_char(a.id)=t.item_code left join T_DATA_CODE b on a.item_attribute=b.id inner " +
                                " join T_ACCOUNT_USER c on t.creat_id=c.user_id inner join T_USERINFO d on d.user_id=c.user_id where RECORD_TYPE in ('D',null) and patient_Id=" + currentPatient.Id + " order by t.create_time asc ";
                //时间集合
                DataSet ds_time_sets = App.GetDataSet(sql_time);
                //项目集合
                DataSet ds_values_sets = App.GetDataSet(sql_set);

                DataTable dt_time = ds_time_sets.Tables[0];
                DataTable dt_sets = ds_values_sets.Tables[0];

                if (dt_sets.Rows.Count > 0)
                {
                    if (dt_sets.Rows[0]["diagnose_name"] != null)
                    {
                        diagnose = dt_sets.Rows[0]["diagnose_name"].ToString();
                    }
                }
                if (dt_time != null)
                {
                    for (int i = 0; i < dt_time.Rows.Count; i++)
                    {
                        string dateTimeValue = dt_time.Rows[i]["DATETIMEVAL"].ToString();

                        //常用项目数组
                        DataRow[] dr_Values = dt_sets.Select(" DATETIMEVAL='" + dateTimeValue + "'");

                        //入量
                        DataRow[] dr_InAmount = dt_sets.Select("item_show_name='入量' and DATETIMEVAL='" + dateTimeValue + "'", "id asc");
                        int index = dr_InAmount.Length;
                        if (index == 0)
                            index = 1;
                        for (int j = 0; j < index; j++)
                        {
                            Class_Nurse_Record temp = new Class_Nurse_Record();
                            temp.DateTime = dateTimeValue;
                            //if (j == 0)
                            //{
                            //入量
                            if (dr_InAmount.Length > 0 && j < dr_InAmount.Length)
                            {
                                temp.In_item_name = dr_InAmount[j]["item_code"].ToString();
                                temp.In_item_value = dr_InAmount[j]["item_value"].ToString();
                                temp.Number = dr_InAmount[j]["id"].ToString();
                            }

                            //}

                            for (int k = 0; k < dr_Values.Length; k++)
                            {
                                if (j == 0)//非入量的项目只在当前时间段的第一行显示
                                {
                                    if (dr_Values[k]["item_show_name"].ToString() == "病情程度")
                                    {
                                        temp.Pathography = dr_Values[k]["item_code"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "护理级别")
                                    {
                                        //switch (dr_Values[k]["item_value"].ToString())
                                        //{
                                        //    case"1":
                                        //        temp.NurseLevel = "0";
                                        //        break;
                                        //    case"2":
                                        //        temp.NurseLevel = "1";
                                        //        break;
                                        //    case"3":
                                        //        temp.NurseLevel = "2";
                                        //        break;
                                        //    case"特":
                                        //        temp.NurseLevel = "3";
                                        //        break;
                                        //    default:
                                        //        temp.NurseLevel = dr_Values[k]["item_code"].ToString();
                                        //        break;
                                        //}
                                        temp.NurseLevel = dr_Values[k]["item_code"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "体温")
                                    {
                                        temp.Temperature = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "脉搏")
                                    {
                                        temp.Pulse = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "心率")
                                    {
                                        temp.HeartRate = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "呼吸")
                                    {
                                        temp.Breathe = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "血压")
                                    {
                                        temp.Blood_pressure = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "意识")
                                    {
                                        temp.Consciousness = dr_Values[k]["item_code"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "左")
                                    {
                                        temp.Pupil_left = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "右")
                                    {
                                        temp.Pupil_right = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "氧饱和度")
                                    {
                                        temp.Bp_saturation = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "大便")
                                    {
                                        temp.Shit = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "小便")
                                    {
                                        temp.Urine = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "手术")
                                    {
                                        temp.Operation = dr_Values[k]["item_code"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "特检")
                                    {
                                        temp.SpecialCheck = dr_Values[k]["item_code"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "伤口")
                                    {
                                        temp.Wound = dr_Values[k]["item_code"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "皮肤")
                                    {
                                        temp.Skin = dr_Values[k]["item_code"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "吸氧")
                                    {
                                        temp.Xy = dr_Values[k]["item_code"].ToString();
                                        temp.Ll = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "安全护理")
                                    {
                                        temp.Safe_Nurse = dr_Values[k]["item_code"].ToString();
                                    }
                                    //else if (dr_Values[k]["status_measure"].ToString() != "")
                                    //{
                                    //    temp.Remark = dr_Values[k]["status_measure"].ToString().Split('@').GetValue(0).ToString();
                                    //}
                                    else if (dr_Values[k]["item_show_name"].ToString() == "备注")
                                    {
                                        temp.Remark = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "管1颜色")
                                    {
                                        temp.Pipe1_Color = dr_Values[k]["item_value"].ToString();
                                        pipe1 = dr_Values[k]["other_name"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "管1量")
                                    {
                                        temp.Pipe1_Value = dr_Values[k]["item_value"].ToString();
                                        pipe1 = dr_Values[k]["other_name"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "管2颜色")
                                    {
                                        temp.Pipe2_Color = dr_Values[k]["item_value"].ToString();
                                        pipe2 = dr_Values[k]["other_name"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "管2量")
                                    {
                                        temp.Pipe2_Value = dr_Values[k]["item_value"].ToString();
                                        pipe2 = dr_Values[k]["other_name"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "管3颜色")
                                    {
                                        temp.Pipe3_Color = dr_Values[k]["item_value"].ToString();
                                        pipe3 = dr_Values[k]["other_name"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "管3量")
                                    {
                                        temp.Pipe3_Value = dr_Values[k]["item_value"].ToString();
                                        pipe3 = dr_Values[k]["other_name"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "管4颜色")
                                    {
                                        temp.Pipe4_Color = dr_Values[k]["item_value"].ToString();
                                        pipe4 = dr_Values[k]["other_name"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "管4量")
                                    {
                                        temp.Pipe4_Value = dr_Values[k]["item_value"].ToString();
                                        pipe4 = dr_Values[k]["other_name"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "管5颜色")
                                    {
                                        temp.Pipe5_Color = dr_Values[k]["item_value"].ToString();
                                        pipe5 = dr_Values[k]["other_name"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "管5量")
                                    {
                                        temp.Pipe5_Value = dr_Values[k]["item_value"].ToString();
                                        pipe5 = dr_Values[k]["other_name"].ToString();
                                    }
                                    //temp.Number = dr_Values[k]["PATIENT_ID"].ToString();
                                    //temp.Signature = dr_Values[k]["user_name"].ToString();
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
            catch (Exception ex)
            {
                App.MsgErr("数据打印加载错误! 问题:" + ex.Message);
            }
        }
        /// <summary>
        /// 重置计算出入量汇总
        /// </summary>
        private void SumInOrOutRecordSets()
        {

            #region old 
            //try
            //{
            //    SumNusersRecords.Clear();
            //    string sql_date = "select * from t_nurse_dangery_inout_sum_h where (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_Id=" + currentPatient.Id + "  order by end_time";
            //    DataSet ds_sum_oper = App.GetDataSet(sql_date);

            //    for (int i = 0; i < ds_sum_oper.Tables[0].Rows.Count; i++)
            //    {
            //        //SumNusersRecords.Add(Convert.ToDateTime(ds_sum_oper.Tables[0].Rows[i]["start_time"]).ToString("yyyy-MM-dd HH:mm") + "," + Convert.ToDateTime(ds_sum_oper.Tables[0].Rows[i]["end_time"]).ToString("yyyy-MM-dd HH:mm") + "," + ds_sum_oper.Tables[0].Rows[i]["oper_method"].ToString() + "," + ds_sum_oper.Tables[0].Rows[i]["ID"].ToString() + "," + ds_sum_oper.Tables[0].Rows[i]["seq_id"] + "," + ds_sum_oper.Tables[0].Rows[i]["SIGNATURE"] + "," + ds_sum_oper.Tables[0].Rows[i]["SUM_ITEM"]);

            //        SumNusersRecords.Add(Convert.ToDateTime(ds_sum_oper.Tables[0].Rows[i]["start_time"]).ToString("yyyy-MM-dd HH:mm") + "," + Convert.ToDateTime(ds_sum_oper.Tables[0].Rows[i]["end_time"]).ToString("yyyy-MM-dd HH:mm") + "," + ds_sum_oper.Tables[0].Rows[i]["oper_method"].ToString().Replace("小时出入量", "h总结") + ",0," + ds_sum_oper.Tables[0].Rows[i]["seq_id"] + "," + ds_sum_oper.Tables[0].Rows[i]["SIGNATURE"] + "," + ds_sum_oper.Tables[0].Rows[i]["SUM_ITEM"]);
            //    }

            //    for (int i1 = 0; i1 < SumNusersRecords.Count; i1++)
            //    {
            //        string BeginTiem, EndTime, Item_name;
            //        string BeginedTiem, EndedTime;
            //        string Remaining = "0";//余液-
            //        string Remained = "0";//余液+
            //        string LetFlow = "";//弃液
            //        string Eat = "";//食物
            //        string Urine = "";//大小便
            //        string Yl = "";//引流
            //        string DB = "0";//大便
            //        string XB = "0";//小便
            //        string G1 = "0";//管1
            //        string G2 = "0";//管2
            //        string G3 = "0";//管3
            //        string G4 = "0";//管4
            //        string G5 = "0";//管5


            //        double inAmount = 0;//入量总和
            //        double outAmount = 0;//出量总和
            //        string Number = "";//号码
            //        string seq_id = "";//统计类型ID
            //        string SIGNATURE = ""; //签名

            //        BeginTiem = SumNusersRecords[i1].ToString().Split(',')[0];
            //        EndTime = SumNusersRecords[i1].ToString().Split(',')[1];
            //        Item_name = SumNusersRecords[i1].ToString().Split(',')[2];
            //        Number = SumNusersRecords[i1].ToString().Split(',')[3];
            //        seq_id = SumNusersRecords[i1].ToString().Split(',')[4];
            //        SIGNATURE = SumNusersRecords[i1].ToString().Split(',')[5];
            //        string[] sum_item = SumNusersRecords[i1].ToString().Split(',')[6].Split('|');//统计项目
            //        //creatID = SumNusersRecords[i1].ToString().Split(',')[4];+ "," + ds_sum_oper.Tables[0].Rows[i]["CREAT_ID"].ToString()
            //        SumNusers.Clear();
            //        //日间,夜间的上一班次时间
            //        BeginedTiem = Convert.ToDateTime(EndTime).AddDays(-1).ToString("yyyy-MM-dd HH:mm");
            //        EndedTime = BeginTiem;

            //        Class_Nurse_Record sumtemp = new Class_Nurse_Record();

            //        string beginSgin = ">=";

            //        string endSgin = "<=";

            //        Class_Take_over_SEQ tempSeq = null;
            //        for (int i = 0; i < cboTiming.Items.Count; i++)
            //        {
            //            tempSeq = cboTiming.Items[i] as Class_Take_over_SEQ;
            //            if (tempSeq != null && tempSeq.Id == seq_id)
            //            {
            //                if (tempSeq.Begin_logic == "0")
            //                {
            //                    beginSgin = ">";
            //                }
            //                if (tempSeq.End_logic == "0")
            //                {
            //                    endSgin = "<";
            //                }
            //                break;
            //            }
            //        }
            //        #region 注

            //        #endregion

            //        //入量总和
            //        string SqlIn_1 = "select '入量总合' as ItemName,sum(a.item_value) as sumval from t_nurse_record a " +
            //                 @" where item_show_name='入量'  and other_name not like '%弃液%' and other_name not like '%余液%' and (regexp_like (trim(item_value),'^-?([1-9]\d*\.\d*|0\.\d*[1-9]\d*|0?\.0+|0)$') or regexp_like (trim(item_value),'^[[:digit:]]+$')) " +
            //                 @"and MEASURE_TIME" + beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" +
            //                 endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and (RECORD_TYPE='D' or RECORD_TYPE is null) and  patient_Id=" + currentPatient.Id + "";
            //        //弃液总和
            //        string SqlIn_2 = "select '入量弃液' as ItemName,sum(abs(a.item_value)) as sumval from t_nurse_record a " +
            //               @" where item_show_name='入量'  and other_name like '%弃液%'  and (regexp_like (trim(item_value),'^-?([1-9]\d*\.\d*|0\.\d*[1-9]\d*|0?\.0+|0)$') or regexp_like (trim(item_value),'^[[:digit:]]+$')) " +
            //               @"and MEASURE_TIME" + beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" +
            //                 endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and (RECORD_TYPE='D' or RECORD_TYPE is null) and  patient_Id=" + currentPatient.Id + "";

            //        //当前统计时段余液总和
            //        string SqlIn_3 = "select '入量余液-' as ItemName,sum(abs(a.item_value)) as sumval from t_nurse_record a " +
            //               @" where item_show_name='入量'  and other_name like '%余液%'  and (regexp_like (trim(item_value),'^-?([1-9]\d*\.\d*|0\.\d*[1-9]\d*|0?\.0+|0)$') or regexp_like (trim(item_value),'^[[:digit:]]+$')) " +
            //               @"and MEASURE_TIME" + beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" +
            //                 endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and (RECORD_TYPE='D' or RECORD_TYPE is null) and  patient_Id=" + currentPatient.Id + "";

            //        //上次统计时段余液总和
            //        string SqlIn_4 = "select '入量余液+' as ItemName,sum(abs(a.item_value)) as sumval from t_nurse_record a " +
            //               @" where item_show_name='入量'  and other_name like '%余液%'  and (regexp_like (trim(item_value),'^-?([1-9]\d*\.\d*|0\.\d*[1-9]\d*|0?\.0+|0)$') or regexp_like (trim(item_value),'^[[:digit:]]+$')) " +
            //               @"and MEASURE_TIME>to_timestamp('" + BeginedTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME<=to_timestamp('" + EndedTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and (RECORD_TYPE='D' or RECORD_TYPE is null) and  patient_Id=" + currentPatient.Id + "";


            //        // 大便
            //        string SqlOut_1 = @"select '大小便' as ItemName,sum(a.item_value) as sumval from t_nurse_record a inner join T_NURSE_RECORD_DICT b on a.item_code=b.item_code or to_char(b.id)=a.item_code  left join T_ACCOUNT_USER c on c.id=a.creat_id left join T_USERINFO d on d.user_id=c.user_id  where item_type=97 and lower(a.item_value) not like '%g%' and b.has_sum=1 and (regexp_like (trim(a.item_value),'^-?([1-9]\d*\.\d*|0\.\d*[1-9]\d*|0?\.0+|0)$') or regexp_like (trim(a.item_value),'^[[:digit:]]+$')) and MEASURE_TIME" +
            //            beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and (RECORD_TYPE='D' or RECORD_TYPE is null) and  patient_Id=" + currentPatient.Id + "";


            //        //管X量
            //        string SqlOut_2 = @"select '引流' as ItemName,sum(a.item_value) as sumval from t_nurse_record a where item_show_name like '管%量' and (regexp_like (trim(item_value),'^-?([1-9]\d*\.\d*|0\.\d*[1-9]\d*|0?\.0+|0)$') or regexp_like (trim(item_value),'^[[:digit:]]+$')) and MEASURE_TIME" +
            //            beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and (RECORD_TYPE='D' or RECORD_TYPE is null) and  patient_Id=" + currentPatient.Id + "";

            //        string SqlOut = "";

            //        foreach (string i in sum_item)
            //        {
            //            if (i != null && i != "")
            //            {
            //                SqlOut += " union " + "select '" + i + "' as ItemName,sum(a.item_value) as sumval from t_nurse_record a where item_show_name like '" + i + @"' and (regexp_like (trim(item_value),'^-?([1-9]\d*\.\d*|0\.\d*[1-9]\d*|0?\.0+|0)$') or regexp_like (trim(item_value),'^[[:digit:]]+$')) and MEASURE_TIME" +
            //                    beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and (RECORD_TYPE='D' or RECORD_TYPE is null) and  patient_Id=" + currentPatient.Id + "";
            //            }
            //            else
            //            {
            //                SqlOut = " union " + SqlOut_1 + " union " + SqlOut_2;
            //            }
            //        }
            //        string Sql = "";
            //        if (Item_name.Contains("日间") || Item_name.Contains("夜间"))
            //        {//需要计算余液的值
            //            Sql = SqlIn_1 + " union " + SqlIn_2 + " union " + SqlIn_3 + " union " + SqlIn_4 + SqlOut; //" union " + SqlOut_1 + " union " + SqlOut_2;
            //        }
            //        else
            //        {
            //            Sql = SqlIn_1 + " union " + SqlIn_2 + SqlOut;// " union " + SqlOut_1 + " union " + SqlOut_2;
            //        }
            //        DataSet ds = null;
            //        try
            //        {
            //            ds = App.GetDataSet(Sql);
            //        }
            //        catch (Exception ex1)
            //        {

            //        }

            //        //DateTime d_begin = Convert.ToDateTime(BeginTiem);
            //        //DateTime d_end = Convert.ToDateTime(EndTime);
            //        sumtemp.DateTime = EndTime;
            //        sumtemp.In_item_name = Item_name;
            //        sumtemp.Number = Number;
            //        #region 统计项赋值
            //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //        {
            //            if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("入量总合"))
            //            {
            //                if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
            //                {
            //                    Eat = ds.Tables[0].Rows[i]["sumval"].ToString();
            //                }
            //                else
            //                {
            //                    Eat = "0";
            //                }
            //            }
            //            else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("入量弃液"))
            //            {
            //                if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
            //                {
            //                    LetFlow = ds.Tables[0].Rows[i]["sumval"].ToString();
            //                }
            //                else
            //                {
            //                    LetFlow = "0";
            //                }
            //            }
            //            else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("入量余液-"))
            //            {
            //                if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
            //                {
            //                    Remaining = ds.Tables[0].Rows[i]["sumval"].ToString();
            //                }
            //                else
            //                {
            //                    Remaining = "0";
            //                }
            //            }
            //            else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("入量余液+"))
            //            {
            //                if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
            //                {
            //                    Remained = ds.Tables[0].Rows[i]["sumval"].ToString();
            //                }
            //                else
            //                {
            //                    Remained = "0";
            //                }
            //            }
            //            else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("大小便"))
            //            {
            //                if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
            //                {
            //                    Urine = ds.Tables[0].Rows[i]["sumval"].ToString();
            //                }
            //                else
            //                {
            //                    Urine = "0";
            //                }
            //            }
            //            else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("引流"))
            //            {
            //                if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
            //                {
            //                    Yl = ds.Tables[0].Rows[i]["sumval"].ToString();
            //                }
            //                else
            //                {
            //                    Yl = "0";
            //                }
            //            }
            //            else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("大便"))
            //            {
            //                if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
            //                {
            //                    DB = ds.Tables[0].Rows[i]["sumval"].ToString();
            //                }
            //                else
            //                {
            //                    DB = "0";
            //                }
            //            }
            //            else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("小便"))
            //            {
            //                if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
            //                {
            //                    XB = ds.Tables[0].Rows[i]["sumval"].ToString();
            //                }
            //                else
            //                {
            //                    XB = "0";
            //                }
            //            }
            //            else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("管1量"))
            //            {
            //                if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
            //                {
            //                    G1 = ds.Tables[0].Rows[i]["sumval"].ToString();
            //                }
            //                else
            //                {
            //                    G1 = "0";
            //                }
            //            }
            //            else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("管2量"))
            //            {
            //                if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
            //                {
            //                    G2 = ds.Tables[0].Rows[i]["sumval"].ToString();
            //                }
            //                else
            //                {
            //                    G2 = "0";
            //                }
            //            }
            //            else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("管3量"))
            //            {
            //                if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
            //                {
            //                    G3 = ds.Tables[0].Rows[i]["sumval"].ToString();
            //                }
            //                else
            //                {
            //                    G3 = "0";
            //                }
            //            }
            //            else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("管4量"))
            //            {
            //                if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
            //                {
            //                    G4 = ds.Tables[0].Rows[i]["sumval"].ToString();
            //                }
            //                else
            //                {
            //                    G4 = "0";
            //                }
            //            }
            //            else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("管5量"))
            //            {
            //                if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
            //                {
            //                    G5 = ds.Tables[0].Rows[i]["sumval"].ToString();
            //                }
            //                else
            //                {
            //                    G5 = "0";
            //                }
            //            }
            //        }
            //        #endregion
            //        //计算入量总和
            //        try
            //        {
            //            inAmount = Convert.ToDouble(Eat) - Math.Abs(Convert.ToDouble(LetFlow)) - Math.Abs(Convert.ToDouble(Remaining)) + Math.Abs(Convert.ToDouble(Remained));
            //        }
            //        catch (Exception) { inAmount = 0; }
            //        //计算出量总和
            //        try
            //        {
            //            outAmount = Convert.ToDouble(Urine) + Convert.ToDouble(Yl);
            //        }
            //        catch (Exception) { outAmount = 0; }

            //        sumtemp.In_item_value = inAmount == 0 ? "" : inAmount.ToString();//入量总和
            //        sumtemp.Urine = outAmount == 0 ? "" : outAmount.ToString();//出量总和 
            //        if (Item_name.Contains("小结"))
            //        {
            //            sumtemp.Shit = DB == "0" ? "" : DB;//大便
            //            sumtemp.Urine = XB == "0" ? "" : XB;//小便
            //            sumtemp.Pipe1_Value = G1 == "0" ? "" : G1;//管1
            //            sumtemp.Pipe2_Value = G2 == "0" ? "" : G2;//管2
            //            sumtemp.Pipe3_Value = G3 == "0" ? "" : G3;//管3
            //            sumtemp.Pipe4_Value = G4 == "0" ? "" : G4;//管4
            //            sumtemp.Pipe5_Value = G5 == "0" ? "" : G5;//管5
            //        }
            //        if (SIGNATURE == "")
            //        {
            //            if (App.UserAccount.UserInfo != null)
            //                sumtemp.Signature = App.UserAccount.UserInfo.User_name;//签名
            //        }
            //        else
            //        {
            //            sumtemp.Signature = SIGNATURE;//签名
            //        }
            //        DateTime TempDate = new DateTime();
            //        bool flag = false;

            //        if (nurses.Count == 0)
            //        {
            //            SumNusers.Add(sumtemp);
            //        }
            //        //将汇总记录插到对象集合中去
            //        for (int i = 0; i < nurses.Count; i++)
            //        {
            //            SumNusers.Add(nurses[i]);
            //        }

            //        for (int i = 0; i < nurses.Count; i++)
            //        {
            //            Class_Nurse_Record temp_nuser = (Class_Nurse_Record)SumNusers[i];
            //            if (temp_nuser.DateTime != null)
            //            {
            //                TempDate = Convert.ToDateTime(temp_nuser.DateTime);

            //                if (TempDate == Convert.ToDateTime(EndTime))
            //                {
            //                    if (tempSeq != null && tempSeq.End_logic == "0")//结束标记为“0”，汇总插到相同时间点的项目之前
            //                    {
            //                        SumNusers.Insert(i, sumtemp);
            //                        break;
            //                    }
            //                }
            //                else if (TempDate > Convert.ToDateTime(EndTime))//汇总时间小于当前录入时间，插到这条项目之前
            //                {
            //                    SumNusers.Insert(i, sumtemp);
            //                    break;
            //                }
            //            }
            //            if (i == SumNusers.Count - 1)
            //            {
            //                SumNusers.Add(sumtemp);
            //                break;
            //            }
            //        }

            //        nurses.Clear();
            //        for (int i = 0; i < SumNusers.Count; i++)
            //        {
            //            nurses.Add(SumNusers[i]);
            //        }

            //    }
            //}
            //catch (Exception ex)
            //{
            //    ex.Message.ToString();
            //}
            #endregion

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
            if (flgView[rowSel, 0] != null && flgView[rowSel, 0].ToString() != "")
            {
                dateTime = flgView[rowSel, 0].ToString();
            }
            else
            {
                dateTime = GetTime(rowSel - 1);
            }

            return dateTime;
        }
        /// <summary>
        /// 添加常用项SQL语句
        /// </summary>
        /// <param name="measureTime">测量时间</param>
        /// <param name="itemCode">项目代码</param>
        /// <param name="itemName">项目名称</param>
        /// <param name="itemValue">项目值</param>
        /// <param name="sqls">sql列表</param>
        /// <param name="other_name">入量的项目名称</param>
        private void AddSqls(string measureTime, string itemCode, string itemName, string itemValue, ref List<string> sqls, string other_name)
        {
            string sql = "";
            if (other_name == "")
            {
                sql = "insert into t_nurse_record" +
                             "( bed_no, pid, measure_time, item_code, item_value, creat_id, create_time, patient_id, item_show_name,RECORD_TYPE)values" +
                             "( '" + currentPatient.Sick_Bed_Name + "', '" + currentPatient.PId + "', to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9'), '" +
                             itemCode + "', '" + itemValue + "', '" + App.UserAccount.Account_id + "', to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9'), " + currentPatient.Id + ", '" + itemName + "','D')";
            }
            else
            {
                sql = "insert into t_nurse_record" +
                             "( bed_no, pid, measure_time, item_code, item_value, creat_id, create_time, patient_id, item_show_name,other_name,RECORD_TYPE)values" +
                             "( '" + currentPatient.Sick_Bed_Name + "', '" + currentPatient.PId + "', to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9'), '" +
                             itemCode + "', '" + itemValue + "', '" + App.UserAccount.Account_id + "', to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9'), " + currentPatient.Id + ", '" + itemName + "','" + other_name + "','D')";
            }
            sqls.Add(sql);
        }
        #region 表格相关操作
        private void flgView_CellChanged(object sender, RowColEventArgs e)
        {
            flgView.AutoSizeCol(e.Col);
        }
        //ComboBox cb = null;
        private void flgView_StartEdit(object sender, RowColEventArgs e)
        {
            //签名禁止编辑
            if (e.Col == 34)
            {
                e.Cancel = true;
                return;
            }
            if (flgView[e.Row, 0] == null || flgView[e.Row, 0].ToString() == "")
            {
                if (e.Col == 12)
                {
                    string measureTime = GetTime(e.Row);
                    //验证权限
                    DateTime objDataTime;
                    if (measureTime != "" && DateTime.TryParse(measureTime, out objDataTime))//时间为空说明是添加数据，不用验证权限
                    {
                        string operateId = App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_id=" + currentPatient.Id, 0, "creat_id");
                        if (!ValidateUser(operateId))
                        {
                            App.Msg("权限不足！");
                            e.Cancel = true;
                            return;
                        }
                    }
                    else
                    {
                        FrmSetDatetime fsd = new FrmSetDatetime(dtpDate.Value, currentPatient.Id.ToString(), "D");
                        fsd.ShowDialog();
                        if (fsd.flag)
                            flgView[e.Row, 0] = fsd.Date.ToString("yyyy-MM-dd HH:mm");
                        //flgView.Col = 1;
                        e.Cancel = true;
                        return;
                    }
                }
                else if (e.Col != 12 && e.Col != 13 && e.Row != flgView.Rows.Count - 1 && flgView[e.Row, 12] != null)
                {
                    e.Cancel = true;
                    return;
                }
                else if (e.Col == 13)
                {
                    if (flgView[e.Row, 12] == null || flgView[e.Row, 12].ToString() == "")
                    {
                        App.Msg("提示:请先输入入量名称！");
                        flgView.Col = 12;
                        return;
                    }
                }
                else
                {
                    if (flgView[e.Row, 12] == null || flgView[e.Row, 12].ToString().Length == 0)
                    {
                        FrmSetDatetime fsd = new FrmSetDatetime(dtpDate.Value, currentPatient.Id.ToString(), "D");
                        fsd.ShowDialog();
                        if (fsd.flag)
                            flgView[e.Row, 0] = fsd.Date.ToString("yyyy-MM-dd HH:mm");
                        //flgView.Col = 1;
                        e.Cancel = true;
                        return;
                    }
                }

            }
            else
            {
                int id = 0;
                if (flgView[e.Row, 35] != null && flgView[e.Row, 35].ToString().Length > 0)
                {
                    try
                    {
                        id = int.Parse(flgView[e.Row, 35].ToString());
                    }
                    catch { }
                }
                if (flgView[e.Row, 12] != null && id == 0 && (flgView[e.Row, 12].ToString().Contains("总结") || flgView[e.Row, 12].ToString().Contains("小结")))
                {
                    e.Cancel = true;
                    return;
                }
                else
                {
                    DateTime dt = Convert.ToDateTime(flgView[e.Row, 0].ToString());
                    string operateId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + dt.ToString("yyyy-MM-dd HH:mm") + "','syyyy-mm-dd hh24:mi:ss.ff9') and (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_id=" + currentPatient.Id + " and rownum=1 order by id", 0, "creat_id"));

                    if (ValidateUser(operateId) || operateId == null)
                    {
                        if (e.Col == 0)
                        {
                            FrmSetDatetime fsd = new FrmSetDatetime(dt, currentPatient.Id.ToString(), "D");
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
                                    dt.ToString("yyyy-MM-dd HH:mm") + "','syyyy-mm-dd hh24:mi:ss.ff9') and (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_id=" + currentPatient.Id.ToString() + "";

                                if (App.ExecuteSQL(sql) == 0 && operateId != null)
                                {
                                    App.MsgErr("修改时间没有修改成功！");
                                }
                            }
                        }
                        //验证xx管的标题是否输入
                        if (e.Col >= 16 && e.Col <= 25)
                        {
                            if (flgView[1, e.Col] == null || flgView[1, e.Col].ToString() == "")
                            {
                                修改标题ToolStripMenuItem_Click(sender, e);
                            }
                        }

                        //入量输入验证，先选择入量类型，再输入数值
                        if (e.Col == 13)
                        {
                            if (flgView[e.Row, e.Col - 1] == null || flgView[e.Row, e.Col - 1].ToString() == "")
                            {
                                App.Msg("提示:请先输入入量名称！");
                                flgView.Col = 12;
                                return;
                            }
                        }
                        //修改入量自定义名称
                        if (e.Col == 12 && flgView[e.Row, 12] != null && flgView[e.Row, 12].ToString() != "")//&& flgView[e.Row, 12] == null)
                        {
                            //string measureTime = GetTime(e.Row);
                            //oldInAmountName = flgView[e.Row, 12].ToString();
                            //FrmModifyTitle frm = new FrmModifyTitle(flgView[e.Row, 12].ToString());
                            //frm.ShowDialog();
                            //flgView[e.Row, e.Col] = frm.tName;

                            ////验证入量类型是否重复
                            //string itemName = flgView[e.Row, 12].ToString();
                            //int itemCount = Convert.ToInt32(App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='入量' and other_name='" + itemName + "' and (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_id=" + currentPatient.Id, 0, "count(*)"));
                            //if (itemCount > 0 && itemName != oldInAmountName)
                            //{
                            //    App.Msg("入量项目重复！");
                            //    flgView[e.Row, e.Col] = oldInAmountName;
                            //    e.Cancel = true;
                            //    return;
                            //}
                            //else if (itemName == oldInAmountName)
                            //{
                            //    e.Cancel = true;
                            //    return;
                            //}

                            //itemCount = Convert.ToInt32(App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='入量' and other_name='" + oldInAmountName + "' and (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_id=" + currentPatient.Id, 0, "count(*)"));

                            ////如果当前项目已存在则修改当前值的入量类型
                            //if (oldInAmountName != "")
                            //{
                            //    if (itemCount > 0 && flgView[e.Row, 13] != null)
                            //    {
                            //        //string operateId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_id=" + currentPatient.Id + " and rownum=1 order by id", 0, "creat_id"));
                            //        //if (ValidateUser(operateId))
                            //        //{
                            //        string sql = "update t_nurse_record set item_code='" + itemName + "', other_name='" + itemName + "',update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='入量' and other_name='" + oldInAmountName + "' and (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_id=" + currentPatient.Id;
                            //        int num = App.ExecuteSQL(sql);
                            //        if (num > 0)
                            //        {
                            //            timer1.Start();
                            //            operateFlag = true;
                            //            //插入签名
                            //            //flgView[e.Row, 34] = App.UserAccount.UserInfo.User_name;
                            //            //App.ExecuteSQL("update t_nurse_record set creat_id='" + App.UserAccount.UserInfo.User_id + "'，create_time=sysdate, update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and patient_id=" + currentPatient.Id);
                            //            App.ExecuteSQL("update t_nurse_record set  update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_id=" + currentPatient.Id);
                            //        }
                            //        //}
                            //        //else
                            //        //{
                            //        //    App.Msg("修改权限不足！");
                            //        //}

                            //    }

                            //}
                            //e.Cancel = true;
                            return;
                        }

                        //编辑瞳孔
                        if (e.Col == 9 || e.Col == 10)
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
                    else
                    {
                        App.Msg("修改权限不足！");
                        e.Cancel = true;
                        return;
                    }
                }
            }
        
            //flgView.AutoSizeCols();
        }
        #endregion

        private void flgView_KeyPressEdit(object sender, KeyPressEditEventArgs e)
        {
            try
            {
                if (e.Col == 0)//时间日期禁止手动输入
                {
                    e.Handled = true;
                }
                if (e.Col == 3 || e.Col == 4 || e.Col == 5 || e.Col == 6 || e.Col == 11 || e.Col == 15 || e.Col == 17 || e.Col == 19 || e.Col == 21 || e.Col == 23 || e.Col == 25 || e.Col == 31)//体温
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
                    {
                        e.Handled = true;
                    }
                }
                if (e.Col == 13)//入量可以输入-
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.' && Char.ToLower(e.KeyChar) != '-')
                    {
                        e.Handled = true;
                    }
                    else if (Char.ToLower(e.KeyChar) == '-')
                    {
                        //判断是否已经输入过单位:-
                        if (flgView.Editor.Text.ToLower().Contains("-") || flgView.Editor.Text != "")
                        {
                            e.Handled = true;
                        }
                    }
                }
                if (e.Col == 14)//大便可输入g ,默认ml
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.' && Char.ToLower(e.KeyChar) != 'g')
                    {
                        e.Handled = true;
                    }
                    else if (Char.ToLower(e.KeyChar) == 'g')
                    {
                        //判断是否已经输入过单位:g
                        if (flgView.Editor.Text.ToLower().Contains("g") || flgView.Editor.Text=="")
                        {
                            e.Handled = true;
                        }
                    }
                }
                if (e.Col == 9 || e.Col == 10)
                {
                    e.Handled = true;
                }
                if (e.Col == 7)//血压
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.' && e.KeyChar != '/')
                    {
                        e.Handled = true;
                    }
                }
            }
            catch
            { }
        }

        /// <summary>
        /// 设置编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flgView_SetupEditor(object sender, RowColEventArgs e)
        {
            try
            {
                flgView.Cols[1].Width = 32;
                flgView.Cols[8].Width = 32;
                if (e.Col == 12 && flgView[e.Row, e.Col] != null && flgView[e.Row, e.Col].ToString() != "")//入量名称列
                {
                    //保存修改前的入量名称
                    if (flgView[e.Row, e.Col] != null)
                    {
                        oldInAmountName = flgView[e.Row, e.Col].ToString();
                        oldInAmountCode = flgView[e.Row, e.Col].ToString();
                    }
                }
            }
            catch
            { }
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SetTable();
            oldInAmountName = "";
            ShowData();
            SumInOrOutRecordSet(true);
            ShowSumDataGrid();
            CellUnit(pipe1, pipe2, pipe3, pipe4, pipe5);
            flgView.Cols[33].Width = 100;
            flgView.Cols[2].Width = 30;
            //flgView.Cols[1].Width =32;
            //flgView.Cols[8].Width = 32;
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
            //if (flgView[e.Row, 0] != null && flgView[e.Row, 0].ToString() != "")
            //{
            //string currentRowTime = flgView[e.Row, 0].ToString();
            ////验证重复时间
            //for (int i = 3; i < flgView.Rows.Count; i++)
            //{
            //    if (i != e.Row)
            //    {
            //        if (flgView[i, 0] != null && flgView[i, 0].ToString() == currentRowTime)
            //        {
            //            flgView[e.Row, 0] = null;
            //            App.Msg("不能录入相同的时间！");
            //            return;
            //        }
            //    }
            //}

            ////验证时间范围是否和查询条件日期相同
            //if (dtpDate.Value.ToString("yyyy-MM-dd") != Convert.ToDateTime(currentRowTime).ToString("yyyy-MM-dd"))
            //{
            //    flgView[e.Row, 0] = null;
            //    App.Msg("您选择的时间超出了查询日期！");
            //    return;
            //}
            //}
            #endregion

            #region 保存数据
            if (flgView[e.Row, e.Col] != null && flgView[e.Row, e.Col].ToString() != "")
            {
                string measureTime = GetTime(e.Row);
                string itemCode = "";
                string itemValue = "";
                string itemName = "";
                string otherName = "";
                int id = 0;
                
                if (e.Col != 0 && e.Col != 30)//12入量类型，30吸氧类型
                {


                    if (e.Col == 1 || e.Col == 2 || e.Col == 8 || e.Col == 26 || e.Col == 27 || e.Col == 28 || e.Col == 29 || e.Col == 30 || e.Col == 32)
                    {
                        ListDictionary ldCommon = GetDictionaryByColIndex(e.Col);
                        itemValue = ldCommon[flgView[e.Row, e.Col].ToString()].ToString();
                        itemCode = flgView[e.Row, e.Col].ToString();
                        itemName = dictColumnName[e.Col];
                    }
                    else if (e.Col == 13||e.Col==12)//入量
                    {
                        if (flgView[e.Row, 12] != null)
                        {
                            otherName = flgView[e.Row, 12].ToString();
                        }
                        else
                        {
                            otherName = flgView[e.Row, 12].ToString();
                        }
                        if (flgView[e.Row, 13] != null)
                        {
                            itemValue = flgView[e.Row, 13].ToString();
                        }
                        itemCode = flgView[e.Row, 12].ToString();
                        itemName = "入量";
                        if (flgView[e.Row, 35] != null && flgView[e.Row, 35].ToString().Length > 0)
                        {
                            try
                            {
                                id = int.Parse(flgView[e.Row, 35].ToString());
                            }
                            catch { }
                        }
                    }
                    else if (e.Col >= 16 && e.Col <= 25)//手工输入的xx管数据
                    {
                        switch (e.Col)
                        {
                            case 16:
                                itemName = "管1颜色";
                                break;
                            case 17:
                                itemName = "管1量";
                                break;
                            case 18:
                                itemName = "管2颜色";
                                break;
                            case 19:
                                itemName = "管2量";
                                break;
                            case 20:
                                itemName = "管3颜色";
                                break;
                            case 21:
                                itemName = "管3量";
                                break;
                            case 22:
                                itemName = "管4颜色";
                                break;
                            case 23:
                                itemName = "管4量";
                                break;
                            case 24:
                                itemName = "管5颜色";
                                break;
                            case 25:
                                itemName = "管5量";
                                break;
                        }
                        itemValue = flgView[e.Row, e.Col].ToString();
                        otherName = flgView[1, e.Col].ToString();                      
                    }
                    else if (e.Col == 31)//吸氧/流量的值
                    {
                        ListDictionary ldCommon = GetDictionaryByColIndex(30);
                        otherName = ldCommon[flgView[e.Row, 30].ToString()].ToString();
                        itemValue = flgView[e.Row, e.Col].ToString();
                        itemCode = flgView[e.Row, 30].ToString();
                        itemName = "吸氧";
                    }
                    else
                    {
                        itemValue = flgView[e.Row, e.Col].ToString();
                        if (e.Col == 33)//备注，验证字符长度
                        {
                            int length = getStringLength(itemValue);
                            if (length > 1400)
                            {
                                App.Msg("您输入的内容超过1400字节了!");
                                return;
                            }
                        }
                        itemName = dictColumnName[e.Col];
                        itemCode = App.ReadSqlVal("select id from t_nurse_record_dict where item_name='" + itemName + "'", 0, "id");

                    }
                    //取当前日期时间最早的创建者id
                    string userId = "";
                    try
                    {
                        userId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_id=" + currentPatient.Id + " and rownum=1 order by id", 0, "creat_id"));
                        if (userId == null || userId=="")
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
                    if (e.Col != 13&&e.Col!=12)
                    {
                        itemCount = Convert.ToInt32(App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='" + itemName + "' and (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_id=" + currentPatient.Id, 0, "count(*)"));
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
                            itemCount = Convert.ToInt32(App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='" + itemName + "' and other_name='" + otherName + "'  and (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_id=" + currentPatient.Id, 0, "count(*)"));
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
                                         itemCode + "', '" + itemValue + "', '" + userId + "', sysdate, " + currentPatient.Id + ", '" + itemName + "','D')";
                        }
                        else
                        {
                            sql = "insert into t_nurse_record" +
                                         "( bed_no, pid, measure_time, item_code, item_value, creat_id, create_time, patient_id, item_show_name,other_name,RECORD_TYPE)values" +
                                         "( '" + currentPatient.Sick_Bed_Name + "', '" + currentPatient.PId + "', to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9'), '" +
                                         itemCode + "', '" + itemValue + "', '" + userId + "', sysdate, " + currentPatient.Id + ", '" + itemName + "','" + otherName + "','D')";
                        }
                    }
                    else
                    {
                        
                        //string operateId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and patient_id=" + currentPatient.Id + " and rownum=1 order by id", 0, "creat_id"));
                        if (!ValidateUser(userId))
                        {
                            App.Msg("修改权限不足!");
                            btnSearch_Click(sender, e);
                            return;
                        }
                        if (otherName == "")
                        {
                            sql = "update t_nurse_record set item_code='" + itemCode + "',item_value='" + itemValue + "',update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate" +
                                " where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='" + itemName + "'  and (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_id=" + currentPatient.Id;
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
                                sql += " where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='" + itemName + "' and other_name='" + otherName + "'  and (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_id=" + currentPatient.Id;
                            }

                        }

                    }
                    int num = App.ExecuteSQL(sql);
                    if (num > 0)
                    {
                        timer1.Start();
                        operateFlag = true;
                        //插入签名
                        if (flgView[e.Row, 0] != null && flgView[e.Row, 0].ToString() != "" && flgView[e.Row, 34] == null && sql.Contains("insert"))
                            flgView[e.Row, 34] = App.UserAccount.UserInfo.User_name;
                        if (id == 0 && itemName == "入量" && sql.ToLower().Contains("insert"))
                        {
                            btnSearch_Click(sender, e);
                        }
                        //App.Msg("操作成功！");
                        //App.ExecuteSQL("update t_nurse_record set creat_id='" + App.UserAccount.UserInfo.User_id + "',create_time=sysdate, update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and patient_id=" + currentPatient.Id);
                        //if (e.Col == 33)//备注，加刷新
                        //btnSearch_Click(sender, e);
                    }
                }
                //else if (e.Col == 12)//&& flgView[e.Row, 0] != null && flgView[e.Row, 0].ToString() != "")//更新入量类型
                //{
                //    //新建自定义入量名称
                //    if (flgView[e.Row, e.Col].ToString() == "80")
                //    {
                //        if (App.Ask("是否需要自定义入量名称？"))
                //        {
                //            FrmModifyTitle frm = new FrmModifyTitle();
                //            frm.Text = "入量名称";
                //            frm.ShowDialog();

                //            flgView[e.Row, e.Col] = frm.tName;
                //            return;
                //        }
                //    }

                //    //验证入量类型是否重复
                //    itemName = flgView[e.Row, 12].ToString();
                //    //int itemCount = Convert.ToInt32(App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='入量' and other_name='" + itemName + "' and (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_id=" + currentPatient.Id, 0, "count(*)"));
                //    //if (itemCount > 0 && itemName != oldInAmountName)
                //    //{
                //    //    App.Msg("入量项目重复！");
                //    //    flgView[e.Row, e.Col] = oldInAmountCode;
                //    //    //btnSearch_Click(sender, e);
                //    //    return;
                //    //}

                //    //itemCount = Convert.ToInt32(App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='入量' and other_name='" + oldInAmountName + "' and (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_id=" + currentPatient.Id, 0, "count(*)"));

                //    //如果当前项目已存在则修改当前值的入量类型
                //    //if (oldInAmountName != "")
                //    //{
                //    //    if (itemCount > 0 && flgView[e.Row, 13] != null)
                //    //    {
                //    //        otherName = flgView[e.Row, 12].ToString();
                //    //        itemCode = flgView[e.Row, 12].ToString();
                //    //        string operateId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_id=" + currentPatient.Id + " and rownum=1 order by id", 0, "creat_id"));
                //    //        if (!ValidateUser(operateId))
                //    //        {
                //    //            App.Msg("修改权限不足!");
                //    //            btnSearch_Click(sender, e);
                //    //            return;
                //    //        }
                //    //        string sql = "update t_nurse_record set item_code='" + itemCode + "',other_name='" + otherName + "',update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate ";
                //    //        sql += " where id=" + id;
                //    //        //sql+=" where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='入量' and other_name='" + oldInAmountName + "' and (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_id=" + currentPatient.Id;
                //    //        int num = App.ExecuteSQL(sql);
                //    //        if (num > 0)
                //    //        {
                //    //            timer1.Start();
                //    //            //App.Msg("操作成功！");
                //    //            operateFlag = true;
                //    //            //插入签名
                //    //            //if (flgView[e.Row, 0] != null && flgView[e.Row, 0].ToString() != "")
                //    //            //    flgView[e.Row, 34] = App.UserAccount.UserInfo.User_name;
                //    //            //App.ExecuteSQL("update t_nurse_record set creat_id='" + App.UserAccount.UserInfo.User_id + "'，create_time=sysdate, update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and patient_id=" + currentPatient.Id);
                //    //            //btnSearch_Click(sender, e);
                //    //        }
                //    //    }

                //    //}
                //    if (flgView[e.Row, 35] != null && flgView[e.Row, 35].ToString().Length > 0)
                //    {
                //        try
                //        {
                //            id = int.Parse(flgView[e.Row, 36].ToString());
                //        }
                //        catch { }
                //    }
                //    if (id > 0)
                //    {
                //        otherName = flgView[e.Row, 12].ToString();
                //        itemCode = flgView[e.Row, 12].ToString();
                //        string operateId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_id=" + currentPatient.Id + " and rownum=1 order by id", 0, "creat_id"));
                //        if (!ValidateUser(operateId))
                //        {
                //            App.Msg("修改权限不足!");
                //            btnSearch_Click(sender, e);
                //            return;
                //        }
                //        string sql = "update t_nurse_record set item_code='" + itemCode + "',other_name='" + otherName + "',update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate ";
                //        sql += " where id=" + id;
                //        //sql+=" where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='入量' and other_name='" + oldInAmountName + "' and (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_id=" + currentPatient.Id;
                //        int num = App.ExecuteSQL(sql);
                //        if (num > 0)
                //        {
                //            timer1.Start();
                //            //App.Msg("操作成功！");
                //            operateFlag = true;
                //            //插入签名
                //            //if (flgView[e.Row, 0] != null && flgView[e.Row, 0].ToString() != "")
                //            //    flgView[e.Row, 34] = App.UserAccount.UserInfo.User_name;
                //            //App.ExecuteSQL("update t_nurse_record set creat_id='" + App.UserAccount.UserInfo.User_id + "'，create_time=sysdate, update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and patient_id=" + currentPatient.Id);
                //            //btnSearch_Click(sender, e);
                //        }
                //    }
                //}
                else if (e.Col == 28)//更新吸氧方式
                {
                    //如果当前项目已存在则修改当前值的吸氧类型
                    int itemCount = Convert.ToInt32(App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='吸氧'  and (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_id=" + currentPatient.Id, 0, "count(*)"));
                    if (itemCount > 0)
                    {
                        otherName = ldXY[flgView[e.Row, 28].ToString()].ToString();
                        itemCode = flgView[e.Row, 28].ToString();
                        string operateId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_id=" + currentPatient.Id + " and rownum=1 order by id", 0, "creat_id"));
                        if (!ValidateUser(operateId))
                        {
                            App.Msg("修改权限不够!");
                            btnSearch_Click(sender, e);
                            return;
                        }
                        string sql = "update t_nurse_record set item_code='" + itemCode + "',other_name='" + otherName + "',update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='吸氧'  and (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_id=" + currentPatient.Id;
                        int num = App.ExecuteSQL(sql);
                        if (num > 0)
                        {
                            timer1.Start();
                            //App.Msg("操作成功！");
                            operateFlag = true;
                            //App.ExecuteSQL("update t_nurse_record set creat_id='" + App.UserAccount.UserInfo.User_id + "'，create_time=sysdate, update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_id=" + currentPatient.Id);
                            //btnSearch_Click(sender, e);
                        }
                    }
                }
                else if (e.Col == 0) //修改时间点
                {
                   //string updatesql="update set "
                }
            }
            #endregion


        }

        /// <summary>
        /// 根据列的索引获得对应的字典集合
        /// </summary>
        /// <returns>类型字典</returns>
        private ListDictionary GetDictionaryByColIndex(int col)
        {
            //病情程度
            if (col == 1)
            {
                return ldPathography;
            }
            else if (col == 2)//护理级别
            {
                return ldNurseLevel;
            }
            else if (col == 8)//意识
            {
                return ldConsciousness;
            }
            //else if (col == 12)//入量
            //{
            //    return ldInAmount;
            //}
            else if (col == 26 || col == 27)//手术特检
            {
                return ldOpreationSpecialCheck;
            }
            else if (col == 28 || col == 29)//伤口皮肤
            {
                return ldWoundSkin;
            }
            else if (col == 30)//吸氧
            {
                return ldXY;
            }
            else if (col == 32)//安全护理
            {
                return ldSafeNurse;
            }
            return null;
        }

        private void 修改标题ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            C1.Win.C1FlexGrid.RowColEventArgs c1e = e as C1.Win.C1FlexGrid.RowColEventArgs;
            string measureTime=GetTime(flgView.Row);
            string operateId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_id=" + currentPatient.Id + " and rownum=1 order by id", 0, "creat_id"));
            if (operateId!=null&&!ValidateUser(operateId))
            {
                App.Msg("修改权限不够!");
                btnSearch_Click(sender, e);
                return;
            }
            string titleName = "";
            titleName = flgView[1, flgView.Col].ToString();
            FrmModifyTitle frm = new FrmModifyTitle(titleName);
            frm.ShowDialog();

            if (frm.flag)
            {
                string pipeIndex = "";//当前选中管的位置
                //设置表头xx管的名字
                if (flgView.Col == 16 || flgView.Col == 17)
                {
                    flgView[1, 16] = frm.tName;
                    flgView[1, 17] = frm.tName;
                    pipeIndex = "1";
                }
                else if (flgView.Col == 18 || flgView.Col == 19)
                {
                    flgView[1, 18] = frm.tName;
                    flgView[1, 19] = frm.tName;
                    pipeIndex = "2";
                }
                else if (flgView.Col == 20 || flgView.Col == 21)
                {
                    flgView[1, 20] = frm.tName;
                    flgView[1, 21] = frm.tName;
                    pipeIndex = "3";
                }
                else if (flgView.Col == 22 || flgView.Col == 23)
                {
                    flgView[1, 22] = frm.tName;
                    flgView[1, 23] = frm.tName;
                    pipeIndex = "4";
                }
                else if (flgView.Col == 24 || flgView.Col == 25)
                {
                    flgView[1, 24] = frm.tName;
                    flgView[1, 25] = frm.tName;
                    pipeIndex = "5";
                }
                //更新xx管的名字
                string sql = "update t_nurse_record set other_name='" + frm.tName + "' where (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_id=" + currentPatient.Id + " and item_show_name like '%" + pipeIndex + "%'";
                try
                {
                    App.ExecuteSQL(sql);
                }
                catch
                {

                }
            }
            else
            {
                c1e.Cancel = true;
            }

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (flgView.Col < 16 || flgView.Col > 25)
            {
                修改标题ToolStripMenuItem.Visible = false;
            }
            else
            {
                修改标题ToolStripMenuItem.Visible = true;
            }

            if (flgView.Col == 12)
            {
                设置入量项目toolStripMenuItem.Visible = true;
            }
            else
            {
                设置入量项目toolStripMenuItem.Visible = false;
            }

            if (flgView.Col == 33)
            {
                备注模板toolStripMenuItem.Visible = true;
                if (flgView[flgView.Row, flgView.Col] != null)
                {
                    添加备注模板toolStripMenuItem.Visible = true;
                }
                else
                {
                    添加备注模板toolStripMenuItem.Visible = false;
                }
            }
            else
            {
                添加备注模板toolStripMenuItem.Visible = false;
                备注模板toolStripMenuItem.Visible = false;
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            lblDatePriview.Text = dtpDate.Value.AddDays(-1).ToShortDateString() + "<<";
            lblDateNext.Text = ">>" + dtpDate.Value.AddDays(1).ToShortDateString();
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
                //tHour = sp.TotalHours;
                //lblTatolTime.Text = tHour.ToString().Split('.')[0];
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
                    //tHour = sp.TotalHours;
                    //lblTatolTime.Text = tHour.ToString().Split('.')[0];
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
            string sum_id=SumInOrOut();
            if (cboTiming.Text.Contains("小结"))
            {
                FrmSumItem sum_item = new FrmSumItem(sum_id,"D");
                sum_item.ShowDialog();
                if (!sum_item.successflag)
                {//没有操作成功,清除这条统计记录
                    string del = "delete from t_nurse_dangery_inout_sum_h where id="+sum_id+" and patient_id=" + currentPatient.Id;
                    if (App.ExecuteSQL(del)>0)
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
            string sum_id=null;
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
                dtpEndTime.Value.ToString("yyyy-MM-dd HH:mm") + "','yyyy-MM-dd HH24:mi'),'" + sum_Name + "'," + currentPatient.Id + "," + take_Seq.Id + ",'" + App.UserAccount.UserInfo.User_name + "','D')";
                
                if (App.ExecuteSQL(inserSumSql)>0)
                {
                    sum_id = id.ToString();
                }
            }
            return sum_id;
#region 注
            //SumNusers.Clear();
            //string Eat = "";//食物
            //string Urine = "";//大小便
            //string Yl = "";//引流
            //string LetFlow = "";//弃液
            //int inAmount = 0;//入量总和
            //int outAmount = 0;//出量总和

            //Class_Nurse_Record sumtemp = new Class_Nurse_Record();

            //string beginSgin = ">=";

            //string endSgin = "<=";

            //if (cboTiming.SelectedItem != null)
            //{
            //    Class_Take_over_SEQ tempSeq = (Class_Take_over_SEQ)cboTiming.SelectedItem;
            //    if (tempSeq.Begin_logic == "0")
            //    {
            //        beginSgin = ">";
            //    }
            //    if (tempSeq.End_logic == "0")
            //    {
            //        endSgin = "<";
            //    }
            //}

            ////入量食物总合and item_attribute=102   SqlIn + " union " + 
            ////string SqlIn_1 = "select '入量总合' as ItemName,sum(a.item_value) as sumval from t_nurse_record a " +
            ////        @"inner join T_NURSE_RECORD_DICT b on to_char(b.id)=a.item_code " +
            ////        @"left join T_ACCOUNT_USER c on c.id=a.creat_id " +
            ////        @"left join T_USERINFO d on d.user_id=c.user_id  where item_show_name='入量' and b.has_sum=1  " +
            ////        @"and MEASURE_TIME" + beginSgin + "to_timestamp('" + dtpBeginTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + dtpEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + "";
            //////出量总和-小便
            ////string SqlOut_1 = "select '小便' as ItemName,sum(a.item_value) as sumval from t_nurse_record a inner join T_NURSE_RECORD_DICT b on a.item_code=b.item_code or to_char(b.id)=a.item_code left join T_ACCOUNT_USER c on c.id=a.creat_id left join T_USERINFO d on d.user_id=c.user_id  where item_type=97 and b.has_sum=1 and a.item_code ='49' and MEASURE_TIME" + beginSgin + "to_timestamp('" + dtpBeginTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + dtpEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + "";
            //////出量总和-大便
            ////string SqlOut_2 = "select '大便' as ItemName,sum(a.item_value) as sumval from t_nurse_record a inner join T_NURSE_RECORD_DICT b on a.item_code=b.item_code  or to_char(b.id)=a.item_code left join T_ACCOUNT_USER c on c.id=a.creat_id left join T_USERINFO d on d.user_id=c.user_id  where item_type=97 and b.has_sum=1 and a.item_code ='50' and MEASURE_TIME" + beginSgin + "to_timestamp('" + dtpBeginTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + dtpEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + "";

            ////入量总和
            //string SqlIn_1 = "select '入量总合' as ItemName,sum(a.item_value) as sumval from t_nurse_record a " +
            //       " where item_show_name='入量'  and other_name not like '%弃液%' " +
            //       "and MEASURE_TIME" + beginSgin + "to_timestamp('" + dtpBeginTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + dtpEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + "";
            ////弃液总和
            //string SqlIn_2 = "select '入量弃液' as ItemName,sum(a.item_value) as sumval from t_nurse_record a " +
            //       " where item_show_name='入量'  and other_name like '%弃液%' " +
            //       "and MEASURE_TIME" + beginSgin + "to_timestamp('" + dtpBeginTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + dtpEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + "";


            //// 大小便
            //string SqlOut_1 = "select '大小便' as ItemName,sum(a.item_value) as sumval from t_nurse_record a inner join T_NURSE_RECORD_DICT b on a.item_code=b.item_code or to_char(b.id)=a.item_code  left join T_ACCOUNT_USER c on c.id=a.creat_id left join T_USERINFO d on d.user_id=c.user_id  where item_type=97 and lower(a.item_value) not like '%g%' and b.has_sum=1 and MEASURE_TIME" +
            //    beginSgin + "to_timestamp('" + dtpBeginTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + dtpEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + "";
            ////引流
            //string SqlOut_2 = "select '引流' as ItemName,sum(a.item_value) as sumval from t_nurse_record a where item_show_name like '管%量' and MEASURE_TIME" +
            //beginSgin + "to_timestamp('" + dtpBeginTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + dtpEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + "";
            //string Sql = SqlIn_1 + " union " + SqlIn_2 + " union " + SqlOut_1 + " union " + SqlOut_2;

            //DataSet ds = App.GetDataSet(Sql);

            //sumtemp.DateTime = dtpEndTime.Value.ToString("yyyy-MM-dd HH:mm");
            //if (cboTiming.Text == "阶段性出入量")
            //{
            //    sumtemp.Temperature = lblTatolTime.Text + "h总结";
            //}
            //else
            //{
            //    sumtemp.Temperature = cboTiming.Text;
            //}

            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{

            //    if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("入量总合"))
            //    {
            //        if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
            //        {
            //            Eat = ds.Tables[0].Rows[i]["sumval"].ToString();
            //        }
            //        else
            //        {
            //            Eat = "0";
            //        }
            //    }
            //    else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("入量弃液"))
            //    {
            //        if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
            //        {
            //            LetFlow = ds.Tables[0].Rows[i]["sumval"].ToString();
            //        }
            //        else
            //        {
            //            LetFlow = "0";
            //        }
            //    }
            //    else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("大小便"))
            //    {
            //        if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
            //        {
            //            Urine = ds.Tables[0].Rows[i]["sumval"].ToString();
            //        }
            //        else
            //        {
            //            Urine = "0";
            //        }
            //    }
            //    else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("引流"))
            //    {
            //        if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
            //        {
            //            Yl = ds.Tables[0].Rows[i]["sumval"].ToString();
            //        }
            //        else
            //        {
            //            Yl = "0";
            //        }
            //    }
            //    //else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("大便"))
            //    //{
            //    //    if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
            //    //    {
            //    //        Excrement = ds.Tables[0].Rows[i]["sumval"].ToString();
            //    //    }
            //    //    else
            //    //    {
            //    //        Excrement = "0";
            //    //    }
            //    //}
            //}
            ////计算入量总和
            //try
            //{
            //    inAmount = Convert.ToInt32(Eat) - Convert.ToInt32(LetFlow);
            //}
            //catch (Exception)
            //{

            //    inAmount = 0;
            //}
            ////计算出量总和
            //try
            //{
            //    outAmount = Convert.ToInt32(Urine) + Convert.ToInt32(Yl);
            //}
            //catch (Exception)
            //{

            //    outAmount = 0;
            //}
            //sumtemp.In_item_value = inAmount == 0 ? "" : inAmount.ToString();//入量总和
            ////sumtemp.Shit = Excrement;//大便量
            //sumtemp.Urine = outAmount == 0 ? "" : outAmount.ToString();//出量总和 
            //if (App.UserAccount.UserInfo != null)
            //{
            //    sumtemp.Signature = App.UserAccount.UserInfo.User_name;//签名
            //}
            //DateTime TempDate = new DateTime();
            //bool flag = false;

            ////将汇总记录插到对象集合中去
            //for (int i = 0; i < nurses.Count; i++)
            //{
            //    Class_Nurse_Record temp_nuser = (Class_Nurse_Record)nurses[i];
            //    if (temp_nuser.DateTime != null)
            //    {
            //        TempDate = Convert.ToDateTime(temp_nuser.DateTime);
            //    }
            //    else
            //    {
            //        SumNusers.Add(temp_nuser);
            //        continue;
            //    }

            //    if (TempDate >= dtpEndTime.Value && !flag)//汇总结束时间小于测量时间时，先添加汇总对象
            //    {
            //        SumNusers.Add(sumtemp);
            //        SumNusers.Add(temp_nuser);
            //        flag = true;
            //    }
            //    //else if (i == nurses.Count - 1 && TempDate <= Convert.ToDateTime(EndTime) && !flag)//最后一次循环,汇总时间大于测量时间，添加汇总对象
            //    //{
            //    //    SumNusers.Add(temp_nuser);
            //    //    SumNusers.Add(sumtemp);
            //    //    flag = true;
            //    //}
            //    else
            //    {
            //        SumNusers.Add(temp_nuser);
            //    }
            //}

            //nurses.Clear();
            //for (int i = 0; i < SumNusers.Count; i++)
            //{
            //    nurses.Add(SumNusers[i]);
            //}

            //string NusersRecord = dtpBeginTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "," + dtpEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "," + sumtemp.Temperature;



            ////记录计算步骤
            //SumNusersRecords.Add(NusersRecord);


            //int id = App.GenId("t_nurse_dangery_inout_sum_h", "ID");//,CREAT_ID  ,'" + App.UserAccount.Account_id+ "'
            //Class_Take_over_SEQ take_Seq = cboTiming.SelectedItem as Class_Take_over_SEQ;

            //if (take_Seq != null)
            //{
            //    string inserSumSql = "insert into t_nurse_dangery_inout_sum_h(ID,PID,CALC_DATE,START_TIME,END_TIME,OPER_METHOD,patient_Id,seq_id,SIGNATURE)values(" +
            //    id.ToString() + ",'" + currentPatient.PId + "',sysdate,to_timestamp('" +
            //    dtpBeginTime.Value.ToString("yyyy-MM-dd HH:mm") + "','yyyy-MM-dd HH24:mi'),to_timestamp('" +
            //    dtpEndTime.Value.ToString("yyyy-MM-dd HH:mm") + "','yyyy-MM-dd HH24:mi'),'" + sumtemp.Temperature + "'," + currentPatient.Id + "," + take_Seq.Id + ",'" + App.UserAccount.UserInfo.User_name + "')";
            //    int count = App.ExecuteSQL(inserSumSql);
            //    //SetTable();//表头设置
            //    //ShowSumDataGrid();
            //}
#endregion
            
        }

        /// <summary>
        /// 表格的汇总计算刷新
        /// </summary>
        private void ShowSumDataGrid()
        {
            string TempDateTime = null;
            Class_Nurse_Record[] Nusers_objs = new Class_Nurse_Record[nurses.Count];
            for (int i = 0; i < nurses.Count; i++)
            {

                Nusers_objs[i] = new Class_Nurse_Record();
                Nusers_objs[i] = (Class_Nurse_Record)nurses[i];
                //if (TempDateTime == null)
                //{
                //    TempDateTime = Nusers_objs[i].DateTime;
                //}
                //else if (TempDateTime != null)
                //{
                //    if (Nusers_objs[i].DateTime != TempDateTime)
                //    {
                //        if (Nusers_objs[i].DateTime != null)
                //            TempDateTime = Nusers_objs[i].DateTime;
                //    }
                //    else
                //    {
                //        Nusers_objs[i].DateTime = null;
                //    }
                //}
            }
            //SetTable();//表头设置
            flgView.Rows.Count = 4 + nurses.Count;
            if (Nusers_objs.Length != 0)
            {
                //Nusers_objs[Nusers_objs.Length - 1] = new Class_Nurse_Record();
                App.ArrayToGrid(flgView, Nusers_objs, cols, 3);
            }


            //给汇总计算的行插入ID
            for (int i = 0; i < Nusers_objs.Length; i++)
            {
                if (Nusers_objs[i].Number != null)
                {
                    flgView[i + 3, 35] = Nusers_objs[i].Number;
                }
            }

            //单元格合并和设置
            //CellUnit(pipe1, pipe2, pipe3, pipe4, pipe5);
            //flgView.AutoSizeCols();
            //flgView.AutoSizeRows();
            //for (int i = 0; i < flgView.Rows.Count; i++)
            //{
            //    if (flgView[i, 12] != null)
            //    {
            //        if (flgView[i, 12].ToString().Contains("小结") || flgView[i, 12].ToString().Contains("出入量"))
            //        {
            //            flgView.Rows[i].AllowEditing = false;
            //        }
            //        else
            //        {
            //            flgView.Rows[i].AllowEditing = true;
            //        }
            //    }
            //}
            //for (int i = 0; i < flgView.Rows.Count; i++)
            //{
            //    if (flgView[i, 12] != null)
            //    {
            //        //只要有小结和出入量这几个字的字体都变成蓝色
            //        if (flgView[i, 12].ToString().Contains("小结") || flgView[i, 12].ToString().Contains("出入量"))
            //        {
            //            if (flgView[i, 12].ToString().Contains("24小时出入量") || flgView[i, 12].ToString().Contains("夜班小结"))
            //            {
            //                flgView.Rows[i].StyleNew.ForeColor = Color.Red;
            //                //横线加粗
            //                flgView.Rows[i].StyleNew.Border.Color = Color.Red;
            //                flgView.Rows[i].StyleNew.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Horizontal;
            //                flgView.Rows[i].StyleNew.Border.Width = 3;
            //            }
            //            else
            //            {
            //                flgView.Rows[i].StyleNew.ForeColor = Color.Blue;
            //                flgView.Rows[i].StyleNew.Border.Color = Color.Red;
            //                flgView.Rows[i].StyleNew.Border.Direction = C1.Win.C1FlexGrid.BorderDirEnum.Horizontal;
            //                flgView.Rows[i].StyleNew.Border.Width = 3;
            //            }
            //        }
            //        else
            //        {
            //            flgView.Rows[i].StyleNew.ForeColor = Color.Black;
            //        }
            //    }
            //}
        }
        private void dtpBeginTime_ValueChanged(object sender, EventArgs e)
        {
            string tHour;
            TimeSpan sp = new TimeSpan();
            sp = dtpEndTime.Value - dtpBeginTime.Value;
            //tHour = sp.TotalHours;
            //lblTatolTime.Text = tHour.ToString().Split('.')[0];
            tHour = Convert.ToString(sp.Days * 24 + sp.Hours) + "h" ;
            tHour += sp.Minutes == 0 ? "" : sp.Minutes.ToString() + "′";
            lblTatolTime.Text = tHour;
        }

        private void dtpEndTime_ValueChanged(object sender, EventArgs e)
        {
            string tHour;
            TimeSpan sp = new TimeSpan();
            sp = dtpEndTime.Value - dtpBeginTime.Value;
            //tHour = sp.TotalHours;
            //lblTatolTime.Text = tHour.ToString().Split('.')[0];
            tHour = Convert.ToString(sp.Days * 24 + sp.Hours) + "h";
            tHour += sp.Minutes == 0 ? "" : sp.Minutes.ToString() + "′";
            lblTatolTime.Text = tHour;
        }
        private void dtpDateSelect_ValueChanged(object sender, EventArgs e)
        {
            cboTiming_SelectedIndexChanged(sender, e);
        }

        /// <summary>
        ///  统计出入总量
        /// </summary>
        /// <param name="IsToDay">是否统计当前查询日前</param>
        private void SumInOrOutRecordSet(bool IsToDay)
        {
            try
            {

                SumNusersRecords.Clear();
                string date = dtpDate.Value.ToString("yyyy-MM-dd");
                string sql_date = "select * from t_nurse_dangery_inout_sum_h where (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_Id=" + currentPatient.Id + " and  to_char(end_time,'yyyy-MM-dd')='" + date + "'  order by end_time";
                if (!IsToDay)
                {
                    sql_date = "select * from t_nurse_dangery_inout_sum_h where (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_Id=" + currentPatient.Id + "  order by end_time";
                }
                DataSet ds_sum_oper = App.GetDataSet(sql_date);

                for (int i = 0; i < ds_sum_oper.Tables[0].Rows.Count; i++)
                {
                    //SumNusersRecords.Add(Convert.ToDateTime(ds_sum_oper.Tables[0].Rows[i]["start_time"]).ToString("yyyy-MM-dd HH:mm") + "," + Convert.ToDateTime(ds_sum_oper.Tables[0].Rows[i]["end_time"]).ToString("yyyy-MM-dd HH:mm") + "," + ds_sum_oper.Tables[0].Rows[i]["oper_method"].ToString().Replace("小时出入量", "h总结") + "," + ds_sum_oper.Tables[0].Rows[i]["ID"].ToString() + "," + ds_sum_oper.Tables[0].Rows[i]["seq_id"] + "," + ds_sum_oper.Tables[0].Rows[i]["SIGNATURE"] + "," + ds_sum_oper.Tables[0].Rows[i]["SUM_ITEM"]);

                    SumNusersRecords.Add(Convert.ToDateTime(ds_sum_oper.Tables[0].Rows[i]["start_time"]).ToString("yyyy-MM-dd HH:mm") + "," + Convert.ToDateTime(ds_sum_oper.Tables[0].Rows[i]["end_time"]).ToString("yyyy-MM-dd HH:mm") + "," + ds_sum_oper.Tables[0].Rows[i]["oper_method"].ToString().Replace("小时出入量", "h总结") + ",0," + ds_sum_oper.Tables[0].Rows[i]["seq_id"] + "," + ds_sum_oper.Tables[0].Rows[i]["SIGNATURE"] + "," + ds_sum_oper.Tables[0].Rows[i]["SUM_ITEM"]);
                }

                for (int i1 = 0; i1 < SumNusersRecords.Count; i1++)
                {
                    string BeginTime, EndTime, Item_name;
                    string BeginedTiem, EndedTime;
                    string Remaining = "0";//余液-
                    string Remained = "0";//余液+
                    string LetFlow = "";//弃液
                    double Eat = 0;//食物
                    double Urine = 0;//大小便
                    double Yl = 0;//引流
                    double DB = 0;//大便
                    double XB = 0;//小便
                    double G1 = 0;//管1
                    double G2 = 0;//管2
                    double G3 = 0;//管3
                    double G4 = 0;//管4
                    double G5 = 0;//管5


                    double inAmount = 0;//入量总和
                    double outAmount = 0;//出量总和
                    string Number = "";//号码
                    string seq_id = "";//统计类型ID
                    string singsure = ""; //签名

                    BeginTime = SumNusersRecords[i1].ToString().Split(',')[0];
                    EndTime = SumNusersRecords[i1].ToString().Split(',')[1];
                    Item_name = SumNusersRecords[i1].ToString().Split(',')[2];
                    Number = SumNusersRecords[i1].ToString().Split(',')[3];
                    seq_id = SumNusersRecords[i1].ToString().Split(',')[4];
                    //creatID = SumNusersRecords[i1].ToString().Split(',')[4];+ "," + ds_sum_oper.Tables[0].Rows[i]["CREAT_ID"].ToString()
                    singsure = SumNusersRecords[i1].ToString().Split(',')[5];
                    string[] sum_item = SumNusersRecords[i1].ToString().Split(',')[6].Split('|');//统计项目

                    SumNusers.Clear();

                    //日间,夜间的上一班次时间
                    //BeginedTiem = Convert.ToDateTime(EndTime).AddDays(-1).ToString("yyyy-MM-dd HH:mm");
                    //EndedTime = BeginTiem;

                    Class_Nurse_Record sumtemp = new Class_Nurse_Record();

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
                    #region 注释
                    //string SqlIn_1 = "select '入量总合' as ItemName,sum(a.item_value) as sumval from t_nurse_record a " +
                    //         @"inner join T_NURSE_RECORD_DICT b on to_char(b.id)=a.item_code  " +
                    //         @"left join T_ACCOUNT_USER c on c.id=a.creat_id " +
                    //         @"left join T_USERINFO d on d.user_id=c.user_id  where item_show_name='入量' and b.has_sum=1  " +
                    //         @"and MEASURE_TIME" + beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" +
                    //         endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + "";

                    ////出量总和-小便
                    //string SqlOut_1 = "select '小便' as ItemName,sum(a.item_value) as sumval from t_nurse_record a inner join T_NURSE_RECORD_DICT b on a.item_code=b.item_code or to_char(b.id)=a.item_code  left join T_ACCOUNT_USER c on c.id=a.creat_id left join T_USERINFO d on d.user_id=c.user_id  where item_type=97 and b.has_sum=1 and a.item_code ='49' and MEASURE_TIME" +
                    //    beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + "";
                    ////出量总和-大便
                    //string SqlOut_2 = "select '大便' as ItemName,sum(a.item_value) as sumval from t_nurse_record a inner join T_NURSE_RECORD_DICT b on a.item_code=b.item_code or to_char(b.id)=a.item_code  left join T_ACCOUNT_USER c on c.id=a.creat_id left join T_USERINFO d on d.user_id=c.user_id  where item_type=97 and b.has_sum=1 and a.item_code ='50' and MEASURE_TIME" +
                    //    beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + "";
                    #endregion

                    #region old统计sql
                    ////入量总和
                    //string SqlIn_1 = "select '入量总合' as ItemName,sum(a.item_value) as sumval from t_nurse_record a " +
                    //     @" where item_show_name='入量'  and other_name not like '%弃液%' and other_name not like '%余液%' and (regexp_like (trim(item_value),'^-?([1-9]\d*\.\d*|0\.\d*[1-9]\d*|0?\.0+|0)$') or regexp_like (trim(item_value),'^[[:digit:]]+$')) " +
                    //     @"and MEASURE_TIME" + beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" +
                    //         endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and (RECORD_TYPE='D' or RECORD_TYPE is null) and  patient_Id=" + currentPatient.Id + "";
                    ////弃液总和
                    //string SqlIn_2 = "select '入量弃液' as ItemName,sum(abs(a.item_value)) as sumval from t_nurse_record a " +
                    //       @" where item_show_name='入量'  and other_name like '%弃液%' and (regexp_like (trim(item_value),'^-?([1-9]\d*\.\d*|0\.\d*[1-9]\d*|0?\.0+|0)$') or regexp_like (trim(item_value),'^[[:digit:]]+$')) " +
                    //       @"and MEASURE_TIME" + beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" +
                    //         endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and (RECORD_TYPE='D' or RECORD_TYPE is null) and  patient_Id=" + currentPatient.Id + "";

                    ////当前统计时段余液总和
                    //string SqlIn_3 = "select '入量余液-' as ItemName,sum(abs(a.item_value)) as sumval from t_nurse_record a " +
                    //       @" where item_show_name='入量'  and other_name like '%余液%'  and (regexp_like (trim(item_value),'^-?([1-9]\d*\.\d*|0\.\d*[1-9]\d*|0?\.0+|0)$') or regexp_like (trim(item_value),'^[[:digit:]]+$')) " +
                    //       @"and MEASURE_TIME" + beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" +
                    //         endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and (RECORD_TYPE='D' or RECORD_TYPE is null) and  patient_Id=" + currentPatient.Id + "";

                    ////上次统计时段余液总和
                    //string SqlIn_4 = "select '入量余液+' as ItemName,sum(abs(a.item_value)) as sumval from t_nurse_record a " +
                    //       @" where item_show_name='入量'  and other_name like '%余液%'  and (regexp_like (trim(item_value),'^-?([1-9]\d*\.\d*|0\.\d*[1-9]\d*|0?\.0+|0)$') or regexp_like (trim(item_value),'^[[:digit:]]+$')) " +
                    //       @"and MEASURE_TIME>to_timestamp('" + BeginedTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME<=to_timestamp('" + EndedTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and (RECORD_TYPE='D' or RECORD_TYPE is null) and  patient_Id=" + currentPatient.Id + "";


                    //// 大便
                    //string SqlOut_1 = @"select '大小便' as ItemName,sum(a.item_value) as sumval from t_nurse_record a inner join T_NURSE_RECORD_DICT b on a.item_code=b.item_code or to_char(b.id)=a.item_code  left join T_ACCOUNT_USER c on c.id=a.creat_id left join T_USERINFO d on d.user_id=c.user_id  where item_type=97 and lower(a.item_value) not like '%g%' and b.has_sum=1 and (regexp_like (trim(item_value),'^-?([1-9]\d*\.\d*|0\.\d*[1-9]\d*|0?\.0+|0)$') or regexp_like (trim(item_value),'^[[:digit:]]+$')) and MEASURE_TIME" +
                    //    beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and (RECORD_TYPE='D' or RECORD_TYPE is null) and  patient_Id=" + currentPatient.Id + "";


                    ////管X量
                    //string SqlOut_2 = @"select '引流' as ItemName,sum(a.item_value) as sumval from t_nurse_record a where item_show_name like '管%量' and (regexp_like (trim(item_value),'^-?([1-9]\d*\.\d*|0\.\d*[1-9]\d*|0?\.0+|0)$') or regexp_like (trim(item_value),'^[[:digit:]]+$')) and MEASURE_TIME" +
                    //    beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and (RECORD_TYPE='D' or RECORD_TYPE is null) and  patient_Id=" + currentPatient.Id + "";

                    //string SqlOut = "";

                    //foreach (string i in sum_item)
                    //{
                    //    if (i != null && i != "")
                    //    {
                    //        SqlOut += " union " + "select '" + i + "' as ItemName,sum(a.item_value) as sumval from t_nurse_record a where item_show_name like '" + i + @"' and (regexp_like (trim(item_value),'^-?([1-9]\d*\.\d*|0\.\d*[1-9]\d*|0?\.0+|0)$') or regexp_like (trim(item_value),'^[[:digit:]]+$')) and MEASURE_TIME" +
                    //            beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and (RECORD_TYPE='D' or RECORD_TYPE is null) and  patient_Id=" + currentPatient.Id + "";
                    //    }
                    //    else
                    //    {
                    //        SqlOut = " union " + SqlOut_1 + " union " + SqlOut_2;
                    //    }
                    //}
                    //string Sql = "";
                    //if (Item_name.Contains("日间") || Item_name.Contains("夜间"))
                    //{//需要计算余液的值
                    //    Sql = SqlIn_1 + " union " + SqlIn_2 + " union " + SqlIn_3 + " union " + SqlIn_4 + SqlOut; //" union " + SqlOut_1 + " union " + SqlOut_2;
                    //}
                    //else
                    //{
                    //    Sql = SqlIn_1 + " union " + SqlIn_2 + SqlOut;// " union " + SqlOut_1 + " union " + SqlOut_2;
                    //}
                    #endregion

                    StringBuilder sbSum = new StringBuilder("select item_show_name as ItemName,a.item_value as ItemValue,a.item_code as ItemCode from t_nurse_record a");
                    sbSum.Append(" where 1=1");
                    sbSum.Append(" and MEASURE_TIME" + beginSgin + "to_timestamp('" + BeginTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME");
                    sbSum.Append(" " + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id);
                    sbSum.Append(" and (RECORD_TYPE is null or record_type='" + strType + "')");
                    sbSum.Append(" and item_show_name in('入量','大便','小便','管1量','管2量','管3量','管4量','管5量')");
                    //处理开始时间点的余液
                    sbSum.Append(" Union all");
                    sbSum.Append(" select item_show_name as ItemName,a.item_value as ItemValue,'余液+' as ItemCode from t_nurse_record a");
                    sbSum.Append(" where  1=1");
                    sbSum.Append(" and to_char(MEASURE_TIME,'yyyy-mm-dd hh24:mi')='" + Convert.ToDateTime(BeginTime).ToString("yyyy-MM-dd HH:mm") + "'");
                    sbSum.Append(" and patient_Id=" + currentPatient.Id);
                    sbSum.Append(" and (RECORD_TYPE is null or record_type='" + strType + "')");
                    sbSum.Append(" and item_show_name='入量'");
                    sbSum.Append(" and item_code='余液'");
                    //处理结束时间点的余液
                    sbSum.Append(" Union all");
                    sbSum.Append(" select item_show_name as ItemName,a.item_value as ItemValue,'余液-' as ItemCode from t_nurse_record a");
                    sbSum.Append(" where  1=1");
                    sbSum.Append(" and to_char(MEASURE_TIME,'yyyy-mm-dd hh24:mi')='" + Convert.ToDateTime(EndTime).ToString("yyyy-MM-dd HH:mm") + "'");
                    sbSum.Append(" and patient_Id=" + currentPatient.Id);
                    sbSum.Append(" and (RECORD_TYPE is null or record_type='" + strType + "')");
                    sbSum.Append(" and item_show_name='入量'");
                    sbSum.Append(" and item_code='余液'");

                    DataSet dsSum = null;
                    dsSum = App.GetDataSet(sbSum.ToString());
                    #region 统计各单项和
                    if (dsSum.Tables.Count > 0 && dsSum.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow drSum in dsSum.Tables[0].Rows)
                        {
                            double dtmp = 0;
                            string strTempName = drSum["ItemName"].ToString();
                            string strTempValue = drSum["ItemValue"].ToString();
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
                                        else if (strTempCode.Equals("余液+"))
                                        {
                                            dtmp = Math.Abs(dtmp);
                                        }
                                        else if (strTempCode.Equals("余液-"))
                                        {
                                            dtmp = -Math.Abs(dtmp);
                                        }
                                        Eat += dtmp;
                                        break;
                                    case "大便":
                                        DB += dtmp;
                                        break;
                                    case "小便":
                                        XB += dtmp;
                                        break;
                                    case "管1量":
                                        G1 += dtmp;
                                        break;
                                    case "管2量":
                                        G2 += dtmp;
                                        break;
                                    case "管3量":
                                        G3 += dtmp;
                                        break;
                                    case "管4量":
                                        G4 += dtmp;
                                        break;
                                    case "管5量":
                                        G5 += dtmp;
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                    #endregion
                    //DateTime d_begin = Convert.ToDateTime(BeginTiem);
                    //DateTime d_end = Convert.ToDateTime(EndTime);
                    sumtemp.DateTime = EndTime;
                    sumtemp.In_item_name = Item_name;
                    sumtemp.Number = Number;
                    #region 统计项赋值
                    //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    //{
                    //    if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("入量总合"))
                    //    {
                    //        if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
                    //        {
                    //            Eat = ds.Tables[0].Rows[i]["sumval"].ToString();
                    //        }
                    //        else
                    //        {
                    //            Eat = "0";
                    //        }
                    //    }
                    //    else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("入量弃液"))
                    //    {
                    //        if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
                    //        {
                    //            LetFlow = ds.Tables[0].Rows[i]["sumval"].ToString();
                    //        }
                    //        else
                    //        {
                    //            LetFlow = "0";
                    //        }
                    //    }
                    //    else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("入量余液-"))
                    //    {
                    //        if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
                    //        {
                    //            Remaining = ds.Tables[0].Rows[i]["sumval"].ToString();
                    //        }
                    //        else
                    //        {
                    //            Remaining = "0";
                    //        }
                    //    }
                    //    else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("入量余液+"))
                    //    {
                    //        if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
                    //        {
                    //            Remained = ds.Tables[0].Rows[i]["sumval"].ToString();
                    //        }
                    //        else
                    //        {
                    //            Remained = "0";
                    //        }
                    //    }
                    //    else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("大小便"))
                    //    {
                    //        if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
                    //        {
                    //            Urine = ds.Tables[0].Rows[i]["sumval"].ToString();
                    //        }
                    //        else
                    //        {
                    //            Urine = "0";
                    //        }
                    //    }
                    //    else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("引流"))
                    //    {
                    //        if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
                    //        {
                    //            Yl = ds.Tables[0].Rows[i]["sumval"].ToString();
                    //        }
                    //        else
                    //        {
                    //            Yl = "0";
                    //        }
                    //    }
                    //    else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("大便"))
                    //    {
                    //        if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
                    //        {
                    //            DB = ds.Tables[0].Rows[i]["sumval"].ToString();
                    //        }
                    //        else
                    //        {
                    //            DB = "0";
                    //        }
                    //    }
                    //    else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("小便"))
                    //    {
                    //        if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
                    //        {
                    //            XB = ds.Tables[0].Rows[i]["sumval"].ToString();
                    //        }
                    //        else
                    //        {
                    //            XB = "0";
                    //        }
                    //    }
                    //    else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("管1量"))
                    //    {
                    //        if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
                    //        {
                    //            G1 = ds.Tables[0].Rows[i]["sumval"].ToString();
                    //        }
                    //        else
                    //        {
                    //            G1 = "0";
                    //        }
                    //    }
                    //    else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("管2量"))
                    //    {
                    //        if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
                    //        {
                    //            G2 = ds.Tables[0].Rows[i]["sumval"].ToString();
                    //        }
                    //        else
                    //        {
                    //            G2 = "0";
                    //        }
                    //    }
                    //    else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("管3量"))
                    //    {
                    //        if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
                    //        {
                    //            G3 = ds.Tables[0].Rows[i]["sumval"].ToString();
                    //        }
                    //        else
                    //        {
                    //            G3 = "0";
                    //        }
                    //    }
                    //    else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("管4量"))
                    //    {
                    //        if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
                    //        {
                    //            G4 = ds.Tables[0].Rows[i]["sumval"].ToString();
                    //        }
                    //        else
                    //        {
                    //            G4 = "0";
                    //        }
                    //    }
                    //    else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("管5量"))
                    //    {
                    //        if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
                    //        {
                    //            G5 = ds.Tables[0].Rows[i]["sumval"].ToString();
                    //        }
                    //        else
                    //        {
                    //            G5 = "0";
                    //        }
                    //    }
                    //}
                    #endregion
                    //计算入量总和
                    //try
                    //{
                    //    inAmount = Convert.ToDouble(Eat) - Math.Abs(Convert.ToDouble(LetFlow)) - Math.Abs(Convert.ToDouble(Remaining)) + Math.Abs(Convert.ToDouble(Remained));
                    //}
                    //catch (Exception) { inAmount = 0; }
                    inAmount = Eat;
                    //计算出量总和
                    //try
                    //{
                    //    outAmount = Convert.ToDouble(Urine) + Convert.ToDouble(Yl);
                    //}
                    //catch (Exception) { outAmount = 0; }
                    outAmount = DB + XB + G1 + G2 + G3 + G4 + G5;
                    //sumtemp.In_item_value = inAmount == 0 ? "" : inAmount.ToString();//入量总和
                    //sumtemp.Urine = outAmount == 0 ? "" : outAmount.ToString();//出量总和     
                    //if (Item_name.Contains("小结"))
                    //{
                    //    sumtemp.Shit = DB ==0 ? "" : DB.ToString();//大便
                    //    sumtemp.Urine = XB == 0 ? "" : XB.ToString();//小便
                    //    sumtemp.Pipe1_Value = G1 == 0 ? "" : G1.ToString();//管1
                    //    sumtemp.Pipe2_Value = G2 == 0 ? "" : G2.ToString();//管2
                    //    sumtemp.Pipe3_Value = G3 == 0 ? "" : G3.ToString();//管3
                    //    sumtemp.Pipe4_Value = G4 == 0 ? "" : G4.ToString();//管4
                    //    sumtemp.Pipe5_Value = G5 == 0 ? "" : G5.ToString();//管5
                    //}

                    if (Item_name.Contains("总结"))
                    {
                        if (inAmount > 0)
                        {
                            sumtemp.In_item_value = inAmount.ToString();
                        }
                        if (outAmount > 0)
                        {
                            sumtemp.Urine = outAmount.ToString();
                        }
                    }
                    else
                    {
                        for (int isum = 0; isum < sum_item.Length; isum++)
                        {
                            switch (sum_item[isum].Trim())
                            {
                                case "入量":
                                    if (Eat > 0)
                                    {
                                        sumtemp.In_item_value = Eat.ToString();
                                    }
                                    break;
                                case "大便":
                                    if (DB > 0)
                                    {
                                        sumtemp.Shit = DB.ToString();
                                    }
                                    break;
                                case "小便":
                                    if (XB > 0)
                                    {
                                        sumtemp.Urine = XB.ToString();
                                    }
                                    break;
                                case "管1量":
                                    if (G1 > 0)
                                    {
                                        sumtemp.Pipe1_Value = G1.ToString();
                                    }
                                    break;
                                case "管2量":
                                    if (G2 > 0)
                                    {
                                        sumtemp.Pipe2_Value = G2.ToString();
                                    }
                                    break;
                                case "管3量":
                                    if (G3 > 0)
                                    {
                                        sumtemp.Pipe3_Value = G3.ToString();
                                    }
                                    break;
                                case "管4量":
                                    if (G4 > 0)
                                    {
                                        sumtemp.Pipe4_Value = G4.ToString();
                                    }
                                    break;
                                case "管5量":
                                    if (G5 > 0)
                                    {
                                        sumtemp.Pipe5_Value = G5.ToString();
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
                        SumNusers.Add(nurses[i]);
                    }

                    for (int i = 0; i < nurses.Count; i++)
                    {
                        Class_Nurse_Record temp_nuser = (Class_Nurse_Record)SumNusers[i];
                        if (temp_nuser.DateTime != null)
                        {
                            TempDate = Convert.ToDateTime(temp_nuser.DateTime);

                            if (TempDate == Convert.ToDateTime(EndTime))
                            {
                                if (tempSeq != null && tempSeq.End_logic == "0")//结束标记为“0”，汇总插到相同时间点的项目之前
                                {
                                    SumNusers.Insert(i, sumtemp);
                                    break;
                                }
                            }
                            else if (TempDate > Convert.ToDateTime(EndTime))//汇总时间小于当前录入时间，插到这条项目之前
                            {
                                SumNusers.Insert(i, sumtemp);
                                break;
                            }
                        }
                        if (i == SumNusers.Count - 1)
                        {
                            SumNusers.Add(sumtemp);
                            break;
                        }
                    }

                    nurses.Clear();
                    for (int i = 0; i < SumNusers.Count; i++)
                    {
                        nurses.Add(SumNusers[i]);
                    }


                }
                //ShowSumDataGrid();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
        #endregion

        private void 添加空行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flgView.Rows.Insert(flgView.RowSel);
        }

        private void 设置入量项目toolStripMenuItem_Click(object sender, EventArgs e)
        {
            string measureTime = GetTime(flgView.Row);
            C1.Win.C1FlexGrid.RowColEventArgs c1e = e as C1.Win.C1FlexGrid.RowColEventArgs;
            string titleName = "";
            if (flgView[flgView.Row, flgView.Col] != null)
            {
                titleName = flgView[flgView.Row, flgView.Col].ToString();
            }
            frmModifyProjectTitle frm = new frmModifyProjectTitle(titleName, "O");
            frm.ShowDialog();

            if (frm.flag)
            {

                string userId = "";
                try
                {
                    userId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_id=" + currentPatient.Id + " and rownum=1 order by id", 0, "creat_id"));
                    if (userId == null || userId == "")
                    {
                        userId = App.UserAccount.UserInfo.User_id;
                    }
                }
                catch (System.Exception ex)
                {
                    userId = App.UserAccount.UserInfo.User_id;
                }
                string sql = "insert into t_nurse_record" +
                                   "( bed_no, pid, measure_time, item_code, creat_id, create_time, patient_id, item_show_name,other_name,RECORD_TYPE)values" +
                                   "( '" + currentPatient.Sick_Bed_Name + "', '" + currentPatient.PId + "', to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9'), '" + frm.tName + "', '" + userId + "', sysdate, " + currentPatient.Id + ", '入量','" + frm.tName + "','D')";

                //更新入量项目的名字               
                if (flgView[flgView.Row, flgView.Col] != null)
                {
                    if (flgView[flgView.Row, flgView.Col].ToString().Trim() != "")
                    {
                        if (ValidateUser(userId))
                        {
                            sql = "update t_nurse_record set item_code='" + frm.tName + "',other_name='" + frm.tName + "' where (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_id=" + currentPatient.Id + " and item_show_name like '%入量%' and measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9')";
                        }
                        else
                        {
                            App.Msg("修改权限不足!");
                            sql = "";
                        }
                    }
                    
                }

                try
                {
                    App.ExecuteSQL(sql);
                    btnSearch_Click(sender, e);
                }
                catch
                {
                }
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                if (flgView[flgView.Row, flgView.Col] != null && flgView[flgView.Row, flgView.Col].ToString() != "")
                {
                    string measureTime = GetTime(flgView.Row);
                    string itemName = dictColumnName[flgView.Col];
                    string otherName = "";
                    //int isIN = 0;
                    int id = 0;
                    if (itemName == "入量")
                    {
                        otherName = flgView[flgView.Row, 12].ToString();
                    }
                        try
                        {
                            if (flgView[flgView.Row, 35] != null && flgView[flgView.Row, 35].ToString().Length > 0)
                            {
                                id = int.Parse(flgView[flgView.Row, 35].ToString());
                            }
                        }
                        catch { }
                        //if (id == 0)
                        //{
                        //    isIN = Convert.ToInt32(App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='" + itemName + "' and other_name='" + otherName + "' and (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_id=" + currentPatient.Id, 0, "count(*)"));
                        //}
                    //}
                    string del = "";//删除语句
                    
                    
                    if (id==0 && flgView[flgView.Row, 12] != null && (flgView[flgView.Row, 12].ToString().Contains("小结") ||
                        flgView[flgView.Row, 12].ToString().Contains("总结") || 
                        flgView[flgView.Row, 12].ToString().Contains("日间小结") || 
                        flgView[flgView.Row, 12].ToString().Contains("出入量")))//删除汇总 日间小结
                    {
                        string signature = App.ReadSqlVal("select signature from t_nurse_dangery_inout_sum_h where (RECORD_TYPE='D' or RECORD_TYPE is null) and oper_method='" + flgView[flgView.Row, 12].ToString() + "' and end_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and patient_id=" + currentPatient.Id, 0, "signature");
                        if (App.UserAccount.UserInfo.User_name == signature || signature == null || signature == ""|| App.UserAccount.CurrentSelectRole.Role_name.Equals("护士长"))
                        {
                            del = "delete from t_nurse_dangery_inout_sum_h where (RECORD_TYPE='D' or RECORD_TYPE is null) and oper_method='" + flgView[flgView.Row, 12].ToString() + "' and end_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and patient_id=" + currentPatient.Id;
                        }
                        else
                        {
                            App.Msg("权限不足！");
                            return;
                        }
                        
                    }
                    else
                    {
                        //if (itemName == "入量")
                        //{                           
                        //    otherName = flgView[flgView.Row, 12].ToString();                          
                        //}
                        //else if (itemName == "吸氧")
                        //{
                        //    otherName = ldXY[flgView[flgView.Row, 26]].ToString();
                        //}
                        if (flgView.Col != 0)//删除单独项
                        {
                            if (otherName == "")
                            {
                                string operateId = App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='" + itemName + "' and (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_id=" + currentPatient.Id, 0, "creat_id");
                                if (App.UserAccount.UserInfo.User_id==operateId||App.UserAccount.CurrentSelectRole.Role_name.Equals("护士长"))
                                {
                                    del = "delete from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='" + itemName + "' and (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_id=" + currentPatient.Id;
                                }
                                else
                                {
                                    App.Msg("权限不足！");
                                    return;
                                }
                            }
                            else
                            {
                                if (id == 0)
                                {
                                    string operateId = App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='" + itemName + "' and other_name='" + otherName + "' and (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_id=" + currentPatient.Id, 0, "creat_id");
                                    if (App.UserAccount.UserInfo.User_id == operateId || App.UserAccount.CurrentSelectRole.Role_name.Equals("护士长"))
                                    {
                                        del = "delete from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='" + itemName + "' and other_name='" + otherName + "' and (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_id=" + currentPatient.Id;
                                    }
                                    else
                                    {
                                        App.Msg("权限不足！");
                                        return;
                                    }
                                }
                                else
                                {
                                    string operateId = App.ReadSqlVal("select creat_id from t_nurse_record where id=" + id, 0, "creat_id");
                                    if (App.UserAccount.UserInfo.User_id == operateId || App.UserAccount.CurrentSelectRole.Role_name.Equals("护士长"))
                                    {
                                        del = "delete from t_nurse_record where id=" + id;
                                    }
                                    else
                                    {
                                        App.Msg("权限不足！");
                                        return;
                                    }
                                }
                            }
                        }
                        else//删除当前行的所有项目
                        {
                            string operateId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_id=" + currentPatient.Id + " and rownum=1 order by id", 0, "creat_id"));
                            
                            if (App.UserAccount.UserInfo.User_id == operateId||App.UserAccount.CurrentSelectRole.Role_name.Equals("护士长"))
                            {
                                del = "delete from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_id=" + currentPatient.Id;
                            }
                            else
                            {
                                App.Msg("权限不足！");
                                return;
                            }
                        }
                    }


                    int num = App.ExecuteSQL(del);
                    if (num > 0)
                    {
                        operateFlag = true;
                        timer1.Start();
                        App.Msg("删除成功！");
                        //更新创建者
                        App.ExecuteSQL("update t_nurse_record set  update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_id=" + currentPatient.Id);
                        btnSearch_Click(sender, e);
                    }
                }
                else
                {
                    if (flgView[flgView.Row, 0] ==null)
                        flgView.Rows.Remove(flgView.Row);
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

        #region 打印排版设置
        /// <summary>
        /// 根据打印时需要到单元格宽度换行
        /// </summary>
        /// <param name="ds"></param>
        public DataSet ReSetPrintDataSet(DataSet ds)
        {


            //
            /*
             * 28.3465像素/1厘米
             * 9pt 的文字 大约 0.3175cm         
             *
             * 单位算作厘米
             */
            //double datewidth = 1;
            //double timewidth = 1;
            //double tempraturewidth = 1;
            //double pulswidth = 1;
            //double breathwidth = 1;
            //double bloodpruswidth = 1;
            //double spo2width = 1;
            //double medicalwidth = 1;
            //double medicalvalwidth = 1;
            //double foodwidth = 1;
            //double foodvalwidth = 1;
            //double sickinfowidth = 3;
            //double signwidth = 1.25;
            ArrayList DataRows = new ArrayList();

            //ArrayList currRowList = new ArrayList();
            //string currTime = "";
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    if (ds.Tables[0].Rows[i]["in_item_name"].ToString().Contains("小结") || ds.Tables[0].Rows[i]["in_item_name"].ToString().Contains("出入量"))
            //    {
            //        DataRows.Add(ds.Tables[0].Rows[i]);
            //    }
            //    else
            //    {
            //        if (currTime == "")
            //        {
            //            currTime = ds.Tables[0].Rows[i]["in_item_name"].ToString();
            //            currRowList.Clear();
            //        }

            //        if (currTime != ds.Tables[0].Rows[i]["in_item_name"].ToString())
            //        {
            //            currTime = ds.Tables[0].Rows[i]["in_item_name"].ToString();
            //            currRowList.Clear();
            //        }
            //        currRowList.Add(ds.Tables[0].Rows[i]);
            //    }
            //}


            int maxcount = 0;
            string sql_time = "select distinct to_char(t.measure_time,'yyyy-mm-dd hh24:mi') as DATETIMEVAL from T_NURSE_RECORD t where (RECORD_TYPE='D' or RECORD_TYPE is null) and t.patient_Id=" + currentPatient.Id + " order by DATETIMEVAL asc";
            DataSet ds_Time = App.GetDataSet(sql_time);
            if (ds_Time != null)
            {
                for (int i = 0; i < ds_Time.Tables[0].Rows.Count; i++)
                {
                    //DataRow dr_Sum = ds.Tables[0].Select("datetime='" + ds_Time.Tables[0].Rows[i]["datetimeval"].ToString() + "'", "number asc");
                    DataRow[] drArray = ds.Tables[0].Select("datetime='" + ds_Time.Tables[0].Rows[i]["datetimeval"].ToString() + "' and in_item_name not like '%小结%' and in_item_name not like '%总结%' and in_item_name not like '%出入量%'", "number asc");


                    if (drArray.Length != 0)
                    {
                        if (drArray[0]["remark"] == null || drArray[0]["remark"].ToString() == "")
                        {
                            for (int j = 0; j < drArray.Length; j++)
                            {
                                DataRows.Add(drArray[j]);
                            }
                        }
                        else
                        {
                            //计算备注换行
                            string[] remarkArray = RemarkArray(DataInit.ReplaceZYChar(drArray[0]["remark"].ToString()));
                            maxcount = remarkArray.Length > drArray.Length ? remarkArray.Length : drArray.Length;
                            string signature = "";
                            for (int j = 0; j < maxcount; j++)
                            {
                                //备注自动换行
                                if (j <= drArray.Length - 1)
                                {
                                    //清空签名
                                    if (drArray[j]["Signature"].ToString() != "" && j < maxcount - 1)
                                    {
                                        signature = drArray[j]["Signature"].ToString();
                                        drArray[j]["Signature"] = "";
                                    }
                                    if (j <= remarkArray.Length - 1)
                                        drArray[j]["remark"] = remarkArray[j];
                                    DataRows.Add(drArray[j]);
                                }
                                else
                                {

                                    DataRow dr = ds.Tables[0].NewRow();
                                    //签名插到最后一行
                                    if (j == maxcount - 1)
                                    {
                                        dr["Signature"] = signature;
                                    }
                                    dr["remark"] = remarkArray[j];
                                    DataRows.Add(dr);
                                }
                            }
                        }
                    }

                }
            }

            ///*
            // *计算总行数 
            // */
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    if (ds.Tables[0].Rows[i]["datetime"].ToString() != "")
            //        maxcount = MaxRowsCount(ds.Tables[0].Rows[i]);

            //    for (int j = 0; j < maxcount; j++)
            //    {
            //        //if (ds.Tables[0].Rows[i]["datetime"].ToString() != "")
            //        //{
            //        DataRow temp = ds.Tables[0].NewRow();
            //        temp["number"] = j.ToString();
            //        DataRows.Add(temp);
            //        //}
            //    }
            //}

            ///*
            // * 绑定值
            // */
            //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //{
            //    int index = 0;
            //    for (int j = 0; j < DataRows.Count; j++)
            //    {
            //        DataRow temp = (DataRow)DataRows[j];
            //        if (temp["number"].ToString() == i.ToString())
            //        {
            //            BindVal(ref temp, index, ds.Tables[0].Rows[i]);
            //            index++;
            //            DataRows[j] = temp;
            //        }

            //    }

            //}
            ////FormatDisplay(DataRows);
            //toDay = string.Empty;

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
                        //FormatConditionSign(norow[ds.Tables[0].Columns[j].ColumnName].ToString().Split('@')[0].ToString());//,norow[ds.Tables[0].Columns[j].ColumnName].ToString().Split('@')[1].ToString()
                    }
                    else
                    {
                        //if (ds.Tables[0].Columns[j].ColumnName != "Pathograhy")
                        //{
                        temprow1[ds.Tables[0].Columns[j].ColumnName] = norow[ds.Tables[0].Columns[j].ColumnName].ToString();
                        //}
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

            DataRow[] drSum = ds.Tables[0].Select("in_item_name like '%出入量%' or in_item_name like '%小结%' or in_item_name like '%总结%' ");
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

            //string tempYear = "";//年份
            string tempDate = "";//日期
            string tempTime = "";//时间
            dd.Columns.Add("Recordtime");
            //设置时间显示格式,日期相同只显示第一行日期，分相同只显示第一行分
            for (int i = 0; i < dd.Rows.Count; i++)
            {
                dd.Rows[i]["Recordtime"] = dd.Rows[i]["datetime"];
                if (!dd.Rows[i]["in_item_name"].ToString().Contains("小结") && 
                    !dd.Rows[i]["in_item_name"].ToString().Contains("总结") && 
                    !dd.Rows[i]["in_item_name"].ToString().Contains("出入量"))
                {
                    if (dd.Rows[i]["datetime"].ToString() != "")
                    {
                        DateTime currDate = Convert.ToDateTime(dd.Rows[i]["datetime"].ToString());
                        if (i % 11 == 0)
                        {
                            tempDate = "";
                        }
                        if (tempDate == "")
                        {
                            dd.Rows[i]["datetime"] = currDate.ToString("yyyy-MM-dd HH:mm");
                            tempDate = currDate.ToString("yyyy-MM-dd");
                            tempTime = currDate.ToString("HH:mm");
                            continue;
                        }
                        if (tempDate == currDate.ToString("yyyy-MM-dd") && tempTime == currDate.ToString("HH:mm"))//日期与时间都相同，不现实
                        {
                            dd.Rows[i]["datetime"] = "";
                        }
                        else if (tempDate == currDate.ToString("yyyy-MM-dd"))//日期相同，显示小时和分
                        {
                            dd.Rows[i]["datetime"] = currDate.ToString("HH:mm");
                            tempTime = currDate.ToString("HH:mm");
                        }
                        else//不同日期显示日期 小时 分
                        {
                            dd.Rows[i]["datetime"] = currDate.ToString("yyyy-MM-dd HH:mm");
                            tempDate = currDate.ToString("yyyy-MM-dd");
                            tempTime = currDate.ToString("HH:mm");
                        }
                    }
                }
                else
                {
                    DateTime currDate = Convert.ToDateTime(dd.Rows[i]["datetime"].ToString());
                    dd.Rows[i]["datetime"] = Convert.ToDateTime(dd.Rows[i]["datetime"]).ToString("yyyy-MM-dd HH:mm");
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
            //SizeF sizeF = graphics.MeasureString(remark, new Font("宋体", 8));
            int strlength = System.Text.Encoding.Default.GetBytes(remark).Length;
            //备注所占行数
            int remarkRowCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(strlength) / 61));//Convert.ToInt32(sizeF.Width / (28.3465 * 8)) < (sizeF.Width / (28.3465 * 8)) ? Convert.ToInt32(sizeF.Width / (28.3465 * 8)) + 1 : Convert.ToInt32(sizeF.Width / (28.3465 * 8));
            string[] strArr = new string[remarkRowCount];
            string tempperval = "";
            int index = 0;//数组递增索引
            for (int j = 0; j < remark.Length; j++)
            {
                strlength = System.Text.Encoding.Default.GetBytes(tempperval).Length;
                if (strlength < 61 || (strlength==61 &&System.Text.Encoding.Default.GetBytes(remark[j].ToString()).Length != 2))
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
                        //if (index == 0)
                        //{
                        //    strArr[index] = "    " + tempperval.Replace(" ", "");
                        //}
                        //else
                        //{
                        //    strArr[index] = tempperval.Replace(" ", "");
                        //}
                        index++;
                        tempperval = "";
                        //j--;
                    }
                }
                else
                {
                    strArr[index] = tempperval;
                    //if (index == 0)
                    //{
                    //    strArr[index] = "    " + tempperval.Replace(" ", "");
                    //}
                    //else
                    //{
                    //    strArr[index] = tempperval.Replace(" ", "");
                    //}
                    index++;
                    tempperval = "";
                    j--;
                }
            }
            ////备注所占行数
            //int remarkRowCount = Convert.ToInt32(Math.Ceiling(sizeF.Width / (45 * 8)));//Convert.ToInt32(sizeF.Width / (28.3465 * 8)) < (sizeF.Width / (28.3465 * 8)) ? Convert.ToInt32(sizeF.Width / (28.3465 * 8)) + 1 : Convert.ToInt32(sizeF.Width / (28.3465 * 8));
            //string[] strArr = new string[remarkRowCount];
            //string tempperval = "";
            //int index = 0;//数组递增索引
            //for (int j = 0; j < remark.Length; j++)
            //{
            //    sizeF = graphics.MeasureString(tempperval, new Font("宋体", 8));
            //    if (sizeF.Width <= 45 * 8)
            //    {
            //        if (tempperval == "")
            //        {
            //            tempperval = remark[j].ToString();
            //        }
            //        else
            //        {
            //            tempperval += remark[j];
            //        }

            //        if (j == remark.Length - 1)
            //        {
            //            strArr[index] = tempperval;
            //            index++;
            //            tempperval = "";
            //            //j--;
            //        }
            //    }
            //    else
            //    {
            //        strArr[index] = tempperval;
            //        index++;
            //        tempperval = "";
            //        j--;
            //    }
            //}

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

        private void flgView_ChangeEdit(object sender, EventArgs e)
        {
            using (Graphics g = flgView.CreateGraphics())
            {
                if (flgView.Col == 33)
                {
                    // measure text height
                    StringFormat sf = new StringFormat();
                    int wid = flgView.Cols[33].WidthDisplay;
                    string text = flgView.Editor.Text;
                    SizeF sz = g.MeasureString(text, flgView.Font, wid, sf);
                    // adjust row height if necessary
                    C1.Win.C1FlexGrid.Row row = flgView.Rows[flgView.Row];
                    if (sz.Height + 4 > row.HeightDisplay)
                        row.HeightDisplay = (int)sz.Height + 4;
                }
            }
        }

        /// <summary>
        /// 备注模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 备注模板toolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //C1.Win.C1FlexGrid.RowColEventArgs c1e = e as C1.Win.C1FlexGrid.RowColEventArgs;
                //string txt = "";
                //if (this.flgView[flgView.Row, flgView.Col] != null)
                //{
                //    txt = this.flgView[flgView.Row, flgView.Col].ToString();
                //}
                Base_Function.BLL_NURSE.NurseTemplate.frmTemplateList fc = new Base_Function.BLL_NURSE.NurseTemplate.frmTemplateList();
                //App.FormStytleSet(fc, false);
                fc.ShowDialog();
                //赋值
                if (fc.nursecomplate != null && fc.nursecomplate != "")
                {
                    this.flgView[flgView.Row, flgView.Col] = fc.nursecomplate;
                    RowColEventArgs ea = new RowColEventArgs(flgView.Row, flgView.Col);
                    this.flgView_AfterEdit(flgView, ea);
                    this.flgView.Select(flgView.Row, flgView.Col);
                    #region 注释
                    
                    ////if (flgView.RowSel > flgView.Rows.Count)
                    ////{
                    ////    flgView.Rows.Insert(flgView.RowSel + 1);
                    ////}
                    ////else
                    ////{
                    ////    flgView.Rows.Insert(flgView.Rows.Count);
                    ////}
                    //string measureTime = GetTime(flgView.Row);

                    //int length = getStringLength(fc.nursecomplate);
                    //if (length > 1400)
                    //{
                    //    App.Msg("您输入的内容超过1400字节了!");
                    //    return;
                    //}
                    //string itemName = dictColumnName[flgView.Col];
                    //string itemCode = App.ReadSqlVal("select id from t_nurse_record_dict where item_name='" + itemName + "'", 0, "id");

                    //string userId = "";
                    //try
                    //{
                    //    userId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_id=" + currentPatient.Id + " and rownum=1 order by id", 0, "creat_id"));
                    //    if (userId == null || userId == "")
                    //    {
                    //        userId = App.UserAccount.UserInfo.User_id;
                    //    }
                    //}
                    //catch (System.Exception ex)
                    //{
                    //    userId = App.UserAccount.UserInfo.User_id;
                    //}
                    //string sql = "insert into t_nurse_record" +
                    //                         "( bed_no, pid, measure_time, item_code, item_value, creat_id, create_time, patient_id, item_show_name,RECORD_TYPE)values" +
                    //                         "( '" + currentPatient.Sick_Bed_Name + "', '" + currentPatient.PId + "', to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9'), '" +
                    //                         itemCode + "', '" + fc.nursecomplate + "', '" + userId + "', sysdate, " + currentPatient.Id + ", '" + itemName + "','D')";

                    ////更新备注               
                    ////判断是新增还是修改:返回值大于0是修改，等于0是新增
                    //int itemCount = Convert.ToInt32(App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='" + itemName + "' and (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_id=" + currentPatient.Id, 0, "count(*)"));
                    //if (itemCount > 0)
                    //{
                    //    if (ValidateUser(userId))
                    //    {
                    //        sql = "update t_nurse_record set item_code='" + itemCode + "',item_value='" + fc.nursecomplate + "',update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate" +
                    //            " where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='" + itemName + "'  and (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_id=" + currentPatient.Id;
                    //    }
                    //    else
                    //    {
                    //        App.Msg("修改权限不足!");
                    //        sql = "";
                    //    }
                    //}

                    //try
                    //{
                    //    App.ExecuteSQL(sql);
                    //    this.btnSearch_Click(sender, e);
                    //    //SetTable();
                    //    //oldInAmountName = "";
                    //    //ShowData();
                    //    //SumInOrOutRecordSet();
                    //    //CellUnit(pipe1, pipe2, pipe3, pipe4, pipe5);
                    //    //flgView.Cols[33].Width = 100;
                    //    //flgView.Cols[2].Width = 30;
                    //    //flgView.AutoSizeRows();
                    //}
                    //catch
                    //{ }

                    #endregion
                }
            }
            catch (System.Exception ex)
            {

            }
        }

        /// <summary>
        /// 添加模板
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 添加备注模板toolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (flgView[flgView.Row, flgView.Col] != null)
            {
                Base_Function.BLL_NURSE.NurseTemplate.frmTemplateAdd fc = new Base_Function.BLL_NURSE.NurseTemplate.frmTemplateAdd(flgView[flgView.Row, flgView.Col].ToString());
                fc.ShowDialog();
            }
        }

        /// <summary>
        /// 添加,修改诊断名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDiagnose_Click(object sender, EventArgs e)
        {
            frmDiagnose frmdiagnose = new frmDiagnose(currentPatient.Id, diagnose);
            frmdiagnose.ShowDialog(this);
        }

        /// <summary>
        /// 诊断按钮提示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDiagnose_MouseEnter(object sender, EventArgs e)
        {
            ToolTip p = new ToolTip(); 
            p.ShowAlways = true;
            p.SetToolTip(this.btnDiagnose, "提示:点击按钮修改诊断名称.");
        }

        //保存护理诊断
        private void buttonX1_Click(object sender, EventArgs e)
        {
            //诊断名称
            diagnose = txtDiagnose.Text.Trim();
            string update_Sql = @"update t_nurse_record set diagnose_name='" + diagnose + "' where (RECORD_TYPE='D' or RECORD_TYPE is null) and patient_id='" + this.currentPatient.Id + "'";
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

        private int PageRowCount = 11;
        private void ShowMsg()
        {
            #region 护理记录单满页提醒
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
                int nrow=ds.Tables[0].Rows.Count;
                if (nrow % PageRowCount == 0)
                {
                    PageCount = nrow / PageRowCount;
                    FullLastPage=PageCount;
                }
                else
                {
                    PageCount = nrow / PageRowCount + 1;
                    FullLastPage=PageCount-1;
                }
                lmsg1.Text = "共" + PageCount.ToString() + "页,";
                if (FullLastPage > 0)
                {
                    int fullpagerowindex = FullLastPage * PageRowCount - 1;
                    DateTime dtime = new DateTime();
                    string stime = ds.Tables[0].Rows[fullpagerowindex]["Recordtime"].ToString();
                    while (!DateTime.TryParse(stime, out dtime))
                    {
                        fullpagerowindex--;
                        stime = ds.Tables[0].Rows[fullpagerowindex]["Recordtime"].ToString();
                    }
                    lmsg1.Text += "第" + FullLastPage.ToString() + "页已满页";
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

        private void txtDiagnose_TextChanged(object sender, EventArgs e)
        {

        }
        
 
    }
}
