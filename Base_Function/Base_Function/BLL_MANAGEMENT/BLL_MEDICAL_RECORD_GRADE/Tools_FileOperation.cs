using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;
using System.Data;
using System.Windows.Forms;

using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;
using ThoughtWorks.QRCode.Codec.Util;
using System.Drawing;
using System.Drawing.Imaging;
using DevComponents.AdvTree;

//using WIA;
using Bifrost;


namespace Base_Function.BLL_MEDICAL_RECORD_GRADE
{   
    /// <summary>
    /// 文件处理类，包含扫描及处理文件的各种静态方法
    /// </summary>
    public class Tools_FileOperation
    {
        #region 处理文件，分类
        /// <summary>
        /// 处理扫描后的文件生成Info_MedicalRecords的集合。
        /// </summary>
        public static ArrayList GetScanFiles(string directoryPath)
        {
            ArrayList scanFiles = new ArrayList();

            if (!Directory.Exists(directoryPath))
            {
                return scanFiles;
            }
            DirectoryInfo dir = new DirectoryInfo(directoryPath);
            FileInfo[] filesInfo = dir.GetFiles();
            for (int i = 0; i < filesInfo.Length; i++)
            {
                Info_MedicalRecords imr = new Info_MedicalRecords();

                //文件名
                imr.FileName = filesInfo[i].Name;
                string[] n = Tools_FileOperation.FileNameAnalyse(filesInfo[i].Name);

                //病人ID
                imr.PatientID = n[1];

                //VisitID
                //int型转换
                try
                {
                    imr.VisitID = int.Parse(n[2]);
                }
                catch (Exception ex)
                {
                    continue;
                }
                
                //文书类型编码
                imr.TextTypeCode = n[3];

                //文件顺序
                //int型转换
                try
                {
                    imr.FileOrder = int.Parse(n[4]);
                }
                catch (Exception ex)
                {
                    imr.FileOrder = 0;
                }

                scanFiles.Add(imr);
            }
            return scanFiles;
        }

        #endregion

        #region 生成文件名称树形结构

        /// <summary>
        /// 生成文件名称树形结构
        /// </summary>
        /// <param name="info_MedicalRecords">Info_MedicalRecords的集合</param>
        /// <param name="nodes">TreeView的根结点集合</param>
        public static void ShowFilesView(ArrayList info_MedicalRecords,NodeCollection nodes)
        {
            nodes.Clear();
            foreach (Info_MedicalRecords imr in info_MedicalRecords)
            {
                bool isHave = false;
                Node node = new Node();

                for (int i = 0; i < nodes.Count; i++)
                {                     
                    try
                    {
                        string[] tag = nodes[i].Tag.ToString().Split('-');
                        if (imr.PatientID.Equals(tag[0]) && imr.VisitID == int.Parse(tag[1]))
                        {
                            isHave = true;

                            //病人姓名
                            imr.PatientName = node.Text;
                            node = nodes[i];
                            break;
                        }
                    }
                    catch(Exception ex)
                    {
                        continue;
                    }
                }
                if (!isHave)
                {  
                    //数据库查询病人姓名
                    string sql = "select t.patient_name from t_in_patient t where t.his_id = '"
                        +imr.PatientID
                        +"-"
                        +imr.VisitID+"'";
                    DataSet ds = App.GetDataSet(sql);
                    if (ds.Tables.Count > 0)
                    {
                        imr.PatientName = ds.Tables[0].Rows[0]["patient_name"].ToString();
                    }

                    node.Text = imr.PatientName+" "+imr.PatientID+"("+imr.VisitID+")";
                    
                    node.Tag = imr .PatientID+"-"+imr.VisitID.ToString();
                    node.CheckBoxVisible = true;
                    nodes.Add(node);
                }
                Tools_FileOperation.GetFilesTree(imr,node.Nodes);
            }
        }

        private static void GetFilesTree(Info_MedicalRecords imr, NodeCollection nodes)
        {
            bool isHave = false;
            
            for (int i = 0; i < nodes.Count; i++)
            {
                try
                {
                    if (imr.TextTypeCode.Equals(nodes[i].Tag.ToString()))
                    {
                        isHave = true;

                        //文书类型
                        imr.TextType = nodes[i].Text;

                        Node node = new Node();
                        node.Text = imr.FileOrder.ToString();
                        node.Tag = imr;

                        nodes[i].Nodes.Add(node);

                        break;
                    }
                }
                catch (Exception ex)
                {
                    continue;
                }
            }

            if (!isHave)
            {
                Node  node = new Node();
                //数据库查询文书类型
                string sql = "select t.textname from t_text t where t.id ="
                    + imr.TextTypeCode;

                DataSet ds = App.GetDataSet(sql);
                if (ds.Tables.Count > 0)
                {
                    imr.TextType = ds.Tables[0].Rows[0]["textname"].ToString();
                }
                
                node.Text = imr.TextType;
                node.Tag = imr.TextTypeCode;
                nodes.Add(node);
                Node temp = new Node();
                temp.Text = imr.FileOrder.ToString();
                temp.Tag = imr;
                node.Nodes.Add(temp);
            }

        }
        #endregion

        #region 解析文件名

        /// <summary>
        ///解析病历文件名。以'_'拆分文件名，返回string数组
        ///如有异常返回空数组
        /// </summary>
        public static string[] FileNameAnalyse(string fileName)
        {
            string[] names;
            try
            {

                names = fileName.Substring(0, fileName.LastIndexOf('.')).Split('_');
                return names;
            }
            catch (Exception ex)
            {
                names = new string[0];
                return names;
            }

        }
        #endregion

        #region 病历类型排序

        //public static void FileNameAnalyse()
        //{
        //    string[] names;
        //    try
        //    {

        //        names = fileName.Substring(0, fileName.LastIndexOf('.')).Split('_');
        //        return names;
        //    }
        //    catch (Exception ex)
        //    {
        //        names = new string[0];
        //        return names;
        //    }

        //}
        #endregion

        #region 判断扫面后图片是否倒置
        /// <summary>
        /// 判断image图片是否是倒置的
        /// 0表示图片为倒置的；1表示图片为正；2表示图片为错误，需要删除
        /// </summary>
        /// <param name="image"></param>
        
        public static int PicInversion(Image image)
        {
            string test = Tools_FileOperation.QRCodeAnalyse(image,"top");

            if (test.Equals("error"))
            {
                test = Tools_FileOperation.QRCodeAnalyse(image,"down");
                if (test.Equals("error"))
                {
                    return 2;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 1;
            }
        }

        #endregion

        #region 解析图片二维码
        /// <summary>
        /// 解析image中qrCodePosition处的二维码
        /// 返回解析后的string，如出现错误二维码或异常则返回"error"
        /// </summary>
        /// <param name="image">包含有二维码的Image</param>
        /// <param name="qrCodePosition">标示二维码在Image中的位置</param>
        /// <returns></returns>
        public static string QRCodeAnalyse(Image image,string qrCodePosition)
        {
            string result = "";
            int x, y, width, height;

            switch (qrCodePosition)
            {
                case "top":
                    {
                        x = image.Width * 7 / 10;
                        y = 0;
                        width = image.Width - x;
                        height = 400;
                        break;
                    }
                case "down":
                    {                        
                        x = 0;
                        y = image.Height - 400;
                        width = image.Width * 3 / 10;
                        height = 400;
                        break;
                    }
                default:
                    {
                        return "error";
                    }
            }
            

            Bitmap bmpCut = new Bitmap(width,height);
            Graphics g = Graphics.FromImage(bmpCut);
            Rectangle rectCut = new Rectangle(x,y,width,height);
            Rectangle rectBmp = new Rectangle(0,0,width,height);

            g.DrawImage(image, rectBmp, rectCut, GraphicsUnit.Pixel);

            if (qrCodePosition.Equals("down"))
            {
                bmpCut.RotateFlip(RotateFlipType.Rotate180FlipNone);
            }
            QRCodeDecoder qrCodeDecoder = new QRCodeDecoder();
            //bmpCut.Save(@"d:\123.jpg");

            try
            {
                result = qrCodeDecoder.decode(new QRCodeBitmapImage(bmpCut), Encoding.UTF8);
            }
            catch(Exception ex)
            {
                result = "error";
            }            
            return result;
        }
        #endregion

        #region
        public static void UpLoadFile()
        {

        }
        #endregion

        #region  创建并清空存储文件的物理路径
        /// <summary>
        /// 创建并清空存储文件的物理路径
        /// </summary>
        /// <param name="dir">物理路径</param>
        /// <returns>成功返回true，失败为false</returns>
        public static bool ClearDir(String dir)
        {
            try
            {
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                else
                {
                    string[] strDirs = Directory.GetDirectories(dir);
                    string[] strFiles = Directory.GetFiles(dir);
                    foreach (string str in strDirs)
                    {
                        Directory.Delete(str, true);
                    }
                    foreach (string str in strFiles)
                    {
                        File.Delete(str);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        #endregion

        #region 扫描启动
        /// <summary>
        /// 扫描文件，返回扫描成功的文件数
        /// </summary>
        /// <param name="beginNum">文件起始计数</param>
        /// <returns></returns>
        //private static int ScanStart(int beginNum)
        //{

        //    ImageFile imageFile = null;

        //    CommonDialogClass cdc = new CommonDialogClass();

        //    DeviceManager manager = new DeviceManagerClass();

        //    Device device = null;
        //    Item item = null;
        //    try
        //    {
        //        foreach (DeviceInfo info in manager.DeviceInfos)
        //        {
        //            if (info.Type != WiaDeviceType.ScannerDeviceType)
        //            {
        //                continue;
        //            }
        //            else
        //            {
        //                device = info.Connect();
        //                break;
        //            }
        //        }
        //        item = device.Items[1];
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("lalala");
        //    }
        //    int fileCount = 0;

        //    while (true)
        //    {
        //        try
        //        {
        //            imageFile = cdc.ShowTransfer(item, WiaFormat.WIA_FORMAT_JPEG, true) as ImageFile;
        //            if (imageFile != null)
        //            {
        //                imageFile.SaveFile(GlobalSettings.TempPath
        //                    + @"\"
        //                    + beginNum.ToString()
        //                    + ".jpg");
        //                fileCount++;
        //                beginNum++;
        //            }
        //            else
        //            {
        //                break;
        //            }
        //        }
        //        catch (System.Runtime.InteropServices.COMException)
        //        {
        //            break;
        //        }
        //        catch (NullReferenceException ex)
        //        {
        //            MessageBox.Show("扫描错误，扫描中断");
        //            Tools_Others.WriteErrorLog("扫描中错误，空引用：" + ex.Message);
        //            break;
        //        }
        //    }
        //    return fileCount;
        //}

        #endregion

        //#region 扫描文件
        ///// <summary>
        ///// 扫描文件,返回总文件数，该方法可连续扫描
        ///// </summary>
        //public static int ScanFiles()
        //{
        //    int beginNum = 0;

        //    while (true)
        //    {                
        //        int scanCount = Tools_FileOperation.ScanStart(beginNum);

        //        beginNum += scanCount;

        //        if (MessageBox.Show("扫描完成，共" + scanCount.ToString() + "页，是否继续扫描？"
        //                , "继续扫描"
        //                , MessageBoxButtons.YesNo) == DialogResult.No)
        //        {
        //            //MessageBox.Show("扫描完成，共扫描" + beginNum + "个文件");
        //            //break;
        //            return beginNum;
        //        }
        //        else
        //        {
        //            MessageBox.Show("请放好文件后点击“确定”开始扫描");
        //        }
        //    }            
        //}

        //#endregion

        //#region 处理扫描后的文件
        ///// <summary>
        ///// 处理扫描后的文件,并解析二维码后保存至BrowsePath。
        ///// 成功后返回0，如未能解析返回1。
        ///// </summary>
        ///// <param name="fileName"></param>
        ///// <returns></returns>
        //public static int ScanFileDispose(Image image)
        //{
        //    Tools_FileOperation.ClearDir(GlobalSettings.BrowsePath);            

        //    int direction = Tools_FileOperation.PicInversion(image);
        //    if (direction == 0)
        //    {
        //        image.RotateFlip(RotateFlipType.Rotate180FlipNone);
        //    }
        //    if (direction == 2)
        //    {
        //        return 1;
        //    }
        //    string newName = Tools_FileOperation.QRCodeAnalyse(image, QRCodePosition.FILE_TOP);
        //    if (newName.Equals("error"))
        //    {
        //        return 1;
        //    }
        //    else
        //    {
        //        try
        //        {
        //            image.Save(GlobalSettings.BrowsePath + @"\" + newName + ".jpg");
        //            return 0;
        //        }
        //        catch (Exception ex)
        //        {
        //            return 1;
        //        }
        //    }            
        //}
        //#endregion
    }
}
