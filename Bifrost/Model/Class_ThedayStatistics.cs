using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost
{
    /// <summary>
    /// �������򰴿��Ҳ�ѯ
    /// </summary>
    public class Class_ThedayStatistics
    {
        private string title;

        private string admission;

        private string at_the_cinema;

        private string to_leave_hospital;
        /// <summary>
        /// ����
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        
        /// <summary>
        /// ��Ժ
        /// </summary>
        public string Admission
        {
            get { return admission; }
            set { admission = value; }
        }
        /// <summary>
        /// ��Ժ
        /// </summary>
        public string At_the_cinema
        {
            get { return at_the_cinema; }
            set { at_the_cinema = value; }
        }
        /// <summary>
        /// ��Ժ
        /// </summary>
        public string To_leave_hospital
        {
            get { return to_leave_hospital; }
            set { to_leave_hospital = value; }
        }
    }
}
