

namespace CAM.Common.DiskOperation.File
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;

    public class File_String : _FileIO, IFileIO<string>
    {
        public string readFile(string File)
        {
            MemoryStream ms = readFileToMemory(File);
            ms.Position = 0;
            int msLength = (int)ms.Length;
            byte[] stringBytes = null;
            using (BinaryReader br = new BinaryReader(ms))
            {
                stringBytes = br.ReadBytes(msLength);
            }

            //如果是手工修改过文件的话，很有可能被加上了BOM头，这里需要尝试去掉BOM头，以保证读取数据能够正确被程序认出来。
            stringBytes = removeUTF8Bom(stringBytes);

            string fileContent = Encoding.UTF8.GetString(stringBytes);
            return fileContent;

        }

        /*
         * 如果UTF-8文件被手工修改并保存后，有可能存在BOM头。
         * 铜鼓偶这个函数可以尝试将文件内容的BOM头去掉
         */
        private byte[] removeUTF8Bom(byte[] stringBytes)
        {
            if (stringBytes == null) return stringBytes;
            if (stringBytes.Length <= 3) return stringBytes;

            byte[] bomBuffer = new byte[] { 0xef, 0xbb, 0xbf };
            if (stringBytes[0] == bomBuffer[0] && stringBytes[1] == bomBuffer[1] && stringBytes[2] == bomBuffer[2])
            {
                byte[] desBytes = new byte[stringBytes.Length - 3];
                Array.Copy(stringBytes, 3, desBytes, 0, desBytes.Length);
                return desBytes;
            }
            else
            {
                return stringBytes;
            }
        }

        public void writeFile(string File, string FileContent)
        {
            byte[] stringBytes = Encoding.UTF8.GetBytes(FileContent);
            MemoryStream ms = new MemoryStream(stringBytes);
            writeFileToDisk(File, ms);
        }


        public void appendFile(string File, string FileContent)
        {
            byte[] stringBytes = Encoding.UTF8.GetBytes(FileContent);
            MemoryStream ms = new MemoryStream(stringBytes);
            appendFileToDisk(File, ms);
        }
    }
}
