using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSyncUtil.Core.Logging
{
    interface ILogger
    {
        void Info(string msg);
        void Warn(string msg);
        void Error(string msg);
        void Success(string msg);
    }
}
