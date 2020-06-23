using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Base_Function.BASE_COMMON;
using Bifrost;
using DevComponents.AdvTree;

namespace Base_Function.BLL_MANAGEMENT.BLL_MEDICAL_RECORD_GRADE
{
    public partial class ucMedicalMark_NEW : UserControl
    {
        private string strTextKind_id = "";

        public ucMedicalMark_NEW()
        {
            InitializeComponent();

            /*
             * 获取所有文书信息
             */
            GetAllBookTree(DataInit.temptrvbook);
            for (int i = 0; i < DataInit.temptrvbook.Nodes.Count; i++)
            {
                advAllDoc.Nodes.Add(DataInit.temptrvbook.Nodes[i].DeepCopy());
            }            
            advAllDoc.ExpandAll();


            /*
             * 数据过滤
             */

             //病程记录
            //DataSet ds_mark = App.GetDataSet("select id from T_MEDICAL_MARK t where t.type_id=7960661");
            //DataSet ds_Text = App.GetDataSet("select b.id from t_text b where b.parentid=172");

            //List<string> sqls = new List<string>();
            //string mark_id="";
            //string text_id="";

            //string ids = "";
            //for (int i = 0; i < ds_mark.Tables[0].Rows.Count; i++)
            //{
            //    mark_id=ds_mark.Tables[0].Rows[i][0].ToString();
            //    if (ids == "")
            //    {
            //        ids = mark_id;
            //    }
            //    else
            //    {
            //        ids =ids+","+ mark_id;
            //    }
            //    for (int j = 0; j < ds_Text.Tables[0].Rows.Count; j++)
            //    {
            //        text_id=ds_Text.Tables[0].Rows[j][0].ToString();
            //        sqls.Add("insert into T_MEDICAL_MARK_TEXT(mark_id,text_id)values(" + mark_id + "," + text_id + ")");
            //    }
            //}

            //App.ExecuteSQL("delete from T_MEDICAL_MARK_TEXT where mark_id in (" + ids + ")");

            //App.ExecuteBatch(sqls.ToArray());
             

        }
    
        /// <summary>
        /// 搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picSearch_Click(object sender, EventArgs e)
        {
            if (txtSearchAllText.Text.Trim() == "")
            {
                advAllDoc.Nodes.Clear();
                GetAllBookTree(advAllDoc);
                advAllDoc.ExpandAll();
            }
            else
            {
                //首字母联想查询
                advAllDoc.Nodes.Clear();
                SearchBookTree(advAllDoc, txtSearchAllText.Text);
                advAllDoc.ExpandAll();
            }
        }

        /// <summary>
        ///  显示所有文书类型
        /// </summary>
        /// <param name="trvBook"></param>
        private void GetAllBookTree(AdvTree trvBook)
        {

            trvBook.Nodes.Clear();
            //查出所有文书
            string SQl = "select * from T_TEXT where enable_flag='Y' order by shownum asc";
            //string SQl = "select * from T_TEXT where enable_flag='Y' and right_range in ('" + App.UserAccount.CurrentSelectRole.Role_type + "','A') order by shownum asc";
            //找出文书所有类别
            //string Sql_Category = "select * from t_data_code where type=31 and enable='Y'";
            DataSet ds = new DataSet();
            ds = App.GetDataSet(SQl);
            Class_Text[] Directionarys = GetSelectClassDs(ds);

            DataTable TableSort = DataInit.GetTextSortSet(DataInit.SortTypeId);//App.GetDataSet(sqlSort).Tables[0]; //获取该类型所有的排序信息
            DataRow[] toptempRows = TableSort.Select("parent_id=0"); //获取顶级节点
            DataRow[] topRows = DataInit.ReSort(toptempRows);               //顶级节点排序

            ////得到文书的类型
            //DataSet ds_category = App.GetDataSet(Sql_Category);
            //Class_Datacodecs[] datacodes = GetSelectDirectionary(ds_category);
            if (Directionarys != null)
            {
                if (topRows.Length > 0)
                {
                    //有排序
                    for (int k = 0; k < topRows.Length; k++)
                    {
                        for (int i = 0; i < Directionarys.Length; i++)
                        {
                            if (topRows[k]["text_id"].ToString() == Directionarys[i].Id.ToString())
                            {
                                Node tn = new Node();
                                tn.Tag = Directionarys[i];
                                tn.Text = Directionarys[i].Textname;
                                tn.Name = Directionarys[i].Id.ToString();
                                //插入顶级节点
                                if (Directionarys[i].Parentid == 0)
                                {
                                    tn.Image = global::Base_Function.Resource.住院记录;
                                    trvBook.Nodes.Add(tn);
                                    DataInit.SetTreeView(Directionarys, tn, TableSort);   //插入文书的子类文书。                                
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < Directionarys.Length; i++)
                    {
                        Node tn = new Node();
                        tn.Tag = Directionarys[i];
                        tn.Text = Directionarys[i].Textname;
                        tn.Name = Directionarys[i].Id.ToString();
                        //插入顶级节点
                        if (Directionarys[i].Parentid == 0)
                        {
                            tn.Image = global::Base_Function.Resource.住院记录;
                            trvBook.Nodes.Add(tn);
                            DataInit.SetTreeView(Directionarys, tn, TableSort);   //插入文书的子类文书。 
                        }
                    }
                }
            }
        }


        /// <summary>
        /// 实例Class_Text化查询结果
        /// </summary>
        /// <param Name="tempds"></param>
        /// <returns></returns>
        private static Class_Text[] GetSelectClassDs(DataSet tempds)
        {
            string bbtextlist = "6980234,6980235,6980236,6980237,6980238";//新生儿相关文书ID
            if (tempds != null)
            {
                if (tempds.Tables[0].Rows.Count > 0)
                {
                    Class_Text[] class_text = new Class_Text[tempds.Tables[0].Rows.Count];
                    for (int i = 0; i < tempds.Tables[0].Rows.Count; i++)
                    {
                        class_text[i] = new Class_Text();
                        class_text[i].Id = Convert.ToInt32(tempds.Tables[0].Rows[i]["ID"].ToString());
                        if (tempds.Tables[0].Rows[i]["PARENTID"].ToString() != "0")
                        {
                            if (bbtextlist.Contains(tempds.Tables[0].Rows[i]["PARENTID"].ToString()))
                            {
                                continue;
                            }
                            class_text[i].Parentid = Convert.ToInt32(tempds.Tables[0].Rows[i]["PARENTID"].ToString());
                        }
                        class_text[i].Sid = tempds.Tables[0].Rows[i]["sid"].ToString();
                        class_text[i].Textcode = tempds.Tables[0].Rows[i]["TEXTCODE"].ToString(); ;
                        class_text[i].Textname = tempds.Tables[0].Rows[i]["TEXTNAME"].ToString();
                        class_text[i].Isenable = tempds.Tables[0].Rows[i]["ISENABLE"].ToString();
                        class_text[i].Txxttype = tempds.Tables[0].Rows[i]["ISBELONGTOTYPE"].ToString();
                        class_text[i].Issimpleinstance = tempds.Tables[0].Rows[i]["issimpleinstance"].ToString();
                        class_text[i].Ishighersign = tempds.Tables[0].Rows[i]["ishighersign"].ToString();
                        class_text[i].Right_range = tempds.Tables[0].Rows[i]["right_range"].ToString();
                        class_text[i].Ishavetime = tempds.Tables[0].Rows[i]["ishavetime"].ToString();
                        class_text[i].Formname = tempds.Tables[0].Rows[i]["formname"].ToString();
                        class_text[i].Other_textname = tempds.Tables[0].Rows[i]["OTHER_TEXTNAME"].ToString();
                        class_text[i].Isneedsign = tempds.Tables[0].Rows[i]["ISNEEDSIGN"].ToString();
                        class_text[i].IsProblemName = tempds.Tables[0].Rows[i]["ISPROBLEM_NAME"].ToString();
                        class_text[i].IsProblemTime = tempds.Tables[0].Rows[i]["ISPROBLEM_TIME"].ToString();

                    }
                    return class_text;
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
        /// 刷新文书树
        /// 不需要显示层级结构
        /// </summary>
        /// <param name="trvBook">树控件对象</param>
        /// <param name="key">查询关键字</param>
        private void SearchBookTree(AdvTree trvBook, string key)
        {
            //查出与关键字匹配的文书。新增首字母联想插入
            string SQl = "select * from T_TEXT where enable_flag='Y' and upper(textname) like '%" + key.ToUpper() + "%' and id not in(select distinct parentid from t_text) and parentid in(select distinct id from t_text where enable_flag='Y') or pyjm like '%" + key.ToUpper() + "%' order by shownum asc";
            //string SQl = "select * from T_TEXT where enable_flag='Y' and id not in(select distinct parentid from t_text) and upper(textname) like '%" + key.ToUpper() + "%' and parentid in(select distinct id from t_text where enable_flag='Y') order by shownum asc";
            DataSet ds = App.GetDataSet(SQl);
            Class_Text[] Directionarys = DataInit.GetSelectClassDs(ds);

            if (Directionarys != null)
            {
                for (int i = 0; i < Directionarys.Length; i++)
                {
                    Node tn = new Node();
                    tn.Tag = Directionarys[i];
                    tn.Text = Directionarys[i].Textname;
                    tn.Name = Directionarys[i].Id.ToString();
                    if (Directionarys[i].Issimpleinstance == "1")
                    {
                        tn.Image = global::Base_Function.Resource.多例文书;
                    }
                    else
                    {
                        tn.Image = global::Base_Function.Resource.单例文书;
                    }
                    trvBook.Nodes.Add(tn);  
                }
            }
        }

        /// <summary>
        /// 搜索文本框文本更改出发按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearchAllText_TextChanged(object sender, EventArgs e)
        {
            picSearch_Click(sender, e);
        }

        /// <summary>
        /// 显示文书对应规则
        /// </summary>
        /// <param name="str">文书类型</param>
        private void DataShow()
        {
            if (!string.IsNullOrEmpty(strTextKind_id))
            {
                try
                {
                    string sql = "select tt.id,tt.code as 编码,tt.name as 规则名称,tt.check_req as 检查要求,tt.deduct_stand as 扣分标准," +
                                    "tt.deduct_score as 单项扣分值,tt.issingveto as 单项否决,tt.singveto_lev as 单项否决级别," +
                                    "tt.ismodify_manual as 手动分值,tt.valid_state as 有效标志,tt.spell_code as 拼音码,tt.type 类型 " +
                                    "from T_MEDICAL_MARK tt inner join T_MEDICAL_MARK_TEXT aa " +
                                    "on tt.id=aa.mark_id where aa.text_id=" + strTextKind_id + "";
                    DataSet ds = App.GetDataSet(sql);

                    dtgRules.DataSource = ds.Tables[0].DefaultView;
                    dtgRules.Refresh();
                    dtgRules.AutoResizeColumns();
                    dtgRules.Columns[3].Width = 70; //检查要求
                    dtgRules.Columns[0].Visible = false;

                    /*
                     * 刷新相关参数
                     */
                    for (int i = 0; i < dtgRules.RowCount; i++)
                    {
                        if (dtgRules["单项否决", i].Value != null)
                        {
                            if (dtgRules["单项否决", i].Value.ToString() == "N")
                            {
                                dtgRules["单项否决", i].Value = "否";
                            }
                            else if (dtgRules["单项否决", i].Value.ToString() == "Y")
                            {
                                dtgRules["单项否决", i].Value = "是";
                            }
                        }

                        if (dtgRules["手动分值", i].Value != null)
                        {
                            //手动分值
                            if (dtgRules["手动分值", i].Value.ToString() == "N")
                            {
                                dtgRules["手动分值", i].Value = "否";
                            }
                            else if (dtgRules["手动分值", i].Value.ToString() == "Y")
                            {
                                dtgRules["手动分值", i].Value = "是";
                            }
                        }

                        //有效标志
                        if (dtgRules["有效标志", i].Value.ToString() == "N")
                        {
                            dtgRules["有效标志", i].Value = "无效";
                        }
                        else if (dtgRules["有效标志", i].Value.ToString() == "Y")
                        {
                            dtgRules["有效标志", i].Value = "有效";
                        }

                        //类型
                        if (dtgRules["类型", i].Value.ToString() == "N")
                        {
                            dtgRules["类型", i].Value = "客观";
                        }
                        else if (dtgRules["类型", i].Value.ToString() == "Y")
                        {
                            dtgRules["类型", i].Value = "主观";
                        }
                    }
                }
                catch { }
            }
        }

        /// <summary>
        /// 当前点击的节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advAllDoc_NodeClick(object sender, TreeNodeMouseEventArgs e)
        {
            strTextKind_id = e.Node.Name;
            DataShow();
        }

        /// <summary>
        /// 创建新规则
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbtnNewRule_Click(object sender, EventArgs e)
        {
            frmMedicalMarkDetial fc = new frmMedicalMarkDetial("");
            fc.ShowDialog();
            if (fc.DialogResult == DialogResult.OK)
            {
                DataShow();
            }
        }
            
        /// <summary>
        /// 修改规则
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbtnChange_Click(object sender, EventArgs e)
        {
            if (dtgRules.SelectedRows.Count > 0)
            {
                string id = dtgRules["id", dtgRules.SelectedRows[0].Index].Value.ToString();
                int rowIndex = dtgRules.SelectedRows[0].Index;
                frmMedicalMarkDetial fc = new frmMedicalMarkDetial(id);
                //fc.TopMost = true;
                fc.ShowDialog();
                if (fc.DialogResult == DialogResult.OK)
                {
                    DataShow();
                    dtgRules.Rows[rowIndex].Selected = true;
                    dtgRules.FirstDisplayedScrollingRowIndex = rowIndex;
                }
            }
            else {
                App.Msg("请选中要修改的规则！");
            }
        }

        /// <summary>
        /// 删除规则
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbtnDel_Click(object sender, EventArgs e)
        {
            if (dtgRules.SelectedRows.Count > 0)
            {
                try
                {
                    if (App.Ask("确认要删除“" + dtgRules["规则名称", dtgRules.SelectedRows[0].Index].Value.ToString() + "”吗？"))
                    {
                        string id = dtgRules["id", dtgRules.SelectedRows[0].Index].Value.ToString();
                        string sqlDelData = "delete T_MEDICAL_MARK where id='" + id + "'";
                        string sqlDelText = "delete T_MEDICAL_MARK_TEXT where mark_id='" + id + "'";

                        List<string> sqls = new List<string>();
                        sqls.Add(sqlDelData);
                        sqls.Add(sqlDelText);
                        App.ExecuteBatch(sqls.ToArray());
                        App.Msg("删除成功！");
                        dtgRules.Rows.Remove(dtgRules.SelectedRows[0]);
                    }
                }
                catch
                {
                    App.Msg("删除失败！");
                }
            }
            else
            {
                App.Msg("请选中要删除的规则！");
            }
        }

        /// <summary>
        /// 行标题序号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgRules_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            e.Row.HeaderCell.Value = string.Format("{0}", e.Row.Index + 1);
        }

    }
}
