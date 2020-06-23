using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using TextEditor;
using Base_Function.BASE_COMMON;
using System.Windows.Forms.VisualStyles;
using System.Xml;
using Bifrost.WebReference;

namespace Base_Function.BLL_MANAGEMENT.BLL_MEDICAL_RECORD_GRADE.Quality_Control_Score
{
    public partial class frmDocView : DevComponents.DotNetBar.Office2007Form
    {
        public delegate void RefEventHandler();
        public event RefEventHandler Refresh;   //质控完成、关闭窗体、重新查询可质控患者

        InPatientInfo inpat;
        string type = "";
        string infoId = "";//医生整改通知反馈信息ID      

        public frmDocView()
        {
            InitializeComponent();
        }

        public frmDocView(string strPatientId, string strType, string strInfoId)
        {
            InitializeComponent();
            inpat = DataInit.GetInpatientInfoByPid(strPatientId);
            type = strType;
            infoId = strInfoId;
        }

        private void ucDocView_Load(object sender, EventArgs e)
        {            
            if (type == "D")
            {
                btnFinish.Text = "质控反馈";                
            }
            else if (type == "H")
            {
                btnFinish.Text = "反馈确认";
                btnNoticeAgain.Visible = true;
            }
            else {
                btnFinish.Text = "质控完成";
                btnNoticeAgain.Visible = true;
                btnFeedBacK.Visible = true;
            }
            dgvSubjectiveShow(); 
            dgvObjectiveShow();
        }
        /// <summary>
        /// 评分人接受反馈之后再次发送整改通知书
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNoticeAgain_Click(object sender, EventArgs e)
        {
            //客观
            DataTable dtObjective = new DataTable();
            DataColumn dcA_1 = new DataColumn("质控项目");
            dtObjective.Columns.Add(dcA_1);
            DataColumn dcA_2 = new DataColumn("状态");
            dtObjective.Columns.Add(dcA_2);
            DataColumn dcA_3 = new DataColumn("分值");
            dtObjective.Columns.Add(dcA_3);
            DataColumn dcA_4 = new DataColumn("项目编码");
            dtObjective.Columns.Add(dcA_4);
            //主观
            DataTable dtSubjective = new DataTable();
            DataColumn dcK_1 = new DataColumn("评分项目");
            dtSubjective.Columns.Add(dcK_1);
            DataColumn dcK_2 = new DataColumn("分值");
            dtSubjective.Columns.Add(dcK_2);
            DataColumn dcK_3 = new DataColumn("扣分标准");
            dtSubjective.Columns.Add(dcK_3);
            bool flag = false;
            //自动质控的数据
            for (int i = 0; i < dgvObjective.Rows.Count; i++)
            {
                DataRow dr = dtObjective.NewRow();
                dr["质控项目"] = dgvObjective.Rows[i].Cells["质控项目"].Value.ToString();
                dr["状态"] = dgvObjective.Rows[i].Cells["状态"].Value.ToString();
                dr["分值"] = dgvObjective.Rows[i].Cells["分值"].Value.ToString();
                dr["项目编码"] = dgvObjective.Rows[i].Cells["项目编码"].Value.ToString();
                dtObjective.Rows.Add(dr);
            }
            //手动质控未确认数据
            for (int i = 0; i < dgvSubjective.Rows.Count; i++)
            {
                if (dgvSubjective.Rows[i].Cells["colBtn_1"].Value.ToString() != "已确认")
                {
                    DataRow dr = dtSubjective.NewRow();
                    dr["评分项目"] = dgvSubjective.Rows[i].Cells["评分项目"].Value.ToString();
                    dr["分值"] = dgvSubjective.Rows[i].Cells["分值"].Value.ToString();
                    dr["扣分标准"] = dgvSubjective.Rows[i].Cells["扣分标准"].Value.ToString();
                    dtSubjective.Rows.Add(dr);
                    flag = true;
                }
            }
            //自动有数据，手动有未确认数据
            if (flag || dgvObjective.Rows.Count > 0)
            {
                frmSendNotice frm = new frmSendNotice(dtSubjective, dtObjective, inpat, type, infoId);
                frm.BtnEnable += new frmSendNotice.RefEventHandler(BtnEnable);
                frm.ShowDialog();
                //if(frm.DialogResult=)
            }
            else
            {
                App.Msg("没有质控信息，无法发送整改通知书！");
            }
        
        }

        /// <summary>
        /// 除院级权限外发送整改通知之后，质控完成按钮不可用
        /// </summary>
        private void BtnEnable()
        {
            if(type!="H")
            btnFinish.Enabled = false;
        }

        /// <summary>
        /// 客观质控DataGridView数据绑定TODO
        /// </summary>
        private void dgvObjectiveShow()
        {           
            DataSet ds = App.GetDataSet("select CASE WGZT WHEN '1' THEN '时限内未完成'" +
                                " WHEN '3' THEN '超时未完成'  WHEN '4' THEN '超时完成' END 状态,zljlxh 项目编码,WGXX 质控项目,KFQK 分值 " +
                                "from qc_zlkzjlk where SYXH='" + inpat.Id + "' and WGZT in ('1','3','4')");

            DataTable dt = ds.Tables[0];
            //DataColumn dc_1 = new DataColumn("dcFlag_1", typeof(bool));
            ////dc_1.ColumnName = "扣分标识（   全选）";
            //dc_1.DefaultValue = false;
            //dt.Columns.Add(dc_1);


            //DataColumn dc_2 = new DataColumn("dcFlag_2", typeof(bool));
            //dc_2.DefaultValue = false;
            //dt.Columns.Add(dc_2);

            /*********自动质控假数据  TODO*********************/
            //DataRow dr_1 = dt.NewRow();
            //dr_1["状态"] = "未完成";
            //dr_1["项目编码"] = "1";
            //dr_1["质控项目"] = "24小时入出院记录未在24小时内完成";
            //dr_1["缺陷类型"] = "时效";
            //dr_1["扣分值"] = "1";
            //dt.Rows.Add(dr_1);
            //DataRow dr_2 = dt.NewRow();
            //dr_2["状态"] = "已完成";
            //dr_2["项目编码"] = "2";
            //dr_2["质控项目"] = "无主治医师查房记录";
            //dr_2["缺陷类型"] = "缺项";
            //dr_2["扣分值"] = "2";
            //dt.Rows.Add(dr_2);
            //DataRow dr_3 = dt.NewRow();
            //dr_2["状态"] = "已完成";
            //dr_3["项目编码"] = "3";
            //dr_3["质控项目"] = "*手术记录未在术后24小时内完成";
            //dr_3["缺陷类型"] = "时效";
            //dr_3["扣分值"] = "1";
            //dt.Rows.Add(dr_3);
            //DataRow dr_4 = dt.NewRow();
            //dr_2["状态"] = "未完成";
            //dr_4["项目编码"] = "4";
            //dr_4["质控项目"] = "无专科检查";
            //dr_4["缺陷类型"] = "缺项";
            //dr_4["扣分值"] = "0.5";
            //dt.Rows.Add(dr_4);

            string strMarkId = App.ReadSqlVal("select mark_id from T_QUALITY_RELATION where key_id='" + infoId + "' and flag='1'", 0, "mark_id");
            if (!string.IsNullOrEmpty(strMarkId))
            {
                for (int i = dt.Rows.Count - 1; i > -1; i--)
                {
                    if (!strMarkId.Contains("," + dt.Rows[i]["项目编码"].ToString() + ","))
                    {
                        dt.Rows.RemoveAt(i);
                    }
                }
            }
            else
            {
                dt.Rows.Clear();
            }

            dgvObjective.DataSource = dt.DefaultView;
            dgvObjective.Columns["项目编码"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvObjective.Columns["项目编码"].Visible = false;
            dgvObjective.Columns["质控项目"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvObjective.Columns["质控项目"].ReadOnly = true;       
            dgvObjective.Columns["分值"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvObjective.Columns["分值"].ReadOnly = true;
            dgvObjective.Columns["状态"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvObjective.Columns["状态"].ReadOnly = true;
            //dgvObjective.Columns["dcFlag_1"].HeaderText = "扣分标识（   全选）";
            //dgvObjective.Columns["dcFlag_2"].HeaderText = "通知发送（   全选）";
            //dgvObjective.Columns["dcFlag_1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            //dgvObjective.Columns["dcFlag_2"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            //加载已勾选扣分项
            
        }

        /// <summary>
        /// 主观质控DataGridView数据绑定
        /// </summary>
        private void dgvSubjectiveShow()
        {
            try
            {
                string strSql = @"select t.id,
                                t.item 评分项目,
                                t.item_score 分值,
                                t.item_content 扣分标准,
                                a.textname 文书类别,
                                a.doc_name 文书名称,
                                a.textkind_id TEXTKIND_ID,
                                t.ITEM_PATIENTID 病人id,
                                isxg,
                                t.medical_mark_id,
                                docId,
                                t.item_type,
                                CASE
                                WHEN STATE IS NULL THEN
                                '未修改'
                                WHEN STATE = 0 THEN
                                '未修改'
                                WHEN STATE = 1 THEN
                                '已修改'
                                else
                                '已确认'
                                end 状态
                                from t_deduct_score t inner join t_patients_doc a on t.docid=a.tid
                                where t.ITEM_PATIENTID='" + inpat.Id + "' and t.item_type='Y' order by t.state";


                DataSet ds = App.GetDataSet(strSql);
                if (ds != null)
                {
                    dgvSubjective.DataSource = ds.Tables[0].DefaultView;
                    dgvSubjective.Columns["id"].Visible = false;
                    dgvSubjective.Columns["病人id"].Visible = false;
                    dgvSubjective.Columns["评分项目"].Width = 100;
                    dgvSubjective.Columns["分值"].Width = 50;
                    dgvSubjective.Columns["扣分标准"].Width = 250;
                    dgvSubjective.Columns["medical_mark_id"].Visible = false;
                    dgvSubjective.Columns["item_type"].Visible = false;
                    dgvSubjective.Columns["isxg"].Visible = false;
                    dgvSubjective.Columns["docId"].Visible = false;
                    dgvSubjective.Columns["状态"].Visible = false;
                    dgvSubjective.Columns["文书名称"].Visible = false;
                    dgvSubjective.Columns["TEXTKIND_ID"].Visible = false;
                    
                    
                    DataGridViewDisableButtonColumn btn_1 = new DataGridViewDisableButtonColumn();
                    btn_1.Name = "colBtn_1";
                    btn_1.HeaderText = "状态";
                    btn_1.DataPropertyName = "状态";
                    dgvSubjective.Columns.Add(btn_1);
                    dgvSubjective.Columns["colBtn_1"].DisplayIndex = 0;

                    if (type == "D")//医生反馈界面，质控状态为未修改显示确认按钮
                    {
                        for (int i = 0; i < dgvSubjective.Rows.Count; i++)
                        {
                            if (dgvSubjective.Rows[i].Cells["colBtn_1"].Value.ToString() != "未修改")
                            {
                                DataGridViewDisableButtonCell buttonCell = (DataGridViewDisableButtonCell)dgvSubjective.Rows[i].Cells["colBtn_1"];
                                buttonCell.Enabled = false;
                            }
                        }
                    }
                    else //质控人接收反馈信息，质控状态为已修改显示确认按钮
                    {
                        for (int i = 0; i < dgvSubjective.Rows.Count; i++)
                        {
                            if (dgvSubjective.Rows[i].Cells["colBtn_1"].Value.ToString() != "已修改")
                            {
                                DataGridViewDisableButtonCell buttonCell = (DataGridViewDisableButtonCell)dgvSubjective.Rows[i].Cells["colBtn_1"];
                                buttonCell.Enabled = false;
                            }
                        }
                    }
                    for (int i = 0; i < dgvSubjective.Columns.Count; i++) { dgvSubjective.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable; }
                }

            }
            catch
            {

            }          
        }

        #region 表格按钮
        public class DataGridViewDisableButtonColumn : DataGridViewButtonColumn
        {
            public DataGridViewDisableButtonColumn()
            {
                this.CellTemplate = new DataGridViewDisableButtonCell();
            }
        }

        public class DataGridViewDisableButtonCell : DataGridViewButtonCell
        {
            private bool enabledValue;
            public bool Enabled
            {
                get
                {
                    return enabledValue;
                }
                set
                {
                    enabledValue = value;
                }
            }

            // Override the Clone method so that the Enabled property is copied.  
            public override object Clone()
            {
                DataGridViewDisableButtonCell cell =
                    (DataGridViewDisableButtonCell)base.Clone();
                cell.Enabled = this.Enabled;
                return cell;
            }

            // By default, enable the button cell.  
            public DataGridViewDisableButtonCell()
            {
                //this.Enabled = this.enabledValue;
                this.enabledValue = true;
            }

            protected override void Paint(Graphics graphics,
                Rectangle clipBounds, Rectangle cellBounds, int rowIndex,
                DataGridViewElementStates elementState, object value,
                object formattedValue, string errorText,
                DataGridViewCellStyle cellStyle,
                DataGridViewAdvancedBorderStyle advancedBorderStyle,
                DataGridViewPaintParts paintParts)
            {
                // The button cell is disabled, so paint the border,    
                // background, and disabled button for the cell.  
                if (!this.enabledValue)
                {
                    // Draw the cell background, if specified.  
                    if ((paintParts & DataGridViewPaintParts.Background) ==
                        DataGridViewPaintParts.Background)
                    {
                        SolidBrush cellBackground =
                            new SolidBrush(cellStyle.BackColor);
                        graphics.FillRectangle(cellBackground, cellBounds);
                        cellBackground.Dispose();
                    }

                    // Draw the cell borders, if specified.  
                    if ((paintParts & DataGridViewPaintParts.Border) ==
                        DataGridViewPaintParts.Border)
                    {
                        PaintBorder(graphics, clipBounds, cellBounds, cellStyle,
                            advancedBorderStyle);
                    }

                    // Calculate the area in which to draw the button.  
                    Rectangle buttonArea = cellBounds;
                    Rectangle buttonAdjustment =
                        this.BorderWidths(advancedBorderStyle);
                    buttonArea.X += buttonAdjustment.X;
                    buttonArea.Y += buttonAdjustment.Y;
                    buttonArea.Height -= buttonAdjustment.Height;
                    buttonArea.Width -= buttonAdjustment.Width;

                    // Draw the disabled button.                  
                    ButtonRenderer.DrawButton(graphics, buttonArea,
                        PushButtonState.Disabled);

                    // Draw the disabled button text.   
                    if (this.FormattedValue is String)
                    {
                        TextRenderer.DrawText(graphics,
                            (string)this.FormattedValue,
                            this.DataGridView.Font,
                            buttonArea, SystemColors.GrayText);
                    }
                }
                else
                {
                    // The button cell is enabled, so let the base class   
                    // handle the painting.  
                    base.Paint(graphics, clipBounds, cellBounds, rowIndex,
                        elementState, value, formattedValue, errorText,
                        cellStyle, advancedBorderStyle, paintParts);
                }
            }
        }
        #endregion

        /// <summary>
        /// 表格中按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvSubjective_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                try
                {
                    if (dgvSubjective.Columns[e.ColumnIndex].Name == "colBtn_1")
                    {
                        if (this.dgvSubjective.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "未修改" && type == "D")  //如果规则状态为未修改，而且为医生权限 点击变成已修改
                        {
                            if (App.ExecuteSQL("update t_deduct_score set state=1 where id='" + dgvSubjective.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'") > 0)
                            {
                                DataGridViewDisableButtonCell buttonCell = (DataGridViewDisableButtonCell)dgvSubjective.Rows[e.RowIndex].Cells[e.ColumnIndex];
                                buttonCell.Enabled = false;
                                dgvSubjective.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "已修改";
                            }
                        }
                        else if (this.dgvSubjective.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "已修改" && type != "D")//如果规则状态为已修改，而且为评分权限 点击变成已确认
                        {
                            if (App.ExecuteSQL("update t_deduct_score set state=2 where id='" + dgvSubjective.Rows[e.RowIndex].Cells["id"].Value.ToString() + "'") > 0)
                            {
                                DataGridViewDisableButtonCell buttonCell = (DataGridViewDisableButtonCell)dgvSubjective.Rows[e.RowIndex].Cells[e.ColumnIndex];
                                buttonCell.Enabled = false;
                                dgvSubjective.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "已确认";                                
                                //删除文书注释、保存文书
                                save_doc(dgvSubjective.Rows[e.RowIndex].Cells["docId"].Value.ToString(), dgvSubjective.Rows[e.RowIndex].Cells["id"].Value.ToString());
                            }

                        }
                    }
                }
                catch { }
            }
        }

        /// <summary>
        /// 删除文书注释，保存文书
        /// </summary>
        private void save_doc(string tid,string mark_id)
        {
            try
            {
                //如已打开 刷新编辑器内容
                for (int i = 0; i < tctlDoc.Tabs.Count; i++)
                {
                    Patient_Doc doc = tctlDoc.Tabs[i].Tag as Patient_Doc;
                    if (doc.Id.ToString() == tid)
                    {
                        frmText frm = tctlDoc.Tabs[i].AttachedControl.Controls[0] as frmText;
                        foreach (var ele in frm.MyDoc.Elements)
                        {
                            if (ele is ZYTextBapfMark)
                            {
                                ZYTextBapfMark mark = (ZYTextBapfMark)ele;
                                if (mark.Value == mark_id)
                                {                                    
                                    mark.Parent.ChildElements.Remove(mark);
                                }
                            }
                        }
                        frm.MyDoc.ContentChanged();
                    }
                }

                //取出clob
                string strSql_Doc = "select a.content from T_PATIENT_DOC_COLB a where a.tid='" + tid + "'";
                DataSet ds_Doc = App.GetDataSet(strSql_Doc);
                string content_source = "";
                XmlDocument tmpxml_source = new XmlDocument();
                tmpxml_source.PreserveWhitespace = true;
                XmlNodeList list;
                content_source = ds_Doc.Tables[0].Rows[0]["content"].ToString();
                if (content_source == "" || content_source == null)
                {
                    content_source = App.DownLoadFtpPatientDoc(tid + ".xml", inpat.Id.ToString());
                }
                tmpxml_source.LoadXml(content_source);
                //修改clob
                list = tmpxml_source.GetElementsByTagName("bapf");
                if (list != null)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        string aa = list[i].Attributes["value"].Value.ToString();
                        if (aa == mark_id)
                        {
                            list[i].ParentNode.RemoveChild(list[i]);
                        }
                    }
                }

                //提交clob
                //重新生成XML文件
                //App.UpLoadFtpPatientDoc(tmpxml_source.OuterXml, tid + ".xml", inpat.Id.ToString());

                // 更新数据库
                String sql_clob = string.Format("update T_PATIENT_DOC_COLB set CONTENT=:doc1 where TID = '{0}'", tid);
                OracleParameter[] xmlPars = new OracleParameter[1];
                xmlPars[0] = new OracleParameter();
                xmlPars[0].ParameterName = "doc1";
                xmlPars[0].Value = tmpxml_source.OuterXml;
                xmlPars[0].OracleType = OracleType.Clob;
                App.ExecuteSQL(sql_clob, xmlPars);
            }
            catch { }
        }


        private void btnFinish_Click(object sender, EventArgs e)
        {
            //质控反馈
            if (type == "D")
            {
                //将通知信息状态变为“已反馈”
                string strSql = "update T_AMENDMENTS_INFO set STATE_FLAG='2',FEEDBACK_TIME=sysdate where id='" + infoId + "'";
                if (App.ExecuteSQL(strSql) > 0)
                {
                    if (Refresh != null)
                    {
                        Refresh();
                    }
                    App.Msg("操作成功！");

                }
                else
                {
                    App.Msg("质控反馈操作失败，请重试！");
                }
            }
            else
            {
                string strAsk = "";
                //院级只是确认本次整改通知结束，其他权限确认本环节质控结束
                if (type == "H") {
                    //将通知信息状态变为“完成”
                    string strSql = "update T_AMENDMENTS_INFO set STATE_FLAG='4',CONFIRM_TIME=sysdate,CONFIRM_USER_ID='"+App.UserAccount.UserInfo.User_id.ToString()
                                    + "',CONFIRM_USER_NAME='"+App.UserAccount.UserInfo.User_name.ToString()+"' where id='" + infoId + "'";
                    if (App.ExecuteSQL(strSql) > 0)
                    {
                        App.Msg("操作成功！");
                        if (Refresh != null)
                        {
                            Refresh();
                        }
                        return;
                    }
                    else
                    {
                        App.Msg("确定反馈信息失败，请重试！");
                        return;
                    }
                }
                else if (type == "S") { strAsk = "科室"; }
                else if (type == "M") { strAsk = "终末"; }

                if (App.Ask(strAsk+"质控结束，该环节无法再对病历进行质控！"))
                {
                    List<string> sqls = new List<string>();

                    //将通知信息状态变为“完成”
                    sqls.Add( "update T_AMENDMENTS_INFO set STATE_FLAG='4',CONFIRM_TIME=sysdate,CONFIRM_USER_ID='" + App.UserAccount.UserInfo.User_id.ToString()
                                    + "',CONFIRM_USER_NAME='" + App.UserAccount.UserInfo.User_name.ToString() + "' where id='" + infoId + "'");

                    //质控记录表
                    string id = App.ReadSqlVal("select SEQ_T_MEDICAL_RECORD.nextval from dual", 0, "NEXTVAL");
                    sqls.Add("insert into t_medical_record(id,user_id,USER_NAME,patient_id，record_time,type,user_section)" +
                                    " values('" + id + "','" + App.UserAccount.UserInfo.User_id.ToString() + "','" + App.UserAccount.UserInfo.User_name.ToString() + "','" +
                                    inpat.Id.ToString() + "',sysdate,'" + type + "','" + App.UserAccount.CurrentSelectRole.Role_name + "')");

                    //该权限评分结束
                    sqls.Add("update T_DEDUCT_SUMMARY set OPERATOR_USER_ID='" + App.UserAccount.UserInfo.User_id.ToString()
                     + "',OPERATOR_USER_NAME='" + App.UserAccount.UserInfo.User_name.ToString() + "',state='" + type + "' where patient_id='" + inpat.Id.ToString() + "'");

                    if (App.ExecuteBatch(sqls.ToArray()) > 0)
                    {
                        if (Refresh != null)
                        {
                            Refresh();
                        }
                        App.Msg("操作成功！");
                    }
                    else
                    {
                        App.Msg("操作失败，请重试！");
                    }

                    
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        /// <summary>
        /// 确认本次整改通知记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFeedBacK_Click(object sender, EventArgs e)
        {
            string strSql = "update T_AMENDMENTS_INFO set STATE_FLAG='4',CONFIRM_TIME=sysdate,CONFIRM_USER_ID='" + App.UserAccount.UserInfo.User_id.ToString()
                                    + "',CONFIRM_USER_NAME='" + App.UserAccount.UserInfo.User_name.ToString() + "' where id='" + infoId + "'";
            if (App.ExecuteSQL(strSql) > 0)
            {
                if (Refresh != null)
                {
                    Refresh();
                }
                App.Msg("操作成功！");
                return;
            }
            else
            {
                App.Msg("确定反馈信息失败，请重试！");
                return;
            }
        }

        private void dgvSubjective_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.ColumnIndex > -1 && dgvSubjective.SelectedRows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(isExitRecord(Convert.ToInt32(dgvSubjective.SelectedRows[0].Cells["docId"].Value.ToString()), inpat.Id)))
                    {
                        CreateTabItem(Convert.ToInt32(dgvSubjective.SelectedRows[0].Cells["docId"].Value.ToString()), dgvSubjective.SelectedRows[0].Cells["id"].Value.ToString());
                    }
                }
            }
            catch { }
        }


        /// <summary>
        /// 判断该文书是否存在
        /// </summary>
        /// <param name="id"></param>
        /// /// <param name="patient_id">病人id</param>
        /// <returns></returns>
        private string isExitRecord(int id, int patient_id)
        {
            string sql = "select tid num from t_patients_doc where tid =" + id + " and patient_id='" + patient_id + "'";
            string tid = App.ReadSqlVal(sql, 0, "num");
            return tid;
        }

        /// <summary>
        /// 当前选中的节点，是否再tctlDoc.Tabs集合里面已经存在，存在true,否则false
        /// </summary>
        /// <param name="tid">文书的id</param>
        /// <returns></returns>
        private bool IsSameTabItem(string tid)
        {
            for (int i = 0; i < tctlDoc.Tabs.Count; i++)
            {
                Patient_Doc doc = tctlDoc.Tabs[i].Tag as Patient_Doc;
                if (doc != null)
                {
                    if (doc.Id.ToString() == tid)
                    {
                        tctlDoc.SelectedTab = tctlDoc.Tabs[i];
                        App.MsgWaring("已经存在相同的文书！");
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 得到单利文书的文书实例
        /// </summary>
        /// <param name="text"></param>
        private Patient_Doc GetDoc(string tid)
        {
            //string sql = "select a.tid,a.pid,a.textkind_id,a.belongtosys_id,a.sickkind_id,a.textname,a.doc_name,a.patient_Id,a.ishighersign,a.havehighersign,a.havedoctorsign,a.submitted,a.createId,a.highersignuserid,a.israplacehightdoctor,a.israplacehightdoctor2  from t_patients_doc a  where textkind_id=" + text.Id + " and patient_id='" + currentPatient.Id.ToString() + "'";

            string sql = "select a.tid,a.pid,a.textkind_id,a.belongtosys_id,a.sickkind_id,a.textname,a.doc_name,a.patient_Id,a.ishighersign,a.havehighersign,a.havedoctorsign,a.submitted,a.createId,a.highersignuserid,a.israplacehightdoctor,a.israplacehightdoctor2  from t_patients_doc a  where tid='"+tid+"'";
            DataSet ds = App.GetDataSet(sql);
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    Patient_Doc pDoc = new Patient_Doc();
                    pDoc.Id = Convert.ToInt32(row["tid"]);
                    pDoc.Patient_id = row["patient_Id"].ToString();
                    pDoc.Pid = row["pid"].ToString();

                    if (row["textkind_id"].ToString() != "")
                        pDoc.Textkind_id = Convert.ToInt32(row["textkind_id"]);

                    if (row["belongtosys_id"].ToString() != "")
                        pDoc.Belongtosys_id = Convert.ToInt32(row["belongtosys_id"]);
                    //pDoc.Patients_doc =row["patients_doc"].ToString();
                    if (row["sickkind_id"].ToString() != "")
                        pDoc.Sickkind_id = Convert.ToInt32(row["sickkind_id"]);

                    pDoc.Docname = row["doc_name"].ToString().TrimStart();
                    pDoc.Textname = row["textname"].ToString().TrimStart();

                    pDoc.Ishighersign = row["ishighersign"].ToString();
                    pDoc.Havehighersign = row["havehighersign"].ToString();
                    pDoc.Havedoctorsign = row["Havedoctorsign"].ToString();
                    pDoc.Submitted = row["submitted"].ToString();
                    pDoc.Createid = row["createId"].ToString();
                    pDoc.Highersignuserid = row["highersignuserid"].ToString();
                    pDoc.Isreplacehighdoctor = row["israplacehightdoctor"].ToString();
                    pDoc.Isreplacehighdoctor2 = row["israplacehightdoctor2"].ToString();
                    return pDoc;
                }
            }
            return null;
        }


        /// <summary>
        /// 创建新的tabItem
        /// </summary>
        /// <param name="tid">文书id</param>
        private void CreateTabItem(int tid,string strMark_id)
        {
            //验证重复打开,如已经打开则定位到该条注释
            if (IsSameTabItem(tid.ToString()) == true)
            {
                frmText text = tctlDoc.SelectedTab.AttachedControl.Controls[0] as frmText;
                if (text.MyDoc.Us.Tid.ToString() == tid.ToString())
                {
                    foreach (var ele in text.MyDoc.Elements)
                    {
                        if (ele is ZYTextBapfMark)
                        {
                            ZYTextBapfMark mark = (ZYTextBapfMark)ele;
                            if (mark.Value == strMark_id)
                            {
                                Point point = new Point(mark.RealLeft, mark.RealTop);
                                point = text.MyDoc.OwnerControl.ViewPointToClient(point.X, point.Y);
                                text.MyDoc.OwnerControl.AutoScrollPosition = new Point(text.MyDoc.OwnerControl.AutoScrollPosition.X/2+point.X/2, point.Y - text.MyDoc.OwnerControl.AutoScrollPosition.Y);
                                text.MyDoc.Content.MoveSelectStart(text.MyDoc.Elements.IndexOf(mark));
                                text.MyDoc.OwnerControl.Focus();
                            }
                        }
                    }
                }
                return;
            }
            /*
             * 创建新的tabItem 的实现思路：
             * 1.当前选中的文书类别，如果是单例文书，就查出其内容。
             * 2.当前选中的是病人文书，根据文书id，查出其内容
             */
            // 获得当前时间，精确到分钟
            // string time = string.Format("{0:g}", DateTime.Now);
            DevComponents.DotNetBar.TabControlPanel tabctpnDoc = new DevComponents.DotNetBar.TabControlPanel();
            tabctpnDoc.AutoScroll = true;
            DevComponents.DotNetBar.TabItem page = new DevComponents.DotNetBar.TabItem();
            //tctlDoc.TabItemClose += new TabStrip.UserActionEventHandler(tctlDoc_TabItemClose);
            //page.Click += new EventHandler(page_Click);

            //if (tid == 0)
            //{
            //    Class_Text text = advFinishDoc.SelectedNode.Tag as Class_Text;
            //    //新建文书，page页的Name用分号隔开，第一位：代表文书类型ID;第二位：文书类型;第三位：代表新建文书;第四位：是否单例文书
            //    page.Name = advFinishDoc.SelectedNode.Name + ";" + advFinishDoc.SelectedNode.Tag.GetType().ToString() + ";0;" + text.Issimpleinstance;
            //}
            //else //修改文书，page页的Name用分号隔开，第一位：文书ID；第二位：文书类型
            //{
            //    page.Name = tid + ";" + advFinishDoc.SelectedNode.Tag.GetType().ToString();
            //}

            page.Text = dgvSubjective.SelectedRows[0].Cells["文书名称"].Value.ToString() + " " + " (" + inpat.Sick_Bed_Name + " 床)";

            //已写文书
            Patient_Doc doc = GetDoc(dgvSubjective.SelectedRows[0].Cells["docId"].Value.ToString());
            page.Tag = doc;
            if (page.Tag != null)
            {
                //string log_Tid = advFinishDoc.SelectedNode.Name;
                //isCustom = false;

                //是否忽略空行
                //bool NeglectLine = IsNeglectLine(advFinishDoc.SelectedNode);                        
                string textTitle = dgvSubjective.SelectedRows[0].Cells["文书名称"].Value.ToString();
                page.Tooltip = dgvSubjective.SelectedRows[0].Cells["文书类别"].Value.ToString(); 

                //打开单例文书
                if (inpat.Sick_Bed_Name != "")
                {
                    //tid = Convert.ToInt32(temptid);
                    frmText text = new frmText(Convert.ToInt32(dgvSubjective.SelectedRows[0].Cells["textkind_id"].Value.ToString()), 0, 0, textTitle, tid, inpat, true, false, "", "");
                    text.MyDoc.IgnoreLine = true;

                    //隐藏编辑器右键
                    text.MyDoc.OwnerControl.ContextMenuStrip.Visible=false;
                    //隐藏工具栏
                    text.MyDoc.Menus.PnlMenus.Visible = false;

                    XmlDocument tmpxml = new System.Xml.XmlDocument();
                    tmpxml.PreserveWhitespace = true;
                    string sql = "select tid,Ishighersign,Havedoctorsign,Havehighersign,submitted,section_name from t_patients_doc where textkind_id='" + dgvSubjective.SelectedRows[0].Cells["textkind_id"].Value.ToString() + "' and patient_id=" + inpat.Id + "";
                    DataTable dt = App.GetDataSet(sql).Tables[0];

                    string content = "";
                    content = App.ReadSqlVal("select * from T_PATIENT_DOC_COLB where tid=" + dt.Rows[0]["tid"].ToString() + "", 0, "CONTENT");
                    if (content == null || content == "")
                    {
                        content = App.DownLoadFtpPatientDoc(dt.Rows[0]["tid"].ToString() + ".xml", inpat.Id.ToString());//App.ReadSqlVal(sql, 0, "patients_doc");
                    }
                    //content = App.DownLoadFtpPatientDoc(dt.Rows[0]["tid"].ToString() + ".xml", currentPatient.Id.ToString()); //dt.Rows[0]["patients_doc"].ToString();
                    string ishighersign = dt.Rows[0]["Ishighersign"].ToString();
                    string havedoctorsign = dt.Rows[0]["Havedoctorsign"].ToString();
                    string havehighersign = dt.Rows[0]["Havehighersign"].ToString();
                    text.MyDoc.Section_name = dt.Rows[0]["section_name"].ToString();
                    //修改文书，Ishighersign是否需要上级医师审签
                    text.MyDoc.TextSuperiorSignature = ishighersign;
                    text.MyDoc.HaveTubebedSign = havedoctorsign;  //经治医师是否审签
                    text.MyDoc.HaveSuperiorSignature = havehighersign;//是否已经有过上级医生签名
                    text.MyDoc.OnDrawPageHeader += DataInit.EMRDoc_OnDrawPageHeader;
                    text.MyDoc.Locked = true;

                    ////病案评分-------------------------------------------------------
                    //if (this.OnComeFrmText != null)
                    //{
                    //    //触发事件
                    //    OnComeFrmText(text);
                    //}
                    ////--------------------------------------------------------


                    tmpxml.LoadXml(content);

                    text.MyDoc.FromXML(tmpxml.DocumentElement);

                    //注释定位
                    foreach (var ele in text.MyDoc.Elements)
                    {
                        if (ele is ZYTextBapfMark)
                        {
                            ZYTextBapfMark mark = (ZYTextBapfMark)ele;
                            if (mark.Value == strMark_id)
                            {
                                Point point = new Point(mark.RealLeft, mark.RealTop);
                                point = text.MyDoc.OwnerControl.ViewPointToClient(point.X, point.Y);
                                text.MyDoc.OwnerControl.AutoScrollPosition = new Point(text.MyDoc.OwnerControl.AutoScrollPosition.X/2+point.X/2,point.Y - text.MyDoc.OwnerControl.AutoScrollPosition.Y);
                                text.MyDoc.Content.MoveSelectStart(text.MyDoc.Elements.IndexOf(mark));
                                //text.MyDoc.OwnerControl.Focus();
                            }
                        }
                    }
                   
                    text.MyDoc.ContentChanged();
                    tabctpnDoc.Controls.Add(text);
                    text.Dock = DockStyle.Fill;

              
                   
                }

                tabctpnDoc.TabItem = page;
                tabctpnDoc.Dock = DockStyle.Fill;
                page.AttachedControl = tabctpnDoc;
                this.tctlDoc.Controls.Add(tabctpnDoc);
                this.tctlDoc.Tabs.Add(page);
                this.tctlDoc.Refresh();
                this.tctlDoc.SelectedTab = page;
                //if (doc.Submitted == "Y")
                //{
                //    App.SetToolButtonByUser("tsbtnTempSave", false);
                //}
                //else
                //{
                //    App.SetToolButtonByUser("tsbtnTempSave", true);
                //}
            }
            else
            {
                App.Msg("打开文书异常！");
            }
            App.AddCurrentDocMsg(inpat.Id.ToString() + page.Text);
        }
    }
}
