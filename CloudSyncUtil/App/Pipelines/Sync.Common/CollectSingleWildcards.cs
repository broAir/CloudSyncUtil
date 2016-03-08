using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSyncUtil.App.Pipelines.Sync.Common
{
    public class CollectSingleWildcards:CommonSyncProcessor
    {
        protected override void DoProcess(CloudSyncPipelineArgs args)
        {
            var wildCards = args.StringFileMap.Values.Where(x => x.EndsWith("*", StringComparison.InvariantCulture));


        }
    }
}
