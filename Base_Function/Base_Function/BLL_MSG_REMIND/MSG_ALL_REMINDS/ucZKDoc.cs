using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Bifrost;
using DevComponents.AdvTree;
using Base_Function.BASE_COMMON;
using Base_Function.BLL_NURSE.Odinopoeia_Record;
using Base_Function.BLL_DOCTOR;
using Base_Function.BLL_NURSE.NBlood_sugarRecord;
using Base_Function.BLL_NURSE.Expectant_Record;
using Base_Function.BLL_NURSE.SickInformational;
using Base_Function.BLL_NURSE.Nereuse_record;
using Base_Function.BLL_NURSE.Nurse_Record;
using Moran.Partogram;
using MoranEditor.GUI;
using Base_Function.TEMPERATURES;
using Base_Function.BLL_NURSE.First_cases;
using TextEditor;
using System.Xml;
using System.Collections;


namespace Base_Function.BLL_MSG_REMIND.MSG_ALL_REMINDS
{
    /// <summary>
    /// 个人质控主界面
    /// </summary>
    public partial class ucZKDoc : UserControl
    {
        /// <summary>
        /// 当前病人对象。 
        /// </summary>
        public InPatientInfo currentPatient;

        //保存所有的文书类型
        //public static AdvTree temptrvbook = new AdvTree();

        private string Record_Time = null;
        private string Record_Content = null;
        private static Node CurrentNode = new Node();

        /// <summary>
        /// 是否是定制的文书
        /// </summary>
        private bool isCustom = false;

        /// <summary>
        /// 文书不可删除的原因
        /// </summary>
        string delBookReason = "";

        /// <summary>
        /// 浏览的文书集合
        /// </summary>
        private Node BrowseNodes;

        /// <summary>
        /// 多实例文书保存成功后，返回文书id
        /// </summary>
        private string book_Id = "";

        /// <summary>
        /// 是否直接点击浏览按钮显示 true 是 false 否
        /// </summary>
        private bool ClickShow = true;

        /// <summary>
        /// 弹出时间选择窗体的返回值，点击确定返回True，点击取消返回false
        /// </summary>
        public static bool isFlagtrue = false;

        AdvTree NowTree = new AdvTree();

        public ucZKDoc()
        {
            InitializeComponent();
        }

        public ucZKDoc(InPatientInfo patientInfo)
        {
            InitializeComponent();
            currentPatient = patientInfo;
        }

        /// <summary>
        /// 刷新文书操作的树
        /// 1.清空树节点
        /// 2.加载住院病程记录下的所有文书类型
        /// 3.把已写的文书加载到树上
        /// 4.移除住院病程记录下没有写文书的节点
        /// </summary>
        private void ReflashTrvBook()
        {
            advFinishDoc.Nodes.Clear();
            AddFinishNode();
            RemoveBookNode(advFinishDoc.Nodes);
            advFinishDoc.ExpandAll();//展开所有文书节点
        }


        /// <summary>
        /// 已写文书
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advFinishDoc_DoubleClick(object sender, EventArgs e)
        {
            NowTree = sender as AdvTree;
            if (advFinishDoc.SelectedNode != null)
            {
                bool isFlag = IsSameTabItem(NowTree.SelectedNode.Name, App.GetSystemTime().ToString("yyyy-MM-dd HH:mm"));
                if (!isFlag)
                {
                    Class_Text text = null;
                    //得到文书类型对象
                    if (NowTree.SelectedNode.Tag.GetType().ToString().Contains("Class_Text"))
                    {
                        text = NowTree.SelectedNode.Tag as Class_Text;
                    }
                    else if (NowTree.SelectedNode.Tag.GetType().ToString().Contains("Patient_Doc"))
                    {
                        text = NowTree.SelectedNode.Parent.Tag as Class_Text;
                    }
                    //定制文书
                    if (!create_Nurse_Book(NowTree.SelectedNode, tctlDoc, currentPatient))
                    {
                        //非定制文书
                        //浏览状态显示文书
                        tlspmnitBrowse_Click(sender, e);
                    }
                }
            }
        }

        private void advFinishDoc_Click(object sender, EventArgs e)
        {
            advFinishDoc_DoubleClick(sender, e);
        }

        /// <summary>
        /// 添加已完成文书
        /// </summary>
        public void AddFinishNode()
        {

            Node node = null;
            if (currentPatient != null)
            {
                node = DataInit.SelectDoc(currentPatient.Id);//获得已写文书
            }
            //取得非住院病程记录文书父节点的ID，拼接字符串以逗号隔开
            string docStr = "";
            for (int i = 0; i < node.Nodes.Count; i++)
            {
                Patient_Doc doc = node.Nodes[i].Tag as Patient_Doc;
                if (doc != null)
                {
                    if (docStr == "")
                    {
                        docStr = doc.Textkind_id.ToString();
                    }
                    else
                    {
                        docStr += "," + doc.Textkind_id;
                    }
                }
            }
            Node tn_doctor = new Node();
            Node tn_nurse = new Node();

            tn_doctor.Text = "医生文书";
            tn_nurse.Text = "护士文书";
            tn_doctor.Image = global::Base_Function.Resource.住院记录;
            tn_nurse.Image = global::Base_Function.Resource.住院记录;

            if (docStr != "")
            {
                //医生文书
                DataInit.getDoctorFinishedText(ref tn_doctor, docStr);
            }

            //护士
            DataInit.getNurseText(ref tn_nurse);

            advFinishDoc.Nodes.Add(tn_doctor);
            advFinishDoc.Nodes.Add(tn_nurse);


            foreach (Node pNode in node.Nodes)
            {
                GetPatientDoc(advFinishDoc.Nodes, pNode);
            }
        }
        /// <summary>
        /// 把文书内容节点插入到具体的文书下
        /// </summary>
        /// <param name="nodes">文书类别</param>
        /// <param name="node">文书内容</param>
        public void GetPatientDoc(NodeCollection nodes, Node node)
        {
            DevComponents.DotNetBar.ElementStyle elementStyleBlue = new ElementStyle();
            elementStyleBlue.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            elementStyleBlue.Description = "Blue";
            elementStyleBlue.Name = "elementStyleBlue";
            elementStyleBlue.TextColor = System.Drawing.Color.Blue;

            DevComponents.DotNetBar.ElementStyle elementStyleRed = new ElementStyle();
            elementStyleRed.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            elementStyleRed.Description = "Red";
            elementStyleRed.Name = "elementStyleRed";
            elementStyleRed.TextColor = System.Drawing.Color.Red;

            DevComponents.DotNetBar.ElementStyle elementStyleOrange = new ElementStyle();
            elementStyleOrange.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            elementStyleOrange.Description = "Orange";
            elementStyleOrange.Name = "elementStyleOrange";
            elementStyleOrange.TextColor = System.Drawing.Color.Orange;

            Patient_Doc doc = node.Tag as Patient_Doc;
            if (doc != null)
            {
                //代主治查房显示*号
                if (doc.Textkind_id == 126 && doc.Isreplacehighdoctor == "Y")
                {
                    node.Text = "*" + doc.Docname;
                }
                //代主任查房显示△
                if (doc.Textkind_id == 126 && doc.Isreplacehighdoctor2 == "Y")
                {
                    node.Text = "△" + doc.Docname;
                }
            }

            foreach (Node TempNode in nodes)
            {
                Class_Text text = TempNode.Tag as Class_Text;
                if (text != null)
                {
                    if (text.Issimpleinstance == "1")   //多例文书
                    {

                        if (doc.Textkind_id == text.Id) //如果当前文书和树节点的文书id相同，就把该文书添加树节点的下面
                        {

                            if (doc.Submitted == "N")//暂存显示为蓝色
                            {
                                node.Style = elementStyleBlue;
                                node.Text += "(暂存)";
                            }
                            else if (doc.Havedoctorsign == "N" && doc.Havehighersign == "N")//N表示经治医师未签字的文书，显示为红色
                            {
                                node.Style = elementStyleRed;
                                node.Text += "(缺经治医师签名)";
                            }
                            else if (doc.Ishighersign == "Y")//是否需要上级医师签字，Y表示需要
                            {
                                if (doc.Havehighersign == "N")//上级医师是否已签字，N代表没签
                                {
                                    node.Style = elementStyleOrange;
                                    node.Text += "(缺上级医师签名)";
                                }
                            }
                            TempNode.Nodes.Add((Node)node.DeepCopy());
                            break;
                        }
                    }
                    else
                    {
                        if (TempNode.Nodes.Count == 0)
                        {
                            if (doc.Textkind_id == text.Id)   //如果当前文书和树节点的文书id相同,说明该单实例文书已经有内容了，颜色则变为蓝色
                            {
                                //TempNode.SelectedImageIndex = 16;
                                TempNode.ImageIndex = 16;
                                if (doc.Submitted == "N")//暂存显示为蓝色
                                {
                                    TempNode.Style = elementStyleBlue;
                                    TempNode.Text += "(暂存)";
                                }
                                else if (doc.Havedoctorsign == "N" && doc.Havehighersign == "N")//N表示经治医师未签字的文书，显示为红色
                                {
                                    TempNode.Style = elementStyleRed;
                                    TempNode.Text += "(缺经治医师签名)";
                                }
                                else if (doc.Ishighersign == "Y")//是否需要上级医师签字，Y表示需要
                                {
                                    if (doc.Havehighersign == "N")//上级医师是否已签字，N代表没签
                                    {
                                        TempNode.Style = elementStyleOrange;
                                        TempNode.Text += "(缺上级医师签名)";
                                    }
                                }
                                break;
                            }
                        }
                    }
                }
                if (TempNode.Nodes.Count > 0)
                {
                    GetPatientDoc(TempNode.Nodes, node);
                }
            }
        }
        /// <summary>
        /// 隐藏没有文书类型
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="node"></param>
        public void RemoveBookNode(NodeCollection nodes)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                Node TempNode = nodes[i];
                Class_Text text = TempNode.Tag as Class_Text;
                if (TempNode.Name != "396")
                {
                    if (text != null)
                    {
                        if (text.Issimpleinstance == "1")   //多例文书
                        {
                            if (TempNode.Nodes.Count == 0)
                            {
                                TempNode.Remove();
                                i--;
                            }
                        }
                        else
                        {
                            if (TempNode.Nodes.Count == 0)
                            {
                                if (TempNode.ImageIndex == 17)   //如果当前文书和树节点的文书id相同,说明该单实例文书已经有内容了，颜色则变为蓝色
                                {

                                    TempNode.Remove();
                                    i--;
                                }
                            }
                        }
                    }
                }
                if (TempNode.Nodes.Count > 0)
                    RemoveBookNode(TempNode.Nodes);
            }
        }

        /// <summary>
        /// 当前选中的节点，是否再tctlDoc.Tabs集合里面已经存在，存在true,否则false
        /// </summary>
        /// <param name="tid">文书的id</param>
        /// <returns></returns>
        private bool IsSameTabItem(string tid, string cTime)
        {
            bool flag = false;
            for (int i = 0; i < tctlDoc.Tabs.Count; i++)
            {
                InPatientInfo inpatient = tctlDoc.Tabs[i].Tag as InPatientInfo;
                if (inpatient != null)
                {
                    if (currentPatient.Sick_Bed_Id == inpatient.Sick_Bed_Id)
                    {
                        string tabtid = "";
                        if (tctlDoc.Tabs[i].Name.Split(';').Length >= 4 && !tctlDoc.Tabs[i].Name.Contains("Class_Text"))
                        {
                            tabtid = tctlDoc.Tabs[i].Name.Split(';')[2];
                        }
                        else
                        {
                            tabtid = tctlDoc.Tabs[i].Name.Split(';')[0];
                        }
                        if (tabtid.Equals(tid))
                        {
                            if (tctlDoc.Tabs[i].Name.Split(';').Length <= 4
                                || (tctlDoc.Tabs[i].Name.Split(';').Length > 4 && tctlDoc.Tabs[i].Name.Split(';')[4] == cTime))
                            {
                                flag = true;
                                tctlDoc.SelectedTab = tctlDoc.Tabs[i];
                                App.Msg("已经存在相同的文书！");
                                break;
                            }
                        }
                    }
                }
            }
            return flag;
        }


        //浏览页面的修改文书
        void MyDoc_OnBackTextId(object sender, BackEvenHandle e)
        {
            if (e.Style == 1)
            {
                if (e.Submit)
                {
                    //文书提交成功后，修改当前打开的文书tab.Name属性中的值
                    if (e.Para != "0")
                    {
                        App.SetToolButtonByUser("tsbtnTempSave", false);
                    }
                    string tabName = "";
                    for (int i = 0; i < tctlDoc.SelectedTab.Name.Split(';').Length; i++)
                    {
                        if (tabName == "")
                        {
                            tabName = tctlDoc.SelectedTab.Name.Split(';')[i];
                        }
                        else
                        {
                            if (i == 2)//第三位是文书的ID，0表示新建，改成当前的文书id
                            {
                                tabName += ";" + e.Para;
                            }
                            else
                            {
                                tabName += ";" + tctlDoc.SelectedTab.Name.Split(';')[i];
                            }
                        }
                    }
                    tctlDoc.SelectedTab.Name = tabName;
                    book_Id = e.Para;
                    if (e.User.TextKind_id == 119 ||    //入院记录
                        e.User.TextKind_id == 120 ||    //24小时内入出院记录
                        e.User.TextKind_id == 121 ||    //24小时内入院死亡记录
                        e.User.TextKind_id == 122 ||    //再次（多次）入院记录
                        e.User.TextKind_id == 123)      //其他专科入院记录
                    { }
                    //SubmitDoc(e.XmlString);
                }
            }
            else if (e.Style == 4)
            {
                DataInit.MyDocStye = true;
                DataInit.saveDocument(sender, e);
                DataInit.MyDocStye = false;
            }
            else if (e.Style == 5)
            {
                if (App.UserAccount.CurrentSelectRole.Role_type != "D")     //医生站
                {
                    App.Msg("提示: 只有医生才能修改!");
                    return;
                }
                if (BrowseNodes.Nodes.Count > 0)
                {
                    for (int i = 0; i < BrowseNodes.Nodes.Count; i++)
                    {
                        //if (BrowseNodes.Nodes[i].Name == e.Para)
                        //{
                        //    advFinishDoc.SelectedNode = BrowseNodes.Nodes[i];
                        //}
                        Node tempnode = GetSelectDocNode(BrowseNodes.Nodes, e.Para);

                        if (tempnode != null)
                        {
                            advFinishDoc.SelectedNode = tempnode;
                        }
                        else
                        {
                            //CurrentNode = NowTree.SelectedNode;
                            //SetSelectNode(BrowseNodes.Nodes, e.Para);
                        }

                    }
                }
                else
                {
                    if (BrowseNodes.Name == e.Para)
                    {
                        advFinishDoc.SelectedNode = BrowseNodes;
                    }
                }
                CreateTabItem(Convert.ToInt32(e.Para));
                ClickShow = false;
            }
            else
            {
                bool flag = false;  //当前帐号对该份文书是否有书写的权限
                Class_Text text = advFinishDoc.SelectedNode.Tag as Class_Text;
                ArrayList list = App.Get_Text_Button_Rights(text.Id, currentPatient.Sick_Group_Id, Convert.ToInt32(currentPatient.Sick_Doctor_Id));
                for (int i = 0; i < list.Count; i++)
                {
                    string Button_Write = list[i] as string;
                    //App.Text_Rights_Set(Convert.ToInt32(e.Para),Convert.ToInt32(currentPatient.Sick_Doctor_Id),currentPatient.Sick_Group_Id);
                    if (Button_Write == "tsbtnWrite")    //判断该登录帐号是否有创建该份文书的权限
                    {
                        //创建文书
                        Rethreee_CreateTab(e.Para);
                        flag = true;
                        break;
                    }
                }
                Update_Tid = e.Para;
                if (!flag)
                    App.Msg("您还没有书写该份文书的权限！");
            }
        }

        private void tlspmnitBrowse_Click(object sender, EventArgs e)
        {
            /*
             * 浏览实现思路：
             * 1.查出当前节点下所有节点的文书内容对应的xml代码
             * 2.拼接查出每份xml文件的body下面的xml代码，并生成新的xml
             * 3.读出新的xml文本，设置只读。
             */
            try
            {
                //barTemplate.Visible = false;
                string result = null;
                string tid = "";
                string account_Type = App.UserAccount.CurrentSelectRole.Role_type;
                if (NowTree.SelectedNode != null)
                {
                    tid = NowTree.SelectedNode.Name;
                    string textTitle = GetTextTitle(NowTree.SelectedNode);
                    if (IsSameTabItem(NowTree.SelectedNode.Name, App.GetSystemTime().ToString("yyyy-MM-dd HH:mm")))
                        return;
                    bool isExist = false; //是否只有定制文书
                    if (NowTree.SelectedNode.Nodes.Count > 0)
                    {
                        foreach (Node node in NowTree.SelectedNode.Nodes)
                        {
                            if (account_Type == "N")
                            {
                                //定制文书
                                isExist = CreateNewPage(null, node); //list
                            }
                            else
                            {
                                isExist = CreateNewPageByDoctor(null, node);//list
                            }
                        }
                    }
                    else
                    {
                        if (account_Type == "N")
                        {
                            //定制文书
                            isExist = CreateNewPage(null, NowTree.SelectedNode);
                        }
                        else
                        {
                            isExist = CreateNewPageByDoctor(null, NowTree.SelectedNode);
                        }
                    }
                    if (isExist)
                    {
                        result = "S";
                        return;
                    }
                    #region 普通文书浏览
                    //string[,] Contents = GetContentByType(trvBookOprate.SelectedNode);

                    Patient_Doc[] patient_Docs = GetContentByType(NowTree.SelectedNode); //此代码暂时不用

                    //记录浏览的节点
                    if (NowTree.SelectedNode.Tag.GetType().ToString().Contains("Class_Text"))
                    {
                        BrowseNodes = NowTree.SelectedNode;
                    }
                    else if (NowTree.SelectedNode.Tag.GetType().ToString().Contains("Patient_Doc"))
                    {
                        BrowseNodes = NowTree.SelectedNode;
                    }


                    if (patient_Docs != null)
                    {

                        //else if (doc.Havedoctorsign == "N")//N表示管床医生未签字的文书，显示为红色
                        //        {
                        //            node.Style = elementStyleRed;
                        //            node.Text += "(缺管床医生签名)";
                        //        }
                        //        else if (doc.Ishighersign == "Y")//是否需要上级医师签字，Y表示需要
                        //        {
                        //            if (doc.Havehighersign == "N")//上级医师是否已签字，N代表没签
                        //            {
                        //                node.Style = elementStyleOrange;
                        //                node.Text += "(缺上级医师签名)";
                        //            }
                        //        }

                        ////暂存文书只能由本人操作
                        //Patient_Doc doc = patient_Docs[0];
                        //if (doc.Submitted == "N" && doc.Createid != App.UserAccount.UserInfo.User_id)
                        //{
                        //    App.Msg("该文书是暂存文书，只能由本人浏览！");
                        //    return;
                        //}
                        DevComponents.DotNetBar.TabControlPanel tabctpnDoc = new DevComponents.DotNetBar.TabControlPanel();
                        tabctpnDoc.AutoScroll = true;
                        DevComponents.DotNetBar.TabItem pageDoc = new DevComponents.DotNetBar.TabItem();



                        pageDoc.Name = NowTree.SelectedNode.Name;
                        pageDoc.Text = NowTree.SelectedNode.Text + " 浏览";
                        pageDoc.Click += new EventHandler(page_Click);
                        InPatientInfo tempInpatinet = null;
                        tempInpatinet = currentPatient;
                        pageDoc.Tag = tempInpatinet as object;
                        InPatientInfo inpat = pageDoc.Tag as InPatientInfo;

                        frmText ucText = new frmText(patient_Docs[0].Textkind_id, patient_Docs[0].Belongtosys_id, patient_Docs[0].Sickkind_id, textTitle, patient_Docs[0].Id, inpat, true);
                        ucText.MyDoc.OnBackTextId += new EventHandler<BackEvenHandle>(MyDoc_OnBackTextId);
                        if (patient_Docs != null)
                        {
                            bool flag = isSurgeryLater(NowTree.Nodes);
                            switch (flag)
                            {
                                case false:
                                    SpiltXml(patient_Docs, ucText, false);
                                    break;
                                case true:
                                    SpiltXml(patient_Docs, ucText, true);
                                    break;
                                default:
                                    break;

                            }
                            XmlDocument tempxmldoc = new XmlDocument();
                            tempxmldoc = DataInit.XmlDoc(tempxmldoc, inpat, ucText);
                            ucText.MyDoc.FromXML(tempxmldoc.DocumentElement);
                            tabctpnDoc.Controls.Add(ucText);
                            App.UsControlStyle(ucText);
                            tabctpnDoc.TabItem = pageDoc;
                            tabctpnDoc.Dock = DockStyle.Fill;
                            ucText.Dock = DockStyle.Fill;
                            pageDoc.AttachedControl = tabctpnDoc;
                            this.tctlDoc.Controls.Add(tabctpnDoc);
                            this.tctlDoc.Tabs.Add(pageDoc);
                            this.tctlDoc.Refresh();
                            this.tctlDoc.SelectedTab = pageDoc;
                            result = "S";
                            ClickShow = true;
                            ucText.MyDoc.Locked = true;

                        }
                        else
                        {
                            App.Msg("该节点暂时没有文书！");
                        }
                    }
                    else
                    {
                        App.Msg("该节点暂时没有文书！");
                    }
                }
                else
                {
                    App.Msg("没有选中节点！");
                }
                int patient_Id = currentPatient.Id;
                //记录系统操作日志,
                //LogHelper.SystemLog("", result, "文书浏览", tid, currentPatient.PId, patient_Id);
                //App.SetToolButtonByUser("tsbtnCommit", false);
                //if (account_Type == "N")
                //{
                //    App.SetToolButtonByUser("tsbtnTemplate", false);
                //    App.SetToolButtonByUser("tsbtnTemplateSave", false);
                //    App.SetToolButtonByUser("ttsbtnPrint", false);
                //    App.SetToolButtonByUser("tsbtnTempSave", false);
                //}
                //App.Get_Text_Buttns_Set_rights(Convert.ToInt32(currentPatient.Sick_Doctor_Id), Convert.ToInt32(currentPatient.Sick_Doctor_Id), NowTree.SelectedNode, currentPatient, 1);                     
                // barTemplate.Hide();
                    #endregion
            }
            catch
            {
                App.MsgErr("该节点并不是有效的文书浏览节点！");
            }
        }
        /// <summary>
        /// 术后病程记录是否有子节点
        /// </summary>
        bool isChildNode = false;

        /// <summary>
        /// 判断术后首次病程记录是否有子节点
        /// </summary>
        /// <param name="nodes">文书树集合</param>
        /// <returns>true 有子节点,false 没有子节点</returns>
        private bool isSurgeryLater(NodeCollection nodes)
        {
            foreach (Node node in nodes)
            {
                if (node.Name == "136") //术后首次病程记录
                {
                    if (node.Nodes.Count > 0)
                        isChildNode = true;
                    break;
                }
                if (node.Nodes.Count > 0)
                    isSurgeryLater(node.Nodes);
            }
            return isChildNode;
        }

        /// <summary>
        /// 设置标题，住院病程记录的文书id=103,
        /// 下面所有文书标题为病程记录;
        /// 其他的文书的标题，则根据文书名称来显示
        /// </summary>
        /// <param name="node">当前节点</param>
        /// <returns></returns>
        private string GetTextTitle(Node node)
        {
            string textTitle = "";
            try
            {
                if (node != null)
                {
                    textTitle = node.Text;
                }
                if (node.Parent != null)
                {
                    if (node.Parent.Parent != null)
                    {
                        if ((node.Parent.Name == "103") || node.Name == "103"  //住院病程记录文书id
                            || (node.Parent.Parent != null && node.Parent.Parent.Name == "103"))
                        {
                            if (node.Parent.Name == "134" || node.Name == "134" ||
                               node.Parent.Parent.Name == "134")  //术前小结
                            {
                                textTitle = "手术前小结";
                            }
                            else if (node.Name == "125")
                            {
                                textTitle = "病程记录";
                            }
                            else
                            {
                                textTitle = "病程记录";
                            }
                        }
                        else
                        {
                            if (node.Tag.GetType().Name.Contains("Patient_Doc"))
                            {
                                textTitle = node.Parent.Text;
                            }
                            else
                            {
                                textTitle = node.Text;
                            }
                            //textTitle = node.Text;
                        }
                        return textTitle;
                    }
                    else
                    {
                        if (node.Parent.Name == "103" || (node.Name == "103" && node.Text == "住院病程记录"))
                        {
                            if (node.Parent.Name == "134" || node.Name == "134")//术前小结
                            {
                                textTitle = "手术前小结";
                            }
                            else if (node.Name == "125")
                            {
                                textTitle = "病程记录";
                            }
                            else
                            {
                                textTitle = "病程记录";
                            }
                        }
                        else
                        {
                            if (node.Tag.GetType().Name.Contains("Patient_Doc"))
                            {
                                textTitle = node.Parent.Text;
                            }
                            else
                            {
                                textTitle = node.Text;
                            }
                        }
                        return textTitle;
                    }
                }
                else
                {
                    Class_Text text = node.Tag as Class_Text;
                    if (text != null)
                    {
                        if (text.Parentid.ToString() == "103" || text.Id.ToString() == "103")
                        {
                            if (text.Id.ToString() == "125" || text.Id.ToString() == "103")
                            {
                                textTitle = "病程记录";
                            }
                            else
                            {
                                textTitle = "病程记录";
                            }
                        }
                        else
                        {
                            textTitle = node.Text;
                        }
                        if (text.Issimpleinstance == "0")
                        {

                            if (node.Text.Contains("(缺管床医生签名)"))
                            {
                                textTitle = textTitle.Replace("(缺管床医生签名)", "");
                            }
                            else if (node.Text.Contains("(缺上级医师签名)"))
                            {
                                textTitle = textTitle.Replace("(缺上级医师签名)", "");
                            }
                        }
                    }
                }


            }
            catch (Exception)
            {
            }
            return textTitle;
        }

        /// <summary>
        /// 拼接xml文件
        /// </summary>
        /// <param name="Contents">xml内容</param>
        /// <param name="ucText">编辑器</param>
        /// <param name="flag">术后首次病程记录是否有子节点文书</param>
        private void SpiltXml(Patient_Doc[] patient_Docs, frmText ucText, bool flag)
        {
            try
            {
                XmlDocument TempXml = new XmlDocument();
                TempXml.PreserveWhitespace = true;
                StringBuilder strBuilder = new StringBuilder();

                string sickarea = "";
                string section = "";
                string bed = "";

                #region 术后病程记录没有子节点拼接xml

                for (int i = 0; i < patient_Docs.Length; i++)
                {
                    if (patient_Docs[i] == null)
                        continue;
                    XmlDocument ChildXml = new XmlDocument();
                    ChildXml.PreserveWhitespace = true;
                    ChildXml.LoadXml(patient_Docs[i].Patients_doc);
                    if (patient_Docs[i].Isnewpage == "Y")
                    {
                        //表示配置中需要进行分页
                        strBuilder.Append(@"<Skip operatercreater='0' />");//<p operatercreater='0' />
                    }

                    sickarea = App.ReadSqlVal("select sick_area_name from T_PATIENTS_DOC where TID=" + patient_Docs[i].Id + "", 0, "sick_area_name");

                    strBuilder.Append(ChildXml.GetElementsByTagName("body")[0].InnerXml);//文书内容
                    strBuilder.Append(@"<split textId='" + patient_Docs[i].Id + "' section_name = '" + patient_Docs[i].Section_name +
                        "' bed_no='" + patient_Docs[i].Bed + "' sick_area='" + sickarea + "'/>");


                }

                #endregion

                XmlDocument tempxmldoc = new XmlDocument();
                tempxmldoc.PreserveWhitespace = true;
                tempxmldoc.LoadXml("<emrtextdoc/>");
                ucText.MyDoc.ToXML(tempxmldoc.DocumentElement);

                XmlNode xmlNode = tempxmldoc.SelectSingleNode("emrtextdoc");//查找<body>
                string ss = strBuilder.ToString();
                foreach (XmlNode bodyNode in xmlNode.ChildNodes)
                {
                    if (bodyNode.Name == "body")
                    {
                        bodyNode.InnerXml = strBuilder.ToString();
                    }
                }

                //DataInit.setXmlHead(tempxmldoc.DocumentElement, sickarea,);

                ucText.MyDoc.FromXML(tempxmldoc.DocumentElement);




                //'电脑血糖监测记录单','PICC护理记录单','产科(新生儿)护理记录单',新生儿经皮胆红素观察表',
                //'缩宫素滴注观察记录单'
                if (patient_Docs.Length > 0)
                {
                    if (patient_Docs[0].Textkind_id == 2172 || patient_Docs[0].Textkind_id == 2173 ||
                        patient_Docs[0].Textkind_id == 2175 || patient_Docs[0].Textkind_id == 2178
                        || patient_Docs[0].Textkind_id == 2179)
                    {
                        ucText.MyDoc.PageStartIndex = NowTree.SelectedNode.Index;
                    }
                }
                ucText.MyDoc.ContentChanged();
                ucText.Dock = DockStyle.Fill;

                ucText.MyDoc.Locked = true;
            }
            catch (Exception ex)
            {
                App.MsgErr("文书读取失败！原因:" + ex.Message);
            }
        }
        /// <summary>
        /// 保存提交过的文书id
        /// </summary>
        private ArrayList save_TextId = new ArrayList();
        /// <summary>
        /// 判断文书是否提交过
        /// </summary>
        /// <param name="textName">文书的id</param>
        /// <returns>true提交,false未提交</returns>
        private bool IsCommit(string textName)
        {
            bool isCommit = false;
            for (int i = 0; i < save_TextId.Count; i++)
            {
                if (textName == save_TextId[i].ToString())
                {
                    isCommit = true;
                    save_TextId.RemoveAt(i);
                    break;
                }
            }
            return isCommit;
        }

        void page_Click(object sender, EventArgs e)
        {

            try
            {
                if (tctlDoc.Tabs.Count > 0)
                {
                    tctlDoc.AutoCloseTabs = false;
                    TabItem item = (TabItem)sender;
                    //Point mp = Cursor.Position;
                    MouseEventArgs mp = (MouseEventArgs)e;
                    Point pTab = item.CloseButtonBounds.Location;
                    if (mp.X >= pTab.X && mp.X <= pTab.X + item.CloseButtonBounds.Width && mp.Y >= pTab.Y &&
                        mp.Y <= pTab.Y + item.CloseButtonBounds.Height)
                    {
                        if (!item.Text.Contains("浏览"))
                        {
                            if (!IsCommit(item.Name))
                            {
                                //验证是否定制文书
                                string doc_id = item.Name.Split(';')[0].ToString();
                                string sql = "select isenable from t_text where id=" + doc_id;
                                string isenable = App.ReadSqlVal(sql, 0, "isenable");
                                if (isenable == "1")
                                {
                                    isCustom = true;
                                }
                                else
                                {
                                    isCustom = false;
                                }
                                if (!isCustom) //不是定制的文书
                                {
                                    DevComponents.DotNetBar.TabControlPanel tab = tctlDoc.Controls[0] as DevComponents.DotNetBar.TabControlPanel;
                                    frmText t = tab.Controls[0] as frmText;

                                    if (t != null)
                                    {
                                        if (t.MyDoc.Modified) //修改过文书，显示提示
                                        {


                                            if (App.Ask("该份文书没有提交，是否关闭？"))
                                            {
                                                //tctlDoc.AutoCloseTabs = true;
                                                //关闭文书，禁用下列按钮 ,
                                                //Remove操作会触发SelectedChecked事件，设置对选中文书的操作权限,在Remove之前执行按钮禁用操作
                                                //App.SetToolButtonByUser("tsbtnSmallTemplateSave", false);
                                                //App.SetToolButtonByUser("ttsbtnPrint", false);
                                                //App.SetToolButtonByUser("tsbtnTempSave", false);
                                                //App.SetToolButtonByUser("tsbtnCommit", false);
                                                tctlDoc.Tabs.Remove(item);
                                            }
                                        }
                                        else
                                        {
                                            tctlDoc.Tabs.Remove(item);
                                            if (tctlDoc.Tabs.Count == 0)
                                            {
                                                App.SetToolButtonByUser("ttsbtnPrint", false);//
                                                App.SetToolButtonByUser("ttsbtnPrintContinue", false);
                                                App.SetToolButtonByUser("tsbtnTempSave", false);
                                                App.SetToolButtonByUser("tsbtnCommit", false);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        tctlDoc.Tabs.Remove(item);
                                    }
                                }
                                else
                                {
                                    tctlDoc.Tabs.Remove(item);
                                }
                            }
                            else
                            {
                                tctlDoc.Tabs.Remove(item);
                                if (tctlDoc.Tabs.Count == 0)
                                {
                                    //App.SetToolButtonByUser("tsbtnSmallTemplateSave", false);
                                    App.SetToolButtonByUser("ttsbtnPrint", false);
                                    App.SetToolButtonByUser("ttsbtnPrintContinue", false);
                                    App.SetToolButtonByUser("tsbtnTempSave", false);
                                    App.SetToolButtonByUser("tsbtnCommit", false);
                                    App.SetToolButtonByUser("tsbtnTemplateSave", false);//保存模版
                                }
                            }
                        }
                        else
                        {
                            //关闭文书，禁用下列按钮 ,
                            //Remove操作会触发SelectedChecked事件，设置对选中文书的操作权限,在Remove之前执行按钮禁用操作
                            //App.SetToolButtonByUser("tsbtnSmallTemplateSave", false);
                            App.SetToolButtonByUser("ttsbtnPrint", false);
                            App.SetToolButtonByUser("ttsbtnPrintContinue", false);
                            App.SetToolButtonByUser("tsbtnTempSave", false);
                            App.SetToolButtonByUser("tsbtnCommit", false);
                            tctlDoc.Tabs.Remove(item);
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        /// <summary>
        /// 创建定制文书
        /// </summary>
        /// <param name="node">当前文书树选中的节点</param>
        /// <param name="tctldoc">tabcontrol</param>
        /// <param name="currentPatient">当前病人</param>
        private bool create_Nurse_Book(Node node, DevComponents.DotNetBar.TabControl tctlDoc, InPatientInfo currentPatient)
        {
            bool isExcute = true;
            //barTemplate.Hide();
            DevComponents.DotNetBar.TabControlPanel tabctpnDoc = new DevComponents.DotNetBar.TabControlPanel();
            tabctpnDoc.AutoScroll = true;
            DevComponents.DotNetBar.TabItem page = new DevComponents.DotNetBar.TabItem();

            page.Click += new EventHandler(page_Click);

            page.Name = node.Name;
            page.Text = node.Text + " " + " (" + currentPatient.Sick_Bed_Name + " 床)";
            page.Tag = DataInit.GetInpatientInfoByPid(currentPatient.Id.ToString()) as object;
            //InPatientInfo inpatient = currentPatient;

            if (node.Tag != null)
            {
                //Class_Text ctext = (Class_Text)node.Tag;
                Class_Text ctext = node.Tag as Class_Text;
                if (ctext == null || ctext.Isenable == "0")
                {
                    isExcute = false;
                }
                else if (node.Tag.ToString().Contains("Class_Text"))
                {

                    if (ctext.Formname.ToLower() == "ucblood_sugar_record")
                    {
                        //血糖检测单
                        InPatientInfo inpatient = page.Tag as InPatientInfo;
                        ucBlood_Sugar_Record unBlood = new ucBlood_Sugar_Record(inpatient.Sick_Bed_Name,
                                                          inpatient.Patient_Name, inpatient.PId, inpatient.Id.ToString());
                        tabctpnDoc.Controls.Add(unBlood);
                        unBlood.Dock = DockStyle.Fill;
                        App.UsControlStyle(unBlood);
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "ucpartogram")
                    {
                        //产程图
                        InPatientInfo inpatient = page.Tag as InPatientInfo;
                        page.Tooltip = "N";
                        ucPartogram ucBirthPic = new ucPartogram();

                        string sql_Partogram = "select * from T_PARTOGRAM t where t.patient_id=" + inpatient.Id + "";
                        DataSet ds_Partogram = App.GetDataSet(sql_Partogram);
                        if (ds_Partogram.Tables[0].Rows.Count > 0)
                        {
                            ucBirthPic.FromXml(ds_Partogram.Tables[0].Rows[0]["content"].ToString());
                        }
                        ucBirthPic.UserInfo.PatientInfo = inpatient;
                        ucBirthPic.UserInfo.Xingming = inpatient.Patient_Name;
                        ucBirthPic.UserInfo.Nianling = inpatient.Age;
                        ucBirthPic.UserInfo.Bingshi = inpatient.Sick_Area_Name;
                        ucBirthPic.UserInfo.Zhuyuanhao = inpatient.PId;
                        ucBirthPic.UserInfo.Chuanghao = inpatient.Sick_Bed_Name;
                        ucBirthPic.UserInfo.Tid = Convert.ToInt32(node.Name);
                        ucBirthPic.UserInfo.RefreshUserInfo();

                        if (App.UserAccount.CurrentSelectRole.Role_type == "N")
                        {
                            /*
                             * 护士操作
                             */
                            tabctpnDoc.Controls.Add(ucBirthPic);
                            ucBirthPic.Dock = DockStyle.Fill;
                            //App.UsControlStyle(ucBirthPic);
                            tabctpnDoc.AutoScroll = true;
                            isCustom = true;

                        }
                        else
                        {
                            /*
                                              * 医生站
                                              */
                            ucBirthPic.OnlyLook = true;
                            tabctpnDoc.Controls.Add(ucBirthPic);
                            ucBirthPic.Dock = DockStyle.Fill;
                            //App.UsControlStyle(ucBirthPic);
                            tabctpnDoc.AutoScroll = true;
                            isCustom = true;
                        }
                    }
                    else if (ctext.Formname.ToLower() == "muctoolscontrol")
                    {
                        string section_id_test = App.UserAccount.CurrentSelectRole.Sickarea_Id;
                        InPatientInfo inpatient = page.Tag as InPatientInfo;
                        if (string.IsNullOrEmpty(section_id_test))
                        {
                            if (inpatient != null)
                            {
                                section_id_test = inpatient.Sike_Area_Id.ToString();
                            }
                            else
                            {
                                section_id_test = "0";
                            }
                        }
                        //MUcToolsControl ucNurseRecord = new MUcToolsControl(inpatient, Convert.ToInt32(section_id_test), Convert.ToInt32(node.Name));
                        MUcToolsControl ucNurseRecord = null;
                        if (currentPatient.Section_Name.Contains("儿科") || currentPatient.Section_Name.Contains("心内二"))
                        {
                            ucNurseRecord = new MUcToolsControl(currentPatient, currentPatient.Section_Id, Convert.ToInt32(node.Name), true);
                            //ucNurseRecord.MyDocument.YzSql = "select distinct order_text, to_char(start_date_time),administration from ORDER_VIEW@dbhislink e where to_char(e.start_date_time,'yyyy-MM-dd') = '{0}' and his_id='{1}' and order_class='A'"; 
                        }
                        else
                        {
                            ucNurseRecord = new MUcToolsControl(currentPatient, currentPatient.Section_Id, Convert.ToInt32(node.Name));
                            //ucNurseRecord.MyDocument.YzSql = "select distinct order_text, to_char(start_date_time),administration from ORDER_VIEW@dbhislink e where to_char(e.start_date_time,'yyyy-MM-dd') = '{0}' and his_id='{1}' and order_class='A'"; 
                        }
                        /*
                         * 护士操作
                         */
                        tabctpnDoc.Controls.Add(ucNurseRecord);
                        ucNurseRecord.Dock = DockStyle.Fill;
                        App.UsControlStyle(ucNurseRecord);
                        string open_num = "";
                        string open_name = "";
                        string ip = "";
                        bool islock = GetLockState(currentPatient.Id, out open_num, out open_name, out ip);
                        if (App.UserAccount.CurrentSelectRole.Role_type != "N" || islock)//|| islock
                        {
                            ucNurseRecord.MyDocument.ClearTempInput();
                            ucNurseRecord.SetToolsEnable(false);
                            if (islock)
                            {
                                page.Text += "锁定" + "工号：" + open_num + "姓名：" + open_name + "已经打开";
                                App.MsgWaring("该份护理记录单已有老师打开，同一个病人同时只能单个用户操作！");
                            }
                        }
                        tabctpnDoc.AutoScroll = true;
                        isCustom = true;
                        if (!islock && App.UserAccount.CurrentSelectRole.Role_type == "N")//没锁定之前
                        {
                            //IsLockBook("t_care_doc", inpatient.Id, "1", App.UserAccount.UserInfo.User_id);
                        }
                    }
                    else if (ctext.Formname.ToLower() == "uctempraute")
                    {
                        //体温单
                        //string medicare_no = currentPatient.Medicare_no;
                        //string id = currentPatient.Id.ToString();
                        //string bed_no = currentPatient.Sick_Bed_Name;
                        //string Pname = currentPatient.Patient_Name;
                        //string sex = currentPatient.Gender_Code;
                        //string age = "";
                        //if (currentPatient.Age != null && currentPatient.Age.ToString() != "" && currentPatient.Age.ToString() != "0")
                        //    age = currentPatient.Age + currentPatient.Age_unit;
                        //else
                        //    age = currentPatient.Child_age;
                        //string section = currentPatient.Section_Name;
                        //string area_Name = currentPatient.Sick_Area_Name;
                        //string in_Time = currentPatient.In_Time.ToString("yyyy-MM-dd HH:mm");

                        //InPatientInfo inpatient = page.Tag as InPatientInfo;
                        if (App.UserAccount.CurrentSelectRole.Role_type == "N")
                        {
                            //ucTempraute temper = new ucTempraute(currentPatient);//inpatient.PId, medicare_no, id, bed_no, Pname, sex, age, section, area_Name, in_Time);
                            TempertureEditor.ucTempraute temper = new TempertureEditor.ucTempraute(currentPatient, TempertureEditor.Tempreture_Management.tempetureDataComm.TEMPLATE_NORMAL, true);
                            temper.Dock = DockStyle.Fill;
                            tabctpnDoc.Controls.Add(temper);
                            App.UsControlStyle(temper);
                        }
                        else
                        {
                            TempertureEditor.ucTempraute uctemperPrint = new TempertureEditor.ucTempraute(currentPatient, TempertureEditor.Tempreture_Management.tempetureDataComm.TEMPLATE_NORMAL, false);
                            App.UsControlStyle(uctemperPrint);
                            uctemperPrint.Dock = DockStyle.Fill;
                            tabctpnDoc.Controls.Add(uctemperPrint);
                            App.SetToolButtonByUser("tsbtnCommit", false);
                        }
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "uctempraute_bb")
                    {
                        //新生儿体温单
                        if (App.UserAccount.CurrentSelectRole.Role_type == "N")
                        {
                            TempertureEditor.ucTempraute temper = new TempertureEditor.ucTempraute(currentPatient, TempertureEditor.Tempreture_Management.tempetureDataComm.TEMPLATE_CHILD, true);
                            temper.Dock = DockStyle.Fill;
                            tabctpnDoc.Controls.Add(temper);
                            App.UsControlStyle(temper);
                        }
                        else
                        {
                            TempertureEditor.ucTempraute uctemperPrint = new TempertureEditor.ucTempraute(currentPatient, TempertureEditor.Tempreture_Management.tempetureDataComm.TEMPLATE_CHILD, false);
                            App.UsControlStyle(uctemperPrint);
                            uctemperPrint.Dock = DockStyle.Fill;
                            tabctpnDoc.Controls.Add(uctemperPrint);
                            App.SetToolButtonByUser("tsbtnCommit", false);
                        }
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "frmcases_first")
                    {
                        InPatientInfo inpatient = page.Tag as InPatientInfo;
                        page.Tooltip = "N";
                        //重新过去最新信息
                        string Sql_section_Patient = "select * from t_in_patient where id='" + inpatient.Id + "'";
                        DataSet ds = App.GetDataSet(Sql_section_Patient);
                        inpatient = DataInit.InitPatient(ds.Tables[0].Rows[0]);
                        frmCases_First ucCase_First = new frmCases_First(inpatient);

                        if (App.UserAccount.CurrentSelectRole.Role_type == "D" ||
                         App.UserAccount.CurrentSelectRole.Role_type == "N")
                        {
                            //frmCases_First ucCase_First = new frmCases_First(inpatient);
                            tabctpnDoc.Controls.Add(ucCase_First);
                            ucCase_First.Dock = DockStyle.Fill;
                        }
                        else
                        {

                            //xp没进入load事件
                            ucCase_First.InitPatientInfo();
                            // 获取病人信息
                            DataTable CoverInfo = ucCase_First.GetCoverInfo();
                            #region 病人信息的必填项检查
                            DataRow dr = CoverInfo.Rows[0];
                            #endregion

                            // 获取诊断信息
                            DataTable Diagnose = ucCase_First.GetCoverDiagnose();
                            #region 主要诊断必须填写入院病情和转归情况
                            dr = Diagnose.Rows[0];
                            #endregion


                            // 获取手术信息
                            DataTable Operation = ucCase_First.GetOperation();

                            // 获取病案质量信息
                            DataTable Quality = ucCase_First.GetQuality();

                            // 获取病案首页的一些杂项
                            DataTable Temp = ucCase_First.GetTemp();
                            dr = Temp.Rows[0];
                            #region 杂项表的必填项控制
                            #endregion

                            DataTable cost = ucCase_First.GetCost();

                            // 构造 DataSet
                            DataSet ds_case = new DataSet();
                            ds_case.Tables.Add(CoverInfo);
                            ds_case.Tables.Add(Diagnose);
                            ds_case.Tables.Add(Operation);
                            ds_case.Tables.Add(Quality);
                            ds_case.Tables.Add(Temp);
                            ds_case.Tables.Add(cost);

                            Ucprint ucprint = new Ucprint(ds_case, inpatient, node.Name, "");
                            ucprint.Dock = DockStyle.Fill;
                            App.UsControlStyle(ucprint);
                            tabctpnDoc.Controls.Add(ucprint);
                        }
                        App.SetToolButtonByUser("tsbtnCommit", false);
                        //App.UsControlStyle(ucCase_First);
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "ucfrmsickreport")
                    {
                        ucfrmSickReport ucsickReport = new ucfrmSickReport();
                        tabctpnDoc.Controls.Add(ucsickReport);
                        ucsickReport.Dock = DockStyle.Fill;
                        App.UsControlStyle(ucsickReport);
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "ucpatientinfo")
                    {
                        InPatientInfo inpatient = page.Tag as InPatientInfo;
                        page.Tooltip = "N";
                        if (App.UserAccount.CurrentSelectRole.Role_type == "D")
                        {
                            UcPatientInfo ucpatientInfo = new UcPatientInfo(inpatient);
                            tabctpnDoc.Controls.Add(ucpatientInfo);
                            ucpatientInfo.Dock = DockStyle.Fill;
                        }
                        else if (App.UserAccount.CurrentSelectRole.Role_type == "N")
                        {
                            UcPatientInfo ucpatientInfo = new UcPatientInfo(inpatient);
                            tabctpnDoc.Controls.Add(ucpatientInfo);
                            ucpatientInfo.Dock = DockStyle.Fill;
                        }
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "expectantrecord")
                    {
                        InPatientInfo inpatient = page.Tag as InPatientInfo;
                        page.Tooltip = "N";
                        string pid = inpatient.PId;
                        string area_Name = inpatient.Sick_Area_Name;
                        string bed_N0 = inpatient.Sick_Bed_Name;
                        string pName = inpatient.Patient_Name;
                        string id = inpatient.Id.ToString();
                        ExpectantRecord exRecord = new ExpectantRecord(pid, area_Name, bed_N0, pName, id);
                        tabctpnDoc.Controls.Add(exRecord);
                        exRecord.Dock = DockStyle.Fill;
                        App.UsControlStyle(exRecord);
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "ucdiagnosis_certificate")//诊断证明书
                    {
                        InPatientInfo inpatient = page.Tag as InPatientInfo;
                        ucDIAGNOSIS_CERTIFICATE ucprint = new ucDIAGNOSIS_CERTIFICATE(inpatient);
                        ucprint.Dock = DockStyle.Fill;
                        App.UsControlStyle(ucprint);
                        tabctpnDoc.Controls.Add(ucprint);
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "ucheart_pic")//心电示波记录单
                    {
                        InPatientInfo inpatient = page.Tag as InPatientInfo;
                        ucHeart_PIC ucHeart = new ucHeart_PIC(inpatient.Sick_Bed_Name, inpatient.Patient_Name, inpatient.PId, inpatient.Id.ToString(), inpatient.Section_Name);
                        ucHeart.Dock = DockStyle.Fill;
                        App.UsControlStyle(ucHeart);
                        tabctpnDoc.Controls.Add(ucHeart);
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "uodinopoeia_record")//中期妊娠引产产后病程记录881
                    {
                        InPatientInfo inpatient = page.Tag as InPatientInfo;
                        page.Tooltip = "N";
                        string pid = inpatient.PId;
                        string area_Name = inpatient.Sick_Area_Name;
                        string bed_N0 = inpatient.Sick_Bed_Name;
                        string pName = inpatient.Patient_Name;
                        string id = inpatient.Id.ToString();
                        UOdinopoeia_Record uo_record = new UOdinopoeia_Record(pid, area_Name, bed_N0, pName, id);
                        tabctpnDoc.Controls.Add(uo_record);
                        uo_record.Dock = DockStyle.Fill;
                        App.UsControlStyle(uo_record);
                        isCustom = true;
                    }
                    else
                    {
                        page.Dispose();
                        tabctpnDoc.Dispose();
                        isExcute = false;
                        App.Msg("定制文书没有确定对应的功能模块,请于管理员联系,在文书类型管理中进行设置！");

                    }
                }
                else
                {
                    isExcute = false;
                }
            }
            if (isExcute)
            {
                tabctpnDoc.TabItem = page;
                tabctpnDoc.Dock = DockStyle.Fill;
                page.AttachedControl = tabctpnDoc;
                tctlDoc.Controls.Add(tabctpnDoc);
                tctlDoc.Tabs.Add(page);
                tctlDoc.Refresh();
                tctlDoc.SelectedTab = page;
            }
            return isExcute;
        }
        /// <summary>
        /// 解除护理记录单的锁定
        /// </summary>
        private void UnlockNurseRecord(string user_id)
        {
            string Update_Sql = "update t_care_doc set islock=0 where (open_user='" + user_id + "' or create_id='" + user_id + "') and islock=1";
            int count = App.ExecuteSQL(Update_Sql);
        }
        /// <summary>
        /// 同一个病人只能单个用户操作
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="patient_id">病人id值</param>
        /// <param name="lockState">是否锁定0未锁定1锁定</param>
        /// <param name="colname">列名</param>
        /// <param name="tid">文书id列名</param>
        private void IsLockBook(string tablename, int patient_id, string lockState, string user_id)
        {
            string Update_Sql = "update " + tablename + " set islock='" + lockState
                            + "',OPEN_USER='" + user_id + "',ip='" + App.GetHostIp() + "' where inpatient_id='" + patient_id + "'";
            App.ExecuteSQL(Update_Sql);
        }
        /// <summary>
        /// 获取当前病人护理记录单是否有人在操作
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="patient_id"></param>
        /// <returns>1是锁定，其他没有锁定</returns>
        private bool GetLockState(int patient_id, out string use_open, out string open_name, out string ip)
        {
            string LockState = "";
            open_name = "";
            use_open = "";
            ip = "";
            string Select_Sql = "select a.islock,a.ip,b.user_num,b.user_name from t_care_doc a " +
                                " inner join t_userinfo b on a.open_user=b.user_id" +
                                " where inpatient_id='" + patient_id + "'";
            DataTable dt = App.GetDataSet(Select_Sql).Tables[0];
            if (dt.Rows.Count > 0)
            {
                open_name = dt.Rows[0]["user_name"].ToString();
                use_open = dt.Rows[0]["user_num"].ToString();
                LockState = dt.Rows[0]["islock"].ToString();
                ip = dt.Rows[0]["ip"].ToString();
            }
            return LockState == "1" ? true : false;
        }

        /// <summary>
        /// 浏览时
        /// </summary>
        /// <param name="list">权限集合</param>
        /// <param name="node">当前选中的节点</param>
        private bool CreateNewPage(ArrayList list, Node node)
        {
            bool IsHave = true;
            DevComponents.DotNetBar.TabControlPanel tabctpnView = new DevComponents.DotNetBar.TabControlPanel();
            tabctpnView.AutoScroll = true;
            DevComponents.DotNetBar.TabItem page = new DevComponents.DotNetBar.TabItem();
            page.Click += new EventHandler(page_Click);
            page.Name = node.Name;
            page.Text = node.Text;
            //if (DataInit.GetActionState(currentPatient.Id.ToString()) == "3")
            //{
            page.Tag = currentPatient as object;
            //}
            //else
            //{
            //page.Tag = GetInpatientByBedId(trvInpatientManager.Nodes, dtlBedNumber.SelectedValue.ToString()) as object;
            //}
            if (page.Tag != null)
            {
                //barTemplate.Hide();
                Class_Text ctext = node.Tag as Class_Text;
                if (ctext == null || ctext.Isenable == "0")
                {
                    IsHave = false;
                }
                if (node.Tag.ToString().Contains("Class_Text"))
                {
                    if (ctext.Formname.ToLower() == "ucblood_sugar_record")
                    {
                        //血糖检测单
                        InPatientInfo inpatient = page.Tag as InPatientInfo;
                        ucBlood_Sugar_Record unBlood = new ucBlood_Sugar_Record(inpatient.Sick_Bed_Name,
                                                          inpatient.Patient_Name, inpatient.PId, inpatient.Id.ToString());
                        tabctpnView.Controls.Add(unBlood);
                        unBlood.Dock = DockStyle.Fill;
                        App.UsControlStyle(unBlood);
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "ucpartogram")
                    {
                        //产程图
                        InPatientInfo inpatient = page.Tag as InPatientInfo;
                        page.Tooltip = "N";
                        ucPartogram ucBirthPic = new ucPartogram();

                        string sql_Partogram = "select * from T_PARTOGRAM t where t.patient_id=" + inpatient.Id + "";
                        DataSet ds_Partogram = App.GetDataSet(sql_Partogram);
                        if (ds_Partogram.Tables[0].Rows.Count > 0)
                        {
                            ucBirthPic.FromXml(ds_Partogram.Tables[0].Rows[0]["content"].ToString());
                        }
                        ucBirthPic.UserInfo.PatientInfo = inpatient;
                        ucBirthPic.UserInfo.Xingming = inpatient.Patient_Name;
                        ucBirthPic.UserInfo.Nianling = inpatient.Age;
                        ucBirthPic.UserInfo.Bingshi = inpatient.Sick_Area_Name;
                        ucBirthPic.UserInfo.Zhuyuanhao = inpatient.PId;
                        ucBirthPic.UserInfo.Chuanghao = inpatient.Sick_Bed_Name;
                        ucBirthPic.UserInfo.Tid = Convert.ToInt32(node.Name);
                        ucBirthPic.UserInfo.RefreshUserInfo();

                        if (App.UserAccount.CurrentSelectRole.Role_type == "N")
                        {
                            /*
                             * 护士操作
                             */
                            tabctpnView.Controls.Add(ucBirthPic);
                            ucBirthPic.Dock = DockStyle.Fill;
                            //App.UsControlStyle(ucBirthPic);
                            tabctpnView.AutoScroll = true;
                            isCustom = true;

                        }
                        else
                        {
                            /*
                                              * 医生站
                                              */
                            ucBirthPic.OnlyLook = true;
                            tabctpnView.Controls.Add(ucBirthPic);
                            ucBirthPic.Dock = DockStyle.Fill;
                            //App.UsControlStyle(ucBirthPic);
                            tabctpnView.AutoScroll = true;
                            isCustom = true;
                        }
                    }
                    else if (ctext.Formname.ToLower() == "muctoolscontrol")
                    {
                        string section_id_test = App.UserAccount.CurrentSelectRole.Sickarea_Id;
                        InPatientInfo inpatient = page.Tag as InPatientInfo;
                        if (string.IsNullOrEmpty(section_id_test))
                        {
                            if (inpatient != null)
                            {
                                section_id_test = inpatient.Sike_Area_Id.ToString();
                            }
                            else
                            {
                                section_id_test = "0";
                            }
                        }
                        //MUcToolsControl ucNurseRecord = new MUcToolsControl(inpatient, Convert.ToInt32(section_id_test), Convert.ToInt32(node.Name));
                        MUcToolsControl ucNurseRecord = null;
                        if (currentPatient.Section_Name.Contains("儿科") || currentPatient.Section_Name.Contains("心内二"))
                        {
                            ucNurseRecord = new MUcToolsControl(currentPatient, currentPatient.Section_Id, Convert.ToInt32(node.Name), true);
                            //ucNurseRecord.MyDocument.YzSql = "select distinct order_text, to_char(start_date_time),administration from ORDER_VIEW@dbhislink e where to_char(e.start_date_time,'yyyy-MM-dd') = '{0}' and his_id='{1}' and order_class='A'"; 
                        }
                        else
                        {
                            ucNurseRecord = new MUcToolsControl(currentPatient, currentPatient.Section_Id, Convert.ToInt32(node.Name));
                            //ucNurseRecord.MyDocument.YzSql = "select distinct order_text, to_char(start_date_time),administration from ORDER_VIEW@dbhislink e where to_char(e.start_date_time,'yyyy-MM-dd') = '{0}' and his_id='{1}' and order_class='A'"; 
                        }
                        /*
                         * 护士操作
                         */
                        tabctpnView.Controls.Add(ucNurseRecord);
                        ucNurseRecord.Dock = DockStyle.Fill;
                        App.UsControlStyle(ucNurseRecord);
                        string open_num = "";
                        string open_name = "";
                        string ip = "";
                        bool islock = GetLockState(currentPatient.Id, out open_num, out open_name, out ip);
                        if (App.UserAccount.CurrentSelectRole.Role_type != "N")
                        {
                            ucNurseRecord.MyDocument.ClearTempInput();
                            ucNurseRecord.SetToolsEnable(false);
                            page.Text += "锁定" + "工号：" + open_num + "姓名：" + open_name + "已经打开";
                        }
                        else
                        {
                            if (islock)
                            {
                                string strAsk;
                                if (App.UserAccount.UserInfo.User_name == open_name)
                                {
                                    strAsk = page.Text + "这个文书已经在" + ip + "打开或者上次没有正常关闭，你确定继续操作吗？，";
                                    if (App.Ask(strAsk))
                                    {
                                        IsLockBook("t_care_doc", inpatient.Id, "1", App.UserAccount.UserInfo.User_id);
                                    }
                                    else
                                    {
                                        ucNurseRecord.MyDocument.ClearTempInput();
                                        ucNurseRecord.SetToolsEnable(false);
                                        page.Text += "锁定" + "工号：" + open_num + "姓名：" + open_name + "已经打开";
                                    }

                                }
                                else
                                {
                                    strAsk = page.Text + "这个文书已经在" + ip + "由工号：" + open_num + "姓名：" + open_name + "已经打开，多人操作可能造成内容错误，你确定打开吗？";
                                    if (!App.Ask(strAsk))
                                    {
                                        ucNurseRecord.MyDocument.ClearTempInput();
                                        ucNurseRecord.SetToolsEnable(false);
                                        page.Text += "锁定" + "工号：" + open_num + "姓名：" + open_name + "已经打开";
                                    }
                                    else
                                    {
                                        IsLockBook("t_care_doc", inpatient.Id, "1", App.UserAccount.UserInfo.User_id);
                                    }
                                }
                            }
                            else
                            {
                                if (!islock && App.UserAccount.CurrentSelectRole.Role_type == "N")//没锁定之前
                                {
                                    IsLockBook("t_care_doc", inpatient.Id, "1", App.UserAccount.UserInfo.User_id);
                                }
                            }
                        }
                        tabctpnView.AutoScroll = true;
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "uctempraute")
                    {
                        //体温单
//                         string medicare_no = currentPatient.Medicare_no;
//                         string id = currentPatient.Id.ToString();
//                         string bed_no = currentPatient.Sick_Bed_Name;
//                         string Pname = currentPatient.Patient_Name;
//                         string sex = currentPatient.Gender_Code;
//                         string age = "";
//                         if (currentPatient.Age != null && currentPatient.Age.ToString() != "" && currentPatient.Age.ToString() != "0")
//                             age = currentPatient.Age + currentPatient.Age_unit;
//                         else
//                             age = currentPatient.Child_age;
//                         string section = currentPatient.Section_Name;
//                         string area_Name = currentPatient.Sick_Area_Name;
//                         string in_Time = currentPatient.In_Time.ToString("yyyy-MM-dd HH:mm");
// 
//                         InPatientInfo inpatient = page.Tag as InPatientInfo;
                        if (App.UserAccount.CurrentSelectRole.Role_type == "N")
                        {
                            //ucTempraute temper = new ucTempraute(currentPatient);//inpatient.PId, medicare_no, id, bed_no, Pname, sex, age, section, area_Name, in_Time);
                            TempertureEditor.ucTempraute temper = new TempertureEditor.ucTempraute(currentPatient, TempertureEditor.Tempreture_Management.tempetureDataComm.TEMPLATE_NORMAL, true);
                            temper.Dock = DockStyle.Fill;
                            tabctpnView.Controls.Add(temper);
                            App.UsControlStyle(temper);
                        }
                        else
                        {
                            TempertureEditor.ucTempraute uctemperPrint = new TempertureEditor.ucTempraute(currentPatient, TempertureEditor.Tempreture_Management.tempetureDataComm.TEMPLATE_NORMAL, false);
                            App.UsControlStyle(uctemperPrint);
                            uctemperPrint.Dock = DockStyle.Fill;
                            tabctpnView.Controls.Add(uctemperPrint);
                            App.SetToolButtonByUser("tsbtnCommit", false);
                        }
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "uctempraute_bb")
                    {
                        //新生儿体温单
                        if (App.UserAccount.CurrentSelectRole.Role_type == "N")
                        {
                            TempertureEditor.ucTempraute temper = new TempertureEditor.ucTempraute(currentPatient, TempertureEditor.Tempreture_Management.tempetureDataComm.TEMPLATE_CHILD, true);
                            temper.Dock = DockStyle.Fill;
                            tabctpnView.Controls.Add(temper);
                            App.UsControlStyle(temper);
                        }
                        else
                        {
                            TempertureEditor.ucTempraute uctemperPrint = new TempertureEditor.ucTempraute(currentPatient, TempertureEditor.Tempreture_Management.tempetureDataComm.TEMPLATE_CHILD, false);
                            App.UsControlStyle(uctemperPrint);
                            uctemperPrint.Dock = DockStyle.Fill;
                            tabctpnView.Controls.Add(uctemperPrint);
                            App.SetToolButtonByUser("tsbtnCommit", false);
                        }
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "frmcases_first")
                    {
                        InPatientInfo inpatient = page.Tag as InPatientInfo;
                        page.Tooltip = "N";
                        //重新过去最新信息
                        string Sql_section_Patient = "select * from t_in_patient where id='" + inpatient.Id + "'";
                        DataSet ds = App.GetDataSet(Sql_section_Patient);
                        inpatient = DataInit.InitPatient(ds.Tables[0].Rows[0]);
                        frmCases_First ucCase_First = new frmCases_First(inpatient);

                        if (App.UserAccount.CurrentSelectRole.Role_type == "D" ||
                         App.UserAccount.CurrentSelectRole.Role_type == "N")
                        {
                            //frmCases_First ucCase_First = new frmCases_First(inpatient);
                            tabctpnView.Controls.Add(ucCase_First);
                            ucCase_First.Dock = DockStyle.Fill;
                        }
                        else
                        {

                            //xp没进入load事件
                            ucCase_First.InitPatientInfo();
                            // 获取病人信息
                            DataTable CoverInfo = ucCase_First.GetCoverInfo();
                            #region 病人信息的必填项检查
                            DataRow dr = CoverInfo.Rows[0];
                            #endregion

                            // 获取诊断信息
                            DataTable Diagnose = ucCase_First.GetCoverDiagnose();
                            #region 主要诊断必须填写入院病情和转归情况
                            dr = Diagnose.Rows[0];
                            #endregion


                            // 获取手术信息
                            DataTable Operation = ucCase_First.GetOperation();

                            // 获取病案质量信息
                            DataTable Quality = ucCase_First.GetQuality();

                            // 获取病案首页的一些杂项
                            DataTable Temp = ucCase_First.GetTemp();
                            dr = Temp.Rows[0];
                            #region 杂项表的必填项控制
                            #endregion

                            DataTable cost = ucCase_First.GetCost();

                            // 构造 DataSet
                            DataSet ds_case = new DataSet();
                            ds_case.Tables.Add(CoverInfo);
                            ds_case.Tables.Add(Diagnose);
                            ds_case.Tables.Add(Operation);
                            ds_case.Tables.Add(Quality);
                            ds_case.Tables.Add(Temp);
                            ds_case.Tables.Add(cost);

                            Ucprint ucprint = new Ucprint(ds_case, inpatient, node.Name, "");
                            ucprint.Dock = DockStyle.Fill;
                            App.UsControlStyle(ucprint);
                            tabctpnView.Controls.Add(ucprint);
                        }
                        App.SetToolButtonByUser("tsbtnCommit", false);
                        //App.UsControlStyle(ucCase_First);
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "ucfrmsickreport")
                    {
                        ucfrmSickReport ucsickReport = new ucfrmSickReport();
                        tabctpnView.Controls.Add(ucsickReport);
                        ucsickReport.Dock = DockStyle.Fill;
                        App.UsControlStyle(ucsickReport);
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "ucpatientinfo")
                    {
                        InPatientInfo inpatient = page.Tag as InPatientInfo;
                        page.Tooltip = "N";
                        if (App.UserAccount.CurrentSelectRole.Role_type == "D")
                        {
                            UcPatientInfo ucpatientInfo = new UcPatientInfo(inpatient);
                            tabctpnView.Controls.Add(ucpatientInfo);
                            ucpatientInfo.Dock = DockStyle.Fill;
                        }
                        else if (App.UserAccount.CurrentSelectRole.Role_type == "N")
                        {
                            UcPatientInfo ucpatientInfo = new UcPatientInfo(inpatient);
                            tabctpnView.Controls.Add(ucpatientInfo);
                            ucpatientInfo.Dock = DockStyle.Fill;
                        }
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "expectantrecord")
                    {
                        InPatientInfo inpatient = page.Tag as InPatientInfo;
                        page.Tooltip = "N";
                        string pid = inpatient.PId;
                        string area_Name = inpatient.Sick_Area_Name;
                        string bed_N0 = inpatient.Sick_Bed_Name;
                        string pName = inpatient.Patient_Name;
                        string id = inpatient.Id.ToString();
                        ExpectantRecord exRecord = new ExpectantRecord(pid, area_Name, bed_N0, pName, id);
                        tabctpnView.Controls.Add(exRecord);
                        exRecord.Dock = DockStyle.Fill;
                        App.UsControlStyle(exRecord);
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "ucdiagnosis_certificate")//诊断证明书
                    {
                        InPatientInfo inpatient = page.Tag as InPatientInfo;
                        ucDIAGNOSIS_CERTIFICATE ucprint = new ucDIAGNOSIS_CERTIFICATE(inpatient);
                        ucprint.Dock = DockStyle.Fill;
                        App.UsControlStyle(ucprint);
                        tabctpnView.Controls.Add(ucprint);
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "ucheart_pic")//心电示波记录单
                    {
                        InPatientInfo inpatient = page.Tag as InPatientInfo;
                        ucHeart_PIC ucHeart = new ucHeart_PIC(inpatient.Sick_Bed_Name, inpatient.Patient_Name, inpatient.PId, inpatient.Id.ToString(), inpatient.Section_Name);
                        ucHeart.Dock = DockStyle.Fill;
                        App.UsControlStyle(ucHeart);
                        tabctpnView.Controls.Add(ucHeart);
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "uodinopoeia_record")//中期妊娠引产产后病程记录881
                    {
                        InPatientInfo inpatient = page.Tag as InPatientInfo;
                        page.Tooltip = "N";
                        string pid = inpatient.PId;
                        string area_Name = inpatient.Sick_Area_Name;
                        string bed_N0 = inpatient.Sick_Bed_Name;
                        string pName = inpatient.Patient_Name;
                        string id = inpatient.Id.ToString();
                        UOdinopoeia_Record uo_record = new UOdinopoeia_Record(pid, area_Name, bed_N0, pName, id);
                        tabctpnView.Controls.Add(uo_record);
                        uo_record.Dock = DockStyle.Fill;
                        App.UsControlStyle(uo_record);
                        isCustom = true;
                    }
                    else
                    {
                        tabctpnView.Dispose();
                        page.Dispose();
                        IsHave = false;
                    }
                }
            }
            if (IsHave == true)
            {
                tabctpnView.TabItem = page;
                tabctpnView.Dock = DockStyle.Fill;
                page.AttachedControl = tabctpnView;
                this.tctlDoc.Controls.Add(tabctpnView);
                this.tctlDoc.Tabs.Add(page);
                this.tctlDoc.Refresh();
                this.tctlDoc.SelectedTab = page;
                isCustom = true;
            }
            return IsHave;
        }

        /// <summary>
        /// 获得当前节点下面所有病人文书的节点
        /// </summary>
        /// <param name="nodes">当前节点下的所有文书内容</param>
        /// <returns>返回Patient_Doc集合</returns>
        private Patient_Doc[] GetSelectNodes(int textid)
        {
            Patient_Doc[] patient_Docs = null;
            if (currentPatient != null)
            {
                string sql = "select a.tid,a.textname,a.textkind_id,a.doc_name,c.issimpleinstance,a.section_name,c.ISNEWPAGE,Bed_no from t_patients_doc a" +
                             " inner join t_text c on a.textkind_id = c.id" +
                             " where patient_id='" + this.currentPatient.Id + "'  and  textkind_id!=134" +    //textkind_id=134术前讨论
                             " and parentid=" + textid + "  and submitted='Y' order by doc_name";
                DataSet ds = App.GetDataSet(sql);
                if (ds != null)
                {
                    DataTable dt = ds.Tables[0];
                    if (dt != null)
                    {
                        //arrs = new string[dt.Rows.Count,2];
                        //去掉相同的文书
                        int tid = 0;
                        patient_Docs = new Patient_Doc[dt.Rows.Count];
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {

                            if (tid != Convert.ToInt32(dt.Rows[i]["tid"].ToString()))
                            {

                                patient_Docs[i] = new Patient_Doc();
                                patient_Docs[i].Patients_doc = App.ReadSqlVal("select * from T_PATIENT_DOC_COLB where tid=" + dt.Rows[i]["tid"].ToString() + "", 0, "CONTENT");
                                if (patient_Docs[i].Patients_doc == "" || patient_Docs[i].Patients_doc == null)
                                {
                                    patient_Docs[i].Patients_doc = App.DownLoadFtpPatientDoc(dt.Rows[i]["tid"].ToString() + ".xml", currentPatient.Id.ToString());

                                }
                                patient_Docs[i].Id = Convert.ToInt32(dt.Rows[i]["tid"].ToString());
                                patient_Docs[i].Textkind_id = Convert.ToInt32(dt.Rows[i]["textkind_id"].ToString());
                                patient_Docs[i].Belongtosys_id = Convert.ToInt32(dt.Rows[i]["issimpleinstance"].ToString());
                                patient_Docs[i].Docname = dt.Rows[i]["doc_name"].ToString();
                                patient_Docs[i].Section_name = dt.Rows[i]["section_name"].ToString();
                                patient_Docs[i].Bed = dt.Rows[i]["Bed_no"].ToString();
                                tid = Convert.ToInt32(dt.Rows[i]["tid"].ToString());

                                if (dt.Rows[i]["ISNEWPAGE"].ToString() == "Y")
                                {
                                    patient_Docs[i].Isnewpage = "Y";
                                }
                                else
                                {
                                    patient_Docs[i].Isnewpage = "N";
                                }
                            }
                        }
                    }
                }
            }
            return patient_Docs;

        }

        /// <summary>
        /// 获得当前节点病人文书
        /// </summary>
        /// <param name="nodes">当前节点下的文书内容</param>
        /// <returns>返回Patient_Doc</returns>
        private Patient_Doc[] GetSelectNodes(Patient_Doc text)
        {
            string sql = "select a.tid,a.textname,a.textkind_id,a.createid,a.submitted,a.doc_name,a.section_name,b.ISNEWPAGE,Bed_no from t_patients_doc a inner join t_text b on a.textkind_id = b.id " +
                         "where a.patient_id='" + this.currentPatient.Id + "' and a.tid=" + text.Id + " order by doc_name";
            DataSet ds = App.GetDataSet(sql);
            Patient_Doc[] patient_Docs = null;
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt != null)
                {
                    //去掉相同的文书
                    int tid = 0;
                    patient_Docs = new Patient_Doc[dt.Rows.Count];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (tid != Convert.ToInt32(dt.Rows[i]["tid"].ToString()))
                        {
                            patient_Docs[i] = new Patient_Doc();
                            patient_Docs[i].Patients_doc = App.ReadSqlVal("select * from T_PATIENT_DOC_COLB where tid=" + dt.Rows[i]["tid"].ToString() + "", 0, "CONTENT");
                            if (patient_Docs[i].Patients_doc == "" || patient_Docs[i].Patients_doc == null)
                            {
                                patient_Docs[i].Patients_doc = App.DownLoadFtpPatientDoc(dt.Rows[i]["tid"].ToString() + ".xml", currentPatient.Id.ToString());
                            }

                            patient_Docs[i].Id = Convert.ToInt32(dt.Rows[i]["tid"].ToString());
                            patient_Docs[i].Textkind_id = Convert.ToInt32(dt.Rows[i]["textkind_id"].ToString());
                            patient_Docs[i].Createid = dt.Rows[i]["createid"].ToString();
                            patient_Docs[i].Submitted = dt.Rows[i]["submitted"].ToString();
                            patient_Docs[i].Docname = dt.Rows[i]["doc_name"].ToString();
                            patient_Docs[i].Section_name = dt.Rows[i]["section_name"].ToString();
                            patient_Docs[i].Bed = dt.Rows[i]["Bed_no"].ToString();
                            tid = Convert.ToInt32(dt.Rows[i]["tid"].ToString());

                            if (dt.Rows[i]["ISNEWPAGE"].ToString() == "Y")
                            {
                                patient_Docs[i].Isnewpage = "Y";
                            }
                            else
                            {
                                patient_Docs[i].Isnewpage = "N";
                            }
                        }
                    }
                }
            }
            return patient_Docs;

        }
        /// <summary>
        /// 获得当前节点下面所有病人文书的节点
        /// </summary>
        /// <param name="nodes">当前节点下的所有文书内容</param>
        /// <returns>返回Patient_Doc集合</returns>
        private Patient_Doc[] GetSelectNodes(Class_Text text)
        {
            string sql = "select tid,a.textname,textkind_id,doc_name,section_name,b.ISNEWPAGE,Bed_no from t_patients_doc a inner join t_text b on a.textkind_id = b.id where patient_id='" + currentPatient.Id + "'and textkind_id=" + text.Id + " and submitted='Y' order by doc_name";
            DataSet ds = App.GetDataSet(sql);
            Patient_Doc[] patient_Docs = null;
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count > 0)
                {
                    //去掉相同的文书
                    int tid = 0;
                    //arrs = new string[dt.Rows.Count,2];
                    if (text.Issimpleinstance == "0")
                    {
                        patient_Docs = new Patient_Doc[1];
                    }
                    else
                    {
                        patient_Docs = new Patient_Doc[dt.Rows.Count];
                    }
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (tid != Convert.ToInt32(dt.Rows[i]["tid"].ToString()))
                        {
                            patient_Docs[i] = new Patient_Doc();
                            patient_Docs[i].Patients_doc = App.ReadSqlVal("select * from T_PATIENT_DOC_COLB where tid=" + dt.Rows[i]["tid"].ToString() + "", 0, "CONTENT");
                            if (patient_Docs[i].Patients_doc == "" || patient_Docs[i].Patients_doc == null)
                            {
                                patient_Docs[i].Patients_doc = App.DownLoadFtpPatientDoc(dt.Rows[i]["tid"].ToString() + ".xml", currentPatient.Id.ToString());

                            }
                            patient_Docs[i].Id = Convert.ToInt32(dt.Rows[i]["tid"].ToString());
                            patient_Docs[i].Textkind_id = Convert.ToInt32(dt.Rows[i]["textkind_id"].ToString());
                            patient_Docs[i].Docname = dt.Rows[i]["doc_name"].ToString();
                            patient_Docs[i].Section_name = dt.Rows[i]["section_name"].ToString();
                            patient_Docs[i].Bed = dt.Rows[i]["Bed_no"].ToString();
                            tid = Convert.ToInt32(dt.Rows[i]["tid"].ToString());

                            if (dt.Rows[i]["ISNEWPAGE"].ToString() == "Y")
                            {
                                patient_Docs[i].Isnewpage = "Y";
                            }
                            else
                            {
                                patient_Docs[i].Isnewpage = "N";
                            }
                            if (text.Issimpleinstance == "0")
                                break;
                        }
                    }
                }
            }
            return patient_Docs;
        }
        /// <summary>
        /// 浏览页面修改的文书id
        /// </summary>
        private string Update_Tid = null;

        /// <summary>
        /// 根据文书类型，获得当前文书的内容
        /// </summary>
        /// <returns></returns>
        private Patient_Doc[] GetContentByType(Node node)
        {

            string Type = node.Tag.GetType().Name;
            //string[,] Contents = null;
            Patient_Doc[] patient_Docs = null;
            switch (Type)
            {
                case "Class_Text":
                    if (node.Nodes.Count > 0)
                    {
                        if (node.Nodes[0].Tag.GetType().Name == "Class_Text")
                        {
                            Class_Text cText = node.Tag as Class_Text;
                            patient_Docs = GetSelectNodes(cText.Id);


                        }
                        else                                               //多实例文书，Patient_Doc类型
                        {
                            Class_Text cText = node.Tag as Class_Text;
                            patient_Docs = GetSelectNodes(cText);
                        }
                    }
                    else
                    {
                        Class_Text cText = node.Tag as Class_Text;
                        patient_Docs = GetSelectNodes(cText);
                    }
                    break;
                default:
                    Patient_Doc patientDoc = node.Tag as Patient_Doc;
                    patient_Docs = GetSelectNodes(patientDoc);
                    break;
            }
            return patient_Docs;
        }

        /// <summary>
        /// 修改文书
        /// </summary>
        /// <param name="tid"></param>
        private void Rethreee_CreateTab(string tid)
        {
            if (tid != "")
            {
                //SelectedNodeByTid(advAllDoc.Nodes, tid);
                if (!IsSameTabItem(tid, App.GetSystemTime().ToString("yyyy-MM-dd HH:mm")))
                {
                    CreateTabItem(Convert.ToInt32(tid));
                }
            }
        }

        /// <summary>
        /// 获取浏览操作时需要修改选中的节点
        /// </summary>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        private Node GetSelectDocNode(NodeCollection nodes, string nodeName)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Name == nodeName)
                {
                    return nodes[i];
                }
                if (nodes[i].Nodes.Count > 0)
                {
                    return GetSelectDocNode(nodes[i].Nodes, nodeName);
                }
            }
            return null;
        }

        /// <summary>
        /// 创建新的tabItem
        /// </summary>
        /// <param name="tid">文书id</param>
        private void CreateTabItem(int tid)
        {
            //yunbarTemplate.Hide();
            //if (tid == 0 && NowTree.Name == "advFinishDoc")
            //{
            //    return;
            //}
            Record_Content = "";
            Record_Time = "";
            string docflaag = "";
            string suporSign = "";  //查房上级医师的userId
            /*
             * 创建新的tabItem 的实现思路：
             * 1.当前选中的文书类别，如果是单例文书，就查出其内容。
             * 2.当前选中的是病人文书，根据文书id，查出其内容
             */
            //CurrentNode = advAllDoc.SelectedNode.Clone() as TreeNode;
            // 获得当前时间，精确到分钟
            // string time = string.Format("{0:g}", App.GetSystemTime());
            DevComponents.DotNetBar.TabControlPanel tabctpnDoc = new DevComponents.DotNetBar.TabControlPanel();
            tabctpnDoc.AutoScroll = true;
            DevComponents.DotNetBar.TabItem page = new DevComponents.DotNetBar.TabItem();
            //tctlDoc.TabItemClose += new TabStrip.UserActionEventHandler(tctlDoc_TabItemClose);

            page.Click += new EventHandler(page_Click);

            if (tid == 0)
            {
                Class_Text text = NowTree.SelectedNode.Tag as Class_Text;
                //新建文书，page页的Name用分号隔开，第一位：代表文书类型ID;第二位：文书类型;第三位：代表新建文书;第四位：是否单例文书
                page.Name = NowTree.SelectedNode.Name + ";" + NowTree.SelectedNode.Tag.GetType().ToString() + ";0;" + text.Issimpleinstance;

                //文书对应的医务处规则ID
                DataSet YWC_RAW = App.GetDataSet("select a.var_id from t_doc_quality_relation a  where a.text_id=" + text.Id + "");
                if (YWC_RAW.Tables[0].Rows.Count > 0)
                {
                    string strval = "";
                    for (int i = 0; i < YWC_RAW.Tables[0].Rows.Count; i++)
                    {
                        if (strval == "")
                        {
                            strval = YWC_RAW.Tables[0].Rows[i][0].ToString();
                        }
                        else
                        {
                            strval = strval + "," + YWC_RAW.Tables[0].Rows[i][0].ToString();
                        }
                    }

                    //该文书的红灯质控记录
                    //string valsql = "select t.id,t.pid,t.pv,t2.编号 as doctypeid,substr(t.note,1,INSTR(t.note,'\"',1,1)-5) as 红灯时间,t.note as 红灯说明,t.patient_id from t_quality_record t inner join quality_var_ywc_view t2 on t.doctype=t2.文档类型 where t.pv=1 and t2.编号 in (" + strval + ") and t.patient_id=" + currentPatient.Id + " order by to_date(substr(t.note,1,INSTR(t.note,'\"',1,1)-5),'YYYY-MM-DD HH24:MI'),t.note desc";
                    //DataSet Quarry_record = App.GetDataSet(valsql);// and t.patient_id=" + currentPatient.Id + "
                    //if (Quarry_record != null)
                    //{
                    //    if (Quarry_record.Tables[0].Rows.Count > 0)
                    //    {
                    //        frmCreateDocSet fc = new frmCreateDocSet(Quarry_record);
                    //        App.FormStytleSet(fc, false);
                    //        fc.ShowDialog();
                    //    }
                    //}
                }
            }
            else //修改文书，page页的Name用分号隔开，第一位：文书ID；第二位：文书类型
            {
                page.Name = NowTree.SelectedNode.Name + ";" + NowTree.SelectedNode.Tag.GetType().ToString();
            }

            page.Text = NowTree.SelectedNode.Text + " " + " (" + currentPatient.Sick_Bed_Name + " 床)";
            if (NowTree.SelectedNode.Tag != null)
            {
                if (NowTree.SelectedNode.Tag.ToString().Contains("Class_Text"))
                {
                    Class_Text tempcl = (Class_Text)NowTree.SelectedNode.Tag;
                    if (App.UserAccount.CurrentSelectRole.Role_type != tempcl.Right_range &&
                        tempcl.Right_range != "A" &&
                       App.UserAccount.CurrentSelectRole.Role_type != "Z")//提供质控科查看痕迹,因为痕迹只在编辑状态才能查看
                    {
                        page.Dispose();
                        tabctpnDoc.Dispose();
                        App.Msg("您没有书写该类文书的权限！");
                        return;
                    }
                    //if (tempcl.Textname=="会诊记录")
                    //{
                    //    page.Dispose();
                    //    tabctpnDoc.Dispose();
                    //    App.Msg("提示: 请从[病人小卡]界面选择病人\r\n鼠标右键选择[会诊申请],再新增进行书写！");
                    //    return;
                    //}
                }
            }



            if (NowTree.SelectedNode.Tag.GetType().ToString().Contains("Class_Text"))
            {
                if (NowTree.SelectedNode.Nodes.Count == 0 ||
                    NowTree.SelectedNode.Nodes[0].Tag.GetType().ToString().Contains("Patient_Doc"))
                {
                    Class_Text select_text = NowTree.SelectedNode.Tag as Class_Text;
                    page.Tag = currentPatient as object;
                    if (page.Tag != null)
                    {
                        //barTemplate.AutoHide = true;
                        string log_Tid = NowTree.SelectedNode.Name;
                        isCustom = false;
                        //是否忽略空行
                        bool NeglectLine = IsNeglectLine(NowTree.SelectedNode);

                        string textTitle = GetTextTitle(NowTree.SelectedNode);

                        if (select_text.Other_textname != "")
                        {
                            textTitle = select_text.Other_textname;
                        }

                        InPatientInfo inpatient = page.Tag as InPatientInfo;
                        Class_Text cText = NowTree.SelectedNode.Tag as Class_Text;
                        //page.Tooltip = cText.Id.ToString();
                        if (cText.Submitted == "Y")
                        {
                            docflaag = "Y";

                        }
                        else
                        {
                            //App.SetToolButtonByUser("ttsbtnPrint", false);
                            docflaag = "N";
                        }
                        page.Tooltip = docflaag;

                        #region 时间标题设置
                        isFlagtrue = false;
                        if (select_text.Ishavetime == "A") //编辑器内显示时间标题
                        {
                            if (frmCreateDocSet.q_time == "")
                            {
                                Record_Time = App.GetSystemTime().ToString("yyyy-MM-dd HH:mm");
                            }
                            else
                            {
                                DateTime temp = Convert.ToDateTime(frmCreateDocSet.q_time);
                                Record_Time = temp.ToString("yyyy-MM-dd HH:mm");
                            }
                        }
                        else if (select_text.Ishavetime == "B" && tid == 0)//弹出提示框，编辑器内显示文书名+时间标题
                        {
                            if (frmCreateDocSet.q_time == "")
                            {
                                Record_Time = App.GetSystemTime().ToString("yyyy-MM-dd HH:mm");
                            }
                            else
                            {
                                DateTime temp = Convert.ToDateTime(frmCreateDocSet.q_time);
                                Record_Time = temp.ToString("yyyy-MM-dd HH:mm");
                            }
                            //    frmUpdateTime frmTime = null;
                            //    if (NowTree.SelectedNode.Name == "127")//上级查房记录
                            //    {
                            //        frmTime = new frmUpdateTime(Record_Time, "查房记录", true);
                            //        frmTime.Event_GetRecord += new DeleGetRecord(GetDate);

                            //        frmTime.ShowDialog();
                            //        if (!isFlagtrue)
                            //        {
                            //            return;
                            //        }
                            //        suporSign = frmTime.suporSign;
                            //    }
                            //    else
                            //    {
                            //        //frmTime = new frmUpdateTime(Record_Time, NowTree.SelectedNode.Text, false);
                            //        //frmTime.Event_GetRecord += new DeleGetRecord(GetDate);
                            //        //DialogResult dr = frmTime.ShowDialog();
                            //        //if (!isFlagtrue)
                            //        //{
                            //        //    return;
                            //        //}
                            //    }
                            //}
                            //else if (select_text.Ishavetime == "")
                            //{
                            //    if (Record_Time == "")
                            //        Record_Time = App.GetSystemTime().ToString("yyyy-MM-dd HH:mm");

                            //}
                            if (NowTree.SelectedNode.Text == "手术记录")
                            {
                                Record_Content = "手术记录";

                            }
                        #endregion

                            if (cText.Issimpleinstance == "1")            //1代表多实例文书
                            {
                                if (inpatient.Sick_Bed_Name != "")
                                {
                                    if (!IsSameBookDoc() && !IsSameTabItem(NowTree.SelectedNode.Name, Record_Time))
                                    {
                                        if (page.Name.Split(';').Length == 4)
                                        {//多例文书选项添加时间记录,防止重复时间添加
                                            page.Name += ";" + Record_Time;
                                        }
                                        string content = DataInit.DocFromXmlBytText(NowTree.SelectedNode.Name, DataInit.GetDefaultTemp(NowTree.SelectedNode.Name), inpatient);
                                        //string content = DocFromXmlBytText(NowTree.SelectedNode.Name, DataInit.GetDefaultTemp(NowTree.SelectedNode.Name));
                                        //content=DocFromXmlBytText(CurrentNode.Name, content);
                                        if (content != null)         //获取文书的默认模板
                                        {

                                            // Record_Time = App.GetSystemTime().ToString("yyyy-MM-dd HH:mm");
                                            //frmText text = new frmText(inpatient.PId, cText.Id, 0, 0, App.GetSystemTime().ToString(), tid, inpatient.Patient_Name, inpatient.PId, inpatient.Sick_Bed_Name, inpatient.Section_Name, edit_Title, true, true, Record_Time, Record_Content);
                                            frmText text = new frmText(cText.Id, 0, 0, textTitle, tid, inpatient, true, true, Record_Time, Record_Content);
                                            //显示所有按钮 (文书对比) 
                                            //if (App.UserAccount.CurrentSelectRole.Role_type == "D" ||
                                            //    App.UserAccount.CurrentSelectRole.Role_type == "N")
                                            //    text.MyDoc.EnableShowAll = false;
                                            //else
                                            //    text.MyDoc.EnableShowAll = true;

                                            //添加文书，Ishighersign是否需要上级医师审签
                                            text.MyDoc.TextSuperiorSignature = cText.Ishighersign;
                                            text.MyDoc.HaveTubebedSign = "N";  //管床医生是否审签
                                            text.MyDoc.HaveSuperiorSignature = "N";//是否已经有过上级医生签名

                                            text.MyDoc.IgnoreLine = NeglectLine;
                                            text.MyDoc.OnBackTextId += new EventHandler<BackEvenHandle>(MyDoc_OnBackTextId);
                                            XmlDocument tempxmldoc = new XmlDocument();
                                            tempxmldoc.PreserveWhitespace = true;
                                            if (select_text.Ishavetime != "")
                                            {
                                                text.MyDoc.NeedTimeTitle = true;
                                            }

                                            if (select_text.Isneedsign == "Y")
                                            {
                                                text.MyDoc.AutoGraph = true;
                                            }
                                            if (content.Contains("emrtextdoc"))
                                            {
                                                tempxmldoc.LoadXml(content);
                                                XmlNode xmlNode = tempxmldoc.SelectSingleNode("emrtextdoc");//查找<body>
                                                foreach (XmlNode bodyNode in xmlNode.ChildNodes)
                                                {
                                                    if (bodyNode.Name == "body")
                                                    {
                                                        if (select_text.Ishavetime != "")
                                                        {
                                                            bodyNode.InnerXml = @"<div id='C8272494' marginLeft='10' candelete='1' timeTitle='Y' name='' title='" + Record_Time + "   " + Record_Content + "'><p operatercreater='0' /></div>" + bodyNode.InnerXml;
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                tempxmldoc.LoadXml("<emrtextdoc/>");
                                                text.MyDoc.ToXML(tempxmldoc.DocumentElement);
                                                XmlNode xmlNode = tempxmldoc.SelectSingleNode("emrtextdoc");//查找<body>
                                                foreach (XmlNode bodyNode in xmlNode.ChildNodes)
                                                {
                                                    if (bodyNode.Name == "body")
                                                    {
                                                        bodyNode.InnerXml = "";

                                                        if (select_text.Ishavetime != "")
                                                        {
                                                            bodyNode.InnerXml = @"<div id='C8272494' marginLeft='10' candelete='1' timeTitle='Y' name='' title='" + Record_Time + "   " + Record_Content + "'><p operatercreater='0' /></div>";
                                                        }
                                                        if (NowTree.SelectedNode.Text.Contains("日常病程记录") ||
                                                            NowTree.SelectedNode.Text.Contains("医患沟通记录"))
                                                        {
                                                            text.MyDoc.HidleNameTitle = false;
                                                        }
                                                        bodyNode.InnerXml += content;
                                                    }
                                                }
                                            }

                                            DataInit.filterInfo(tempxmldoc.DocumentElement, inpatient, text.MyDoc.Us.TextKind_id, text.MyDoc.Us.Tid);
                                            text.MyDoc.FromXML(tempxmldoc.DocumentElement);
                                            //手术知情同意书行间距默认6
                                            if (cText.Id == 1601)
                                            {
                                                text.MyDoc.Info.LineSpacing = 6;
                                                text.MyDoc.Info.ParagraphSpacing = 6;
                                            }
                                            text.MyDoc.ContentChanged();
                                            tabctpnDoc.Controls.Add(text);
                                            text.Dock = DockStyle.Fill;
                                            text.MyDoc.HidleNameTitle = false;
                                            //if (advAllDoc.SelectedNode.Name == "1102") //透析
                                            //{
                                            //    text.MyDoc._InsertMoreDiv(Record_Time + " " + Record_Content);
                                            //}                                      

                                        }
                                        else
                                        {
                                            //frmText text = new frmText(inpatient.PId, cText.Id, 0, 0, App.GetSystemTime().ToString(), tid, inpatient.Patient_Name, inpatient.PId, inpatient.Sick_Bed_Name, inpatient.Section_Name, edit_Title, true, true, Record_Time, Record_Content);
                                            //Record_Time = App.GetSystemTime().ToString("yyyy-MM-dd HH:mm");
                                            frmText text = new frmText(cText.Id, 0, 0, textTitle, tid, inpatient, true, true, Record_Time, Record_Content);

                                            //添加文书，Ishighersign是否需要上级医师审签
                                            text.MyDoc.TextSuperiorSignature = cText.Ishighersign;
                                            text.MyDoc.HaveTubebedSign = "N";  //管床医生是否审签
                                            text.MyDoc.HaveSuperiorSignature = "N";//是否已经有过上级医生签名

                                            text.MyDoc.SuporSign = suporSign; //查房上级医师userId

                                            text.MyDoc.IgnoreLine = NeglectLine;
                                            //显示所有按钮 (文书对比)
                                            //if (App.UserAccount.CurrentSelectRole.Role_type == "D" ||
                                            // App.UserAccount.CurrentSelectRole.Role_type == "N")
                                            //    text.MyDoc.EnableShowAll = false;
                                            //else
                                            //    text.MyDoc.EnableShowAll = true;

                                            DataInit.SetToolEvent(text);

                                            App.A_RefleshTreeBook = null;
                                            text.MyDoc.OnBackTextId += new EventHandler<BackEvenHandle>(MyDoc_OnBackTextId);
                                            App.A_RefleshTreeBook += new EventHandler(ReflashTrvBookEvent);
                                            tabctpnDoc.Controls.Add(text);
                                            text.Dock = DockStyle.Fill;
                                            if (select_text.Ishavetime != "")
                                            {
                                                text.MyDoc.NeedTimeTitle = true;
                                            }

                                            if (select_text.Isneedsign == "Y")
                                            {
                                                text.MyDoc.AutoGraph = true;
                                            }
                                            if (select_text.Ishavetime != "")
                                            {
                                                text.MyDoc._InsertMoreDiv(Record_Time + "   " + Record_Content);
                                            }
                                            if (NowTree.SelectedNode.Text.Contains("医患沟通记录"))
                                            {
                                                text.MyDoc.HidleNameTitle = false;
                                            }
                                            XmlDocument tempxmldoc = new XmlDocument();
                                            tempxmldoc = DataInit.XmlDoc(tempxmldoc, inpatient, text);
                                            text.MyDoc.FromXML(tempxmldoc.DocumentElement);
                                        }
                                    }
                                    else
                                    {
                                        Record_Time = null;
                                        Record_Content = null;
                                        return;
                                    }

                                }
                            }
                            else//单例文书
                            {
                                string temptid = isExitRecord(cText.Id, currentPatient.Id);
                                if (temptid != null && temptid != "")   //如果已经存在，则是修改。
                                {
                                    if (inpatient.Sick_Bed_Name != "")
                                    {
                                        tid = Convert.ToInt32(temptid);
                                        //frmText text = new frmText(inpatient.PId, cText.Id, 0, 0, App.GetSystemTime().ToString(), tid, inpatient.Patient_Name, inpatient.PId, inpatient.Sick_Bed_Name, inpatient.Section_Name, edit_Title, true);
                                        frmText text = new frmText(cText.Id, 0, 0, textTitle, tid, inpatient, true, false, Record_Time, Record_Content);
                                        //显示所有按钮 (文书对比)
                                        //if (App.UserAccount.CurrentSelectRole.Role_type == "D" ||
                                        //     App.UserAccount.CurrentSelectRole.Role_type == "N")
                                        //    text.MyDoc.EnableShowAll = false;
                                        //else
                                        //    text.MyDoc.EnableShowAll = true;
                                        text.MyDoc.OnBackTextId += new EventHandler<BackEvenHandle>(MyDoc_OnBackTextId);
                                        text.MyDoc.IgnoreLine = NeglectLine;
                                        XmlDocument tmpxml = new System.Xml.XmlDocument();
                                        tmpxml.PreserveWhitespace = true;
                                        string sql = "select tid,Ishighersign,Havedoctorsign,Havehighersign,submitted,section_name from t_patients_doc where textkind_id=" + cText.Id + " and patient_id=" + inpatient.Id + "";
                                        DataTable dt = App.GetDataSet(sql).Tables[0];

                                        string content = "";
                                        content = App.ReadSqlVal("select * from T_PATIENT_DOC_COLB where tid=" + dt.Rows[0]["tid"].ToString() + "", 0, "CONTENT");
                                        if (content == "" || content == null)
                                        {
                                            content = App.DownLoadFtpPatientDoc(dt.Rows[0]["tid"].ToString() + ".xml", inpatient.Id.ToString()); //dt.Rows[0]["patients_doc"].ToString();
                                        }

                                        string ishighersign = dt.Rows[0]["Ishighersign"].ToString();
                                        string havedoctorsign = dt.Rows[0]["Havedoctorsign"].ToString();
                                        string havehighersign = dt.Rows[0]["Havehighersign"].ToString();
                                        docflaag = dt.Rows[0]["submitted"].ToString();
                                        text.MyDoc.Section_name = dt.Rows[0]["section_name"].ToString();
                                        //修改文书，Ishighersign是否需要上级医师审签
                                        text.MyDoc.TextSuperiorSignature = ishighersign;
                                        text.MyDoc.HaveTubebedSign = havedoctorsign;  //管床医生是否审签
                                        text.MyDoc.HaveSuperiorSignature = havehighersign;//是否已经有过上级医生签名

                                        if (select_text.Ishavetime != "")
                                        {
                                            text.MyDoc.NeedTimeTitle = true;
                                        }

                                        if (select_text.Isneedsign == "Y")
                                        {
                                            text.MyDoc.AutoGraph = true;
                                        }

                                        tmpxml.LoadXml(content);
                                        if (NowTree.SelectedNode.Text.Contains("日常病程记录"))
                                        {
                                            text.MyDoc.HidleNameTitle = false;
                                        }
                                        DataInit.filterInfo(tmpxml.DocumentElement, currentPatient, cText.Id, tid);
                                        text.MyDoc.FromXML(tmpxml.DocumentElement);
                                        text.MyDoc.ContentChanged();
                                        tabctpnDoc.Controls.Add(text);
                                        text.Dock = DockStyle.Fill;

                                    }
                                }
                                else
                                {

                                    if (inpatient.Sick_Bed_Name != "")
                                    {
                                        string content = DataInit.DocFromXmlBytText(NowTree.SelectedNode.Name, DataInit.GetDefaultTemp(NowTree.SelectedNode.Name), inpatient);
                                        //string content = DocFromXmlBytText(NowTree.SelectedNode.Name,DataInit.GetDefaultTemp(NowTree.SelectedNode.Name));
                                        //content=DocFromXmlBytText(CurrentNode.Name, content);
                                        if (content != null)         //获取文书的默认模板
                                        {
                                            frmText text = new frmText(cText.Id, 0, 0, textTitle, tid, inpatient, true, false, Record_Time, Record_Content);
                                            //显示所有按钮 (文书对比)
                                            //if (App.UserAccount.CurrentSelectRole.Role_type == "D" ||
                                            // App.UserAccount.CurrentSelectRole.Role_type == "N")
                                            //    text.MyDoc.EnableShowAll = false;
                                            //else
                                            //    text.MyDoc.EnableShowAll = true;
                                            //添加文书，Ishighersign是否需要上级医师审签
                                            text.MyDoc.TextSuperiorSignature = cText.Ishighersign;
                                            //患者授权(委托)书 1603 自动出院同意书 1585 不需要管床签字
                                            if (select_text.Ishavetime != "")
                                            {
                                                text.MyDoc.NeedTimeTitle = true;
                                            }
                                            if (select_text.Isneedsign == "Y")
                                            {
                                                text.MyDoc.AutoGraph = true;
                                            }
                                            if (cText.Id == 1603 || cText.Id == 1585)
                                            {
                                                text.MyDoc.HaveTubebedSign = "Y";
                                            }
                                            else
                                            {
                                                text.MyDoc.HaveTubebedSign = "N";//管床医生是否审签
                                            }
                                            text.MyDoc.HaveSuperiorSignature = "N";//是否已经有过上级医生签名
                                            text.MyDoc.OnBackTextId += new EventHandler<BackEvenHandle>(MyDoc_OnBackTextId);
                                            text.MyDoc.IgnoreLine = NeglectLine;
                                            XmlDocument tempxmldoc = new XmlDocument();
                                            tempxmldoc.PreserveWhitespace = true;
                                            if (content.Contains("emrtextdoc"))
                                            {
                                                tempxmldoc.LoadXml(content);
                                                XmlNode xmlNode = tempxmldoc.SelectSingleNode("emrtextdoc");//查找<body>
                                                foreach (XmlNode bodyNode in xmlNode.ChildNodes)
                                                {
                                                    if (bodyNode.Name == "body")
                                                    {
                                                        if (select_text.Ishavetime != "")
                                                        {
                                                            bodyNode.InnerXml = @"<div id='C8272494' marginLeft='10' candelete='1' timeTitle='Y' name='' title='" + Record_Time + "   " + Record_Content + "'><p operatercreater='0' /></div>" + bodyNode.InnerXml;
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                tempxmldoc.LoadXml("<emrtextdoc/>");
                                                text.MyDoc.ToXML(tempxmldoc.DocumentElement);
                                                //tempxmldoc.SelectSingleNode("emrtextdoc/body").InnerXml = "";
                                                XmlNode xmlNode = tempxmldoc.SelectSingleNode("emrtextdoc");//查找<body>
                                                foreach (XmlNode bodyNode in xmlNode.ChildNodes)
                                                {
                                                    if (bodyNode.Name == "body")
                                                    {
                                                        bodyNode.InnerXml = "";
                                                        if (select_text.Ishavetime != "")
                                                        {
                                                            text.MyDoc.NeedTimeTitle = true;
                                                            bodyNode.InnerXml = @"<div id='C8272494' marginLeft='10' candelete='1' timeTitle='Y' name='' title='" + Record_Time + "   " + Record_Content + "'><p operatercreater='0' /></div>";
                                                        }
                                                        bodyNode.InnerXml += content;
                                                    }
                                                }
                                            }
                                            DataInit.filterInfo(tempxmldoc.DocumentElement, inpatient, text.MyDoc.Us.TextKind_id, text.MyDoc.Us.Tid);
                                            text.MyDoc.FromXML(tempxmldoc.DocumentElement);

                                            //患者授权（委托）书行间距4
                                            if (cText.Id == 1603)
                                            {
                                                text.MyDoc.Info.LineSpacing = 4;
                                                text.MyDoc.Info.ParagraphSpacing = 4;
                                            }
                                            text.MyDoc.ContentChanged();
                                            tabctpnDoc.Controls.Add(text);
                                            text.Dock = DockStyle.Fill;
                                        }
                                        else
                                        {
                                            frmText text = new frmText(cText.Id, 0, 0, textTitle, tid, inpatient, true, false, Record_Time, Record_Content);
                                            //显示所有按钮 (文书对比)
                                            //if (App.UserAccount.CurrentSelectRole.Role_type == "D" ||
                                            // App.UserAccount.CurrentSelectRole.Role_type == "N")
                                            //    text.MyDoc.EnableShowAll = false;
                                            //else
                                            //    text.MyDoc.EnableShowAll = true;
                                            //添加文书，Ishighersign是否需要上级医师审签
                                            text.MyDoc.TextSuperiorSignature = cText.Ishighersign;
                                            text.MyDoc.HaveTubebedSign = "N";  //管床医生是否审签
                                            text.MyDoc.HaveSuperiorSignature = "N";//是否已经有过上级医生签名
                                            text.MyDoc.OnBackTextId += new EventHandler<BackEvenHandle>(MyDoc_OnBackTextId);
                                            text.MyDoc.IgnoreLine = NeglectLine;
                                            DataInit.SetToolEvent(text);
                                            App.A_RefleshTreeBook = null;
                                            App.A_RefleshTreeBook += new EventHandler(ReflashTrvBookEvent);
                                            tabctpnDoc.Controls.Add(text);
                                            text.Dock = DockStyle.Fill;
                                            if (select_text.Ishavetime != "")
                                            {
                                                text.MyDoc.NeedTimeTitle = true;
                                            }

                                            if (select_text.Isneedsign == "Y")
                                            {
                                                text.MyDoc.AutoGraph = true;
                                            }
                                            if (select_text.Ishavetime != "")
                                            {
                                                text.MyDoc._InsertMoreDiv(Record_Time + "   " + Record_Content);
                                            }
                                            XmlDocument tempxmldoc = new XmlDocument();
                                            tempxmldoc = DataInit.XmlDoc(tempxmldoc, inpatient, text);
                                            text.MyDoc.FromXML(tempxmldoc.DocumentElement);
                                        }
                                    }
                                }
                            }



                            int patient_Id = currentPatient.Id;
                            //记录操作日志
                            //LogHelper.SystemLog("", "S", "添加文书", log_Tid, currentPatient.PId, patient_Id);

                            tabctpnDoc.TabItem = page;
                            tabctpnDoc.Dock = DockStyle.Fill;
                            page.AttachedControl = tabctpnDoc;
                            this.tctlDoc.Controls.Add(tabctpnDoc);
                            this.tctlDoc.Tabs.Add(page);
                            this.tctlDoc.Refresh();
                            this.tctlDoc.SelectedTab = page;
                            //if (docflaag == "Y" || NowTree.SelectedNode.Text == "住院病案首页" || NowTree.SelectedNode.Text == "患者基本信息")
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
                            App.Msg("此病人床号异常！");
                        }
                    }

                }
                else if (NowTree.SelectedNode.Tag.GetType().ToString().Contains("Patient_Doc"))
                {

                    Class_Text cText = NowTree.SelectedNode.Parent.Tag as Class_Text;
                    //barTemplate.AutoHide = true;
                    //设置文书标题
                    string textTitle = GetTextTitle(NowTree.SelectedNode);
                    //是否可以忽略空行
                    bool NeglectLine = IsNeglectLine(NowTree.SelectedNode);

                    page.Tag = currentPatient as object;
                    Record_Time = NowTree.SelectedNode.Text;
                    InPatientInfo inpatient = page.Tag as InPatientInfo;
                    if (inpatient.Sick_Bed_Name != "")
                    {
                        isCustom = false;
                        //把未提交的普通文书存到arraylist
                        //save_TextId.Add(advAllDoc.SelectedNode.Name);
                        Patient_Doc pdoc = NowTree.SelectedNode.Tag as Patient_Doc;
                        tid = pdoc.Id;
                        frmText text = new frmText(cText.Id, 0, 0, textTitle, tid, inpatient, true, true, Record_Time, Record_Content);
                        if (textTitle.Contains("电脑血糖监测记录单") || textTitle.Contains("产科(新生儿)护理记录单") ||
                            textTitle.Contains("新生儿经皮胆红素观察表") || textTitle.Contains("缩宫素滴注观察记录单") ||
                            textTitle.Contains("PICC护理记录单"))
                        {
                            int nodeIndex = advFinishDoc.SelectedNode.Index;
                            text.MyDoc.PageStartIndex = nodeIndex;
                        }
                        //显示所有按钮 (文书对比)
                        //if (App.UserAccount.CurrentSelectRole.Role_type == "D" ||
                        //                     App.UserAccount.CurrentSelectRole.Role_type == "N")
                        //    text.MyDoc.EnableShowAll = false;
                        //else
                        //    text.MyDoc.EnableShowAll = true;
                        text.MyDoc.Section_name = pdoc.Section_name;//文书所属科室 
                        //修改文书，Ishighersign是否需要上级医师审签
                        text.MyDoc.TextSuperiorSignature = pdoc.Ishighersign;
                        text.MyDoc.HaveTubebedSign = pdoc.Havedoctorsign;  //管床医生是否审签
                        text.MyDoc.HaveSuperiorSignature = pdoc.Havehighersign;//是否已经有过上级医生签名
                        text.MyDoc.SuporSign = pdoc.Highersignuserid; //查房医生的userId
                        text.MyDoc.OnBackTextId += new EventHandler<BackEvenHandle>(MyDoc_OnBackTextId);

                        text.MyDoc.IgnoreLine = NeglectLine;
                        //锁定不是本科室的文书
                        string[] sections = cText.Sid.Split(',');
                        bool sectionflag = false;
                        for (int k = 0; k < sections.Length; k++)
                        {
                            if (App.UserAccount.CurrentSelectRole.Section_Id == sections[k])
                            {
                                sectionflag = true;
                                break;
                            }
                        }

                        System.Xml.XmlDocument tmpxml = new System.Xml.XmlDocument();
                        tmpxml.PreserveWhitespace = true;
                        string content = "";
                        content = App.ReadSqlVal("select * from T_PATIENT_DOC_COLB where tid=" + pdoc.Id + "", 0, "CONTENT");

                        if (content == "" || content == null)
                        {
                            content = App.DownLoadFtpPatientDoc(pdoc.Id + ".xml", inpatient.Id.ToString());
                        }

                        tmpxml.LoadXml(content);
                        DataInit.filterInfo(tmpxml.DocumentElement, currentPatient, cText.Id, tid);
                        text.MyDoc.FromXML(tmpxml.DocumentElement);
                        text.MyDoc.ContentChanged();
                        tabctpnDoc.Controls.Add(text);
                        text.Dock = DockStyle.Fill;
                        DataInit.SetToolEvent(text);
                        App.A_RefleshTreeBook = null;
                        App.A_RefleshTreeBook += new EventHandler(ReflashTrvBookEvent);
                        tabctpnDoc.TabItem = page;
                        page.Tooltip = docflaag;
                        tabctpnDoc.Dock = DockStyle.Fill;
                        page.AttachedControl = tabctpnDoc;
                        this.tctlDoc.Controls.Add(tabctpnDoc);
                        this.tctlDoc.Tabs.Add(page);
                        this.tctlDoc.Refresh();
                        this.tctlDoc.SelectedTab = page;
                        string log_Tid = NowTree.SelectedNode.Name;
                        int patient_Id = currentPatient.Id;
                        //LogHelper.SystemLog("", "S", "添加文书", log_Tid, currentPatient.PId, patient_Id);
                        //锁定文书
                        if (!sectionflag)
                        {
                            // text.MyDoc.Locked = true;
                        }
                    }
                }
                App.AddCurrentDocMsg(currentPatient.Id.ToString() + page.Text);
            }
        }

        /// <summary>
        /// 是否可以忽略空行
        /// </summary>
        /// <param name="node">当前选中的节点</param>
        /// <returns>true忽略，false不忽略</returns>
        private bool IsNeglectLine(Node node)
        {
            bool NeglectLin = true;
            if (node != null)
            {
                if (node.Tag.ToString().Contains("Class_Text"))//文书节点
                {
                    Class_Text class_Text = node.Tag as Class_Text;
                    if (class_Text.Txxttype == "915")//知情同意书
                    {
                        NeglectLin = false;
                    }
                }
                else if (node.Tag.ToString().Contains("Patient_Doc"))//文书内容节点
                {
                    if (node.Parent != null)
                    {
                        Class_Text class_Text = node.Parent.Tag as Class_Text;
                        if (class_Text.Txxttype == "915")//知情同意书
                        {
                            NeglectLin = false;
                        }
                    }
                }
            }
            return NeglectLin;
        }

        /// <summary>
        /// 判断该类单例文书是否已经存在
        /// </summary>
        /// <param name="id"></param>
        /// /// <param name="patient_id">病人id</param>
        /// <returns></returns>
        private string isExitRecord(int id, int patient_id)
        {
            string sql = "select tid num from t_patients_doc where textkind_id =" + id + " and patient_id='" + patient_id + "' ";
            //union select tid from t_care_doc  where textkind_id =" + id + " and inpatient_id='" + patient_id + "'
            string tid = App.ReadSqlVal(sql, 0, "num");
            return tid;
        }
        /// <summary>
        /// 医生账号登陆只能浏览护士文书的打印界面
        /// </summary>
        /// <param name="list"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        /// <summary>
        /// 医生账号登陆只能浏览护士文书的打印界面
        /// </summary>
        /// <param name="list"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        private bool CreateNewPageByDoctor(ArrayList list, Node node)
        {
            bool IsHave = true;
            DevComponents.DotNetBar.TabControlPanel tabctpnDoc = new DevComponents.DotNetBar.TabControlPanel();
            tabctpnDoc.AutoScroll = true;
            DevComponents.DotNetBar.TabItem page = new DevComponents.DotNetBar.TabItem();
            page.Click += new EventHandler(page_Click);
            page.Name = node.Name;
            page.Tag = currentPatient as object;
            InPatientInfo inpatient = page.Tag as InPatientInfo;
            page.Text = node.Text + " " + " (" + inpatient.Sick_Bed_Name + " 床)";
            if (node.Tag != null)
            {
                if (node.Tag.ToString().Contains("Class_Text"))
                {
                    Class_Text ctext = node.Tag as Class_Text;
                    if (ctext == null || ctext.Isenable == "0")
                    {
                        IsHave = false;
                    }
                    if (ctext.Formname.ToLower() == "ucblood_sugar_record")
                    {
                        //血糖检测单

                        ucBlood_Sugar_Record unBlood = new ucBlood_Sugar_Record(inpatient.Sick_Bed_Name,
                                                          inpatient.Patient_Name, inpatient.PId, inpatient.Id.ToString());
                        tabctpnDoc.Controls.Add(unBlood);
                        unBlood.Dock = DockStyle.Fill;
                        App.UsControlStyle(unBlood);
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "ucpartogram")
                    {
                        //产程图

                        page.Tooltip = "N";
                        ucPartogram ucBirthPic = new ucPartogram();

                        string sql_Partogram = "select * from T_PARTOGRAM t where t.patient_id=" + inpatient.Id + "";
                        DataSet ds_Partogram = App.GetDataSet(sql_Partogram);
                        if (ds_Partogram.Tables[0].Rows.Count > 0)
                        {
                            ucBirthPic.FromXml(ds_Partogram.Tables[0].Rows[0]["content"].ToString());
                        }
                        ucBirthPic.UserInfo.PatientInfo = inpatient;
                        ucBirthPic.UserInfo.Xingming = inpatient.Patient_Name;
                        ucBirthPic.UserInfo.Nianling = inpatient.Age;
                        ucBirthPic.UserInfo.Bingshi = inpatient.Sick_Area_Name;
                        ucBirthPic.UserInfo.Zhuyuanhao = inpatient.PId;
                        ucBirthPic.UserInfo.Chuanghao = inpatient.Sick_Bed_Name;
                        ucBirthPic.UserInfo.Tid = Convert.ToInt32(node.Name);
                        ucBirthPic.UserInfo.RefreshUserInfo();

                        if (App.UserAccount.CurrentSelectRole.Role_type == "N")
                        {
                            /*
                             * 护士操作
                             */
                            tabctpnDoc.Controls.Add(ucBirthPic);
                            ucBirthPic.Dock = DockStyle.Fill;
                            //App.UsControlStyle(ucBirthPic);
                            tabctpnDoc.AutoScroll = true;
                            isCustom = true;

                        }
                        else
                        {
                            /*
                                              * 医生站
                                              */
                            ucBirthPic.OnlyLook = true;
                            tabctpnDoc.Controls.Add(ucBirthPic);
                            ucBirthPic.Dock = DockStyle.Fill;
                            //App.UsControlStyle(ucBirthPic);
                            tabctpnDoc.AutoScroll = true;
                            isCustom = true;
                        }
                    }
                    else if (ctext.Formname.ToLower() == "muctoolscontrol")
                    {
                        string section_id_test = App.UserAccount.CurrentSelectRole.Sickarea_Id;

                        if (string.IsNullOrEmpty(section_id_test))
                        {
                            if (inpatient != null)
                            {
                                section_id_test = inpatient.Sike_Area_Id.ToString();
                            }
                            else
                            {
                                section_id_test = "0";
                            }
                        }
                        //MUcToolsControl ucNurseRecord = new MUcToolsControl(inpatient, Convert.ToInt32(section_id_test), Convert.ToInt32(node.Name));
                        MUcToolsControl ucNurseRecord = null;
                        if (currentPatient.Section_Name.Contains("儿科") || currentPatient.Section_Name.Contains("心内二"))
                        {
                            ucNurseRecord = new MUcToolsControl(currentPatient, currentPatient.Section_Id, Convert.ToInt32(node.Name), true);
                            //ucNurseRecord.MyDocument.YzSql = "select distinct order_text, to_char(start_date_time),administration from ORDER_VIEW@dbhislink e where to_char(e.start_date_time,'yyyy-MM-dd') = '{0}' and his_id='{1}' and order_class='A'"; 
                        }
                        else
                        {
                            ucNurseRecord = new MUcToolsControl(currentPatient, currentPatient.Section_Id, Convert.ToInt32(node.Name));
                            //ucNurseRecord.MyDocument.YzSql = "select distinct order_text, to_char(start_date_time),administration from ORDER_VIEW@dbhislink e where to_char(e.start_date_time,'yyyy-MM-dd') = '{0}' and his_id='{1}' and order_class='A'"; 
                        }
                        /*
                         * 护士操作
                         */
                        tabctpnDoc.Controls.Add(ucNurseRecord);
                        ucNurseRecord.Dock = DockStyle.Fill;
                        App.UsControlStyle(ucNurseRecord);
                        string open_num = "";
                        string open_name = "";
                        string ip = "";
                        bool islock = GetLockState(currentPatient.Id, out open_num, out open_name, out ip);
                        if (App.UserAccount.CurrentSelectRole.Role_type != "N")
                        {
                            ucNurseRecord.MyDocument.ClearTempInput();
                            ucNurseRecord.SetToolsEnable(false);
                            page.Text += "锁定" + "工号：" + open_num + "姓名：" + open_name + "已经打开";
                        }
                        else
                        {
                            if (islock)
                            {
                                string strAsk;
                                if (App.UserAccount.UserInfo.User_name == open_name)
                                {
                                    strAsk = page.Text + "这个文书已经在" + ip + "打开或者上次没有正常关闭，你确定继续操作吗？，";
                                    if (App.Ask(strAsk))
                                    {
                                        IsLockBook("t_care_doc", inpatient.Id, "1", App.UserAccount.UserInfo.User_id);
                                    }
                                    else
                                    {
                                        ucNurseRecord.MyDocument.ClearTempInput();
                                        ucNurseRecord.SetToolsEnable(false);
                                        page.Text += "锁定" + "工号：" + open_num + "姓名：" + open_name + "已经打开";
                                    }

                                }
                                else
                                {
                                    strAsk = page.Text + "这个文书已经在" + ip + "由工号：" + open_num + "姓名：" + open_name + "已经打开，多人操作可能造成内容错误，你确定打开吗？";
                                    if (!App.Ask(strAsk))
                                    {
                                        ucNurseRecord.MyDocument.ClearTempInput();
                                        ucNurseRecord.SetToolsEnable(false);
                                        page.Text += "锁定" + "工号：" + open_num + "姓名：" + open_name + "已经打开";
                                    }
                                    else
                                    {
                                        IsLockBook("t_care_doc", inpatient.Id, "1", App.UserAccount.UserInfo.User_id);
                                    }
                                }
                            }
                            else
                            {
                                if (!islock && App.UserAccount.CurrentSelectRole.Role_type == "N")//没锁定之前
                                {
                                    IsLockBook("t_care_doc", inpatient.Id, "1", App.UserAccount.UserInfo.User_id);
                                }
                            }
                        }
                        tabctpnDoc.AutoScroll = true;
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "uctempraute")
                    {
                        //体温单
//                         string medicare_no = currentPatient.Medicare_no;
//                         string id = currentPatient.Id.ToString();
//                         string bed_no = currentPatient.Sick_Bed_Name;
//                         string Pname = currentPatient.Patient_Name;
//                         string sex = currentPatient.Gender_Code;
//                         string age = "";
//                         if (currentPatient.Age != null && currentPatient.Age.ToString() != "" && currentPatient.Age.ToString() != "0")
//                             age = currentPatient.Age + currentPatient.Age_unit;
//                         else
//                             age = currentPatient.Child_age;
//                         string section = currentPatient.Section_Name;
//                         string area_Name = currentPatient.Sick_Area_Name;
//                         string in_Time = currentPatient.In_Time.ToString("yyyy-MM-dd HH:mm");


                        if (App.UserAccount.CurrentSelectRole.Role_type == "N")
                        {
                            //ucTempraute temper = new ucTempraute(currentPatient);//inpatient.PId, medicare_no, id, bed_no, Pname, sex, age, section, area_Name, in_Time);
                            TempertureEditor.ucTempraute temper = new TempertureEditor.ucTempraute(currentPatient, TempertureEditor.Tempreture_Management.tempetureDataComm.TEMPLATE_NORMAL, true);
                            temper.Dock = DockStyle.Fill;
                            tabctpnDoc.Controls.Add(temper);
                            App.UsControlStyle(temper);
                        }
                        else
                        {
                            TempertureEditor.ucTempraute uctemperPrint = new TempertureEditor.ucTempraute(currentPatient, TempertureEditor.Tempreture_Management.tempetureDataComm.TEMPLATE_NORMAL, false);
                            App.UsControlStyle(uctemperPrint);
                            uctemperPrint.Dock = DockStyle.Fill;
                            tabctpnDoc.Controls.Add(uctemperPrint);
                            App.SetToolButtonByUser("tsbtnCommit", false);
                        }
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "uctempraute_bb")
                    {
                        //新生儿体温单
                        if (App.UserAccount.CurrentSelectRole.Role_type == "N")
                        {
                            TempertureEditor.ucTempraute temper = new TempertureEditor.ucTempraute(currentPatient, TempertureEditor.Tempreture_Management.tempetureDataComm.TEMPLATE_CHILD, true);
                            temper.Dock = DockStyle.Fill;
                            tabctpnDoc.Controls.Add(temper);
                            App.UsControlStyle(temper);
                        }
                        else
                        {
                            TempertureEditor.ucTempraute uctemperPrint = new TempertureEditor.ucTempraute(currentPatient, TempertureEditor.Tempreture_Management.tempetureDataComm.TEMPLATE_CHILD, false);
                            App.UsControlStyle(uctemperPrint);
                            uctemperPrint.Dock = DockStyle.Fill;
                            tabctpnDoc.Controls.Add(uctemperPrint);
                            App.SetToolButtonByUser("tsbtnCommit", false);
                        }
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "frmcases_first")
                    {

                        page.Tooltip = "N";
                        //重新过去最新信息
                        string Sql_section_Patient = "select * from t_in_patient where id='" + inpatient.Id + "'";
                        DataSet ds = App.GetDataSet(Sql_section_Patient);
                        inpatient = DataInit.InitPatient(ds.Tables[0].Rows[0]);
                        frmCases_First ucCase_First = new frmCases_First(inpatient);

                        if (App.UserAccount.CurrentSelectRole.Role_type == "D" ||
                         App.UserAccount.CurrentSelectRole.Role_type == "N")
                        {
                            //frmCases_First ucCase_First = new frmCases_First(inpatient);
                            tabctpnDoc.Controls.Add(ucCase_First);
                            ucCase_First.Dock = DockStyle.Fill;
                        }
                        else
                        {

                            //xp没进入load事件
                            ucCase_First.InitPatientInfo();
                            // 获取病人信息
                            DataTable CoverInfo = ucCase_First.GetCoverInfo();
                            #region 病人信息的必填项检查
                            DataRow dr = CoverInfo.Rows[0];
                            #endregion

                            // 获取诊断信息
                            DataTable Diagnose = ucCase_First.GetCoverDiagnose();
                            #region 主要诊断必须填写入院病情和转归情况
                            dr = Diagnose.Rows[0];
                            #endregion


                            // 获取手术信息
                            DataTable Operation = ucCase_First.GetOperation();

                            // 获取病案质量信息
                            DataTable Quality = ucCase_First.GetQuality();

                            // 获取病案首页的一些杂项
                            DataTable Temp = ucCase_First.GetTemp();
                            dr = Temp.Rows[0];
                            #region 杂项表的必填项控制
                            #endregion

                            DataTable cost = ucCase_First.GetCost();

                            // 构造 DataSet
                            DataSet ds_case = new DataSet();
                            ds_case.Tables.Add(CoverInfo);
                            ds_case.Tables.Add(Diagnose);
                            ds_case.Tables.Add(Operation);
                            ds_case.Tables.Add(Quality);
                            ds_case.Tables.Add(Temp);
                            ds_case.Tables.Add(cost);

                            Ucprint ucprint = new Ucprint(ds_case, inpatient, node.Name, "");
                            ucprint.Dock = DockStyle.Fill;
                            App.UsControlStyle(ucprint);
                            tabctpnDoc.Controls.Add(ucprint);
                        }
                        App.SetToolButtonByUser("tsbtnCommit", false);
                        //App.UsControlStyle(ucCase_First);
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "ucfrmsickreport")
                    {
                        ucfrmSickReport ucsickReport = new ucfrmSickReport();
                        tabctpnDoc.Controls.Add(ucsickReport);
                        ucsickReport.Dock = DockStyle.Fill;
                        App.UsControlStyle(ucsickReport);
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "ucpatientinfo")
                    {

                        page.Tooltip = "N";
                        if (App.UserAccount.CurrentSelectRole.Role_type == "D")
                        {
                            UcPatientInfo ucpatientInfo = new UcPatientInfo(inpatient);
                            tabctpnDoc.Controls.Add(ucpatientInfo);
                            ucpatientInfo.Dock = DockStyle.Fill;
                        }
                        else if (App.UserAccount.CurrentSelectRole.Role_type == "N")
                        {
                            UcPatientInfo ucpatientInfo = new UcPatientInfo(inpatient);
                            tabctpnDoc.Controls.Add(ucpatientInfo);
                            ucpatientInfo.Dock = DockStyle.Fill;
                        }
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "expectantrecord")
                    {

                        page.Tooltip = "N";
                        string pid = inpatient.PId;
                        string area_Name = inpatient.Sick_Area_Name;
                        string bed_N0 = inpatient.Sick_Bed_Name;
                        string pName = inpatient.Patient_Name;
                        string id = inpatient.Id.ToString();
                        ExpectantRecord exRecord = new ExpectantRecord(pid, area_Name, bed_N0, pName, id);
                        tabctpnDoc.Controls.Add(exRecord);
                        exRecord.Dock = DockStyle.Fill;
                        App.UsControlStyle(exRecord);
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "ucdiagnosis_certificate")//诊断证明书
                    {

                        ucDIAGNOSIS_CERTIFICATE ucprint = new ucDIAGNOSIS_CERTIFICATE(inpatient);
                        ucprint.Dock = DockStyle.Fill;
                        App.UsControlStyle(ucprint);
                        tabctpnDoc.Controls.Add(ucprint);
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "ucheart_pic")//心电示波记录单
                    {

                        ucHeart_PIC ucHeart = new ucHeart_PIC(inpatient.Sick_Bed_Name, inpatient.Patient_Name, inpatient.PId, inpatient.Id.ToString(), inpatient.Section_Name);
                        ucHeart.Dock = DockStyle.Fill;
                        App.UsControlStyle(ucHeart);
                        tabctpnDoc.Controls.Add(ucHeart);
                        isCustom = true;
                    }
                    else if (ctext.Formname.ToLower() == "uodinopoeia_record")//中期妊娠引产产后病程记录881
                    {

                        page.Tooltip = "N";
                        string pid = inpatient.PId;
                        string area_Name = inpatient.Sick_Area_Name;
                        string bed_N0 = inpatient.Sick_Bed_Name;
                        string pName = inpatient.Patient_Name;
                        string id = inpatient.Id.ToString();
                        UOdinopoeia_Record uo_record = new UOdinopoeia_Record(pid, area_Name, bed_N0, pName, id);
                        tabctpnDoc.Controls.Add(uo_record);
                        uo_record.Dock = DockStyle.Fill;
                        App.UsControlStyle(uo_record);
                        isCustom = true;
                    }
                    else
                    {
                        page.Dispose();
                        tabctpnDoc.Dispose();
                        IsHave = false;
                        App.Msg("定制文书没有确定对应的功能模块,请于管理员联系,在文书类型管理中进行设置！");

                    }
                }
                else
                {
                    IsHave = false;
                }
            }
            if (IsHave == true)
            {
                tabctpnDoc.TabItem = page;
                tabctpnDoc.Dock = DockStyle.Fill;
                page.AttachedControl = tabctpnDoc;
                this.tctlDoc.Controls.Add(tabctpnDoc);
                this.tctlDoc.Tabs.Add(page);
                this.tctlDoc.Refresh();
                this.tctlDoc.SelectedTab = page;
                isCustom = true;
            }
            //else
            //{
            //    tabctpnDoc.Dispose();
            //    page.Dispose();
            //}
            return IsHave;
        }



        /// <summary>
        ///  判断文书下面是否有相同名称的文书。
        /// </summary>
        /// <returns></returns>
        private bool IsSameBookDoc()
        {
            bool flag = false;
            //InPatientInfo inpatient = GetInpatientByBedId(trvInpatientManager.Nodes, dtlBedNumber.SelectedValue.ToString());
            if (this.currentPatient != null)
            {
                Node node = DataInit.SelectDoc(currentPatient.Id, NowTree.SelectedNode.Name);
                //当前创建文书的名称
                string new_TextName = Record_Time + "   " + Record_Content;
                foreach (Node childNode in node.Nodes)
                {
                    Patient_Doc pdoc = childNode.Tag as Patient_Doc;
                    //已经存在该类文书的名称
                    string old_TextName = pdoc.Docname;
                    //if (new_TextName.Equals(old_TextName))
                    if (old_TextName.Contains(Record_Time))
                    {
                        flag = true;
                        App.Msg("已经存在相同的文书！");
                        break;
                    }
                }
            }
            return flag;
        }

        /// <summary>
        /// 文书提交后刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReflashTrvBookEvent(object sender, EventArgs e)
        {
            // App.SetToolButtonByUser("tsbtnTempSave",false);            
            if (advFinishDoc.SelectedNode != null)
            {
                CurrentNode = advFinishDoc.SelectedNode;
                string name = "";
                if (sender.GetType().ToString().Contains("ButtonItem"))
                {
                    name = (((ButtonItem)sender).Text);
                }

                if (name.Contains("提交"))
                {
                    App.SetToolButtonByUser("tsbtnTempSave", false);
                    int tid = 0;
                    string sql = "";
                    //("Patient_Doc"))//多例文书

                    //("Class_Text"))//单例文书

                    frmText tempEditor = tctlDoc.SelectedPanel.Controls[0] as frmText;
                    if (tempEditor != null)
                    {
                        sql = "select submitted from t_patients_doc where TID='" + tempEditor.MyDoc.Us.Tid + "' and patient_id='" + tempEditor.MyDoc.Us.InpatientInfo.Id + "'";
                        string isSubmitted = Convert.ToString(App.ReadSqlVal(sql, 0, "submitted"));
                        if (isSubmitted == "Y")
                        {//已经提交
                            //App.SetToolButtonByUser("tsbtnCommit", true);//提交

                            //try
                            //{
                            //    //更新质控提醒
                            //    if (backgroundWorker1.IsBusy)
                            //    {
                            //    }
                            //    else
                            //    {
                            //        backgroundWorker1.RunWorkerAsync();
                            //    }
                            //}
                            //catch (System.Exception ex)
                            //{

                            //}
                        }
                        else
                        {//未提交或暂存
                            App.SetToolButtonByUser("tsbtnTempSave", true);//暂存
                        }
                    }
                }
            }
            ReflashTrvBook();
            //刷新节点
            //SetSelectNode(advFinishDoc.Nodes);
            //SelectedNodeByTid(advFinishDoc.Nodes, Update_Tid);
            //展开当前选中的节点
            //ExpendTree(advFinishDoc.SelectedNode);
        }


    }
}
