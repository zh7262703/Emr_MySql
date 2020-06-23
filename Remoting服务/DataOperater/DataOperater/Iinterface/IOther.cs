using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace DataOperater.Iinterface
{
    /// <summary>
    /// 其他的相关操作
    /// 创建者：张华
    /// 创建时间：2020-6-23
    /// </summary>
    public interface IOther
    {
        /// <summary>
        /// 获取FTP更新目录的信息
        /// </summary>
        /// <returns></returns>       
        string[] GetFtpMessage();

        /// <summary>
        /// 插入文书模板(t_patients_doc-文书;t_model_lable-标签模块;t_struct-结构化)
        /// </summary>
        /// <param name="PID">病人主ID(HIS)</param>
        /// <param name="textKind">文书类型</param>
        /// <param name="xmlDoc">文书模板</param>
        /// <returns></returns>       
        string InsertModel(string PID, int textKind_ID, string xmlDoc, int belongToSys_ID, int sickKind_ID, string textName);

        /// <summary>
        /// 插入标签模板
        /// </summary>
        /// <param name="doc">文书代码</param>
        /// <param name="xmlDoc">标签模板</param>
        /// <returns></returns>       
        string InsertLableModel(int tid, string xmlDoc);

        /// <summary>
        /// 插入标签模板
        /// </summary>
        /// <param name="doc">文书代码</param>
        /// <param name="xmlDoc">标签模板</param>
        /// <returns></returns>       
        string InsertLableContent(int tid, string xmlDoc);

        ///// <summary>
        ///// 获取所有局域网地址
        ///// </summary>
        ///// <returns></returns>    
        ArrayList GetAllLocalMachines();

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="message">要传送的消息</param>
        /// <param name="currentip">发消息的Ip</param>     
        void sendmymsg(string message, string currentip);


        /// <summary>
        /// 获取所有的当前的在线用户的资料
        /// </summary>
        /// <returns></returns>
        string GetAllCurrentOpersXml();


        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="SenderIp"></param>
        /// <param name="target"></param>
        /// <param name="patintname"></param>
        void SenderCurrentOpersXml(string SenderIp, string TargetSectionId, string patintname);

        /// <summary>
        /// 删除所有的flag为1的记录
        /// </summary>
        void DeleteAllOpersXml();

        /// <summary>
        /// 设置flag标志位
        /// </summary>
        void SetOpersXml(string SenderIp);

        /// <summary>
        /// 返回服务器时间
        /// </summary>
        /// <returns></returns>
        DateTime GetSystemTime();

    }
}
