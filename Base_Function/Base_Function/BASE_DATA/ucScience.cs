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
        Class_Sections currentSelectbig = null;  //��ǰѡ�еĴ�Ʊ����
        Class_Sections currentSelectsmall = null;//��ǰѡ�е�С�Ʊ����
        Class_Sections[] SectionRelations;       //��¼�뵱ǰ����й�ϵ��С��

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
        /// �жϹ�ϵ�Ƿ��ظ�����
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
        /// ʵ������ѯ���
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
        /// ��Ʊ��ѯ
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
                    App.Msg("�ò�ѯ��������SQLע���Σ��!");
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
                //    App.Msg("û���ҵ���ѯ�����");
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
        ///С�Ʊ��ѯ        
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
                    App.Msg("�ò�ѯ��������SQLע���Σ��!");
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
                //   App.Msg("û���ҵ���ѯ�����");
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
                    if (App.Ask("ȷ��Ҫɾ�����й�ϵ��"))
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
                            App.Msg("���ȱ�������չ�ϵ���û�������Ҽ�ɾ��!");
                        }
                        //trvRelation.Nodes.Clear();
                    }
                }
            }
        }
        /// <summary>
        /// ��������С�ƵĹ�ϵ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentSelectbig != null)
            {
                if (lvRelation.SelectedItems != null)
                {
                    if (App.Ask("���Ƿ�Ҫɾ����"))
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
        /// �����ϵ����
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentSelectbig != null)
                {
                    
                    //���ԭ�й�ϵ 
                    if (SectionRelations != null)
                    {
                        for (int i = 0; i < SectionRelations.Length; i++)
                        {
                            App.ExecuteSQL("update T_SECTIONINFO set BELONGTO_BIGSECTION_ID=null where SID='" + SectionRelations[i].Sid + "'");
                        }
                    }
                    //�������й�ϵ
                    for (int i = 0; i < lvRelation.Items.Count; i++)
                    {
                        if (lvRelation.Items[i].Tag.GetType().ToString().Contains("Class_Sections"))
                        {
                            Class_Sections temp = (Class_Sections)lvRelation.Items[i].Tag;
                            App.ExecuteSQL("update T_SECTIONINFO set BELONGTO_BIGSECTION_ID='" + currentSelectbig.Sid + "' where SID='" + temp.Sid + "'");

                        }
                      
                    }
                    App.Msg("�����ɹ���");
                    btnSelect_B_Click(sender, e);
                }
                else
                {
                    App.Msg("����ѡ���Ʊ�");
                }
            }
            catch(Exception ex)
            {
                App.Msg("����ʧ�ܣ�ԭ��:" + ex.ToString()+"");
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
        #region /*** ��Ƶ���ʾ����*/
        //private void trvBigsection_AfterSelect(object sender, TreeViewEventArgs e)
        //{
           
        //    if (trvBigsection.SelectedNode != null)
        //    {
        //        trvRelation.Nodes.Clear();
        //        SectionRelations = null;
        //        currentSelectbig = (Class_Sections)trvBigsection.SelectedNode.Tag;
        //        lblSelectValue.Text = currentSelectbig.Section_Name;
        //        //DataSet ds = App.GetDataSet(@"select SID,SECTION_CODE,SECTION_NAME,BELONGTO_SECTION_ID," +
        //        //        @"case when ISCHECKSECTION='Y' then '��' else '��' end ISCHECKSECTION," +
        //        //        @"BELONGTO_SECTION_NAME,BELONGTO_BIGSECTION_ID,(select SECTION_NAME from T_SECTIONINFO b where b.SECTION_CODE=a.BELONGTO_BIGSECTION_ID) as �������," +
        //        //        @"case when ISBELONGTOBIGSECTION='Y' then '��' else '��' end ISBELONGTOBIGSECTION," +
        //        //        @"case when TYPEINFO=0 then '����' when TYPEINFO=1 then '���' else '��ͨ' end TYPEINFO," +
        //        //        @"case when IN_FLAG='I' then 'סԺ' else '����' end IN_FLAG," +
        //        //        @"case when MANAGE_TYPE=0 then '�ٴ�' when MANAGE_TYPE=1 then 'ҩ��' when  MANAGE_TYPE=2 then '����' when MANAGE_TYPE=3 then '����' when MANAGE_TYPE=4 then 'ҽ��' when  MANAGE_TYPE=5 then '����' else '��ѧ' end MANAGE_TYPE," +
        //        //        @"case when ENABLE_FLAG='Y' then '��Ч' else '��Ч' end ENABLE_FLAG," +
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
        /// ���ù�ϵ
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
            //App.SetMainFrmMsgToolBarText("�����С�ƹ�ϵ������Ϣ");
            this.panel5.Left = (418 - 216) / 2;
        }












    }
        
}