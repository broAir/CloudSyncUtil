using CloudSyncUtil.Core.Integrations;
using CloudSyncUtil.Core.Pipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSyncUtil.App.Pipelines
{
    public class CloudSyncPipelineArgs : PipelineArgs
    {
        public CloudRepository Repository { get; set; }

        public string SyncRootFolderName { get; set; }

        public CloudFile SyncRootFolder { get; set; }

        public string FilesSyncSettingValue { get; set; }

        public Dictionary<string, string> StringFileMap { get; set; }

        public Dictionary<CloudFile, string> CloudToStringMap { get; set; } 
    }
}
