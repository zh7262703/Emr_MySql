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
    public partial class ucSick_relation : UserControl
    {
       Class_Sickarea   currentSickareaBig = null;  //��ǰѡ�еĴ�������
       Class_Sickarea   currentSickareaSmall = null;//��ǰѡ�е�С��������
       Class_Sickarea[]  SickRelations;       //��¼�뵱ǰ����й�ϵ��С����
        public ucSick_relation()
        {
            InitializeComponent();
        }
        /// <summary>
        /// �жϹ�ϵ�Ƿ��ظ�����
        /// </summary>
        /// <param Name="Id"></param>
        /// <returns></returns>
        private bool isExist(string id)
        {
            bool flag = false;

            for (int i = 0; i < lvRelation.Items.Count; i++)
            {
                if (lvRelation.Items[i].Tag.GetType().ToString().Contains("class_Sickarea"))
                {
                    Class_Sickarea temp = (Class_Sickarea)lvRelation.Items[i].Tag;
                    if (temp.Said == id)
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
        private Class_Sickarea[] GetSelectDirectionary(DataSet tempds)
        {
            if (tempds != null)
            {
                if (tempds.Tables[0].Rows.Count > 0)
                {
                    Class_Sickarea[] Directionary = new Class_Sickarea[tempds.Tables[0].Rows.Count];
                    for (int i = 0; i < tempds.Tables[0].Rows.Count; i++)
                    {
                        Directionary[i] = new Class_Sickarea();
                        Directionary[i].Said =tempds.Tables[0].Rows[i]["SAID"].ToString();
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
        /// ������ѯ
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                btnSelect.Enabled = false;
                lvBigSick.Items.Clear();
                this.Cursor = Cursors.WaitCursor;
                if (txtConditions.Text.Contains("'"))
                {
                    App.Msg("�ò�ѯ��������SQLע���Σ��!");
                    txtConditions.Focus();
                    return;
                }


                string Sql = "select * from T_SICKAREAINFO where ISBELONGTOSECTION='Y' and ENABLE_FLAG='Y'";

                if (txtConditions.Text.Trim() != "")
                {
                    Sql = "select * from T_SICKAREAINFO where SICK_AREA_NAME like '%" + txtConditions.Text.Trim() + "%' and ISBELONGTOSECTION='Y' and ENABLE_FLAG='Y'";
                }
         
                DataSet ds = new DataSet();
                ds = App.GetDataSet(Sql);
                Class_Sickarea[] Directionarys = GetSelectDirectionary(ds);

                if (Directionarys != null)
                {
                    for (int i = 0; i < Directionarys.Length; i++)
                    {

                        ListViewItem lvitem = new ListViewItem();
                        lvitem.Tag = Directionarys[i];
                        lvitem.Text = Directionarys[i].Sick_area_name;
                        lvitem.ImageIndex = 0;
                        lvBigSick.Items.Add(lvitem);

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
        /// С������ѯ
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnSelect_B_Click(object sender, EventArgs e)
        {
            try
            {

                btnSelect_B.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                if (txtConditions.Text.Contains("'"))
                {
                    App.Msg("�ò�ѯ��������SQLע���Σ��!");
                    txtConditions.Focus();
                    return;
                }
                lvSmallSick.Items.Clear();
                //string Sql = @"select SAID,a.SHID,c.sub_hospital_name as ""SHID_NAME"",SICK_AREA_CODE," +
                //         @"SICK_AREA_NAME,case when ISBELONGTOSECTION='Y' then '��' else '��' end ISBELONGTOSECTION," +
                //         @"BELONGTOSECTION,(select SICK_AREA_NAME from T_SICKAREAINFO b where b.SAID=a.belongtosection) as ��������," +
                //         @"case when ENABLE_FLAG='Y' then '��Ч' else '��Ч' end ENABLE_FLAG," +
                //         @"BED_COUNT,ALOW_COUNT from T_SICKAREAINFO a inner join T_SUB_HOSPITALINFO c on a.shid=c.shid��where ISBELONGTOSECTION='N' and BELONGTOSECTION is null";
                string Sql = "select * from T_SICKAREAINFO where ISBELONGTOSECTION='N' and ENABLE_FLAG='Y' and  BELONGTOSECTION is null ";

                if (txtConditions_B.Text.Trim() != "")
                {
                    Sql = "select * from T_SICKAREAINFO where  SICK_AREA_NAME like '%" + txtConditions_B.Text.Trim() + "%' and ISBELONGTOSECTION='N' and ENABLE_FLAG='Y' and  BELONGTOSECTION is null";
                }
        
                DataSet ds = new DataSet();
                ds = App.GetDataSet(Sql);
                Class_Sickarea[] Directionarys = GetSelectDirectionary(ds);
                if (Directionarys != null)
                {
                    for (int i = 0; i < Directionarys.Length; i++)
                    {
                        ListViewItem lvitem = new ListViewItem();
                        lvitem.Tag = Directionarys[i];
                        lvitem.Text = Directionarys[i].Sick_area_name;
                        lvitem.ImageIndex = 1;
                        lvSmallSick.Items.Add(lvitem);

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
                btnSelect_B.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }
        /// <summary>
        /// ��չ�ϵ
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            if (currentSickareaBig != null)
            {
                if (lvRelation.SelectedItems != null)
                {
                    if (App.Ask("ȷ��Ҫɾ�����й�ϵ��"))
                    {
                        if (SickRelations != null)
                        {
                            for (int i = 0; i < SickRelations.Length; i++)
                            {
                                Class_Sickarea temp = (Class_Sickarea)lvRelation.Items[i].Tag;
                                string sql = "update T_SICKAREAINFO set BELONGTOSECTION=null where SAID='" + temp.Said + "'";
                                App.ExecuteSQL(sql);

                            }
                            lvRelation.Items.Clear();
                        }
                        else
                        {
                            App.Msg("���ȱ�������չ�ϵ���û�������Ҽ�ɾ��!");
                        }
                    }
                }
            }
        }
        /// <summary>
        /// ���������С����֮���ϵ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ɾ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentSickareaBig != null)
            {
                if (lvRelation.SelectedItems != null)
                {
                    if (App.Ask("���Ƿ�Ҫɾ����"))
                    {
                        //for (int i = 0; i < SickRelations.Length; i++)
                        //{
                        Class_Sickarea temp = (Class_Sickarea)lvRelation.SelectedItems[0].Tag;
                    

                            ListViewItem lvitem = new ListViewItem();
                            lvitem.Tag = temp;
                            lvitem.Text = temp.Sick_area_name;
                            App.ExecuteSQL("update T_SICKAREAINFO  set BELONGTOSECTION=null where SAID=" + temp.Said + "");
                            lvitem.ImageIndex = 1;
                            lvSmallSick.Items.Add(lvitem);
                            lvRelation.Items.Remove(lvRelation.SelectedItems[0]);

                           // App.ExecuteSQL("update T_SICKAREAINFO set BELONGTOSECTION=null where SAID='" + SickRelations[i].Said + "'");
                       // }
                
                    }
                }
            }
        }
        /// <summary>
        /// ����
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentSickareaBig != null)
                {

                    //���ԭ�й�ϵ 
                    if (SickRelations != null)
                    {
                        for (int i = 0; i < SickRelations.Length; i++)
                        {
                            App.ExecuteSQL("update T_SICKAREAINFO set BELONGTOSECTION=null where SAID='" + SickRelations[i].Said + "'");
                        }
                    }
                    //�������й�ϵ
                    for (int i = 0; i < lvRelation.Items.Count; i++)
                    {
                        if (lvRelation.Items[i].Tag.GetType().ToString().Contains("Class_Sickarea"))
                        {
                            Class_Sickarea temp = (Class_Sickarea)lvRelation.Items[i].Tag;
                            App.ExecuteSQL("update T_SICKAREAINFO set BELONGTOSECTION='" + currentSickareaBig.Said + "' where SAID=" + temp.Said + "");

                        }

                    }
                    App.Msg("�����ɹ���");
                    btnSelect_B_Click(sender, e);
                }
                else
                {
                    App.Msg("����ѡ�������");
                }
            }
            catch (Exception ex)
            {
                App.Msg("����ʧ�ܣ�ԭ��:" + ex.ToString() + "");
            }
        }

        //private void trvRelation_MouseDown(object sender, MouseEventArgs e)
        //{
        //    trvRelation.SelectedNode = trvRelation.GetNodeAt(e.X, e.Y); 
        //}
        private void lvBigSick_Click(object sender, EventArgs e)
        {
            if (lvBigSick.SelectedItems != null)
            {
                lvRelation.Items.Clear();
                SickRelations = null;
                currentSickareaBig = (Class_Sickarea)lvBigSick.SelectedItems[0].Tag;
                lblSelectValue.Text = currentSickareaBig.Sick_area_name;

                DataSet ds = App.GetDataSet("select * from T_SICKAREAINFO where BELONGTOSECTION='" + currentSickareaBig.Said + "'");
                Class_Sickarea[] Directionarys = GetSelectDirectionary(ds);

                if (Directionarys != null)
                {
                    SickRelations = new Class_Sickarea[Directionarys.Length];
                    for (int i = 0; i < Directionarys.Length; i++)
                    {
                        SickRelations[i] = Directionarys[i];
                    }


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
            btnSelect_B_Click(sender, e);
        }
 
        private void lvSmallSick_RightToLeftLayoutChanged(object sender, EventArgs e)
        {
            if (lvSmallSick.SelectedItems != null)
            {
                currentSickareaSmall = (Class_Sickarea)lvSmallSick.SelectedItems[0].Tag;
            }
        }
        private void lvSmallSick_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvSmallSick.SelectedItems != null)
            {
                if (lvSmallSick.SelectedItems[0].Tag.GetType().ToString().Contains("Class_Sickarea"))
                {
                    Class_Sickarea temp = (Class_Sickarea)lvSmallSick.SelectedItems[0].Tag;
                    if (!isExist(temp.Said))
                    {


                        ListViewItem lvitem = new ListViewItem();
                        lvitem.Tag = temp;
                        lvitem.Text = temp.Sick_area_name;
                        lvitem.ImageIndex = 1;
                        lvRelation.Items.Add(lvitem);
                        lvSmallSick.Items.Remove(lvSmallSick.SelectedItems[0]);
                    }
                }

            }
        }
        private void frmSick_relation_Load(object sender, EventArgs e)
        {
            //App.SetMainFrmMsgToolBarText("�����Ĺ�ϵ����");
            this.panel5.Left = (418 - 216) / 2;
        }

        private void frmSick_relation_Resize(object sender, EventArgs e)
        {
            this.panel5.Left = (this.panel2.Width - this.panel5.Width) / 2;
        }

        private void frmSick_relation_Activated(object sender, EventArgs e)
        {

                btnSelect_Click(sender, e);
                btnSelect_B_Click(sender, e);
       
        }



  

   






      
    }
}