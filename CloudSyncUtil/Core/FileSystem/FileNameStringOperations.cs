using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSyncUtil.Core.FileSystem
{
    public static class FileNameStringOperations
    {
        public static string GetExtension(string fileName)
        {
            return Path.GetExtension(fileName).ToLower();
        }

        public static string GetFileName(string path)
        {
            return Path.GetFileName(path);
        }
    }
}
