using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Leadron;
using System.Text.RegularExpressions;
using System.Collections;

namespace LeadronTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            App.Ini();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {           

            ////string[] tt1=new string[1];
            ////tt1[0] = "12";
            ////string ss = App.getMesContent(tt1);
            ////App.SenderMessage("12", "dasdasd"); ;
            //App.AddTempUserMsg("dasdasdasdsd");
            //App.IsReceiceMsg("zhanghua");
            ////App.Ini();
            //App.ButtonStytle(this,false);
            //App.ShowTip("系统提示", "欢迎使用本系统");
            //ucC1FlexGrid1.fg.Click += new EventHandler(C1FlexGrid1_Click);                        

            //string sql222 = @"select user_id,user_num,user_name,case when gender_code=0 then '男' else '女' end gender_code,birthday,u_tech_post,c.name as " + '"' + "u_tech_post_name" + '"' + ",case when u_seniority=0 then '无' when u_seniority=1 then '高' else '低' end u_seniority,in_time,u_position,b.name as " + '"' + "u_position" + '"' + ",case when u_recipe_power=0 then '普通处方权' else '麻毒药物处方权' end u_recipe_power,section_id,sickarea_id,phone,email,mobile_phone,case when a.enable='Y' then '有效' else '无效' end u_enable,case when profession_card='true' then '有' else '无' end profession_card,prof_card_name,pass_time,receive_time,register_time from t_userinfo a inner join T_DATA_CODE b on a.u_position=b.id inner join T_DATA_CODE c on a.u_tech_post=c.id order by user_id desc";
            //int y = 0;          
            //for (int i = 0; i < 30; i++)
            //{
            //    //ListViewItem lvItem = new ListViewItem();
            //    //lvItem.Checked = true;
            //    //lvItem.Name = i.ToString();
            //    //lvItem.Text = i.ToString() + "fdsfsdfsdfs";
            //    CheckBox tt = new CheckBox();
            //    tt.Text = i.ToString();
            //    tt.AutoSize = true;
            //    //listView1.Items.Insert(0, lvItem);
            //    ////listView1.Refresh();

            //    ////Point f = new Point(0, tt1);
            //    ////tt.Location = f;
            //    ////listView1.Controls.Add(tt);
            //    ////listBox1.Controls.Add(tt);
            //    tt.Location = new Point(2,y);
            //    panel1.Controls.Add(tt);
            //    //listBox1.Items.Add(tt);
            //    if (i % 5 == 0)
            //    {
            //        tt.ForeColor = Color.Red;
            //    }
            //    if (i % 4 == 0)
            //    {
            //        tt.Enabled=false;
            //    }
            //    y = y + tt.Height;
                      
            //    //tt1++;
            //}


            //string Sql_Approval_List_Look = "select a.sick_bed_no,a.patient_name,case a.gender_code when '1' then '女' else '男' end sex,a.pid,a.age," +
            //                                 " b.display,b.desioper_names,to_char(b.opery_date,'yyyy-MM-dd HH24:mi') opery_date,to_char(b.apply_date,'yyyy-MM-dd HH24:mi') apply_date," +
            //                                 " b.apply_docname,b.oper_type,to_char(c.shenpi_time,'yyyy-MM-dd HH24:mi') shenpi_time,c.applystate_doc," +
            //                                 " c.approval_doctid,c.approval_doctname,b.code_icd9,b.apply_docid,c.id,c.oper_type from t_in_patient a" +
            //                                 " inner join t_operapproval_application b on a.pid = inpatient_id" +
            //                                 " inner join t_operationdoctor_approval c on b.id = c.oper_type";

            //ucC1FlexGrid1.DataBd(sql222, "user_id",false,
            //                   "",
            //                   "");


            //    //this.ucC1FlexGrid1.DataBd(sql222, "user_id", "", "");
            //c1FlexGrid1.DataSource = App.GetDataSet(sql222).Tables[0].DefaultView;


            ////==============================================================
            //this.txtSource.Text=App.ModelLableText();

            //textEdit1.ValText = "daskjdhaskjdhkasjd";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void glassButton1_Click(object sender, EventArgs e)
        {
            //App.Progress("测试");
            //App.Msg("真是的");
            //App.HideProgress();


            //获取所有用户信息
            DataSet ds = App.GetDataSet("select * from t_userinfo");

            string[] sqls = new string[ds.Tables[0].Rows.Count];
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                string sq = "update t_userinfo set SHORTCUT_CODE='" + App.getSpell(ds.Tables[0].Rows[i]["USER_NAME"].ToString()) + "' where USER_ID=" + ds.Tables[0].Rows[i]["USER_ID"].ToString() + "";
                sqls[i] = sq;
            }

            App.ExecuteBatch(sqls);
            App.Msg("操作已经成功！");
        }

        private void glassButton2_Click(object sender, EventArgs e)
        {
            this.textBox3.Text=Encrypt.EncryptStr(textBox1.Text);
        }

        private void glassButton3_Click(object sender, EventArgs e)
        {
            this.textBox2.Text=Encrypt.DecryptStr(textBox3.Text);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            App.ReadExcel();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 数据库操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void glassButton4_Click(object sender, EventArgs e)
        {           
            string objectdata = App.ReadSqlVal("select objectdata from ET_DOCUMENT",0, "objectdata");
            this.richTextBox1.Text = objectdata;
        }

        private void glassButton5_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 表格测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void glassButton6_Click(object sender, EventArgs e)
        {
            //DataSet ds = App.GetDataSet("select * from DATA_DICTIONARY");
            //App.reFleshFlexGrid(ds,ref c1FlexGrid1,"code,py,wb,name,classtype","代码,拼音,五笔,名称,类型");

            //DataSet ds=App.RunProcedureGetData("PROC_SELECT", null);
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            
        }

        private void glassButton7_Click(object sender, EventArgs e)
        {
            //textBox4.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, 2].ToString();
            //textBox4.Text = App.SelectObj.Select_Row.ToString();
        }

        private void C1FlexGrid1_Click(object sender, EventArgs e)
        {          
            textBox4.Text = ucC1FlexGrid1.fg[ucC1FlexGrid1.fg.RowSel, 2].ToString();
        }

        /// <summary>
        /// 插入文书模版------单个测试通过
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
 
            XmlDocument doc = new XmlDocument();
            doc.Load(@"E:\csc\C#\oracle编辑器\12月15日\ZYTextDocumentLib\TEST\bin\Debug\病历.xml");
            //string ms=App.InsertLabelContent("12342",doc);            
            //App.ExecuteSQL("insert into t_patients_doc(TID,PID,TEXTKIND,PATIENTS_DOC)values(3,'123123','sdfsf','" + this.richTextBox2.Text + "')");
        }

        /// <summary>
        /// 插入标签模版------单个测试通过
        /// </summary>
       
        private void button4_Click(object sender, EventArgs e)
        {
            //XmlDocument doc = new XmlDocument();
            //doc.Load(@"E:\csc\C#\oracle编辑器\12月15日\ZYTextDocumentLib\TEST\bin\Debug\病历.xml");
            //string ms = App.InsertLabelModel(2, doc);           
        }

        /// <summary>
        /// 插入结构化------单个测试通过
        /// </summary>   
        private void button5_Click(object sender, EventArgs e)
        {
            //XmlDocument doc = new XmlDocument();
            //doc.Load(@"E:\csc\C#\oracle编辑器\12月15日\ZYTextDocumentLib\TEST\bin\Debug\病历.xml");
            //string ms = App.InsertStructValue(2, doc);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string source = this.txtSource.Text;

            if (source == null || source == "" )
                this.txtFilter.Text ="";
            //Regex.IsMatch(source,@"^\d+$");
            //source = source.Replace("34.7", "XXX");
            this.txtFilter.Text=Regex.Replace(source, @"\d", "X");
            //this.txtFilter.Text = Valiate(source);
            //this.txtFilter.Text =source;
            //this.txtFilter.Text = IsNumber(source);//过滤数字


            
        }

        /// <summary>
        /// 过滤数字
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string Valiate(string str)
        {
           //bool isCheck = true;
            char[] arrChar = str.ToCharArray(0, str.Trim().Length);
            foreach (char char1 in arrChar)
            {
                if (char.IsDigit(char1))
                {
                    str=str.Replace(char1, 'X');                    
                }
               
            }
            return str;
        }

        /// <summary>
        /// 过滤数字
        /// </summary>
        /// <param name="checkNumber"></param>
        /// <returns></returns>
        public static string IsNumber(String checkNumber)
        {
            //bool isCheck = true;

            //if (string.IsNullOrEmpty(checkNumber))
            //{
            //    isCheck = false;
            //}
            //else
            //{
                char[] charNumber = checkNumber.ToCharArray();

                for (int i = 0; i < charNumber.Length; i++)
                {
                    if (Char.IsNumber(charNumber[i]))//如果是数字全部替换为*号
                    {
                        //isCheck = false;
                        checkNumber = checkNumber.Replace(charNumber[i], '*');

                    }
                }
            //}

            return checkNumber;
        }

        /// <summary>
        /// 过滤关键字
        /// </summary>
        /// <param name="source"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static string IsFilter(string source, ArrayList filter)
        {

            
                for (int i = 0; i < filter.Count; i++)
                {
                    source=source.Replace(filter[i].ToString(), "xxx");
                }
           
            return source;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string source = this.txtSource.Text;
            ArrayList arrayList=new ArrayList();
            if (this.txtGJZ.Text != "" || this.txtGJZ1.Text != "")
            {
                arrayList.Add(this.txtGJZ.Text);
                arrayList.Add(this.txtGJZ1.Text);
            }
            if (source == null || source == "")
                this.txtFilter.Text = "";
            //过滤关键字
            this.txtFilter.Text = IsFilter(source, arrayList);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            textBox7.Text = App.GetTimeString(textBox4.Text);
        }

        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                App.SelectFastCodeCheck();
            }
            else if(e.KeyCode == Keys.Left)
            {

            }
            else if (e.KeyCode == Keys.Right)
            {
 
            }
            else if (e.KeyCode == Keys.Escape)
            {
                App.HideFastCodeCheck();
            }
            else
            {
                if (!App.FastCodeFlag)
                    if (textBox4.Text.Trim() != "")
                        App.FastCodeCheck("select * from DATA_DICTIONARY where py like '%" + textBox4.Text + "%'", textBox4, "name", "code");  
                                      
                App.FastCodeFlag = false;   
                            
            }  
        }

        private void button8_Click(object sender, EventArgs e)
        {
            App.SendMessage("你好你在干什么呢？","");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = textEdit1.ValText;
        }

        DataSet ds;
        DataSet dsArea;
        DataSet dsRelartion;
        /// <summary>
        /// 提取数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, EventArgs e)
        {
            App.Msg("读取科室信息");
            //提取科室数据
            ds=App.ReadExcel();

            App.Msg("读取病区信息");
            //提取病区数据
            dsArea = App.ReadExcel();

            App.Msg("读取科室病区关系信息");
            //获取关系表
            dsRelartion = App.ReadExcel();

        }

        /// <summary>
        /// 导入数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button11_Click(object sender, EventArgs e)
        {

             #region 清空科室表重新设置
            //清空数据
            App.ExecuteSQL("delete from t_sectioninfo");

            //导入数据
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                int id = App.GenId("t_sectioninfo", "SID");
                string Sql = "insert into t_sectioninfo(SID,SECTION_CODE,SECTION_NAME,ISCHECKSECTION,ISBELONGTOBIGSECTION,TYPEINFO,IN_FLAG,MANAGE_TYPE,ENABLE_FLAG,SHID)values(" + id + ",'" +
                    ds.Tables[0].Rows[i]["ID"].ToString() + "','" + ds.Tables[0].Rows[i]["NAME"].ToString() + "','Y','Y',60,'I',60,'Y',1)";
                App.ExecuteSQL(Sql);
            }

           #endregion

            #region 清除病区数据重新设置
            App.ExecuteSQL("delete from t_sickareainfo");
            //导入数据
            for (int i = 0; i < dsArea.Tables[0].Rows.Count; i++)
            {

                App.ExecuteSQL("insert into t_sickareainfo(SHID,SICK_AREA_CODE,SICK_AREA_NAME,ISBELONGTOSECTION,ENABLE_FLAG,BED_COUNT,ALOW_COUNT)values(1,'" + dsArea.Tables[0].Rows[i]["ID"].ToString() + "','"
                    + dsArea.Tables[0].Rows[i]["NAME"].ToString() + "','Y','Y'," + dsArea.Tables[0].Rows[i]["BED_NUM"].ToString() + "," + dsArea.Tables[0].Rows[i]["ALOW_NUM"].ToString() + ")");
            }
            #endregion

            #region 清空关系设置重新设置
            App.ExecuteSQL("delete from t_section_area");

            DataSet dsSection1 = App.GetDataSet("select * from t_sectioninfo");
            DataSet dsArea1 = App.GetDataSet("select * from t_sickareainfo");

            for (int i = 0; i < dsRelartion.Tables[0].Rows.Count; i++)
            {
                //int id = App.GenId("T_SECTION_AREA", "ID");
                string sectionid = App.ReadSqlVal("select SID from t_sectioninfo where SECTION_CODE='" + dsRelartion.Tables[0].Rows[i]["SECTION_ID"] + "'", 0, "SID");
                string areaid = App.ReadSqlVal("select SAID from t_sickareainfo where SICK_AREA_CODE='" + dsRelartion.Tables[0].Rows[i]["SICK_AREA_ID"] + "'", 0, "SAID");
                App.ExecuteSQL("insert into T_SECTION_AREA(SID,SAID)values(" + sectionid + "," + areaid + ")");
            }

            #endregion
            App.Msg("操作已经成功");

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            textBox6.Text = App.GetNomalTime(this.textBox5.Text);
        }

        private void c1FlexGrid1_RowColChange(object sender, EventArgs e)
        {

        }

        private void c1FlexGrid1_AfterRowColChange(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
        {

        }

        private void c1FlexGrid1_CellChanged(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {

        }

        private void c1FlexGrid1_AfterResizeRow(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
        {

        }

        private void c1FlexGrid1_TextChanged(object sender, EventArgs e)
        {

        }

        private void c1FlexGrid1_GridChanged(object sender, C1.Win.C1FlexGrid.GridChangedEventArgs e)
        {

        }

        private void c1FlexGrid1_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// 保存媒体文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button12_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (App.SaveMediaFile(openFileDialog1.FileName, "3"))
                {
                    App.Msg("保存成功");
                }
            }
        }

        /// <summary>
        /// 读取媒体文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button13_Click(object sender, EventArgs e)
        {            
            //if (App.GetMediaFile(@"D:\", "1.WMV"))
            //{
            //    App.Msg("读取成功");
            //}           
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Class_DocSign ff=App.InSerterHighLevelSign();
            if (ff != null)
                this.textBox8.Text = ff.Username;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //DataSet ds = App.ReadExcel();
            //if (ds != null)
            //{
            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //        {
            //            string code="WJX"+i.ToString();
            //            if (ds.Tables[0].Rows[i][1].ToString().Trim()!="")
            //                App.ExecuteSQL("insert into T_LIS_ITEM(item_code,item_name,ITEM_TYPE)values('"+code+"','" + ds.Tables[0].Rows[i][0].ToString() + "','" + ds.Tables[0].Rows[i][1].ToString() + "')");
            //            else
            //                App.ExecuteSQL("insert into T_LIS_ITEM(item_code,item_name)values('" + code + "','" + ds.Tables[0].Rows[i][0].ToString() + "')");
            //        }
            //        App.Msg("ok");
            //    }
            //}
        }

        private void button15_Click(object sender, EventArgs e)
        {
            DataSet ds = App.GetDataSet("select distinct a.item_code,t.jgdw from t_lis_result t inner join t_lis_item a on t.xmmc=a.item_name");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (ds.Tables[0].Rows[i]["JGDW"].ToString().Trim() != "")
                {
                    App.ExecuteSQL("update t_lis_item set item_unit='" + ds.Tables[0].Rows[i]["JGDW"].ToString().Trim() + "' where item_code='" + ds.Tables[0].Rows[i]["item_code"].ToString().Trim() + "'");
                }
            }
            App.Msg("ok");
        }

    }
   
}