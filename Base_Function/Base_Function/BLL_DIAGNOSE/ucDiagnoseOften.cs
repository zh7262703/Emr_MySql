using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;
using DevComponents.AdvTree;
using TextEditor.TextDocument.Document;
using TextEditor.TextDocument.frmWindow;

namespace Base_Function.BLL_DIAGNOSE
{
    public partial class ucDiagnoseOften : UserControl
    {
        public InPatientInfo patient;
        DataTable typeTable;
        string action = string.Empty;
        string caction = string.Empty;
        public ucDiagnoseOften(InPatientInfo _patient)
        {
            InitializeComponent();
            patient = _patient;
            string sql = "select t.id,t.name from t_data_code t where t.type = '65' order by t.order_id";
            typeTable = App.GetDataSet(sql).Tables[0];

            this.tcpWestern.Controls.Add(this.txtDiagnose.listBoxAutoComplete);
            this.txtDiagnose.SetPoint();
            this.txtDiagnose.OnReturnId = ReturnId;
            this.tcpChinese.Controls.Add(this.txtBm.listBoxAutoComplete);
            
            this.txtBm.SetPoint();
            this.txtBm.SetSql(" select bm_name name,bm_code id,bm_name||'  '||bm_code as ni from t_bm where lower(py) like '{0}%' UNION all select bm_name name,bm_code id,bm_name||'  '||bm_code as ni from t_bm where lower(wb) like '{0}%' UNION all select bm_name name,bm_code id,bm_name||'  '||bm_code as ni from t_bm where bm_name like '%{0}%'");
            this.txtBm.OnReturnId = ReturnId2;
            this.tcpChinese.Controls.Add(this.txtZh.listBoxAutoComplete);
            this.txtZh.SetSql(" select zh_name name,zh_code id,zh_name||'  '||zh_code as ni from t_zh where lower(py) like '{0}%' UNION all select zh_name name,zh_code id,zh_name||'  '||zh_code as ni from t_zh where lower(wb) like '{0}%' UNION all select zh_name name,zh_code id,zh_name||'  '||zh_code as ni from t_zh where zh_name like '%{0}%'");
            this.txtZh.SetPoint();
            this.txtZh.OnReturnId = ReturnId3;

            RefreshDiagnose(atDiagnoseList, "N");
            RefreshDiagnose(atChineseDiagnose, "Y");
            cbiSelectAll_Click(null, null);

        }

        public void RefreshDiagnose(AdvTree diagnoseTree, string isChinese)
        {
            diagnoseTree.Nodes.Clear();
            string sqlMainDiagnose = string.Format(@"select id,
                                                           to_char(create_time, 'yyyy-mm-dd hh24:mi') create_time,
                                                           create_id,
                                                           diagnose_name,
                                                           diagnose_icd10,
                                                           diagnose_sort,
                                                           SYMPTOMS_NAME,
                                                           SYMPTOMS_CODE
                                                      from t_diagnose_often where create_id = '{0}' and is_chinese = '{1}'  order by diagnose_sort", App.UserAccount.UserInfo.User_id, isChinese);

            DataTable mainDt = App.GetDataSet(sqlMainDiagnose).Tables[0];
            if (mainDt != null && mainDt.Rows.Count > 0)
            {
                foreach (DataRow mainRow in mainDt.Rows)
                {
                    Node parentNode = new Node();
                    parentNode.Name = mainRow["id"].ToString();
                    parentNode.Text = mainRow["diagnose_name"].ToString();
                    parentNode.Tag = mainRow;
                    parentNode.CheckBoxVisible = true;
                    parentNode.Cells.Add(new Cell(mainRow["diagnose_icd10"].ToString()));
                    if (isChinese == "Y")
                    {
                        parentNode.Cells.Add(new Cell(mainRow["SYMPTOMS_NAME"].ToString()));
                        parentNode.Cells.Add(new Cell(mainRow["SYMPTOMS_CODE"].ToString()));
                    }




                    string sqlTrendDiagnose = string.Format(@"select ID,
                                                                   TREND_DIAGNOSE_NAME,
                                                                   DIAGNOSE_ICD10,
                                                                   TREND_SORT,
                                                                   PARENT_ID,
                                                                   DIAGNOSE_ID
                                                              from t_trend_diagnose_often where DIAGNOSE_ID = '{0}' order by TREND_SORT", parentNode.Name);
                    DataTable trendDt = App.GetDataSet(sqlTrendDiagnose).Tables[0];
                    if (trendDt != null && trendDt.Rows.Count > 0)
                        AddTrendDiagnose(parentNode, parentNode.Name, trendDt, parentNode.Name, isChinese);
                    diagnoseTree.Nodes.Add(parentNode);
                }
            }
            diagnoseTree.ExpandAll();
        }

        #region  文本框
        public void ReturnId(string icd)
        {
            if (icd == "add")
            {
                btnAdd_Click(null, null);
            }
            else
            {
                this.lblIcd10Encode.Text = icd;
            }
        }

        public void ReturnId2(string icd)
        {
            if (icd == "add")
            {
                if (this.txtZh.Enabled == false)
                {
                    btnChineseAdd_Click(null, null);
                }
                else
                {
                    this.txtZh.Focus();
                }
            }
            else
            {
                this.lbChineseBmIcd.Text = icd;
            }
        }

        public void ReturnId3(string icd)
        {
            if (icd == "add")
            {
                btnChineseAdd_Click(null, null);
            }
            else
            {
                this.lbChineseZhIcd.Text = icd;
            }
        }
#endregion

        /// <summary>
        /// 附属诊断加载
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="parentId"></param>
        /// <param name="trendDt"></param>
        /// <param name="parentName"></param>
        /// <param name="icChinese"></param>
        static void AddTrendDiagnose(Node parentNode, string parentId, DataTable trendDt, string parentName, string icChinese)
        {
            DataRow[] dr = trendDt.Select(string.Format("parent_id = '{0}'", parentId));
            if (dr != null && dr.Length > 0)
            {
                foreach (DataRow trendRow in dr)
                {
                    Node childNode = new Node();
                    //childNode.CheckBoxVisible = true;
                    childNode.Name = trendRow["ID"].ToString();
                    childNode.Text = trendRow["TREND_DIAGNOSE_NAME"].ToString();
                    childNode.Cells.Add(new Cell(trendRow["DIAGNOSE_ICD10"].ToString()));
                    childNode.Tag = trendRow;
                    if (childNode.Name != parentId && childNode.Name != parentName)
                        AddTrendDiagnose(childNode, childNode.Name, trendDt, parentName, icChinese);
                    parentNode.Nodes.Add(childNode);
                }
            }
        }

        private void biUp_Click(object sender, EventArgs e)
        {
            ChangedNodeMoveUp(atDiagnoseList);
        }

        static void ChangedNodeMoveUp(AdvTree tree)
        {
            Node selectNode = tree.SelectedNode;
            if (selectNode != null && selectNode.Index > 0)
            {
                Node PrentNode = GetParentNode(selectNode);
                Node preNode = selectNode.PrevNode;
                Node newNode = selectNode.Copy();
                CopyToNode(selectNode, newNode);
                if (selectNode.Parent == null)
                {
                    tree.Nodes.Insert(preNode.Index, newNode);
                    tree.Nodes.Remove(selectNode);
                    tree.SelectedNode = newNode;
                    InterChangerParentId(newNode, preNode);
                }
                else
                {
                    preNode.Parent.Nodes.Insert(preNode.Index, newNode);
                    preNode.Parent.Nodes.Remove(selectNode);
                    tree.SelectedNode = newNode;
                    InterchangeNodeId(newNode, preNode);
                }
            }
        }

        static void ChangedNodeMoveDown(AdvTree tree)
        {
            Node selectNode = tree.SelectedNode;
            if (selectNode != null && selectNode.NextNode != null)
            {
                Node PrentNode = GetParentNode(selectNode);
                Node nextNode = selectNode.NextNode;
                Node newNode = selectNode.Copy();
                CopyToNode(selectNode, newNode);
                if (selectNode.Parent == null)
                {
                    tree.Nodes.Insert(nextNode.Index + 1, newNode);
                    tree.Nodes.Remove(selectNode);
                    tree.SelectedNode = newNode;
                    InterChangerParentId(nextNode, newNode);
                }
                else
                {
                    nextNode.Parent.Nodes.Insert(nextNode.Index + 1, newNode);
                    nextNode.Parent.Nodes.Remove(selectNode);
                    tree.SelectedNode = newNode;
                    InterchangeNodeId(nextNode, newNode);
                }
            }
        }

        /// <summary>
        /// 交换排序ID
        /// </summary>
        /// <param name="_node1"></param>
        /// <param name="_node2"></param>
        /// <returns></returns>
        static int InterchangeNodeId(Node _node1, Node _node2)
        {
            string sql1 = string.Format("UPDATE t_trend_diagnose_often T set T.TREND_SORT = T.TREND_SORT-1 WHERE T.ID = '{0}'", _node1.Name);
            string sql2 = string.Format("UPDATE t_trend_diagnose_often Y set Y.TREND_SORT = Y.TREND_SORT+1 WHERE Y.ID = '{0}'", _node2.Name);
            return App.ExecuteBatch(new string[] { sql1, sql2 });
        }

        static int InterChangerParentId(Node _node1, Node _node2)
        {
            string sql1 = string.Format("UPDATE t_diagnose_often T set T.diagnose_sort =T.diagnose_sort-1 WHERE T.ID = '{0}'", _node1.Name);
            string sql2 = string.Format("UPDATE t_diagnose_often Y set Y.diagnose_sort =Y.diagnose_sort+1 WHERE Y.ID = '{0}'", _node2.Name);
            return App.ExecuteBatch(new string[] { sql1, sql2 });
        }

        /// <summary>
        /// 获取顶级节点
        /// </summary>
        /// <param name="_node"></param>
        /// <returns></returns>
        static Node GetParentNode(Node _node)
        {
            Node node = _node;
            while (node.Parent != null)
            {
                node = node.Parent;
            }
            return node;
        }

        /// <summary>
        /// 复制到新节点
        /// </summary>
        /// <param name="oldNode"></param>
        /// <param name="newNode"></param>
        /// <returns></returns>
        static void CopyToNode(Node oldNode, Node newNode)
        {
            foreach (Node childNode in oldNode.Nodes)
            {
                Node newChildNode = childNode.Copy();
                newNode.Nodes.Add(newChildNode);
                CopyToNode(childNode, newChildNode);
            }
        }

        private void biDown_Click(object sender, EventArgs e)
        {
            ChangedNodeMoveDown(atDiagnoseList);
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            string diagnoseName = this.txtDiagnose.Text.Trim().Replace("'", "''");
            string timeStr = App.GetSystemTime().ToString("yyyy-MM-dd HH:mm:ss");
            if (string.IsNullOrEmpty(diagnoseName))
            {
                App.Msg("[诊断名称]未填写完整！");
                return;
            }

            if (this.action == "trend")
            {
                Node selectNode = this.atDiagnoseList.SelectedNode;
                if (selectNode != null)
                {
                    Node parentNode = GetParentNode(selectNode);

                    int num = parentNode.Nodes.Count;
                    t_trend_diagnose_often tstd = new t_trend_diagnose_often(parentNode.Name, diagnoseName, this.lblIcd10Encode.Text, num + 1, selectNode.Name);
                    if (tstd.Insert())
                    {
                        App.Msg("附属诊断添加成功！");
                    }
                }
            }
            else if (this.action == "update")
            {
                Node selectNode = this.atDiagnoseList.SelectedNode;
                if (selectNode != null)
                {
                    if (selectNode.Parent == null)
                    {//(this.lblIcd10Encode.Text, "", diagnoseName, this.lblIcd10Encode.Text, 0, "0", this, this.comboBox1.SelectedValue.ToString(), this.dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm"));
                        t_diagnose_often tsd = new t_diagnose_often("", diagnoseName, this.lblIcd10Encode.Text, 0, this);
                        if (tsd.Update(selectNode.Name))
                        {
                            App.Msg("诊断修改成功！");
                        }
                    }
                    else
                    {
                        t_trend_diagnose_often tstd = new t_trend_diagnose_often("", diagnoseName, this.lblIcd10Encode.Text, 0, "");
                        if (tstd.Update(selectNode.Name))
                        {
                            App.Msg("附属诊断修改成功！");
                        }
                    }
                }
            }
            else
            {
                int num = this.atDiagnoseList.Nodes.Count;
                
                t_diagnose_often tsd = new t_diagnose_often(timeStr, diagnoseName, this.lblIcd10Encode.Text, num + 1,  this);
                if (tsd.Insert())
                {
                    App.Msg("诊断添加成功！");
                }
            }
            this.action = string.Empty;
            this.atDiagnoseList.Enabled = true;
            this.clearDiagnose();
            RefreshDiagnose(atDiagnoseList, "N");
        }

        private void 添加附属诊断ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Node selectNode = this.atDiagnoseList.SelectedNode;
            if (selectNode != null)
            {
                this.action = "trend";
                this.atDiagnoseList.Enabled = false;
                clearDiagnose();
            }
            else
            {
                App.Msg("请选中要添加附属诊断的节点！");
            }
        }

        void clearDiagnose()
        {
            this.lblIcd10Encode.Text = "";
            this.txtDiagnose.Text = "";
        }

        void clearChineseDiagnose()
        {
            this.lbChineseBmIcd.Text = "";
            this.lbChineseZhIcd.Text = "";
            this.txtBm.Text = "";
            this.txtZh.Text = "";
            this.txtZh.Enabled = true;
        }

        private void atDiagnoseList_NodeDoubleClick(object sender, TreeNodeMouseEventArgs e)
        {
            Node selectNode = (sender as AdvTree).SelectedNode;
            if (selectNode != null)
            {
                selectNode.Checked = !selectNode.Checked;
            }
        }

        static void ChildCheck(Node node, bool b)
        {
            if (node.Nodes.Count > 0)
            {
                foreach (Node childNode in node.Nodes)
                {
                    childNode.Checked = b;
                    ChildCheck(childNode, b);
                }
            }
        }

        private void atDiagnoseList_AfterCheck(object sender, AdvTreeCellEventArgs e)
        {
            if (changed)
                return;
            Node selectNode = this.atDiagnoseList.SelectedNode;
            if (selectNode != null)
            {
                ChildCheck(selectNode, selectNode.Checked);
            }
        }

        private void atDiagnoseList_NodeMouseDown(object sender, TreeNodeMouseEventArgs e)
        {
            Node findNode = this.atDiagnoseList.GetNodeAt(e.Y);
            if (findNode != null)
            {
                //this.atDiagnoseList.SelectedNode = findNode;
            }
        }

        private void 删除诊断ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Node selectNode = this.atDiagnoseList.SelectedNode;
            if (selectNode == null)
            {
                App.Msg("请选中要删除诊断的节点！");
                return;
            }
            if (MessageBox.Show("确定要删除该诊断吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                return;
            if (selectNode.Parent == null)
            {
                t_diagnose_often.Delete(selectNode.Name, "N");
                t_trend_diagnose_often.Delete(selectNode.Name, 1, "");
            }
            else
            {
                t_trend_diagnose_often.Delete(selectNode.Name, 0, selectNode.Parent.Name);
            }
            this.action = string.Empty;
            this.atDiagnoseList.Enabled = true;
            this.clearDiagnose();
            RefreshDiagnose(atDiagnoseList, "N");
        }

        private void 修改诊断ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Node selectNode = this.atDiagnoseList.SelectedNode;
            if (selectNode != null)
            {
                this.action = "update";
                this.atDiagnoseList.Enabled = false;
                this.txtDiagnose.Text = selectNode.Text;
                this.lblIcd10Encode.Text = ((DataRow)selectNode.Tag)["diagnose_icd10"].ToString();
            }
            else
            {
                App.Msg("请选中要修改的诊断节点！");
            }
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.action = string.Empty;
            this.atDiagnoseList.Enabled = true;
            this.clearDiagnose();
        }
        bool changed = false;
        private void cbiSelectAll_Click(object sender, EventArgs e)
        {
            changed = true;
            if (this.atDiagnoseList.Nodes.Count > 0)
            {
                foreach (Node node in this.atDiagnoseList.Nodes)
                {
                    //ChildCheck(node, node.Checked);
                    node.Checked = this.checkBoxItem2.Checked;
                }
            }
            changed = false;
        }

        bool isCheckedMore(Node tvNode)
        {
            if (tvNode.Nodes.Count > 0)
            {
                int count1 = 0;
                foreach (Node node in tvNode.Nodes)
                {
                    if (node.Checked)
                    {
                        count1++;
                    }
                    if (count1 > 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        bool isCheckedMore(AdvTree tvNode)
        {
            if (tvNode.Nodes.Count > 0)
            {
                int count1 = 0;
                foreach (Node node in tvNode.Nodes)
                {
                    if (node.Checked)
                    {
                        count1++;
                    }
                    if (count1 > 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        
        /// <summary>
        /// 复制诊断
        /// </summary>
        /// <param name="diagnoseid"></param>
        /// <param name="type"></param>
        /// <param name="sqlList"></param>
        /// <param name="create_time"></param>
        private void GetSql(string type, string create_time, Node treeNode, List<string> sqlList, int countAdd, string is_chinese, string sxqm)
        {
            string id = App.GetDataSet("select T_DIAGNOSE_ITEM_ID.nextval from dual").Tables[0].Rows[0][0].ToString();
            string max = App.GetDataSet(string.Format("select max(diagnose_sort)+{2} from t_diagnose_item where patient_id = '{0}' and diagnose_type = '{1}' and is_chinese = '{3}'", this.patient.Id.ToString(), type, countAdd + 1, is_chinese)).Tables[0].Rows[0][0].ToString();
            
            if (string.IsNullOrEmpty(max))
            {
                max = countAdd.ToString();
            }
            //id,diagnose_type,diagnose_code,create_id,create_time,fix_time,diagnose_name, diagnose_icd10,diagnose_sort,patient_id,is_chinese,symptoms_name,symptoms_code
            string sql = string.Format(@"INSERT INTO t_diagnose_item( id,                     
                                     diagnose_code,          
                                     create_time,            
                                     fix_time,               
                                     create_id,              
                                     diagnose_name,          
                                     diagnose_icd10,         
                                     is_chinese,         
                                     patient_id,             
                                     diagnose_sort,          
                                     diagnose_type,          
                                     SYMPTOMS_NAME,          
                                     SYMPTOMS_CODE  {0} ) 
                                    SELECT 
                                    '{1}',
                                    diagnose_icd10,
                                    to_TIMESTAMP('{2}','yyyy-MM-dd hh24:mi:ss'),
                                    to_TIMESTAMP('{2}','yyyy-MM-dd hh24:mi:ss'),
                                    '{3}',
                                    diagnose_name,
                                    diagnose_icd10,
                                    is_chinese,
                                    '{9}',
                                    '{4}',
                                    '{5}',
                                    SYMPTOMS_NAME,
                                    SYMPTOMS_CODE ,
                                    '{6}',
                                    '{7}'
                                     FROM t_diagnose_often 
                                     WHERE ID = '{8}'",
                                    sxqm,
                                    id,
                                    create_time,
                                    App.UserAccount.UserInfo.User_id,
                                    max,
                                    type,
                                    App.UserAccount.UserInfo.User_id,
                                    App.UserAccount.UserInfo.User_name,
                                    treeNode.Name,
                                    this.patient.Id.ToString()
                                   );


            
            sqlList.Add(sql);
            SetCopyDiagnose(sqlList, treeNode, id, id);
        }

        private void SetCopyDiagnose(List<string> sqlList, Node _node, string id, string parentId)
        {
            foreach (Node childNode in _node.Nodes)
            {
                DataRow row = childNode.Tag as DataRow;
                string newid = App.GetDataSet("select T_DIAGNOSE_ITEM_ID.nextval from dual").Tables[0].Rows[0][0].ToString(); //诊断条目ID
                string sql = string.Format(" INSERT INTO t_trend_diagnose (ID,DIAGNOSEITEM_ID,TREND_DIAGNOSE_NAME,DIAGNOSE_ICD10,DIAGNOSE_CODE,SORT_SEQUENCE,PARENT_ID) "
                           + " VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", newid, id, childNode.Text.Replace("'", "''"), row["DIAGNOSE_ICD10"].ToString(), row["DIAGNOSE_ICD10"].ToString(), childNode.Index, parentId);
                sqlList.Add(sql);
                if (childNode.Nodes.Count > 0)
                {
                    SetCopyDiagnose(sqlList, childNode, id, newid);
                }
                
            }
        }

        //private void buttonX3_Click(object sender, EventArgs e)
        //{
        //    frmDiagnoseModify fr = new frmDiagnoseModify(document);
        //    fr.ShowDialog();
        //}

        private void atDiagnoseList_DoubleClick(object sender, EventArgs e)
        {
            atDiagnoseList_NodeDoubleClick(sender, null);
        }

        private void btnChineseClear_Click(object sender, EventArgs e)
        {
            this.caction = string.Empty;
            this.atChineseDiagnose.Enabled = true;
            this.clearChineseDiagnose();
        }

        private void btnChineseAdd_Click(object sender, EventArgs e)
        {
            string diagnoseBm = this.txtBm.Text.Trim();
            string diagnoseZh = this.txtZh.Text.Trim();
            if (string.IsNullOrEmpty(diagnoseBm))
            {
                App.Msg("[病名]未填写完整！");
                return;
            }

            string timeStr = App.GetSystemTime().ToString("yyyy-MM-dd HH:mm:ss");
            if (this.caction == "trend")
            {
                Node selectNode = this.atChineseDiagnose.SelectedNode;
                if (selectNode != null)
                {
                    Node parentNode = GetParentNode(selectNode);

                    int num = parentNode.Nodes.Count;
                    t_trend_diagnose_often tstd = new t_trend_diagnose_often(parentNode.Name, diagnoseBm, this.lbChineseBmIcd.Text, num + 1, selectNode.Name);
                    if (tstd.Insert())
                    {
                        App.Msg("附属诊断添加成功！");
                    }
                }
            }
            else if (this.caction == "update")
            {
                Node selectNode = this.atChineseDiagnose.SelectedNode;
                if (selectNode != null)
                {
                    if (selectNode.Parent == null)
                    {
                        t_diagnose_often tsd = new t_diagnose_often( "", diagnoseBm, this.lbChineseBmIcd.Text, 0, "Y", diagnoseZh, this.lbChineseZhIcd.Text, this);
                        if (tsd.Update(selectNode.Name))
                        {
                            App.Msg("诊断修改成功！");
                        }
                    }
                    else
                    {
                        t_trend_diagnose_often tstd = new t_trend_diagnose_often("", diagnoseBm, this.lbChineseBmIcd.Text, 0, "");
                        if (tstd.Update(selectNode.Name))
                        {
                            App.Msg("附属诊断修改成功！");
                        }
                    }
                }
            }
            else
            {
                int num = this.atChineseDiagnose.Nodes.Count;
                t_diagnose_often tsd = new t_diagnose_often( timeStr, diagnoseBm, this.lbChineseBmIcd.Text, num + 1, "Y", diagnoseZh, this.lbChineseZhIcd.Text, this);
                if (tsd.Insert())
                {
                    App.Msg("诊断添加成功！");
                }
            }
            this.caction = string.Empty;
            this.atChineseDiagnose.Enabled = true;
            this.clearChineseDiagnose();
            RefreshDiagnose(atChineseDiagnose, "Y");
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Node selectNode = this.atChineseDiagnose.SelectedNode;
            if (selectNode != null)
            {
                this.caction = "trend";
                this.atChineseDiagnose.Enabled = false;
                clearChineseDiagnose();
                this.txtZh.Enabled = false;
            }
            else
            {
                App.Msg("请选中要添加附属诊断的节点！");
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Node selectNode = this.atChineseDiagnose.SelectedNode;
            if (selectNode != null)
            {
                this.caction = "update";
                this.atChineseDiagnose.Enabled = false;
                DataRow row = (DataRow)selectNode.Tag;
                this.txtBm.Text = selectNode.Text;
                this.lbChineseBmIcd.Text = row["diagnose_icd10"].ToString();
                if (selectNode.Parent == null)
                {
                    this.txtZh.Text = row["SYMPTOMS_NAME"].ToString();
                    this.lbChineseZhIcd.Text = row["SYMPTOMS_CODE"].ToString();
                }
                else
                {
                    this.txtZh.Text = "";
                    this.lbChineseZhIcd.Text = "";
                    this.txtZh.Enabled = false;
                }
            }
            else
            {
                App.Msg("请选中要修改的诊断节点！");
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Node selectNode = this.atChineseDiagnose.SelectedNode;
            if (selectNode == null)
            {
                App.Msg("请选中要删除诊断的节点！");
                return;
            }
            if (MessageBox.Show("确定要删除该诊断吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No)
                return;
            if (selectNode.Parent == null)
            {
                t_diagnose_often.Delete(selectNode.Name, "Y");
                t_trend_diagnose_often.Delete(selectNode.Name, 1, "");
            }
            else
            {
                t_trend_diagnose_often.Delete(selectNode.Name, 0, selectNode.Parent.Name);
            }

            this.caction = string.Empty;
            this.atChineseDiagnose.Enabled = true;
            this.clearChineseDiagnose();
            RefreshDiagnose(atChineseDiagnose, "Y");
        }

        private void atChineseDiagnose_DoubleClick(object sender, EventArgs e)
        {
            atDiagnoseList_NodeDoubleClick(sender, null);
        }

        bool chineseChanged = false;
        private void atChineseDiagnose_AfterCheck(object sender, AdvTreeCellEventArgs e)
        {
            if (chineseChanged)
                return;
            Node selectNode = this.atChineseDiagnose.SelectedNode;
            if (selectNode != null)
            {
                ChildCheck(selectNode, selectNode.Checked);
            }
        }

        private void checkBoxItem1_Click(object sender, EventArgs e)
        {
            chineseChanged = true;
            if (this.atChineseDiagnose.Nodes.Count > 0)
            {
                foreach (Node node in this.atChineseDiagnose.Nodes)
                {
                    node.Checked = checkBoxItem1.Checked;
                    //ChildCheck(node, node.Checked);
                }
            }
            chineseChanged = false;
        }

        private void buttonItem1_Click(object sender, EventArgs e)
        {
            ChangedNodeMoveUp(atChineseDiagnose);
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {
            ChangedNodeMoveDown(atChineseDiagnose);
        }

        

        void items_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem items = sender as ToolStripMenuItem;
            if (items != null)
            {
                AdvTree advTree;
                if (items.Tag.ToString() == "N")
                {
                    advTree = this.atDiagnoseList;
                }
                else
                {
                    advTree = this.atChineseDiagnose;
                }
                string sxqm = string.Empty;
                this.GetDiagnoseQm(ref sxqm);
                if (string.IsNullOrEmpty(sxqm))
                {
                    App.Msg("您的权限不能够复制诊断。");
                    return;
                }
                List<string> list = new List<string>();
                int countadd = 0;
                foreach (Node item in advTree.Nodes)
                {
                    if (item.Checked)
                    {
                        GetSql(items.Name, App.GetSystemTime().ToString(), item, list, countadd, items.Tag.ToString(), sxqm);
                        countadd++;
                    }
                }
                if (list.Count > 0)
                {
                    if (App.ExecuteBatch(list.ToArray()) > 0)
                    {
                        App.Msg("复制成功。");
                        return;
                    }
                    App.Msg("复制失败");
                }
                else
                {
                    App.Msg("请勾选需要复制的诊断。");
                }
            }
        }

        private void cmsDiagnose_Opening(object sender, CancelEventArgs e)
        {
            this.复制诊断ToolStripMenuItem.DropDownItems.Clear();
            foreach (DataRow row in typeTable.Rows)
            {
                ToolStripMenuItem items = new ToolStripMenuItem();
                items.Text = row[1].ToString();
                items.Tag = "N";
                items.Name = row[0].ToString();
                items.Click += new EventHandler(items_Click);
                this.复制诊断ToolStripMenuItem.DropDownItems.Add(items);
            }
        }


        public string GetDiagnoseQm(ref string sxQx)
        {
            string currentUserId = App.UserAccount.UserInfo.User_id;
            //if (currentUserId == patient.Resident_Doctor_Id.ToString())
            //{
            //    sxQx = ",yjsx_id,yjsx_name";
            //}
            //if (currentUserId == patient.Charge_Doctor_Id.ToString())
            //{
            //    sxQx = ",ejsx_id,ejsx_name";
            //}
            //if (currentUserId == patient.Chief_Doctor_Id.ToString())
            //{
            //    sxQx = ",sjsx_id,sjsx_name";
            //}
            sxQx = ",yjsx_id,yjsx_name";
            if (string.IsNullOrEmpty(sxQx))
            {
                if (App.UserAccount.UserInfo.Guid_doctor_id == patient.Resident_Doctor_Id.ToString()
                    || App.UserAccount.UserInfo.Guid_doctor_id == patient.Charge_Doctor_Id.ToString()
                    || App.UserAccount.UserInfo.Guid_doctor_id == patient.Chief_Doctor_Id.ToString())
                {
                    sxQx = ",fssx_id,fssx_name";
                }
            }
            return currentUserId;
        }

        private void cmsChineseDiagnose_Opening(object sender, CancelEventArgs e)
        {
            this.复制诊断到ToolStripMenuItem.Enabled = true;
            this.复制诊断到ToolStripMenuItem.Visible = true;
            this.复制诊断到ToolStripMenuItem.DropDownItems.Clear();
            foreach (DataRow row in typeTable.Rows)
            {
                ToolStripMenuItem items = new ToolStripMenuItem();
                items.Text = row[1].ToString();
                items.Name = row[0].ToString();
                items.Tag = "Y";
                items.Click += new EventHandler(items_Click);
                this.复制诊断到ToolStripMenuItem.DropDownItems.Add(items);
            }
        }

        private void 添加为常用诊断ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem items = sender as ToolStripMenuItem;
            AdvTree advTree;
            if (items.Tag.ToString() == "N")
            {
                advTree = this.atDiagnoseList;
            }
            else
            {
                advTree = this.atChineseDiagnose;
            }
            List<string> list = new List<string>();
            int countadd = 0;
            DateTime createTime = App.GetSystemTime();
            foreach (Node item in advTree.Nodes)
            {
                if (item.Checked)
                {
                    //GetSql(items.Name, App.GetSystemTime().ToString(), item, list, countadd, IsChinese);
                    string diagnose_id = App.GetDataSet("select T_DIAGNOSE_ITEM_ID.nextval from dual").Tables[0].Rows[0][0].ToString();
                    string sql = string.Format(@"INSERT INTO t_diagnose_often( id,
                                                                              create_time,
                                                                              create_id,
                                                                              diagnose_name,
                                                                              diagnose_icd10,
                                                                              is_chinese,
                                                                              diagnose_sort,
                                                                              symptoms_name,
                                                                              symptoms_code)
                                                                        SELECT 
                                                                              '{0}',
                                                                              to_TIMESTAMP('{1}','yyyy-MM-dd hh24:mi:ss'),
                                                                              '{2}',
                                                                              diagnose_name,
                                                                              diagnose_icd10,
                                                                              is_chinese,
                                                                              diagnose_sort,
                                                                              symptoms_name,
                                                                              symptoms_code
                                                                        FROM t_diagnose_item  WHERE ID = '{3}'",
                                                                        diagnose_id,
                                                                        createTime.ToString(),
                                                                        App.UserAccount.UserInfo.User_id,
                                                                        item.Name);
                    list.Add(sql);
                    SetCopyTrend_diagnose_often(list, item, diagnose_id, diagnose_id);
                    countadd++;
                }
            }
            if (list.Count > 0)
            {
                if (App.ExecuteBatch(list.ToArray()) > 0)
                {
                    App.Msg("添加成功。");
                    return;
                }
                App.Msg("添加失败");
            }
            else
            {
                App.Msg("请勾选需要添加为常用的诊断。");
            }
        }

        private void SetCopyTrend_diagnose_often(List<string> sqlList, Node _node, string diagnoseId, string parentId)
        {
            foreach (Node childNode in _node.Nodes)
            {
                DataRow row = childNode.Tag as DataRow;
                string newid = App.GetDataSet("select T_DIAGNOSE_ITEM_ID.nextval from dual").Tables[0].Rows[0][0].ToString(); //诊断条目ID
                string sql = string.Format(@"INSERT INTO t_trend_diagnose_often(ID,
                                                TREND_DIAGNOSE_NAME,
                                                DIAGNOSE_ICD10,
                                                TREND_SORT,
                                                PARENT_ID,DIAGNOSE_ID) 
                                            VALUES('{0}','{1}','{2}','{3}','{4}','{5}')",
                                      newid,
                                      childNode.Text.Replace("'", "''"),
                                      row["DIAGNOSE_ICD10"].ToString(),
                                      childNode.Index,
                                      parentId, diagnoseId);
                sqlList.Add(sql);
                if (childNode.Nodes.Count > 0)
                {
                    SetCopyTrend_diagnose_often(sqlList, childNode, diagnoseId, newid);
                }
            }
        }

        private void btnSelN_Click(object sender, EventArgs e)
        {
            RefreshDiagnose(atDiagnoseList, "N");
        }
        private void btnSelY_Click(object sender, EventArgs e)
        {
            RefreshDiagnose(atChineseDiagnose, "Y");
        }

    }
    public class t_diagnose_often
    {
        private string create_time;

        public string Create_time
        {
          get { return create_time; }
          set { create_time = value; }
        }
        private string diagnose_name;

        public string Diagnose_name
        {
          get { return diagnose_name; }
          set { diagnose_name = value; }
        }
        private string diagnose_icd10;

        public string Diagnose_icd10
        {
          get { return diagnose_icd10; }
          set { diagnose_icd10 = value; }
        }
        private int diagnose_sort;

        public int Diagnose_sort
        {
          get { return diagnose_sort; }
          set { diagnose_sort = value; }
        }
        private string is_chinese = "N";

        public string Is_chinese
        {
          get { return is_chinese; }
          set { is_chinese = value; }
        }
        private string symptoms_name;

        public string Symptoms_name
        {
          get { return symptoms_name; }
          set { symptoms_name = value; }
        }
        private string symptoms_code;

        public string Symptoms_code
        {
          get { return symptoms_code; }
          set { symptoms_code = value; }
        }

        private ucDiagnoseOften DiagnoseOften;

        public t_diagnose_often(
            string time,
            string name,
            string icd10,
            int sort,
            ucDiagnoseOften DiagnoseSimple)
        {
            this.create_time = time;
            this.diagnose_name = name;
            this.diagnose_icd10 = icd10;
            this.diagnose_sort = sort;
            DiagnoseOften = DiagnoseSimple;
        }

        public t_diagnose_often(
            string time,
            string name,
            string icd10,
            int sort,
            string is_chinese,
            string zhName,
            string zhIcd,
            ucDiagnoseOften DiagnoseSimple)
        {
            this.create_time = time;
            this.diagnose_name = name;
            this.diagnose_icd10 = icd10;
            this.diagnose_sort = sort;
            this.symptoms_name = zhName;
            this.Symptoms_code = zhIcd;
            this.is_chinese = is_chinese;
            DiagnoseOften = DiagnoseSimple;
        }


        public bool Insert()
        {
            string newid = App.GetDataSet("select T_DIAGNOSE_ITEM_ID.nextval from dual").Tables[0].Rows[0][0].ToString();
            string max = App.GetDataSet(string.Format("select max(diagnose_sort)+1 from t_diagnose_often where create_id = '{0}' and is_chinese = '{1}'", App.UserAccount.UserInfo.User_id, this.is_chinese)).Tables[0].Rows[0][0].ToString();
            if (string.IsNullOrEmpty(max))
            {
                max = "0";
            }
            string sql = string.Format(@"INSERT INTO t_diagnose_often( id,
                                                                      create_time,
                                                                      create_id,
                                                                      diagnose_name,
                                                                      diagnose_icd10,
                                                                      is_chinese,
                                                                      diagnose_sort,
                                                                      symptoms_name,
                                                                      symptoms_code) values(
                                                                      '{0}',
                                                                      to_TIMESTAMP('{1}','yyyy-MM-dd hh24:mi:ss'),
                                                                      '{2}',
                                                                      '{3}',
                                                                      '{4}',
                                                                      '{5}',
                                                                      '{6}',
                                                                      '{7}',
                                                                      '{8}')",
                                                                newid,
                                                                create_time,
                                                                App.UserAccount.UserInfo.User_id,
                                                                diagnose_name,
                                                                diagnose_icd10,
                                                                is_chinese,
                                                                max,
                                                                symptoms_name,
                                                                symptoms_code);
            if (App.ExecuteSQL(sql) > 0)
                return true;
            return false;
        }

        public static bool Delete(string id, string isChinese)
        {
            //string sql2 = string.Format("update t_diagnose_often t set t.diagnose_sort = t.diagnose_sort-1 where t.patient_id = '{0}' and is_chinese='{3}' and t.diagnose_type = '{2}' and t.diagnose_sort > (select x.diagnose_sort from t_diagnose_item x where x.id = '{1}')", patient_id, id, diagnose_type, isChinese);
            //App.ExecuteSQL(sql2);
            string sql = string.Format("delete t_diagnose_often where id = '{0}'", id);
            if (App.ExecuteSQL(sql) > 0)
                return true;
            return false;
        }

        public bool Update(string id)
        {
            string sql = string.Format(@"update t_diagnose_often 
                                          set
                                          diagnose_name = '{1}',
                                          diagnose_icd10 = '{2}',
                                          symptoms_name = '{3}',
                                          symptoms_code = '{4}'  
                                          where id = '{0}'",
                                          id,
                                          diagnose_name,
                                          diagnose_icd10,
                                          symptoms_name,
                                          symptoms_code);
            if (App.ExecuteSQL(sql) > 0)
                return true;
            return false;
        }
    }

    public class t_trend_diagnose_often 
    {
        private string diagnose_id;

        public string Diagnose_id
        {
          get { return diagnose_id; }
          set { diagnose_id = value; }
        }
        private string trend_diagnose_name;

        public string Trend_diagnose_name
        {
          get { return trend_diagnose_name; }
          set { trend_diagnose_name = value; }
        }
        private string trend_diagnose_icd10;

        public string Trend_diagnose_icd10
        {
          get { return trend_diagnose_icd10; }
          set { trend_diagnose_icd10 = value; }
        }
        private int trend_sort;

        public int Trend_sort
        {
          get { return trend_sort; }
          set { trend_sort = value; }
        }
        private string parent_id;

        public string Parent_id
        {
          get { return parent_id; }
          set { parent_id = value; }
        }

        public t_trend_diagnose_often(
            string parentId,
            string name,
            string icd10,
            int sort,
            string pid)
        {
            diagnose_id = parentId;
            trend_diagnose_name = name;
            trend_diagnose_icd10 = icd10;
            trend_sort = sort;
            parent_id = pid;
        }

        public bool Insert()
        {
            string newid = App.GetDataSet("select T_DIAGNOSE_ITEM_ID.nextval from dual").Tables[0].Rows[0][0].ToString();

            string max = App.GetDataSet(string.Format("select max(TREND_SORT)+1 from t_trend_diagnose_often where parent_id = '{0}'", parent_id)).Tables[0].Rows[0][0].ToString();
            if (string.IsNullOrEmpty(max))
            {
                max = "0";
            }
            string sql = string.Format(@"INSERT INTO t_trend_diagnose_often(ID,
                                                TREND_DIAGNOSE_NAME,
                                                DIAGNOSE_ICD10,
                                                TREND_SORT,
                                                PARENT_ID,
                                                DIAGNOSE_ID) 
                                            VALUES('{0}','{1}','{2}','{3}','{4}','{5}')",
                                      newid,
                                      trend_diagnose_name,
                                      trend_diagnose_icd10,
                                      max,
                                      parent_id,
                                      diagnose_id);
            if (App.ExecuteSQL(sql) > 0)
                return true;
            return false;
        }

        public static bool Delete(string id, int type, string parent_id)
        {
            string sql = string.Empty;
            if (type == 0)
            {
                //string sql2 = string.Format("update t_trend_diagnose t set t.sort_sequence = t.sort_sequence-1 where t.parent_id = '{0}' and t.sort_sequence > (select x.sort_sequence from t_trend_diagnose x where x.id = '{1}')", parent_id, id);
                //App.ExecuteSQL(sql2);

                sql = string.Format("delete t_trend_diagnose_often where id = {0}", id);
            }
            else
                sql = string.Format("delete t_trend_diagnose_often where parent_id ='{0}'", id);
            if (App.ExecuteSQL(sql) > 0)
                return true;
            return false;
        }

        public bool Update(string id)
        {
            string sql = string.Format(@"update t_trend_diagnose_often  set 
                                            trend_diagnose_name = '{0}',
                                            DIAGNOSE_ICD10 = '{1}' 
                                            where id = '{2}'",
                                            trend_diagnose_name,
                                            trend_diagnose_icd10,
                                            id);
            if (App.ExecuteSQL(sql) > 0)
                return true;
            return false;
        }
    }
}
