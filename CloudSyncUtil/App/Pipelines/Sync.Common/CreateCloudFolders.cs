using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSyncUtil.Core.Integrations;

namespace CloudSyncUtil.App.Pipelines.Sync.Common
{
    public class CreateCloudFolders:CommonSyncProcessor
    {
        protected override void DoProcess(CloudSyncPipelineArgs args)
        {
            var resultingMap = new Dictionary<CloudFile, string>();

            foreach (var pathsKeyValue in args.StringFileMap)
            {
                var cloudFolder = args.Repository.CreateFolderStructure(pathsKeyValue.Key);

                resultingMap.Add(cloudFolder, pathsKeyValue.Value);
            }

            args.CloudToStringMap = resultingMap;
        }
    }
}
