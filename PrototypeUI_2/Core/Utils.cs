using ICSharpCode.SharpZipLib.Zip;
using PrototypeUI_2.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PrototypeUI_2.Core
{
    public static class Utils
    {
        private static string _key = "aabbccdd";
        private static string _iv = "20191220";
        public static string ConfigFolder = $"{AppDomain.CurrentDomain.BaseDirectory}config\\";

        /// <summary>
        /// 得到所以功能页VM
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Dictionary<string, ComponentViewModel> GetPartViewModels()
        {
            var viewModels = new Dictionary<string, ComponentViewModel>();
            viewModels.Add("ProjectManage", new ProjectManageViewModel());
            viewModels.Add("ReportForms", new ReportFormsViewModel());
            viewModels.Add("InformationManage", new InformationManageViewModel());
            viewModels.Add("SystemManage", new SystemManageViewModel());
            viewModels.Add("CheckTask", new CheckTaskViewModel() { Parent = viewModels["ProjectManage"] });
            return viewModels;
        }

        public static string MD5Encrypt(string input)
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);

            MD5 md5 = MD5.Create();
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();

            foreach (var b in hash)
                sb.Append(b.ToString("x2"));

            return sb.ToString();
        }

        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="data">加密数据</param>
        /// <param name="key">8位字符的密钥字符串</param>
        /// <param name="iv">8位字符的初始化向量字符串</param>
        /// <returns></returns>
        public static string DESEncrypt(string data, string key, string iv)
        {
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(key);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(iv);

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            int i = cryptoProvider.KeySize;
            MemoryStream ms = new MemoryStream();
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey, byIV), CryptoStreamMode.Write);

            StreamWriter sw = new StreamWriter(cst);
            sw.Write(data);
            sw.Flush();
            cst.FlushFinalBlock();
            sw.Flush();
            return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
        }

        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="data">解密数据</param>
        /// <param name="key">8位字符的密钥字符串(需要和加密时相同)</param>
        /// <param name="iv">8位字符的初始化向量字符串(需要和加密时相同)</param>
        /// <returns></returns>
        public static string DESDecrypt(string data, string key, string iv)
        {
            byte[] byKey = System.Text.ASCIIEncoding.ASCII.GetBytes(key);
            byte[] byIV = System.Text.ASCIIEncoding.ASCII.GetBytes(iv);

            byte[] byEnc;
            try
            {
                byEnc = Convert.FromBase64String(data);
            }
            catch
            {
                return null;
            }

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream(byEnc);
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cst);
            return sr.ReadToEnd();
        }

        public static void WriteConfig(string content, string file)
        {
            if (!Directory.Exists(ConfigFolder))
            {
                Directory.CreateDirectory(ConfigFolder);
            }
            using (StreamWriter sw = new StreamWriter($"{ConfigFolder}{file}", false, Encoding.Default))
            {
                string content_encrypt = DESEncrypt(content, _key, _iv);
                sw.Write(content_encrypt);
            }
        }

        public static string ReadConfig(string file)
        {
            using (StreamReader sr = new StreamReader($"{ConfigFolder}{file}", Encoding.Default))
            {
                string content = sr.ReadToEnd();
                return DESDecrypt(content, _key, _iv);
            }
        }

        /// <summary>
        /// 解压
        /// </summary>
        /// <param name="zipFile">压缩文件路径</param>
        /// <param name="extractFolder">解压释放路径</param>
        /// <param name="msg">操作消息</param>
        /// <returns></returns>
        public static string UnZip(string zipFile, string extractFolder, ref string msg)
        {
            string rootFile = "";
            msg = "";
            try
            {
                //读取压缩文件（zip文件），准备解压缩
                ZipInputStream inputstream = new ZipInputStream(File.OpenRead(zipFile.Trim()));
                ZipEntry entry;
                string path = extractFolder;
                //解压出来的文件保存路径
                string rootDir = "";
                //根目录下的第一个子文件夹的名称
                while ((entry = inputstream.GetNextEntry()) != null)
                {
                    rootDir = Path.GetDirectoryName(entry.Name);
                    //得到根目录下的第一级子文件夹的名称
                    if (rootDir.IndexOf("\\") >= 0)
                    {
                        rootDir = rootDir.Substring(0, rootDir.IndexOf("\\") + 1);
                    }
                    string dir = Path.GetDirectoryName(entry.Name);
                    //得到根目录下的第一级子文件夹下的子文件夹名称
                    string fileName = Path.GetFileName(entry.Name);
                    //根目录下的文件名称
                    if (dir != "")
                    {
                        //创建根目录下的子文件夹，不限制级别
                        if (!Directory.Exists(extractFolder + "\\" + dir))
                        {
                            path = extractFolder + "\\" + dir;
                            //在指定的路径创建文件夹
                            Directory.CreateDirectory(path);
                        }
                    }
                    else if (dir == "" && fileName != "")
                    {
                        //根目录下的文件
                        path = extractFolder;
                        rootFile = fileName;
                    }
                    else if (dir != "" && fileName != "")
                    {
                        //根目录下的第一级子文件夹下的文件
                        if (dir.IndexOf("\\") > 0)
                        {
                            //指定文件保存路径
                            path = extractFolder + "\\" + dir;
                        }
                    }
                    if (dir == rootDir)
                    {
                        //判断是不是需要保存在根目录下的文件
                        path = extractFolder + "\\" + rootDir;
                    }

                    //以下为解压zip文件的基本步骤
                    //基本思路：遍历压缩文件里的所有文件，创建一个相同的文件
                    if (fileName != String.Empty)
                    {
                        FileStream fs = File.Create(path + "\\" + fileName);
                        int size = 2048;
                        byte[] data = new byte[2048];
                        while (true)
                        {
                            size = inputstream.Read(data, 0, data.Length);
                            if (size > 0)
                            {
                                fs.Write(data, 0, size);
                            }
                            else
                            {
                                break;
                            }
                        }
                        fs.Close();
                    }
                }
                inputstream.Close();
                return rootFile;
            }
            catch (Exception ex)
            {
                msg = "解压失败，原因：" + ex.Message;
                return "1;" + ex.Message;
            }
        }
    }
}
