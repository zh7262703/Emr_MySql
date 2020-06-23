using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Specialized;
using Base_Function.BLL_NURSE.Nereuse_record;
using Base_Function.MODEL;
using Base_Function.BLL_NURSE.Nurse_Record.NurseItmeControls;
using System.Threading;
using Base_Function.BASE_COMMON;
using Bifrost;
using C1.Win.C1FlexGrid;

namespace Base_Function.BLL_NURSE.Nurse_Record
{
    public partial class UcNurse_Record_NewBorn : UserControl
    {
        public UcNurse_Record_NewBorn()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 列名称字典
        /// 键:列索引
        /// 值:项目名称
        /// </summary>
        Dictionary<int, string> dictColumnName = new Dictionary<int, string>();
        ColumnInfo[] cols = new ColumnInfo[35];
        /// <summary>
        /// 护理记录单行对象的集合
        /// </summary>
        ArrayList nurses = new ArrayList();
        ArrayList SumNusers = new ArrayList();
        ArrayList SumNusersRecords = new ArrayList();

        #region 字典
        ListDictionary ldDuckItem = new ListDictionary();//管道项目
        ListDictionary ldEye = new ListDictionary();//眼
        ListDictionary ldMouth = new ListDictionary();//口
        ListDictionary ldNavel = new ListDictionary();//脐
        ListDictionary ldButtocks = new ListDictionary();//臀
        ListDictionary ldShower = new ListDictionary();//淋浴
        ListDictionary ldSpongeBath = new ListDictionary();//擦浴
        ListDictionary ldPosition = new ListDictionary();//体位
        ListDictionary ldSkin = new ListDictionary();//皮肤
        ListDictionary ldSuck = new ListDictionary();//吸吮
        ListDictionary ldAutoActive = new ListDictionary();//自主活动
        ListDictionary ldAcra = new ListDictionary();//肢端
        ListDictionary ldCry = new ListDictionary();
        #endregion
        /// <summary>
        /// 诊断
        /// </summary>
        public string diagnose = "";

        /// <summary>
        /// 变更前的药物名称
        /// </summary>
        string oldInAmountName = "";

        /// <summary>
        /// 当前病人
        /// </summary>
        InPatientInfo currentPatient = null;
        /// <summary>
        /// 记录种类 B：新生儿科
        /// </summary>
        string strType="";

        Class_Take_over_SEQ[] Take_over_seq;

        public UcNurse_Record_NewBorn(InPatientInfo patient)
        {
            InitializeComponent();
            currentPatient = patient;
            strType = "B";
            Take_over_SEQ();//绑定班次
            SetCellData();
            LoadDiagnose();
        }

        /// <summary>
        /// 绑定班次表
        /// </summary>
        private void Take_over_SEQ()
        {
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
            dictColumnName.Add(1, "箱温");
            dictColumnName.Add(2, "湿度");
            dictColumnName.Add(3, "体温");
            dictColumnName.Add(4, "心率");
            dictColumnName.Add(5, "呼吸");
            dictColumnName.Add(6, "血压");
            dictColumnName.Add(7, "血氧饱和度");
            dictColumnName.Add(8, "药物名称");
            dictColumnName.Add(9, "药物量");
            dictColumnName.Add(10, "速度");
            dictColumnName.Add(11, "母乳");
            dictColumnName.Add(12, "水");
            dictColumnName.Add(13, "配方奶");
            dictColumnName.Add(14, "小便");
            dictColumnName.Add(15, "颜色");
            dictColumnName.Add(16, "大便");
            dictColumnName.Add(17, "性状");
            dictColumnName.Add(18, "呕吐物");
            dictColumnName.Add(19, "管道");
            dictColumnName.Add(20, "眼");
            dictColumnName.Add(21, "口");
            dictColumnName.Add(22, "脐");
            dictColumnName.Add(23, "臀");
            dictColumnName.Add(24, "淋浴");
            dictColumnName.Add(25, "擦浴");
            dictColumnName.Add(26, "体位");
            dictColumnName.Add(27, "皮肤");
            dictColumnName.Add(28, "哭声");
            dictColumnName.Add(29, "吸吮");
            dictColumnName.Add(30, "自主活动");
            dictColumnName.Add(31, "肢端");
            dictColumnName.Add(32, "护理措施");
            dictColumnName.Add(33, "签名");
        }

        #region 表格设置
        /// <summary>
        /// 绑定数据
        /// </summary>
        public void ShowData()
        {
            SetTable();
            GetDatas(false);
            try
            {
            //过滤相同的时间
                string tempDateTime = null;
                Class_Nurse_Record_NewBorn[] nurse = new Class_Nurse_Record_NewBorn[nurses.Count];
                for (int i = 0; i < nurses.Count; i++)
                {
                    nurse[i] = new Class_Nurse_Record_NewBorn();
                    nurse[i] = nurses[i] as Class_Nurse_Record_NewBorn;

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
                        App.ArrayToGrid(flgView, nurse, cols, 3);
                    }
                    else
                    {
                        flgView.Rows.Count = 3;
                    }
                }
                catch
                {
                }
            }
            catch (Exception ex)
            {
                App.MsgErr("数据加载错误!问题:" + ex.Message);
            }
            CellUnit();
            //flgView.Refresh();
            flgView.AutoSizeCols();
            flgView.AutoSizeRows();
        }

        /// <summary>
        /// 表头设置
        /// </summary>
        private void SetTable()
        {
            flgView.Cols.Count = 35;
            flgView.Rows.Count = 4 + nurses.Count;
            flgView.Rows.Fixed = 3;
            //表头设置
            cols[0].Name = "日期时间";
            cols[0].Field = "dateTime";
            cols[0].Index = 1;
            cols[0].visible = true;

            //病情程度
            cols[1].Name = "箱温";
            cols[1].Field = "boxT";
            cols[1].Index = 2;
            cols[1].visible = true;

            //护理级别
            cols[2].Name = "湿度";
            cols[2].Field = "humidity";
            cols[2].Index = 3;
            cols[2].visible = true;

            //体温
            cols[3].Name = "体温";
            cols[3].Field = "t";
            cols[3].Index = 4;
            cols[3].visible = true;

            //心率
            cols[4].Name = "心率";
            cols[4].Field = "hr";
            cols[4].Index = 5;
            cols[4].visible = true;

            //呼吸
            cols[5].Name = "呼吸";
            cols[5].Field = "r";
            cols[5].Index = 6;
            cols[5].visible = true;

            //血压
            cols[6].Name = "血压";
            cols[6].Field = "bp";
            cols[6].Index = 7;
            cols[6].visible = true;

            //血氧饱和度
            cols[7].Name = "血氧饱和度";
            cols[7].Field = "oxygen_saturation";
            cols[7].Index = 8;
            cols[7].visible = true;

            //药物名称
            cols[8].Name = "药物名称";
            cols[8].Field = "medicineName";
            cols[8].Index = 9;
            cols[8].visible = true;

            //药物量
            cols[9].Name = "药物量";
            cols[9].Field = "medicineValue";
            cols[9].Index = 10;
            cols[9].visible = true;

            //速度
            cols[10].Name = "速度";
            cols[10].Field = "v";
            cols[10].Index = 11;
            cols[10].visible = true;

            //母乳
            cols[11].Name = "母乳";
            cols[11].Field = "breastMilk";
            cols[11].Index = 12;
            cols[11].visible = true;

            //水
            cols[12].Name = "水";
            cols[12].Field = "water";
            cols[12].Index = 13;
            cols[12].visible = true;

            //配方奶
            cols[13].Name = "配方奶";
            cols[13].Field = "formula";
            cols[13].Index = 14;
            cols[13].visible = true;

            //小便
            cols[14].Name = "小便";
            cols[14].Field = "urine";
            cols[14].Index = 15;
            cols[14].visible = true;

            //颜色
            cols[15].Name = "颜色";
            cols[15].Field = "uColor";
            cols[15].Index = 16;
            cols[15].visible = true;

            //大便
            cols[16].Name = "大便";
            cols[16].Field = "shit";
            cols[16].Index = 17;
            cols[16].visible = true;

            //性状
            cols[17].Name = "性状";
            cols[17].Field = "characteristics";
            cols[17].Index = 18;
            cols[17].visible = true;

            //呕吐物
            cols[18].Name = "呕吐物";
            cols[18].Field = "puke";
            cols[18].Index = 19;
            cols[18].visible = true;

            //管道
            cols[19].Name = "管道";
            cols[19].Field = "ductItem";
            cols[19].Index = 20;
            cols[19].visible = true;

            //眼
            cols[20].Name = "眼";
            cols[20].Field = "eye";
            cols[20].Index = 21;
            cols[20].visible = true;

            //口
            cols[21].Name = "口";
            cols[21].Field = "mouth";
            cols[21].Index = 22;
            cols[21].visible = true;

            //脐
            cols[22].Name = "脐";
            cols[22].Field = "navel";
            cols[22].Index = 23;
            cols[22].visible = true;

            //臀
            cols[23].Name = "臀";
            cols[23].Field = "buttocks";
            cols[23].Index = 24;
            cols[23].visible = true;

            //淋浴
            cols[24].Name = "淋浴";
            cols[24].Field = "shower";
            cols[24].Index = 25;
            cols[24].visible = true;

            //擦浴
            cols[25].Name = "擦浴";
            cols[25].Field = "spongeBath";
            cols[25].Index = 26;
            cols[25].visible = true;

            //体位
            cols[26].Name = "体位";
            cols[26].Field = "position";
            cols[26].Index = 27;
            cols[26].visible = true;

            //皮肤
            cols[27].Name = "皮肤";
            cols[27].Field = "skin";
            cols[27].Index = 28;
            cols[27].visible = true;

            //哭声
            cols[28].Name = "哭声";
            cols[28].Field = "cry";
            cols[28].Index = 29;
            cols[28].visible = true;

            //吸吮
            cols[29].Name = "吸吮";
            cols[29].Field = "suck";
            cols[29].Index = 30;
            cols[29].visible = true;

            //自主活动
            cols[30].Name = "自主活动";
            cols[30].Field = "autoactive";
            cols[30].Index = 31;
            cols[30].visible = true;

            //肢端
            cols[31].Name = "肢端";
            cols[31].Field = "acra";
            cols[31].Index = 32;
            cols[31].visible = true;

            //护理措施
            cols[32].Name = "护理措施";
            cols[32].Field = "nurseResult";
            cols[32].Index = 33;
            cols[32].visible = true;

            //签名
            cols[33].Name = "签名";
            cols[33].Field = "signature";
            cols[33].Index = 34;
            cols[33].visible = true;

            cols[34].Name = "SumID";
            cols[34].Field = "Number";
            cols[34].Index = 35;
            cols[34].visible = false;
        }

        /// <summary>
        /// 单元格合并和设置 
        /// </summary>
        private void CellUnit()
        {
            flgView.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            flgView.Cols.Fixed = 0;

            C1.Win.C1FlexGrid.CellRange cr;
            cr = flgView.GetCellRange(0, 0, 2, 0);
            cr.Data = "日期\r\n/\r\n时间";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 1, 2, 1);
            cr.Data = "箱\n温";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 2, 2, 2);
            cr.Data = "湿\n度";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 3, 0, 7);
            cr.Data = "监测项目";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 3, 2, 3);
            cr.Data = "体\n温";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 4, 2, 4);
            cr.Data = "心\n率";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 5, 2, 5);
            cr.Data = "呼\n吸";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 6, 2, 6);
            cr.Data = "血压";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 7, 2, 7);
            cr.Data = "血氧\n饱和度";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 8, 0, 13);
            cr.Data = "入量(ml)";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 8, 1, 10);
            cr.Data = "药物";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(2, 8, 2, 8);
            cr.Data = "名称";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(2, 9, 2, 9);
            cr.Data = "量";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(2, 10, 2, 10);
            cr.Data = "速度";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 11, 2, 11);
            cr.Data = "母\n乳";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 12, 2, 12);
            cr.Data = "水";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 13, 2, 13);
            cr.Data = "配\n方\n奶";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 14, 0, 18);
            cr.Data = "出量(ml)";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 14, 1, 15);
            cr.Data = "小便";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(2, 14, 2, 14);
            cr.Data = "量\n或\n次";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(2, 15, 2, 15);
            cr.Data = "色";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 16, 1, 17);
            cr.Data = "大便";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);


            cr = flgView.GetCellRange(2, 16, 2, 16);
            cr.Data = "量\n或\n次";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(2, 17, 2, 17);
            cr.Data = "性\n状";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 18, 2, 18);
            cr.Data = "呕\n吐";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 19, 2, 19);
            cr.Data = "各\n种\n管\n道";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 20, 0, 26);
            cr.Data = "护   理";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 20, 2, 20);
            cr.Data = "眼";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 21, 2, 21);
            cr.Data = "口";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 22, 2, 22);
            cr.Data = "脐";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 23, 2, 23);
            cr.Data = "臀";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 24, 2, 24);
            cr.Data = "淋\n浴";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 25, 2, 25);
            cr.Data = "擦\n浴";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 26, 2, 26);
            cr.Data = "体\n位";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 27, 0, 31);
            cr.Data = "病情观察";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 27, 2, 27);
            cr.Data = "皮\n肤";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 28, 2, 28);
            cr.Data = "哭\n声";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 29, 2, 29);
            cr.Data = "吸\n吮";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 30, 2, 30);
            cr.Data = "自\n主\n活\n动";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 31, 2, 31);
            cr.Data = "肢\n端";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 32, 2, 32);
            cr.Data = "护理\n措施及效果";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 33, 2, 33);
            cr.Data = "签名";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            //flgView.AutoSizeCols();
            flgView.Cols[27].Width = 35;
            flgView.Cols[28].Width = 35;
            flgView.Cols[32].Width = 100;
            flgView.AutoSizeRows();
        }

        private void SetCellData()
        {
            //管道
            ldDuckItem.Add("0", "-");
            ldDuckItem.Add("1", "+");
            ldDuckItem.Add("nul", " ");

            //眼
            ldEye.Add("0", "√");
            ldEye.Add("1", " ");

            //口
            ldMouth.Add("0", "√");
            ldMouth.Add("1", " ");

            //脐
            ldNavel.Add("0", "√");
            ldNavel.Add("1", " ");

            //臀
            ldShower.Add("0", "√");
            ldShower.Add("1", " ");

            //淋浴
            ldSpongeBath.Add("0", "√");
            ldSpongeBath.Add("1", " ");

            //擦浴
            ldButtocks.Add("0", "√");
            ldButtocks.Add("1", " ");

            //体位
            ldPosition.Add("0", "左");
            ldPosition.Add("1", "右");
            ldPosition.Add("2", "平");
            ldPosition.Add("3", "俯");
            ldPosition.Add("4", " ");

            //皮肤
            ldSkin.Add("0", "完整");
            ldSkin.Add("1", "破损");
            ldSkin.Add("3", "正常");
            ldSkin.Add("4", "稍黄");
            ldSkin.Add("5", "黄染");
            ldSkin.Add("6", "红润");
            ldSkin.Add("7", "苍白");
            ldSkin.Add("2", " ");

            //吸吮
            ldSuck.Add("0", "协调");
            ldSuck.Add("1", "不协调");
            ldSuck.Add("2", "存在");
            ldSuck.Add("3", "可");

            //肢端
            ldAcra.Add("0", "温");
            ldAcra.Add("1", "凉");
            ldAcra.Add("2", " ");

            //自主活动
            ldAutoActive.Add("0", "有");
            ldAutoActive.Add("1", "无");
            ldAutoActive.Add("2", " ");

            //哭声
            ldCry.Add("0", "响亮");
            ldCry.Add("1", "稍弱");
            ldCry.Add("2", "嘶哑");
            ldCry.Add("4", "无");
            ldCry.Add("3", " ");
        }

        /// <summary>
        /// 绑定表格数据
        /// </summary>
        private void bindColData()
        {
            try
            {
                flgView.Cols[19].DataMap = ldDuckItem;//管道
                flgView.Cols[20].DataMap = ldEye;//眼
                flgView.Cols[21].DataMap = ldMouth;//口
                flgView.Cols[22].DataMap = ldNavel;//脐
                flgView.Cols[23].DataMap = ldButtocks;//臀
                flgView.Cols[24].DataMap = ldShower;//淋浴
                flgView.Cols[25].DataMap = ldSpongeBath;//擦浴
                flgView.Cols[26].DataMap = ldPosition;//体位
                flgView.Cols[27].DataMap = ldSkin;//皮肤
                flgView.Cols[28].DataMap = ldCry;//哭声
                flgView.Cols[29].DataMap = ldSuck;//吸吮
                flgView.Cols[30].DataMap = ldAutoActive;//自主活动
                flgView.Cols[31].DataMap = ldAcra;//肢端
            }
            catch
            { }
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
                diagnose = App.ReadSqlVal("select diagnose_name from T_NURSE_RECORD where RECORD_TYPE='B' and Patient_Id =" + currentPatient.Id, 0, "diagnose_name");//自己修改的护理
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
            frmNursePrint_Records ff = new frmNursePrint_Records(ReSetPrintDataSet(ds),diagnose, currentPatient, strType);
            ff.Show();
        }

        public DataSet GetNusersRecords()
        {
            DataSet ds = null;
            GetDatas(true);
            SumInOrOutRecordSets();
            Class_Nurse_Record_NewBorn[] cNurse = new Class_Nurse_Record_NewBorn[nurses.Count];
            for (int i = 0; i < nurses.Count; i++)
            {
                cNurse[i] = new Class_Nurse_Record_NewBorn();
                cNurse[i] = nurses[i] as Class_Nurse_Record_NewBorn;
                //    //if (cNurse[i].In_item_name == null)
                //    //{
                //    //    cNurse[i].In_item_name = "";
                //    //}
                //    //代码转换成类型名称
                //    //if (cNurse[i].Consciousness != null)
                //    //    cNurse[i].Consciousness = ldConsciousness[cNurse[i].Consciousness].ToString();

            }
            ds = App.ObjectArrayToDataSet(cNurse);
            return ds;
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

        #region 表格相关操作
        private void flgView_CellChanged(object sender, RowColEventArgs e)
        {
            flgView.AutoSizeCol(e.Col);
        }
        private void flgView_StartEdit(object sender, RowColEventArgs e)
        {
            //签名列不允许编辑
            if (e.Col == 33)
            {
                e.Cancel = true;
                return;
            }
            if (flgView[e.Row, 0] == null || flgView[e.Row, 0].ToString() == "")
            {
                if (e.Col == 8)
                {
                    string measureTime = GetTime(e.Row);
                    //验证权限
                    DateTime objDataTime;
                    if (measureTime != "" && DateTime.TryParse(measureTime, out objDataTime))//时间为空说明是添加数据，不用验证权限
                    {
                        string operateId = App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and patient_id=" + currentPatient.Id, 0, "creat_id");
                        if (!ValidateUser(operateId))//App.UserAccount.UserInfo.User_id != operateId && !App.UserAccount.CurrentSelectRole.Role_name.Equals("护士长"))
                        {
                            App.Msg("权限不足！");
                            e.Cancel = true;
                            return;
                        }
                    }
                    else
                    {
                        FrmSetDatetime fsd = new FrmSetDatetime(dtpDate.Value, currentPatient.Id.ToString(),"B");
                        fsd.ShowDialog();
                        if (fsd.flag)
                            flgView[e.Row, 0] = fsd.Date.ToString("yyyy-MM-dd HH:mm");
                        //flgView.Col = 1;
                        e.Cancel = true;
                        return;
                    }
                }
                else if (e.Col == 9 || e.Col == 10)
                {
                    if (flgView[e.Row, 8] == null || flgView[e.Row, 8].ToString() == "")
                    {
                        App.Msg("请先输入药物名称！");
                        flgView.Col = 8;
                        return;
                    }
                }
                else
                {
                    if (flgView[e.Row, 8] != null && flgView[e.Row, 8].ToString().Length > 0)
                    {
                        e.Cancel = true;
                        return;
                    }
                    //App.Msg("请选择测量时间！");
                    FrmSetDatetime fsd = new FrmSetDatetime(dtpDate.Value, currentPatient.Id.ToString(), "B");
                    fsd.ShowDialog();
                    if (fsd.flag)
                        flgView[e.Row, 0] = fsd.Date.ToString("yyyy-MM-dd HH:mm");
                    //flgView.Col = 1;
                    e.Cancel = true;
                    return;
                }
            }
            else
            {
                //if (flgView.Col == 32)
                //{
                //    //this.提取备注模板ToolStripMenuItem_Click(sender, e);
                //    //return;
                //}
                if (flgView[e.Row, 8] != null && (flgView[e.Row, 8].ToString().Contains("总结") || flgView[e.Row, 8].ToString().Contains("小结")))
                {
                    int id = 0;
                    if (flgView[e.Row, 34] != null && flgView[e.Row, 34].ToString().Length > 0)
                    {
                        try
                        {
                            id = int.Parse(flgView[e.Row, 34].ToString());
                        }
                        catch { }
                    }
                    if (id == 0)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
                else
                {
                    DateTime dt = Convert.ToDateTime(flgView[e.Row, 0].ToString());
                    string operateId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + dt.ToString("yyyy-MM-dd HH:mm") + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and  patient_id=" + currentPatient.Id + " and rownum=1 order by id", 0, "creat_id"));
                    if (ValidateUser(operateId) || operateId == null)//operateId == null || App.UserAccount.UserInfo.User_id == operateId || App.UserAccount.CurrentSelectRole.Role_name.Equals("护士长"))
                    {
                        if (e.Col == 0)
                        {
                            FrmSetDatetime fsd = new FrmSetDatetime(dt, currentPatient.Id.ToString(), "B");
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
                                    dt.ToString("yyyy-MM-dd HH:mm") + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and patient_id=" + currentPatient.Id.ToString() + "";

                                if (App.ExecuteSQL(sql) == 0 && operateId != null)
                                {
                                    App.MsgErr("修改时间没有修改成功！");
                                }
                            }
                        }
                        if (e.Col == 9 || e.Col == 10)
                        {
                            if (flgView[e.Row, 8] == null || flgView[e.Row, 8].ToString() == "")
                            {
                                App.Msg("请先输入药物名称！");
                                flgView.Col = 8;
                                return;
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
        }
        #endregion

        private void flgView_KeyPressEdit(object sender, KeyPressEditEventArgs e)
        {
            try
            {
                if (e.Col == 0 )//|| e.Col == 32)//时间日期,备注禁止手动输入
                {
                    e.Handled = true;
                }
                if (e.Col == 1|| e.Col == 9 || e.Col == 11 || e.Col == 12 || e.Col == 13)
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
                    {
                        if (e.Col == 9 && e.KeyChar == '-')
                        {
                            e.Handled = false;
                        }
                        else
                            e.Handled = true;
                    }
                }
                if (e.Col == 2 || e.Col == 4 || e.Col == 5 || e.Col == 7)
                {
                    if (!Char.IsNumber(e.KeyChar) && e.KeyChar != '\b')
                    {
                        e.Handled = true;
                    }
                }
                //if (e.Col == 14 || e.Col == 16)//大小便允许输入g、次、数值
                //{

                //}
                if (e.Col == 6)//血压
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
            oldInAmountName = "";
            try
            {
                if ((e.Col == 8||e.Col==9||e.Col==10) && flgView[e.Row, 8] != null && flgView[e.Row, 8].ToString() != "")//药物名称列
                {
                    //保存修改前的药物名称
                    if (flgView[e.Row, 8] != null)
                    {
                        oldInAmountName = flgView[e.Row, 8].ToString();
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
            //oldDuct_name = "";
            ShowData();
            SumInOrOutRecordSet(true);
            ShowSumDataGrid();
            flgView.Cols[2].Width = 30;
            flgView.Cols[32].Width = 100;
            flgView.Cols[27].Width = 35;
            flgView.Cols[28].Width = 35;
            //flgView.AutoSizeCols();
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
            if (flgView[e.Row, e.Col] != null && flgView[e.Row, e.Col].ToString() != "")
            {
                string measureTime = GetTime(e.Row);
                string itemCode = "";
                string itemValue = "";
                string itemName = "";
                string otherName = "";
                int id = 0;
                if (e.Col > 18 && e.Col < 32)
                {
                    ListDictionary ldCommon = GetDictionaryByColIndex(e.Col);
                    itemValue = ldCommon[flgView[e.Row, e.Col].ToString()].ToString();
                    itemCode = flgView[e.Row, e.Col].ToString();
                    itemName = dictColumnName[e.Col];
                }
                else if (e.Col > 7 && e.Col < 11)//药物
                {
                    //药物名称
                    otherName = flgView[e.Row, 8] == null ? "" : flgView[e.Row, 8].ToString();
                    //药物量
                    itemValue = flgView[e.Row, 9] == null ? "" : flgView[e.Row, 9].ToString();
                    //药物速度
                    itemCode = flgView[e.Row, 10] == null ? "" : flgView[e.Row, 10].ToString();
                    itemName = "药物";
                    if (flgView[e.Row, 34] != null&&flgView[e.Row,34].ToString().Length>0)
                    {
                        try
                        {
                            id = int.Parse(flgView[e.Row, 34].ToString());
                        }
                        catch { }
                    }
                    //if (e.Col == 8)
                    //{
                    //    string s = App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='" + itemName + "' and other_name='" + otherName + "' and record_type='" + strType + "' and patient_id=" + currentPatient.Id, 0, "count(*)");
                    //    if (s != "0" && oldInAmountName != otherName)
                    //    {
                    //        App.Msg("药物名称重复!");
                    //        this.flgView[e.Row, e.Col] = oldInAmountName;
                    //        this.flgView.Col = e.Col;
                    //        return;
                    //    }
                    //}
                }
                else if (e.Col == 14 || e.Col == 15)//小便
                {
                    //量或次
                    itemValue = flgView[e.Row, 14] == null ? "" : flgView[e.Row, 14].ToString();
                    //色
                    itemCode = flgView[e.Row, 15] == null ? "" : flgView[e.Row, 15].ToString();
                    itemName = "小便";
                }
                else if (e.Col == 16 || e.Col == 17)//大便
                {
                    //量或次
                    itemValue = flgView[e.Row, 16] == null ? "" : flgView[e.Row, 16].ToString();
                    //性状
                    itemCode = flgView[e.Row, 17] == null ? "" : flgView[e.Row, 17].ToString();
                    itemName = "大便";
                }

                else
                {
                    itemValue = flgView[e.Row, e.Col].ToString();
                    if (e.Col == 33)//备注，验证字符长度
                    {
                        int length = getStringLength(itemValue);
                        if (length > 1000)
                        {
                            App.Msg("您输入的内容超过1000字节了!");
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
                if (e.Col < 8 || e.Col > 10)
                {
                    itemCount = Convert.ToInt32(App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='" + itemName + "' and record_type='" + strType + "' and patient_id=" + currentPatient.Id, 0, "count(*)"));
                }
                else //入量验证条件增加othername
                {
                    if (id == 0)
                    {
                        itemCount = 0;
                    }
                    else
                    {
                        itemCount = 1;
                    }
                    //string strName = string.IsNullOrEmpty(oldInAmountName) ? otherName : oldInAmountName;
                    //itemCount = Convert.ToInt32(App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='" + itemName + "' and other_name='" + strName + "'  and record_type='" + strType + "' and patient_id=" + currentPatient.Id, 0, "count(*)"));
                }
                string sql = "";
                if (itemCount == 0)
                {
                    if (otherName == "")
                    {
                        sql = "insert into t_nurse_record" +
                                     "( bed_no, pid, measure_time, item_code, item_value, creat_id, create_time, patient_id, item_show_name,RECORD_TYPE)values" +
                                     "( '" + currentPatient.Sick_Bed_Name + "', '" + currentPatient.PId + "', to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9'), '" +
                                     itemCode + "', '" + itemValue + "', '" + userId + "', sysdate, " + currentPatient.Id + ", '" + itemName + "','" + strType + "')";
                    }
                    else
                    {
                        sql = "insert into t_nurse_record" +
                                     "( bed_no, pid, measure_time, item_code, item_value, creat_id, create_time, patient_id, item_show_name,other_name,RECORD_TYPE)values" +
                                     "( '" + currentPatient.Sick_Bed_Name + "', '" + currentPatient.PId + "', to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9'), '" +
                                     itemCode + "', '" + itemValue + "', '" + userId + "', sysdate, " + currentPatient.Id + ", '" + itemName + "','" + otherName + "','" + strType + "')";
                    }
                }
                else
                {

                    //string operateId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and patient_id=" + currentPatient.Id + " and rownum=1 order by id", 0, "creat_id"));
                    //if (App.UserAccount.UserInfo.User_id != operateId && !App.UserAccount.CurrentSelectRole.Role_name.Equals("护士长"))
                    //{
                    //    App.Msg("修改权限不足!");
                    //    btnSearch_Click(sender, e);
                    //    return;
                    //}
                    if (!ValidateUser(userId))
                    {
                        App.Msg("修改权限不足!");
                        btnSearch_Click(sender, e);
                        return;
                    }
                    if (otherName == "")
                    {
                        sql = "update t_nurse_record set item_code='" + itemCode + "',item_value='" + itemValue + "',update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate";
                        sql += " where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='" + itemName + "' and record_type='" + strType + "' and patient_id=" + currentPatient.Id;
                    }
                    else
                    {
                        sql = "update t_nurse_record set item_code='" + itemCode + "',item_value='" + itemValue + "',other_name='" + otherName + "',update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate";
                        //sql += " where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='" + itemName + "'";
                        //if (string.IsNullOrEmpty(oldInAmountName))
                        //{
                        //    sql += " and other_name='" + otherName + "'";
                        //}
                        //else
                        //{
                        //    sql += " and other_name='" + oldInAmountName + "'";
                        //}
                        //sql += " and record_type='" + strType + "' and patient_id=" + currentPatient.Id;

                        //int id = int.Parse(flgView[e.Row, 35].ToString());
                        sql += " where id=" + id;
                    }

                }
                int num = App.ExecuteSQL(sql);
                if (num > 0)
                {
                    timer1.Start();
                    operateFlag = true;
                    //插入签名
                    if (flgView[e.Row, 0] != null && flgView[e.Row, 0].ToString() != "" && flgView[e.Row, 34] == null && sql.Contains("insert"))
                    {
                        flgView[e.Row, 33] = App.UserAccount.UserInfo.User_name;
                    }
                    if (otherName.Length > 0 && id == 0&&sql.ToLower().Contains("insert"))
                    {
                        btnSearch_Click(sender, e);
                    }
                    //App.Msg("操作成功！");
                    //App.ExecuteSQL("update t_nurse_record set creat_id='" + App.UserAccount.UserInfo.User_id + "',create_time=sysdate, update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and patient_id=" + currentPatient.Id);
                    //
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
            switch (col)
            {
                case 19:
                    return ldDuckItem;
                case 20:
                    return ldEye;
                case 21:
                    return ldMouth;
                case 22:
                    return ldNavel;
                case 23:
                    return ldButtocks;
                case 24:
                    return ldShower;
                case 25:
                    return ldSpongeBath;
                case 26:
                    return ldPosition;
                case 27:
                    return ldSkin;
                case 28:
                    return ldCry;
                case 29:
                    return ldSuck;
                case 30:
                    return ldAutoActive;
                case 31:
                    return ldAcra;
                default:
                    return null;
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            //lblDatePriview.Text = dtpDate.Value.AddDays(-1).ToShortDateString() + "<<";
            //lblDateNext.Text = ">>" + dtpDate.Value.AddDays(1).ToShortDateString();
            
            cboTiming_SelectedIndexChanged(sender, e);
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
            string sum_id = SumInOrOut();
            if (cboTiming.Text.Contains("小结"))
            {
                FrmSumItem sum_item = new FrmSumItem(sum_id, "B");
                sum_item.ShowDialog();
                if (!sum_item.successflag)
                {//没有操作成功,清除这条统计记录
                    string del = "delete from t_nurse_dangery_inout_sum_h where id=" + sum_id + " and record_type='" + strType + "' and patient_id=" + currentPatient.Id;
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
            Class_Nurse_Record_NewBorn[] Nusers_objs = new Class_Nurse_Record_NewBorn[nurses.Count];
            for (int i = 0; i < nurses.Count; i++)
            {
                Nusers_objs[i] = new Class_Nurse_Record_NewBorn();
                Nusers_objs[i] = (Class_Nurse_Record_NewBorn)nurses[i];
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
                    flgView[i + 3, 34] = Nusers_objs[i].Number;
                }
            }
            //单元格合并和设置
            CellUnit();
            this.flgView.AutoSizeCols();
            this.flgView.AutoSizeRows();
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
        }
        private void dtpBeginTime_ValueChanged(object sender, EventArgs e)
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
        /// 重置计算出入量汇总
        /// </summary>
        private void SumInOrOutRecordSet(bool IsToDay)
        {
            SumNusersRecords.Clear();
            string date = dtpDate.Value.ToString("yyyy-MM-dd");
            string sql_date = "select * from t_nurse_dangery_inout_sum_h where patient_Id=" + currentPatient.Id;
            if(IsToDay)
            {
                sql_date+= " and  to_char(end_time,'yyyy-MM-dd')='" + date + "'";
            }
            sql_date += " and record_type='" + strType + "'";
            sql_date += " order by end_time";
            DataSet ds_sum_oper = App.GetDataSet(sql_date);

            for (int i = 0; i < ds_sum_oper.Tables[0].Rows.Count; i++)
            {
                //SumNusersRecords.Add(Convert.ToDateTime(ds_sum_oper.Tables[0].Rows[i]["start_time"]).ToString("yyyy-MM-dd HH:mm") + "," + Convert.ToDateTime(ds_sum_oper.Tables[0].Rows[i]["end_time"]).ToString("yyyy-MM-dd HH:mm") + "," + ds_sum_oper.Tables[0].Rows[i]["oper_method"].ToString().Replace("小时出入量", "h总结") + "," + ds_sum_oper.Tables[0].Rows[i]["ID"].ToString() + "," + ds_sum_oper.Tables[0].Rows[i]["seq_id"] + "," + ds_sum_oper.Tables[0].Rows[i]["SIGNATURE"] + "," + ds_sum_oper.Tables[0].Rows[i]["SUM_ITEM"]);

                SumNusersRecords.Add(Convert.ToDateTime(ds_sum_oper.Tables[0].Rows[i]["start_time"]).ToString("yyyy-MM-dd HH:mm") + "," + Convert.ToDateTime(ds_sum_oper.Tables[0].Rows[i]["end_time"]).ToString("yyyy-MM-dd HH:mm") + "," + ds_sum_oper.Tables[0].Rows[i]["oper_method"].ToString().Replace("小时出入量", "h总结") + ",0," + ds_sum_oper.Tables[0].Rows[i]["seq_id"] + "," + ds_sum_oper.Tables[0].Rows[i]["SIGNATURE"] + "," + ds_sum_oper.Tables[0].Rows[i]["SUM_ITEM"]);
            }

            for (int i1 = 0; i1 < SumNusersRecords.Count; i1++)
            {
                string BeginTime, EndTime, Item_name;
                string Number = "";//号码
                string seq_id = "";//统计类型ID
                string singsure = ""; //签名
                double dinsum = 0;//入量
                double dmedicine = 0;//药物
                double dbreastmilk = 0;//母乳
                double dwater = 0;//水
                double dformula = 0;//配方奶
                double doutsum = 0;//出量
                double durine = 0;//小便
                double dshit = 0;//大便
                double dpuke = 0;//呕吐

                BeginTime = SumNusersRecords[i1].ToString().Split(',')[0];
                EndTime = SumNusersRecords[i1].ToString().Split(',')[1];
                Item_name = SumNusersRecords[i1].ToString().Split(',')[2];
                Number = SumNusersRecords[i1].ToString().Split(',')[3];
                seq_id = SumNusersRecords[i1].ToString().Split(',')[4];
                //creatID = SumNusersRecords[i1].ToString().Split(',')[4];+ "," + ds_sum_oper.Tables[0].Rows[i]["CREAT_ID"].ToString()
                singsure = SumNusersRecords[i1].ToString().Split(',')[5];
                string[] sum_item = SumNusersRecords[i1].ToString().Split(',')[6].Split('|');
                SumNusers.Clear();

                Class_Nurse_Record_NewBorn sumtemp = new Class_Nurse_Record_NewBorn ();

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

                StringBuilder sbSum = new StringBuilder("select item_show_name as ItemName,a.item_value as ItemValue,a.other_name as ItemCode from t_nurse_record a");
                sbSum.Append(" where 1=1");
                sbSum.Append(" and MEASURE_TIME" + beginSgin + "to_timestamp('" + BeginTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME");
                sbSum.Append(" " + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id);
                sbSum.Append(" and record_type='" + strType + "'");
                sbSum.Append(" and item_show_name in('药物','母乳','水','配方奶','小便','大便','呕吐物')");
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
                        string strTempValue = drSum["ItemValue"].ToString();
                        string strTempCode = drSum["ItemCode"].ToString();
                        if (Double.TryParse(strTempValue, out dtmp))
                        {
                            switch (strTempName)
                            {
                                case "药物":
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
                                    dmedicine += dtmp;
                                    break;
                                case "母乳":
                                    dbreastmilk += dtmp;
                                    break;
                                case "水":
                                    dwater += dtmp;
                                    break;
                                case "配方奶":
                                    dformula += dtmp;
                                    break;
                                case "大便":
                                    dshit += dtmp;
                                    break;
                                case "小便":
                                    durine += dtmp;
                                    break;
                                case "呕吐物":
                                    dpuke += dtmp;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
                dinsum = dmedicine + dbreastmilk + dwater + dformula;
                doutsum = durine + dshit + dpuke;
                sumtemp.DateTime = Convert.ToDateTime(EndTime).ToString("yyyy-MM-dd HH:mm");
                sumtemp.MedicineName = Item_name;
                sumtemp.Number = Number;
                //统计值为0的均不显示
                if (Item_name.Contains("总结"))
                {
                    if (dinsum > 0)
                    {
                        sumtemp.MedicineValue = dinsum.ToString();
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
                            case "药物":
                                if (dmedicine > 0)
                                {
                                    sumtemp.MedicineValue = dmedicine.ToString();
                                }
                                break;
                            case "母乳":
                                if (dbreastmilk > 0)
                                {
                                    sumtemp.BreastMilk = dbreastmilk.ToString();
                                }
                                break;
                            case "水":
                                if (dwater > 0)
                                {
                                    sumtemp.Water = dwater.ToString();
                                }
                                break;
                            case "配方奶":
                                if (dformula > 0)
                                {
                                    sumtemp.Formula = dformula.ToString();
                                }
                                break;
                            case "大便":
                                if (dshit > 0)
                                {
                                    sumtemp.Shit = dshit.ToString();
                                }
                                break;
                            case "小便":
                                if (durine > 0)
                                {
                                    sumtemp.Urine = durine.ToString();
                                }
                                break;
                            case "呕吐":
                                if (dpuke > 0)
                                {
                                    sumtemp.Puke = dpuke.ToString();
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
                    Class_Nurse_Record_NewBorn temp_nuser = (Class_Nurse_Record_NewBorn)SumNusers[i];
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
        #endregion

        private void 添加空行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flgView.Rows.Insert(flgView.RowSel);
        }  

        /// <summary>
        /// 删除行或者删除项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void Delete()
        {
            int rowindex = flgView.Row;
            int colindex = flgView.Col;
            string measureTime = GetTime(rowindex);
            object obj = flgView[rowindex, colindex];
            object obj2 = flgView[rowindex, 8];
            if (obj != null && obj.ToString().Trim().Length > 0)
            {
                string sql = "";
                int id = 0;
                if (flgView[rowindex, 34] != null && flgView[rowindex, 34].ToString().Length > 0)
                {
                    try
                    {
                        id = int.Parse(flgView[rowindex, 34].ToString());
                    }
                    catch { }
                }
                if (colindex == 0&&(obj2==null||(obj2!=null&&!obj2.ToString().Contains("小结")&&!obj2.ToString().Contains("总结"))))
                {
                    string operateId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and patient_id=" + currentPatient.Id + " and rownum=1 order by id", 0, "creat_id"));
                    //只有创建者本人或者护士长权限的才能删除记录
                    if (App.UserAccount.UserInfo.User_id == operateId || operateId == null || operateId == ""||App.UserAccount.CurrentSelectRole.Role_name.Equals("护士长"))
                    {
                        sql = "delete from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and patient_id=" + currentPatient.Id;
                    }
                    else
                    {
                        App.Msg("权限不足！");
                        return;
                    }
                }
                else if (id == 0 && obj2 != null && (flgView[rowindex, 8].ToString().Contains("小结") || flgView[rowindex, 8].ToString().Contains("总结")))
                {
                    string signature = App.ReadSqlVal("select signature from t_nurse_dangery_inout_sum_h where oper_method='" + flgView[flgView.Row, 8].ToString() + "' and end_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and patient_id=" + currentPatient.Id, 0, "signature");
                    if (App.UserAccount.UserInfo.User_name == signature || signature == null || signature == "" || App.UserAccount.CurrentSelectRole.Role_name.Equals("护士长"))
                    {
                        sql = "delete from t_nurse_dangery_inout_sum_h where oper_method='" + flgView[flgView.Row, 8].ToString() + "' and end_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and patient_id=" + currentPatient.Id;
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
                    string itemName = dictColumnName[flgView.Col];
                    if (itemName.Contains("药物"))
                    {
                        if (flgView[flgView.Row, 34] != null && flgView[flgView.Row, 34].ToString().Length > 0)
                        {
                            try
                            {
                                id = int.Parse(flgView[flgView.Row, 34].ToString());
                            }
                            catch { }
                        }
                    }
                    if (id == 0)
                    {
                        string operateId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and patient_id=" + currentPatient.Id + " and rownum=1 order by id", 0, "creat_id"));
                        //只有创建者本人或者护士长权限的才能删除记录
                        if (App.UserAccount.UserInfo.User_id != operateId && !App.UserAccount.CurrentSelectRole.Role_name.Equals("护士长"))
                        {
                            App.Msg("权限不足！");
                            return;
                        }
                    }
                    else
                    {
                        string operateId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where id=" + id + " order by id", 0, "creat_id"));
                        //只有创建者本人或者护士长权限的才能删除记录
                        if (App.UserAccount.UserInfo.User_id != operateId && !App.UserAccount.CurrentSelectRole.Role_name.Equals("护士长"))
                        {
                            App.Msg("权限不足！");
                            return;
                        }
                    }
                    if (colindex == 8)//删除药物名称
                    {
                        if (id > 0)
                        {
                            sql = "delete from t_nurse_record where id=" + id;
                        }
                        else
                        {
                            sql = "delete from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and patient_id=" + currentPatient.Id;
                            sql += " and item_show_name='药物' and other_name='" + obj.ToString() + "'";
                        }
                    }
                    else if (colindex == 9 || colindex == 10)//删除药物量、速度
                    {
                        sql = "update t_nurse_record set ";
                        if (colindex == 9)
                        {
                            sql += " item_value=null ";
                        }
                        else
                        {
                            sql += " item_code=null ";
                        }
                        if (id > 0)
                        {
                            sql += " where id=" + id;
                        }
                        else
                        {
                            sql += " where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and patient_id=" + currentPatient.Id;
                            sql += " and item_show_name='药物' and other_name='" + obj2.ToString() + "'";
                        }
                    }
                    else//删除其他项
                    {
                        sql = "delete from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and record_type='" + strType + "' and patient_id=" + currentPatient.Id;
                        sql += " and item_show_name='" + dictColumnName[colindex] + "'";
                    }
                }
                int num = 0;
                try
                {
                    num = App.ExecuteSQL(sql);
                }
                catch
                {

                }
                if (num > 0)
                {
                    btnSearch_Click(this, new EventArgs());
                }
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
            ArrayList DataRows = new ArrayList();
            int maxcount = 0;
            string sql_time = "select distinct to_char(t.measure_time,'yyyy-mm-dd hh24:mi') as DATETIMEVAL from T_NURSE_RECORD t where t.patient_Id=" + currentPatient.Id + " and record_type='" + strType + "' order by DATETIMEVAL asc";
            DataSet ds_Time = App.GetDataSet(sql_time);
            if (ds_Time != null)
            {
                for (int i = 0; i < ds_Time.Tables[0].Rows.Count; i++)
                {
                    ArrayList drDatarows = new ArrayList();
                    for (int i1 = 0; i1 < ds.Tables[0].Rows.Count; i1++)
                    {
                        if (!ds.Tables[0].Rows[i1]["medicineName"].ToString().Contains("小结") &&
                           !ds.Tables[0].Rows[i1]["medicineName"].ToString().Contains("出入量") &&
                           !ds.Tables[0].Rows[i1]["medicineName"].ToString().Contains("总结"))
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
                        int rownurseresult = 32;//打印时备注显示的字符个数
                        List<string> nurseresultlist = new List<string>();

                        string signature = "";
                        maxcount = drArray.Length;
                        if (drArray[0]["nurseResult"] != null && drArray[0]["nurseResult"].ToString().Length > 0)
                        {
                            GetRowNurseResult(drArray[0]["nurseResult"].ToString(), rownurseresult, ref nurseresultlist);
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
                                    drArray[j]["nurseResult"] = nurseresultlist[j];
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
                                        dr["nurseResult"] = nurseresultlist[j];
                                    }
                                    DataRows.Add(dr);
                                }
                                else
                                {
                                    DataRow dr = ds.Tables[0].NewRow();
                                    dr["Signature"] = "";
                                    if (j <= nurseresultlist.Count - 1)
                                    {
                                        dr["nurseResult"] = nurseresultlist[j];
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

            DataRow[] drSum = ds.Tables[0].Select("medicineName like '%出入量%' or medicineName like '%小结%' or medicineName like '%总结%'");
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
            //每一页显示的数据行数
            int pageRows = 25;
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
                if (!dd.Rows[i]["medicineName"].ToString().Contains("小结") &&
                    !dd.Rows[i]["medicineName"].ToString().Contains("总结") &&
                    !dd.Rows[i]["medicineName"].ToString().Contains("出入量"))
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
                            //dd.Rows[i]["datetime"] = currDate.ToString("yyyy-MM-dd HH:mm");
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
                        dd.Rows[i]["datetime"] = currDate.ToString("yyyy-MM-dd HH:mm");
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
                GetRowNurseResult(strNurseResult, rowlenth, ref list);
            }
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
                if (strlength < 61 || (strlength == 61 && System.Text.Encoding.Default.GetBytes(remark[j].ToString()).Length != 2))
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
                    if (temprow.Table.Columns[i].ColumnName.ToLower() != "number")//number
                    {
                        string tempperval = "";

                        tempperval = perval + olddatarow[i].ToString()[j];


                        SizeF sizeF = graphics.MeasureString(tempperval, new Font("宋体", 8));
                        if (sizeF.Width <= widthindex * 28.3465)
                        {
                            perval = tempperval;
                            if (j == olddatarow[i].ToString().Length - 1)
                            {
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
                if (flgView.Col == 32)
                {
                    // measure text height
                    StringFormat sf = new StringFormat();
                    int wid = flgView.Cols[32].WidthDisplay;
                    string text = flgView.Editor.Text;
                    SizeF sz = g.MeasureString(text, flgView.Font, wid, sf);
                    // adjust row height if necessary
                    C1.Win.C1FlexGrid.Row row = flgView.Rows[flgView.Row];
                    if (sz.Height + 4 > row.HeightDisplay)
                        row.HeightDisplay = (int)sz.Height + 4;
                }
            }
        }

        private void UcNurse_Record_NewBorn_Load(object sender, EventArgs e)
        {
            lblDatePriview.Text = App.GetSystemTime().AddDays(-1).ToShortDateString() + "<<";
            lblDateNext.Text = ">>" + App.GetSystemTime().AddDays(1).ToShortDateString();
            SetDictionaryForItem();
            cboTiming_SelectedIndexChanged(sender, e);
            btnSearch_Click(sender, e);
            bindColData();
            ShowMsg();
            //flgView.Cols.Count = 34;
            //CellUnit();
            //flgView.AutoSizeCols();
            //flgView.AutoSizeRows();
            //flgView.Rows.Fixed = 3;
        }

        /// <summary>
        /// 获取护理数据
        /// </summary>
        /// <param name="IsAllData"></param>
        private void GetDatas(bool IsAllData)
        {
            nurses.Clear();
            try
            {
                #region 数据加载
                string dateTime = dtpDate.Value.ToString("yyyy-MM-dd HH:mm");

                string sql_time = "select distinct to_char(t.measure_time,'yyyy-mm-dd hh24:mi') as DATETIMEVAL from T_NURSE_RECORD t where record_type='" + strType + "' and t.patient_Id=" + currentPatient.Id;
                if (!IsAllData)
                {
                    sql_time = sql_time + " and to_char(t.measure_time,'yyyy-MM-dd')='" + dtpDate.Value.ToString("yyyy-MM-dd") + "'";
                }
                sql_time += " order by DATETIMEVAL asc";
                string sql_set = "select to_char(t.measure_time,'yyyy-mm-dd hh24:mi') as DATETIMEVAL,t.id,t.item_code,a.item_name,t.item_show_name,a.item_attribute,t.item_value,t.other_name,a.item_type,t.status_measure,t.creat_id,d.user_name,t.diagnose_name,PATIENT_ID from T_NURSE_RECORD t " +
                                " left join t_nurse_record_dict a on  to_char(a.id)=t.item_code left join T_DATA_CODE b on a.item_attribute=b.id inner " +
                                " join T_ACCOUNT_USER c on t.creat_id=c.user_id inner join T_USERINFO d on d.user_id=c.user_id where  patient_Id=" + currentPatient.Id + " and record_type='" + strType + "' order by t.create_time asc ";
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

                        //药物
                        DataRow[] dr_InAmount = dt_sets.Select("item_show_name='药物' and DATETIMEVAL='" + dateTimeValue + "'", "id asc");
                        int index = dr_InAmount.Length;
                        if (index == 0)
                            index = 1;
                        for (int j = 0; j < index; j++)
                        {
                            Class_Nurse_Record_NewBorn temp = new Class_Nurse_Record_NewBorn();
                            temp.DateTime = dateTimeValue;
                            //药物
                            if (dr_InAmount.Length > 0 && j < dr_InAmount.Length)
                            {
                                temp.MedicineName = dr_InAmount[j]["other_name"].ToString();
                                temp.MedicineValue = dr_InAmount[j]["item_value"].ToString();
                                temp.V = dr_InAmount[j]["item_code"].ToString();
                                temp.Number = dr_InAmount[j]["id"].ToString();
                            }
                            for (int k = 0; k < dr_Values.Length; k++)
                            {
                                if (j == 0)//非入量的药物项目只在当前时间段的第一行显示
                                {
                                    if (dr_Values[k]["item_show_name"].ToString() == "箱温")
                                    {
                                        temp.BoxT = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "湿度")
                                    {
                                        temp.Humidity = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "体温")
                                    {
                                        temp.T = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "心率")
                                    {
                                        temp.HR = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "呼吸")
                                    {
                                        temp.R = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "血压")
                                    {
                                        temp.Bp = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "血氧饱和度")
                                    {
                                        temp.Oxygen_saturation = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "母乳")
                                    {
                                        temp.BreastMilk = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "水")
                                    {
                                        temp.Water = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "配方奶")
                                    {
                                        temp.Formula = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "小便")
                                    {
                                        temp.Urine = dr_Values[k]["item_value"].ToString();
                                        temp.UColor = dr_Values[k]["item_code"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "大便")
                                    {
                                        temp.Shit = dr_Values[k]["item_value"].ToString();
                                        temp.Characteristics = dr_Values[k]["item_code"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "呕吐物")
                                    {
                                        temp.Puke = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "管道")
                                    {
                                        temp.DuctItem = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "眼")
                                    {
                                        temp.Eye = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "口")
                                    {
                                        temp.Mouth = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "脐")
                                    {
                                        temp.Navel = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "臀")
                                    {
                                        temp.Buttocks = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "淋浴")
                                    {
                                        temp.Shower = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "擦浴")
                                    {
                                        temp.SpongeBath = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "体位")
                                    {
                                        temp.Position = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "皮肤")
                                    {
                                        temp.Skin = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "哭声")
                                    {
                                        temp.Cry = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "吸吮")
                                    {
                                        temp.Suck = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "自主活动")
                                    {
                                        temp.Autoactive = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "肢端")
                                    {
                                        temp.Acra = dr_Values[k]["item_value"].ToString();
                                    }
                                    else if (dr_Values[k]["item_show_name"].ToString() == "护理措施")
                                    {
                                        temp.NurseResult = dr_Values[k]["item_value"].ToString();
                                    }
                                }
                                if (j == index - 1)
                                {
                                    temp.Signature = dr_Values[0]["user_name"].ToString();
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
                App.MsgErr("数据加载错误!问题:" + ex.Message);
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

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (flgView.Col == 32)
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

        private int PageRowCount = 25;
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
                    lmsg2.Text = "满页记录时间为：" + dtime.ToString("yyyy-MM-dd HH:mm");
                }
                else
                {
                    lmsg2.Text = "无满页信息";
                }

            }
            #endregion

            #region 病危病重提示
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

        private void flgView_DoubleClick(object sender, EventArgs e)
        {
            
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
                diagnose = App.ReadSqlVal("select diagnose_name from T_NURSE_RECORD where Patient_Id =" + currentPatient.Id + " and record_type='" + strType + "'", 0, "diagnose_name");//自己修改的护理
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

        private void txtDiagnose_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelX1_Click(object sender, EventArgs e)
        {

        }
    }
}
