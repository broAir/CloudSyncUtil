using CloudSyncUtil.App.Pipelines.Sync.Common;
using CloudSyncUtil.Core.Pipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSyncUtil.App.Pipelines.Sync.Common
{
    public class EnsureAuth : CommonSyncProcessor
    {
        public EnsureAuth(int priority = 100) : base(priority) { }

        protected override void Cancel(CloudSyncPipelineArgs args, Exception e = null)
        {
            base.Cancel(args, e);
            args.ExitCode = 11;
        }

        protected override void DoProcess(CloudSyncPipelineArgs args)
        {
            try
            {
                var service = args.Repository.Authorize();

                if (service == null)
                {
                    this.Cancel(args);
                }
            }
            catch (Exception e)
            {
                this.Cancel(args, e);
            }

        }
    }
}
