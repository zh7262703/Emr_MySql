using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    /// <summary>
    /// 自定义类，方便listbox,combox添加项。
    /// </summary>
    public class ListItem
    {
        private string _id;
        private string _name;
        private string _sid;

        public ListItem()
        { }
        public ListItem(string id, string name, string sid)
        {
            this.Id = id;
            this.Name = name;
            this.Sid = sid;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Sid
        {
            get { return _sid; }
            set { _sid = value; }
        }
    }
}
