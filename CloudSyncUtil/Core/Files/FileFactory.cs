using CloudSyncUtil.Core.FileSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSyncUtil.Core.Files
{
    public class FileFactory
    {
        protected FileFactory() { }

        private static readonly FileFactory _instance = new FileFactory();
        public static FileFactory Instance { get { return _instance; } }

        public LocalFile GetFile(string path)
        {
            if (IOManager.Exists(path))
            {
                var file = new LocalFile
                {
                    FullPath = path,
                    Extension = FileNameStringOperations.GetExtension(path),
                    Name = FileNameStringOperations.GetFileName(path),
                    MD5Checksum = IOManager.GetMD5CheckSum(path),
                    Updated = IOManager.GetLastUpdated(path)
                };
                return file;
            }

            return null;
        }
    }
}
