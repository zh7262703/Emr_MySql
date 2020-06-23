using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Bifrost
{ 
    /// <summary>
    /// 文书权限设置
    /// 创建者：张华
    /// 创建时间：2010-10-15
    /// </summary>
    public partial class frmDocRoleSet : UserControl
    {

        /*
         *基本思路：
         * 1.首先将所有的“文书”按照一定的“分类原则”进行归类并加载进来，并“树状”进行展示。
         * 2.加载相关的文书操作按钮、职务、职称等相关信息。
         * 3.在选择相关文书的操作按钮时，查找该按钮所对应的权限（包括职务职称和其他权限等)。
         * 4.每一次设置的时候就直接保存到数据库中，保存的方式是先删除原来的设置，再添加入新的设置。
         */

        ArrayList Doc_Ranges = new ArrayList();  //当前文书使用范围

        private int CurrentSelectDocId = 0;      //当前选择的文书ID

        ArrayList Doc_Job = new ArrayList();     //文书职业或职称

        ArrayList Doc_Other = new ArrayList();   //文书职业或职称

        private bool flagIsCheck=true;           //是否当前操作选择项

        private int SaveCount = 0;               //记录保存次数

        /// <summary>
        /// 构造函数
        /// </summary>
        public frmDocRoleSet()
        {
            InitializeComponent();
        }

        #region 使用范围
        /// <summary>
        ///  显示文书
        /// </summary>
        /// <param name="trvBook"></param>
        public static void ReflashBookTree(TreeView trvBook)
        {
            //查出所有文书
            string SQl = "select * from T_TEXT where ENABLE_FLAG='Y'";
            //找出文书所有类别
            string Sql_Category = "select * from t_data_code where type=31";
            DataSet ds = new DataSet();
            ds = App.GetDataSet(SQl);
            Class_Text_A[] Directionarys = GetSelectClassDs(ds);
            DataSet ds_category = App.GetDataSet(Sql_Category);
            Class_Datacodecs_A[] datacodes = GetSelectDirectionary(ds_category);                        

            if (datacodes != null)
            {
                for (int j = 0; j < datacodes.Length; j++)    //添加文书类别节点
                {
                    TreeNode tempNode = new TreeNode();
                    tempNode.Name = datacodes[j].Id;
                    tempNode.Text = datacodes[j].Name;
                    tempNode.Tag = datacodes[j] as object;
                    tempNode.ImageIndex = 1;
                    tempNode.SelectedImageIndex = 1;
                    if (Directionarys != null)
                    {
                        for (int i = 0; i < Directionarys.Length; i++)
                        {
                            TreeNode tn = new TreeNode();
                            tn.Tag = Directionarys[i];
                            tn.Text = Directionarys[i].Textname;
                            tn.Name = Directionarys[i].Id.ToString();
                            //插入顶级节点
                            if (Directionarys[i].Parentid == 0 && datacodes[j].Id.Equals(Directionarys[i].Txxttype))
                            {
                                tempNode.Nodes.Add(tn);
                                SetTreeView(Directionarys, tn);   //插入文书的子类文书。
                            }
                        }
                    }
                    trvBook.Nodes.Add(tempNode);
                }
            }
        }

        /// <summary>
        /// 对文书进行分类设置
        /// </summary>
        /// <param Name="Directionarys">所有文书节点集合</param>
        /// <param Name="currentnode">当前文书节点</param>
        private static void SetTreeView(Class_Text_A[] Directionarys, TreeNode current)
        {
            for (int i = 0; i < Directionarys.Length; i++)
            {
                Class_Text_A cunrrentDir = (Class_Text_A)current.Tag;
                if (Directionarys[i].Parentid == cunrrentDir.Id)
                {
                    TreeNode tn = new TreeNode();
                    tn.Tag = Directionarys[i];
                    tn.Text = Directionarys[i].Textname;
                    tn.Name = Directionarys[i].Id.ToString();
                    tn.ImageIndex = 9;
                    tn.SelectedImageIndex = 9;
                    current.Nodes.Add(tn);
                    SetTreeView(Directionarys, tn);
                }
            }
        }

        /// <summary>
        /// 实例化查询结果
        /// </summary>
        /// <param Name="tempds"></param>
        /// <returns></returns>
        private static Class_Datacodecs_A[] GetSelectDirectionary(DataSet tempds)
        {
            if (tempds != null)
            {
                if (tempds.Tables[0].Rows.Count > 0)
                {
                    Class_Datacodecs_A[] Directionary = new Class_Datacodecs_A[tempds.Tables[0].Rows.Count];
                    for (int i = 0; i < tempds.Tables[0].Rows.Count; i++)
                    {
                        Directionary[i] = new Class_Datacodecs_A();
                        Directionary[i].Id = tempds.Tables[0].Rows[i]["ID"].ToString();
                        Directionary[i].Name = tempds.Tables[0].Rows[i]["NAME"].ToString();
                        Directionary[i].Code = tempds.Tables[0].Rows[i]["CODE"].ToString();
                        Directionary[i].Shortchut_code = tempds.Tables[0].Rows[i]["SHORTCUT_CODE"].ToString();
                        Directionary[i].Enable = tempds.Tables[0].Rows[i]["ENABLE"].ToString();
                        Directionary[i].Type = tempds.Tables[0].Rows[i]["TYPE"].ToString();
                    }
                    return Directionary;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 实例Class_Text化查询结果
        /// </summary>
        /// <param Name="tempds"></param>
        /// <returns></returns>
        private static Class_Text_A[] GetSelectClassDs(DataSet tempds)
        {
            if (tempds != null)
            {
                if (tempds.Tables[0].Rows.Count > 0)
                {
                    Class_Text_A[] class_text = new Class_Text_A[tempds.Tables[0].Rows.Count];
                    for (int i = 0; i < tempds.Tables[0].Rows.Count; i++)
                    {
                        class_text[i] = new Class_Text_A();
                        class_text[i].Id = Convert.ToInt32(tempds.Tables[0].Rows[i]["ID"].ToString());
                        if (tempds.Tables[0].Rows[i]["PARENTID"].ToString() != "0")
                        {
                            class_text[i].Parentid = Convert.ToInt32(tempds.Tables[0].Rows[i]["PARENTID"].ToString());
                        }
                        class_text[i].Textcode = tempds.Tables[0].Rows[i]["TEXTCODE"].ToString(); ;
                        class_text[i].Textname = tempds.Tables[0].Rows[i]["TEXTNAME"].ToString();
                        class_text[i].Isenable = tempds.Tables[0].Rows[i]["ISENABLE"].ToString();
                        class_text[i].Txxttype = tempds.Tables[0].Rows[i]["ISBELONGTOTYPE"].ToString();
                        class_text[i].Issimpleinstance = tempds.Tables[0].Rows[i]["issimpleinstance"].ToString();
                    }
                    return class_text;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 工作组信息
        /// </summary>
        private void Work_Group()
        {
            try
            {
                string Sql = "select * from t_data_code t where type=47";
                DataSet ds = App.GetDataSet(Sql);
                cboWorkGroup.DataSource = ds.Tables[0].DefaultView;
                cboWorkGroup.DisplayMember = "NAME";
                cboWorkGroup.ValueMember = "ID";
                cboWorkGroup.SelectedIndex = 0;
            }
            catch
            { }
        }

        /// <summary>
        /// 显示所有的分院信息
        /// </summary>
        private void Sub_Hospital()
        {
            try
            {               
                string Sql = "select * from T_SUB_HOSPITALINFO";
                DataSet ds = App.GetDataSet(Sql);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Class_Sub_Hospital temp = new Class_Sub_Hospital();
                    temp.Id = ds.Tables[0].Rows[i]["SHID"].ToString();
                    temp.Sub_code = ds.Tables[0].Rows[i]["SUB_HOSPITAL_CODE"].ToString();
                    temp.Sub_name = ds.Tables[0].Rows[i]["SUB_HOSPITAL_NAME"].ToString();
                    chkListFenyuan.Items.Add(temp);
                    chkListFenyuan.DisplayMember = "Sub_name";
                    chkListFenyuan.ValueMember = "Sub_code";
                }
            }
            catch
            { }
        }

        /// <summary>
        /// 根据分院查找相关科室
        /// </summary>
        /// <param name="subid">分院ID</param>
        private void Section_BY_SubHospital(string subid)
        {
            try
            {
                chkListSection.Items.Clear();
                string Sql = "select * from T_SECTIONINFO where shid=" + subid + "";
                DataSet ds = App.GetDataSet(Sql);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Class_Sections temp = new Class_Sections();
                    temp.Sid = Convert.ToInt16(ds.Tables[0].Rows[i]["sid"].ToString());
                    temp.Section_Code = ds.Tables[0].Rows[i]["SECTION_CODE"].ToString();
                    temp.Section_Name = ds.Tables[0].Rows[i]["SECTION_NAME"].ToString();                    
                    chkListSection.Items.Add(temp);
                    chkListSection.DisplayMember = "Section_Name";
                    chkListSection.ValueMember = "Sid";
                }
            }
            catch
            { }
        }

        /// <summary>
        /// 根据分院查找相关病区
        /// </summary>
        /// <param name="subid">分院ID</param>
        private void Area_BY_SubHospital(string subid)
        {
            try
            {
                chkListSection.Items.Clear();
                string Sql = "select * from t_sickareainfo where shid=" + subid + "";
                DataSet ds = App.GetDataSet(Sql);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Class_Sections temp = new Class_Sections();
                    temp.Sid = Convert.ToInt16(ds.Tables[0].Rows[i]["SAID"].ToString());
                    temp.Section_Code = ds.Tables[0].Rows[i]["SICK_AREA_CODE"].ToString();
                    temp.Section_Name = ds.Tables[0].Rows[i]["SICK_AREA_NAME"].ToString();
                    chkListSection.Items.Add(temp);
                    chkListSection.DisplayMember = "Section_Name";
                    chkListSection.ValueMember = "Sid";
                }
            }
            catch
            { }
        }

       

        /// <summary>
        /// 判断是否选中当前项
        /// </summary>
        private void IsCheckFenyuanItem()
        {
            if (trvBookOprate.SelectedNode != null)
            {
                if (trvBookOprate.SelectedNode.Tag != null)
                {
                    //清空所有的选项
                    for (int i = 0; i < chkListFenyuan.Items.Count; i++)
                    {
                        chkListFenyuan.SetSelected(i, false);
                    }

                    Class_Text_A temp = (Class_Text_A)trvBookOprate.SelectedNode.Tag;
                    DataSet ds = App.GetDataSet("select * from t_textusearea where texttype=" + temp.Id.ToString()+ "");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        //分院
                        for (int j = 0; j < chkListFenyuan.Items.Count; j++)
                        {
                            Class_Sub_Hospital temp2 = (Class_Sub_Hospital)chkListFenyuan.Items[j];
                            if (ds.Tables[0].Rows[i]["belonghospital"].ToString() == temp2.Id)
                            {
                                chkListFenyuan.SetItemChecked(j, true);
                            }                           
                        }                       
                    }                    
                }
            }
        }

        /// <summary>
        /// 判断是否选中当前项
        /// </summary>
        private void IsCheckSectionsItem()
        {
            if (trvBookOprate.SelectedNode != null)
            {
                if (trvBookOprate.SelectedNode.Tag != null)
                {
                    //清空所有的选项
                    for (int i = 0; i < chkListSection.Items.Count; i++)
                    {
                        chkListSection.SetSelected(i, false);
                    }

                    Class_Text_A temp = (Class_Text_A)trvBookOprate.SelectedNode.Tag;
                    Class_Sub_Hospital temp_sub_hospital=(Class_Sub_Hospital)chkListFenyuan.SelectedItem;
                    DataSet ds = App.GetDataSet("select * from t_textusearea where texttype=" + temp.Id.ToString() + " and belonghospital=" + temp_sub_hospital.Id.ToString()+ "");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {                       
                        //科室或病区
                        for (int j = 0; j < chkListSection.Items.Count; j++)
                        {
                            Class_Sections temp2 = (Class_Sections)chkListSection.Items[j];
                            if (ds.Tables[0].Rows[i]["section"].ToString() == temp2.Sid.ToString())
                            {
                                chkListSection.SetItemChecked(j, true);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 所有文书子节点的使用范围设置
        /// </summary>
        private void ChildNodeRangeSet(TreeNodeCollection nodes)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Nodes.Count > 0)
                {
                    ChildNodeRangeSet(nodes[i].Nodes);
                }
                else
                {
                    if (nodes[i].Tag.GetType().ToString().Contains("Class_Text_A"))
                    {
                        Class_Text_A selectdoc = (Class_Text_A)nodes[i].Tag;
                        ArrayList strSqls = new ArrayList();
                        strSqls.Add("delete from T_TEXTUSEAREA where TEXTTYPE=" + selectdoc.Id.ToString() + "");
                        //分院信息
                        string Sql = "select * from T_SUB_HOSPITALINFO";
                        DataSet ds_hospital = App.GetDataSet(Sql);

                        //医生组                      
                        string Sql_section = "select * from T_SECTIONINFO";
                        DataSet ds_section = App.GetDataSet(Sql_section);
                        for (int i1 = 0; i1 < ds_hospital.Tables[0].Rows.Count; i1++)
                        {
                            DataRow[] Rows = ds_section.Tables[0].Select("shid = " + ds_hospital.Tables[0].Rows[i1]["SHID"].ToString() + "");
                            if (Rows.Length > 0)
                            {
                                for (int j = 0; j < Rows.Length; j++)
                                {
                                    Class_Doc_User_Range temp = new Class_Doc_User_Range();
                                    temp.Texttype = selectdoc.Id;
                                    temp.Section = Convert.ToInt16(Rows[j]["sid"].ToString());
                                    temp.Belonghospital = Convert.ToInt16(ds_hospital.Tables[0].Rows[i1]["SHID"].ToString());
                                    temp.Workgroup = 212;
                                    strSqls.Add("insert into T_TEXTUSEAREA(TEXTTYPE,BELONGHOSPITAL,SECTION,WORKGROUP)values(" +
                                               temp.Texttype.ToString() + "," +
                                               temp.Belonghospital.ToString() + "," +
                                               temp.Section.ToString() + "," +
                                               temp.Workgroup.ToString() + ")");
                                }
                            }
                            else
                            {
                                strSqls.Add("insert into T_TEXTUSEAREA(TEXTTYPE,BELONGHOSPITAL,SECTION,WORKGROUP)values(" +
                                                                                 selectdoc.Id.ToString() + "," + ds_hospital.Tables[0].Rows[i1]["SHID"].ToString() + ",0," + 212 + ")");
                            }
                        }
                        //护士组                        
                        string Sql_sickarea = "select * from t_sickareainfo";
                        DataSet ds_sickarea = App.GetDataSet(Sql_sickarea);
                        for (int i1 = 0; i1 < ds_hospital.Tables[0].Rows.Count; i1++)
                        {
                            DataRow[] Rows = ds_sickarea.Tables[0].Select("shid = " + ds_hospital.Tables[0].Rows[i1]["SHID"].ToString() + "");
                            if (Rows.Length > 0)
                            {
                                for (int j = 0; j < Rows.Length; j++)
                                {
                                    Class_Doc_User_Range temp = new Class_Doc_User_Range();
                                    temp.Texttype = selectdoc.Id;
                                    temp.Section = Convert.ToInt16(Rows[j]["said"].ToString());
                                    temp.Belonghospital = Convert.ToInt16(ds_hospital.Tables[0].Rows[i1]["SHID"].ToString());
                                    temp.Workgroup = 213;
                                    strSqls.Add("insert into T_TEXTUSEAREA(TEXTTYPE,BELONGHOSPITAL,SECTION,WORKGROUP)values(" +
                                            temp.Texttype.ToString() + "," +
                                            temp.Belonghospital.ToString() + "," +
                                            temp.Section.ToString() + "," +
                                            temp.Workgroup.ToString() + ")");
                                }
                            }
                            else
                            {
                                strSqls.Add("insert into T_TEXTUSEAREA(TEXTTYPE,BELONGHOSPITAL,SECTION,WORKGROUP)values(" +
                                                                                 selectdoc.Id.ToString() + "," + ds_hospital.Tables[0].Rows[i1]["SHID"].ToString() + ",0," + 213 + ")");
                            }
                        }
                        string[] strsqls2 = new string[strSqls.Count];
                        for (int k = 0; k < strsqls2.Length; k++)
                        {
                            strsqls2[k] = strSqls[k].ToString();
                        }
                        if(App.ExecuteBatch(strsqls2)>0)
                          SaveCount++;
                    }
                }
            }
        }

        /// <summary>
        /// 移除某一分院所有的科室或病区
        /// </summary>
        /// <param name="shid">分院ID</param>
        private void RemoveAllSectionByShid(int shid)
        {
            for (int i = 0; i < Doc_Ranges.Count; i++)
            {
                Class_Doc_User_Range temp = (Class_Doc_User_Range)Doc_Ranges[i];
                if (temp.Belonghospital == shid)
                {
                    Doc_Ranges.Remove(Doc_Ranges[i]);
                    RemoveAllSectionByShid(shid);
                }
            }
        }
        #endregion

        #region 权限设置
      
        /// <summary>
        /// 加载所有的文书按钮
        /// </summary>
        private void iniAllbuttons()
        {
            lsbButton.DataSource = App.GetDataSet("select * from t_permission t where t.perm_kind=2").Tables[0].DefaultView;
            lsbButton.DisplayMember = "perm_name";
            lsbButton.ValueMember = "id";

            lsbButton.SelectedIndex = -1;
            cboSign1.SelectedIndex = 0;
            cboSign2.SelectedIndex = 0;
        }

        /// <summary>
        /// 加载所有的职务
        /// </summary>
        private void iniAllZhiWu()
        {
            cboZhiWu.DataSource = App.GetDataSet("select * from T_DATA_CODE where type=2 and id in (select jobtitle_id from T_IN_DOC_JOBTITLE)").Tables[0].DefaultView;
            cboZhiWu.DisplayMember = "name";
            cboZhiWu.ValueMember = "id";
            if (cboZhiWu.Items.Count>0)
               cboZhiWu.SelectedIndex = 0;
        }

        /// <summary>
        /// 加载所有的职称
        /// </summary>
        private void iniAllZhiChen()
        {

            cboZhiChen.DataSource = App.GetDataSet("select * from T_DATA_CODE where type=1 and id in (select jobtitle_id from T_IN_DOC_JOBTITLE)").Tables[0].DefaultView;
            cboZhiChen.DisplayMember = "name";
            cboZhiChen.ValueMember = "id";
            if (cboZhiChen.Items.Count > 0)
                cboZhiChen.SelectedIndex = 0;
        }

        /// <summary>
        /// 移除某一分院所有的科室或病区
        /// </summary>  
        private void RemoveAllJobsByButtonId()
        {

            //for (int i = 0; i < Doc_Job.Count; i++)
            //{
            //    Class_Doc_Job temp = (Class_Doc_Job)Doc_Job[i];
            //    if (temp.Texttype == CurrentSelectDocId)
            //    {
            //        int buttonId = Convert.ToInt16(lsbButton.SelectedValue);
            //        if (temp.Textcontrol == buttonId)
            //        {
            //            Doc_Job.Remove(Doc_Job[i]);
            //            RemoveAllJobsByButtonId();
            //        }
            //    }
            //}
        }

        /// <summary>
        /// 移除其他权限
        /// </summary>     
        private void RemoveAllOtherRightsByButtonId()
        {
            //for (int i = 0; i < Doc_Other.Count; i++)
            //{
            //    Class_Doc_OtherRights temp = (Class_Doc_OtherRights)Doc_Other[i];                
            //    if (temp.Texttype == CurrentSelectDocId)
            //    {
            //        int buttonId = Convert.ToInt16(lsbButton.SelectedValue);
            //        if (temp.Textcontrol == buttonId)
            //        {
            //            Doc_Other.Remove(Doc_Other[i]);
            //            RemoveAllOtherRightsByButtonId();
            //        }
            //    }
            //}
        }
        #endregion

        /// <summary>
        /// 选择所有的使用范围和职务职称等
        /// </summary>
        private void RangeSelectAllByNode(TreeNode node)
        {
            Doc_Ranges.Clear();

            //Doc_Job.Clear();

            //Doc_Other.Clear();

            Class_Text_A selectdoc = (Class_Text_A)node.Tag;

            /*
             * 使用范围部分
             */          
            string Sql_textusearea = "select * from t_textusearea where texttype=" + selectdoc.Id + "";
            DataSet ds_textusearea = App.GetDataSet(Sql_textusearea);
            for (int i = 0; i < ds_textusearea.Tables[0].Rows.Count; i++)
            {
                Class_Doc_User_Range temp = new Class_Doc_User_Range();
                temp.Texttype = selectdoc.Id;
                temp.Workgroup = Convert.ToInt16(ds_textusearea.Tables[0].Rows[i]["WORKGROUP"]);
                cboWorkGroup.SelectedValue = temp.Workgroup;
                Doc_Ranges.Add(temp);
            }

            Save_WorkGroup();           
        }

        /// <summary>
        /// 刷新使用范围和权限
        /// </summary>
        private void IniReflesh()
        {
            //分院
            for (int i = 0;i<chkListFenyuan.Items.Count; i++)
            {
                chkListFenyuan.SetItemChecked(i, false);
            }

            //科室
            chkListSection.Items.Clear();

            lsbButton.SelectedIndex = -1;

            chkZhiwu.Checked = false;

            chkZhicheng.Checked = false;

            //其他权限
            for (int i = 0; i < chkOtherRights.Items.Count; i++)
            {
                chkOtherRights.SetItemChecked(i, false);
            }
        }

        private void frmDocRoleSet_Load(object sender, EventArgs e)
        {
            ReflashBookTree(this.trvBookOprate);
            Sub_Hospital();
            Work_Group();

            iniAllbuttons();
            iniAllZhiChen();
            iniAllZhiWu();
            SaveCount = 0;
        }

        private void chkListFenyuan_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(chkListFenyuan.SelectedItem!=null)
            //{
            //    Class_Sub_Hospital temp = (Class_Sub_Hospital)chkListFenyuan.SelectedItem;
            //    if (cboWorkGroup.SelectedValue.ToString() == "212")
            //    {                    
            //        Section_BY_SubHospital(temp.Id);
            //    }
            //    else
            //    {
            //        Area_BY_SubHospital(temp.Id);                    
            //    }
            //    IsCheckSectionsItem();
            //}
        }

        private void trvBookOprate_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (trvBookOprate.SelectedNode != null)
            {
                if (SaveCount>0)
                {
                    App.Msg("刚才的文书权限设置，都已经保存！");
                }

                if (trvBookOprate.SelectedNode.Nodes.Count > 0)
                {
                    lblSelectDocType.Text = "当前文书类型：";
                }
                else   //此处只针对单个文书设置权限，对于批量设置权限，在各个执行方法中
                {

                    lblSelectDocType.Text = "当前文书类型：" + trvBookOprate.SelectedNode.Text;
                    if (trvBookOprate.SelectedNode.Tag != null)
                    {
                        if (trvBookOprate.SelectedNode.Tag.GetType().ToString().Contains("Class_Text_A"))
                        {
                            Class_Text_A temp = (Class_Text_A)trvBookOprate.SelectedNode.Tag;
                            CurrentSelectDocId = temp.Id;
                            IniReflesh();
                            RangeSelectAllByNode(trvBookOprate.SelectedNode);
                        }
                    }
                }

                IniReflesh();    //控件重置
                SaveCount = 0;   //保存操作数还原为零
            }
        }

        private void Save_WorkGroup()
        {
            if (trvBookOprate.SelectedNode != null)
            {
                if (trvBookOprate.SelectedNode.Tag != null)
                {
                    ArrayList strSqls = new ArrayList();
                    if (trvBookOprate.SelectedNode.Tag.GetType().ToString().Contains("Class_Text_A"))
                    {
                        Class_Text_A temp = (Class_Text_A)trvBookOprate.SelectedNode.Tag;

                        /*
                         * 文书的使用范围
                         */
                        strSqls.Add("delete from T_TEXTUSEAREA where TEXTTYPE=" + temp.Id.ToString() + "");


                        strSqls.Add("insert into T_TEXTUSEAREA(TEXTTYPE,WORKGROUP)values(" +
                               CurrentSelectDocId + "," +
                               cboWorkGroup.SelectedValue.ToString() + ")");


                        string[] strSql2s = new string[strSqls.Count];
                        for (int i = 0; i < strSqls.Count; i++)
                        {
                            strSql2s[i] = strSqls[i].ToString();
                        }
                        App.ExecuteBatch(strSql2s);
                    }
                }
            }
        }

        /// <summary>
        /// 保存文书权限
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save_WorkGroup();                      
        }

       

        private void cboWorkGroup_SelectedIndexChanged(object sender, EventArgs e)
        {           
            btnSave_Click(sender, e);
        }

        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            ChildNodeRangeSet(trvBookOprate.Nodes);
        }

        private void chkSectionAllCheck_CheckedChanged(object sender, EventArgs e)
        {
         
        }

        private void chkSectionAllCancel_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void lblSectionAllCheck_Click(object sender, EventArgs e)
        {
            //全选所有的选项
            for (int i = 0; i < chkListSection.Items.Count; i++)
            {
                chkListSection.SetItemChecked(i, true);
            }
        }

        private void lblSectionAllCancel_Click(object sender, EventArgs e)
        {
            //清空所有的选项
            for (int i = 0; i < chkListSection.Items.Count; i++)
            {
                chkListSection.SetItemChecked(i, false);
            }
        }      
        
        private void chkListSection_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            
        }

        /// <summary>
        /// 范围修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkListSection_MouseUp(object sender, MouseEventArgs e)
        {
            if (chkListFenyuan.SelectedItem != null)
            {
                Class_Sub_Hospital temp_hospital = (Class_Sub_Hospital)chkListFenyuan.SelectedItem;
                RemoveAllSectionByShid(Convert.ToInt16(temp_hospital.Id));

                /*
                 * 加载新设置的分院科室或病区
                 */
                for (int i = 0; i < chkListSection.CheckedItems.Count; i++)
                {
                    Class_Sections temp_section = (Class_Sections)chkListSection.CheckedItems[i];
                    Class_Doc_User_Range temp = new Class_Doc_User_Range();
                    temp.Belonghospital = Convert.ToInt16(temp_hospital.Id);
                    temp.Section = temp_section.Sid;
                    temp.Texttype = CurrentSelectDocId;
                    temp.Workgroup = Convert.ToInt16(cboWorkGroup.SelectedValue);
                    Doc_Ranges.Add(temp);
                }
            }
        }

        private void chkListFenyuan_MouseUp(object sender, MouseEventArgs e)
        {

        }

       

        /// <summary>
        /// 选择按钮设置权限
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lsbButton_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (trvBookOprate.SelectedNode != null)
                {
                    if (lsbButton.SelectedItem != null && trvBookOprate.SelectedNode.Nodes.Count==0)
                    {
                        SelectButtonRightSet(CurrentSelectDocId);   //选择按钮权限设置
                    }
                    else if (lsbButton.SelectedItem != null && trvBookOprate.SelectedNode.Level == 1)  //批量修改文书权限
                    {
                        chkZhiwu.Checked = false;
                        cboSign2.Enabled = false;
                        cboZhiChen.Enabled = false;
                        chkZhicheng.Checked = false;
                        cboSign1.Enabled = false;
                        cboZhiWu.Enabled = false;

                        //清空其他权限
                        for (int i = 0; i < chkOtherRights.Items.Count; i++)
                        {
                            chkOtherRights.SetItemChecked(i, false);
                        }

                        int buttonid = Convert.ToInt16(lsbButton.SelectedValue);

                        if (trvBookOprate.SelectedNode.Tag.GetType().ToString().Contains("Class_Text_A"))
                        {
                            TreeNode parentNode = trvBookOprate.SelectedNode;
                            foreach (TreeNode tn in parentNode.Nodes)
                            {
                                Class_Text_A temp = (Class_Text_A)tn.Tag;
                                Doc_Job.Add("delete from t_text_jobtitle_relation where TEXTTYPE=" + temp.Id + " and textcontrol=" + buttonid + "");  //单个设置权限
                                Doc_Other.Add("delete from t_text_other_set where TEXTTYPE=" + temp.Id + " and TEXTCONTROL=" + buttonid + "");

                            }
                            string[] SqlsJob = new string[Doc_Job.Count];
                            string[] SqlsOther = new string[Doc_Other.Count];
                            for (int i = 0; i < Doc_Job.Count; i++)
                            {
                                SqlsJob[i] = Doc_Job[i].ToString();
                            }

                            for (int i = 0; i < Doc_Other.Count; i++)
                            {
                                SqlsOther[i] = Doc_Other[i].ToString();
                            }

                            if (App.ExecuteBatch(SqlsJob) > 0 || App.ExecuteBatch(SqlsOther) > 0)
                            {
                                SaveCount++;
                            }
                        }
                    }
                }
            }
            catch
            { }
            finally {
                flagIsCheck = false;
            }
        }

        //选择按钮权限设置
        private void SelectButtonRightSet(int currentSelectDocId)
        {
            flagIsCheck = true;
            int buttonId = Convert.ToInt16(lsbButton.SelectedValue);

            chkZhiwu.Checked = false;
            cboSign2.Enabled = false;
            cboZhiChen.Enabled = false;
            chkZhicheng.Checked = false;
            cboSign1.Enabled = false;
            cboZhiWu.Enabled = false;

            //清空其他权限
            for (int i = 0; i < chkOtherRights.Items.Count; i++)
            {
                chkOtherRights.SetItemChecked(i, false);
            }
            /*
             *权限使用部分-职务职称 
             */
            string Sql_job = "select * from T_TEXT_JOBTITLE_RELATION where TEXTTYPE=" + currentSelectDocId + " and textcontrol=" + buttonId + "";
            DataSet ds_Job = App.GetDataSet(Sql_job);

            for (int i = 0; i < ds_Job.Tables[0].Rows.Count; i++)
            {

                Class_Doc_Job temp = new Class_Doc_Job();
                temp.Id = Convert.ToInt16(ds_Job.Tables[0].Rows[i]["id"]);
                temp.Texttype = Convert.ToInt16(ds_Job.Tables[0].Rows[i]["texttype"]);
                temp.Textcontrol = Convert.ToInt16(ds_Job.Tables[0].Rows[i]["textcontrol"]);
                temp.Flag = ds_Job.Tables[0].Rows[i]["flag"].ToString();
                temp.Jobtitle = Convert.ToInt16(ds_Job.Tables[0].Rows[i]["jobtitle"]);
                temp.Type = Convert.ToInt16(ds_Job.Tables[0].Rows[i]["type"]);


                //职称
                if (temp.Type == 1)
                {
                    chkZhicheng.Checked = true;
                    cboSign2.Enabled = true;
                    cboZhiChen.Enabled = true;
                    cboSign2.Text = temp.Flag.Trim();
                    cboZhiChen.SelectedValue = temp.Jobtitle;
                }

                //职务
                if (temp.Type == 2)
                {
                    chkZhiwu.Checked = true;
                    cboSign1.Enabled = true;
                    cboZhiWu.Enabled = true;
                    cboSign1.Text = temp.Flag.Trim();
                    cboZhiWu.SelectedValue = temp.Jobtitle;
                }

            }

            /*
             * 权限使用部分-其他权限
             */
            string Sql_Other_rights = "select * from T_TEXT_OTHER_SET where TEXTTYPE=" + currentSelectDocId + " and textcontrol=" + buttonId + "";
            DataSet ds_Other_rights = App.GetDataSet(Sql_Other_rights);
            for (int i = 0; i < ds_Other_rights.Tables[0].Rows.Count; i++)
            {
                Class_Doc_OtherRights temp = new Class_Doc_OtherRights();
                temp.Id = Convert.ToInt16(ds_Other_rights.Tables[0].Rows[i]["id"]);
                temp.Texttype = Convert.ToInt16(ds_Other_rights.Tables[0].Rows[i]["texttype"]);
                temp.Textcontrol = Convert.ToInt16(ds_Other_rights.Tables[0].Rows[i]["textcontrol"]);
                temp.Other_name = ds_Other_rights.Tables[0].Rows[i]["Other_name"].ToString();

                for (int j = 0; j < chkOtherRights.Items.Count; j++)
                {
                    if (temp.Other_name == chkOtherRights.Items[j].ToString())
                    {
                        chkOtherRights.SetItemChecked(j, true);
                    }
                }
            }
        }

        //职务选定项改变事件
        private void chkZhiwu_CheckedChanged(object sender, EventArgs e)
        {
            if (!flagIsCheck)
            {
                if (trvBookOprate.SelectedNode != null)
                {
                    if (trvBookOprate.SelectedNode.Level == 1)
                    {
                        if (trvBookOprate.SelectedNode.Tag != null)
                        {
                            if (trvBookOprate.SelectedNode.Tag.GetType().ToString().Contains("Class_Text_A"))
                            {
                                TreeNode parentNode = trvBookOprate.SelectedNode;
                                foreach (TreeNode tn in parentNode.Nodes)
                                {
                                    Class_Text_A temp = (Class_Text_A)tn.Tag;
                                    SetZhiWu(temp.Id);   //设置职务,循环遍历删除权限
                                }
                            }
                        }
                    }
                    else if (trvBookOprate.SelectedNode.Level == 2)
                    {
                        SetZhiWu(CurrentSelectDocId);   //设置职务，单独删除权限
                    }
                }
            }
        }

        //设置职务
        private void SetZhiWu(int currentSelectDocId)
        {
            int buttonid = Convert.ToInt16(lsbButton.SelectedValue);
            Doc_Job.Clear();
            Doc_Job.Add("delete from t_text_jobtitle_relation where TEXTTYPE=" + currentSelectDocId + " and textcontrol=" + buttonid + " and type=2");  //单个设置权限
            if (chkZhiwu.Checked)
            {
                cboSign1.Enabled = true;
                cboZhiWu.Enabled = true;
                Doc_Job.Add("insert into t_text_jobtitle_relation(TEXTTYPE,TEXTCONTROL,FLAG,JOBTITLE,TYPE)values(" + currentSelectDocId + "," + buttonid + ",'" + cboSign1.Text + "'," + cboZhiWu.SelectedValue.ToString() + ",2)");
            }
            else
            {
                cboSign1.Enabled = false;
                cboZhiWu.Enabled = false;
            }
            string[] Sqls = new string[Doc_Job.Count];
            for (int i = 0; i < Doc_Job.Count; i++)
            {
                Sqls[i] = Doc_Job[i].ToString();
            }
            if (App.ExecuteBatch(Sqls) > 0)
                SaveCount++;
        }

        //设置职称
        private void chkZhicheng_CheckedChanged(object sender, EventArgs e)
        {
            if (!flagIsCheck)
            {
                if (trvBookOprate.SelectedNode != null)
                {
                    if (trvBookOprate.SelectedNode.Level == 1)
                    {
                        if (trvBookOprate.SelectedNode.Tag != null)
                        {
                            if (trvBookOprate.SelectedNode.Tag.GetType().ToString().Contains("Class_Text_A"))
                            {
                                TreeNode parentNode = trvBookOprate.SelectedNode;
                                foreach (TreeNode tn in parentNode.Nodes)
                                {
                                    Class_Text_A temp = (Class_Text_A)tn.Tag;
                                    SetZhiCheng(temp.Id);   //设置职称
                                }
                            }
                        }
                    }
                    else if (trvBookOprate.SelectedNode.Level == 2)
                    {
                        SetZhiCheng(CurrentSelectDocId);   //设置职称
                    }
                }
            }
        }

        //设置职称
        private void SetZhiCheng(int currentSelectDocId)
        {
            int buttonid = Convert.ToInt16(lsbButton.SelectedValue);
            Doc_Job.Clear();
            Doc_Job.Add("delete from t_text_jobtitle_relation where TEXTTYPE=" + currentSelectDocId + " and textcontrol=" + buttonid + " and type=1");  //单个设置权限
            if (chkZhicheng.Checked)
            {
                cboSign2.Enabled = true;
                cboZhiChen.Enabled = true;
                Doc_Job.Add("insert into t_text_jobtitle_relation(TEXTTYPE,TEXTCONTROL,FLAG,JOBTITLE,TYPE)values(" + currentSelectDocId + "," + buttonid + ",'" + cboSign2.Text + "'," + cboZhiChen.SelectedValue.ToString() + ",1)");

            }
            else
            {
                cboSign2.Enabled = false;
                cboZhiChen.Enabled = false;
            }
            string[] Sqls = new string[Doc_Job.Count];
            for (int i = 0; i < Doc_Job.Count; i++)
            {
                Sqls[i] = Doc_Job[i].ToString();
            }
            if (App.ExecuteBatch(Sqls) > 0)
                SaveCount++;
        }

        //设置其他权限
        private void chkOtherRights_MouseUp(object sender, MouseEventArgs e)
        {
            if (trvBookOprate.SelectedNode != null)
            {
                if (trvBookOprate.SelectedNode.Level == 1)
                {
                    if (trvBookOprate.SelectedNode.Tag != null)
                    {
                        if (trvBookOprate.SelectedNode.Tag.GetType().ToString().Contains("Class_Text_A"))
                        {
                            TreeNode parentNode = trvBookOprate.SelectedNode;
                            foreach (TreeNode tn in parentNode.Nodes)
                            {
                                Class_Text_A temp = (Class_Text_A)tn.Tag;
                                SetOtherRights(temp.Id);   //设置其它权限
                            }
                        }
                    }
                }
                else if (trvBookOprate.SelectedNode.Level == 2)
                {
                    SetOtherRights(CurrentSelectDocId);   //设置其它权限
                }
            }
        }

        //设置其它权限
        private void SetOtherRights(int currentSelectDocId)
        {
            int buttonid = Convert.ToInt16(lsbButton.SelectedValue);
            Doc_Other.Clear();
            Doc_Other.Add("delete from t_text_other_set where TEXTTYPE=" + currentSelectDocId + " and TEXTCONTROL=" + buttonid + "");
            for (int i = 0; i < chkOtherRights.CheckedItems.Count; i++)
            {
                Doc_Other.Add("insert into t_text_other_set(TEXTTYPE,TEXTCONTROL,OTHER_NAME)values(" + currentSelectDocId + "," + buttonid + ",'" + chkOtherRights.CheckedItems[i].ToString() + "')");
            }
            string[] sqls = new string[Doc_Other.Count];
            for (int i = 0; i < Doc_Other.Count; i++)
            {
                sqls[i] = Doc_Other[i].ToString();
            }
            if (App.ExecuteBatch(sqls) > 0)
                SaveCount++;
        }

        private void cboSign1_SelectedIndexChanged(object sender, EventArgs e)
        {            
            chkZhiwu_CheckedChanged(sender, e);
        }

        private void cboSign2_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkZhicheng_CheckedChanged(sender, e);
        }

        private void cboZhiWu_SelectedIndexChanged(object sender, EventArgs e)
        {           
            chkZhiwu_CheckedChanged(sender, e);
        }

        private void cboZhiChen_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkZhicheng_CheckedChanged(sender, e);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void frmDocRoleSet_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void frmDocRoleSet_VisibleChanged(object sender, EventArgs e)
        {
            if (SaveCount > 0)
            {
                App.Msg("文书的权限设置已经保存！");
                SaveCount = 0;
            }
        }
      
    }
}