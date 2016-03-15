using CloudSyncUtil.App.Pipelines.Sync.GoogleDrive.Processors;
using CloudSyncUtil.Core.Pipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSyncUtil.App.Pipelines.Sync.GoogleDrive
{
    public class GoogleDriveSyncPipeline : Pipeline<CloudSyncPipelineArgs>
    {
        public GoogleDriveSyncPipeline() : base(null)
        {
        }
    }
}
