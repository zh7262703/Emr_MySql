using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using DevComponents.DotNetBar;
using Base_Function.BASE_COMMON;

namespace Base_Function.BLL_MANAGEMENT
{
    public partial class frmSectionCheck :Office2007Form
    {
        /// <summary>
        /// 刷新FlexGrid的事件
        /// </summary>
        public event ucYWCParam.DisplayUpdate ShowUpdate;
        public event ucYWCParam.DisplayTextBoxValue ShowTextBoxValue;


        #region 消息提醒使用
        /// <summary>
        /// 用来判断是否是消息提醒使用的代码
        /// </summary>
        int strT_Msg_Setting = 0;
        /// <summary>
        /// 用来接收科室id
        /// </summary>
        string STRMSGSECTION_IDS = "";
        /// <summary>
        /// 用来接收科室名称
        /// </summary>
        string STRMSG_SECTION_NAMES = "";
        /// <summary>
        /// 操作标志
        /// </summary>
        public bool flag = false; 
        #endregion

        #region 属性

        private static string ywcSectionID;

        /// <summary>
        /// 科室ID
        /// </summary>
        public static string YwcSectionID
        {
            get { return frmSectionCheck.ywcSectionID; }
            set { frmSectionCheck.ywcSectionID = value; }
        }



        private static string ywcSectionName;

        /// <summary>
        /// 科室名字
        /// </summary>
        public static string YwcSectionName
        {
            get { return frmSectionCheck.ywcSectionName; }
            set { frmSectionCheck.ywcSectionName = value; }
        }



        private static string documentType;

        /// <summary>
        /// 文书类型
        /// </summary>
        public static string DocumentType
        {
            get { return frmSectionCheck.documentType; }
            set { frmSectionCheck.documentType = value; }
        }

        private static string id;

        /// <summary>
        /// 质控规则ID
        /// </summary>
        public static string Id
        {
            get { return frmSectionCheck.id; }
            set { frmSectionCheck.id = value; }
        }
        #endregion

        public frmSectionCheck()
        {
            InitializeComponent();            
        }


        #region 消息提醒使用
        /// <summary>
        /// 消息发布使用的构造函数
        /// </summary>
        /// <param name="strType"></param>
        public frmSectionCheck(int strType)
        {
            InitializeComponent();
            strT_Msg_Setting = strType;
        }
        /// <summary>
        /// 消息提醒使用的构造函数
        /// </summary>
        /// <param name="strType"></param>
        /// <param name="strMSGSECTION_ID"></param>
        /// <param name="strMSG_SECTION_NAME"></param>
        public frmSectionCheck(int strType, string strMSGSECTION_ID, string strMSG_SECTION_NAME)
        {
            InitializeComponent();
            strT_Msg_Setting = strType;
            STRMSGSECTION_IDS = strMSGSECTION_ID;
            STRMSG_SECTION_NAMES = strMSG_SECTION_NAME;
        } 
        #endregion

        private void frmSectionCheck_Load(object sender, EventArgs e)
        {
            //老代码注释掉
            //DataSet dataSet = App.GetDataSet("select distinct(ts.sid),ts.section_name from t_Section_Area tsa inner join t_Sectioninfo ts on tsa.sid=ts.sid");

            #region 消息提醒使用
            DataSet dataSet = new DataSet();
            if (strT_Msg_Setting == 3)
            {
                dataSet = App.GetDataSet("select t.said as SID,t.sick_area_name as SECTION_NAME from T_SICKAREAINFO t");
            }
            else
            {
                if (strT_Msg_Setting == 2)
                {
                    dataSet = App.GetDataSet("select distinct(ts.sid),ts.section_name from  t_Sectioninfo ts");
                }
                else
                {
                    dataSet = App.GetDataSet("select distinct(ts.sid),ts.section_name from t_Section_Area tsa inner join t_Sectioninfo ts on tsa.sid=ts.sid");
                }
            } 
            #endregion

            Class_Sections[] class_Sections;
            int lenght = dataSet.Tables[0].Rows.Count;

            CheckBox[] ff = new CheckBox[lenght];
            for (int i = 0; i < lenght; i++)
            {
                class_Sections = new Class_Sections[lenght];
                class_Sections[i] = new Class_Sections();
                class_Sections[i].Sid = Convert.ToInt32(dataSet.Tables[0].Rows[i]["SID"].ToString());
                class_Sections[i].Section_Name = dataSet.Tables[0].Rows[i]["SECTION_NAME"].ToString();      

                chkSectionListBox.Items.Add(class_Sections[i]);
                chkSectionListBox.DisplayMember = "Section_Name";
                chkSectionListBox.ValueMember = "SID";
            }

            if (ucYWCParam.FlexSection != null)
            {
               // Con_CheckBoxListUtil.SetCheck(this.chkSectionListBox, frmYWCParam.FlexSection);

                //chkSectionListBox.Items.Clear();
                string[] temp = ucYWCParam.FlexSection.Split(',');
                foreach (string str in temp)
                {
                    for (int i = 0; i < chkSectionListBox.Items.Count; i++)
                    {
                        if (str == chkSectionListBox.GetItemText(chkSectionListBox.Items[i]))
                        {
                            chkSectionListBox.Items.RemoveAt(i); //除自身规则的科室以外，已被选择的科室则移除它
                        }
                    }
                }

                //Con_CheckBoxListUtil.RemoveExitItems(chkSectionListBox);
            }

            if (ywcSectionName != null)
            {
                Con_CheckBoxListUtil.SetCheck(this.chkSectionListBox, ywcSectionName);

                //老代码注释掉
                //this.groupBox1.Text = "文书类型为：[" + documentType + "]的科室列表";

                #region 消息提醒使用
                if (strT_Msg_Setting == 3)
                {
                    this.groupBox1.Text = "病区列表";
                }
                else if (strT_Msg_Setting == 1 || strT_Msg_Setting == 2)
                {
                    this.groupBox1.Text = "科室列表";
                }
                else
                {
                    this.groupBox1.Text = "文书类型为：[" + documentType + "]的科室列表";
                } 
                #endregion
            }
            else
            {
                //老代码注释掉
                //this.groupBox1.Text = "科室列表";
                #region 消息提醒使用
                if (strT_Msg_Setting == 3)
                {
                    this.groupBox1.Text = "病区列表";
                }
                else
                {
                    this.groupBox1.Text = "科室列表";
                } 
                #endregion

            }

            #region 消息提醒使用
            if (strT_Msg_Setting == 1 || strT_Msg_Setting == 2 || strT_Msg_Setting == 3)//消息提醒使用
            {
                // DataSet ds;
                if (STRMSGSECTION_IDS == "")//如果等于空，不需要进行选中提示
                {
                    for (int i = 0; i < chkSectionListBox.Items.Count; i++)
                    {
                        chkSectionListBox.SetItemChecked(i, false);
                    }
                    ywcSectionID = "";
                    ywcSectionName = "";
                }
            } 
            #endregion
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //老代码注释掉
            //ucYWCParam.DoubleModifyFlag = false;
            //ywcSectionName = null;
            //id = null;
            //this.Close();

            #region 消息提醒使用
            if (strT_Msg_Setting != 1 && strT_Msg_Setting != 2 && strT_Msg_Setting != 3)
            {
                ucYWCParam.DoubleModifyFlag = false;
                ywcSectionName = null;
                id = null;
                this.Close();
            }
            else//消息提醒使用
            {
                this.Close();
            } 
            #endregion

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (chkSectionListBox.CheckedItems.Count <= 0)
            {
                //老代码注释掉
                //App.MsgErr("请选择科室");
                //return;

                #region 消息提醒使用
                if (strT_Msg_Setting == 3)
                {
                    App.MsgErr("请选择病区");
                    return;
                }
                else
                {
                    App.MsgErr("请选择科室");
                    return;
                } 
                #endregion
            }

            if (id != null)
            {
                ywcSectionID = Con_CheckBoxListUtil.GetCheckedItems(chkSectionListBox);
                string tempUpdate = "update t_quality_var_ywc t set t.effect_section='" + ywcSectionID + "' where t.id="+id;

                int i = 0;
                DialogResult resultUpdate = MessageBox.Show("确认要保存已修改的数据？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (resultUpdate == DialogResult.OK)
                {
                    i = App.ExecuteSQL(tempUpdate);
                }
                else
                {
                    return;
                }

                if (i > 0)
                {
                    App.Msg("数据修改成功！");
                    ShowUpdate(true);                    
                    this.Close();
                    return;

                }
                else
                {
                    App.MsgErr("数据修改失败！");
                    return;
                }
            }
            else
            {

                DialogResult resultInsert = MessageBox.Show("确认要保存数据？", "消息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (resultInsert == DialogResult.OK)
                {
                    //老代码注释掉
                    //ywcSectionID = Con_CheckBoxListUtil.GetCheckedItems(chkSectionListBox);
                    //ywcSectionName = Con_CheckBoxListUtil.GetCheckedItemsValue(chkSectionListBox);
                    //ShowTextBoxValue();
                    //this.Close();
                    #region  消息提醒使用
                    flag = true;//消息提醒
                    if (strT_Msg_Setting != 1 && strT_Msg_Setting != 2 && strT_Msg_Setting != 3)
                    {
                        ywcSectionID = Con_CheckBoxListUtil.GetCheckedItems(chkSectionListBox);
                        ywcSectionName = Con_CheckBoxListUtil.GetCheckedItemsValue(chkSectionListBox);
                        ShowTextBoxValue();
                        this.Close();
                    }
                    else//消息提醒使用
                    {

                        ywcSectionID = Con_CheckBoxListUtil.GetCheckedItems(chkSectionListBox);
                        ywcSectionName = Con_CheckBoxListUtil.GetCheckedItemsValue(chkSectionListBox);
                        this.Close();
                    }
                    
                    #endregion
                }
            }
        }

    }
}