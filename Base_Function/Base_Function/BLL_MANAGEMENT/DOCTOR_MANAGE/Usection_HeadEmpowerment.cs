using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Bifrost;
using Base_Function.BLL_MANAGEMENT.DOCTOR_MANAGE;


namespace Base_Function.BLL_MANAGEMENT.DOCTOR_MANAGE
{
    public partial class Usection_HeadEmpowerment : UserControl
    {
        private int y = 0;
        public Usection_HeadEmpowerment()
        {
            try
            {
                InitializeComponent();
            }
            catch 
            {
            }

        }

        private void Usection_HeadEmpowerment_Load(object sender, EventArgs e)
        {
            btnSelect_Click(sender,e);
        }
        /// <summary>
        /// 查询科室
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                trvSectionItems.Nodes.Clear();
                string SectionName = txtName.Text;
                string sql = "";
                if (SectionName != "")
                {
                    sql = "select * from T_SECTIONINFO  where SECTION_NAME like '%" + SectionName + "%' and ISBELONGTOBIGSECTION='Y' and ENABLE_FLAG='Y'";
                }
                else
                {
                    sql = "select * from T_SECTIONINFO where ISBELONGTOBIGSECTION='Y'and ENABLE_FLAG='Y'";
                }
                DataSet ds = App.GetDataSet(sql);
                if (ds != null)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        TreeNode tn = new TreeNode();
                        Class_Sections section = new Class_Sections();
                        section.Sid = Convert.ToInt32(ds.Tables[0].Rows[i]["SID"]);
                        section.Section_Code = ds.Tables[0].Rows[i]["SECTION_CODE"].ToString();
                        section.Section_Name = ds.Tables[0].Rows[i]["SECTION_NAME"].ToString();
                        section.Belongto_Section_Id = ds.Tables[0].Rows[i]["BELONGTO_SECTION_ID"].ToString();
                        section.isCheckSection = ds.Tables[0].Rows[i]["ISCHECKSECTION"].ToString();
                        section.Belongto_Section_Name = ds.Tables[0].Rows[i]["BELONGTO_SECTION_NAME"].ToString();
                        section.Belongto_BigSection_ID = ds.Tables[0].Rows[i]["BELONGTO_BIGSECTION_ID"].ToString();
                        section.isBelongToBigSection = ds.Tables[0].Rows[i]["ISBELONGTOBIGSECTION"].ToString();
                        section.Type = ds.Tables[0].Rows[i]["TYPEINFO"].ToString();
                        section.Inout_flag = ds.Tables[0].Rows[i]["IN_FLAG"].ToString();
                        section.Manage_type = ds.Tables[0].Rows[i]["MANAGE_TYPE"].ToString();
                        section.State = ds.Tables[0].Rows[i]["ENABLE_FLAG"].ToString();
                        section.Belongto_hospital = ds.Tables[0].Rows[i]["SHID"].ToString();
                        tn.Name = section.Sid.ToString();
                        tn.Text = section.Section_Name;
                        tn.Tag = section;
                        trvSectionItems.Nodes.Add(tn);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            #region
            /*
  try
  {
      panel1.Controls.Clear();
      string sql = "select * from t_sectioninfo where ISBELONGTOBIGSECTION='N'";

      DataSet ds = App.GetDataSet(sql);
      y = 0;
      for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
      {
          Class_Sections Section = new Class_Sections();
          Section.Sid = Convert.ToInt32(ds.Tables[0].Rows[i]["SID"].ToString());
          Section.Section_Name = ds.Tables[0].Rows[i]["SECTION_NAME"].ToString();
          if (Section.Sid.ToString() != "")
          {
              Section_HeadEmpowerment SecHead = new Section_HeadEmpowerment(Section.Sid.ToString(), Section.Section_Name);
              SecHead.Location = new System.Drawing.Point(20, y);
              SecHead.Size = new System.Drawing.Size(498, 164);
              panel1.Controls.Add(SecHead);
              y = y + SecHead.Height;
          }
      }
  }
  catch
  {}
  */
            #endregion
            #region
            //string sql_Section = "select * from t_sectioninfo where ISBELONGTOBIGSECTION='N'";
            /* sql1 = "select u.user_id,u.user_name,u.section_id,t.section_name from t_userinfo u  " +
                       @" inner join t_sectioninfo t on t.sid=u.section_id
             select * from t_userinfo us inner join t_approve_accredit t on t.userid=us.user_id and t.sid=us.section_id
             select u.user_id,u.user_name,u.section_id,t.section_name,t.ISBELONGTOBIGSECTION from t_userinfo u  " +
                       @" inner join t_sectioninfo t on t.sid=u.section_id
                
             select u.user_id,u.user_name,u.section_id,sec.section_name,r.role_id,r.role_name from t_userinfo u 
                inner join t_account_user a on a.user_id=u.user_id
                inner join t_account tot on tot.account_id=a.account_id
                inner join t_acc_role tac on tac.account_id=tot.account_id
                inner join t_role r on r.role_id=tac.role_id
                inner join t_sectioninfo sec on sec.sid=u.section_id    
                 where r.role_type='D' 
             * 
            //"select distinct(a.user_id),a.user_name from t_userinfo a" +
            //         " inner join t_account_user b on a.user_id=b.user_id" +
            //         " inner join t_account c on b.account_id = c.account_id" +
            //         " inner join t_acc_role d on d.account_id = c.account_id" +
            //         " inner join t_role e on e.role_id = d.role_id" +
            //         " where a.section_id='" + Inpatient.Section_Id + "' and  e.role_type='D';

            //select * from t_userinfo us inner join t_approve_accredit t on t.userid=us.user_id and t.sid=us.section_id
            //Bifrost.WebReference.Class_Table[] NTables = new Bifrost.WebReference.Class_Table[3];
                 
             */
            #endregion
            #region
            //try
            //{
            //    panel1.Controls.Clear();
            //    ArrayList Sqls = new ArrayList();
            
            //    Bifrost.WebReference.Class_Table[] NTables = new Bifrost.WebReference.Class_Table[3];

            //    NTables[0] = new Bifrost.WebReference.Class_Table();
            //    NTables[0].Tablename = "Sections";
            //    NTables[0].Sql = "select * from t_sectioninfo where ISBELONGTOBIGSECTION='N' order by SID asc";

            //    NTables[1] = new Bifrost.WebReference.Class_Table();
            //    NTables[1].Tablename = "Sections_Peoples";
            //    NTables[1].Sql = "select  distinct(u.user_id),u.user_name,f.section_id,sec.section_name,sec.ISBELONGTOBIGSECTION,r.role_id,r.role_name,r.role_type from t_userinfo u " +
            //                    @"inner join t_account_user a on a.user_id=u.user_id  " +
            //                   @"inner join t_account tot on tot.account_id=a.account_id " +
            //                    @"inner join t_acc_role tac on tac.account_id=tot.account_id " +
            //                   @" inner join t_role r on r.role_id=tac.role_id " +
            //                    @" inner join t_acc_role_range f on tac.id = f.acc_role_id  " +
            //                    @"inner join t_sectioninfo sec on sec.sid=f.section_id";

            //    NTables[2] = new Bifrost.WebReference.Class_Table();
            //    NTables[2].Tablename = "Sections_Exist_peoples";
            //    NTables[2].Sql = "select * from T_APPROVE_ACCREDIT tap inner join t_userinfo us on  tap.userid=us.user_id";
            //    DataSet ds = App.GetDataSet(NTables);
            //    y = 0;
            //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //    {
            //        Class_Sections Section = new Class_Sections();
            //        Section.Sid = Convert.ToInt32(ds.Tables[0].Rows[i]["SID"].ToString());
            //        Section.Section_Name = ds.Tables[0].Rows[i]["SECTION_NAME"].ToString();
            //        if (Section.Sid.ToString() != "")
            //        {
            //            Section_HeadEmpowerment SecHead = new Section_HeadEmpowerment(Section.Sid.ToString(), Section.Section_Name, ds);
            //            SecHead.Location = new System.Drawing.Point(20, y);
            //            SecHead.Size = new System.Drawing.Size(498, 164);
            //            panel1.Controls.Add(SecHead);
            //            y = y + SecHead.Height;
            //        }
            //    }
            //}
            //catch
            //{ }
            #endregion
            try
            {
                panel3.Controls.Clear();
                ArrayList Sqls = new ArrayList();
                y = 0;

                Bifrost.WebReference.Class_Table[] NTables = new Bifrost.WebReference.Class_Table[2];

                NTables[0] = new Bifrost.WebReference.Class_Table();
                NTables[0].Tablename = "Sections_Peoples";
                NTables[0].Sql = "select  distinct(u.user_id),u.user_name,f.section_id,sec.section_name,sec.ISBELONGTOBIGSECTION,r.role_id,r.role_name,r.role_type from t_userinfo u " +
                                @"inner join t_account_user a on a.user_id=u.user_id  " +
                               @"inner join t_account tot on tot.account_id=a.account_id " +
                                @"inner join t_acc_role tac on tac.account_id=tot.account_id " +
                               @" inner join t_role r on r.role_id=tac.role_id " +
                                @" inner join t_acc_role_range f on tac.id = f.acc_role_id  " +
                                @"inner join t_sectioninfo sec on sec.sid=f.section_id";

                NTables[1] = new Bifrost.WebReference.Class_Table();
                NTables[1].Tablename = "Sections_Exist_peoples";
                NTables[1].Sql = "select * from T_APPROVE_ACCREDIT tap inner join t_userinfo us on  tap.userid=us.user_id";
                DataSet ds = App.GetDataSet(NTables);
                 //获取所有项目分类
                for (int i = 0; i < trvSectionItems.Nodes.Count; i++)
                {
                     //判断项目是否被选中,选中的话就生成控件
                    if (trvSectionItems.Nodes[i].Checked)
                    {
                        if (trvSectionItems.Nodes[i].Tag!=null)
                        {
                            Class_Sections tempNode = (Class_Sections)trvSectionItems.Nodes[i].Tag;
                            Section_HeadEmpowerment SecHead = new Section_HeadEmpowerment(tempNode.Sid.ToString(), tempNode.Section_Name, ds);
                            SecHead.Location = new System.Drawing.Point(20, y);
                            SecHead.Size = new System.Drawing.Size(498, 164);
                            panel3.Controls.Add(SecHead);
                            y = y + SecHead.Height;
                        }
                    }
                }
            }
            catch
            {

            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            y = 0;
            //获取所有项目分类
            for (int i = 0; i < trvSectionItems.Nodes.Count; i++)
            {
                //判断项目是否被选中,选中的话就生成控件
                if (trvSectionItems.Nodes[i].Checked)
                {
                    trvSectionItems.Nodes[i].Checked = false;
                }
            }
        }

        private void Usection_HeadEmpowerment_Resize(object sender, EventArgs e)
        {
            this.panel1.Left = (this.panel2.Width - this.panel1.Width) / 2;
            this.panel1.Top = (this.panel2.Height - this.panel1.Height) / 2;
        }


    }
}
