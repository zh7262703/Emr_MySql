using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Collections;
using Bifrost;
using Base_Function.MODEL;
using C1.Win.C1FlexGrid;
using Base_Function.BLL_NURSE.Nurse_Record.NurseItmeControls;
using Base_Function.BLL_NURSE.Nereuse_record;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using Base_Function.BASE_COMMON;


namespace Base_Function.BLL_NURSE.Nurse_Record
{
    /// <summary>
    /// 产科模块
    /// </summary>
    public partial class UcNurse_Record_Obstetrical : UserControl
    {
        /// <summary>
        /// 列名称字典
        /// 键:列索引
        /// 值:项目名称
        /// </summary>
        Dictionary<int, string> dictColumnName = new Dictionary<int, string>();
        ColumnInfo[] cols = new ColumnInfo[34];
        /// <summary>
        /// 护理记录单行对象的集合
        /// </summary>
        ArrayList nurses = new ArrayList();
        ArrayList SumNusers = new ArrayList();
        ArrayList SumNusersRecords = new ArrayList();
        /// <summary>
        /// 诊断
        /// </summary>
        public string diagnose = "";
        #region 字典
     
   
        ListDictionary ldConsciousness = new ListDictionary();//意识字典
       // ListDictionary ldInAmount = new ListDictionary();//入量字典

        ListDictionary ldLinenames = new ListDictionary();//管道名称
        ListDictionary ldLinecase = new ListDictionary(); //管道情况

        ListDictionary ldTpl = new ListDictionary(); //胎膜破裂
        ListDictionary ldSX = new ListDictionary();  //渗血
        ListDictionary ldHz = new ListDictionary();  //红肿

        ListDictionary ldGas = new ListDictionary();       //肛门排气
        ListDictionary ldfeedskill = new ListDictionary(); //喂哺指导技巧
  
        #endregion

        #region 管路名称
        string pipe1 = "";
        string pipe2 = "";
        string pipe3 = "";
        string pipe4 = "";
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

        public UcNurse_Record_Obstetrical()
        {
            InitializeComponent();
        }

        private string strType = "O";
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="patient"></param>
        public UcNurse_Record_Obstetrical(InPatientInfo patient)
        {
            InitializeComponent();
            currentPatient = patient;
            Take_over_SEQ();//绑定班次
            SetCellData();//绑定单元格数据
            LoadDiagnose();
        }

        private void UcNurse_Record_Obstetrical_Load(object sender, EventArgs e)
        {
            bindColData();
            SetDictionaryForItem();
            flgView.Styles.Normal.WordWrap = true;
            cboTiming_SelectedIndexChanged(sender, e);//加载统计项时间
            flgView.Cols[14].AllowEditing = false;
            ShowMsg();
        }

        
        /// <summary>
        /// 画图特殊公式
        /// </summary>
        /// <param name="val">公式模式：左上，右上，左下，左右 （例如：123,33,25,167），一般模式：例如：123</param>
        /// <returns></returns>
        public Image DrawValueImage(string val)
        {
            Pen blackPen = new Pen(Color.Black, 1f);
            if (val.Contains(","))
            {
                string[] strs = val.Split(',');

                string UpL = "";    //左上
                string UpR = "";   //右上
                string DownL = ""; //左下
                string DownR = ""; //右下
                Font df = new Font("宋体", 9f); 
                StringFormat sf = new StringFormat();
                sf.FormatFlags = StringFormatFlags.MeasureTrailingSpaces | StringFormatFlags.FitBlackBox;
                SizeF UpLSize = new SizeF();
                SizeF UpRSize = new SizeF();
                SizeF DownLSize = new SizeF();
                SizeF DownRSize = new SizeF();
                UpL = strs[0];
                UpR = strs[1];
                DownL = strs[2];
                DownR = strs[3];
                Bitmap bt = new Bitmap(52, 28);
                Graphics g = Graphics.FromImage(bt);
                UpLSize = g.MeasureString(UpL, df);
                UpRSize = g.MeasureString(UpR, df);
                DownLSize = g.MeasureString(DownL, df);
                DownRSize = g.MeasureString(DownR, df);
                //十字架
                g.DrawLine(blackPen, 0, bt.Height / 2, bt.Width, bt.Height / 2);
                g.DrawLine(blackPen, bt.Width / 2, 0, bt.Width / 2, bt.Height);
                //左上
                g.DrawString(UpL, df, Brushes.Black, 0, 1);
                //右上
                g.DrawString(UpR, df, Brushes.Black, bt.Width / 2 + 1, 1);
                //左下
                g.DrawString(DownL, df, Brushes.Black, 0, bt.Height / 2 + 1);
                //右下
                g.DrawString(DownR, df, Brushes.Black, bt.Width / 2 + 1, bt.Height / 2 + 1);
                Image myImage = bt;
                return myImage;
            }
            else
            {
                if (val != "")
                {
                    StringFormat stringFormat = new StringFormat();
                    stringFormat.LineAlignment = StringAlignment.Center;
                    stringFormat.Alignment = StringAlignment.Center;
                    Font df = new Font("宋体", 9f);
                    Image imgTest = new Bitmap(35, 25);
                    Graphics grp = Graphics.FromImage(imgTest);
                    SizeF sz = grp.MeasureString(val, df);
                    Bitmap bt = new Bitmap((int)sz.Width, (int)sz.Height);
                    Graphics g = Graphics.FromImage(bt);
                    g.DrawString(val, df, Brushes.Black, 0,1);
                    Image myImage = bt;
                    return myImage;
                }
               
            }
            Bitmap bt1 = new Bitmap(35, 25);
            Image myImage1 = bt1;
            return myImage1;
        }


        private void SetCellData()
        {            

            //护理字典：96入量
            string sql_Nurse = "select item_code,item_name,item_type from t_nurse_record_dict where item_type=96";
            DataSet ds_Nurse = App.GetDataSet(sql_Nurse);

            //数据字典：意识196
            /*
              199  各类管道-名称(护理记录单)  GLGD001
              200  各类管道-情况(护理记录单)  GLGD002
              201  胎膜破裂(护理记录单)  TMPL001
              202  喂哺技巧(护理记录单)  WBJQ001
             * 196,199,200,201,202
             */
            string sql_Data = "select code,name,type from t_data_code where type in (199,200,201,202,207,208) order by code";
            DataSet ds_Data = App.GetDataSet(sql_Data);
            //时间日期
            //flgView.Cols[0].DataType = Type.GetType("System.DateTime");
            //flgView.Cols[0].Format = "yyyy-MM-dd HH:mm";

                

            if (sql_Nurse != null && ds_Data != null)
            {
                ////入量
                //DataRow[] dr = ds_Nurse.Tables[0].Select("item_type=96");
                //for (int i = 0; i < dr.Length; i++)
                //{
                //    ldInAmount.Add(dr[i]["item_code"].ToString(), dr[i]["item_name"].ToString());
                //}
                //flgView.Cols[7].DataMap = ldInAmount;

                //意识
                DataRow[] dr = ds_Data.Tables[0].Select("type='208'");
                for (int i = 0; i < dr.Length; i++)
                {
                    ldConsciousness.Add(dr[i]["code"].ToString(), dr[i]["name"].ToString());
                }
                

                //各类管道-名称(护理记录单) 
                dr = ds_Data.Tables[0].Select("type=199");
                for (int i = 0; i < dr.Length; i++)
                {
                    ldLinenames.Add(dr[i]["code"].ToString(), dr[i]["name"].ToString());
                }

                //各类管道-情况(护理记录单)
                //dr = ds_Nurse.Tables[0].Select("type=200");
                //for (int i = 0; i < dr.Length; i++)
                //{
                //    ldLinecase.Add(dr[i]["item_code"].ToString(), dr[i]["item_name"].ToString());
                //}

                ldLinecase.Add("-", "-");
                ldLinecase.Add("+", "+");
                ldLinecase.Add("拔", "拔");

                //胎膜破裂(护理记录单) 
                dr = ds_Data.Tables[0].Select("type=201");
                for (int i = 0; i < dr.Length; i++)
                {
                    ldTpl.Add(dr[i]["code"].ToString(), dr[i]["name"].ToString());
                }

                //喂哺技巧(护理记录单) 
                dr = ds_Data.Tables[0].Select("type=202");
                for (int i = 0; i < dr.Length; i++)
                {
                    ldfeedskill.Add(dr[i]["code"].ToString(), dr[i]["name"].ToString());
                }
                
                //渗血
                ldSX.Add("0","无");
                ldSX.Add("1", "有");

                //红肿
                dr = ds_Data.Tables[0].Select("type=207");
                for (int i = 0; i < dr.Length; i++)
                {
                    ldHz.Add(dr[i]["code"].ToString(), dr[i]["name"].ToString());
                }
                //ldHz.Add("0","无");
                //ldHz.Add("1", "有");

                //肛门排气
                ldGas.Add("0", "无");
                ldGas.Add("1", "有");             
            }
        }

        /// <summary>
        /// 绑定表格数据
        /// </summary>
        private void bindColData()
        {
            try
            {
                flgView.Cols[1].DataMap = ldConsciousness;
                //各类管道-名称(护理记录单)
                flgView.Cols[12].DataMap = ldLinenames;

                //各类管道-情况(护理记录单)
                flgView.Cols[13].DataMap = ldLinecase;

                //胎膜破裂(护理记录单) 
                flgView.Cols[15].DataMap = ldTpl;

                //喂哺技巧(护理记录单) 
                flgView.Cols[22].DataMap = ldfeedskill;

                //渗血
                flgView.Cols[19].DataMap = ldSX;

                //红肿
                flgView.Cols[20].DataMap = ldHz;

                //肛门排气
                flgView.Cols[21].DataMap = ldGas; 
            }
            catch
            { }
        }

        /// <summary>
        /// 设置项目字典
        /// </summary>
        public void SetDictionaryForItem()
        {
            dictColumnName.Add(0, "时间日期");
            dictColumnName.Add(1, "意识");         
            dictColumnName.Add(2, "体温");
            dictColumnName.Add(3, "脉搏");   
            dictColumnName.Add(4, "呼吸");
            dictColumnName.Add(5, "血压");
            dictColumnName.Add(6, "SPO2");
            dictColumnName.Add(7, "项目");
            dictColumnName.Add(8, "量");           
            dictColumnName.Add(9, "阴道流血");
            dictColumnName.Add(10, "尿液");
            dictColumnName.Add(11, "其他");
            dictColumnName.Add(12, "名称");
            dictColumnName.Add(13, "情况");
            dictColumnName.Add(14, "胎心音");
            dictColumnName.Add(15, "胎膜破裂");
            dictColumnName.Add(16, "宫口开大");
            dictColumnName.Add(17, "宫缩状况");
            dictColumnName.Add(18, "宫底高度脐下");
            dictColumnName.Add(19, "渗血");
            dictColumnName.Add(20, "红肿");
            dictColumnName.Add(21, "肛门排气");
            dictColumnName.Add(22, "喂哺技巧指导");
            dictColumnName.Add(23, "病情护理措施及效果");           
            dictColumnName.Add(24, "签名");
        }

        /// <summary>
        /// 绑定班次表
        /// </summary>
        private void Take_over_SEQ()
        {
            DataSet ds = App.GetDataSet("select * from T_TAKE_OVER_SEQ  order by seq,ID asc");
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
        /// 表头设置
        /// </summary>
        private void SetTable()
        {            

            flgView.Cols.Count = 26;
            flgView.Rows.Count = 4 + nurses.Count;
            flgView.Rows.Fixed = 3;
            //表头设置
            cols[0].Name = "日期/时间";
            cols[0].Field = "dateTime";
            cols[0].Index = 1;
            cols[0].visible = true;

            //意识
            cols[1].Name = "意识";
            cols[1].Field = "consciousness";
            cols[1].Index = 2;
            cols[1].visible = true;

            //体温
            cols[2].Name = "体温";
            cols[2].Field = "temperature";
            cols[2].Index = 3;
            cols[2].visible = true;

            //脉搏
            cols[3].Name = "脉搏";
            cols[3].Field = "pulse";
            cols[3].Index = 4;
            cols[3].visible = true;

            //呼吸
            cols[4].Name = "呼吸";
            cols[4].Field = "breathe";
            cols[4].Index = 5;
            cols[4].visible = true;

            //血压
            cols[5].Name = "血压";
            cols[5].Field = "blood_pressure";
            cols[5].Index = 6;
            cols[5].visible = true;

            //氧饱和度
            cols[6].Name = "血氧饱和度";
            cols[6].Field = "bp_saturation";
            cols[6].Index = 7;
            cols[6].visible = true;

            //入量名称
            cols[7].Name = "名称";
            cols[7].Field = "in_item_name";
            cols[7].Index = 8;
            cols[7].visible = true;

            //入量数值
            cols[8].Name = "量";
            cols[8].Field = "in_item_value";
            cols[8].Index = 9;
            cols[8].visible = true;

            //阴道流血
            cols[9].Name = "阴道流血";
            cols[9].Field = "in_item_value";
            cols[9].Index = 10;
            cols[9].visible = true;

            //尿液
            cols[10].Name = "尿液";
            cols[10].Field = "in_item_value";
            cols[10].Index = 11;
            cols[10].visible = true;

            //其他
            cols[11].Name = "其他";
            cols[11].Field = "in_item_value";
            cols[11].Index = 12;
            cols[11].visible = true;

            //各类导管--名称
            cols[12].Name = "名称";
            cols[12].Field = "in_item_name";
            cols[12].Index = 13;
            cols[12].visible = true;

            //各类导管--情况
            cols[13].Name = "名称";
            cols[13].Field = "in_item_name";
            cols[13].Index = 14;
            cols[13].visible = true;


            //胎心音
            cols[14].Name = "胎心音";
            cols[14].Field = "in_item_name";
            cols[14].Index = 15;
            cols[14].visible = true;

            //胎膜破裂
            cols[15].Name = "胎膜破裂";
            cols[15].Field = "in_item_name";
            cols[15].Index = 16;
            cols[15].visible = true;


            //宫口大开
            cols[16].Name = "宫口开大";
            cols[16].Field = "in_item_name";
            cols[16].Index = 17;
            cols[16].visible = true;


            //宫缩状况
            cols[17].Name = "宫缩状态";
            cols[17].Field = "in_item_name";
            cols[17].Index = 18;
            cols[17].visible = true;

            //宫底高度脐下
            cols[18].Name = "宫底高度脐下";
            cols[18].Field = "in_item_name";
            cols[18].Index = 19;
            cols[18].visible = true;

            //渗血
            cols[19].Name = "渗血";
            cols[19].Field = "in_item_name";
            cols[19].Index = 20;
            cols[19].visible = true;

            //红肿
            cols[20].Name = "红肿";
            cols[20].Field = "in_item_name";
            cols[20].Index = 21;
            cols[20].visible = true;

            //肛门排气
            cols[21].Name = "肛门排气";
            cols[21].Field = "in_item_name";
            cols[21].Index = 22;
            cols[21].visible = true;

            //喂哺技巧指导
            cols[22].Name = "喂哺技巧指导";
            cols[22].Field = "in_item_name";
            cols[22].Index = 23;
            cols[22].visible = true;

            //病情记录
            cols[23].Name = "病情记录";
            cols[23].Field = "in_item_name";
            cols[23].Index = 24;
            cols[23].visible = true;

            //签名
            cols[24].Name = "签名";
            cols[24].Field = "signature";
            cols[24].Index = 25;
            cols[24].visible = true;

            cols[25].Name = "SumID";
            cols[25].Field = "Number";
            cols[25].Index = 26;
            cols[25].visible = false;
        }

        /// <summary>
        /// 单元格合并和设置 
        /// </summary>
        /// <param name="pipe1">xx管名</param>
        /// <param name="pipe2">xx管名</param>
        /// <param name="pipe3">xx管名</param>
        /// <param name="pipe4">xx管名</param>
        private void CellUnit(string pipe1, string pipe2, string pipe3, string pipe4)
        {
            flgView.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            flgView.Cols.Fixed = 0;

            C1.Win.C1FlexGrid.CellRange cr;
            cr = flgView.GetCellRange(0, 0, 2, 0);
            cr.Data = "日期\r\n/\r\n时间";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 1, 2, 1);
            cr.Data = "意\r\n识";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 2, 0, 5);
            cr.Data = "生命体征";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 2, 2, 2);
            cr.Data = "体\r\n温";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 3, 2, 3);
            cr.Data = "脉\r\n搏";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 4, 2, 4);
            cr.Data = "呼\r\n吸";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 5, 2, 5);
            cr.Data = "血\r\n压";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 6, 0, 6);
            cr.Data = "SP\r\nO2";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);


            cr = flgView.GetCellRange(1, 6, 2, 6);
            cr.Data = "(%)";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);


            cr = flgView.GetCellRange(0, 7, 0, 8);
            cr.Data = "入量(ml)";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 7, 2, 7);
            cr.Data = "项\r\n目";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 8, 2, 8);
            cr.Data = "量";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);



            cr = flgView.GetCellRange(0, 9, 0, 11);
            cr.Data = "出量(ml)";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);


            cr = flgView.GetCellRange(1, 9, 2, 9);
            cr.Data = "阴道\r\n流血";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 10, 2, 10);
            cr.Data = "尿\r\n液";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 11, 2, 11);
            cr.Data = "其\r\n他";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);



            cr = flgView.GetCellRange(0, 12, 0, 13);
            cr.Data = "各类管道";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 12, 2, 12);
            cr.Data = "名\r\n称";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 13, 2, 13);
            cr.Data = "情\r\n况";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 14, 2, 14);
            cr.Data = "胎\r\n心\r\n音";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);


            cr = flgView.GetCellRange(0, 15, 2, 15);
            cr.Data = "胎\r\n膜\r\n破\r\n裂";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);


            cr = flgView.GetCellRange(0, 16, 2, 16);
            cr.Data = "宫\r\n口\r\n开\r\n大";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);


            cr = flgView.GetCellRange(0, 17, 2, 17);
            cr.Data = "宫  缩\r\n状  况";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 18, 2, 18);
            cr.Data = "宫底\r\n高度\r\n脐下\r\n(指)";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 19, 0, 20);
            cr.Data = "伤口";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 19, 2, 19);
            cr.Data = "渗血";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(1, 20, 2, 20);
            cr.Data = "红肿";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);


            cr = flgView.GetCellRange(0, 21, 2, 21);
            cr.Data = "肛\r\n门\r\n排\r\n气";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 22, 2, 22);
            cr.Data = "喂哺\r\n技巧\r\n指导";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);


            cr = flgView.GetCellRange(0, 23, 2, 23);
            cr.Data = "病情、护理措施及效果";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            cr = flgView.GetCellRange(0, 24, 2, 24);
            cr.Data = "签名";
            cr.StyleNew.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
            flgView.MergedRanges.Add(cr);

            flgView.AutoSizeCols();
            flgView.AutoSizeRows();
        }

        /// <summary>
        /// 获取需要打印的数据
        /// </summary>
        /// <returns></returns>
        public DataSet GetNusersRecords()
        {
            DataSet ds = null;
            ShowDatas();
            SumInOrOutRecordSets();
            Class_Nurse_Record_Obstetric[] cNurse = new Class_Nurse_Record_Obstetric[nurses.Count];
            for (int i = 0; i < nurses.Count; i++)
            {
                cNurse[i] = new Class_Nurse_Record_Obstetric();
                cNurse[i] = nurses[i] as Class_Nurse_Record_Obstetric;
                if (cNurse[i].In_item_name == null)
                {
                    cNurse[i].In_item_name = "";
                }
                //代码转换成类型名称
                try
                {
                    if (cNurse[i].Consciousness != null)
                        cNurse[i].Consciousness = ldConsciousness[cNurse[i].Consciousness].ToString();
                }
                catch (Exception ex)
                { }
                if (cNurse[i].In_item_name != null && App.IsNumeric(cNurse[i].In_item_name))
                {
                    if (cNurse[i].In_item_name != null)
                    {
                        cNurse[i].In_item_name = cNurse[i].In_item_name;
                    }
                    else
                    {
                        cNurse[i].In_item_name = cNurse[i].In_item_name.ToString();
                    }
                }            
            }           
            ds = App.ObjectArrayToDataSet(cNurse);
            return ds;
        }


        /// <summary>
        /// 绑定数据
        /// </summary>
        public void ShowData()
        {
            //SetTable();
            nurses.Clear();           

            #region 数据加载
            string dateTime = dtpDate.Value.ToString("yyyy-MM-dd HH:mm");

            string sql_time = "select distinct to_char(t.measure_time,'yyyy-mm-dd hh24:mi') as DATETIMEVAL from T_NURSE_RECORD t where t.patient_Id=" + currentPatient.Id + " and to_char(t.measure_time,'yyyy-MM-dd')='" + dtpDate.Value.ToString("yyyy-MM-dd") + "' and RECORD_TYPE='O' order by DATETIMEVAL asc";
            string sql_set = "select to_char(t.measure_time,'yyyy-mm-dd hh24:mi') as DATETIMEVAL,t.id,t.item_code,a.item_name,t.item_show_name,a.item_attribute,t.item_value,t.other_name,a.item_type,t.status_measure,t.creat_id,d.user_name,t.diagnose_name,PATIENT_ID from T_NURSE_RECORD t " +
                            " left join t_nurse_record_dict a on  to_char(a.id)=t.item_code left join T_DATA_CODE b on a.item_attribute=b.id inner " +
                            " join T_ACCOUNT_USER c on t.creat_id=c.user_id inner join T_USERINFO d on d.user_id=c.user_id where patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O' order by t.create_time asc ";
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
                    DataRow[] dr_dgmc = dt_sets.Select("item_show_name='名称' and DATETIMEVAL='" + dateTimeValue + "'", "id asc");
                    DataRow[] dr_dgqk = dt_sets.Select("item_show_name='情况' and DATETIMEVAL='" + dateTimeValue + "'", "id asc");
                    int index = dr_InAmount.Length;
                    if (dr_dgmc.Length > index)
                    {
                        index = dr_dgmc.Length;
                    }
                    if (dr_dgqk.Length > index)
                    {
                        index = dr_dgqk.Length;
                    }
                    if (index == 0)
                        index = 1;
                    for (int j = 0; j < index; j++)
                    {
                        Class_Nurse_Record_Obstetric temp = new Class_Nurse_Record_Obstetric();
                        temp.DateTime = dateTimeValue;
                        //入量
                        if (dr_InAmount.Length > 0 && j < dr_InAmount.Length)
                        {
                            temp.In_item_name = dr_InAmount[j]["item_code"].ToString();
                            temp.In_item_value = dr_InAmount[j]["item_value"].ToString();
                            temp.Number = dr_InAmount[j]["id"].ToString();
                        }
                        if (dr_dgmc.Length > 0 && j < dr_dgmc.Length)
                        {
                            temp.Pipeline_name = dr_dgmc[j]["item_value"].ToString();
                        }
                        if (dr_dgqk.Length > 0 && j < dr_dgqk.Length)
                        {
                            temp.Pipeline_value = dr_dgqk[j]["item_value"].ToString();
                        }
                        for (int k = 0; k < dr_Values.Length; k++)
                        {
                            if (j == 0)//非入量的项目只在当前时间段的第一行显示
                            {


                                if (dr_Values[k]["item_show_name"].ToString() == "意识")
                                {
                                    temp.Consciousness = dr_Values[k]["item_code"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "体温")
                                {
                                    temp.Temperature = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "脉搏")
                                {
                                    temp.Pulse = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "呼吸")
                                {
                                    temp.Breathe = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "血压")
                                {
                                    temp.Blood_pressure = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "SPO2")
                                {
                                    temp.Bp_saturation = dr_Values[k]["item_value"].ToString();
                                }
                                //else if (dr_Values[k]["item_show_name"].ToString() == "入量名称")
                                //{
                                //    temp.In_item_name = dr_Values[k]["item_value"].ToString();
                                //}
                                //else if (dr_Values[k]["item_show_name"].ToString() == "入量")
                                //{
                                //    temp.In_item_value = dr_Values[k]["item_value"].ToString();
                                //}
                                else if (dr_Values[k]["item_show_name"].ToString() == "阴道流血")
                                {
                                    temp.Abnormalvaginalbleeding = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "尿液")
                                {
                                    temp.Urine = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "其他")
                                {
                                    temp.Out_otheritem_value = dr_Values[k]["item_value"].ToString();
                                }
                                //else if (dr_Values[k]["item_show_name"].ToString() == "名称")
                                //{
                                //    temp.Pipeline_name = dr_Values[k]["item_value"].ToString();
                                //}
                                //else if (dr_Values[k]["item_show_name"].ToString() == "情况")
                                //{
                                //    temp.Pipeline_value = dr_Values[k]["item_value"].ToString();
                                //}
                                else if (dr_Values[k]["item_show_name"].ToString() == "胎心音")
                                {
                                    temp.Fetal_heart_sound = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "胎膜破裂")
                                {
                                    temp.Rupture_membranes = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "宫口开大")
                                {
                                    temp.Miyaguchi_kaio = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "宫缩状况")
                                {
                                    temp.Uterine_contraction = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "宫底高度脐下")
                                {
                                    temp.Fundus_height = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "渗血")
                                {
                                    temp.Blood_oozing = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "红肿")
                                {
                                    temp.Redandswollen = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "肛门排气")
                                {
                                    temp.Anus_gas = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "喂哺技巧指导")
                                {
                                    temp.Breast_feeding = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "病情护理措施及效果")
                                {
                                    temp.Remark = dr_Values[k]["item_value"].ToString();
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
                Class_Nurse_Record_Obstetric[] nurse = new Class_Nurse_Record_Obstetric[nurses.Count];
                for (int i = 0; i < nurses.Count; i++)
                {
                    nurse[i] = new Class_Nurse_Record_Obstetric();
                    nurse[i] = nurses[i] as Class_Nurse_Record_Obstetric;

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
                //CellUnit(pipe1, pipe2, pipe3, pipe4);
                //flgView.Refresh();
                //flgView.AutoSizeCols();
                //flgView.AutoSizeRows();
            }

            #endregion

        }


        /// <summary>
        /// 绑定数据
        /// </summary>
        public void ShowDatas()
        {
            //SetTable();
            nurses.Clear();

            #region 数据加载
            string dateTime = dtpDate.Value.ToString("yyyy-MM-dd HH:mm");

            string sql_time = "select distinct to_char(t.measure_time,'yyyy-mm-dd hh24:mi') as DATETIMEVAL from T_NURSE_RECORD t where t.patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O' order by DATETIMEVAL asc";
            string sql_set = "select to_char(t.measure_time,'yyyy-mm-dd hh24:mi') as DATETIMEVAL,t.id,t.item_code,a.item_name,t.item_show_name,a.item_attribute,t.item_value,t.other_name,a.item_type,t.status_measure,t.creat_id,d.user_name,t.diagnose_name,PATIENT_ID from T_NURSE_RECORD t " +
                            " left join t_nurse_record_dict a on  to_char(a.id)=t.item_code left join T_DATA_CODE b on a.item_attribute=b.id inner " +
                            " join T_ACCOUNT_USER c on t.creat_id=c.user_id inner join T_USERINFO d on d.user_id=c.user_id where patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O' order by t.create_time asc ";
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
                    DataRow[] dr_dgmc = dt_sets.Select("item_show_name='名称' and DATETIMEVAL='" + dateTimeValue + "'", "id asc");
                    DataRow[] dr_dgqk = dt_sets.Select("item_show_name='情况' and DATETIMEVAL='" + dateTimeValue + "'", "id asc");
                    int index = dr_InAmount.Length;
                    if (dr_dgmc.Length > index)
                    {
                        index = dr_dgmc.Length;
                    }
                    if (dr_dgqk.Length > index)
                    {
                        index = dr_dgqk.Length;
                    }
                    if (index == 0)
                        index = 1;
                    for (int j = 0; j < index; j++)
                    {
                        Class_Nurse_Record_Obstetric temp = new Class_Nurse_Record_Obstetric();
                        temp.DateTime = dateTimeValue;
                        //入量
                        if (dr_InAmount.Length > 0 && j < dr_InAmount.Length)
                        {
                            temp.In_item_name = dr_InAmount[j]["item_code"].ToString();
                            temp.In_item_value = dr_InAmount[j]["item_value"].ToString();
                            temp.Number = dr_InAmount[j]["id"].ToString();
                        }
                        if (dr_dgmc.Length > 0 && j < dr_dgmc.Length)
                        {
                            temp.Pipeline_name = dr_dgmc[j]["item_value"].ToString();
                        }
                        if (dr_dgqk.Length > 0 && j < dr_dgqk.Length)
                        {
                            temp.Pipeline_value = dr_dgqk[j]["item_value"].ToString();
                        }
                        for (int k = 0; k < dr_Values.Length; k++)
                        {
                            if (j == 0)//非入量的项目只在当前时间段的第一行显示
                            {
                                if (dr_Values[k]["item_show_name"].ToString() == "意识")
                                {
                                    temp.Consciousness = dr_Values[k]["item_code"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "体温")
                                {
                                    temp.Temperature = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "脉搏")
                                {
                                    temp.Pulse = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "呼吸")
                                {
                                    temp.Breathe = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "血压")
                                {
                                    temp.Blood_pressure = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "SPO2")
                                {
                                    temp.Bp_saturation = dr_Values[k]["item_value"].ToString();
                                }
                                //else if (dr_Values[k]["item_show_name"].ToString() == "入量名称")
                                //{
                                //    temp.In_item_name = dr_Values[k]["item_value"].ToString();
                                //}
                                //else if (dr_Values[k]["item_show_name"].ToString() == "入量")
                                //{
                                //    temp.In_item_value = dr_Values[k]["item_value"].ToString();
                                //}
                                else if (dr_Values[k]["item_show_name"].ToString() == "阴道流血")
                                {
                                    temp.Abnormalvaginalbleeding = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "尿液")
                                {
                                    temp.Urine = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "其他")
                                {
                                    temp.Out_otheritem_value = dr_Values[k]["item_value"].ToString();
                                }
                                //else if (dr_Values[k]["item_show_name"].ToString() == "名称")
                                //{
                                //    temp.Pipeline_name = dr_Values[k]["item_value"].ToString();
                                //}
                                //else if (dr_Values[k]["item_show_name"].ToString() == "情况")
                                //{
                                //    temp.Pipeline_value = dr_Values[k]["item_value"].ToString();
                                //}
                                else if (dr_Values[k]["item_show_name"].ToString() == "胎心音")
                                {
                                    temp.Fetal_heart_sound = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "胎膜破裂")
                                {
                                    temp.Rupture_membranes = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "宫口开大")
                                {
                                    temp.Miyaguchi_kaio = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "宫缩状况")
                                {
                                    temp.Uterine_contraction = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "宫底高度脐下")
                                {
                                    temp.Fundus_height = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "渗血")
                                {
                                    temp.Blood_oozing = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "红肿")
                                {
                                    temp.Redandswollen = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "肛门排气")
                                {
                                    temp.Anus_gas = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "喂哺技巧指导")
                                {
                                    temp.Breast_feeding = dr_Values[k]["item_value"].ToString();
                                }
                                else if (dr_Values[k]["item_show_name"].ToString() == "病情护理措施及效果")
                                {
                                    temp.Remark = dr_Values[k]["item_value"].ToString();
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

        private int  GetOtherName(int rowSel,ref int ireturn)
        {
            if (flgView[rowSel, 0] != null && flgView[rowSel, 0].ToString() != "")
            {
                return ireturn + 1;
            }
            else
            {
                ireturn++;
                return GetOtherName(rowSel - 1, ref ireturn);
            }
        }

        private bool GetOtherNameExists(int rowSel,int rows,int istart, int colIndex, string itemname)
        {
            if (istart == rows)
            {
                if (rows == 1)
                    return false;
                if (flgView[rowSel, colIndex] != null && flgView[rowSel, colIndex].ToString() != "" && flgView[rowSel, colIndex].Equals(itemname))
                    return true;
                else
                    return false;
            }
            if (flgView[rowSel, colIndex] != null && flgView[rowSel, colIndex].ToString() != "" && flgView[rowSel, colIndex].Equals(itemname))
            {
                return true;
            }
            else
            {
                return GetOtherNameExists(rowSel - 1, rows, istart + 1, colIndex, itemname);
            }
        }

        #region 表格相关操作
        private void flgView_CellChanged(object sender, RowColEventArgs e)
        {
            flgView.AutoSizeCol(e.Col);
           

        }
        //ComboBox cb = null;
        private void flgView_StartEdit(object sender, RowColEventArgs e)
        {
            if (flgView[e.Row, 0] == null && e.Col == 7)
            {
                string measureTime = GetTime(e.Row);
                //验证权限
                if (measureTime != "")//时间为空说明是添加数据，不用验证权限
                {
                    //string operateId = App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and patient_id=" + currentPatient.Id, 0, "creat_id");
                    string operateId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and patient_id=" + currentPatient.Id + " and RECORD_TYPE='O' and rownum=1 order by id", 0, "creat_id"));
                    if (!ValidateUser(operateId))
                    {
                        App.Msg("权限不足！");
                        e.Cancel = true;
                        return;
                    }
                }
            }
            else if ((flgView[e.Row, 0] == null||flgView[e.Row,0].ToString()=="") && (e.Col == 12||e.Col==13))
            {
                string measureTime = GetTime(e.Row);
                //验证权限
                if (measureTime != "")//时间为空说明是添加数据，不用验证权限
                {
                    //string operateId = App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and patient_id=" + currentPatient.Id, 0, "creat_id");
                    string operateId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and patient_id=" + currentPatient.Id + " and RECORD_TYPE='O' and rownum=1 order by id", 0, "creat_id"));
                    if (!ValidateUser(operateId))
                    {
                        App.Msg("权限不足！");
                        e.Cancel = true;
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else if ((flgView[e.Row, 0] != null && flgView[e.Row, 7] != null && (flgView[e.Row, 7].ToString().Contains("小结") || flgView[e.Row, 7].ToString().Contains("总结"))))
            {
                int id = 0;
                if (flgView[e.Row, 25] != null && flgView[e.Row, 25].ToString().Length > 0)
                {
                    try
                    {
                        id = int.Parse(flgView[e.Row, 25].ToString());
                    }
                    catch { }
                }
                if (id == 0)
                {
                    e.Cancel = true;
                    return;
                }
            }
            else if ((flgView[e.Row, 0] != null && flgView[e.Row, 0].ToString() != ""))
            {
                string measureTime = GetTime(e.Row);
                int num = Convert.ToInt32(App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and patient_id=" + currentPatient.Id, 0, "count(*)"));
                if (num > 0)
                {
                    //验证权限
                    if (measureTime != "")//时间为空说明是添加数据，不用验证权限
                    {
                        string operateId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and patient_id=" + currentPatient.Id + " and rownum=1 order by id", 0, "creat_id"));
                        if (!ValidateUser(operateId))
                        {
                            App.Msg("权限不足！");
                            e.Cancel = true;
                            return;
                        }
                    }
                }
            }
            //if (((flgView[e.Row, 0] == null && e.Col != 12) || (flgView[e.Row, 0] == null && e.Col != 13)) || e.Row != flgView.Rows.Count - 2)
            //{
            //    e.Cancel = true;
            //    return;
            //}
            if ((flgView[e.Row, 0] == null || flgView[e.Row, 0].ToString() == "") && e.Col != 7 && e.Col != 8 && e.Row != flgView.Rows.Count - 1 && flgView[e.Row, 7] != null)
            {
                e.Cancel = true;
                return;
            }

            //3体温单元格中的值不是数值类型，则该行是汇总数据，取消编辑
            //if (flgView[e.Row, 3] != null && !App.IsNumeric(flgView[e.Row, 3].ToString()))
            //{
            //    e.Cancel = true;
            //    return;
            //}
            //签名禁止编辑
            if (e.Col == 24)
            {
                e.Cancel = true;
                return;
            }
            if ((e.Col != 7 && e.Col != 8 && e.Col != 12 && e.Col != 13) || e.Col == 0)
            {
                //if (flgView[e.Row, 0] == null || flgView[e.Row, 0].ToString() == "")
                //{
                if (flgView[e.Row, 0] == null || flgView[e.Row, 0].ToString() == "")
                {
                    //App.Msg("请选择测量时间！");
                    FrmSetDatetime fsd = new FrmSetDatetime(dtpDate.Value, currentPatient.Id.ToString(), "O");
                    fsd.ShowDialog();
                    if (fsd.flag)
                        flgView[e.Row, 0] = fsd.Date.ToString("yyyy-MM-dd HH:mm");
                    e.Cancel = true;
                    return;
                }
                else
                {
                    if (e.Col == 0)
                    {
                        DateTime dt = Convert.ToDateTime(flgView[e.Row, 0].ToString());
                        string operateId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + dt.ToString("yyyy-MM-dd HH:mm") + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and patient_id=" + currentPatient.Id + " and rownum=1 order by id", 0, "creat_id"));

                        if (ValidateUser(operateId) || operateId == null)
                        {
                            FrmSetDatetime fsd = new FrmSetDatetime(dt, currentPatient.Id.ToString(), "O");
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
                                    dt.ToString("yyyy-MM-dd HH:mm") + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and patient_id=" + currentPatient.Id.ToString() + "";

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
            ////验证xx管的标题是否输入
            //if (e.Col >= 16 && e.Col <= 23)
            //{
            //    if (flgView[1, e.Col] == null || flgView[1, e.Col].ToString() == "")
            //    {
            //        修改标题ToolStripMenuItem_Click(sender, e);
            //    }
            //}

            //入量输入验证，先选择入量类型，再输入数值
            if (e.Col == 8)
            {
                if (flgView[e.Row, e.Col - 1] == null || flgView[e.Row, e.Col - 1].ToString() == "")
                {
                    App.Msg("提示:请先输入入量名称！");
                    flgView.Col = 7;
                    return;
                }
            }
            if (e.Col == 13)
            {
                if (flgView[e.Row, e.Col - 1] == null || flgView[e.Row, e.Col - 1].ToString() == "")
                {
                    App.Msg("提示:请先选择管道名称！");
                    flgView.Col = 12;
                    return;
                }
            }
            //if (flgView.Col == 23 && flgView[flgView.Row, 0] != null)
            //{
            //    this.提取备注模版ToolStripMenuItem_Click(sender, e);
            //    return;
            //}
            ////修改入量自定义名称
            //if (e.Col == 7 && flgView[e.Row, 7] != null && flgView[e.Row, 7].ToString() != "" && ldInAmount[flgView[e.Row, 7].ToString()] == null)
            //{
            //    string measureTime = GetTime(e.Row);
            //    oldInAmountName = flgView[e.Row, 7].ToString();
            //    FrmModifyTitle frm = new FrmModifyTitle(flgView[e.Row, 7].ToString());
            //    frm.ShowDialog();
            //    flgView[e.Row, e.Col] = frm.tName;
            //    //验证入量类型是否重复
            //    string itemName = flgView[e.Row, 7].ToString();
            //    int itemCount = Convert.ToInt32(App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='入量' and other_name='" + itemName + "' and patient_id=" + currentPatient.Id, 0, "count(*)"));
            //    if (itemCount > 0 && itemName != oldInAmountName)
            //    {
            //        App.Msg("入量项目重复！");
            //        flgView[e.Row, e.Col] = oldInAmountName;
            //        e.Cancel = true;
            //        return;
            //    }
            //    else if (itemName == oldInAmountName)
            //    {
            //        e.Cancel = true;
            //        return;
            //    }

            //    itemCount = Convert.ToInt32(App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='入量' and other_name='" + oldInAmountName + "' and patient_id=" + currentPatient.Id, 0, "count(*)"));

            //    //如果当前项目已存在则修改当前值的入量类型
            //    if (oldInAmountName != "")
            //    {
            //        if (itemCount > 0 && flgView[e.Row, 13] != null)
            //        {
            //            string sql = "update t_nurse_record set item_code='" + itemName + "', other_name='" + itemName + "',update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='入量' and other_name='" + oldInAmountName + "' and patient_id=" + currentPatient.Id;
            //            int num = App.ExecuteSQL(sql);
            //            if (num > 0)
            //            {
            //                timer1.Start();
            //                operateFlag = true;
            //                //插入签名
            //                flgView[e.Row, 24] = App.UserAccount.UserInfo.User_name;
            //                App.ExecuteSQL("update t_nurse_record set creat_id='" + App.UserAccount.UserInfo.User_id + "'，create_time=sysdate, update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and patient_id=" + currentPatient.Id);
            //            }
            //        }

            //    }
            //    e.Cancel = true;
            //}
        }


        private void flgView_KeyPressEdit(object sender, KeyPressEditEventArgs e)
        {
            //if (e.Col == 23)//备注
            //{
            //    e.Handled = true;
            //}
            if (e.Col == 2 || e.Col == 3 || e.Col == 4 || e.Col == 6 || e.Col == 10 || e.Col == 11 )
            {
                if (!Char.IsNumber(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.')
                {
                    e.Handled = true;
                }
            }
            //if (e.Col == 9)
            //{
            //    if (!Char.IsNumber(e.KeyChar))
            //    {
            //        e.Handled = true;
            //    }
            //}
            if (e.Col == 8)//入量可以输入-
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
            if (e.Col == 14)
            {
                string measureTime = GetTime(e.Row);
                frmFormula fc = new frmFormula(currentPatient, measureTime, dictColumnName[14]);
                fc.ShowDialog();
                if (fc.successflag)
                {
                    SetTable();
                    oldInAmountName = "";
                    ShowData();
                    SumInOrOutRecordSet(true);
                    ShowSumDataGrid();
                    CellUnit(pipe1, pipe2, pipe3, pipe4);
                }
            }

            if (e.Col == 5)//血压
            {
                if (!Char.IsNumber(e.KeyChar) && e.KeyChar != '\b' && e.KeyChar != '.' && e.KeyChar != '/')
                {
                    e.Handled = true;
                }
            }
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
                //string state = "";
                if (e.Col != 0)//12入量类型
                {
                    if (e.Col == 1 || e.Col == 12 || e.Col == 13 || e.Col == 15 || 
                        e.Col == 19 || e.Col == 20 || e.Col == 21 || e.Col == 22)
                    {
                        ListDictionary ldCommon = GetDictionaryByColIndex(e.Col);
                        itemValue = ldCommon[flgView[e.Row, e.Col].ToString()].ToString();
                        itemCode = flgView[e.Row, e.Col].ToString();
                        itemName = dictColumnName[e.Col];
                        if (e.Col == 12 || e.Col == 13)
                        {
                            int ireturn = 0;
                            otherName = GetOtherName(flgView.Row, ref ireturn).ToString();
                        }
                    }
                    else if (e.Col == 8||e.Col==7)//入量的值
                    {
                        if (flgView[e.Row, 7].ToString() != null)
                        {
                            otherName = flgView[e.Row, 7].ToString();
                        }
                        else
                        {
                            otherName = flgView[e.Row, 7].ToString();
                        }
                        if (flgView[e.Row, 8] != null)
                        {
                            itemValue = flgView[e.Row, 8].ToString();
                        }
                        itemCode = flgView[e.Row, 7].ToString();
                        itemName = "入量";
                        if (flgView[e.Row, 25] != null && flgView[e.Row, 25].ToString().Length > 0)
                        {
                            try
                            {
                                id = int.Parse(flgView[e.Row, 25].ToString());
                            }
                            catch { }
                        }
                    }
                    else
                    {
                        itemValue = flgView[e.Row, e.Col].ToString();
                        if (e.Col == 23)//备注，验证字符长度
                        {
                            int length = getStringLength(itemValue);
                            if (length > 1000)
                            {
                                App.Msg("您输入的内容超过1000字节了!");
                                return;
                            }
                        }
                        if (e.Col == 9)
                        {
                            if (!App.IsNumeric(itemValue))
                            {
                                otherName = "不汇总";
                            }
                        }
                        itemName = dictColumnName[e.Col];
                        itemCode = App.ReadSqlVal("select id from t_nurse_record_dict where item_name='" + itemName + "'", 0, "id");
                    }
                    //取当前日期时间最早的创建者id
                    string userId = "";
                    try
                    {
                        userId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and patient_id=" + currentPatient.Id + " and rownum=1 order by id", 0, "creat_id"));
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
                    if (e.Col != 8&&e.Col!=7)
                    {
                        itemCount = Convert.ToInt32(App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and item_show_name='" + itemName + "' and patient_id=" + currentPatient.Id, 0, "count(*)"));
                        if (e.Col == 12 || e.Col == 13)
                        {
                            if (otherName != "1")
                            {
                                itemCount = Convert.ToInt32(App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and item_show_name='" + itemName + "' and other_name='" + otherName + "'  and patient_id=" + currentPatient.Id, 0, "count(*)"));
                            }
                        }
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
                            itemCount = Convert.ToInt32(App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and item_show_name='" + itemName + "' and other_name='" + otherName + "'  and patient_id=" + currentPatient.Id, 0, "count(*)"));
                        }
                    }
                    string sql = "";
                    if (itemCount == 0)
                    {
                        //if (e.Col==9)
                        //{
                        //    sql = "insert into t_nurse_record" +
                        //                 "( bed_no, pid, measure_time, item_code, item_value, creat_id, create_time, patient_id, item_show_name,RECORD_TYPE,C_STATE)values" +
                        //                 "( '" + currentPatient.Sick_Bed_Name + "', '" + currentPatient.PId + "', to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9'), '" +
                        //                 itemCode + "', '" + itemValue + "', '" + App.UserAccount.UserInfo.User_id + "', sysdate, " + currentPatient.Id + ", '" + itemName + "','O','" + state + "')";
                        //}
                        //else 
                        if (otherName == "")
                        {
                            sql = "insert into t_nurse_record" +
                                         "( bed_no, pid, measure_time, item_code, item_value, creat_id, create_time, patient_id, item_show_name,RECORD_TYPE)values" +
                                         "( '" + currentPatient.Sick_Bed_Name + "', '" + currentPatient.PId + "', to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9'), '" +
                                         itemCode + "', '" + itemValue + "', '" + userId + "', sysdate, " + currentPatient.Id + ", '" + itemName + "','O')";
                        }
                        else
                        {
                            sql = "insert into t_nurse_record" +
                                         "( bed_no, pid, measure_time, item_code, item_value, creat_id, create_time, patient_id, item_show_name,other_name,RECORD_TYPE)values" +
                                         "( '" + currentPatient.Sick_Bed_Name + "', '" + currentPatient.PId + "', to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9'), '" +
                                         itemCode + "', '" + itemValue + "', '" + userId + "', sysdate, " + currentPatient.Id + ", '" + itemName + "','" + otherName + "','O')";
                        }
                    }
                    else
                    {
                        if (!ValidateUser(userId))
                        {
                            App.Msg("修改权限不足!");
                            btnSearch_Click(sender, e);
                            return;
                        }
                        if (e.Col == 9)
                        {//阴道流血:不为数字的标识存在other_name字段,所以的跟着变
                            sql = "update t_nurse_record set item_code='" + itemCode + "',item_value='" + itemValue + "',other_name='" + otherName + "',update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate" +
                                " where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and item_show_name='" + itemName + "'  and patient_id=" + currentPatient.Id;
                        }
                        else if (otherName == "")
                        {
                            sql = "update t_nurse_record set item_code='" + itemCode + "',item_value='" + itemValue + "',update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate" +
                                " where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and item_show_name='" + itemName + "'  and patient_id=" + currentPatient.Id;
                        }
                        else
                        {   
                            sql = "update t_nurse_record set item_code='" + itemCode + "',item_value='" + itemValue + "',update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate";
                            if (id > 0)
                            {
                                sql += " where id=" + id;
                            }
                            else
                            {
                                sql += " where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and item_show_name='" + itemName + "' and other_name='" + otherName + "'  and patient_id=" + currentPatient.Id;
                            }
                            if (e.Col == 12 || e.Col == 13)
                            {
                                if (otherName == "1")
                                {
                                    sql = "update t_nurse_record set item_code='" + itemCode + "',item_value='" + itemValue + "',update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate";
                                    sql += " where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and item_show_name='" + itemName + "' and (other_name='" + otherName + "' or other_name is null)  and patient_id=" + currentPatient.Id;
                                }
                            }
                        }
                    }
                    int num = App.ExecuteSQL(sql);
                    if (num > 0)
                    {
                        timer1.Start();
                        operateFlag = true;
                        //插入签名
                        if (flgView[e.Row, 0] != null && flgView[e.Row, 0].ToString() != "" && flgView[e.Row, 24] == null && sql.Contains("insert"))
                        {
                            flgView[e.Row, 24] = App.UserAccount.UserInfo.User_name;
                        }
                        if (id == 0 && itemName == "入量"&&sql.ToLower().Contains("insert"))
                        {
                            btnSearch_Click(sender, e);
                        }
                        //App.Msg("操作成功！");
                        //App.ExecuteSQL("update t_nurse_record set creat_id='" + App.UserAccount.UserInfo.User_id + "',create_time=sysdate, update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and patient_id=" + currentPatient.Id);
                        //btnSearch_Click(sender, e);
                    }
                }
                //else if (e.Col == 7)//&& flgView[e.Row, 0] != null && flgView[e.Row, 0].ToString() != "")//更新入量类型
                //{
                //    //新建自定义入量名称
                //    //if (flgView[e.Row, e.Col].ToString() == "80")
                //    //{
                //    //    if (App.Ask("是否需要自定义入量名称？"))
                //    //    {
                //    //        FrmModifyTitle frm = new FrmModifyTitle();
                //    //        frm.Text = "入量名称";
                //    //        frm.ShowDialog();
                //    //        flgView[e.Row, e.Col] = frm.tName;
                //    //        return;
                //    //    }
                //    //}

                //    //验证入量类型是否重复
                //    itemName = flgView[e.Row, 7].ToString();
                //    int itemCount = Convert.ToInt32(App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and item_show_name='入量' and other_name='" + itemName + "' and patient_id=" + currentPatient.Id, 0, "count(*)"));
                //    //if (itemCount > 0 && itemName != oldInAmountName)
                //    //{
                //    //    App.Msg("入量项目重复！");
                //    //    flgView[e.Row, e.Col] = oldInAmountCode;
                //    //    //btnSearch_Click(sender, e);
                //    //    return;
                //    //}

                //    //itemCount = Convert.ToInt32(App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='入量' and other_name='" + oldInAmountName + "' and patient_id=" + currentPatient.Id, 0, "count(*)"));
                //    if (flgView[e.Row, flgView.Cols.Count - 1] != null && flgView[e.Row, flgView.Cols.Count - 1].ToString().Length > 0)
                //    {
                //        try
                //        {
                //            id = int.Parse(flgView[e.Row, flgView.Cols.Count - 1].ToString());
                //        }
                //        catch { }
                //    }
                //    if (id > 0)
                //    {
                //        otherName = flgView[e.Row, 7].ToString();
                //        itemCode = flgView[e.Row, 7].ToString();
                //        string operateId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and patient_id=" + currentPatient.Id + " and rownum=1 order by id", 0, "creat_id"));
                //        if (!ValidateUser(operateId))
                //        {
                //            App.Msg("修改权限不足!");
                //            btnSearch_Click(sender, e);
                //            return;
                //        }
                //        string sql = "update t_nurse_record set item_code='" + itemCode + "',other_name='" + otherName + "',update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate ";
                //        sql += " where id=" + id;
                //        //sql+=" where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and item_show_name='入量' and other_name='" + oldInAmountName + "' and patient_id=" + currentPatient.Id;
                //        int num = App.ExecuteSQL(sql);
                //        if (num > 0)
                //        {
                //            timer1.Start();
                //            //App.Msg("操作成功！");
                //            operateFlag = true;
                //            //插入签名
                //            //if (flgView[e.Row, 0] != null && flgView[e.Row, 0].ToString() != "")
                //            //    flgView[e.Row, 24] = App.UserAccount.UserInfo.User_name;
                //            //App.ExecuteSQL("update t_nurse_record set creat_id='" + App.UserAccount.UserInfo.User_id + "'，create_time=sysdate, update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and patient_id=" + currentPatient.Id);
                //            //btnSearch_Click(sender, e);
                //        }
                //    }
                    //如果当前项目已存在则修改当前值的入量类型
                    //if (oldInAmountName != flgView[e.Row, 7].ToString())
                    //{
                    //    if (flgView[e.Row, 8] != null)
                    //    {
                    //        otherName = flgView[e.Row, 7].ToString();
                    //        itemCode = flgView[e.Row, 7].ToString();
                    //        string operateId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and patient_id=" + currentPatient.Id + " and rownum=1 order by id", 0, "creat_id"));
                    //        if (!ValidateUser(operateId))
                    //        {
                    //            App.Msg("修改权限不足!");
                    //            btnSearch_Click(sender, e);
                    //            return;
                    //        }
                    //        string sql = "update t_nurse_record set item_code='" + itemCode + "',other_name='" + otherName + "',update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and item_show_name='入量' and other_name='" + oldInAmountName + "' and patient_id=" + currentPatient.Id;
                    //        int num = App.ExecuteSQL(sql);
                    //        if (num > 0)
                    //        {
                    //            timer1.Start();
                    //            //App.Msg("操作成功！");
                    //            operateFlag = true;
                    //            //插入签名
                    //            //if (flgView[e.Row, 0] != null && flgView[e.Row, 0].ToString() != "")
                    //            //    flgView[e.Row, 24] = App.UserAccount.UserInfo.User_name;
                    //            //App.ExecuteSQL("update t_nurse_record set creat_id='" + App.UserAccount.UserInfo.User_id + "'，create_time=sysdate, update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and patient_id=" + currentPatient.Id);
                    //            //btnSearch_Click(sender, e);
                    //        }
                    //    }
                    //}
                //}              
            }
            #endregion
        }

        /// <summary>
        /// 设置编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flgView_SetupEditor(object sender, RowColEventArgs e)
        {
            if (e.Col == 7 && flgView[e.Row, e.Col] != null && flgView[e.Row, e.Col].ToString() != "")//入量名称列
            {
                //保存修改前的入量名称
                if (flgView[e.Row, e.Col] != null)
                {
                    oldInAmountName = flgView[e.Row, e.Col].ToString();
                    oldInAmountCode = flgView[e.Row, e.Col].ToString();
                }
            }
        }
        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SetTable();
            oldInAmountName = "";
            ShowData();
            SumInOrOutRecordSet(true);
            ShowSumDataGrid();
            CellUnit(pipe1, pipe2, pipe3, pipe4);
        }


        /// <summary>
        /// 根据列的索引获得对应的字典集合
        /// </summary>
        /// <returns>类型字典</returns>
        private ListDictionary GetDictionaryByColIndex(int col)
        {          
            //意识
            if (col == 1)
            {
                return ldConsciousness;
            }
            //else if (col == 7)//项目
            //{
            //    return ldInAmount;
            //}           
            else if (col == 12)//各类管道名称
            {
                return ldLinenames;
            }
            else if (col == 13)//各类管道情况
            {
                return ldLinecase;
            } 
            else if (col == 15)//胎膜破裂
            {
                return ldTpl;
            }
            else if (col == 19)//渗血
            {
                return ldSX;
            }
            else if (col == 20)//红肿
            {
                return ldHz;
            }
            else if (col == 21)//肛门排气
            {
                return ldGas;
            }
            else if (col == 22)//喂技巧指导
            {
                return ldfeedskill;
            }
            return null;
        }

        private void 修改标题ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            C1.Win.C1FlexGrid.RowColEventArgs c1e = e as C1.Win.C1FlexGrid.RowColEventArgs;
            string measureTime = GetTime(flgView.Row);
            string operateId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and patient_id=" + currentPatient.Id + " and rownum=1 order by id", 0, "creat_id"));
            if (!ValidateUser(operateId))
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
                //更新xx管的名字
                string sql = "update t_nurse_record set other_name='" + frm.tName + "' where patient_id=" + currentPatient.Id + " and RECORD_TYPE='O' and item_show_name like '%" + pipeIndex + "%'";
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
            if (flgView.Col == 7)
            {
                修改项目名toolStripMenuItem.Visible = true;
            }
            else
            {
                修改项目名toolStripMenuItem.Visible = false;
            }

            if (flgView.Col == 23 && flgView[flgView.Row, 0] != null)
            {
                提取备注模版ToolStripMenuItem.Visible = true;
               
                if (flgView[flgView.Row, flgView.Col] != null)
                {
                    添加备注模版ToolStripMenuItem.Visible = true;
                }
                else
                {
                    添加备注模版ToolStripMenuItem.Visible = false;
                }
            }
            else
            {
                添加备注模版ToolStripMenuItem.Visible = false;
                提取备注模版ToolStripMenuItem.Visible = false;
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
                FrmSumItem sum_item = new FrmSumItem(sum_id,"O");
                sum_item.ShowDialog();
                if (!sum_item.successflag)
                {//没有操作成功,清除这条统计记录
                    string del = "delete from t_nurse_dangery_inout_sum_h where id=" + sum_id + " and patient_id=" + currentPatient.Id;
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



            int id = App.GenId("t_nurse_dangery_inout_sum_h", "ID");//,CREAT_ID  ,'" + App.UserAccount.Account_id+ "'
            Class_Take_over_SEQ take_Seq = cboTiming.SelectedItem as Class_Take_over_SEQ;

            if (take_Seq != null)
            {
                //类型 空（或者 D） 成人    C 儿童  O 产科  B新生儿
                string inserSumSql = "insert into t_nurse_dangery_inout_sum_h(ID,PID,CALC_DATE,START_TIME,END_TIME,OPER_METHOD,patient_Id,seq_id,SIGNATURE,RECORD_TYPE)values(" +
                id.ToString() + ",'" + currentPatient.PId + "',sysdate,to_timestamp('" +
                dtpBeginTime.Value.ToString("yyyy-MM-dd HH:mm") + "','yyyy-MM-dd HH24:mi'),to_timestamp('" +
                dtpEndTime.Value.ToString("yyyy-MM-dd HH:mm") + "','yyyy-MM-dd HH24:mi'),'" + sum_Name + "'," + currentPatient.Id + "," + take_Seq.Id + ",'" + App.UserAccount.UserInfo.User_name + "','O')";
                if (App.ExecuteSQL(inserSumSql)>0)
                {
                    sum_id = id.ToString();
                } 
            }
            return sum_id;
#region 注
            //SumNusers.Clear();
            //string Eat = "";//食物
            //string abnormalvaginalbleeding = "";//阴道流血
            //string Urine = "";//尿液
            //string OtherOut = "";//其他出量
            //string LetFlow = "";//弃液
            //int inAmount = 0;//入量总和
            //int outAmount = 0;//出量总和

            
            //Class_Nurse_Record_Obstetric sumtemp = new Class_Nurse_Record_Obstetric();

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

            ////入量总和
            //string SqlIn_1 = "select '入量总合' as ItemName,sum(a.item_value) as sumval from t_nurse_record a " +
            //       " where item_show_name='入量'  and other_name not like '%弃液%' " +
            //       "and MEASURE_TIME" + beginSgin + "to_timestamp('" + dtpBeginTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + dtpEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";
            ////弃液总和
            //string SqlIn_2 = "select '入量弃液' as ItemName,sum(a.item_value) as sumval from t_nurse_record a " +
            //       " where item_show_name='入量' and other_name like '%弃液%' " +
            //       " and MEASURE_TIME" + beginSgin + "to_timestamp('" + dtpBeginTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + dtpEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";

            ////阴道流血:字符不统计
            //string SqlOut_1 = "select '阴道流血' as ItemName,sum(a.item_value) as sumval from t_nurse_record a  where item_show_name like '%阴道流血%' and other_name is null and MEASURE_TIME" +
            //    beginSgin + "to_timestamp('" + dtpBeginTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + dtpEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";
            ////尿液
            //string SqlOut_2 = "select '尿液' as ItemName,sum(a.item_value) as sumval from t_nurse_record a where item_show_name like '%尿液%' and MEASURE_TIME" +
            //beginSgin + "to_timestamp('" + dtpBeginTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + dtpEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";
         
            ////其他
            //string SqlOut_3 = "select '其他' as ItemName,sum(a.item_value) as sumval from t_nurse_record a where item_show_name like '%其他%' and MEASURE_TIME" +
            //beginSgin + "to_timestamp('" + dtpBeginTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + dtpEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";
            //string Sql = SqlIn_1 + " union " + SqlIn_2 + " union " + SqlOut_1 + " union " + SqlOut_2 + " union " + SqlOut_3;

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
            //    else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("阴道流血"))
            //    {
            //        if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
            //        {
            //            abnormalvaginalbleeding = ds.Tables[0].Rows[i]["sumval"].ToString();
            //        }
            //        else
            //        {
            //            abnormalvaginalbleeding = "0";
            //        }
            //    }
            //    else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("尿液"))
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
            //    else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("其他"))
            //    {
            //        if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
            //        {
            //            OtherOut = ds.Tables[0].Rows[i]["sumval"].ToString();
            //        }
            //        else
            //        {
            //            OtherOut = "0";
            //        }
            //    }   
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
            //    outAmount = Convert.ToInt32(abnormalvaginalbleeding) + Convert.ToInt32(Urine) + Convert.ToInt32(OtherOut);
            //}
            //catch (Exception)
            //{

            //    outAmount = 0;
            //}

            //sumtemp.In_item_value = inAmount == 0 ? "" : inAmount.ToString();//食物量
            ////sumtemp.Shit = Excrement;//大便量
            //sumtemp.Out_otheritem_value = outAmount == 0 ? "" : outAmount.ToString();//出量总和 
            //if (App.UserAccount.UserInfo != null)
            //    sumtemp.Signature = App.UserAccount.UserInfo.User_name;//签名

            //DateTime TempDate = new DateTime();
            //bool flag = false;

            ////将汇总记录插到对象集合中去
            //for (int i = 0; i < nurses.Count; i++)
            //{
            //    Class_Nurse_Record_Obstetric temp_nuser = (Class_Nurse_Record_Obstetric)nurses[i];
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
            //}
#endregion
        }

        /// <summary>
        /// 表格的汇总计算刷新
        /// </summary>
        private void ShowSumDataGrid()
        {
            string TempDateTime = null;
            Class_Nurse_Record_Obstetric[] Nusers_objs = new Class_Nurse_Record_Obstetric[nurses.Count];
            for (int i = 0; i < nurses.Count; i++)
            {

                Nusers_objs[i] = new Class_Nurse_Record_Obstetric();
                Nusers_objs[i] = (Class_Nurse_Record_Obstetric)nurses[i];
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
                    flgView[i + 3, 25] = Nusers_objs[i].Number;
                }
            }
            //for (int i = 0; i < flgView.Rows.Count; i++)
            //{
            //    if (flgView[i, 7] != null)
            //    {
            //        if (flgView[i, 7].ToString().Contains("小结") || flgView[i, 7].ToString().Contains("出入量"))
            //        {
            //            flgView.Rows[i].AllowEditing = false;
            //        }
            //        else
            //        {
            //            flgView.Rows[i].AllowEditing = true;
            //        }
            //    }
            //}


            //胎心音图片生成         
            for (int i = 3; i < flgView.Rows.Count; i++)
            {
                if (flgView[i, 14] != null)
                {
                    if (flgView[i, 14].ToString() != "")
                    {                       
                        flgView.SetCellImage(i, 14, DrawValueImage(flgView[i, 14].ToString()));
                        flgView[i, 14] = "";
                    }
                    else
                    {
                        flgView.SetCellImage(i, 14, null);
                        flgView[i, 14] = "";
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
        /// 重置计算出入量汇总
        /// </summary>
        private void SumInOrOutRecordSet(bool IsToDay)
        {
            
            SumNusersRecords.Clear();
            string date = dtpDate.Value.ToString("yyyy-MM-dd");
            string sql_date = "select * from t_nurse_dangery_inout_sum_h where patient_Id=" + currentPatient.Id + " and  to_char(end_time,'yyyy-MM-dd')='" + date + "' and RECORD_TYPE='O' order by end_time";
            if (!IsToDay)
            {
                sql_date="select * from t_nurse_dangery_inout_sum_h where patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O' order by end_time";
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
                double Eat = 0;//食物
                double abnormalvaginalbleeding = 0;//阴道流血
                double Urine = 0;//尿液
                double OtherOut = 0;//其他出量
                string Number = "";//号码
                string seq_id = "";//统计类型ID
                string LetFlow = "";//弃液
                double inAmount = 0;//入量总和
                double outAmount = 0;//出量总和
                string singsure = ""; //签名

                BeginTime = SumNusersRecords[i1].ToString().Split(',')[0];
                EndTime = SumNusersRecords[i1].ToString().Split(',')[1];
                Item_name = SumNusersRecords[i1].ToString().Split(',')[2];
                Number = SumNusersRecords[i1].ToString().Split(',')[3];
                seq_id = SumNusersRecords[i1].ToString().Split(',')[4];
                singsure = SumNusersRecords[i1].ToString().Split(',')[5];
                string[] sum_item = SumNusersRecords[i1].ToString().Split(',')[6].Split('|');//统计项目
                //creatID = SumNusersRecords[i1].ToString().Split(',')[4];+ "," + ds_sum_oper.Tables[0].Rows[i]["CREAT_ID"].ToString()
                SumNusers.Clear();
                //日间,夜间的上一班次时间
                //BeginedTiem = Convert.ToDateTime(EndTime).AddDays(-1).ToString("yyyy-MM-dd HH:mm");
                //EndedTime = BeginTiem;

                Class_Nurse_Record_Obstetric sumtemp = new Class_Nurse_Record_Obstetric();

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

                #region old
                ////入量总和
                //string SqlIn_1 = "select '入量总合' as ItemName,sum(a.item_value) as sumval from t_nurse_record a " +
                //       " where item_show_name='入量'  and other_name not like '%弃液%'  and other_name not like '%余液%' " +
                //       "and MEASURE_TIME" + beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";
                ////弃液总和
                //string SqlIn_2 = "select '入量弃液' as ItemName,sum(abs(a.item_value)) as sumval from t_nurse_record a " +
                //       " where item_show_name='入量' and other_name like '%弃液%' " +
                //       " and MEASURE_TIME" + beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";
                ////当前统计时段余液总和
                //string SqlIn_3 = "select '入量余液-' as ItemName,sum(abs(a.item_value)) as sumval from t_nurse_record a " +
                //       " where item_show_name='入量'  and other_name like '%余液%' " +
                //       @"and MEASURE_TIME" + beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" +
                //         endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";
                ////上次统计时段余液总和
                //string SqlIn_4 = "select '入量余液+' as ItemName,sum(abs(a.item_value)) as sumval from t_nurse_record a " +
                //       " where item_show_name='入量'  and other_name like '%余液%' " +
                //       @"and MEASURE_TIME>to_timestamp('" + BeginedTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME<=to_timestamp('" + EndedTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";

                ////阴道流血:非数字不统计!
                //string SqlOut_1 = "select '阴道流血' as ItemName,sum(a.item_value) as sumval from t_nurse_record a where item_show_name like '%阴道流血%' and other_name is null and MEASURE_TIME" +
                //    beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";
                ////尿液
                //string SqlOut_2 = "select '尿液' as ItemName,sum(a.item_value) as sumval from t_nurse_record a where item_show_name like '%尿液%' and MEASURE_TIME" +
                //    beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";
                ////其他
                //string SqlOut_3 = "select '其他' as ItemName,sum(a.item_value) as sumval from t_nurse_record a where item_show_name like '%其他%' and MEASURE_TIME" +
                //    beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";

                //string SqlOut = "";

                //foreach (string i in sum_item)
                //{
                //    if (i != null && i != "")
                //    {
                //        if (i == "阴道流血")
                //            SqlOut += " union " + "select '" + i + "' as ItemName,sum(a.item_value) as sumval from t_nurse_record a where item_show_name like '%" + i + "%' and other_name is null and MEASURE_TIME" +
                //                beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";
                //        else
                //            SqlOut += " union " + "select '" + i + "' as ItemName,sum(a.item_value) as sumval from t_nurse_record a where item_show_name like '%" + i + "%' and MEASURE_TIME" +
                //                beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";
                //    }
                //    else
                //    {
                //        SqlOut = " union " + SqlOut_1 + " union " + SqlOut_2 + " union " + SqlOut_3;
                //    }
                //}

                //string Sql ="";
                //if (Item_name.Contains("日间") || Item_name.Contains("夜间"))
                //{
                //    Sql = SqlIn_1 + " union " + SqlIn_2 + " union " + SqlIn_3 + " union " + SqlIn_4 + SqlOut;//" union " + SqlOut_1 + " union " + SqlOut_2 + " union " + SqlOut_3;
                //}
                //else
                //{
                //    Sql = SqlIn_1 + " union " + SqlIn_2 + SqlOut;// " union " + SqlOut_1 + " union " + SqlOut_2 + " union " + SqlOut_3;
                //}

                //DataSet ds = App.GetDataSet(Sql);
                #endregion

                StringBuilder sbSum = new StringBuilder("select item_show_name as ItemName,a.item_value as ItemValue,a.item_code as ItemCode from t_nurse_record a");
                sbSum.Append(" where 1=1");
                sbSum.Append(" and MEASURE_TIME" + beginSgin + "to_timestamp('" + BeginTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME");
                sbSum.Append(" " + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id);
                sbSum.Append(" and record_type='" + strType + "'");
                sbSum.Append(" and item_show_name in('入量','阴道流血','尿液','其他')");
                //处理开始时间点的余液
                sbSum.Append(" Union all");
                sbSum.Append(" select item_show_name as ItemName,a.item_value as ItemValue,'余液+' as ItemCode from t_nurse_record a");
                sbSum.Append(" where  1=1");
                sbSum.Append(" and to_char(MEASURE_TIME,'yyyy-mm-dd hh24:mi')='" + Convert.ToDateTime(BeginTime).ToString("yyyy-MM-dd HH:mm") + "'");
                sbSum.Append(" and patient_Id=" + currentPatient.Id);
                sbSum.Append(" and record_type='" + strType + "'");
                sbSum.Append(" and item_show_name='入量'");
                sbSum.Append(" and item_code='余液'");
                //处理结束时间点的余液
                sbSum.Append(" Union all");
                sbSum.Append(" select item_show_name as ItemName,a.item_value as ItemValue,'余液-' as ItemCode from t_nurse_record a");
                sbSum.Append(" where  1=1");
                sbSum.Append(" and to_char(MEASURE_TIME,'yyyy-mm-dd hh24:mi')='" + Convert.ToDateTime(EndTime).ToString("yyyy-MM-dd HH:mm") + "'");
                sbSum.Append(" and patient_Id=" + currentPatient.Id);
                sbSum.Append(" and record_type='" + strType + "'");
                sbSum.Append(" and item_show_name='入量'");
                sbSum.Append(" and item_code='余液'");
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
                                case "阴道流血":
                                    abnormalvaginalbleeding += dtmp;
                                    break;
                                case "尿液":
                                    Urine += dtmp;
                                    break;
                                case "其他":
                                    OtherOut += dtmp;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
                sumtemp.DateTime = EndTime;
                sumtemp.In_item_name = Item_name;
                sumtemp.Number = Number;
                #region old统计赋值
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
                //    else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("阴道流血"))
                //    {
                //        if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
                //        {
                //            abnormalvaginalbleeding = ds.Tables[0].Rows[i]["sumval"].ToString();
                //        }
                //        else
                //        {
                //            abnormalvaginalbleeding = "0";
                //        }
                //    }
                //    else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("尿液"))
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
                //    else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("其他"))
                //    {
                //        if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
                //        {
                //            OtherOut = ds.Tables[0].Rows[i]["sumval"].ToString();
                //        }
                //        else
                //        {
                //            OtherOut = "0";
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
                //    outAmount = Convert.ToDouble(abnormalvaginalbleeding) + Convert.ToDouble(Urine) + Convert.ToDouble(OtherOut);
                //}
                //catch (Exception) { outAmount = 0; }
                outAmount = abnormalvaginalbleeding + Urine + OtherOut;
                //sumtemp.In_item_value = inAmount == 0 ? "" : inAmount.ToString();//食物量
                //sumtemp.Out_otheritem_value = outAmount == 0 ? "" : outAmount.ToString();//出量总和 
                //if (Item_name.Contains("小结"))
                //{
                //    sumtemp.Abnormalvaginalbleeding = abnormalvaginalbleeding ==0 ? "" : abnormalvaginalbleeding.ToString();//阴道流血
                //    sumtemp.Urine = Urine == 0 ? "" : Urine.ToString();//尿液
                //    sumtemp.Out_otheritem_value = OtherOut == 0 ? "" : OtherOut.ToString();//其他
                //}
                //统计值为0的均不显示
                if (Item_name.Contains("总结"))
                {
                    if (inAmount > 0)
                    {
                        sumtemp.In_item_value = inAmount.ToString();
                    }
                    if (outAmount > 0)
                    {
                        sumtemp.Out_otheritem_value = outAmount.ToString();
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
                            case "阴道流血":
                                if (abnormalvaginalbleeding > 0)
                                {
                                    sumtemp.Abnormalvaginalbleeding = abnormalvaginalbleeding.ToString();
                                }
                                break;
                            case "尿液":
                                if (Urine > 0)
                                {
                                    sumtemp.Urine = Urine.ToString();
                                }
                                break;
                            case "其他":
                                if (OtherOut > 0)
                                {
                                    sumtemp.Out_otheritem_value = OtherOut.ToString();
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
                    Class_Nurse_Record_Obstetric temp_nuser = (Class_Nurse_Record_Obstetric)SumNusers[i];
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


        /// <summary>
        /// 重置计算出入量汇总
        /// </summary>
        private void SumInOrOutRecordSets()
        {

            #region old
            //SumNusersRecords.Clear();
            //string sql_date = "select * from t_nurse_dangery_inout_sum_h where patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O' order by end_time";
            //DataSet ds_sum_oper = App.GetDataSet(sql_date);

            //for (int i = 0; i < ds_sum_oper.Tables[0].Rows.Count; i++)
            //{
            //    //SumNusersRecords.Add(Convert.ToDateTime(ds_sum_oper.Tables[0].Rows[i]["start_time"]).ToString("yyyy-MM-dd HH:mm") + "," + Convert.ToDateTime(ds_sum_oper.Tables[0].Rows[i]["end_time"]).ToString("yyyy-MM-dd HH:mm") + "," + ds_sum_oper.Tables[0].Rows[i]["oper_method"].ToString().Replace("小时出入量", "h总结") + "," + ds_sum_oper.Tables[0].Rows[i]["ID"].ToString() + "," + ds_sum_oper.Tables[0].Rows[i]["seq_id"] + "," + ds_sum_oper.Tables[0].Rows[i]["SIGNATURE"] + "," + ds_sum_oper.Tables[0].Rows[i]["SUM_ITEM"]);
            //    SumNusersRecords.Add(Convert.ToDateTime(ds_sum_oper.Tables[0].Rows[i]["start_time"]).ToString("yyyy-MM-dd HH:mm") + "," + Convert.ToDateTime(ds_sum_oper.Tables[0].Rows[i]["end_time"]).ToString("yyyy-MM-dd HH:mm") + "," + ds_sum_oper.Tables[0].Rows[i]["oper_method"].ToString().Replace("小时出入量", "h总结") + ",0," + ds_sum_oper.Tables[0].Rows[i]["seq_id"] + "," + ds_sum_oper.Tables[0].Rows[i]["SIGNATURE"] + "," + ds_sum_oper.Tables[0].Rows[i]["SUM_ITEM"]);
            //}

            //for (int i1 = 0; i1 < SumNusersRecords.Count; i1++)
            //{
            //    string BeginTiem, EndTime, Item_name;
            //    string BeginedTiem, EndedTime;
            //    string Remaining = "0";//余液-
            //    string Remained = "0";//余液+
            //    string Eat = "";//食物
            //    string abnormalvaginalbleeding = "";//阴道流血
            //    string Urine = "";//尿液
            //    string OtherOut = "";//其他出量
            //    string Number = "";//号码
            //    string seq_id = "";//统计类型ID
            //    string LetFlow = "";//弃液
            //    double inAmount = 0;//入量总和
            //    double outAmount = 0;//出量总和
            //    string SIGNATURE = ""; //签名

            //    BeginTiem = SumNusersRecords[i1].ToString().Split(',')[0];
            //    EndTime = SumNusersRecords[i1].ToString().Split(',')[1];
            //    Item_name = SumNusersRecords[i1].ToString().Split(',')[2];
            //    Number = SumNusersRecords[i1].ToString().Split(',')[3];
            //    seq_id = SumNusersRecords[i1].ToString().Split(',')[4];
            //    SIGNATURE = SumNusersRecords[i1].ToString().Split(',')[5];
            //    string[] sum_item = SumNusersRecords[i1].ToString().Split(',')[6].Split('|');//统计项目
            //    //creatID = SumNusersRecords[i1].ToString().Split(',')[4];+ "," + ds_sum_oper.Tables[0].Rows[i]["CREAT_ID"].ToString()
            //    SumNusers.Clear();
            //    //日间,夜间的上一班次时间
            //    BeginedTiem = Convert.ToDateTime(EndTime).AddDays(-1).ToString("yyyy-MM-dd HH:mm");
            //    EndedTime = BeginTiem;

            //    Class_Nurse_Record_Obstetric sumtemp = new Class_Nurse_Record_Obstetric();

            //    string beginSgin = ">=";

            //    string endSgin = "<=";

            //    Class_Take_over_SEQ tempSeq = null;
            //    for (int i = 0; i < cboTiming.Items.Count; i++)
            //    {
            //        tempSeq = cboTiming.Items[i] as Class_Take_over_SEQ;
            //        if (tempSeq != null && tempSeq.Id == seq_id)
            //        {
            //            if (tempSeq.Begin_logic == "0")
            //            {
            //                beginSgin = ">";
            //            }
            //            if (tempSeq.End_logic == "0")
            //            {
            //                endSgin = "<";
            //            }
            //            break;
            //        }
            //    }


            //    ////入量总和
            //    //string SqlIn_1 = "select '入量总合' as ItemName,sum(a.item_value) as sumval from t_nurse_record a " +
            //    //       " where item_show_name='入量'  and other_name not like '%弃液%' " +
            //    //       "and MEASURE_TIME" + beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";
            //    ////弃液总和
            //    //string SqlIn_2 = "select '入量弃液' as ItemName,sum(a.item_value) as sumval from t_nurse_record a " +
            //    //       " where item_show_name='入量' and other_name like '%弃液%' " +
            //    //       " and MEASURE_TIME" + beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";

            //    ////阴道流血:非数字不统计
            //    //string SqlOut_1 = "select '阴道流血' as ItemName,sum(a.item_value) as sumval from t_nurse_record a where item_show_name like '%阴道%血%' and other_name is null and MEASURE_TIME" +
            //    //    beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";
            //    ////尿液
            //    //string SqlOut_2 = "select '尿液' as ItemName,sum(a.item_value) as sumval from t_nurse_record a where item_show_name like '%尿液%' and MEASURE_TIME" +
            //    //beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";

            //    ////其他
            //    //string SqlOut_3 = "select '其他' as ItemName,sum(a.item_value) as sumval from t_nurse_record a where item_show_name like '%其他%' and MEASURE_TIME" +
            //    //beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";
            //    //string Sql = SqlIn_1 + " union " + SqlIn_2 + " union " + SqlOut_1 + " union " + SqlOut_2 + " union " + SqlOut_3;

            //    //入量总和
            //    string SqlIn_1 = "select '入量总合' as ItemName,sum(a.item_value) as sumval from t_nurse_record a " +
            //           " where item_show_name='入量'  and other_name not like '%弃液%'  and other_name not like '%余液%' " +
            //           "and MEASURE_TIME" + beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";
            //    //弃液总和
            //    string SqlIn_2 = "select '入量弃液' as ItemName,sum(abs(a.item_value)) as sumval from t_nurse_record a " +
            //           " where item_show_name='入量' and other_name like '%弃液%' " +
            //           " and MEASURE_TIME" + beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";
            //    //当前统计时段余液总和
            //    string SqlIn_3 = "select '入量余液-' as ItemName,sum(abs(a.item_value)) as sumval from t_nurse_record a " +
            //           " where item_show_name='入量'  and other_name like '%余液%' " +
            //           @"and MEASURE_TIME" + beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" +
            //             endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";
            //    //上次统计时段余液总和
            //    string SqlIn_4 = "select '入量余液+' as ItemName,sum(abs(a.item_value)) as sumval from t_nurse_record a " +
            //           " where item_show_name='入量'  and other_name like '%余液%' " +
            //           @"and MEASURE_TIME>to_timestamp('" + BeginedTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME<=to_timestamp('" + EndedTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";

            //    //阴道流血:非数字不统计!
            //    string SqlOut_1 = "select '阴道流血' as ItemName,sum(a.item_value) as sumval from t_nurse_record a where item_show_name like '%阴道流血%' and other_name is null and MEASURE_TIME" +
            //        beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";
            //    //尿液
            //    string SqlOut_2 = "select '尿液' as ItemName,sum(a.item_value) as sumval from t_nurse_record a where item_show_name like '%尿液%' and MEASURE_TIME" +
            //        beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";
            //    //其他
            //    string SqlOut_3 = "select '其他' as ItemName,sum(a.item_value) as sumval from t_nurse_record a where item_show_name like '%其他%' and MEASURE_TIME" +
            //        beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";

            //    string SqlOut = "";

            //    foreach (string i in sum_item)
            //    {
            //        if (i != null && i != "")
            //        {
            //            if (i == "阴道流血")
            //                SqlOut += " union " + "select '" + i + "' as ItemName,sum(a.item_value) as sumval from t_nurse_record a where item_show_name like '%" + i + "%' and other_name is null and MEASURE_TIME" +
            //                    beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";
            //            else
            //                SqlOut += " union " + "select '" + i + "' as ItemName,sum(a.item_value) as sumval from t_nurse_record a where item_show_name like '%" + i + "%' and MEASURE_TIME" +
            //                    beginSgin + "to_timestamp('" + BeginTiem + "','syyyy-mm-dd hh24:mi:ss.ff9') and MEASURE_TIME" + endSgin + "to_timestamp('" + EndTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and  patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O'";
            //        }
            //        else
            //        {
            //            SqlOut = " union " + SqlOut_1 + " union " + SqlOut_2 + " union " + SqlOut_3;
            //        }
            //    }

            //    string Sql = "";
            //    if (Item_name.Contains("日间") || Item_name.Contains("夜间"))
            //    {
            //        Sql = SqlIn_1 + " union " + SqlIn_2 + " union " + SqlIn_3 + " union " + SqlIn_4 + SqlOut;//" union " + SqlOut_1 + " union " + SqlOut_2 + " union " + SqlOut_3;
            //    }
            //    else
            //    {
            //        Sql = SqlIn_1 + " union " + SqlIn_2 + SqlOut;// " union " + SqlOut_1 + " union " + SqlOut_2 + " union " + SqlOut_3;
            //    }
            //    DataSet ds = App.GetDataSet(Sql);

            //    sumtemp.DateTime = EndTime;
            //    sumtemp.In_item_name = Item_name;
            //    sumtemp.Number = Number;
            //    #region 统计赋值
            //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //    {
            //        if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("入量总合"))
            //        {
            //            if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
            //            {
            //                Eat = ds.Tables[0].Rows[i]["sumval"].ToString();
            //            }
            //            else
            //            {
            //                Eat = "0";
            //            }
            //        }
            //        else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("入量弃液"))
            //        {
            //            if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
            //            {
            //                LetFlow = ds.Tables[0].Rows[i]["sumval"].ToString();
            //            }
            //            else
            //            {
            //                LetFlow = "0";
            //            }
            //        }
            //        else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("入量余液-"))
            //        {
            //            if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
            //            {
            //                Remaining = ds.Tables[0].Rows[i]["sumval"].ToString();
            //            }
            //            else
            //            {
            //                Remaining = "0";
            //            }
            //        }
            //        else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("入量余液+"))
            //        {
            //            if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
            //            {
            //                Remained = ds.Tables[0].Rows[i]["sumval"].ToString();
            //            }
            //            else
            //            {
            //                Remained = "0";
            //            }
            //        }
            //        else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("阴道流血"))
            //        {
            //            if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
            //            {
            //                abnormalvaginalbleeding = ds.Tables[0].Rows[i]["sumval"].ToString();
            //            }
            //            else
            //            {
            //                abnormalvaginalbleeding = "0";
            //            }
            //        }
            //        else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("尿液"))
            //        {
            //            if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
            //            {
            //                Urine = ds.Tables[0].Rows[i]["sumval"].ToString();
            //            }
            //            else
            //            {
            //                Urine = "0";
            //            }
            //        }
            //        else if (ds.Tables[0].Rows[i]["ItemName"].ToString().Contains("其他"))
            //        {
            //            if (ds.Tables[0].Rows[i]["sumval"].ToString() != "")
            //            {
            //                OtherOut = ds.Tables[0].Rows[i]["sumval"].ToString();
            //            }
            //            else
            //            {
            //                OtherOut = "0";
            //            }
            //        }
            //    }
            //    #endregion
            //    //计算入量总和
            //    try
            //    {
            //        inAmount = Convert.ToDouble(Eat) - Math.Abs(Convert.ToDouble(LetFlow)) - Math.Abs(Convert.ToDouble(Remaining)) + Math.Abs(Convert.ToDouble(Remained));
            //    }
            //    catch (Exception) { inAmount = 0; }
            //    //计算出量总和
            //    try
            //    {
            //        outAmount = Convert.ToDouble(abnormalvaginalbleeding) + Convert.ToDouble(Urine) + Convert.ToDouble(OtherOut);
            //    }
            //    catch (Exception) { outAmount = 0; }

            //    sumtemp.In_item_value = inAmount == 0 ? "" : inAmount.ToString();//食物量
            //    sumtemp.Out_otheritem_value = outAmount == 0 ? "" : outAmount.ToString();//出量总和 
            //    if (Item_name.Contains("小结"))
            //    {
            //        sumtemp.Abnormalvaginalbleeding = abnormalvaginalbleeding == "0" ? "" : abnormalvaginalbleeding;//阴道流血
            //        sumtemp.Urine = Urine == "0" ? "" : Urine;//尿液
            //        sumtemp.Out_otheritem_value = OtherOut == "0" ? "" : OtherOut;//其他
            //    }
            //    if (SIGNATURE == "")
            //    {
            //        if (App.UserAccount.UserInfo != null)
            //            sumtemp.Signature = App.UserAccount.UserInfo.User_name;//签名
            //    }
            //    else
            //    {
            //        sumtemp.Signature = SIGNATURE;//签名
            //    }
            //    DateTime TempDate = new DateTime();
            //    bool flag = false;//汇总对象是否已添加标志

            //    if (nurses.Count == 0)
            //    {
            //        SumNusers.Add(sumtemp);
            //    }
            //    //将汇总记录插到对象集合中去
            //    for (int i = 0; i < nurses.Count; i++)
            //    {
            //        SumNusers.Add(nurses[i]);
            //    }

            //    for (int i = 0; i < nurses.Count; i++)
            //    {
            //        Class_Nurse_Record_Obstetric temp_nuser = (Class_Nurse_Record_Obstetric)SumNusers[i];
            //        if (temp_nuser.DateTime != null)
            //        {
            //            TempDate = Convert.ToDateTime(temp_nuser.DateTime);

            //            if (TempDate == Convert.ToDateTime(EndTime))
            //            {
            //                if (tempSeq != null && tempSeq.End_logic == "0")//结束标记为“0”，汇总插到相同时间点的项目之前
            //                {
            //                    SumNusers.Insert(i, sumtemp);
            //                    break;
            //                }
            //            }
            //            else if (TempDate > Convert.ToDateTime(EndTime))//汇总时间小于当前录入时间，插到这条项目之前
            //            {
            //                SumNusers.Insert(i, sumtemp);
            //                break;
            //            }
            //        }
            //        if (i == SumNusers.Count - 1)
            //        {
            //            SumNusers.Add(sumtemp);
            //            break;
            //        }
            //    }

            //    nurses.Clear();
            //    for (int i = 0; i < SumNusers.Count; i++)
            //    {
            //        nurses.Add(SumNusers[i]);
            //    }


            //}
            #endregion

            SumInOrOutRecordSet(false);
        }

        #endregion

        private void 添加空行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flgView.Rows.Insert(flgView.RowSel);
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
                    string del = "";//删除语句


                    if (flgView.Col == 7)
                    {
                        itemName = "入量";
                    }
                    //int isIN = 0;
                    int id = 0;
                    if (itemName == "入量")
                    {
                        otherName = flgView[flgView.Row, 7].ToString();
                        if (flgView[flgView.Row, 25] != null && flgView[flgView.Row, 25].ToString().Length>0)
                        {
                            try
                            {
                                id = int.Parse(flgView[flgView.Row, 25].ToString());
                            }
                            catch{}
                        }
                        //if (id == 0)
                        //{
                        //    isIN = Convert.ToInt32(App.ReadSqlVal("select count(*) from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and item_show_name='" + itemName + "' and other_name='" + otherName + "' and RECORD_TYPE='O' and patient_id=" + currentPatient.Id, 0, "count(*)"));
                        //}
                    }

                    if (id == 0 && flgView[flgView.Row, 7] != null && (flgView[flgView.Row, 7].ToString().Contains("小结") || flgView[flgView.Row, 7].ToString().Contains("总结") || flgView[flgView.Row, 7].ToString().Contains("出入量")))//删除汇总
                    {
                        string signature = App.ReadSqlVal("select signature from t_nurse_dangery_inout_sum_h where oper_method='" + flgView[flgView.Row, 12].ToString() + "' and RECORD_TYPE='O' and end_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and patient_id=" + currentPatient.Id, 0, "signature");
                        if (App.UserAccount.UserInfo.User_name == signature || signature == null || signature == "" || App.UserAccount.CurrentSelectRole.Role_name.Equals("护士长"))
                        {
                            del = "delete from t_nurse_dangery_inout_sum_h where oper_method='" + flgView[flgView.Row, 7].ToString() + "' and end_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and patient_id=" + currentPatient.Id;
                        }
                        else
                        {
                            App.Msg("权限不足！");
                            return;
                        }
                        
                    }
                    else
                    {
                        if (itemName == "入量")
                        {
                            if (flgView[flgView.Row, 7] != null)
                            {
                                otherName = flgView[flgView.Row, 7].ToString();
                            }
                            else
                            {
                                otherName = flgView[flgView.Row, 7].ToString();
                            }

                        }
                        if (itemName == "名称" || itemName == "情况")
                        {
                            int ireturn=0;
                            otherName = GetOtherName(flgView.Row, ref ireturn).ToString();
                        }
                        //else if (itemName == "吸氧")
                        //{
                        //    otherName = ldXY[flgView[flgView.Row, 26]].ToString();
                        //}
                        if (flgView.Col != 0)//删除单独项
                        {
                            if (otherName == "")
                            {
                                string operateId = App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and item_show_name='" + itemName + "' and patient_id=" + currentPatient.Id, 0, "creat_id");
                                if (App.UserAccount.UserInfo.User_id == operateId || App.UserAccount.CurrentSelectRole.Role_name.Equals("护士长"))
                                {
                                    del = "delete from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and item_show_name='" + itemName + "' and patient_id=" + currentPatient.Id;
                                }
                                else
                                {
                                    App.Msg("权限不足！");
                                    return;
                                }
                            }
                            else
                            {
                                if (id > 0)
                                {
                                    string operateId = App.ReadSqlVal("select creat_id from t_nurse_record where id="+id, 0, "creat_id");
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
                                else
                                {
                                    string operateId = App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and item_show_name='" + itemName + "' and other_name='" + otherName + "' and patient_id=" + currentPatient.Id, 0, "creat_id");
                                    if (App.UserAccount.UserInfo.User_id == operateId || App.UserAccount.CurrentSelectRole.Role_name.Equals("护士长"))
                                    {
                                        del = "delete from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and item_show_name='" + itemName + "' and other_name='" + otherName + "' and patient_id=" + currentPatient.Id;
                                        if (otherName == "1")
                                        {
                                            del = "delete from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and item_show_name='" + itemName + "' and (other_name='" + otherName + "' or other_name is null) and patient_id=" + currentPatient.Id;
                                        }
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
                            //string operateId = App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and patient_id=" + currentPatient.Id, 0, "creat_id");
                            if (id > 0)
                            {
                                string operateId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where id=" + id + " order by id", 0, "creat_id"));
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
                            else
                            {
                                string operateId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and patient_id=" + currentPatient.Id + " and rownum=1 order by id", 0, "creat_id"));
                                if (App.UserAccount.UserInfo.User_id == operateId || App.UserAccount.CurrentSelectRole.Role_name.Equals("护士长"))
                                {
                                    del = "delete from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and patient_id=" + currentPatient.Id;
                                }
                                else
                                {
                                    App.Msg("权限不足！");
                                    return;
                                }
                            }
                        }
                    }


                    int num = App.ExecuteSQL(del);
                    if (num > 0)
                    {
                        operateFlag = true;
                        timer1.Start();
                        //App.Msg("删除成功！");
                        //更新创建者
                        //App.ExecuteSQL("update t_nurse_record set creat_id='" + App.UserAccount.UserInfo.User_id + "'，create_time=sysdate, update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and patient_id=" + currentPatient.Id);
                        //App.ExecuteSQL("update t_nurse_record set  update_id='" + App.UserAccount.UserInfo.User_id + "',update_time=sysdate where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and patient_id=" + currentPatient.Id);
                        btnSearch_Click(sender, e);
                    }
                }
                else
                {
                    if (flgView[flgView.Row, 0] == null)
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
            string sql_time = "select distinct to_char(t.measure_time,'yyyy-mm-dd hh24:mi') as DATETIMEVAL from T_NURSE_RECORD t where t.patient_Id=" + currentPatient.Id + " and RECORD_TYPE='O' order by DATETIMEVAL asc";
            DataSet ds_Time = App.GetDataSet(sql_time);
            if (ds_Time != null)
            {
                for (int i = 0; i < ds_Time.Tables[0].Rows.Count; i++)
                {                   
                    ArrayList drDatarows = new ArrayList();
                    for (int i1 = 0; i1 < ds.Tables[0].Rows.Count; i1++)
                    {
                        if (!ds.Tables[0].Rows[i1]["in_item_name"].ToString().Contains("小结") &&
                           !ds.Tables[0].Rows[i1]["in_item_name"].ToString().Contains("出入量") &&
                           !ds.Tables[0].Rows[i1]["in_item_name"].ToString().Contains("总结"))
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

            DataRow[] drSum = ds.Tables[0].Select("in_item_name like '%出入量%' or in_item_name like '%小结%' or in_item_name like '%总结%'");
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
                        if (i % 17 == 0)
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
            int remarkRowCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(strlength) / 39));//Convert.ToInt32(sizeF.Width / (28.3465 * 8)) < (sizeF.Width / (28.3465 * 8)) ? Convert.ToInt32(sizeF.Width / (28.3465 * 8)) + 1 : Convert.ToInt32(sizeF.Width / (28.3465 * 8));
            string[] strArr = new string[remarkRowCount];
            string tempperval = "";
            int index = 0;//数组递增索引
            for (int j = 0; j < remark.Length; j++)
            {
                strlength = System.Text.Encoding.Default.GetBytes(tempperval).Length;
                if (strlength < 39 || (strlength == 39 && System.Text.Encoding.Default.GetBytes(remark[j].ToString()).Length!=2))
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
            //Graphics graphics = CreateGraphics();
            //SizeF sizeF = graphics.MeasureString(remark, new Font("宋体", 8));
            ////备注所占行数
            //int remarkRowCount = Convert.ToInt32(Math.Ceiling(sizeF.Width / (45 * 8)));//28.3465 * 8.3Convert.ToInt32(sizeF.Width / (28.3465 * 8)) < (sizeF.Width / (28.3465 * 8)) ? Convert.ToInt32(sizeF.Width / (28.3465 * 8)) + 1 : Convert.ToInt32(sizeF.Width / (28.3465 * 8));
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
                diagnose = App.ReadSqlVal("select diagnose_name from T_NURSE_RECORD where Patient_Id =" + currentPatient.Id + "  and RECORD_TYPE='O'", 0, "diagnose_name");//自己修改的护理
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

            DataSet dsResault=ReSetPrintDataSet(ds);

         
            //ArrayList datalist=new ArrayList();
            for (int i = 0; i < dsResault.Tables[0].Rows.Count;i++)
            {  
                string val="";
                if (dsResault.Tables[0].Rows[i]["Fetal_heart_sound"] != null)
                {
                    val = dsResault.Tables[0].Rows[i]["Fetal_heart_sound"].ToString();
                }

                Image _Image = DrawValueImage(val);

                
                System.IO.MemoryStream _ImageMem = new System.IO.MemoryStream();
                _Image.Save(_ImageMem, ImageFormat.Png);
                byte[] _ImageBytes = _ImageMem.GetBuffer();
                dsResault.Tables[0].Rows[i]["Fetal_heart_sound"] = System.Convert.ToBase64String(_ImageBytes);
            }         
            frmNursePrint_Records ff = new frmNursePrint_Records(dsResault,diagnose, currentPatient, "O");
            ff.Show();
        }

        private void 修改项目名toolStripMenuItem_Click(object sender, EventArgs e)
        {
            string measureTime = GetTime(flgView.Row);
            C1.Win.C1FlexGrid.RowColEventArgs c1e = e as C1.Win.C1FlexGrid.RowColEventArgs;
            string titleName = "";
            if (flgView[flgView.Row, flgView.Col]!=null)
                titleName = flgView[flgView.Row, flgView.Col].ToString();
            frmModifyProjectTitle frm = new frmModifyProjectTitle(titleName,"N");
            frm.ShowDialog();
            if (frm.flag)
            {
                //取当前日期时间最早的创建者id
                string userId = "";
                try
                {
                    userId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and patient_id=" + currentPatient.Id + " and rownum=1 order by id", 0, "creat_id"));
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
                                   "( '" + currentPatient.Sick_Bed_Name + "', '" + currentPatient.PId + "', to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9'), '" + frm.tName + "', '" + userId + "', sysdate, " + currentPatient.Id + ", '入量','" + frm.tName + "','O')";                    

                //更新入量项目的名字               
                if (flgView[flgView.Row, flgView.Col]!=null)
                {
                    if (flgView[flgView.Row, flgView.Col].ToString().Trim() != "")
                    {
                        if (ValidateUser(userId))
                        {
                            sql = "update t_nurse_record set item_code='" + frm.tName + "',other_name='" + frm.tName + "' where patient_id=" + currentPatient.Id + " and item_show_name like '%入量%' and RECORD_TYPE='O' and measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9')";                   
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

        private void flgView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (flgView[flgView.Row, 0] != null)
            {
                if (flgView.Row >= 3 && flgView.Col == 14)
                {
                    string measureTime = GetTime(flgView.Row);
                    string operateId = Convert.ToString(App.ReadSqlVal("select creat_id from t_nurse_record where measure_time=to_timestamp('" + measureTime + "','syyyy-mm-dd hh24:mi:ss.ff9') and RECORD_TYPE='O' and patient_id=" + currentPatient.Id + " and rownum=1 order by id", 0, "creat_id"));
                    if (!ValidateUser(operateId) && operateId!=null)
                    {
                        App.Msg("修改权限不够!");
                        btnSearch_Click(sender, e);
                        return;
                    }
                    frmFormula fc = new frmFormula(currentPatient, measureTime, dictColumnName[14]);
                    fc.ShowDialog();
                    if (fc.successflag)
                    {
                        SetTable();
                        oldInAmountName = "";
                        ShowData();
                        SumInOrOutRecordSet(true);
                        ShowSumDataGrid();
                        CellUnit(pipe1, pipe2, pipe3, pipe4);
                    }
                }
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// 提取模版
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 提取备注模版ToolStripMenuItem_Click(object sender, EventArgs e)
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

        /// <summary>
        /// 添加模版
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 添加备注模版toolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (flgView[flgView.Row, flgView.Col] != null)
            {
                Base_Function.BLL_NURSE.NurseTemplate.frmTemplateAdd fc = new Base_Function.BLL_NURSE.NurseTemplate.frmTemplateAdd(flgView[flgView.Row, flgView.Col].ToString());
                fc.ShowDialog();
            }
        }

        private int PageRowCount = 17;
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

    }
}
