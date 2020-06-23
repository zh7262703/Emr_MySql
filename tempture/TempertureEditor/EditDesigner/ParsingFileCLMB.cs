using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Xml;
using TempertureEditor.EditDesigner.tlElement;

namespace TempertureEditor.EditDesigner
{
    class ParsingFileCLMB
    {
        private XmlDocument _xmlDoc = new XmlDocument();
        private int ggenid = 0; //自动生成主键
        private string _templateType = "";        //模板类型
        public List<TlFont> listTlFonts = new List<TlFont>();
        //public List<TlEventHandler> listTlEventHandlers = new List<TlEventHandler>();
        public Dictionary<string, string> dicCustomEventHandlers = new Dictionary<string, string>();
        public Dictionary<string, string> dicVars = new Dictionary<string, string>();
        public List<TlControl> listTlControls = new List<TlControl>();

        public string TemplateType
        {
            get
            {
                return _templateType;
            }
            /*
            set
            {
                _templateType = value;
            }
            */
        }

        public ParsingFileCLMB()
        {
           
        }

        internal void ParsingXml(string clmbFileName)
        {
            _xmlDoc.Load(clmbFileName);
            XmlNodeList xmlNodeList;

            ggenid = Convert.ToInt32(_xmlDoc.DocumentElement.Attributes["Genid"].Value);

            XmlAttribute xmlAttribute = _xmlDoc.DocumentElement.Attributes["TemplateType"];
            if (xmlAttribute != null)
            {
                _templateType = xmlAttribute.Value.ToString();
            }
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


            //自定义事件处理
            dicCustomEventHandlers.Clear();
            xmlNodeList = _xmlDoc.GetElementsByTagName("CustomEventHandler");
            foreach (XmlNode tempxmlnode in xmlNodeList)
            {
                string name = tempxmlnode.Attributes["Name"].Value;
                string handler = tempxmlnode.Attributes["Handler"].Value;
                dicCustomEventHandlers.Add(name, handler);
            }
            
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
                        //((TlGroupBox)tlControl).Text = clNode.Attributes["Text"].Value;

                    }
                    else if (type == "Label")
                    {
                        tlControl = new TlLabel();

                        ((TlLabel)tlControl).ForeColor = ColorTranslator.FromHtml(clNode.Attributes["ForeColor"].Value);
                        ((TlLabel)tlControl).AutoSize = clNode.Attributes["AutoSize"].Value.ToString() == "true";
                        //((TlLabel)tlControl).Text = clNode.Attributes["Text"].Value;
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
                    }
                    else if (type == "ButtonX")
                    {
                        tlControl = new TlButtonX();

                        if (clNode.Attributes["Image"] != null)
                        {
                            ((TlButtonX)tlControl).Image = clNode.Attributes["Image"].Value;
                        }
                    }
                    else if (type == "CheckBox")
                    {
                        tlControl = new TlCheckBox();

                        ((TlCheckBox)tlControl).ForeColor = ColorTranslator.FromHtml(clNode.Attributes["ForeColor"].Value);
                        ((TlCheckBox)tlControl).AutoSize = clNode.Attributes["AutoSize"].Value.ToString() == "true";
                        //((TlCheckBox)tlControl).Text = clNode.Attributes["Text"].Value;
                        ((TlCheckBox)tlControl).Checked = clNode.Attributes["Checked"].Value == "true";
                    }
                    else if (type == "RadioButton")
                    {
                        tlControl = new TlRadioButton();

                        ((TlRadioButton)tlControl).ForeColor = ColorTranslator.FromHtml(clNode.Attributes["ForeColor"].Value);
                        ((TlRadioButton)tlControl).AutoSize = clNode.Attributes["AutoSize"].Value.ToString() == "true";
                        //((TlRadioButton)tlControl).Text = clNode.Attributes["Text"].Value;
                        ((TlRadioButton)tlControl).Checked = clNode.Attributes["Checked"].Value == "true";
                        if (clNode.Attributes["UseVisualStyleBackColor"] != null)
                        {
                            ((TlRadioButton)tlControl).UseVisualStyleBackColor = clNode.Attributes["UseVisualStyleBackColor"].Value == "true";
                        }
                    }
                    else if (type == "ListBox")
                    {
                        tlControl = new TlListBox();
                    }
                    else if (type == "Panel" || type == "PanelControl" || type == "GroupPanel")
                    {
                        if (type == "Panel")
                        {
                            tlControl = new TlPanel();
                        }
                        else
                        {
                            if (type == "PanelControl")
                            {
                                tlControl = new TlPanelControl();
                            }
                            else
                            {
                                if (type == "GroupPanel")
                                {
                                    tlControl = new TlGroupPanel();
                                }
                                else
                                {

                                }
                            }
                            ((TlPanelControl)tlControl).ShowFocusRectangle = clNode.Attributes["ShowFocusRectangle"].Value.ToString() == "true";
                            ((TlPanelControl)tlControl).ColorSchemeStyle = Convert.ToInt32(clNode.Attributes["ColorSchemeStyle"].Value.ToString());
                            if (clNode.Attributes["CanvasColor"] != null)
                            {
                                ((TlPanelControl)tlControl).CanvasColor = ColorTranslator.FromHtml(clNode.Attributes["CanvasColor"].Value);
                            }
                        }

                        ((TlPanel)tlControl).AutoScroll = clNode.Attributes["AutoScroll"].Value.ToString() == "true";

                    }
                    else if (type == "DateTimePicker")
                    {
                        tlControl = new TlDateTimePicker();

                        ((TlDateTimePicker)tlControl).ShowUpDown = clNode.Attributes["ShowUpDown"].Value.ToString() == "true";
                        ((TlDateTimePicker)tlControl).Format = Convert.ToInt32(clNode.Attributes["Format"].Value);
                        ((TlDateTimePicker)tlControl).CustomFormat = clNode.Attributes["CustomFormat"].Value;
                    }
                    else if (type == "PictureBox")
                    {
                        tlControl = new TlPictureBox();

                        ((TlPictureBox)tlControl).BackColor = ColorTranslator.FromHtml(clNode.Attributes["BackColor"].Value);
                    }
                    else if (type == "ExpandableSplitter")
                    {
                        tlControl = new TlExpandableSplitter();

                        ((TlExpandableSplitter)tlControl).Style = Convert.ToInt32(clNode.Attributes["Style"].Value);
                        ((TlExpandableSplitter)tlControl).ExpandableControl = clNode.Attributes["ExpandableControl"].Value.ToString();
                    }
                    else if (type == "AdvTree")
                    {
                        tlControl = new TlAdvTree();

                        ((TlAdvTree)tlControl).ForeColor = ColorTranslator.FromHtml(clNode.Attributes["ForeColor"].Value);
                        ((TlAdvTree)tlControl).AllowDrop = clNode.Attributes["AllowDrop"].Value.ToString() == "true";
                    }
                    else if (type == "Slider")
                    {
                        tlControl = new TlSlider();

                        ((TlSlider)tlControl).Maximum = Convert.ToInt32(clNode.Attributes["Maximum"].Value);
                        ((TlSlider)tlControl).Minimum = Convert.ToInt32(clNode.Attributes["Minimum"].Value);
                        ((TlSlider)tlControl).Value = Convert.ToInt32(clNode.Attributes["Value"].Value);
                    }
                    else if (type == "ucAiTemperature")
                    {
                        tlControl = new TlAiTemperature();
                        ((TlAiTemperature)tlControl).ClmbFileName = clNode.Attributes["ClmbFileName"].Value.ToString();
                    }
                    else if (type == "ucTemperatureReport")
                    {
                        tlControl = new TlTemperatureReport();
                        ((TlTemperatureReport)tlControl).TmbFileName = clNode.Attributes["TmbFileName"].Value.ToString();
                    }
                    else if (type == "RibbonBar")
                    {
                        tlControl = new TlRibbonBar();

                        ((TlRibbonBar)tlControl).Style = Convert.ToInt32(clNode.Attributes["Style"].Value);
                        ((TlRibbonBar)tlControl).TitleVisible = clNode.Attributes["TitleVisible"].Value.ToString() == "true";
                        ((TlRibbonBar)tlControl).AutoOverflowEnabled = clNode.Attributes["AutoOverflowEnabled"].Value.ToString() == "true";
                        ((TlRibbonBar)tlControl).ContainerControlProcessDialogKey = clNode.Attributes["ContainerControlProcessDialogKey"].Value.ToString() == "true";
                        if (clNode.Attributes["Items"] != null)
                        {
                            string items = clNode.Attributes["Items"].Value;
                            ((TlRibbonBar)tlControl).ListItems.Clear();
                            ((TlRibbonBar)tlControl).ListItems.AddRange(items.Split(','));
                        }

                    }
                    else
                    {
                        //continue;   //未知或未实现的类型跳过
                        tlControl = new TlControl();
                    }

                    tlControl.TlParentControl = tlParentControl;
                    if (clNode.Attributes["BackColor"] != null)
                    {
                        tlControl.BackColor = ColorTranslator.FromHtml(clNode.Attributes["BackColor"].Value);
                    }
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

                    if (clNode.Attributes["Text"] != null)
                    {
                        tlControl.Text = clNode.Attributes["Text"].Value;
                    }

                    string[]events = clNode.Attributes["Events"].Value.Split('|');
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
 
    }
}
