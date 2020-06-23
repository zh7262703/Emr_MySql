using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace Base_Function.BASE_COMMON
{
    public enum SelectionTypes
    { 
        清空,
        反选,
        全选
    }

    [ProvideProperty("SelectionSource",typeof(Control))]
    [ProvideProperty("SelectionType",typeof(Control))]
    public partial class SelectForCSC : Component,IExtenderProvider
    {
        
        private Dictionary<Control, Control> buttonDict;
        private Dictionary<Control, SelectionTypes> functionDict;

        public SelectForCSC():this(null) { }
              

        public SelectForCSC(IContainer container)
        {
            if (container != null) container.Add(this);

            buttonDict = new Dictionary<Control, Control>();
            functionDict = new Dictionary<Control, SelectionTypes>();

            InitializeComponent();
        }

        #region IExtenderProvider 成员

        public bool CanExtend(object extendee)
        {
            if(extendee is Button)return true;
            return false;
        }

        #endregion


        [Category("速选"),Description("速选按钮类型"),Localizable(true)]
        public Control GetSelectionSource(Control control)
        {
            if(buttonDict.ContainsKey(control))
            return buttonDict[control];
            else
            return null;
        }

        public void SetSelectionSource(Control control,Control selectionSource)
        {
            if(selectionSource!=null)
            {
                if(buttonDict.ContainsKey(control)&&buttonDict[control]!=selectionSource)
                    SetSelectionSource(control,null);
                buttonDict.Add(control,selectionSource);
                functionDict.Add(control,SelectionTypes.清空);
                control.Click+=new EventHandler(control_Click);
            }
            else
            {
                buttonDict.Remove(control);
                functionDict.Remove(control);
                control.Click-=new EventHandler(control_Click);
            }
        }

        [Category("速选"),Description("速选功能"),DefaultValue(SelectionTypes.清空),Localizable(true)]
        public SelectionTypes GetSelectionType(Control control)
        {
            if(functionDict.ContainsKey(control))
                return functionDict[control];
            else
                return SelectionTypes.清空;
        }

        public void SetSelectionType(Control control,SelectionTypes selectionTypes)
        {
            if(functionDict.ContainsKey(control))
                functionDict[control]=selectionTypes;
            else
                functionDict.Add(control,selectionTypes);
        }

        private bool ChangSelected(bool isSelected,SelectionTypes types)
        {
            if(types==SelectionTypes.清空)return false;
            else if(types==SelectionTypes.全选) return true;
            else if(types==SelectionTypes.反选) return !isSelected;
            else throw new NotImplementedException();
        }

        void control_Click(object sender,EventArgs e)
        {
            Control control=sender as Control;
            Control selectionSourceControl=buttonDict[control];
            SelectionTypes selectType=functionDict[control];

            if(selectionSourceControl is CheckedListBox)
            {
                CheckedListBox checkedListBox=selectionSourceControl as CheckedListBox;
                for(int i=0;i<checkedListBox.Items.Count;i++)
                {
                    bool _selected=checkedListBox.GetItemChecked(i);
                    _selected=ChangSelected(_selected,selectType);
                    checkedListBox.SetItemChecked(i,_selected);
                    checkedListBox.SetSelected(i,_selected);
                }
            }
        }
    }
}
