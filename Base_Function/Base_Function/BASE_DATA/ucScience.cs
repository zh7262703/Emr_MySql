using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using DevComponents.DotNetBar;
namespace Base_Function.BASE_DATA
{
    public partial class ucScience : UserControl
    {
        Class_Sections currentSelectbig = null;  //当前选中的大科表对象
        Class_Sections currentSelectsmall = null;//当前选中的小科表对象
        Class_Sections[] SectionRelations;       //记录与当前大科有关系的小科

        public ucScience()
        {
            InitializeComponent();
        }
        private void frmScience_Activated(object sender, EventArgs e)
        {
            btnSelect_Click(sender, e);
            btnSelect_B_Click(sender, e);
        }
        /// <summary>
        /// 判断关系是否重复设置
        /// </summary>
        /// <param Name="Id"></param>
        /// <returns></returns>
        private bool isExist(int id)
        {
            bool flag = false;

            for (int i = 0; i < lvRelation.Items.Count; i++)
            {
                if (lvRelation.Items[i].Tag.GetType().ToString().Contains("Class_Sections"))
                {
                    Class_Sections temp = (Class_Sections)lvRelation.Items[i].Tag;
                    if (temp.Sid ==id)
                    {
                        flag = true;
                    }
                }
            }
            return flag;
        }

        /// <summary>
        /// 实例化查询结果
        /// </summary>
        /// <param Name="tempds"></param>
        /// <returns></returns>
        private Class_Sections[] GetSelectDirectionary(DataSet tempds)
        {
            if (tempds != null)
            {
                if (tempds.Tables[0].Rows.Count > 0)
                {
                    Class_Sections[] Directionary = new Class_Sections[tempds.Tables[0].Rows.Count];
                    for (int i = 0; i < tempds.Tables[0].Rows.Count; i++)
                    {
                        Directionary[i] = new Class_Sections();
                        Directionary[i].Sid =Convert.ToInt32(tempds.Tables[0].Rows[i]["SID"]);
                        Directionary[i].Section_Code = tempds.Tables[0].Rows[i]["SECTION_CODE"].ToString();
                        Directionary[i].Section_Name = tempds.Tables[0].Rows[i]["SECTION_NAME"].ToString();
                        Directionary[i].Belongto_Section_Id = tempds.Tables[0].Rows[i]["BELONGTO_SECTION_ID"].ToString();
                        Directionary[i].isCheckSection = tempds.Tables[0].Rows[i]["ISCHECKSECTION"].ToString();
                        Directionary[i].Belongto_Section_Name = tempds.Tables[0].Rows[i]["BELONGTO_SECTION_NAME"].ToString();
                        Directionary[i].Belongto_BigSection_ID= tempds.Tables[0].Rows[i]["BELONGTO_BIGSECTION_ID"].ToString();
                        Directionary[i].isBelongToBigSection= tempds.Tables[0].Rows[i]["ISBELONGTOBIGSECTION"].ToString();
                        Directionary[i].Type = tempds.Tables[0].Rows[i]["TYPEINFO"].ToString();
                        Directionary[i].Inout_flag = tempds.Tables[0].Rows[i]["IN_FLAG"].ToString();
                        Directionary[i].Manage_type=tempds.Tables[0].Rows[i]["MANAGE_TYPE"].ToString();
                        Directionary[i].State = tempds.Tables[0].Rows[i]["ENABLE_FLAG"].ToString();
                        Directionary[i].Belongto_hospital = tempds.Tables[0].Rows[i]["SHID"].ToString();
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
        /// 大科表查询
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                btnSelect.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                if (txtConditions.Text.Contains("'"))
                {
                    App.Msg("该查询条件存在SQL注入的危险!");
                    txtConditions.Focus();
                    return;
                }
                lvBigsection.Items.Clear();
                string Sql = "select * from T_SECTIONINFO where ISBELONGTOBIGSECTION='Y'and ENABLE_FLAG='Y'";


                if (txtConditions.Text.Trim() != "")
                {
                    Sql = "select * from T_SECTIONINFO  where SECTION_NAME like '%" + txtConditions.Text.Trim() + "%' and ISBELONGTOBIGSECTION='Y' and ENABLE_FLAG='Y'";
                }
           
                DataSet ds = new DataSet();
                ds = App.GetDataSet(Sql);
                Class_Sections[] Directionarys = GetSelectDirectionary(ds);
                if (Directionarys != null)
                {
                    for (int i = 0; i < Directionarys.Length; i++)
                    {
                

                        ListViewItem lvitemp = new ListViewItem();
                        lvitemp.Tag = Directionarys[i];
                        lvitemp.Text = Directionarys[i].Section_Name;
                        lvitemp.ImageIndex = 0;
                        lvBigsection.Items.Add(lvitemp);
                    }
                }
                //else
                //{
                //    App.Msg("没有找到查询结果！");
                //}
            }
            catch
            { }
            finally
            {
                btnSelect.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        ///小科表查询        
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnSelect_B_Click(object sender, EventArgs e)
        {
            try
            {  

                btnSelect_B.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                if (txtConditions_B.Text.Contains("'"))
                {
                    App.Msg("该查询条件存在SQL注入的危险!");
                    txtConditions.Focus();
                    return;
                }
                lvSmallscience.Items.Clear();
                string Sql = "select * from T_SECTIONINFO where ISBELONGTOBIGSECTION='N' and ENABLE_FLAG='Y' and BELONGTO_BIGSECTION_ID is null";
               
                if (txtConditions_B.Text.Trim() != "")
                {
                    Sql = "select * from T_SECTIONINFO where SECTION_NAME like '%" + txtConditions_B.Text.Trim() + "%' and ISBELONGTOBIGSECTION='N' and ENABLE_FLAG='Y' and BELONGTO_BIGSECTION_ID is null";
                }

                DataSet ds = new DataSet();
                ds = App.GetDataSet(Sql);
                Class_Sections[] Directionarys = GetSelectDirectionary(ds);
                if (Directionarys != null)
                {
                    for (int i = 0; i < Directionarys.Length; i++)
                    {

                        ListViewItem lvitemp = new ListViewItem();
                        lvitemp.Tag = Directionarys[i];
                        lvitemp.Text = Directionarys[i].Section_Name;
                        lvitemp.ImageIndex = 1;
                        lvSmallscience.Items.Add(lvitemp);
                    }
                }
                //else
                //{
                //   App.Msg("没有找到查询结果！");
                //}
            }
            catch
            { }
            finally
            {
                btnSelect_B.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (currentSelectbig != null)
            {
                if (lvRelation.SelectedItems != null)
                {
                    if (App.Ask("确定要删除所有关系？"))
                    {
                        if (SectionRelations != null)
                        {
                            for (int i = 0; i < SectionRelations.Length; i++)
                            {
                                Class_Sections temp = (Class_Sections)lvRelation.Items[i].Tag;
                                string sql = "update T_SECTIONINFO  set BELONGTO_BIGSECTION_ID=null where SID='" + temp.Sid + "'";
                                App.ExecuteSQL(sql);

                            }
                            lvRelation.Items.Clear();
                        }
                        else
                        {
                            App.Msg("请先保存再清空关系设置或点击鼠标右键删除!");
                        }
                        //trvRelation.Nodes.Clear();
                    }
                }
            }
        }
        /// <summary>
        /// 解除大科与小科的关系设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentSelectbig != null)
            {
                if (lvRelation.SelectedItems != null)
                {
                    if (App.Ask("你是否要删除？"))
                    {
                        Class_Sections temp = (Class_Sections)lvRelation.SelectedItems[0].Tag;
                        //TreeNode tn = new TreeNode();
                        //tn.Tag = temp;
                        //tn.Text = temp.Section_Name;

                        ListViewItem lvitem = new ListViewItem();
                        lvitem.Tag = temp;
                        lvitem.Text = temp.Section_Name;
                        App.ExecuteSQL("update T_SECTIONINFO  set BELONGTO_BIGSECTION_ID=null where  where SID='" + temp.Sid + "'");
                        lvitem.ImageIndex = 1;
                        lvSmallscience.Items.Add(lvitem);
                        lvRelation.Items.Remove(lvRelation.SelectedItems[0]);
                    }
                }
            }
        }
        /// <summary>
        /// 保存关系设置
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentSelectbig != null)
                {
                    
                    //清空原有关系 
                    if (SectionRelations != null)
                    {
                        for (int i = 0; i < SectionRelations.Length; i++)
                        {
                            App.ExecuteSQL("update T_SECTIONINFO set BELONGTO_BIGSECTION_ID=null where SID='" + SectionRelations[i].Sid + "'");
                        }
                    }
                    //设置现有关系
                    for (int i = 0; i < lvRelation.Items.Count; i++)
                    {
                        if (lvRelation.Items[i].Tag.GetType().ToString().Contains("Class_Sections"))
                        {
                            Class_Sections temp = (Class_Sections)lvRelation.Items[i].Tag;
                            App.ExecuteSQL("update T_SECTIONINFO set BELONGTO_BIGSECTION_ID='" + currentSelectbig.Sid + "' where SID='" + temp.Sid + "'");

                        }
                      
                    }
                    App.Msg("操作成功！");
                    btnSelect_B_Click(sender, e);
                }
                else
                {
                    App.Msg("请先选择大科表！");
                }
            }
            catch(Exception ex)
            {
                App.Msg("操作失败，原因:" + ex.ToString()+"");
            }
        }

        //private void lvRelation_MouseDown(object sender, MouseEventArgs e)
        //{
        //    lvRelation.SelectedItems = lvRelation.GetNodeAt(e.X, e.Y);  
        //}
        private void lvBigsection_Click(object sender, EventArgs e)
        {
            if (lvBigsection.SelectedItems != null)
            {
                lvRelation.Items.Clear();
                SectionRelations = null;
                currentSelectbig = (Class_Sections)lvBigsection.SelectedItems[0].Tag;
                lblSelectValue.Text = currentSelectbig.Section_Name;
                DataSet ds = App.GetDataSet("select * from T_SECTIONINFO where BELONGTO_BIGSECTION_ID='" + currentSelectbig.Sid + "'");
                Class_Sections[] Directionarys = GetSelectDirectionary(ds);

                if (Directionarys != null)
                {
                    SectionRelations = new Class_Sections[Directionarys.Length];
                    for (int i = 0; i < Directionarys.Length; i++)
                    {
                        SectionRelations[i] = Directionarys[i];
                    }


                    for (int i = 0; i < Directionarys.Length; i++)
                    {
                       

                        ListViewItem lvitem = new ListViewItem();
                        lvitem.Tag = Directionarys[i];
                        lvitem.Text = Directionarys[i].Section_Name;
                        lvitem.ImageIndex = 1;
                        lvRelation.Items.Add(lvitem);
                    }
                } 
            }
            btnSelect_B_Click(sender, e);
        }
        #region /*** 大科的显示设置*/
        //private void trvBigsection_AfterSelect(object sender, TreeViewEventArgs e)
        //{
           
        //    if (trvBigsection.SelectedNode != null)
        //    {
        //        trvRelation.Nodes.Clear();
        //        SectionRelations = null;
        //        currentSelectbig = (Class_Sections)trvBigsection.SelectedNode.Tag;
        //        lblSelectValue.Text = currentSelectbig.Section_Name;
        //        //DataSet ds = App.GetDataSet(@"select SID,SECTION_CODE,SECTION_NAME,BELONGTO_SECTION_ID," +
        //        //        @"case when ISCHECKSECTION='Y' then '是' else '否' end ISCHECKSECTION," +
        //        //        @"BELONGTO_SECTION_NAME,BELONGTO_BIGSECTION_ID,(select SECTION_NAME from T_SECTIONINFO b where b.SECTION_CODE=a.BELONGTO_BIGSECTION_ID) as 大科名称," +
        //        //        @"case when ISBELONGTOBIGSECTION='Y' then '是' else '否' end ISBELONGTOBIGSECTION," +
        //        //        @"case when TYPEINFO=0 then '核算' when TYPEINFO=1 then '大科' else '普通' end TYPEINFO," +
        //        //        @"case when IN_FLAG='I' then '住院' else '门诊' end IN_FLAG," +
        //        //        @"case when MANAGE_TYPE=0 then '临床' when MANAGE_TYPE=1 then '药剂' when  MANAGE_TYPE=2 then '后勤' when MANAGE_TYPE=3 then '行政' when MANAGE_TYPE=4 then '医技' when  MANAGE_TYPE=5 then '科研' else '教学' end MANAGE_TYPE," +
        //        //        @"case when ENABLE_FLAG='Y' then '有效' else '无效' end ENABLE_FLAG," +
        //        //        @"a.SHID,c.sub_hospital_name as ""SHID_NAME"" from T_SECTIONINFO a inner join T_SUB_HOSPITALINFO c on a.shid=c.shid where BELONGTO_BIGSECTION_ID='" + currentSelectbig.Sid + "'");
        //        DataSet ds = App.GetDataSet("select * from T_SECTIONINFO where BELONGTO_BIGSECTION_ID='" + currentSelectbig.Sid + "'");
        //        Class_Sections[] Directionarys = GetSelectDirectionary(ds);

        //        if (Directionarys != null)
        //        {
        //            SectionRelations = new Class_Sections[Directionarys.Length];
        //            for (int i = 0; i < Directionarys.Length; i++)
        //            {
        //                SectionRelations[i] = Directionarys[i];
        //            }


        //            for (int i = 0; i < Directionarys.Length; i++)
        //            {
        //                TreeNode tn = new TreeNode();
        //                tn.Tag = Directionarys[i];
        //                tn.Text = Directionarys[i].Section_Name;
        //                trvRelation.Nodes.Add(tn);
        //            }
        //        }

        //        btnSelect_B_Click(sender, e);
        //    }
        //}
        #endregion

        private void lvSmallscience_RightToLeftLayoutChanged(object sender, EventArgs e)
        {
            if (lvSmallscience.SelectedItems != null)
            {
                currentSelectsmall = (Class_Sections)lvSmallscience.SelectedItems[0].Tag;
            }
        }
        /// <summary>
        /// 设置关系
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void lvSmallscience_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvSmallscience.SelectedItems != null)
            {
                if (lvSmallscience.SelectedItems[0].Tag.GetType().ToString().Contains("Class_Sections"))
                {
                    Class_Sections temp = (Class_Sections)lvSmallscience.SelectedItems[0].Tag;
                    if (!isExist(Convert.ToInt32(temp.Sid)))
                    {

                        ListViewItem lvitem = new ListViewItem();
                        lvitem.Tag = temp;
                        lvitem.Text = temp.Section_Name;
                        lvitem.ImageIndex = 1;
                        lvRelation.Items.Add(lvitem);
                        lvSmallscience.Items.Remove(lvSmallscience.SelectedItems[0]);
                    }
                }
            }
        }
        private void frmScience_Resize(object sender, EventArgs e)
        {
            this.panel5.Left = (this.panel2.Width - this.panel5.Width) / 2;
        }

        private void frmScience_Load(object sender, EventArgs e)
        {
            //App.SetMainFrmMsgToolBarText("大科与小科关系设置信息");
            this.panel5.Left = (418 - 216) / 2;
        }












    }
        
}