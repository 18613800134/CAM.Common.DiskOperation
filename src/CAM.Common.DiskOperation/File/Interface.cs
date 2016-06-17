
namespace CAM.Common.DiskOperation.File
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;


    public interface IFileIO<TType>
    {
        /// <summary>
        /// 从文件中读取内容
        /// </summary>
        /// <param name="File"></param>
        /// <returns></returns>
        TType readFile(string File);

        /// <summary>
        /// 将内容保存到文件，如果没有则创建，如果有了则替换
        /// </summary>
        /// <param name="File"></param>
        /// <param name="FileContent"></param>
        void writeFile(string File, TType FileContent);

        /// <summary>
        /// 将内容追加到现有文件，如果文件不存在，则新建一个文件
        /// </summary>
        /// <param name="File"></param>
        /// <param name="FileContent"></param>
        void appendFile(string File, TType FileContent);
    }
}
