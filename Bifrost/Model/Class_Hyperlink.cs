using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Bifrost
{
   public class Class_Hyperlink
    {
       string _text;
	   string _link;
	   bool   _visited;

       public Class_Hyperlink(string text, string link)
		{
			_text = text;
			_link = link;
			_visited = false;
		}
		public bool Visited
		{
			get { return _visited; }
		}
		public Process Activate()
		{
			_visited = true;
			return Process.Start(_link);
		}
		override public string ToString()
		{
			return _text;
		}
    }
}
