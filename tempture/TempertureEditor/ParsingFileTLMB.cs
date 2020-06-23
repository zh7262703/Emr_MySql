using Bifrost;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using TempertureEditor.EditDesigner.tlElement;

namespace TempertureEditor.EditDesigner
{
    class ParsingFileTLMB
    {
        private delegate void EventSubHandler(params Control[] controls);

        private XmlDocument _xmlDoc = new XmlDocument();
        private string _tlmbFileName = "";
        private int ggenid = 0; //自动生成主键
        //private List<string> listWriteTimes = new List<string>();
        private List<TlFont> listTlFonts = new List<TlFont>();
        //private List<TlEventHandler> listTlEventHandlers = new List<TlEventHandler>();
        private Dictionary<string, EventSubHandler> dicEventHandlers= new Dictionary<string, EventSubHandler>();
        private Dictionary<string, string> dicVars = new Dictionary<string, string>();
        private List<TlControl> listTlControls = new List<TlControl>();
        public List<Control> listWinControls = new List<Control>();

        public ParsingFileTLMB()
        {
            //注册接口:增加特殊控件处理函数后,在此添加新函数至容器
            dicEventHandlers.Clear();
            dicEventHandlers.Add("testClick", testClick);
            dicEventHandlers.Add("dateTimePicker_Select_ValueChanged", dateTimePicker_Select_ValueChanged);
            dicEventHandlers.Add("cboTime_SelectedIndexChanged", cboTime_SelectedIndexChanged);
            dicEventHandlers.Add("btn_up_Click", btn_up_Click);
            dicEventHandlers.Add("btn_next_Click", btn_next_Click);
            dicEventHandlers.Add("ControlTemperatureVisable", ControlTemperatureVisable);
            dicEventHandlers.Add("ckChu_CheckedChanged", ckChu_CheckedChanged);
            dicEventHandlers.Add("ListBoxAddItem", ListBoxAddItem);
            dicEventHandlers.Add("ListBoxRemoveItem", ListBoxRemoveItem);
            dicEventHandlers.Add("btnSure_Click", btnSure_Click);
            dicEventHandlers.Add("btnCancel_Click", btnCancel_Click);
        }

        internal void ParsingXml(string tlmbFileName)
        {
            _tlmbFileName = App.SysPath + "\\" + tlmbFileName;
            _xmlDoc.Load(_tlmbFileName);
            XmlNodeList xmlNodeList;

            ggenid = Convert.ToInt32(_xmlDoc.DocumentElement.Attributes["Genid"].Value);

            /*
            //初始化树节点
            listWriteTimes.Clear();
            xmlNodeList = _xmlDoc.GetElementsByTagName("ClsWriteTimes");
            foreach (XmlNode tempxmlnode in xmlNodeList)
            {
                string[] strs = tempxmlnode.InnerText.Split(',');
                listWriteTimes = new List<string>(strs);
            }
            */
            //变量信息
            dicVars.Clear();
            xmlNodeList = _xmlDoc.GetElementsByTagName("Var");
            foreach (XmlNode tempxmlnode in xmlNodeList)
            {
                string name = tempxmlnode.Attributes["Name"].Value;
                string value = tempxmlnode.Attributes["Value"].Value;
                dicVars.Add(name, value);

            }
            
            //字体信息
            listTlFonts.Clear();
            xmlNodeList = _xmlDoc.GetElementsByTagName("Font");
            foreach (XmlNode tempxmlnode in xmlNodeList)
            {
                TlFont tlFont = new TlFont();
                tlFont.Name = tempxmlnode.Attributes["Name"].Value;
                tlFont.FamilyName = tempxmlnode.Attributes["FamilyName"].Value;
                tlFont.EmSize = (float)Convert.ToDouble(tempxmlnode.Attributes["Size"].Value);
                tlFont.Style = Convert.ToInt32(tempxmlnode.Attributes["Style"].Value);
                listTlFonts.Add(tlFont);

            }

            /*
            //事件处理
            listTlEventHandlers.Clear();
            xmlNodeList = _xmlDoc.GetElementsByTagName("EventHandler");
            foreach (XmlNode tempxmlnode in xmlNodeList)
            {
                TlEventHandler tlEventHandler = new TlEventHandler();
                tlEventHandler.Name = tempxmlnode.Attributes["Name"].Value;
                string paramTypes = tempxmlnode.Attributes["paramTypes"].Value;
                tlEventHandler.ListParamTypes.Clear();
                tlEventHandler.ListParamTypes.AddRange(paramTypes.Split(','));
                listTlEventHandlers.Add(tlEventHandler);

            }
            */
            //控件信息
            listTlControls.Clear();

            //xmlNodeList = _xmlDoc.GetElementsByTagName("Controls");
            xmlNodeList = _xmlDoc.DocumentElement.ChildNodes;
            foreach (XmlNode clChildNode in xmlNodeList)
            {
                if (clChildNode.Name == "Controls")
                    ParsingControls(clChildNode, null);
            }
        }

        private void ParsingControls(XmlNode controlsNode, TlControl tlParentControl)
        {
            string type;
            foreach (XmlNode clNode in controlsNode.ChildNodes)
            {
                if (clNode.Name == "Control")
                {
                    TlControl tlControl = null;
                    type = clNode.Attributes["Type"].Value;

                    if (type == "GroupBox")
                    {
                        tlControl = new TlGroupBox();

                        ((TlGroupBox)tlControl).ForeColor = ColorTranslator.FromHtml(clNode.Attributes["ForeColor"].Value);
                        ((TlGroupBox)tlControl).Text = clNode.Attributes["Text"].Value;
                    }
                    else if (type == "Label")
                    {
                        tlControl = new TlLabel();

                        ((TlLabel)tlControl).ForeColor = ColorTranslator.FromHtml(clNode.Attributes["ForeColor"].Value);
                        ((TlLabel)tlControl).AutoSize = clNode.Attributes["AutoSize"].Value.ToString() == "true";
                        ((TlLabel)tlControl).Text = clNode.Attributes["Text"].Value;
                    }
                    else if (type == "ComboBox")
                    {
                        tlControl = new TlComboBox();

                        ((TlComboBox)tlControl).DropDownStyle = Convert.ToInt32(clNode.Attributes["DropDownStyle"].Value);
                        string items = clNode.Attributes["Items"].Value;
                        ((TlComboBox)tlControl).ListItems.Clear();
                        ((TlComboBox)tlControl).ListItems.AddRange(items.Split(','));

                    }
                    else if (type == "TextBox")
                    {
                        tlControl = new TlTextBox();
                    }
                    else if (type == "Button")
                    {
                        tlControl = new TlButton();
                        ((TlButton)tlControl).Text = clNode.Attributes["Text"].Value;
                    }
                    else if (type == "CheckBox")
                    {
                        tlControl = new TlCheckBox();

                        ((TlCheckBox)tlControl).ForeColor = ColorTranslator.FromHtml(clNode.Attributes["ForeColor"].Value);
                        ((TlCheckBox)tlControl).AutoSize = clNode.Attributes["AutoSize"].Value.ToString() == "true";
                        ((TlCheckBox)tlControl).Text = clNode.Attributes["Text"].Value;
                    }
                    else if (type == "ListBox")
                    {
                        tlControl = new TlListBox();
                    }
                    else if (type == "Panel")
                    {
                        tlControl = new TlPanel();

                        ((TlPanel)tlControl).AutoScroll = clNode.Attributes["AutoScroll"].Value.ToString() == "true";
                    }
                    else if (type == "DateTimePicker")
                    {
                        tlControl = new TlDateTimePicker();

                        ((TlDateTimePicker)tlControl).ShowUpDown = clNode.Attributes["ShowUpDown"].Value.ToString() == "true";
                        ((TlDateTimePicker)tlControl).Format = Convert.ToInt32(clNode.Attributes["Format"].Value);
                        ((TlDateTimePicker)tlControl).CustomFormat = clNode.Attributes["CustomFormat"].Value;
                    }
                    else
                    {
                        continue;   //未知或未实现的类型跳过
                    }

                    tlControl.TlParentControl = tlParentControl;
                    tlControl.Type = clNode.Attributes["Type"].Value;
                    tlControl.Name = clNode.Attributes["Name"].Value;
                    tlControl.X = Convert.ToInt32(clNode.Attributes["X"].Value);
                    tlControl.Y = Convert.ToInt32(clNode.Attributes["Y"].Value);
                    tlControl.Width = Convert.ToInt32(clNode.Attributes["Width"].Value);
                    tlControl.Height = Convert.ToInt32(clNode.Attributes["Height"].Value);
                    tlControl.TabIndex = Convert.ToInt32(clNode.Attributes["TabIndex"].Value);
                    tlControl.Visable = clNode.Attributes["Visable"].Value.ToString() == "true";
                    tlControl.Enable = clNode.Attributes["Enable"].Value.ToString() == "true";
                    tlControl.TabStop = clNode.Attributes["TabStop"].Value.ToString() == "true";
                    tlControl.FontName = clNode.Attributes["FontName"].Value;
                    tlControl.Dock = Convert.ToInt32(clNode.Attributes["Dock"].Value);

                    string []events = clNode.Attributes["Events"].Value.Split('|');
                    tlControl.DicEvents = new Dictionary<string, string>();
                    foreach (string et in events)
                    {
                        if (et.Trim() != "")
                        {
                            int pos = et.IndexOf(':');
                            string eventName = et.Substring(0, pos);
                            string eventHandler = et.Substring(pos + 1);
                            tlControl.DicEvents.Add(eventName, eventHandler);
                        }
                    }
                    listTlControls.Add(tlControl);

                    foreach (XmlNode clChildNode in clNode.ChildNodes)
                    {
                        if (clChildNode.Name == "Controls")
                            ParsingControls(clChildNode, tlControl);
                    }
                }
            }
        }
        /*
        #region 第1种实现方式
        public void CreateWinControls(Control dockWinControl)
        {
            dockWinControl.SuspendLayout();
            listWinControls.Clear();
            string type;
            foreach (TlControl tlControl in listTlControls)
            {
                Control winControl = null;
                type = tlControl.Type;

                if (type == "GroupBox")
                {
                    winControl = new GroupBox();
                    winControl.SuspendLayout();

                    ((GroupBox)winControl).ForeColor = ((TlGroupBox)tlControl).ForeColor;
                    ((GroupBox)winControl).Text = ((TlGroupBox)tlControl).Text;
                }
                else if (type == "Label")
                {
                    winControl = new Label();

                    ((Label)winControl).ForeColor = ((TlLabel)tlControl).ForeColor;
                    ((Label)winControl).AutoSize = ((TlLabel)tlControl).AutoSize;
                    ((Label)winControl).Text = ((TlLabel)tlControl).Text;
                }
                else if (type == "ComboBox")
                {
                    winControl = new ComboBox();

                    ((ComboBox)winControl).DropDownStyle = (ComboBoxStyle)((TlComboBox)tlControl).DropDownStyle;
                    ((ComboBox)winControl).Items.AddRange(((TlComboBox)tlControl).ListItems.ToArray());

                }
                else if (type == "TextBox")
                {
                    winControl = new TextBox();
                }
                else if (type == "Button")
                {
                    winControl = new Button();
                    ((Button)winControl).Text = ((TlButton)tlControl).Text;
                }
                else if (type == "CheckBox")
                {
                    winControl = new CheckBox();

                    ((CheckBox)winControl).ForeColor = ((TlCheckBox)tlControl).ForeColor;
                    ((CheckBox)winControl).AutoSize = ((TlCheckBox)tlControl).AutoSize;
                    ((CheckBox)winControl).Text = ((TlCheckBox)tlControl).Text;
                }
                else if (type == "ListBox")
                {
                    winControl = new ListBox();
                }
                else if (type == "Panel")
                {
                    winControl = new Panel();
                    winControl.SuspendLayout();
                }
                else if (type == "DateTimePicker")
                {
                    winControl = new DateTimePicker();

                    ((DateTimePicker)winControl).ShowUpDown = ((TlDateTimePicker)tlControl).ShowUpDown;
                    ((DateTimePicker)winControl).Format = (DateTimePickerFormat)((TlDateTimePicker)tlControl).Format;
                    ((DateTimePicker)winControl).CustomFormat = ((TlDateTimePicker)tlControl).CustomFormat;
                }

                if (winControl != null)
                {                   
                    winControl.Name = tlControl.Name;
                    winControl.Location = new Point(tlControl.X, tlControl.Y);
                    winControl.Size = new Size(tlControl.Width, tlControl.Height);
                    winControl.TabIndex = tlControl.TabIndex;
                    winControl.Visible = tlControl.Visable;
                    winControl.Enabled = tlControl.Enable;
                    winControl.TabStop = tlControl.TabStop;
                    winControl.Dock = (DockStyle)tlControl.Dock;

                    foreach (TlFont tlFont in listTlFonts)
                    {
                        if (tlControl.FontName == tlFont.Name)
                        {
                            winControl.Font = new Font(tlFont.FamilyName, tlFont.EmSize, (FontStyle)tlFont.Style);
                            break;
                        }
                    }

                    listWinControls.Add(winControl);

                }
            }

            //遍历处理控件Controls.Add();
            foreach (Control winControl in listWinControls)
            {
                foreach (TlControl tlControl in listTlControls)
                {
                    if (winControl.Name == tlControl.Name)
                    {
                        foreach (Control winParentControl in listWinControls)
                        {
                            if (tlControl.TlParentControl == null)
                            {
                                if (!dockWinControl.Controls.Contains(winControl))
                                {
                                    dockWinControl.Controls.Add(winControl);
                                }
                                break;
                            }
                            else if (winParentControl.Name == tlControl.TlParentControl.Name)
                            {
                                winParentControl.Controls.Add(winControl);
                                break;
                            }
                        }
                        break;
                    }
                }
            }


            foreach (Control winControl in listWinControls)
            {
                foreach (TlControl tlControl in listTlControls)
                {
                    if (winControl.Name == tlControl.Name)
                    {
                        if (tlControl.Type == "Panel" || tlControl.Type == "GroupBox")
                        {
                            winControl.ResumeLayout(true);
                            break;
                        }
                    }
                }
            }
            dockWinControl.ResumeLayout(false);
        }
        #endregion
        */

        #region 第2种实现方式, 要求:listTlControlst和listWinControls一一对应,效率更高
        public void CreateWinControls(Control dockWinControl)
        {
            //dockWinControl.SuspendLayout();
            listWinControls.Clear();
            string type;
            for (int i = 0; i < listTlControls.Count; i++)
            {
                Control winControl = null;
                type = listTlControls[i].Type;

                if (type == "GroupBox")
                {
                    winControl = new GroupBox();
                    //winControl.SuspendLayout();

                    ((GroupBox)winControl).ForeColor = ((TlGroupBox)listTlControls[i]).ForeColor;
                    ((GroupBox)winControl).Text = ((TlGroupBox)listTlControls[i]).Text;
                }
                else if (type == "Label")
                {
                    winControl = new Label();

                    ((Label)winControl).ForeColor = ((TlLabel)listTlControls[i]).ForeColor;
                    ((Label)winControl).AutoSize = ((TlLabel)listTlControls[i]).AutoSize;
                    ((Label)winControl).Text = ((TlLabel)listTlControls[i]).Text;
                }
                else if (type == "ComboBox")
                {
                    winControl = new ComboBox();

                    ((ComboBox)winControl).DropDownStyle = (ComboBoxStyle)((TlComboBox)listTlControls[i]).DropDownStyle;
                    ((ComboBox)winControl).Items.AddRange(((TlComboBox)listTlControls[i]).ListItems.ToArray());

                    if (listTlControls[i].DicEvents.ContainsKey("SelectedIndexChanged"))
                    {
                        ((ComboBox)winControl).SelectedIndexChanged += new EventHandler(controlEvent_SelectedIndexChanged);
                    }
                }
                else if (type == "TextBox")
                {
                    winControl = new TextBox();
                   
                }
                else if (type == "Button")
                {
                    winControl = new Button();
                    ((Button)winControl).Text = ((TlButton)listTlControls[i]).Text;
                }
                else if (type == "CheckBox")
                {
                    winControl = new CheckBox();

                    ((CheckBox)winControl).ForeColor = ((TlCheckBox)listTlControls[i]).ForeColor;
                    ((CheckBox)winControl).AutoSize = ((TlCheckBox)listTlControls[i]).AutoSize;
                    ((CheckBox)winControl).Text = ((TlCheckBox)listTlControls[i]).Text;

                    ((CheckBox)winControl).CheckedChanged += new EventHandler(controlEvent_CheckedChanged);
                }
                else if (type == "ListBox")
                {
                    winControl = new ListBox();
                }
                else if (type == "Panel")
                {
                    winControl = new Panel();
                    //winControl.SuspendLayout();

                    ((Panel)winControl).AutoScroll = ((TlPanel)listTlControls[i]).AutoScroll;
                }
                else if (type == "DateTimePicker")
                {
                    winControl = new DateTimePicker();

                    ((DateTimePicker)winControl).ShowUpDown = ((TlDateTimePicker)listTlControls[i]).ShowUpDown;
                    ((DateTimePicker)winControl).Format = (DateTimePickerFormat)((TlDateTimePicker)listTlControls[i]).Format;
                    ((DateTimePicker)winControl).CustomFormat = ((TlDateTimePicker)listTlControls[i]).CustomFormat;

                    if (listTlControls[i].DicEvents.ContainsKey("ValueChanged"))
                    {
                        ((DateTimePicker)winControl).ValueChanged += new EventHandler(controlEvent_ValueChanged);
                    }
                }

                if (winControl != null)
                {
                    winControl.Name = listTlControls[i].Name;
                    winControl.Location = new Point(listTlControls[i].X, listTlControls[i].Y);
                    winControl.Size = new Size(listTlControls[i].Width, listTlControls[i].Height);
                    winControl.TabIndex = listTlControls[i].TabIndex;
                    winControl.Visible = listTlControls[i].Visable;
                    winControl.Enabled = listTlControls[i].Enable;
                    winControl.TabStop = listTlControls[i].TabStop;
                    foreach (TlFont tlFont in listTlFonts)
                    {
                        if (listTlControls[i].FontName == tlFont.Name)
                        {
                            winControl.Font = new Font(tlFont.FamilyName, tlFont.EmSize, (FontStyle)tlFont.Style);
                            break;
                        }
                    }
                    winControl.Dock = (DockStyle)listTlControls[i].Dock;

                    // 注: 不能使用if/else,因为同个控件可能要处理多个事件
                    if (listTlControls[i].DicEvents.ContainsKey("Click"))
                    {
                        winControl.Click += new EventHandler(controlEvent_Click);
                    }

                    if (listTlControls[i].DicEvents.ContainsKey("TextChanged"))
                    {
                        winControl.TextChanged += new EventHandler(controlEvent_TextChanged);
                    }

                    listWinControls.Add(winControl);

                }
            }

            //遍历处理控件Controls.Add(); 当同一DockStyle时,如都为DockStyle.Top时,倒序Add才能按配置文件的正序展示
            for (int i = listWinControls.Count - 1; i >= 0; i--)
            {
                Control winControl = listWinControls[i];

                if (listTlControls[i].TlParentControl == null)
                {
                    if (!dockWinControl.Controls.Contains(winControl))
                    {
                        dockWinControl.Controls.Add(winControl);
                    }
                }
                else
                {
                    foreach (Control winParentControl in listWinControls)
                    {
                        if (winParentControl.Name == listTlControls[i].TlParentControl.Name)
                        {
                            winParentControl.Controls.Add(winControl);
                            break;
                        }
                    }
                }
            }

            /*
            for (int i = listWinControls.Count - 1; i >= 0 ; i--)
            {
                Control winControl = listWinControls[i];
                if (listTlControls[i].Type == "Panel" || listTlControls[i].Type == "GroupBox")
                {
                    winControl.ResumeLayout(true);
                    break;
                }
            }
            */
            //dockWinControl.ResumeLayout(false);
            
        }
        #endregion



        /*
        #region 处理事件
        private void controlEvent(object sender, EventArgs e)
        {
            Control winControl = (Control)sender;
            int index = listWinControls.FindIndex(cl=>cl.Name == winControl.Name);

            if (index >= 0 && index < listWinControls.Count)
            {
                string type = listTlControls[index].Type;
                if (type == "GroupBox")
                {
                    winControl = new GroupBox();
                 
                }
                else if (type == "Label")
                {
                    winControl = new Label();

                 
                }
                else if (type == "ComboBox")
                {
                    winControl = new ComboBox();

                   
                }
                else if (type == "TextBox")
                {
                    winControl = new TextBox();
                }
                else if (type == "Button")
                {
                    Button button = (Button)sender;
                }
                else if (type == "CheckBox")
                {
                    winControl = new CheckBox();

                }
                else if (type == "ListBox")
                {
                    winControl = new ListBox();
                }
                else if (type == "Panel")
                {
                    winControl = new Panel();
              
                }
                else if (type == "DateTimePicker")
                {
                }
            }
        }
        #endregion
    */
        #region 处理单击事件
      
        private void controlEvent_Click(object sender, EventArgs e)
        {
            EventHnadler("Click", (Control)sender);
        }

        private void controlEvent_TextChanged(object sender, EventArgs e)
        {
            EventHnadler("TextChanged", (Control)sender);
        }

        private void controlEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            EventHnadler("SelectedIndexChanged", (Control)sender);
        }

        private void controlEvent_ValueChanged(object sender, EventArgs e)
        {
            EventHnadler("ValueChanged", (Control)sender);
        }

        private void controlEvent_CheckedChanged(object sender, EventArgs e)
        {
            EventHnadler("CheckedChanged", (Control)sender);
        }
        #endregion

        #region EventHandler
        private void testClick(params Control[] controls)
        {
            System.Windows.Forms.MessageBox.Show("test click");
        }

        private void dateTimePicker_Select_ValueChanged(params Control[] controls)
        {
            System.Windows.Forms.MessageBox.Show("dateTimePicker_Select_ValueChanged");
        }

        private void cboTime_SelectedIndexChanged(params Control[] controls)
        {
            System.Windows.Forms.MessageBox.Show("cboTime_SelectedIndexChanged");
        }
        private void btn_up_Click(params Control[] controls)
        {
            ComboBox cboPageIndex = (ComboBox)controls[0];
            if (cboPageIndex.SelectedIndex != -1 && cboPageIndex.Items.Count > 0)
            {
                if (cboPageIndex.SelectedIndex != 0)
                {
                    cboPageIndex.SelectedIndex -= 1;
                }
                else
                {
                    App.Msg("已经是第一页！");
                }
            }
        }

        private void btn_next_Click(params Control[] controls)
        {
            ComboBox cboPageIndex = (ComboBox)controls[0];
            if (cboPageIndex.SelectedIndex != -1 && cboPageIndex.Items.Count > 0)
            {
                if (cboPageIndex.SelectedIndex != cboPageIndex.Items.Count - 1)
                {
                    cboPageIndex.SelectedIndex += 1;
                }
                else
                {
                    App.Msg("已经是最后一页！");
                }
            }
        }

        private void ControlTemperatureVisable(params Control[] controls)
        {
            float highTemper = float.Parse(dicVars["HighTemper"]);
            TextBox txtTemper = (TextBox)controls[0];
            TextBox txtDown = (TextBox)controls[1];
            Label lbDown = (Label)controls[2];

            if (txtTemper.Text.Trim() != "")
            {
                txtDown.Visible = lbDown.Visible = (float.Parse(txtTemper.Text) >= highTemper);
                txtDown.Enabled = lbDown.Enabled = (float.Parse(txtTemper.Text) >= highTemper);
            }
        }

        private void ckChu_CheckedChanged(params Control[] controls)
        {
            CheckBox ckChu = (CheckBox)controls[0];
            TextBox txtHeart = (TextBox)controls[1];
            CheckBox ckHeartRate = (CheckBox)controls[2];

            if (!ckChu.Checked)
                txtHeart.Text = "";
            txtHeart.Enabled = ckChu.Checked;
            ckHeartRate.Enabled = ckChu.Checked;
        }

        private void ListBoxAddItem(params Control[] controls)
        {
            ListBox listBox = (ListBox)controls[0];
            ComboBox comboBox = (ComboBox)controls[1];

            if (comboBox.Text.Trim() != "")
            {
                listBox.Items.Add(comboBox.Text);
            }

        }

        private void ListBoxRemoveItem(params Control[] controls)
        {
            ListBox listBox = (ListBox)controls[0];

            if (listBox.Items.Count > 0)
            {
                if (listBox.SelectedItem != null)
                {
                    listBox.Items.Remove(listBox.SelectedItem);
                }
            }
        }

        private void btnSure_Click(params Control[] controls)
        {
        }

        private void btnCancel_Click(params Control[] controls)
        {
        }
        #endregion

        private void EventHnadler(string eventName, Control winControl)
        {
            int index = listWinControls.IndexOf(winControl);
            if (index >= 0 && index < listWinControls.Count)
            {
                TlControl tlControl = listTlControls[index];

                if (!tlControl.DicEvents.ContainsKey(eventName))
                {
                    // 当配置文件中的该控件未处理eventName对应的事件,直接跳过.
                    return;
                }
                string value = tlControl.DicEvents[eventName];
                int pos = value.IndexOf('(');
                if (pos >= 0)
                {
                    string funName = value.Substring(0, pos);
                    string[] funParams = value.Substring(pos + 1, value.Length - pos - 2).Split(',');//最后字符为')'
                    List<Control> listControls = new List<Control>();
                    foreach (string funParam in funParams)
                    {
                        foreach (Control cl in listWinControls)
                        {
                            if (cl.Name == funParam)
                            {
                                listControls.Add(cl);
                                break;
                            }
                        }
                    }
                    dicEventHandlers[funName](listControls.ToArray());
                   
                }

            }

        }
    }
}
