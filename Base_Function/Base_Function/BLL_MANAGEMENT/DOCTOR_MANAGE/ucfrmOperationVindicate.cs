using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using System.Collections;
using C1.Win.C1FlexGrid;
using Base_Function.BASE_COMMON;

namespace Base_Function.BLL_MANAGEMENT.DOCTOR_MANAGE
{
    /// <summary>
    /// 手术维护
    /// </summary>
    /// 开发 李伟
    /// 时间 2010年9月14号
    public partial class ucfrmOperationVindicate : UserControl
    {
        UserRights userRights = new UserRights();
        public ucfrmOperationVindicate()
        {

            try
            {
                InitializeComponent();
                ffding = new ucLeverContact("丁");
                ffbing = new ucLeverContact("丙");
                ffyi = new ucLeverContact("乙");
                ffjia = new ucLeverContact("甲");

                ffding.Height = 172;
                ffding.Dock = System.Windows.Forms.DockStyle.Top;
                panel4.Controls.Add(ffding);

                ffbing.Height = 172;
                ffbing.Dock = System.Windows.Forms.DockStyle.Top;
                panel4.Controls.Add(ffbing);

                ffyi.Height = 172;
                ffyi.Dock = System.Windows.Forms.DockStyle.Top;
                panel4.Controls.Add(ffyi);


                ffjia.Height = 172;
                ffjia.Dock = System.Windows.Forms.DockStyle.Top;

                panel4.Controls.Add(ffjia);
                SetucC1FlexGrid3();
                SettabPages4();
            }
            catch 
            {
                
            }

        }
        public ucfrmOperationVindicate(ArrayList buttonRights)
        {

            try
            {
                InitializeComponent();
                ffding = new ucLeverContact("丁");
                ffbing = new ucLeverContact("丙");
                ffyi = new ucLeverContact("乙");
                ffjia = new ucLeverContact("甲");

                ffding.Height = 172;
                ffding.Dock = System.Windows.Forms.DockStyle.Top;
                panel4.Controls.Add(ffding);

                ffbing.Height = 172;
                ffbing.Dock = System.Windows.Forms.DockStyle.Top;
                panel4.Controls.Add(ffbing);

                ffyi.Height = 172;
                ffyi.Dock = System.Windows.Forms.DockStyle.Top;
                panel4.Controls.Add(ffyi);


                ffjia.Height = 172;
                ffjia.Dock = System.Windows.Forms.DockStyle.Top;

                panel4.Controls.Add(ffjia);
                SetucC1FlexGrid3();
                SettabPages4();
                //查询
                this.btnQuery.Enabled = false;
                this.btnSheDing.Enabled = false;
                //确定
                this.btnconfirm.Enabled = false;
                this.btnQueDing.Enabled = false;
                this.btnConfirmTeShu.Enabled = false;
                //添加
                this.btnAdd.Enabled = false;
                //修改
                this.btnUpdate.Enabled = false;
                //取消
                this.btnCancel.Enabled = false;
                //删除
                this.btnDelete.Enabled = false;
                //查看的权利
                if (userRights.isExistRole("tsbtnLook", buttonRights))
                {
                    this.btnQuery.Enabled = true;
                    this.btnSheDing.Enabled = true;
                }
                //书写的权利
                if (userRights.isExistRole("tsbtnWrite", buttonRights))
                {
                    this.btnAdd.Enabled = true;
                    this.btnconfirm.Enabled = true;
                    this.btnQueDing.Enabled = true;
                    this.btnConfirmTeShu.Enabled = true;
                    this.btnCancel.Enabled = true;
                }
                //修改的权利
                if (userRights.isExistRole("tsbtnModify", buttonRights))
                {
                    this.btnUpdate.Enabled = true;
                    this.btnQueDing.Enabled = true;
                    this.btnCancel.Enabled = true;
                }
                //删除的权利
                if (userRights.isExistRole("tsbtnDelete", buttonRights))
                {
                    this.btnDelete.Enabled = true;
                }
            }
            catch
            {

            }

        }
        ucLeverContact ffjia;
        ucLeverContact ffyi;
        ucLeverContact ffbing;
        ucLeverContact ffding;


        int rowsSel = 0;
        Dictionary<int, bool[]> Checks = new Dictionary<int, bool[]>();

        private ArrayList Sqls = new ArrayList();//保存 插入甲乙丙丁和 删除甲乙丙丁的sql语句
        private ArrayList SqlsTeShu = new ArrayList();

        //定义特殊手术集合
        private List<ucLeverContact> list = new List<ucLeverContact>();
        
        ucLeverContact ff;//特殊手术的用户控件
        private void SettabPages4()
        {
            list.Clear();
            this.panel2.Controls.Clear();//首先把全部panel2里面的特殊手术全部清空
            for (int i = this.ucC1FlexGrid3.fg.Rows.Count - 1; i > 0; i--)
            {
                string str = "特殊手术类型";
                /*
                 * 思路就是:项目类型长度太长，想要换行，每行定义6个长度，大于6个长度的就在6个
                 * 长度后面加个\n
                 */
                //定义原来的项目类型值
                string ucc1Value = ucC1FlexGrid3.fg[i, "项目类型"].ToString();
                //定义换行后的值

                string old = "";
                //记录最后要插入\n时的长度的值
                int sd = 0;
                //每隔6个长度就插入一个\n
                for (int j = 0; j <= ucc1Value.Length; j += 6)
                {
                    //长度不等于0的时候
                    if (j != 0)
                    {
                        //这个值就截取6个长度出来，加个换行进去
                        old += ucc1Value.Substring(j - 6, 6) + "\n";
                    }
                    //最终换行时的长度值
                    sd = j;
                }
                //在最后插入\n了之后又不足6个的，就要把他加进去
                if (ucc1Value.Length - sd > 0 && ucc1Value.Length > 6)
                {
                    //把换了行的（6个长度）和不足6个长度的值加起来
                    old = old + ucc1Value.Substring(sd, ucc1Value.Length - sd);
                    //Font a = new FontSize();

                    //FontSize a = FontSize.Find(1);
                    //System.Drawing.Font a = new Font(old,9F,FontStyle.Bold);
                }
                else
                {
                    //没的6个长度的值
                    old = ucc1Value;
                    Font a = new Font(old, 10);
                }
                ff = new ucLeverContact(old, str, 9);

                ff.Tag = this.ucC1FlexGrid3.fg[i, "ID"].ToString();//与ID关联
                ff.SetTeShuChecked(ff.Tag.ToString());//根据数据表里面的ID对应的查询出选中的医生
                ff.Height = 172;
                ff.Dock = System.Windows.Forms.DockStyle.Top;
                list.Add(ff);//用集合把每项特殊手术保存起来
                this.panel2.Controls.Add(ff);//显示
            }
        }

        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        private void SetUCflgview()
        {
            string qureySql = "select Oper_level as 手术等级, is_appr as 是否审批2,oper_code as 手术代码," +
                            " name as 手术名称,code as ICD9编码,shortcut1 as " +
                            " 拼音码, shortcut2 as 五笔码,is_enable as 是否有效2 from oper_def_icd9 where 1=1 ";
            ds = App.GetDataSet(qureySql);
            dt = ds.Tables[0];

            DataColumn dc = new DataColumn("是否审批", typeof(bool));
            dc.DefaultValue = false;
            dt.Columns.Add(dc);

            DataColumn dc1 = new DataColumn("是否有效", typeof(string));
            //dc.DefaultValue = false;
            dt.Columns.Add(dc1);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["是否审批"] = dt.Rows[i]["是否审批2"].ToString() == "Y" ? true : false;
                dt.Rows[i]["是否有效"] = dt.Rows[i]["是否有效2"].ToString() == "Y" ? "是" : "否";
            }
            this.ucC1FlexGridOperation.fg.DataSource = dt;

            this.ucC1FlexGridOperation.fg.Cols["是否审批"].Move(2);
            CellStyle cs = this.ucC1FlexGridOperation.fg.Styles.Add("手术等级");
            cs.DataType = typeof(string);
            this.ucC1FlexGridOperation.fg.Cols["手术等级"].Style.ComboList = " |甲|乙|丙|丁";

            this.ucC1FlexGridOperation.fg.Cols["是否审批2"].Visible = false;
            this.ucC1FlexGridOperation.fg.Cols["是否审批2"].AllowEditing = false;

            this.ucC1FlexGridOperation.fg.Cols["是否有效2"].Visible = false;
            this.ucC1FlexGridOperation.fg.Cols["是否有效2"].AllowEditing = false;

            ucC1FlexGridOperation.fg.Cols["手术等级"].Width = 100;
            ucC1FlexGridOperation.fg.Cols["是否审批"].Width = 100;
            ucC1FlexGridOperation.fg.Cols["手术代码"].Width = 100;
            ucC1FlexGridOperation.fg.Cols["手术名称"].Width = 300;
            ucC1FlexGridOperation.fg.Cols["ICD9编码"].Width = 100;
            ucC1FlexGridOperation.fg.Cols["拼音码"].Width = 100;
            ucC1FlexGridOperation.fg.Cols["五笔码"].Width = 100;
            ucC1FlexGridOperation.fg.Cols["是否有效"].Width = 100;

            ucC1FlexGridOperation.fg.Rows[0].StyleNew.TextAlign = TextAlignEnum.CenterCenter;
            for (int i = 0; i < ucC1FlexGridOperation.fg.Cols.Count; i++)
            {
                ucC1FlexGridOperation.fg.Cols[i].TextAlign = TextAlignEnum.CenterCenter;
            }

        }

        private void SetViSible(object sender, EventArgs e)
        {
            this.ucC1FlexGridOperation.fg.Cols["是否审批2"].Visible = false;
            this.ucC1FlexGridOperation.fg.Cols["是否审批2"].AllowEditing = false;

        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ucLeverContact1_TabIndexChanged(object sender, EventArgs e)
        {
        }
        
        private void btnConfirmTeShu_Click(object sender, EventArgs e)
        {
            string delectSql = "delete from T_SPECIALOPER_LEVEL_RELA";
            App.ExecuteSQL(delectSql);
            //SqlsTeShu.Add(delectSql);
            for (int i = 0; i < list.Count; i++)
            {
                //把每项特殊手术选中的关联的医生添加到数据库
                list[i].getInsertTeShuSql();
            }
            list.Clear();
            App.Msg("操作已经成功！");
        }
        private void btnconfirm_Click(object sender, EventArgs e)
        {
            string sql = "delete from T_OPER_LEVEL_RELA";
            Sqls.Add(sql);//包删除语句添加进去集合
            ffding.getInsertSql(ref Sqls);//添加一条等级是丁的sql语句
            ffbing.getInsertSql(ref Sqls);//添加一条等级是丙的sql语句
            ffyi.getInsertSql(ref Sqls);//添加一条等级是乙的sql语句
            ffjia.getInsertSql(ref Sqls);//添加一条等级是甲的sql语句

            string[] strsqls = new string[Sqls.Count];//定义个string数组 个数等于sqls个数
            for (int i = 0; i < Sqls.Count; i++)
            {
                strsqls[i] = Sqls[i].ToString();//把sqls的每一项赋值给strsqls
            }
            if (App.ExecuteBatch(strsqls) > 0)//一起执行
            {
                App.Msg("操作已经成功！");
            }
        }
        /// <summary>
        /// 等级设定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSheDing_Click(object sender, EventArgs e)
        {
            this.btnSheDing.Enabled = false;//按钮灰掉
            this.Cursor = Cursors.WaitCursor;//让鼠标变成沙漏状
            string updateSQL = "";
            List<string> list = new List<string>();//保存要修改的手术等级(全部)
            for (int i = 1; i < ucC1FlexGridOperation.fg.Rows.Count; i++)
            {
                string dengji = ucC1FlexGridOperation.fg[i, 1].ToString();//获取每行中第一列的等级
                string appr = "";
                string code = ucC1FlexGridOperation.fg[i, 6].ToString();
                if (ucC1FlexGridOperation.fg[i, 2].ToString().ToLower() == "true")
                {
                    appr = "Y";
                }
                else
                {
                    appr = "N";
                }
                updateSQL = "update oper_def_icd9 set oper_level='" + dengji + "',is_appr='" + appr + "' where code='" + code + "'";
                list.Add(updateSQL);
            }
            //ToArray是复制到一个新数组里面
            if (App.ExecuteBatch(list.ToArray()) > 0)
            {
                App.Msg("批量等级设定成功");
                this.btnSheDing.Enabled = true;//变回来原来形状
                this.Cursor = Cursors.Default;
                list.Clear();//清空
                SetUCflgview();//刷新
            }
        }
        //特殊手术设置
        private void SetucC1FlexGrid3()
        {
            string querySQl = "select ID as ID,RECORD_TIME as 添加日期,TYPE_VALUE as 项目类型,RECORDBY_NAME as 上报人 from T_SPECIALOPER_TYPE";
            ucC1FlexGrid3.DataBd(querySQl, "ID", "", "");
            ucC1FlexGrid3.fg.Cols["ID"].Width = 100;
            ucC1FlexGrid3.fg.Cols["添加日期"].Width = 270;
            ucC1FlexGrid3.fg.Cols["项目类型"].Width = 500;
            ucC1FlexGrid3.fg.Cols["上报人"].Width = 150;
            ucC1FlexGrid3.fg.AllowEditing = false;
            ucC1FlexGrid3.fg.Rows[0].StyleNew.TextAlign = TextAlignEnum.CenterCenter;

            for (int j = 0; j < ucC1FlexGrid3.fg.Cols.Count; j++)
            {
                ucC1FlexGrid3.fg.Cols[j].TextAlign = TextAlignEnum.CenterCenter;
            }
            //int i = ucC1FlexGrid3.fg.Rows.Count;
        }

        private void ucC1FlexGrid3_Load(object sender, EventArgs e)
        {
            //SetucC1FlexGrid3();
            this.txtUserName.Text = App.UserAccount.UserInfo.User_name;
            this.txtProjectType.Enabled = false;
            this.txtUserName.Enabled = false;
            this.btnQueDing.Enabled = false;
            this.btnCancel.Enabled = false;
            ucC1FlexGrid3.fg.Click += new EventHandler(ucC1FlexGrid3_Click);
            ucC1FlexGrid3.fg.Cols["ID"].Width = 100;
            ucC1FlexGrid3.fg.Cols["添加日期"].Width = 270;
            ucC1FlexGrid3.fg.Cols["项目类型"].Width = 500;
            ucC1FlexGrid3.fg.Cols["上报人"].Width = 150;
            ucC1FlexGrid3.fg.AllowEditing = false;
            ucC1FlexGrid3.fg.Rows[0].StyleNew.TextAlign = TextAlignEnum.CenterCenter;

            for (int j = 0; j < ucC1FlexGrid3.fg.Cols.Count; j++)
            {
                ucC1FlexGrid3.fg.Cols[j].TextAlign = TextAlignEnum.CenterCenter;
            }
        }
        bool isAddUpdate = false;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAddUpdate = true;
            this.txtProjectType.Enabled = true;
            this.btnAdd.Enabled = false;
            this.btnUpdate.Enabled = false;
            this.btnDelete.Enabled = false;
            this.btnQueDing.Enabled = true;
            this.btnCancel.Enabled = true;
            this.dateTimePicker1.Text = App.GetSystemTime().ToString("yyyy-MM-dd HH:mm");
            this.txtProjectType.Text = "";

        }

        private void btnQueDing_Click(object sender, EventArgs e)
        {
            string record_time = this.dateTimePicker1.Text.Trim();
            string tYPE_VALUE = this.txtProjectType.Text.Trim();
            string rECORDBY_NAME = this.txtUserName.Text.Trim();
            string rECORD_BY_ID = App.UserAccount.UserInfo.User_id;
            string iS_STATE = "";
            if (isAddUpdate == true)
            {
                if (this.txtProjectType.Text == "")
                {
                    App.Msg("项目类型不能为空");
                    this.txtProjectType.Focus();
                    return;
                }
                //'" + tYPE_VALUE + "','" + record_time + "','" + rECORD_BY_ID + "','" + rECORDBY_NAME + "','" + iS_STATE + "'
                string insertSQL = string.Format("insert into T_SPECIALOPER_TYPE(type_value,record_time,record_by_id,recordby_name,is_state)" +
                  " values('{0}',to_TIMESTAMP('{1}','yyyy-MM-dd hh24:mi:ss'),'{2}','{3}','{4}')", tYPE_VALUE, record_time, rECORD_BY_ID, rECORDBY_NAME, iS_STATE);
                if (App.ExecuteSQL(insertSQL) > 0)
                {
                    App.Msg("添加成功");
                    this.btnAdd.Enabled = true;
                    this.btnDelete.Enabled = true;
                    this.btnUpdate.Enabled = true;
                    this.btnQueDing.Enabled = false;
                    this.btnCancel.Enabled = false;
                    this.txtProjectType.Enabled = false;
                    this.dateTimePicker1.Enabled = false;
                    SetucC1FlexGrid3();
                    SettabPages4();
                }
                else
                {
                    App.Msg("添加失败了");
                    this.btnAdd.Enabled = true;
                    this.btnDelete.Enabled = true;
                    this.btnUpdate.Enabled = true;
                    this.btnQueDing.Enabled = false;
                    this.btnCancel.Enabled = false;
                }
            }
            else
            {
                if (rowsSel > 0)
                {
                    if (this.txtProjectType.Text == "")
                    {
                        App.Msg("项目类型不能为空");
                        this.txtProjectType.Focus();
                        return;
                    }
                    string updateSQL = "update T_SPECIALOPER_TYPE set record_time=to_TIMESTAMP('" + record_time + "','yyyy-MM-dd hh24:mi:ss'),type_value='" + tYPE_VALUE + "' where ID='" + ucC1FlexGrid3.fg[ucC1FlexGrid3.fg.RowSel, "ID"].ToString() + "'";
                    if (App.ExecuteSQL(updateSQL) > 0)
                    {
                        App.Msg("修改成功");
                        this.btnCancel.Enabled = false;
                        this.btnQueDing.Enabled = false;
                        this.btnAdd.Enabled = true;
                        this.btnUpdate.Enabled = true;
                        this.btnDelete.Enabled = true;
                        this.txtProjectType.Enabled = false;
                        SetucC1FlexGrid3();
                        SettabPages4();

                    }
                    else
                    {
                        App.MsgErr("此次操作未成功");
                    }
                }
                else
                {
                    App.Msg("您还没有选中要修改的信息");
                }

            }
        }
        private void ucC1FlexGrid3_Click(object sender, EventArgs e)
        {
            if (ucC1FlexGrid3.fg.RowSel >= 0)
            {
                ucC1FlexGrid3.fg.AllowEditing = false;
                rowsSel = ucC1FlexGrid3.fg.RowSel;
                this.dateTimePicker1.Text = ucC1FlexGrid3.fg[ucC1FlexGrid3.fg.RowSel, "添加日期"].ToString();
                this.txtProjectType.Text = ucC1FlexGrid3.fg[ucC1FlexGrid3.fg.RowSel, "项目类型"].ToString();
                this.txtUserName.Text = ucC1FlexGrid3.fg[ucC1FlexGrid3.fg.RowSel, "上报人"].ToString();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (rowsSel > 0)
            {
                string deleteSQl = "delete T_SPECIALOPER_TYPE where ID='" + ucC1FlexGrid3.fg[ucC1FlexGrid3.fg.RowSel, "ID"].ToString() + "'";
                if (App.Ask("是否确定删除"))
                {
                    if (App.ExecuteSQL(deleteSQl) > 0)
                    {
                        App.Msg("删除成功");
                        this.btnCancel.Enabled = false;
                        this.btnQueDing.Enabled = false;
                        this.btnAdd.Enabled = true;
                        this.btnUpdate.Enabled = true;
                        this.btnDelete.Enabled = true;
                        this.txtProjectType.Enabled = false;
                        SetucC1FlexGrid3();
                        SettabPages4();
                    }
                }
            }
            else
            {
                App.Msg("您还没有选中要删除的信息");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (rowsSel > 0)
            {
                this.txtProjectType.Enabled = true;
                this.dateTimePicker1.Enabled = true;
                this.txtUserName.Enabled = false;
                this.btnAdd.Enabled = false;
                this.btnDelete.Enabled = false;
                this.btnUpdate.Enabled = false;
                this.btnQueDing.Enabled = true;
                this.btnCancel.Enabled = true;
            }
            else
            {
                App.Msg("您还没有选中要修改的信息");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.txtUserName.Enabled = false;
            this.txtProjectType.Enabled = false;
            this.btnAdd.Enabled = true;
            this.btnDelete.Enabled = true;
            this.btnUpdate.Enabled = true;
            this.btnQueDing.Enabled = false;
            this.btnCancel.Enabled = false;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string qureySql = "select Oper_level as 手术等级, is_appr as 是否审批2,oper_code as 手术代码," +
                            " name as 手术名称,code as ICD9编码,shortcut1 as " +
                            " 拼音码, shortcut2 as 五笔码,is_enable as 是否有效2 from oper_def_icd9 where 1=1 ";
            string shoushudaima = this.txtOPSCode.Text;
            string shoushuName = this.txtOPSName.Text;
            string icd9Code = this.txtICD9Code.Text;
            string isavailability = "";
            if (this.cboxIsavailability.Text != "")
            {
                if (this.cboxIsavailability.Text == "是")
                {
                    isavailability = "Y";
                }
                else if (this.cboxIsavailability.Text == "否")
                {
                    isavailability = "N";
                }
                else
                {
                    isavailability = " ";
                }
            }

            if (shoushudaima != "")
            {
                qureySql += " and oper_code like '" + shoushudaima + "%'";
            }
            if (shoushuName != "")
            {
                qureySql += " and name like '" + shoushuName + "%'";
            }
            if (icd9Code != "")
            {
                qureySql += " and code like '" + icd9Code + "%'";
            }
            if (isavailability != "")
            {
                qureySql += " and is_enable = '" + isavailability + "'";
            }

            ds = App.GetDataSet(qureySql);
            dt = ds.Tables[0];

            DataColumn dc = new DataColumn("是否审批", typeof(bool));
            dc.DefaultValue = false;
            dt.Columns.Add(dc);

            DataColumn dc1 = new DataColumn("是否有效", typeof(string));
            //dc.DefaultValue = false;
            dt.Columns.Add(dc1);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["是否审批"] = dt.Rows[i]["是否审批2"].ToString() == "Y" ? true : false;
                dt.Rows[i]["是否有效"] = dt.Rows[i]["是否有效2"].ToString() == "Y" ? "是" : "否";
            }
            this.ucC1FlexGridOperation.fg.DataSource = dt;

            this.ucC1FlexGridOperation.fg.Cols["是否审批"].Move(2);
            CellStyle cs = this.ucC1FlexGridOperation.fg.Styles.Add("手术等级");
            cs.DataType = typeof(string);
            this.ucC1FlexGridOperation.fg.Cols["手术等级"].Style.ComboList = " |甲|乙|丙|丁";

            this.ucC1FlexGridOperation.fg.Cols["是否审批2"].Visible = false;
            this.ucC1FlexGridOperation.fg.Cols["是否审批2"].AllowEditing = false;

            this.ucC1FlexGridOperation.fg.Cols["是否有效2"].Visible = false;
            this.ucC1FlexGridOperation.fg.Cols["是否有效2"].AllowEditing = false;

            ucC1FlexGridOperation.fg.Cols["手术等级"].Width = 100;
            ucC1FlexGridOperation.fg.Cols["是否审批"].Width = 100;
            ucC1FlexGridOperation.fg.Cols["手术代码"].Width = 100;
            ucC1FlexGridOperation.fg.Cols["手术名称"].Width = 300;
            ucC1FlexGridOperation.fg.Cols["ICD9编码"].Width = 100;
            ucC1FlexGridOperation.fg.Cols["拼音码"].Width = 100;
            ucC1FlexGridOperation.fg.Cols["五笔码"].Width = 100;
            ucC1FlexGridOperation.fg.Cols["是否有效"].Width = 100;

            ucC1FlexGridOperation.fg.Rows[0].StyleNew.TextAlign = TextAlignEnum.CenterCenter;
            for (int i = 0; i < ucC1FlexGridOperation.fg.Cols.Count; i++)
            {
                ucC1FlexGridOperation.fg.Cols[i].TextAlign = TextAlignEnum.CenterCenter;
            }
        }

        private void ucfrmOperationVindicate_Load(object sender, EventArgs e)
        {
            try
            {
                ucC1FlexGridOperation.fg.Click += new EventHandler(ucC1FlexGridOperation_Click);
                ucC1FlexGridOperation.fg.DoubleClick += new EventHandler(ucC1FlexGridOperation_DoubleClick);

                SetUCflgview();

                ffding.SetChecked();
                ffbing.SetChecked();
                ffyi.SetChecked();
                ffjia.SetChecked();
                ff.SetTeShuChecked(ff.Tag.ToString());
            }
            catch
            {
            }
        }

        private void ucC1FlexGridOperation_Click(object sender, EventArgs e)
        {
            if (ucC1FlexGridOperation.fg.RowSel >= 0)
            {
                if (ucC1FlexGridOperation.fg.ColSel == 1 || ucC1FlexGridOperation.fg.ColSel == 2)
                {
                    ucC1FlexGridOperation.fg.AllowEditing = true;
                }
                else
                {
                    ucC1FlexGridOperation.fg.AllowEditing = false;
                }
            }
        }

        private void ucC1FlexGridOperation_DoubleClick(object sender, EventArgs e)
        {
            if (ucC1FlexGridOperation.fg.RowSel >= 0)
            {
                if (ucC1FlexGridOperation.fg.ColSel == 1 || ucC1FlexGridOperation.fg.ColSel == 2)
                {
                    ucC1FlexGridOperation.fg.AllowEditing = true;
                }
                else
                {
                    ucC1FlexGridOperation.fg.AllowEditing = false;
                }
            }
        }

        private void ucC1FlexGrid3_DoubleClick(object sender, EventArgs e)
        {
            if (ucC1FlexGrid3.fg.RowSel >= 0)
            {
                ucC1FlexGrid3.fg.AllowEditing = false;
            }
        }
    }
}
