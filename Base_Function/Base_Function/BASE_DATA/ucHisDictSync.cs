using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Bifrost;

namespace Base_Function.BASE_DATA
{
    public partial class ucHisDictSync : UserControl
    {
        public ucHisDictSync()
        {
            InitializeComponent();
            
        }
        /// <summary>
        /// ͬ������ֵ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX1_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> Sqls = new List<string>();
                SyncDiagnose(ref Sqls);
                App.ExecuteBatch(Sqls.ToArray());
            }
            catch (Exception ex)
            {
                App.Msg("ͬ����ϳ���" + ex.Message.ToString());
                return;
            }
            App.Msg("ͬ���������ɣ�");
            mThread = new System.Threading.Thread(new System.Threading.ThreadStart(SetDiagShortCut));
            mThread.Start();
        }
        System.Threading.Thread mThread = null;
        System.Threading.Thread mThread2 = null;
        /// <summary>
        /// ��ȡ��ϼ�����
        /// </summary>
        private void SetDiagShortCut()
        {
            string sSec = "select * from diag_def_icd10 where shortcut1 is null";
            DataSet ds = App.GetDataSet(sSec);
            int lenth = 20;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string sCode = dr["code"].ToString();
                string sName = dr["name"].ToString();
                string shortcut1 = App.getSpell(sName);
                string shortcut2 = App.GetWBcode(sName);
                shortcut1 = App.GetStringList(shortcut1, lenth)[0];
                shortcut2 = App.GetStringList(shortcut2, lenth)[0];
                string sUpdate = "Update diag_def_icd10 set shortcut1='" + shortcut1 + "',"
                + "shortcut2='" + shortcut2 + "'"
                + " where name='" + sName + "'";
                try
                {
                    App.ExecuteSQL(sUpdate);
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            if (mThread != null)
            {
                mThread.Abort();
            }
        }

        private void SyncDiagnose(ref List<string> Sqls)
        {
            //string sDelete = "delete from diag_def_icd10";
            //Sqls.Add(sDelete);
            ////������ҽ���
            //string sInsert = "insert into DIAG_DEF_ICD10 select ZDBM as CODE,ZDMC as NAME,'' as shortcut1,'' as shortcut2,'' as QTXM,'' as FJBM,'N' as is_chinese from hnyz_zxyy.intf_emr_icd10@dbhislink";
            //sInsert += " where flag is null or flag='0'";
            //Sqls.Add(sInsert);
            ////������ҽ���
            //sInsert = "insert into DIAG_DEF_ICD10 select ZDBM as CODE,ZDMC as NAME,'' as shortcut1,'' as shortcut2,'' as QTXM,'' as FJBM,'Y' as is_chinese from hnyz_zxyy.intf_emr_icd10@dbhislink";
            //sInsert += " where flag<>'0'";
            //Sqls.Add(sInsert);

            string sSec="select ZDBM as CODE,ZDMC as NAME,'' as shortcut1,'' as shortcut2,'' as QTXM,'' as FJBM,flag from hnyz_zxyy.intf_emr_icd10@dbhislink"
                 +" where zdmc not in (select a.name  from diag_def_icd10 a)";
            DataTable dtDiag = App.GetDataSet(sSec).Tables[0];
            int lenth = 50;
            foreach(DataRow dr in dtDiag.Rows)
            {
                string sCode = dr["code"].ToString();
                string sName = dr["name"].ToString();
                string shortcut1 = App.getSpell(sName);
                string shortcut2 = App.GetWBcode(sName);
                string ischinese="N";
                if(dr["flag"]!=null&&dr["flag"].ToString()=="1")
                {
                    ischinese="Y";
                }
                shortcut1 = App.GetStringList(shortcut1, lenth)[0];
                shortcut2 = App.GetStringList(shortcut2, lenth)[0];
                string insert = "insert into DIAG_DEF_ICD10 (code,name,shortcut1,shortcut2,is_chinese)"
                             + " values("
                             + "'" + sCode + "'"
                             + ",'" + sName + "'"
                             + ",'" + shortcut1 + "'"
                             + ",'" + shortcut2 + "'"
                             + ",'" + ischinese + "')";
                Sqls.Add(insert);
            }

        }
        /// <summary>
        /// ͬ�����������ֵ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX2_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> Sqls = new List<string>();
                SyncOperation(ref Sqls);
                App.ExecuteBatch(Sqls.ToArray());
            }
            catch(Exception ex)
            {
                App.Msg("ͬ����������"+ex.Message.ToString());
                return;
            }
            App.Msg("ͬ����������ɣ�");
            mThread2 = new System.Threading.Thread(new System.Threading.ThreadStart(SetOperShortCut));
            mThread2.Start();
        }
        private void SyncOperation(ref List<string>Sqls)
        {
            //string sDelete = "delete from oper_def_icd9";
            //Sqls.Add(sDelete);
            //string sInsert = "insert into OPER_DEF_ICD9 select a.SSDM as CODE,SSMC as NAME,'' as shortcut1,'' as shortcut2,'��' as oper_level,'N' as is_appr,'' as oper_code,'' as is_enable,'' as qtxm,'' as fjbm   from hnyz_zxyy.intf_emr_icdoperation@dbhislink a";
            //Sqls.Add(sInsert);

            string sSec = "select a.SSDM as CODE,SSMC as NAME,'' as shortcut1,'' as shortcut2,'��' as oper_level,'N' as is_appr,'' as oper_code,'' as is_enable,'' as qtxm,'' as fjbm   from hnyz_zxyy.intf_emr_icdoperation@dbhislink a"
                       + " where a.ssmc not in(select a.name from oper_def_icd9 a)";
            DataTable dtOper = App.GetDataSet(sSec).Tables[0];
            int lenth = 20;
            foreach (DataRow dr in dtOper.Rows)
            {
                string sCode = dr["code"].ToString();
                string sName = dr["name"].ToString();
                string shortcut1 = App.getSpell(sName);
                string shortcut2 = App.GetWBcode(sName);
                shortcut1 = App.GetStringList(shortcut1, lenth)[0];
                shortcut2 = App.GetStringList(shortcut2, lenth)[0];
                string insert = " insert into OPER_DEF_ICD9(code,name,shortcut1,shortcut2,oper_level,is_appr)"
                              + " values("
                              + "'" + sCode + "',"
                              + "'" + sName + "',"
                              + "'" + shortcut1 + "',"
                              + "'" + shortcut2 + "',"
                              + "'" + dr["oper_level"].ToString() + "',"
                              + "'" + dr["is_appr"].ToString() + "')";
                Sqls.Add(insert);
            }
        }

        /// <summary>
        /// ��ȡ����������
        /// </summary>
        private void SetOperShortCut()
        {
            string sSec = "select * from oper_def_icd9 where shortcut1 is null";
            DataSet ds = App.GetDataSet(sSec);
            int lenth = 20;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string sCode = dr["code"].ToString();
                string sName = dr["name"].ToString();
                string shortcut1 = App.getSpell(sName);
                string shortcut2 = App.GetWBcode(sName);
                shortcut1 = App.GetStringList(shortcut1, lenth)[0];
                shortcut2 = App.GetStringList(shortcut2, lenth)[0];
                string sUpdate = "Update oper_def_icd9 set shortcut1='" + shortcut1 + "',"
                + "shortcut2='" + shortcut2 + "'"
                + " where name='" + sName + "'";
                try
                {
                    App.ExecuteSQL(sUpdate);
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            if (mThread2 != null)
            {
                mThread2.Abort();
            }
        }
    }
}
