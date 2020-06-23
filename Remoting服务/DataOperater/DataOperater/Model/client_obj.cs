using System;
using System.Collections.Generic;
using System.Text;

namespace DataOperater.Model
{
    public class client_obj
    {
        private string _ip;
        /// <summary>
        /// 地址
        /// </summary>
        public string Ip
        {
            get { return _ip; }
            set { _ip = value; }
        }

        private string _userName;

        /// <summary>
        /// 用户姓名
        /// </summary>
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private string _ZhiWu;
        /// <summary>
        /// 职务
        /// </summary>
        public string ZhiWu
        {
            get { return _ZhiWu; }
            set { _ZhiWu = value; }
        }

        private string _ZhiCheng;
        /// <summary>
        /// 职称
        /// </summary>
        public string ZhiCheng
        {
            get { return _ZhiCheng; }
            set { _ZhiCheng = value; }
        }

        private string _Account_Name;
        /// <summary>
        /// 帐号名称
        /// </summary>
        public string Account_Name
        {
            get { return _Account_Name; }
            set { _Account_Name = value; }
        }

        private int _LinkCount;
        /// <summary>
        /// 连接计数
        /// </summary>
        public int LinkCount
        {
            get { return _LinkCount; }
            set { _LinkCount = value; }
        }

    }
}
