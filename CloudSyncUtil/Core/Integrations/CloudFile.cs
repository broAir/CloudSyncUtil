using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSyncUtil.Core.Integrations
{
    public class CloudFile
    {
        public object InnerFile { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public string MD5Checksum { get; set; }

        public DateTime Updated { get; set; }

        public int Size { get; set; }

        public CloudFile(object inner)
        {
            this.InnerFile = inner;
        }
        

        public bool IsNewer(CloudFile other)
        {
            return this.Updated > other.Updated;
        }
    }
}
