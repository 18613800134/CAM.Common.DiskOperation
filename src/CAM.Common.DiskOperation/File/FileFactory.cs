using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAM.Common.DiskOperation.File
{
    public class FileFactory
    {
        public static IFileIO<string> createStringFileIO()
        {
            return new File_String();
        }
    }
}
