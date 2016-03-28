using CloudSyncUtil.Core.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSyncUtil.App.Logging
{
    public class CmdLogger : ILogger
    {
        protected void Write(string msg)
        {
            Console.WriteLine(msg);
        }

        public void Error(string msg)
        {
            var message = string.Format(" [ERROR] An error occurred: {0}", msg);
            this.Write(message);
        }

        public void Info(string msg)
        {
            var message = string.Format(" [INFO] {0}", msg);
            this.Write(message);
        }

        public void Success(string msg)
        {
            var message = string.Format(" [SUCCESS] {0}", msg);
            this.Write(message);
        }

        public void Warn(string msg)
        {
            var message = string.Format(" [WARN] {0}", msg);
            this.Write(message);
        }
    }
}
