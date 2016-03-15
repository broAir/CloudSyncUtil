using CloudSyncUtil.Core.Integrations;
using CloudSyncUtil.Core.Pipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSyncUtil.App.Pipelines.Sync.Common
{
    public abstract class CommonSyncProcessor : Processor<CloudSyncPipelineArgs>
    {
        protected CommonSyncProcessor() : base() { }

        protected CommonSyncProcessor(int priority) : base(priority) { }
    }
}
