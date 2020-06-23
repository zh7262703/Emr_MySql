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
    public partial class ucSick_area : UserControl
    {
        Class_Sickarea currentSick;//当前选中的病区对象
        Class_Sections currentSection;//当前选中的科室对象

        public ucSick_area()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 每当窗体被激活时发生的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSick_section_Activated(object sender, EventArgs e)
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
                if (lvRelation.Items[i].Tag.GetType().ToString().Contains("Class_Sickarea"))
                {                   
                    Class_Sickarea temp = (Class_Sickarea)lvRelation.Items[i].Tag;
                    if (temp.Said == id.ToString())
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
        private Class_SectionArea[] GetSelectDirectionary(DataSet tempds)
        {
            if (tempds != null)
            {
                if (tempds.Tables[0].Rows.Count > 0)
                {
                    Class_SectionArea[] Directionary = new Class_SectionArea[tempds.Tables[0].Rows.Count];
                    for (int i = 0; i < tempds.Tables[0].Rows.Count; i++)
                    {
                        Directionary[i] = new Class_SectionArea();
                        Directionary[i].Id = tempds.Tables[0].Rows[i]["ID"].ToString();
                        Directionary[i].Sid = tempds.Tables[0].Rows[i]["SID"].ToString();
                        Directionary[i].Said = tempds.Tables[0].Rows[i]["SAID"].ToString();

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
        /// 实例化查询病区结果
        /// </summary>
        /// <param Name="tempds"></param>
        /// <returns></returns>
        private Class_Sickarea[] GetDirectionary(DataSet tempds)
        {
            if (tempds != null)
            {
                if (tempds.Tables[0].Rows.Count > 0)
                {
                    Class_Sickarea[] Directionary = new Class_Sickarea[tempds.Tables[0].Rows.Count];
                    for (int i = 0; i < tempds.Tables[0].Rows.Count; i++)
                    {
                        Directionary[i] = new Class_Sickarea();
                        Directionary[i].Said = tempds.Tables[0].Rows[i]["SAID"].ToString();//Convert.ToInt32(
                        Directionary[i].Shid = tempds.Tables[0].Rows[i]["SHID"].ToString();
                        Directionary[i].Sick_area_code = tempds.Tables[0].Rows[i]["SICK_AREA_CODE"].ToString();
                        Directionary[i].Sick_area_name = tempds.Tables[0].Rows[i]["SICK_AREA_NAME"].ToString();
                        Directionary[i].Isbelongtosection = tempds.Tables[0].Rows[i]["ISBELONGTOSECTION"].ToString();
                        Directionary[i].Belongtosection = tempds.Tables[0].Rows[i]["BELONGTOSECTION"].ToString();
                        Directionary[i].Enable_flag = tempds.Tables[0].Rows[i]["ENABLE_FLAG"].ToString();
                        Directionary[i].Bed_count = tempds.Tables[0].Rows[i]["BED_COUNT"].ToString();
                        Directionary[i].Alow_count = tempds.Tables[0].Rows[i]["ALOW_COUNT"].ToString();

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
        /// 实例化查询科室结果
        /// </summary>
        /// <param Name="tempds"></param>
        /// <returns></returns>
        private Class_Sections[] GetSectionDirectionary(DataSet tempds)
        {
            if (tempds != null)
            {
                if (tempds.Tables[0].Rows.Count > 0)
                {
                    Class_Sections[] Directionary = new Class_Sections[tempds.Tables[0].Rows.Count];
                    for (int i = 0; i < tempds.Tables[0].Rows.Count; i++)
                    {
                        Directionary[i] = new Class_Sections();
                        Directionary[i].Sid = Convert.ToInt32(tempds.Tables[0].Rows[i]["SID"].ToString());
                        Directionary[i].Section_Code = tempds.Tables[0].Rows[i]["SECTION_CODE"].ToString();
                        Directionary[i].Section_Name = tempds.Tables[0].Rows[i]["SECTION_NAME"].ToString();
                        Directionary[i].Belongto_Section_Id = tempds.Tables[0].Rows[i]["BELONGTO_SECTION_ID"].ToString();
                        Directionary[i].isCheckSection = tempds.Tables[0].Rows[i]["ISCHECKSECTION"].ToString();
                        Directionary[i].Belongto_Section_Name = tempds.Tables[0].Rows[i]["BELONGTO_SECTION_NAME"].ToString();
                        Directionary[i].Belongto_BigSection_ID = tempds.Tables[0].Rows[i]["BELONGTO_BIGSECTION_ID"].ToString();
                        Directionary[i].isBelongToBigSection = tempds.Tables[0].Rows[i]["ISBELONGTOBIGSECTION"].ToString();
                        Directionary[i].Type = tempds.Tables[0].Rows[i]["TYPEINFO"].ToString();
                        Directionary[i].Inout_flag = tempds.Tables[0].Rows[i]["IN_FLAG"].ToString();
                        Directionary[i].Manage_type = tempds.Tables[0].Rows[i]["MANAGE_TYPE"].ToString();
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
        /// 病区查询
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
                lvSick.Items.Clear();
                string Sql = @"select a.shid,a.said,a.sick_area_code,a.sick_area_name,ISBELONGTOSECTION, ENABLE_FLAG,BELONGTOSECTION,BED_COUNT,ALOW_COUNT from t_sickareainfo a                                     
                                    where  ISBELONGTOSECTION='N' and ENABLE_FLAG='Y'
                                    group  by a.shid,a.said,a.sick_area_code,a.sick_area_name,ISBELONGTOSECTION, ENABLE_FLAG,BELONGTOSECTION,BED_COUNT,ALOW_COUNT
                                    order by a.shid,a.sick_area_code";//查询病区 to_number(a.sick_area_code)
                if (txtConditions.Text.Trim() != "")
                {
                    Sql = "select * from T_SICKAREAINFO  where SICK_AREA_NAME like '%" + txtConditions.Text.Trim() + "%' and ISBELONGTOSECTION='N' and ENABLE_FLAG='Y'";
                }
 
                DataSet ds = new DataSet();
                ds = App.GetDataSet(Sql);
                Class_Sickarea[] Directionarys = GetDirectionary(ds);
                if (Directionarys != null)
                {
                    for (int i = 0; i < Directionarys.Length; i++)
                    {
                        ListViewItem lvitem = new ListViewItem();
                        lvitem.Tag = Directionarys[i];
                        lvitem.Text = Directionarys[i].Sick_area_name;
                        lvitem.ImageIndex = 0;
                        lvSick.Items.Add(lvitem);
                    }
                }               
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
        /// 科室查询
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
                lvSection.Items.Clear();
                string Sql = @"select a.shid,a.sid,a.section_code,a.section_name,a.shid,a.sid,a.section_code,a.section_name,
                              BELONGTO_SECTION_ID,ISCHECKSECTION,BELONGTO_SECTION_NAME,BELONGTO_BIGSECTION_ID,ISBELONGTOBIGSECTION,
                              TYPEINFO,IN_FLAG,MANAGE_TYPE,ENABLE_FLAG from t_sectioninfo a                               
                              where ISBELONGTOBIGSECTION='N' and ENABLE_FLAG='Y'
                              group  by a.shid,a.sid,a.section_code,a.section_name,BELONGTO_SECTION_ID,ISCHECKSECTION,
                              BELONGTO_SECTION_NAME,BELONGTO_BIGSECTION_ID,ISBELONGTOBIGSECTION,TYPEINFO,IN_FLAG,MANAGE_TYPE,ENABLE_FLAG
                              order by a.shid,to_number(a.section_code)";//查询科室
        
                if (txtConditions_B.Text.Trim() != "")
                {
                    Sql = "select * from T_SECTIONINFO where SECTION_NAME like '%" + txtConditions_B.Text.Trim() + "%' and ISBELONGTOBIGSECTION='N' and ENABLE_FLAG='Y'";
                }
            
                DataSet ds = new DataSet();
                ds = App.GetDataSet(Sql);
                Class_Sections[]  Directionarys =GetSectionDirectionary(ds);
                if (Directionarys != null)
                {
                    for (int i = 0; i < Directionarys.Length; i++)
                    {
                   
                        ListViewItem lvitem = new ListViewItem();
                        lvitem.Tag = Directionarys[i];
                        lvitem.Text = Directionarys[i].Section_Name;
                        lvitem.ImageIndex = 1;
                        lvSection.Items.Add(lvitem);
                       
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
                btnSelect_B.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (currentSick != null)
            {
                if (lvRelation.SelectedItems != null)
                {
                    if (App.Ask("确定要删除所有关系？"))
                    {
                        string sql = "delete from T_SECTION_AREA where SID='" + currentSection.Sid + "'";
                        App.ExecuteSQL(sql);
                        lvRelation.Items.Clear();
                    }
                }
            }
        }


        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentSick != null)
            {
                if (lvRelation.SelectedItems != null)
                {
                     if (App.Ask("你是否要删除？"))
                     {

                         Class_Sections temp = (Class_Sections)lvRelation.SelectedItems[0].Tag;
                        App.ExecuteSQL("delete from T_SECTION_AREA where SID='" + temp.Sid.ToString() + "' and  SAID='" + currentSick.Said + "'");
                        lvRelation.Items.Remove(lvRelation.SelectedItems[0]);

                     }
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (currentSection != null)
                {
                    
                    //清空原有关系 
                    if (currentSection != null)
                    {
                        App.ExecuteSQL("delete T_SECTION_AREA  where SID='" + currentSection.Sid + "'");
                    }
                    //设置现有关系
                    for (int i = 0; i < lvRelation.Items.Count; i++)
                    {
                        
                        if (lvRelation.Items[i].Tag.GetType().ToString().Contains("Class_Sickarea"))
                        {
                            Class_Sickarea temp = (Class_Sickarea)lvRelation.Items[i].Tag;

                            App.ExecuteSQL("insert into T_SECTION_AREA(id,SID,SAID) values(" + App.GenId().ToString() + "," + currentSection.Sid.ToString() + "," + temp.Said.ToString() + ")");

                        }

                    }
                    App.Msg("操作成功！");

                }
                else
                {
                    App.Msg("请先选择病区！");
                }
            }
            catch (Exception ex)
            {
                App.Msg("操作失败，原因:" + ex.ToString() + "");
            }
        }

        private void lvSection_Click(object sender, EventArgs e)
        {
            
            if (lvSection.SelectedItems != null)
            {             
                lvRelation.Items.Clear();
                currentSection = (Class_Sections)lvSection.SelectedItems[0].Tag;
                lblSelectValue.Text = currentSection.Section_Name;

                DataSet ds = App.GetDataSet(@"select a.* from t_sickareainfo a inner join T_SECTION_AREA b on a.said = b.said where b.SID="+ currentSection.Sid.ToString()+ "");

                
                Class_Sickarea[] Directionarys = GetDirectionary(ds);

                if (Directionarys != null)
                {

                    for (int i = 0; i < Directionarys.Length; i++)
                    {

                        ListViewItem lvitem = new ListViewItem();
                        lvitem.Tag = Directionarys[i];
                        lvitem.Text = Directionarys[i].Sick_area_name;
                        lvitem.ImageIndex = 1;
                        lvRelation.Items.Add(lvitem);

                    }
                }
            }
        }

        private void lvSick_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvSick.SelectedItems != null)
            {
                if (lvSick.SelectedItems[0].Tag.GetType().ToString().Contains("Class_Sickarea"))
                {
                    Class_Sickarea temp = (Class_Sickarea)lvSick.SelectedItems[0].Tag;
                    if (!isExist(Convert.ToInt32(temp.Said)))
                    {
                        ListViewItem lvitem = new ListViewItem();
                        lvitem.Tag = temp;
                        lvitem.Text = temp.Sick_area_name;
                        lvitem.ImageIndex = 1;
                        lvRelation.Items.Add(lvitem);
                    }
                    else
                    {
                        App.Msg("当前病区已经存在相同的小病区了!");
                    }
                }
            }
        }

        private void lvSick_RightToLeftLayoutChanged(object sender, EventArgs e)
        {
            if (lvSection.SelectedItems != null)
            {

                currentSick = (Class_Sickarea)lvSick.SelectedItems[0].Tag;
            }
        }

        private void ucSick_area_Load(object sender, EventArgs e)
        {
            //App.SetMainFrmMsgToolBarText("病区与科室关系设置");
            this.panel5.Left = (418 - 216) / 2;
        }

        private void ucSick_area_Resize(object sender, EventArgs e)
        {
            //App.SetMainFrmMsgToolBarText("病区与科室关系设置");
            this.panel5.Left = (418 - 216) / 2;
        }
    }
}