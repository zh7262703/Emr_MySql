using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    /// <summary>
    /// 按病区或按科室查询
    /// </summary>
    public class Class_ThedayStatistics
    {
        private string title;

        private string admission;

        private string at_the_cinema;

        private string to_leave_hospital;
        /// <summary>
        /// 主题
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        
        /// <summary>
        /// 入院
        /// </summary>
        public string Admission
        {
            get { return admission; }
            set { admission = value; }
        }
        /// <summary>
        /// 在院
        /// </summary>
        public string At_the_cinema
        {
            get { return at_the_cinema; }
            set { at_the_cinema = value; }
        }
        /// <summary>
        /// 出院
        /// </summary>
        public string To_leave_hospital
        {
            get { return to_leave_hospital; }
            set { to_leave_hospital = value; }
        }
    }
}
