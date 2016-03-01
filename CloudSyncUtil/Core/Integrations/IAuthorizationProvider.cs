using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSyncUtil.Core.Integrations
{
    public interface IAuthorizationProvider
    {
        object Authorize(string userName, string apiKey, string apiSecret);
    }
}
