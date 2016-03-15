using CloudSyncUtil.App.Pipelines.Sync.Common;
using CloudSyncUtil.App.Pipelines.Sync.GoogleDrive;
using CloudSyncUtil.Core.Configuration;
using CloudSyncUtil.Core.Pipelines;
using CloudSyncUtil.Integrations.GoogleDrive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSyncUtil.App.Pipelines
{
    public static class PipelineFactory
    {
        public static GoogleDriveSyncPipeline GetGoogleSyncPipeline()
        {
            var pipeline = new GoogleDriveSyncPipeline();

            pipeline.AddProcessor(new EnsureAuth(100));
            pipeline.AddProcessor(new EnsureSyncFolder(200));
            pipeline.AddProcessor(new ParseFilePaths(300));
            pipeline.AddProcessor(new CreateCloudFolders(400));
            pipeline.AddProcessor(new ProcessSingleWildcards(500));

            return pipeline;
        }

        public static class ArgsFactory
        {
            public static GoogleSyncArgs GetGoogleSyncArgs()
            {
                return new GoogleSyncArgs
                {
                    // TODO: DI
                    Repository = new GoogleCloudRepository(),
                    FilesSyncSettingValue = SettingsManager.Instance.GoogleFileList(),
                    SyncRootFolderName = SettingsManager.Instance.GoogleRootFolder()
                };
            }
        }
    }
}
