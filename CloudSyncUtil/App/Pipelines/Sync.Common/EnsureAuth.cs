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
        protected override void Cancel(CloudSyncPipelineArgs args)
        {
            base.Cancel(args);
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
            catch (Exception)
            {
                this.Cancel(args);
            }

        }
    }
}
