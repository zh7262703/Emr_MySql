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
    public partial class ucSection : UserControl
    {
        bool IsSave = false;　            //用于存放当前的操作状态 true为添加操作 false为修改操作
        private  string inspection = "Y"; //是否为检查科
        private  string Science = "Y";    //是否为大科
        private  string Hospital = "I";　//住院及门诊科室标志
        private  string Mark = "Y";      //有效标志
        private  string ID="";          //获取当前的ID
        private string T_section_Sql;  //科室查询
        Class_Sections[] section;
        private string section_code;   //当前选中的科室编号
        private string section_name;   //当前选中的科室名称
        DataSet ds;
        public ucSection()
        {
            InitializeComponent();
            T_section_Sql =@" select SID as 编号,SECTION_CODE as 科室编号,SECTION_NAME as 科室名称,BELONGTO_SECTION_ID as 所属核算科室,(case when ISCHECKSECTION='Y' then '是' else '否' end) as 是否是检查科,
                            BELONGTO_SECTION_NAME as 核算科名称,BELONGTO_BIGSECTION_ID 所属大科,(select SECTION_NAME from T_SECTIONINFO b where b.SID=a.BELONGTO_BIGSECTION_ID) as 大科名称,
                            (case when ISBELONGTOBIGSECTION='Y' then '是' else '否' end) as 是否大科,TYPEINFO as 类别编号,g.name as 类别,
                            (case when IN_FLAG='I' then '住院' else '门诊' end) as 住院及门诊标志,MANAGE_TYPE as 科室管理属性编号,s.name as 科室管理属性,
                            (case when ENABLE_FLAG='Y' then '有效' else '无效' end) as 有效标志,
                            a.SHID as 分院编号,c.sub_hospital_name as 分院名称 from T_SECTIONINFO a inner join T_SUB_HOSPITALINFO c on a.shid=c.shid inner join T_DATA_CODE s on a.manage_type=s.id inner join T_DATA_CODE g on a.typeinfo=g.id  where 1=1 ";//ENABLE_FLAG='Y'";
        }

        private void frmSection_Load(object sender, EventArgs e)
        {
            //App.SetMainFrmMsgToolBarText("科室信息");
            //显示列表数据
            ShowValue();
            ucGridviewX1.fg.Click += new EventHandler(ucC1FlexGrid1_Click);
            //ucGridviewX1.fg.CellValueChanged += new EventHandler(CurrentDataChange);
            ucGridviewX1.fg.AllowUserToAddRows = false;
            //绑定大科
            BigSenction();
            //绑定分院
            HospitalInfo();
            //绑定科室管理属性
            Property();
            //绑定类型
            Type();
            cboBigscience.SelectedIndex = 0;
            RefleshFrm();
            ucGridviewX1.fg.AutoResizeColumns();

        }

        private void CurrentDataChange(object sender, EventArgs e)
        {

            try
            {

                ucGridviewX1.fg.Columns["编号"].Visible = false;
                ucGridviewX1.fg.Columns["编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["所属大科"].Visible = false;
                ucGridviewX1.fg.Columns["所属大科"].ReadOnly = true;
                ucGridviewX1.fg.Columns["类别编号"].Visible = false;
                ucGridviewX1.fg.Columns["类别编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["科室管理属性编号"].Visible = false;
                ucGridviewX1.fg.Columns["科室管理属性编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["分院编号"].Visible = false;
                ucGridviewX1.fg.Columns["分院编号"].ReadOnly = true;
                ucGridviewX1.fg.ReadOnly = true;
            }

            catch
            { }
                 
        }

        //显示列表数据
        private void ShowValue()
        {
            string Sql = T_section_Sql + "  order by SID desc";
            ds = App.GetDataSet(Sql);
            if (ds != null)
            {
                ucGridviewX1.DataBd(Sql, "编号", false, "", "");
                ucGridviewX1.fg.Columns["编号"].Visible = false;
                ucGridviewX1.fg.Columns["编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["所属大科"].Visible = false;
                ucGridviewX1.fg.Columns["所属大科"].ReadOnly = true;
                ucGridviewX1.fg.Columns["类别编号"].Visible = false;
                ucGridviewX1.fg.Columns["类别编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["科室管理属性编号"].Visible = false;
                ucGridviewX1.fg.Columns["科室管理属性编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["分院编号"].Visible = false;
                ucGridviewX1.fg.Columns["分院编号"].ReadOnly = true;
                ucGridviewX1.fg.ReadOnly = true;
            }    
        }


      /// <summary>
      /// 绑定大科
      /// </summary>
        private void BigSenction()
        {
            cboBigscience.Items.Clear();
            Class_Sections none = new Class_Sections();
            none.Sid = 0;
            none.Section_Code = "无";
            none.Section_Name = "无";
            none.Belongto_Section_Id = "无";
            none.isCheckSection = "无";
            none.Belongto_Section_Name = "无";
            none.Belongto_BigSection_ID = "无";
            none.isBelongToBigSection = "无";
            none.Type = "无";
            none.Inout_flag = "无";
            none.Manage_type = "无";
            none.State = "无";
            none.Belongto_hospital = "无";
            cboBigscience.Items.Add(none);
                  
            string sql = "select * from T_SECTIONINFO  where ISBELONGTOBIGSECTION='Y' and ENABLE_FLAG='Y'";
            DataSet ds = App.GetDataSet(sql);
            section= new Class_Sections[ds.Tables[0].Rows.Count]; 
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                section[i] = new Class_Sections();
                section[i].Sid =Convert.ToInt32( ds.Tables[0].Rows[i]["SID"].ToString());
                section[i].Section_Code = ds.Tables[0].Rows[i]["SECTION_CODE"].ToString();
                section[i].Section_Name = ds.Tables[0].Rows[i]["SECTION_NAME"].ToString();
                section[i].Belongto_Section_Id = ds.Tables[0].Rows[i]["BELONGTO_SECTION_ID"].ToString();
                section[i].isCheckSection = ds.Tables[0].Rows[i]["ISCHECKSECTION"].ToString();
                section[i].Belongto_Section_Name = ds.Tables[0].Rows[i]["BELONGTO_SECTION_NAME"].ToString();
                section[i].Belongto_BigSection_ID = ds.Tables[0].Rows[i]["BELONGTO_BIGSECTION_ID"].ToString();
                section[i].isBelongToBigSection = ds.Tables[0].Rows[i]["ISBELONGTOBIGSECTION"].ToString();
                section[i].Type = ds.Tables[0].Rows[i]["TYPEINFO"].ToString();
                section[i].Inout_flag = ds.Tables[0].Rows[i]["IN_FLAG"].ToString();
                section[i].Manage_type = ds.Tables[0].Rows[i]["MANAGE_TYPE"].ToString();
                section[i].State = ds.Tables[0].Rows[i]["ENABLE_FLAG"].ToString();
                section[i].Belongto_hospital = ds.Tables[0].Rows[i]["SHID"].ToString();
                cboBigscience.Items.Add(section[i]);
                
            }

                cboBigscience.ValueMember = "SID";
                cboBigscience.DisplayMember = "SECTION_NAME";
               
                //cboBigscience.SelectedValue = "SID";

        }
        //所属分院
        private void HospitalInfo()
        {
            DataSet ds = App.GetDataSet("select * from T_SUB_HOSPITALINFO");
            cboBranchcourts.DataSource = ds.Tables[0].DefaultView;
            cboBranchcourts.ValueMember = "SHID";
            cboBranchcourts.DisplayMember = "SUB_HOSPITAL_NAME";
        }
        //绑定科室管理属性
        private void Property()
        {
            DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='8'");
            cboProperty.DataSource = ds.Tables[0].DefaultView;
            cboProperty.ValueMember = "ID";
            cboProperty.DisplayMember = "NAME";
        }
        //绑定类型
        private void Type()
        {
            DataSet ds = App.GetDataSet("select * from  T_DATA_CODE where Type='9'");
            cboType.DataSource = ds.Tables[0].DefaultView;
            cboType.ValueMember = "ID";
            cboType.DisplayMember = "NAME";
        }
        /// <summary>
        /// 刷新
        /// </summary>
        private void RefleshFrm()
        {

            txtID.Enabled = false;
            txtName.Enabled = false;
            cboOffice.Enabled = false;
            rbtnYes.Enabled = false;
            rbtnNo.Enabled = false;
            cboComputation.Enabled = false;
            cboBigscience.Enabled = false;
            rdtnScienceYes.Enabled = false;
            rdtnScienceNo.Enabled = false;
            cboType.Enabled = false;
            rbtnHospital.Enabled = false;
            rbtnOutpatient.Enabled = false;
            cboProperty.Enabled = false;
            rbtnValidmark.Enabled = false;
            rbtnVainmark.Enabled = false;
            cboBranchcourts.Enabled = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            groupPanel2.Enabled = true;
            IsSave = false;

        }

        /// <summary>
        /// 编辑状态
        /// </summary>
        /// <param Name="flag"></param>
        private void Edit(bool flag)
        {
            if (flag)
            {
                txtID.Text = "";
                txtName.Text = "";
                cboOffice.Text = "";
                cboComputation.Text = "";
            }
            txtID.Enabled = true;
            txtName.Enabled = true;
            cboOffice.Enabled =false;
            rbtnYes.Enabled = true;
            rbtnNo.Enabled = true;
            cboComputation.Enabled = false;
            cboBigscience.Enabled = true;
            rdtnScienceYes.Enabled = true;
            rdtnScienceNo.Enabled = true;
            cboType.Enabled = true;
            rbtnHospital.Enabled = true;
            rbtnOutpatient.Enabled = true;
            cboProperty.Enabled = true;
            rbtnValidmark.Enabled = true;
            rbtnVainmark.Enabled = true;
            cboBranchcourts.Enabled = true;
            btnAdd.Enabled = false ;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            groupPanel2.Enabled = false;
           
            if (rdtnScienceYes.Checked == true)
            {
                cboBigscience.Enabled = false;
                cboBigscience.SelectedIndex = -1;
            }
            else
            {
                cboBigscience.Enabled = true;
            }
            

            txtID.Focus();
        }

        /// <summary>
        /// 判断是否出现重名
        /// </summary>
        /// <param Name="Name"></param>
        /// <returns></returns>
        private bool isExisitNames(string id)
        {
            DataSet ds = App.GetDataSet("select * from T_SECTIONINFO  where SECTION_CODE='" + id + "'");
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
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
        /// <summary>
        /// 判断是否出现重名
        /// </summary>
        /// <param Name="Name"></param>
        /// <returns></returns>
        private bool Isnames(string name)
        {
            DataSet ds = App.GetDataSet("select * from T_SECTIONINFO  where SECTION_NAME='" + name + "'");
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
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
        /// <summary>
        /// 添加
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            IsSave = true;
            Edit(IsSave);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            IsSave = false;
            Edit(IsSave);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text.Trim() == "")
                {
                    App.Msg("科室信息编号必须填写！");
                    txtID.Focus();
                    return;
                }
                if (txtName.Text.Trim() == "")
                {
                    App.Msg("科室名称必须填写！");
                    txtName.Focus();
                    return;
                }
             
                //是否为检查科
                if (!rbtnYes.Checked)
                {
                    inspection = "N";
                }
 
                //是否为大科
                if (!rdtnScienceYes.Checked)
                {
                    Science = "N";
                }
                if (cboType.Text.Trim() == "")
                {
                    App.Msg("类型必须填写！");
                    cboType.Focus();
                    return;
                }
                //住院及门诊科室标志
                if (!rbtnHospital.Checked)
                {
                    Hospital = "O";
                }
                if (cboProperty.Text.Trim() == "")
                {
                    App.Msg("科室管理属性必须填写！");
                    cboProperty.Focus();
                    return;
                }
                //有效标志
                if (!rbtnValidmark.Checked)
                {
                    Mark = "N";
                }
                if (cboBranchcourts.Text.Trim() == "")
                {
                    App.Msg("所属分院必须填写！");
                    cboBranchcourts.Focus();
                    return;
                }
                string sql = "";
                string bigid = "";
                if (rdtnScienceYes.Checked)
                {
                    bigid = null;
                }
                else
                {
                    if (cboBigscience.SelectedItem!= null)
                    {
                        Class_Sections temp = (Class_Sections)cboBigscience.SelectedItem;
                        bigid = temp.Sid.ToString();
                    }
                }
               
                ID = App.GenId("T_SECTIONINFO", "SID").ToString();
                if (IsSave)
                {
                    if (isExisitNames(App.ToDBC(txtID.Text.Trim())))
                    {
                        App.Msg("已经存在了相同的科室编号了！");
                        txtID.Focus();
                        return;
                    }
                    else if (Isnames(App.ToDBC(txtName.Text.Trim())))
                    {
                        App.Msg("已经存在了相同的科室名称了！");
                        txtName.Focus();
                        return;
                    }
                   
                    sql = "insert into T_SECTIONINFO(SID,SECTION_CODE,SECTION_NAME,BELONGTO_SECTION_ID,ISCHECKSECTION,BELONGTO_SECTION_NAME,BELONGTO_BIGSECTION_ID,ISBELONGTOBIGSECTION,TYPEINFO,IN_FLAG,MANAGE_TYPE,ENABLE_FLAG,SHID) values('"
                         +ID+"','"
                         + txtID.Text + "','"
                         + txtName.Text + "','"
                         + cboOffice.Text + "','"
                         + inspection + "','"
                         + cboComputation.Text + "','"
                         + bigid + "','"
                         + Science + "','"
                         + cboType.SelectedValue+ "','"
                         + Hospital + "','"
                         + cboProperty.SelectedValue+ "','"
                         + Mark + "','"
                         + cboBranchcourts.SelectedValue + "')";
                    btnAdd_Click(sender, e);

                }
                else
                {
                    if (section_code.Trim() != "")
                    {
                        if (txtID.Text.Trim() != section_code.Trim())
                        {
                            if (isExisitNames(App.ToDBC(txtID.Text.Trim())))
                            {
                                App.Msg("已经存在了相同的科室编号了！");
                                txtID.Focus();
                                return;
                            }
                        }
                    }
                    else if (section_name.Trim() != "")
                    {
                        if (txtName.Text.Trim() != section_name.Trim())
                        {
                          if (Isnames(App.ToDBC(txtName.Text.Trim())))
                            {
                                App.Msg("已经存在了相同的科室名称了！");
                                txtName.Focus();
                                return;
                            }
                        }
                    }
                    sql = "update T_SECTIONINFO set SECTION_CODE='"
                              + txtID.Text + "',SECTION_NAME='"
                              + App.ToDBC(txtName.Text) + "',BELONGTO_SECTION_ID='"
                              + cboOffice.Text + "',ISCHECKSECTION='"
                              + inspection + "',BELONGTO_SECTION_NAME='"
                              + cboComputation.Text + "',BELONGTO_BIGSECTION_ID='"
                              + bigid+ "',ISBELONGTOBIGSECTION='"
                              + Science + "',TYPEINFO='"
                              + cboType.SelectedValue + "',IN_FLAG='"
                              + Hospital + "',MANAGE_TYPE='"
                              + cboProperty.SelectedValue+ "',ENABLE_FLAG='"
                              + Mark + "',SHID='"
                              + cboBranchcourts.SelectedValue + "' where SID='" + ucGridviewX1.fg["编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "'";

                }
                if (sql != "")
                    if (App.ExecuteSQL(sql) > 0)
                    {
                        App.Msg("操作成功！");
                        btnCancel_Click(sender, e);
                    }

                //显示列表数据
                ShowValue();
                //string Sql = T_section_Sql + "  order by SID asc";
                //ucC1FlexGrid1.DataBd(Sql, "SID", "SID,SECTION_CODE,SECTION_NAME,BELONGTO_SECTION_ID,ISCHECKSECTION,BELONGTO_SECTION_NAME,BELONGTO_BIGSECTION_ID,ISBELONGTOBIGSECTION,TYPEINFO,TYPEINFO_NAME,IN_FLAG,MANAGE_TYPE,MANAGE_TYPE_NAME,ENABLE_FLAG,SHID,SHID_NAME", "编号,科室编号,科室名称,所属核算科室,是否是检查科,核算科名称,所属大科,是否大科,类别编号,类别,住院及门诊标志,科室管理属性编号,科室管理属性,有效标志,分院编号,分院名称");
            }
            catch (Exception ex)
            {
                App.Msg("添加失败，原因：" + ex.ToString() + "");
            }
        }


        /// <summary>
        /// 取消
        /// </summary>
        /// <param Name="sender"></param>
        /// <param Name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            refurbish();
            //RefleshFrm();
        }

       /// <summary>
       /// 删除科室信息
       /// </summary>
       /// <param Name="sender"></param>
       /// <param Name="e"></param>
     
        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnDelete_Click(sender,e);
        }
            /// 刷新表格
        /// </summary>
        private void refurbish()
        {
            txtID.Text = "";
            txtName.Text = "";
            cboOffice.Text = "";
            cboComputation.Text = "";
            txtID.Enabled = false;
            txtName.Enabled = false;
            cboOffice.Enabled = false;
            rbtnYes.Enabled = false;
            rbtnNo.Enabled = false;
            cboComputation.Enabled = false;
            cboBigscience.Enabled = false;
            rdtnScienceYes.Enabled = false;
            rdtnScienceNo.Enabled = false;
            cboType.Enabled = false;
            rbtnHospital.Enabled = false;
            rbtnOutpatient.Enabled = false;
            cboProperty.Enabled = false;
            rbtnValidmark.Enabled = false;
            rbtnVainmark.Enabled = false;
            cboBranchcourts.Enabled = false;
            btnAdd.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            groupPanel2.Enabled = true;
            //groupBox1.Enabled = true;
        }
        /// <summary>
        /// 删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (App.Ask("你是否要删除"))
            {
                DataSet ds = App.GetDataSet("select Count(*) from T_SECTION_AREA where SID=" + ucGridviewX1.fg["编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "");
                if (ds.Tables[0].Rows[0][0].ToString().Trim() == "0")
                {
                    string sqlup = "update  T_SECTIONINFO set ENABLE_FLAG='N' where SID=" + ucGridviewX1.fg["编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "";
                    App.ExecuteSQL(sqlup);
                }
                else
                {
                    if (App.Ask("该科室信息已经与病区或其它相关联，点击“是”删除科室并解除关联!"))
                    {
                        string sqlup = "update  T_SECTIONINFO set ENABLE_FLAG='N' where SID=" + ucGridviewX1.fg["编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() + "";
                        App.ExecuteSQL(sqlup);
                    }
                }
            }
            //显示列表数据
            ShowValue();
            refurbish();
            //string Sql = T_section_Sql + "   order by SID asc";
            //ucC1FlexGrid1.DataBd(Sql, "SID", "SID,SECTION_CODE,SECTION_NAME,BELONGTO_SECTION_ID,ISCHECKSECTION,BELONGTO_SECTION_NAME,BELONGTO_BIGSECTION_ID,ISBELONGTOBIGSECTION,TYPEINFO,TYPEINFO_NAME,IN_FLAG,MANAGE_TYPE,MANAGE_TYPE_NAME,ENABLE_FLAG,SHID,SHID_NAME", "编号,科室编号,科室名称,所属核算科室,是否是检查科,核算科名称,所属大科,是否大科,类别编号,类别,住院及门诊标志,科室管理属性编号,科室管理属性,有效标志,分院编号,分院名称");
        }
        int Rowcount = 0;
       /// <summary>
       /// 单击表格
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void ucC1FlexGrid1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ucGridviewX1.fg.Rows.Count> 0)
                {
                    ID =ucGridviewX1.fg["编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    txtID.Text = ucGridviewX1.fg["科室编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    section_code = txtID.Text;
                    txtName.Text = ucGridviewX1.fg["科室名称", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    section_name = txtName.Text;
                    cboOffice.Text = ucGridviewX1.fg["所属核算科室", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    if (ucGridviewX1.fg["是否是检查科", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() == "是")
                    {
                        rbtnYes.Checked = true;
                    }
                    else
                    {
                        rbtnNo.Checked = true;
                    }
                    cboComputation.Text = ucGridviewX1.fg["核算科名称", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    cboBigscience.SelectedItem = null;
                    if (ucGridviewX1.fg["是否大科", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() == "是")
                    {
                        rdtnScienceYes.Checked = true;
                        cboBigscience.SelectedItem = null;
                    }
                    else
                    {
                        rdtnScienceNo.Checked = true;
                        string sid = "";
                        if (ucGridviewX1.fg["所属大科", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                        {
                            //cboBigscience.SelectedValue = Convert.ToInt32();

                            sid = ucGridviewX1.fg["所属大科", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                            SelectValues(sid);
                        }
                        else
                        {
                            SelectValues(sid);
                        }

                    }
                    if (ucGridviewX1.fg["类别编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                    {
                        cboType.SelectedValue = ucGridviewX1.fg["类别编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();
                    }
                    if (ucGridviewX1.fg["住院及门诊标志",ucGridviewX1.fg.CurrentRow.Index].Value.ToString() == "住院")
                    {
                        rbtnHospital.Checked = true;
                    }
                    else
                    {
                        rbtnOutpatient.Checked = true;
                    }
                    if (ucGridviewX1.fg["科室管理属性编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                    {
                        cboProperty.SelectedValue = ucGridviewX1.fg["科室管理属性编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString();

                    }
                    if (ucGridviewX1.fg["有效标志",ucGridviewX1.fg.CurrentRow.Index].Value.ToString() == "有效")
                    {
                        rbtnValidmark.Checked = true;
                    }
                    else
                    {
                        rbtnVainmark.Checked = true;
                    }
                    if (ucGridviewX1.fg["分院编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString() != "")
                    {
                        cboBranchcourts.SelectedValue = Convert.ToInt32(ucGridviewX1.fg["分院编号", ucGridviewX1.fg.CurrentRow.Index].Value.ToString());

                    }
                    cboBranchcourts.Refresh();
                   

                }
            }
            catch (Exception ex)
            {
                App.MsgErr(ex.Message);
            }
        }
        /// <summary>
        /// 根据表格选中下拉列表
        /// </summary>
        /// <returns></returns>
        public void SelectValues(string sid)
        {
            //bool flag = false;
            foreach (object var in cboBigscience.Items)
            {
                Class_Sections class_Section = var as Class_Sections;
                if (sid == class_Section.Sid.ToString())
                {
                    cboBigscience.SelectedItem = var;
                    break;
                }
                else
                {
                    cboBigscience.SelectedIndex = 0;
                }
            }
        }
        private void chkName_CheckedChanged(object sender, EventArgs e)
        {
            if (chkName.Checked)
            {
                chkId.Checked = false;
            }
            else
            {
                chkId.Checked = true;
                txtBox.Text = "";
            }
        }

        private void chkId_CheckedChanged(object sender, EventArgs e)
        {
            if (chkId.Checked)
            {
                chkName.Checked = false;
            }
            else
            {
                chkName.Checked = true;
                txtBox.Text = "";
            }
        }
       /// <summary>
       /// 查找
       /// </summary>
       /// <param Name="sender"></param>
       /// <param Name="e"></param>
        private void btnLookup_Click(object sender, EventArgs e)
        {
            try
            {
                btnLookup.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                string Sql = T_section_Sql + "  order by SID desc";
              
                if (txtBox.Text.Contains("'"))
                {
                    App.Msg("该查询条件存在SQL注入的危险！");
                    txtBox.Focus();
                    return;
                }
        　　　　//按科室名称进行查询
                if (chkName.Checked)
                {

                    if (txtBox.Text.Trim() != "")
                    {
                        Sql = T_section_Sql + " and  SECTION_NAME　like'%" + txtBox.Text.Trim() + "%' order by SID desc";
                        
                    }

                }
                //按科室编号进行查询
                else if (chkId.Checked)
                {
                    if (txtBox.Text.Trim() != "")
                    {
                        Sql = T_section_Sql + " and SECTION_CODE like'%" + txtBox.Text.Trim() + "%' order by SID desc";
                        
                    }
                }

                ucGridviewX1.DataBd(Sql, "编号", false, "", "");
                ucGridviewX1.fg.Columns["编号"].Visible = false;
                ucGridviewX1.fg.Columns["编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["所属大科"].Visible = false;
                ucGridviewX1.fg.Columns["所属大科"].ReadOnly = true;
                ucGridviewX1.fg.Columns["类别编号"].Visible = false;
                ucGridviewX1.fg.Columns["类别编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["科室管理属性编号"].Visible = false;
                ucGridviewX1.fg.Columns["科室管理属性编号"].ReadOnly = true;
                ucGridviewX1.fg.Columns["分院编号"].Visible = false;
                ucGridviewX1.fg.Columns["分院编号"].ReadOnly = true;
                ucGridviewX1.fg.ReadOnly = true;
               
            }
            catch(Exception ex)
            {

            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnLookup.Enabled = true;
            }
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtName.Focus();

            }
   
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboType.Focus();
            }
     
        }


        private void cboType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rbtnYes.Focus();
            }

        }

        private void rbtnYes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rdtnScienceYes.Focus();
                //cboComputation.Focus();
            }

        }

        private void rbtnNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rdtnScienceYes.Focus();
                //cboComputation.Focus();
            }

        }

        private void cboComputation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboBigscience.Focus();
            }

        }
        private void cboOffice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rdtnScienceYes.Focus();
            }

        }

 

        private void rdtnScienceYes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rbtnHospital.Focus();              
                
            }

        }

        private void rdtnScienceNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboBigscience.Focus();
                //cboType.Focus();
            }

        }

        private void cboBigscience_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rbtnHospital.Focus();
            }

        }
        private void rbtnHospital_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboProperty.Focus();
            }

        }

        private void rbtnOutpatient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboProperty.Focus();
            }

        }

        private void cboProperty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                rbtnValidmark.Focus();
            }

        }

        private void rbtnValidmark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboBranchcourts.Focus();
            }

        }

        private void rbtnVainmark_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboBranchcourts.Focus();
            }

        }

        private void cboBranchcourts_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(sender, e);
            }

        }

        private void rdtnScienceYes_CheckedChanged(object sender, EventArgs e)
        {
            if (rdtnScienceYes.Checked == true)
            {
                if (btnCancel.Enabled)
                {
                    cboBigscience.Enabled = false;
                    cboBigscience.SelectedIndex = -1;
                }
               
            }            
        }

        private void rdtnScienceNo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdtnScienceNo.Checked == true)
            {
                BigSenction();
                if (btnCancel.Enabled)
                    cboBigscience.Enabled = true;
              cboBigscience.SelectedIndex = 0;
             
            }
        }

 




  

      


    }
}