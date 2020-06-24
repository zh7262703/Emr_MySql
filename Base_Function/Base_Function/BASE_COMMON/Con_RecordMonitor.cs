using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using Bifrost;
using System.Windows.Forms;
using System.Drawing;
using Base_Function.BLL_MANAGEMENT;

namespace Base_Function.BASE_COMMON
{
    public class Con_RecordMonitor
    {
        public delegate void DisplayCommboBoxValue(ComboBox combox, string name);
        
        public event DisplayCommboBoxValue ShowCommboBox;

        private DataSet DS_QUALITYTABLE = null;


        private bool IsHaveGroup(string GroupName, ListView lstMontior)
        {           
            bool flag = false;
            try
            {
                for (int i = 0; i < lstMontior.Groups.Count; i++)
                {
                    if (GroupName.Trim() == lstMontior.Groups[i].Header.Trim())
                    {
                        flag = true;
                    }
                }
                return flag;
            }
            catch
            {
                return flag;
            }
        }
        
#region
        /// <summary>
        /// 初始化数据--HLB
        /// </summary>        
        //public void InitFlexGrid(ListView lstMontior,string sqlSel,ComboBox comboxSA,string flag,ListView lstCount,string sqlCount)
        //{

        //    try
        //    {
        //        float x = 20;
        //        float y = 20;
        //        ArrayList tempList = new ArrayList();
        //        ImageList imaList = lstMontior.SmallImageList;
        //        ImageList imgState = lstMontior.StateImageList;
        //        //红灯
        //        Image img1 = imgState.Images[0];
        //        //黄灯
        //        Image img2 = imgState.Images[1];
        //        imaList.Images.Clear();
        //        //imaList.Images.Add(img1);
        //        //imaList.Images.Add(img2);
        //        //Image.GetThumbnailImageAbort imgAbort = new Image.GetThumbnailImageAbort(GetImg);
        //        //imaList.Images.Clear();
        //        //imaList.Images.Add(img1.GetThumbnailImage(100,20,imgAbort,IntPtr.Zero));
        //        //imaList.Images.Add(img2.GetThumbnailImage(100,20,imgAbort,IntPtr.Zero));
        //        //imaList.Images.Clear();
        //        Class_Table[] table = new Class_Table[2];

        //        table[0] = new Class_Table();
        //        table[0].Sql = sqlSel;
        //        table[0].Tablename = "sqlSel";

        //        table[1] = new Class_Table();
        //        table[1].Sql = sqlCount;
        //        table[1].Tablename = "sqlCount";
        //        DS_QUALITYTABLE = App.GetDataSet(table);

        //        DataSet dataSet = DS_QUALITYTABLE;

        //        ListViewItem[] item = new ListViewItem[dataSet.Tables[0].Rows.Count];
        //        Class_Record_Monitor_View[] crmv = new Class_Record_Monitor_View[dataSet.Tables[0].Rows.Count];
        //        if (dataSet.Tables["sqlSel"] != null)
        //        {
        //            if (flag == "HLB")
        //            {
        //                //加载病区组
        //                for (int i = 0; i < dataSet.Tables["sqlSel"].Rows.Count; i++)
        //                {
        //                    if (!IsHaveGroup(dataSet.Tables["sqlSel"].Rows[i]["SICK_AREA_NAME"].ToString(), lstMontior))
        //                    {
        //                        ListViewGroup tempGroup = new ListViewGroup();
        //                        tempGroup.Header = dataSet.Tables["sqlSel"].Rows[i]["SICK_AREA_NAME"].ToString();
        //                        tempGroup.Name = dataSet.Tables["sqlSel"].Rows[i]["SICK_AREA_NAME"].ToString();
        //                        //if (comboxSA.Text != tempGroup.Name)
        //                        //{
        //                        //    ShowCommboBoxValue(comboxSA, tempGroup.Name);//病区名字
        //                        //}

                              
        //                        lstMontior.Groups.Add(tempGroup);
        //                    }
        //                }

        //                for (int i = 0; i < dataSet.Tables["sqlSel"].Rows.Count; i++)
        //                {
        //                    crmv[i] = new Class_Record_Monitor_View();
        //                    crmv[i].SickArea_ID = dataSet.Tables["sqlSel"].Rows[i]["SICK_AREA_ID"].ToString();
        //                    crmv[i].SickArea_Name = dataSet.Tables["sqlSel"].Rows[i]["SICK_AREA_NAME"].ToString();
        //                    crmv[i].DocType = dataSet.Tables["sqlSel"].Rows[i]["DOCTYPE"].ToString();
        //                    crmv[i].Num = Convert.ToInt32(dataSet.Tables["sqlSel"].Rows[i]["NUM"].ToString());
        //                    crmv[i].PV = Convert.ToInt32(dataSet.Tables["sqlSel"].Rows[i]["PV"].ToString());

        //                    ListViewItem tempItem = new ListViewItem();
        //                    tempItem.Tag = crmv[i];
        //                    tempItem.Name = crmv[i].DocType;
        //                    tempItem.Text = crmv[i].DocType + "[" + crmv[i].Num.ToString() + "]";

        //                    if (crmv[i].PV == 0)
        //                    {
        //                        tempItem.ImageIndex = 1;
        //                    }
        //                    else
        //                    {
        //                        tempItem.ImageIndex = 0;
        //                    }
        //                    tempItem.Group = lstMontior.Groups[crmv[i].SickArea_Name];

        //                    lstMontior.Items.Add(tempItem);
        //                }
        //                ListViewGroup CountGroup = new ListViewGroup();
        //                CountGroup.Header = "统计列表";
        //                CountGroup.Name = "统计列表";
        //                lstCount.Groups.Add(CountGroup);

        //                if (dataSet.Tables["sqlCount"] != null)
        //                {
        //                    for (int i = 0; i < dataSet.Tables["sqlCount"].Rows.Count; i++)
        //                    {
        //                        crmv[i] = new Class_Record_Monitor_View();

        //                        crmv[i].DocType = dataSet.Tables["sqlCount"].Rows[i]["DOCTYPE"].ToString();
        //                        crmv[i].Num = Convert.ToInt32(dataSet.Tables["sqlCount"].Rows[i]["NUM"].ToString());
        //                        crmv[i].PV = Convert.ToInt32(dataSet.Tables["sqlCount"].Rows[i]["PV"].ToString());

        //                        ListViewItem tempItem = new ListViewItem();
        //                        tempItem.Tag = crmv[i];
        //                        tempItem.Name = crmv[i].DocType;
        //                        tempItem.Text = crmv[i].DocType + "[" + crmv[i].Num.ToString() + "]";
                                


        //                        if (crmv[i].PV == 0)
        //                        {
        //                            tempItem.ImageIndex = 1;
        //                        }
        //                        else
        //                        {
        //                            tempItem.ImageIndex = 0;
        //                        }
        //                        tempItem.Group = lstCount.Groups["统计列表"];
                                
        //                        lstCount.Items.Add(tempItem);
        //                    }

        //                }
        //            }

        //            if (flag == "YWC")
        //            {
        //                //加载科室组
        //                for (int i = 0; i < dataSet.Tables["sqlSel"].Rows.Count; i++)
        //                {
        //                    //!IsHaveGroup(dataSet.Tables["sqlSel"].Rows[i]["SECTION_NAME"].ToString(), lstMontior)
        //                    if (lstMontior.Items.Count == 0)
        //                    {
        //                        ListViewGroup tempGroup = new ListViewGroup();
        //                        tempGroup.Header = dataSet.Tables["sqlSel"].Rows[i]["SECTION_NAME"].ToString();
        //                        tempGroup.Name = dataSet.Tables["sqlSel"].Rows[i]["SECTION_NAME"].ToString();
        //                        //if (comboxSA.Text != tempGroup.Name)
        //                        //{
        //                        //    ShowCommboBoxValue(comboxSA, tempGroup.Name);//病区名字
        //                        //}
                                
        //                        lstMontior.Groups.Add(tempGroup);
        //                    }
        //                }

        //                //string sql = "select doctype,count(*) as num from record_monitor_view_ywc group by doctype,section_id having count(*) > 1";
        //                //DataSet ds = App.GetDataSet(sql);
        //                for (int i = 0; i < dataSet.Tables["sqlSel"].Rows.Count; i++)
        //                {                          
                           
        //                    crmv[i] = new Class_Record_Monitor_View();
        //                    crmv[i].SickArea_ID = dataSet.Tables["sqlSel"].Rows[i]["SECTION_ID"].ToString();
        //                    crmv[i].SickArea_Name = dataSet.Tables["sqlSel"].Rows[i]["SECTION_NAME"].ToString();
        //                    crmv[i].DocType = dataSet.Tables["sqlSel"].Rows[i]["DOCTYPE"].ToString();
        //                    crmv[i].Num = Convert.ToInt32(dataSet.Tables["sqlSel"].Rows[i]["NUM"].ToString());
        //                    crmv[i].PV = Convert.ToInt32(dataSet.Tables["sqlSel"].Rows[i]["PV"].ToString());

        //                    int onePv = crmv[i].PV;
        //                    int oneNum = crmv[i].Num;
        //                    string text = crmv[i].DocType;
        //                    //取反条件
        //                    int intPv = onePv == 1 ? 0 : 1;
        //                    string swithcs = "SECTION_ID='" + crmv[i].SickArea_ID + "' and DOCTYPE='" +
        //                                     crmv[i].DocType + "' and PV='"+intPv+"'";
        //                    DataRow[] rows = dataSet.Tables["sqlSel"].Select(swithcs);
        //                    int otherPv = 0;
        //                    int otherNum = 0;
        //                    if (rows.Length > 0) //相同的文书
        //                    {
        //                        //i++;
        //                        //crmv[i] = new Class_Record_Monitor_View();
        //                        //crmv[i].SickArea_ID = rows[0]["SECTION_ID"].ToString();
        //                        //crmv[i].SickArea_Name = rows[0]["SECTION_NAME"].ToString();
        //                        //crmv[i].DocType = rows[0]["DOCTYPE"].ToString();
        //                        //crmv[i].Num =
        //                        //crmv[i].PV = 
        //                        otherNum = Convert.ToInt32(rows[0]["NUM"].ToString());
        //                        otherPv = Convert.ToInt32(rows[0]["PV"].ToString());
        //                        dataSet.Tables["sqlSel"].Rows.Remove(rows[0]);
        //                    }

        //                    ListViewItem tempItem = new ListViewItem();

        //                    tempItem.Tag = crmv[i];
        //                    tempItem.Name = crmv[i].DocType;
        //                    if (rows.Length > 0)
        //                    {
        //                        int imgIndex1 = onePv == 0 ? 1 : 0;
        //                        int imgIndex2 = otherPv == 0 ? 1 : 0;
        //                        Image img;
        //                        if (imgIndex1 == 1)
        //                        {
        //                            img = CreateImage(oneNum, otherNum, img2, img1);
                                    
        //                        }
        //                        else
        //                        {
        //                            img = CreateImage(otherNum,oneNum , img1, img2);
        //                        }
        //                        imaList.Images.Add(tempItem.Name, img);
                                
        //                        tempItem.ImageKey = tempItem.Name;
        //                        tempItem.Text = text;
        //                    }
        //                    else
        //                    {
        //                    //    if (onePv == 0)
        //                    //    {
        //                    //        tempItem.StateImageIndex = 1;//黄灯  
        //                    //    }
        //                    //    else
        //                    //    {
        //                    //        tempItem.StateImageIndex = 0;//红灯
        //                    //    }
        //                        Image imgOne;
        //                        if (onePv == 0)
        //                        {
        //                            imgOne = CreateImage(oneNum, img2);
                                    
        //                        }
        //                        else
        //                        {
        //                            imgOne = CreateImage(oneNum, img1);
        //                        }
        //                        imaList.Images.Add(tempItem.Name, imgOne);
                                
        //                        tempItem.ImageKey = tempItem.Name;
        //                        tempItem.Text = text;
        //                        //tempItem.Text = crmv[i].DocType + "[" + crmv[i].Num.ToString() + "]";
        //                    }

                            
        //                    tempItem.Group = lstMontior.Groups[crmv[i].SickArea_Name];
        //                    lstMontior.Items.Add(tempItem);
        //                }

        //                ListViewGroup CountGroup = new ListViewGroup();
        //                CountGroup.Header = "统计列表";
        //                CountGroup.Name = "统计列表";
        //                lstCount.Groups.Add(CountGroup);

        //                if (dataSet.Tables["sqlCount"] != null)
        //                {
        //                    for (int i = 0; i < dataSet.Tables["sqlCount"].Rows.Count; i++)
        //                    {
        //                        crmv[i] = new Class_Record_Monitor_View();
                              
        //                        crmv[i].DocType = dataSet.Tables["sqlCount"].Rows[i]["DOCTYPE"].ToString();
        //                        crmv[i].Num = Convert.ToInt32(dataSet.Tables["sqlCount"].Rows[i]["NUM"].ToString());
        //                        crmv[i].PV = Convert.ToInt32(dataSet.Tables["sqlCount"].Rows[i]["PV"].ToString());

        //                        ListViewItem tempItem = new ListViewItem();
        //                        tempItem.Tag = crmv[i];
        //                        tempItem.Name = crmv[i].DocType;
        //                        tempItem.Text = crmv[i].DocType + "[" + crmv[i].Num.ToString() + "]";


        //                        if (crmv[i].PV == 0)
        //                        {
        //                            tempItem.ImageIndex = 1;//黄灯
        //                        }
        //                        else
        //                        {
        //                            tempItem.ImageIndex = 0;//红灯
        //                        }
        //                        tempItem.Group = lstCount.Groups["统计列表"];

        //                        lstCount.Items.Add(tempItem);
        //                    }

        //                }
        //            }
        //        }
        //    }
        //    catch
        //    { }
        //}

           /// <summary>
        /// 初始化数据--HLB
        /// </summary>        
        
        //public void InitFlexGrid(Panel GbxMontior, string sqlSel, ComboBox comboxSA, string flag, ListView lstCount, string sqlCount)
        //{
        //    GbxMontior.Controls.Clear();

        //        Class_Table[] table = new Class_Table[2];

        //        table[0] = new Class_Table();
        //        table[0].Sql = sqlSel;
        //        table[0].Tablename = "sqlSel";

        //        table[1] = new Class_Table();
        //        table[1].Sql = sqlCount;
        //        table[1].Tablename = "sqlCount";
        //        DS_QUALITYTABLE = App.GetDataSet(table);

        //        DataSet dataSet = DS_QUALITYTABLE;
        //        Class_Record_Monitor_View[] crmv=null;
        //        if (dataSet.Tables[0].Rows.Count > 0)
        //        {
        //            crmv = new Class_Record_Monitor_View[dataSet.Tables[0].Rows.Count];
        //        }
        //        else
        //        {
        //            return;
        //        }
        //        if (dataSet.Tables["sqlSel"] != null)
        //        {
        //            Class_Record_Monitor_View[] crmv1 = new Class_Record_Monitor_View[dataSet.Tables["sqlSel"].Rows.Count];
        //            //using (Graphics gh = Graphics.FromHwnd(GbxMontior.Handle))
        //            //{
        //                string section_name = string.Empty;
        //                bool isLine = false;
        //                for (int j = 0; j < dataSet.Tables["sqlSel"].Rows.Count; j++)
        //                {

        //                    crmv1[j] = new Class_Record_Monitor_View();
        //                    crmv1[j].SickArea_ID = dataSet.Tables["sqlSel"].Rows[j]["SECTION_ID"].ToString();
        //                    crmv1[j].SickArea_Name = dataSet.Tables["sqlSel"].Rows[j]["SECTION_NAME"].ToString();
        //                    crmv1[j].DocType = dataSet.Tables["sqlSel"].Rows[j]["DOCTYPE"].ToString();
        //                    crmv1[j].Num = Convert.ToInt32(dataSet.Tables["sqlSel"].Rows[j]["NUM"].ToString());
        //                    crmv1[j].PV = Convert.ToInt32(dataSet.Tables["sqlSel"].Rows[j]["PV"].ToString());
        //                    int onePv = crmv1[j].PV;
        //                    int oneNum = crmv1[j].Num;
        //                    string text = crmv1[j].DocType;
        //                    //取反条件
        //                    int intPv = onePv == 1 ? 0 : 1;
        //                    string swithcs = "SECTION_ID='" + crmv1[j].SickArea_ID + "' and DOCTYPE='" +
        //                                        crmv1[j].DocType + "' and PV='" + intPv + "'";
        //                    DataRow[] rows = dataSet.Tables["sqlSel"].Select(swithcs);
        //                    int otherPv = 0;
        //                    int otherNum = 0;
        //                    UserControl uc;
        //                    if (rows.Length > 0) //相同的文书
        //                    {
        //                        otherNum = Convert.ToInt32(rows[0]["NUM"].ToString());
        //                        otherPv = Convert.ToInt32(rows[0]["PV"].ToString());
        //                        dataSet.Tables["sqlSel"].Rows.Remove(rows[0]);
        //                        Image red = lstCount.SmallImageList.Images[0];
        //                        Image yellow = lstCount.SmallImageList.Images[1];
        //                        if (onePv == 0)//黄灯
        //                        {
        //                            uc = new UcMerger(text, oneNum, yellow, otherNum, red, flag);
        //                            //uc = new PbMerger(text, oneNum, yellow, otherNum, red);
        //                        }
        //                        else
        //                        {
        //                            uc = new UcMerger(text, otherNum, yellow, oneNum, red, flag);
        //                            //uc = new PbMerger(text, oneNum, yellow, otherNum, red);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        Image img;
        //                        if (onePv == 0)//黄灯
        //                        {
        //                            img = lstCount.SmallImageList.Images[1];
        //                        }
        //                        else
        //                        {
        //                            img = lstCount.SmallImageList.Images[0];
        //                        }
        //                        uc = new UcLight(text, oneNum, img, flag);
        //                        //uc = new PbLight(text, oneNum, img);
        //                    }
        //                    uc.Tag = crmv1[j];
        //                    if (section_name != crmv1[j].SickArea_Name)
        //                    {
        //                        if (!string.IsNullOrEmpty(crmv1[j].SickArea_Name))
        //                        {
        //                            section_name = crmv1[j].SickArea_Name;
        //                            Label lbl = new Label();
        //                            lbl.Text = section_name;
        //                            lbl.ForeColor = Color.Blue;
        //                            GbxMontior.Controls.Add(lbl);
        //                            //AddUcontrol(GbxMontior, uc, section_name);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        //AddUcontrol(GbxMontior, uc);
        //                    }
        //                    GbxMontior.Controls.Add(uc);
        //                }
        //            //}
        //        }
        //        GbxMontior.Refresh();
        //        ListViewGroup CountGroup = new ListViewGroup();
        //        CountGroup.Header = "统计列表";
        //        CountGroup.Name = "统计列表";
        //        lstCount.Groups.Add(CountGroup);

        //        if (dataSet.Tables["sqlCount"] != null)
        //        {
        //            Class_Record_Monitor_View[] crmv1 = new Class_Record_Monitor_View[dataSet.Tables["sqlCount"].Rows.Count];
        //            for (int i = 0; i < dataSet.Tables["sqlCount"].Rows.Count; i++)
        //            {
        //                crmv1[i] = new Class_Record_Monitor_View();

        //                crmv1[i].DocType = dataSet.Tables["sqlCount"].Rows[i]["DOCTYPE"].ToString();
        //                crmv1[i].Num = Convert.ToInt32(dataSet.Tables["sqlCount"].Rows[i]["NUM"].ToString());
        //                crmv1[i].PV = Convert.ToInt32(dataSet.Tables["sqlCount"].Rows[i]["PV"].ToString());

        //                ListViewItem tempItem = new ListViewItem();
        //                tempItem.Tag = crmv1[i];
        //                tempItem.Name = crmv1[i].DocType;
        //                tempItem.Text = crmv1[i].DocType + "[" + crmv1[i].Num.ToString() + "]";


        //                if (crmv1[i].PV == 0)
        //                {
        //                    tempItem.ImageIndex = 1;//黄灯
        //                }
        //                else
        //                {
        //                    tempItem.ImageIndex = 0;//红灯
        //                }
        //                tempItem.Group = lstCount.Groups["统计列表"];
                        

        //                lstCount.Items.Add(tempItem);
        //            }

        //        }
        //}

#endregion

        /// <summary>
        /// 质控监控界面-初始化数据
        /// </summary>
        /// <param name="GbxMontior"></param>
        /// <param name="sqlSel"></param>
        /// <param name="comboxSA"></param>
        /// <param name="flag"></param>
        /// <param name="pCount"></param>
        /// <param name="sqlCount"></param>
        /// <param name="img"></param>
        public void InitFlexGrid(Panel GbxMontior, string sqlSel, ComboBox comboxSA, string flag, Panel pCount, string sqlCount,ImageList img)
        {
            GbxMontior.Controls.Clear();
            pCount.Controls.Clear();
            Class_Table[] table = new Class_Table[2];

            table[0] = new Class_Table();
            table[0].Sql = sqlSel;
            table[0].Tablename = "sqlSel";

            table[1] = new Class_Table();
            table[1].Sql = sqlCount;
            table[1].Tablename = "sqlCount";
            DS_QUALITYTABLE = App.GetDataSet(table);

            DataSet dataSet = DS_QUALITYTABLE;
            Class_Record_Monitor_View[] crmv = null;
            if (dataSet.Tables[0].Rows.Count > 0)
            {
                crmv = new Class_Record_Monitor_View[dataSet.Tables[0].Rows.Count];
            }
            else
            {
                return;
            }
            if (dataSet.Tables["sqlSel"] != null)
            {
                Class_Record_Monitor_View[] crmv1 = new Class_Record_Monitor_View[dataSet.Tables["sqlSel"].Rows.Count];
                //using (Graphics gh = Graphics.FromHwnd(GbxMontior.Handle))
                //{
                string section_name = string.Empty;
                int no = 0;
                bool isLine = false;
                for (int j = 0; j < dataSet.Tables["sqlSel"].Rows.Count; j++)
                {

                    crmv1[j] = new Class_Record_Monitor_View();
                    crmv1[j].SickArea_ID = dataSet.Tables["sqlSel"].Rows[j]["SECTION_ID"].ToString();
                    crmv1[j].SickArea_Name = dataSet.Tables["sqlSel"].Rows[j]["SECTION_NAME"].ToString();
                    crmv1[j].DocType = dataSet.Tables["sqlSel"].Rows[j]["DOCTYPE"].ToString();
                    crmv1[j].Num = Convert.ToInt32(dataSet.Tables["sqlSel"].Rows[j]["NUM"].ToString());
                    crmv1[j].PV = Convert.ToInt32(dataSet.Tables["sqlSel"].Rows[j]["PV"].ToString());
                    if (crmv1[j].DocType == "体温单"||crmv1[j].DocType == "体温单其他")//'体温单','体温单其他'
                    {//找出所有对应的规则id
                        crmv1[j].DocTypeID = App.ReadSqlVal("select wm_concat(tqv.id) id from t_quality_var_hlb tqv inner join t_data_code ta on tqv.document_type=ta.id where ta.name='" + crmv1[j].DocType + "'", 0, "id");
                    }
                    int onePv = crmv1[j].PV;
                    int oneNum = crmv1[j].Num;
                    string text = crmv1[j].DocType;
                    //取反条件
                    int intPv = onePv == 1 ? 0 : 1;
                    string swithcs = "SECTION_ID='" + crmv1[j].SickArea_ID + "' and DOCTYPE='" +
                                        crmv1[j].DocType + "' and PV='" + intPv + "'";
                    DataRow[] rows = dataSet.Tables["sqlSel"].Select(swithcs);
                    int otherPv = 0;
                    int otherNum = 0;
                    UserControl uc;
                    if (rows.Length > 0) //相同的文书
                    {
                        otherNum = Convert.ToInt32(rows[0]["NUM"].ToString());
                        otherPv = Convert.ToInt32(rows[0]["PV"].ToString());
                        dataSet.Tables["sqlSel"].Rows.Remove(rows[0]);
                        Image red = img.Images[0];
                        Image yellow = img.Images[1];
                        if (onePv == 0)//黄灯
                        {
                            uc = new UcMerger(text, oneNum, yellow, otherNum, red, flag);
                            //uc = new PbMerger(text, oneNum, yellow, otherNum, red);
                        }
                        else
                        {
                            uc = new UcMerger(text, otherNum, yellow, oneNum, red, flag);
                            //uc = new PbMerger(text, oneNum, yellow, otherNum, red);
                        }
                    }
                    else
                    {
                        Image image;
                        if (onePv ==3)
                        {
                            image = img.Images[3];//补录
                        }
                        else if (onePv == 0)//黄灯
                        {
                            image = img.Images[1];
                        }
                        else
                        {
                            image = img.Images[0];
                        }
                        uc = new UcLight(text, oneNum, image, flag);
                        //uc = new PbLight(text, oneNum, img);
                    }
                    uc.Tag = crmv1[j];
                    if (section_name != crmv1[j].SickArea_Name)
                    {
                        if (!string.IsNullOrEmpty(crmv1[j].SickArea_Name))
                        {
                            section_name = crmv1[j].SickArea_Name;
                            Label lbl = new Label();
                            //lbl.AutoSize = true;
                            no++;
                            lbl.Text =no.ToString() + "." + section_name;
                            lbl.Width = 120;
                            lbl.ForeColor = Color.Blue;
                            GbxMontior.Controls.Add(lbl);
                            //AddUcontrol(GbxMontior, uc, section_name);
                        }
                    }
                    else
                    {
                        //AddUcontrol(GbxMontior, uc);
                    }
                    GbxMontior.Controls.Add(uc);
                }
                //}
            }
            GbxMontior.Refresh();

            if (dataSet.Tables["sqlCount"] != null)
            {
                Class_Record_Monitor_View[] crmv1 = new Class_Record_Monitor_View[dataSet.Tables["sqlCount"].Rows.Count];
                for (int i = 0; i < dataSet.Tables["sqlCount"].Rows.Count; i++)
                {
                    crmv1[i] = new Class_Record_Monitor_View();

                    crmv1[i].DocType = dataSet.Tables["sqlCount"].Rows[i]["DOCTYPE"].ToString();
                    crmv1[i].Num = Convert.ToInt32(dataSet.Tables["sqlCount"].Rows[i]["NUM"].ToString());
                    crmv1[i].PV = Convert.ToInt32(dataSet.Tables["sqlCount"].Rows[i]["PV"].ToString());
                    if (comboxSA.Text != "" && !comboxSA.Text.Contains("请选择"))
                    {
                        crmv1[i].SickArea_ID = comboxSA.SelectedValue == null ? "" : comboxSA.SelectedValue.ToString();
                        crmv1[i].SickArea_Name = comboxSA.Text;
                    }
                    if (crmv1[i].DocType == "体温单" || crmv1[i].DocType == "体温单其他")//'体温单','体温单其他'
                    {//找出所有对应的规则id
                        crmv1[i].DocTypeID = App.ReadSqlVal("select wm_concat(tqv.id) id from t_quality_var_hlb tqv inner join t_data_code ta on tqv.document_type=ta.id where ta.name='" + crmv1[i].DocType + "'", 0, "id");
                    }
                    int onePv = crmv1[i].PV;
                    int oneNum = crmv1[i].Num;
                    string text = crmv1[i].DocType;
                    //取反条件
                    int intPv = onePv == 1 ? 0 : 1;
                    string swithcs = " DOCTYPE='" + crmv1[i].DocType + "' and PV='" + intPv + "'";
                    DataRow[] rows = dataSet.Tables["sqlCount"].Select(swithcs);
                    int otherPv = 0;
                    int otherNum = 0;
                    UserControl uc;
                    if (rows.Length > 0) //相同的文书
                    {
                        otherNum = Convert.ToInt32(rows[0]["NUM"].ToString());
                        otherPv = Convert.ToInt32(rows[0]["PV"].ToString());
                        dataSet.Tables["sqlCount"].Rows.Remove(rows[0]);
                        Image red = img.Images[0];
                        Image yellow = img.Images[1];
                        if (onePv == 0)//黄灯
                        {
                            uc = new UcMerger(text, oneNum, yellow, otherNum, red, flag);
                            //uc = new PbMerger(text, oneNum, yellow, otherNum, red);
                        }
                        else
                        {
                            uc = new UcMerger(text, otherNum, yellow, oneNum, red, flag);
                            //uc = new PbMerger(text, oneNum, yellow, otherNum, red);
                        }
                    }
                    else
                    {
                        Image image;
                        if (onePv == 3)//补录
                        {
                            image = img.Images[3];
                        }
                        else if (onePv == 0)//黄灯
                        {
                            image = img.Images[1];
                        }
                        else
                        {
                            image = img.Images[0];
                        }
                        uc = new UcLight(text, oneNum, image, flag);
                        //uc = new PbLight(text, oneNum, img);
                    }
                    uc.Tag = crmv1[i];
                    
                    pCount.Controls.Add(uc);
                }
            }
            pCount.Refresh();
        }

#region 

        /// <summary>
        /// 初始化数据--HLB
        /// </summary>        
        //public void InitFlexGrid(Panel GbxMontior, string sqlSel, ComboBox comboxSA, string flag, ListView lstCount, string sqlCount,bool isDoctor)
        //{
        //    GbxMontior.Controls.Clear();

        //    Class_Table[] table = new Class_Table[2];

        //    table[0] = new Class_Table();
        //    table[0].Sql = sqlSel;
        //    table[0].Tablename = "sqlSel";

        //    table[1] = new Class_Table();
        //    table[1].Sql = sqlCount;
        //    table[1].Tablename = "sqlCount";
        //    DS_QUALITYTABLE = App.GetDataSet(table);

        //    DataSet dataSet = DS_QUALITYTABLE;

        //    ListViewItem[] item = new ListViewItem[dataSet.Tables[0].Rows.Count];
        //    Class_Record_Monitor_View[] crmv = new Class_Record_Monitor_View[dataSet.Tables[0].Rows.Count];

        //    if (dataSet.Tables["sqlSel"] != null)
        //    {
        //        Class_Record_Monitor_View[] crmv1 = new Class_Record_Monitor_View[dataSet.Tables["sqlSel"].Rows.Count];
        //        //using (Graphics gh = Graphics.FromHwnd(GbxMontior.Handle))
        //        //{
        //        string section_name = string.Empty;
        //        for (int j = 0; j < dataSet.Tables["sqlSel"].Rows.Count; j++)
        //        {

        //            string doctor_name = dataSet.Tables["sqlSel"].Rows[j]["sick_doctor_name"].ToString();
        //            int yelNum = Convert.ToInt32(dataSet.Tables["sqlSel"].Rows[j]["黄灯"].ToString());
        //            int redNum = Convert.ToInt32(dataSet.Tables["sqlSel"].Rows[j]["红灯"].ToString());
        //            string names = dataSet.Tables["sqlSel"].Rows[j]["names"].ToString();
        //            Image red = lstCount.SmallImageList.Images[0];
        //            Image yellow = lstCount.SmallImageList.Images[1];
        //            UserControl uc = new UcMerger(true,doctor_name, yelNum, yellow, redNum, red, flag);
        //            Class_Record_Monitor_View crmv5 = new Class_Record_Monitor_View();
        //            crmv5.DocType = doctor_name;
        //            crmv5.SickArea_Name = names;
        //            uc.Tag = crmv5;
        //            //if (section_name != names)
        //            //{
        //            //    if (!string.IsNullOrEmpty(names))
        //            //    {
        //            //        section_name = names;
        //            //        Label lbl = new Label();
        //            //        lbl.Text = section_name;
        //            //        lbl.ForeColor = Color.Blue;
        //            //        GbxMontior.Controls.Add(lbl);
        //            //        //AddUcontrol(GbxMontior, uc, section_name);
        //            //    }
        //            //}
        //            GbxMontior.Controls.Add(uc);
        //        }
        //        //}
        //    }
        //    GbxMontior.Refresh();
        //    ListViewGroup CountGroup = new ListViewGroup();
        //    CountGroup.Header = "统计列表";
        //    CountGroup.Name = "统计列表";
        //    lstCount.Groups.Add(CountGroup);

        //    if (dataSet.Tables["sqlCount"] != null)
        //    {
        //        Class_Record_Monitor_View[] crmv1 = new Class_Record_Monitor_View[dataSet.Tables["sqlCount"].Rows.Count];
        //        for (int i = 0; i < dataSet.Tables["sqlCount"].Rows.Count; i++)
        //        {
        //            crmv1[i] = new Class_Record_Monitor_View();

        //            crmv1[i].DocType = dataSet.Tables["sqlCount"].Rows[i]["DOCTYPE"].ToString();
        //            crmv1[i].Num = Convert.ToInt32(dataSet.Tables["sqlCount"].Rows[i]["NUM"].ToString());
        //            crmv1[i].PV = Convert.ToInt32(dataSet.Tables["sqlCount"].Rows[i]["PV"].ToString());

        //            ListViewItem tempItem = new ListViewItem();
        //            tempItem.Tag = crmv1[i];
        //            tempItem.Name = crmv1[i].DocType;
        //            tempItem.Text = crmv1[i].DocType + "[" + crmv1[i].Num.ToString() + "]";


        //            if (crmv1[i].PV == 0)
        //            {
        //                tempItem.ImageIndex = 1;//黄灯
        //            }
        //            else
        //            {
        //                tempItem.ImageIndex = 0;//红灯
        //            }
        //            tempItem.Group = lstCount.Groups["统计列表"];

        //            lstCount.Items.Add(tempItem);
        //        }

        //    }
        //}

#endregion

        /// <summary>
        /// 管床医生监控界面-初始化数据
        /// </summary>
        /// <param name="GbxMontior"></param>
        /// <param name="sqlSel"></param>
        /// <param name="comboxSA"></param>
        /// <param name="flag"></param>
        /// <param name="pCount"></param>
        /// <param name="sqlCount"></param>
        /// <param name="isDoctor"></param>
        /// <param name="img"></param>
        /// <param name="IsQualityAlert">是否质控提醒界面查询</param>
        public void InitFlexGrid(Panel GbxMontior, string sqlSel, ComboBox comboxSA, string flag, Panel pCount, string sqlCount, bool isBuLu, ImageList img,bool IsQualityAlert)
        {
            GbxMontior.Controls.Clear();
            pCount.Controls.Clear();
            Class_Table[] table = new Class_Table[2];

            table[0] = new Class_Table();
            table[0].Sql = sqlSel;
            table[0].Tablename = "sqlSel";

            table[1] = new Class_Table();
            table[1].Sql = sqlCount;
            table[1].Tablename = "sqlCount";
            DS_QUALITYTABLE = App.GetDataSet(table);

            DataSet dataSet = DS_QUALITYTABLE;

            //ListViewItem[] item = new ListViewItem[dataSet.Tables[0].Rows.Count];
            //Class_Record_Monitor_View[] crmv = new Class_Record_Monitor_View[dataSet.Tables[0].Rows.Count];

            if (dataSet.Tables["sqlSel"] != null)
            {
                Class_Record_Monitor_View[] crmv1 = new Class_Record_Monitor_View[dataSet.Tables["sqlSel"].Rows.Count];
                string section_name = string.Empty;
                int no = 0;
                for (int j = 0; j < dataSet.Tables["sqlSel"].Rows.Count; j++)
                {
                    crmv1[j] = new Class_Record_Monitor_View();
                    string doctor_name = dataSet.Tables["sqlSel"].Rows[j]["sick_doctor_name"].ToString();
                    string sid = dataSet.Tables["sqlSel"].Rows[j]["section_id"].ToString();
                    string names = dataSet.Tables["sqlSel"].Rows[j]["section_name"].ToString();
                    
                    Image red = img.Images[0];
                    Image yellow = img.Images[1];
                    Image bl = img.Images[3];
                    UserControl uc;
                    //Class_Record_Monitor_View crmv5 = new Class_Record_Monitor_View();
                    if (isBuLu)
                    {
                        int blNum = Convert.ToInt32(dataSet.Tables["sqlSel"].Rows[j]["补录"].ToString());
                        uc = new UcLight(true, IsQualityAlert, doctor_name, blNum, bl, flag);
                        //uc = new UcLight(doctor_name, blNum, bl, "", true);
                        crmv1[j].Num = blNum;
                        crmv1[j].PV = 3;
                    }
                    else
                    {
                        int yelNum = Convert.ToInt32(dataSet.Tables["sqlSel"].Rows[j]["黄灯"].ToString());
                        int redNum = Convert.ToInt32(dataSet.Tables["sqlSel"].Rows[j]["红灯"].ToString());
                        uc = new UcMerger(true,IsQualityAlert, doctor_name, yelNum, yellow, redNum, red, flag);
                    }
                    crmv1[j].DocType = doctor_name;
                    crmv1[j].SickArea_ID = sid;
                    crmv1[j].SickArea_Name = names;
                    uc.Tag = crmv1[j];
                    if (section_name != crmv1[j].SickArea_Name)
                    {
                        if (!string.IsNullOrEmpty(crmv1[j].SickArea_Name))
                        {
                            section_name = crmv1[j].SickArea_Name;
                            Label lbl = new Label();
                            //lbl.AutoSize = true;//考虑到排版会不对称,取消自动宽度,变成固定宽度
                            no++;
                            lbl.Text = no.ToString() + "." + section_name;
                            lbl.Width = 120;
                            lbl.ForeColor = Color.Blue;
                            GbxMontior.Controls.Add(lbl);
                        }
                    }
                    GbxMontior.Controls.Add(uc);
                }
                //}
            }
            GbxMontior.Refresh();

            if (dataSet.Tables["sqlCount"] != null)
            {
                Class_Record_Monitor_View[] crmv1 = new Class_Record_Monitor_View[dataSet.Tables["sqlCount"].Rows.Count];
                for (int i = 0; i < dataSet.Tables["sqlCount"].Rows.Count; i++)
                {
                    crmv1[i] = new Class_Record_Monitor_View();

                    crmv1[i].DocType = dataSet.Tables["sqlCount"].Rows[i]["DOCTYPE"].ToString();
                    crmv1[i].Num = Convert.ToInt32(dataSet.Tables["sqlCount"].Rows[i]["NUM"].ToString());
                    crmv1[i].PV = Convert.ToInt32(dataSet.Tables["sqlCount"].Rows[i]["PV"].ToString());
                    if (comboxSA.Text!=""&&!comboxSA.Text.Contains("请选择"))
                    {
                        crmv1[i].SickArea_ID = comboxSA.SelectedValue == null ? "" : comboxSA.SelectedValue.ToString();
                        crmv1[i].SickArea_Name = comboxSA.Text;
                    }
                    int onePv = crmv1[i].PV;
                    int oneNum = crmv1[i].Num;
                    string text = crmv1[i].DocType;
                    //取反条件
                    int intPv = onePv == 1 ? 0 : 1;
                    string swithcs = " DOCTYPE='" + crmv1[i].DocType + "' and PV='" + intPv + "'";
                    DataRow[] rows = dataSet.Tables["sqlCount"].Select(swithcs);
                    int otherPv = 0;
                    int otherNum = 0;
                    UserControl uc;
                    if (rows.Length > 0) //相同的文书
                    {
                        otherNum = Convert.ToInt32(rows[0]["NUM"].ToString());
                        otherPv = Convert.ToInt32(rows[0]["PV"].ToString());
                        dataSet.Tables["sqlCount"].Rows.Remove(rows[0]);
                        Image red = img.Images[0];
                        Image yellow = img.Images[1];
                        if (onePv == 0)//黄灯
                        {
                            uc = new UcMerger(IsQualityAlert, text, oneNum, yellow, otherNum, red, flag);
                            //uc = new PbMerger(text, oneNum, yellow, otherNum, red);
                        }
                        else
                        {
                            uc = new UcMerger(IsQualityAlert, text, otherNum, yellow, oneNum, red, flag);
                            //uc = new PbMerger(text, oneNum, yellow, otherNum, red);
                        }
                    }
                    else
                    {
                        Image image;
                        if (onePv == 3)//补录灯
                        {
                            image = img.Images[3];
                        }
                        else if (onePv == 0)//黄灯
                        {
                            image = img.Images[1];
                        }
                        else
                        {
                            image = img.Images[0];
                        }
                        uc = new UcLight(IsQualityAlert, text, oneNum, image, flag);
                        //uc = new PbLight(text, oneNum, img);
                    }
                    uc.Tag = crmv1[i];
                    
                    pCount.Controls.Add(uc);
                }

            }
            pCount.Refresh();
        }
        
        private void AddUcontrol(Panel gbx,UserControl uc)
        {
            //foreach (Control item in gbx.Controls)
            //{
            //    if (item.Name == uc.Name)
            //    {
                    //Point pt = new Point(2, 1);
                    //if (gbx.Controls.Count > 0)
                    //{
                    //    Control ctl = gbx.Controls[gbx.Controls.Count - 1];
                    //    int x = ctl.Location.X + ctl.Width;
                    //    int y =  ctl.Location.Y;
                    //    if (x + ctl.Width + uc.Width + 5 > gbx.Width)
                    //    {
                    //        x = 2;
                    //        y += ctl.Height + 5;
                    //    }
                    //    else
                    //    {
                    //        x = x + 10;
                    //    }
                    //    pt.X = x;
                    //    pt.Y = y;
                    //}
                    gbx.Controls.Add(uc);
                    //uc.Location = pt;
                    //break;
            //    }
            //}
        }

        private void AddUcontrol(Panel gbx, UserControl uc, string section_name)
        {
            //foreach (Control item in gbx.Controls)
            //{
            //    if (item.Name == uc.Name)
            //    {133 9613 8807
            Point pt = new Point(2, 1);
            //int x = 3;
            int y = 1;
            int lineY = 1;
            //Brush bs = Brushes.Blue;
            //Pen p = new Pen(bs, 1f);
            //Font ft = new Font("宋体", 9f, GraphicsUnit.Pixel);
            Label lbx = new Label();
            lbx.Text = section_name;
            lbx.BackColor = Color.White;
            lbx.ForeColor = Color.Blue;
            if (gbx.Controls.Count > 0)
            {
                Control ctl = gbx.Controls[gbx.Controls.Count - 1];
                lineY = ctl.Location.Y + ctl.Height + 2;
            }
            //gh.DrawLine(p, pt, new Point(20, 1));
            //gh.DrawString(section_name, ft, bs, new PointF(22, 1));
            //SizeF sf = gh.MeasureString(section_name, ft);
            //int lineX = 0;
            //Int32.TryParse(sf.Width.ToString(), out lineX);
            //lineX += 2;
            //gh.DrawLine(p, new Point(lineX, 1), new Point(gbx.Width - 1, 1));
            gbx.Controls.Add(lbx);
            gbx.Controls.Add(uc);
            lbx.Location = new Point(1, lineY);
            y = lineY + lbx.Height + 3;
            pt.Y = y;
            uc.Location = pt;
        }
        private bool GetImg()
        {
            return false;
        }

        public void ShowCommboBoxValue(ComboBox combox,string name)
        {
            
            combox.Items.Add(name);
            combox.DisplayMember = name;
          
        }
        public ListViewItem Annexation(DataSet dd)
        {
            ListViewItem temp = new ListViewItem();
            DataSet ds = dd;
            return temp;
        }

        public Image CreateImage( int yelNum, int redNum,Image yellow,Image red)
        {
            Image img = new Bitmap(100, 20);
            //缩放原图
            Image redImg = new Bitmap(red, 15, 15);
            Image yeldImg = new Bitmap(yellow, 15, 15);
            //位数
            int yelCount = yelNum.ToString().Length;
            //位数
            int redCount = redNum.ToString().Length;
            int x1 = 15;
            int x2 = 60;
            if (yelCount >1)
            {
                x1 = 10;
            }
            if (redCount >2)
            {
                x2 = 50;
            }
            using (Graphics gh = Graphics.FromImage(img))
            {
                Brush bs = Brushes.Black;
                Font font = new Font("宋体",9f);
                
                gh.DrawString("[", font, bs, 1, 1);
                gh.DrawString(yelNum.ToString(), font, bs, x1, 1);
                gh.DrawImage(yeldImg, 30, 1);
                gh.DrawString("+", font, bs, 45, 1);
                gh.DrawString(redNum.ToString(), font, bs, x2, 1);
                gh.DrawImage(redImg, 75, 1);
                gh.DrawString("]", font, bs, 90, 1);
            }
            return img;
        }

        public Image CreateImage(int redNum,Image red)
        {
            Image img = new Bitmap(100, 20);
            //缩放原图
            //Image redImg = new Bitmap(red, 20, 20);
            //位数
            int redCount = redNum.ToString().Length;
            int x2 = 15;
            if (redCount > 2)
            {
                x2 = 10;
            }
            using (Graphics gh = Graphics.FromImage(img))
            {
                Brush bs = Brushes.Black;
                Font font = new Font("宋体", 9f);

                gh.DrawString("[", font, bs, 1, 1);
                gh.DrawString(redNum.ToString(), font, bs, x2, 1);
                gh.DrawImage(red, 35, 1);
                gh.DrawString("]", font, bs, 58, 1);
            }
            return img;
        }
    }
}

