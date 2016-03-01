using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSyncUtil.Core.Integrations
{
    [Flags]
    public enum AccessOptions
    {
        None = 0,
        ReadMetadata = 1,
        ReadFile = 2,
        UploadFile = 4
    }
}
