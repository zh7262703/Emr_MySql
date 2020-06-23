using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Bifrost.Ecp_IData
{
    /// <summary>
    /// ���ݽӿ�
    /// ������:¬����
    /// ����:2012-07-24
    /// </summary>
    public interface IDataSource
    {
        /// <summary>
        /// ��õ�ǰ����,���߲������в���
        /// </summary>
        /// <returns></returns>
         DataSet GetPatients(int area_Id,string account_Type);
        /// <summary>
        /// ��ò��˵�����б�
        /// </summary>
        /// <param name="patient_Id"></param>
        /// <returns></returns>
         DataSet GetDiagnoses(string patient_Id);
        /// <summary>
        /// ��ò��˵������б�
        /// </summary>
        /// <param name="patient_Id"></param>
        /// <returns></returns>
         DataSet GetOperation(string patient_Id);
        /// <summary>
         /// ����˺�id���˺����
        /// </summary>
        /// <param name="user_Number">�û���</param>
        /// <param name="pass_World">����</param>
         /// <param name="account_Type">�˺�����</param>
        /// <returns></returns>
        Class_Account GetAccountInfo(string user_Number, string pass_World, string account_Type);
        /// <summary>
        /// ��ʼ��������Ϣ
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        InPatientInfo InitPatient(DataRow row);
        /// <summary>
        /// ����˺�id���˺����
        /// </summary>
        /// <param name="user_Number">�û���</param>
        /// <param name="account_Type">�˺�����</param>
        /// <returns></returns>
        Class_Account GetAccountInfoByBrowe(string user_Number, string section_id, string account_Type);

        DataSet GetAllSection();

        DataSet GetAllArea();
    }
}
