using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSyncUtil.Core.Files
{
    public class LocalFile
    {
        public string FullPath { get; set; }

        public string Name { get; set; }

        public string Extension { get; set; }

        public string MD5Checksum { get; set; }

        public DateTime Updated { get; set; }

        public int Size { get; set; }
    }
}
