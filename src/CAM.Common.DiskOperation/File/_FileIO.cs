

namespace CAM.Common.DiskOperation.File
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;
    using CAM.Common.DiskOperation.Directory;

    public abstract class _FileIO
    {
        private string _basePath = "";

        public _FileIO()
        {
            _basePath = DirectoryHelper.GetApplicationDirectory();
        }

        protected MemoryStream readFileToMemory(string File)
        {
            File = string.Format("{0}{1}", _basePath, File);
            DirectoryHelper.CheckDirectory(DirectoryHelper.GetFilePath(File));

            FileStream fs = new FileStream(File, FileMode.OpenOrCreate, FileAccess.Read);
            long fileLength = fs.Length;
            byte[] fileContentBytes = new byte[fileLength];
            fs.Read(fileContentBytes, 0, (int)fileLength);
            fs.Close();
            fs.Dispose();
            MemoryStream ms = new MemoryStream(fileContentBytes);
            return ms;
        }

        protected void writeFileToDisk(string File, MemoryStream FileContentStream)
        {
            File = string.Format("{0}{1}", _basePath, File);
            DirectoryHelper.CheckDirectory(DirectoryHelper.GetFilePath(File));

            FileStream fs = new FileStream(File, FileMode.Create, FileAccess.Write);
            FileContentStream.WriteTo(fs);
            fs.Close();
            fs.Dispose();
        }

        protected void appendFileToDisk(string File, MemoryStream FileContentStream)
        {
            File = string.Format("{0}{1}", _basePath, File);
            DirectoryHelper.CheckDirectory(DirectoryHelper.GetFilePath(File));

            FileStream fs = new FileStream(File, FileMode.Append, FileAccess.Write);
            FileContentStream.WriteTo(fs);
            fs.Close();
            fs.Dispose();
        }
    }
}
