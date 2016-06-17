

namespace CAM.Common.DiskOperation.Directory
{
    using System;
    using System.IO;

    public class DirectoryHelper
    {
        /// <summary>
        /// 检查目录是否存在，如果不存在则创建
        /// </summary>
        /// <param name="Path"></param>
        public static void CheckDirectory(string Path)
        {

            if (!System.IO.Directory.Exists(Path))
            {
                System.IO.Directory.CreateDirectory(Path);
            }
        }

        public static string GetFilePath(string File)
        {
            File = File.Replace("/", "\\");
            string Path = File.Substring(0, File.LastIndexOf("\\") + 1);
            return Path;
        }


        /// <summary>
        /// 获取当前系统运行的物理根目录（注意：不是在bin目录下）
        /// </summary>
        /// <returns>传回目录，比如 c:\\webroot\\</returns>
        public static string GetApplicationDirectory()
        {
            string strPath = GetApplicationDirectory("");
            return strPath;
        }
        /// <summary>
        /// 获取一个子目录在本系统下的物理目录结构
        /// </summary>
        /// <param name="AppendDirectoryPath">传入子目录路径，比如Attachments\\Images</param>
        /// <returns>传回目录完整结构，比如 c:\\webroot\\Attachments\\Images\\</returns>
        public static string GetApplicationDirectory(string AppendDirectoryPath)
        {
            //这句是返回到bin目录
            string strPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).Replace("file:\\", "");
            //这句是返回到网站所在根目录
            //string strPath = System.Web.HttpContext.Current.Request.MapPath(System.Web.HttpContext.Current.Request.ApplicationPath);
            if (strPath.Substring(strPath.Length - 1, 1) != "\\")
            {
                strPath = string.Format("{0}\\", strPath);
            }
            if (!string.IsNullOrWhiteSpace(AppendDirectoryPath))
            {
                if (AppendDirectoryPath.Substring(0, 1) == "\\")
                {
                    AppendDirectoryPath = AppendDirectoryPath.Substring(1, AppendDirectoryPath.Length - 1);
                }
                if (AppendDirectoryPath.Substring(AppendDirectoryPath.Length - 1, 1) == "\\")
                {
                    AppendDirectoryPath = AppendDirectoryPath.Substring(0, AppendDirectoryPath.Length - 1);
                }
                strPath = string.Format("{0}{1}\\", strPath, AppendDirectoryPath);
            }
            return strPath;
        }
    }
}
