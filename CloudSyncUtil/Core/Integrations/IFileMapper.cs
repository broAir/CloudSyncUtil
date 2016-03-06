using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSyncUtil.Core.Integrations
{
    public interface IFileMapper
    {
        CloudFile MapToFile(object innerFile);

        List<CloudFile> MapMany(List<object> inners);
    }
}
