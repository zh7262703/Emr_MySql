using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Bifrost.SYSTEMSET
{
    public partial class ucSetTextRight : UserControl
    {

        /// <summary>
        /// 岁所有文书集合
        /// </summary>
        private ArrayList AryText = new ArrayList();

        /// <summary>
        /// 所有科室集合
        /// </summary>
        private ArrayList ArySections = new ArrayList();

        frmTextRightSet f = null;
        /// <summary>
        /// 文书树控件
        /// </summary>
        TreeNode textnode = new TreeNode();

        /// <summary>
        /// 病人主键
        /// </summary>
        private string Patient_Id = "";

        /// <summary>
        /// 科室集合
        /// </summary>
        DataSet ds_sec;

        /// <summary>
        /// 构造函数
        /// </summary>
        public ucSetTextRight()
        {
            InitializeComponent();
           
        }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="patient_id">病人主键</param>
        public ucSetTextRight(string patient_id,frmTextRightSet frm)
        {
            InitializeComponent();
            Patient_Id = patient_id;
            App.UsControlStyle(this);
            this.f = frm;
            //DataSet ds_set_rights = App.GetDataSet("select * from T_SET_TEXT_RIGHTS t where sysdate between begin_time and end_time and t.patient_id=" + patient_id + "");
            //if (ds_set_rights.Tables[0].Rows.Count > 0)
            //{

            //    string relations = ds_set_rights.Tables[0].Rows[0]["RELATION_ID"].ToString();

            //    /*
            //     *已经被授权
            //     */
            //    btnSure.Visible = false;

            //    if (ds_set_rights.Tables[0].Rows[0]["RIGHT_TYPE"].ToString() == "P")
            //    {
            //        //个人
            //        if (ds_set_rights.Tables[0].Rows[0]["RIGHT_TYPE"].ToString().Trim() != "")
            //        {
                         
            //        }
            //    }
            //    else if (ds_set_rights.Tables[0].Rows[0]["RIGHT_TYPE"].ToString() == "S")
            //    {
            //        //科室
            //        if (ds_set_rights.Tables[0].Rows[0]["RIGHT_TYPE"].ToString().Trim() != "")
            //        {

            //            for (int i = 0; i < chkSectionList.Items.Count; i++)
            //            {
            //               Uobject temp=(Uobject)chkSectionList.Items[i];
            //               for (int j = 0; j < relations.Split(',').Length; j++)
            //               {
            //                   if (relations.Split(',')[j].ToString() == temp.Id)
            //                   {
            //                       chkSectionList.SetSelected(i,true);
            //                   }
            //               }
            //            }
            //            MoveItem(chkSectionList, chkSectionListselect);
            //        }
            //    }

            //    if (ds_set_rights.Tables[0].Rows[0]["TEXT_ID"].ToString() != "0")
            //    {
            //        /*
            //         * 非所有文书
            //         */

            //    }


            //}
        }

        ///// <summary>
        ///// 初始化树
        ///// </summary>
        //private void DataTreeIni()
        //{
        //    textnode.Nodes.Clear();
        //    DataSet ds = App.GetDataSet("select t.id,t.textname,t.parentid from t_text t where t.isenable=0");
        //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //    {
        //        TreeNode tempnode = new TreeNode();
        //        Uobject temptext = new Uobject();
        //        temptext.Id = ds.Tables[0].Rows[i]["id"].ToString();
        //        temptext.Name = ds.Tables[0].Rows[i]["textname"].ToString();
        //        tempnode.Name = temptext.Id;
        //        tempnode.Text = temptext.Name;
        //        tempnode.Tag = temptext;
        //        DataTreeChildIni(ds, tempnode);
        //        textnode.Nodes.Add(tempnode);
        //    }
        //}

        ///// <summary>
        ///// 初始化树子节点
        ///// </summary>
        //private void DataTreeChildIni(DataSet dsText, TreeNode node)
        //{
        //    DataRow[] rows = dsText.Tables[0].Select("parentid=" + node.Name + "");
        //    for (int i = 0; i < rows.Length; i++)
        //    {
        //        TreeNode tempnode = new TreeNode();
        //        Uobject temptext = new Uobject();
        //        temptext.Id = rows[i]["id"].ToString();
        //        temptext.Name = rows[i]["textname"].ToString();
        //        tempnode.Name = temptext.Id;
        //        tempnode.Text = temptext.Name;
        //        tempnode.Tag = temptext;
        //        DataTreeChildIni(dsText, tempnode);
        //        node.Nodes.Add(tempnode);
        //    }
        //}

        /// <summary>
        /// 刷新列表
        /// </summary>
        private void DataIniTextList(TreeNodeCollection nodes)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Nodes.Count == 0)
                {
                    if(!isExistVal(nodes[i].Name, chkTextListSelect))
                       chkTextList.Items.Add(nodes[i].Tag);

                   AryText.Add(nodes[i].Tag);
                }
            }
        }

        /// <summary>
        /// 初始化科室信息
        /// </summary>
        private void DataSections()
        {
            DataSet ds_sec = App.GetDataSet("select a.sid,a.section_name from t_sectioninfo a inner join t_section_area b on a.sid=b.sid order by a.section_name,a.sid ");
            for (int i = 0; i < ds_sec.Tables[0].Rows.Count; i++)
            {
                Uobject temp = new Uobject();
                temp.Id = ds_sec.Tables[0].Rows[i]["sid"].ToString();
                temp.Name = ds_sec.Tables[0].Rows[i]["section_name"].ToString();
                if (!isExistVal(temp.Id, chkSectionListselect))
                   chkSectionList.Items.Add(temp);

               ArySections.Add(temp);
            }
            
        }

        /// <summary>
        /// 根据工号获取病人信息
        /// </summary>
        /// <param name="Gh"></param>
        private Uobject GetUserInfoByGh(string Gh)
        {
            lblUserInfo.Text = "用户基本信息";
            string sql="select a.user_id,c.account_name,a.user_name,d.section_name from t_userinfo a inner join t_account_user b on a.user_id=b.user_id inner join t_account c on b.account_id=c.account_id inner join t_sectioninfo d on a.section_id=d.sid ";
            DataSet ds = App.GetDataSet(sql + " where c.account_name='" + Gh.ToUpper() + "'");
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblUserInfo.Text = "登录名：" + ds.Tables[0].Rows[0]["account_name"].ToString() +
                                       "  姓名：" + ds.Tables[0].Rows[0]["user_name"].ToString() +
                                       "  姓名：" + ds.Tables[0].Rows[0]["section_name"].ToString();
                    Uobject tempuser = new Uobject();
                    tempuser.Id = ds.Tables[0].Rows[0]["user_id"].ToString();
                    tempuser.Name = ds.Tables[0].Rows[0]["user_name"].ToString();
                    return tempuser;
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
        /// 判断对象是否已经被选择过
        /// </summary>
        /// <param name="ID">主键</param>
        /// <param name="templistbox">被选择对象容器</param>
        /// <returns></returns>
        private bool isExistVal(string ID, CheckedListBox templistbox)
        {
            bool flag = false;
            for (int i = 0; i < templistbox.Items.Count; i++)
            {
                Uobject temp = (Uobject)templistbox.Items[i];
                if(temp.Id == ID)
                   flag = true;
            }
            return flag;
        }
        
        /// <summary>
        /// 添加移除选择列表中的项
        /// </summary>       
        /// <param name="RemoveChkListBox">移除项</param>
        /// <param name="AddChkListBox">添加项</param>
        /// <param name="list">原列表所有集合项</param>
        private void MoveItem(CheckedListBox RemoveChkListBox,CheckedListBox AddChkListBox,ArrayList list)
        {
            Uobject[] objtemps = new Uobject[RemoveChkListBox.CheckedItems.Count];

            //添加项
            for (int i = 0; i < RemoveChkListBox.CheckedItems.Count; i++)
            {
                Uobject temp=(Uobject)RemoveChkListBox.CheckedItems[i];
                objtemps[i] = temp;
                if (!isExistVal(temp.Id, AddChkListBox))
                {                    
                    AddChkListBox.Items.Add(temp);
                }
            }

            //移除项
            for (int i = 0; i < objtemps.Length; i++)
            {
                RemoveItem(objtemps[i].Id, RemoveChkListBox);
            }   

            AddChkListBox.Items.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                Uobject temp = (Uobject)list[i];
                if (!isExistVal(temp.Id, RemoveChkListBox))
                    AddChkListBox.Items.Add(temp);
            }
              
        }

        /// <summary>
        /// 添加移除选择列表中的项
        /// </summary>       
        /// <param name="RemoveChkListBox">移除项</param>
        /// <param name="AddChkListBox">添加项</param>  
        private void MoveItem(CheckedListBox RemoveChkListBox, CheckedListBox AddChkListBox)
        {
            Uobject[] objtemps = new Uobject[RemoveChkListBox.CheckedItems.Count];

            //添加项
            for (int i = 0; i < RemoveChkListBox.CheckedItems.Count; i++)
            {
                Uobject temp = (Uobject)RemoveChkListBox.CheckedItems[i];
                objtemps[i] = temp;
                if (!isExistVal(temp.Id, AddChkListBox))
                {
                    AddChkListBox.Items.Add(temp);
                }
            }

            //移除项
            for (int i = 0; i < objtemps.Length; i++)
            {
                RemoveItem(objtemps[i].Id, RemoveChkListBox);
            }             

        }

        /// <summary>
        /// 移除制定项
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="RemoveChkListBox"></param>
        private void RemoveItem(string ID, CheckedListBox RemoveChkListBox)
        {
            for (int i = 0; i < RemoveChkListBox.Items.Count; i++)
            {
                Uobject temp = (Uobject)RemoveChkListBox.CheckedItems[i];
                if (temp.Id == ID)
                {
                    RemoveChkListBox.Items.Remove(RemoveChkListBox.CheckedItems[i]);
                    break;
                }
            }           
        }

        /// <summary>
        /// 移除制定项2
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="RemoveChkListBox"></param>
        private void RemoveItem2(string ID, CheckedListBox RemoveChkListBox)
        {
            for (int i = 0; i < RemoveChkListBox.Items.Count; i++)
            {
                Uobject temp = (Uobject)RemoveChkListBox.Items[i];
                if (temp.Id == ID)
                {
                    RemoveChkListBox.Items.Remove(RemoveChkListBox.Items[i]);
                    break;
                }
            }
        }

        private void ucSetTextRight_Load(object sender, EventArgs e)
        {
            chkTextList.DisplayMember = "Name";
            chkTextList.ValueMember = "Id";
            chkTextListSelect.DisplayMember = "Name";
            chkTextListSelect.ValueMember = "Id";
            chkSectionList.ValueMember = "Id";
            chkSectionList.DisplayMember = "Name";
            chkSectionListselect.DisplayMember = "Name";
            chkSectionListselect.ValueMember = "Id";
            chkUserSelectList.ValueMember = "Id";
            chkUserSelectList.DisplayMember = "Name";
            btnSure.Enabled = true;
            try
            {
                btnReSet_Click(sender, e);

                //获取已经设置的授权
                DataSet ds = App.GetDataSet("select * from T_SET_TEXT_RIGHTS t where t.patient_id=" + Patient_Id + "");
                if (ds != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string textids = ds.Tables[0].Rows[0]["TEXT_ID"].ToString();
                        string right_type = ds.Tables[0].Rows[0]["RIGHT_TYPE"].ToString();
                        string reationids = ds.Tables[0].Rows[0]["RELATION_ID"].ToString();
                        string functions = ds.Tables[0].Rows[0]["FUNCTIONS"].ToString();
                        dateTimePicker1.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["BEGIN_TIME"].ToString());
                        dateTimePicker2.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["END_TIME"].ToString());

                        if (dateTimePicker2.Value < App.GetSystemTime())
                        {
                            dateTimePicker1.Value = App.GetSystemTime();
                            dateTimePicker2.Value = App.GetSystemTime().AddHours(48);
                        }

                        if (functions.Contains(chkCheck.Text))
                        {
                            chkCheck.Checked = true;
                        }
                        if (functions.Contains(chkUpdate.Text))
                        {
                            chkUpdate.Checked = true;
                        }
                        if (functions.Contains(chkCreate.Text))
                        {
                            chkCreate.Checked = true;
                        }
                        if (functions.Contains(chkPatch.Text))
                        {
                            chkPatch.Checked = true;
                        }

                        if (textids != "0")
                        {
                            //文书类型
                            for (int i = 0; i < textids.Split(',').Length; i++)
                            {
                                for (int j = 0; j < chkTextList.Items.Count; j++)
                                {
                                    Uobject temp = (Uobject)chkTextList.Items[j];
                                    if (temp.Id == textids.Split(',')[i])
                                    {
                                        chkTextListSelect.Items.Add(temp);
                                        RemoveItem2(temp.Id, chkTextList);
                                    }
                                }

                            }
                        }

                        if (right_type == "S")
                        {
                            //科室
                            for (int i = 0; i < reationids.Split(',').Length; i++)
                            {
                                for (int j = 0; j < chkSectionList.Items.Count; j++)
                                {
                                    Uobject temp = (Uobject)chkSectionList.Items[j];
                                    if (temp.Id == reationids.Split(',')[i])
                                    {
                                        chkSectionListselect.Items.Add(temp);
                                        RemoveItem2(temp.Id, chkSectionList);
                                    }
                                }
                            }
                        }
                        else if (right_type == "P")
                        {
                            DataSet ds_p = App.GetDataSet("select t.user_id,t.user_name from t_userinfo t where user_id in (" + reationids + ")");

                            //用户
                            for (int i = 0; i < ds_p.Tables[0].Rows.Count; i++)
                            {
                                Uobject tempobj = new Uobject();
                                tempobj.Id = ds_p.Tables[0].Rows[i]["user_id"].ToString();
                                tempobj.Name = ds_p.Tables[0].Rows[i]["user_name"].ToString();
                                chkUserSelectList.Items.Add(tempobj);
                            }
                        }

                        btnSure.Visible = true;
                    }

                }
            }
            catch
            { }

        }

        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReSet_Click(object sender, EventArgs e)
        {
            panel1.Enabled = false;
            panel2.Enabled = false;
            panel3.Enabled = false;
            if (chkTextSelect.Checked)
            {
                panel1.Enabled = true;
            }
            if (radSectionSelect.Checked)
            {
                panel2.Enabled = true;
            }
            if (radUserSelect.Checked)
            {
                panel3.Enabled = true;
            }

            chkCheck.Checked = false;
            chkCreate.Checked = false;
            chkUpdate.Checked = false;
            chkPatch.Checked = false;
           // DataTreeIni();
            chkSectionList.Items.Clear();//.Clear();
            chkTextList.Items.Clear();
            chkTextListSelect.Items.Clear();
            chkSectionListselect.Items.Clear();
            DataIniTextList(textnode.Nodes);
            DataSections();

            chkTextListSelect.Items.Clear();
            chkSectionListselect.Items.Clear();
            chkUserSelectList.Items.Clear();

            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now.AddHours(48);

            
        }

        #region 按钮操作
        private void btnTextAdd_Click(object sender, EventArgs e)
        {
            MoveItem(chkTextList, chkTextListSelect);
        }

        private void btnTextRemove_Click(object sender, EventArgs e)
        {
            MoveItem(chkTextListSelect,chkTextList,AryText);           
        }

        private void btnSecAdd_Click(object sender, EventArgs e)
        {
            MoveItem(chkSectionList, chkSectionListselect);
        }

        private void btnSecRemove_Click(object sender, EventArgs e)
        {
            MoveItem(chkSectionListselect,chkSectionList,ArySections);
        }

        private void btnUserAdd_Click(object sender, EventArgs e)
        {
            Uobject temp = GetUserInfoByGh(txtGh.Text);
            if (temp != null)
            {
                chkUserSelectList.Items.Add(temp);
            }
        }

        private void btnUserRemove_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < chkUserSelectList.CheckedItems.Count; i++)
            {
                Uobject temp = (Uobject)chkUserSelectList.CheckedItems[i];
                RemoveItem(temp.Id, chkUserSelectList);
            }
        }

        /// <summary>
        /// 授权设置确定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSure_Click(object sender, EventArgs e)
        {
            string textid = "";
            string relation = "";
            string rtype = "";
            string functions = "";
            string[] sqls = new string[2];

            if (chkCheck.Checked)
            {
                functions = functions + ","+chkCheck.Text;
            }
            if (chkUpdate.Checked)
            {
                functions = functions + "," + chkUpdate.Text;
            }
            if (chkCreate.Checked && chkPatch.Checked)
            {
                App.Msg("注意:创建和补录授权只能选择一个,请重新选择！");
                return;
            }
            else
            {
                if (chkCreate.Checked)
                {
                    functions = functions + "," + chkCreate.Text;
                }
                if (chkPatch.Checked)
                {
                    functions = functions + "," + chkPatch.Text;
                }
            }
            if (chkTextSelect.Checked)
            {

                for (int i = 0; i < chkTextListSelect.Items.Count; i++)
                {
                    Uobject temp = (Uobject)chkTextListSelect.Items[i];
                    if (textid == "")
                    {
                        textid = temp.Id;
                    }
                    else
                    {
                        textid = textid + "," + temp.Id;
                    }
                }               
            }
            else
            {
                textid = "0";
            }

            if (textid == "")
            {
                textid = "0";
            }

            if (radSectionSelect.Checked)
            {
                for (int i = 0; i < chkSectionListselect.Items.Count; i++)
                {
                    Uobject temp = (Uobject)chkSectionListselect.Items[i];
                    if (relation == "")
                    {
                        relation = temp.Id;
                    }
                    else
                    {
                        relation =relation+","+ temp.Id;
                    }
                }
                rtype = "S";
            }

            if (radUserSelect.Checked)
            {
                for (int i = 0; i < chkUserSelectList.Items.Count; i++)
                {
                    Uobject temp = (Uobject)chkUserSelectList.Items[i];
                    if (relation == "")
                    {
                        relation = temp.Id;
                    }
                    else
                    {
                        relation = relation + "," + temp.Id;
                    }
                }
                rtype = "P";
            }


            sqls[0] = "delete from T_SET_TEXT_RIGHTS where PATIENT_ID=" + Patient_Id + "";
            sqls[1] = "insert into T_SET_TEXT_RIGHTS(PATIENT_ID,TEXT_ID,RIGHT_TYPE,RELATION_ID,BEGIN_TIME,END_TIME,FUNCTIONS)values(" + Patient_Id + ",'" + textid + "','" + rtype + "','" + relation + "',to_timestamp('" + dateTimePicker1.Value.ToString()
                                                    + "','yyyy-MM-dd hh24:mi:ss'),to_timestamp('" + dateTimePicker2.Value.ToString()
                                                    + "','yyyy-MM-dd hh24:mi:ss'),'" + functions + "')";

            if (functions == "")
            {
                App.MsgWaring("请先选择要授权的权限！");
                return;
            }

            if (App.ExecuteBatch(sqls) > 0)
            {
                App.Msg("操作已经成功！");
                this.f.Close();
            }
        }

        private void chkTextSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTextSelect.Checked)
            {
                panel1.Enabled = true;
            }
            else
            {
                panel1.Enabled = false;
            }
        }

        private void radSectionSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (radSectionSelect.Checked)
            {
                panel2.Enabled = true;
            }
            else
            {
                panel2.Enabled = false;
            }
        }

        private void radUserSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (radUserSelect.Checked)
            {
                panel3.Enabled = true;
            }
            else
            {
                panel3.Enabled = false;
            }
        }
        #endregion

        private void txtGh_TextChanged(object sender, EventArgs e)
        {
            GetUserInfoByGh(txtGh.Text);            
        }

        private void chkUpdate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUpdate.Checked)
            {
                chkCheck.Checked = true;
            }
        }

        private void chkCreate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCreate.Checked)
            {
                chkCheck.Checked = true;
            }
        }

        private void chkPatch_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPatch.Checked)
            {
                chkCheck.Checked = true;
            }
        }    
        
    }  
}
