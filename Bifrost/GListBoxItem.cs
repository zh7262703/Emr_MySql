using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Bifrost
{
    public class GListBoxItem
    {
        private string _myText; 
        private int _myImageIndex;
        private object _Tag;
        // 属性 
        public string Text { get {return _myText;} set {_myText = value;} } 
        public int ImageIndex { get {return _myImageIndex;} set {_myImageIndex = value;} }
        public object Tag { get { return _Tag; } set { _Tag = value; } }
        //构造函数 
        public GListBoxItem(string text, int index) 
        { _myText = text; _myImageIndex = index; } 
        public GListBoxItem(string text): this(text,-1){} 
        public GListBoxItem(): this(""){} 
        public override string ToString() { return _myText; } 
    }
}
