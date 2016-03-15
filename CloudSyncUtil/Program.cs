using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSyncUtil.Core.Configuration;
using CloudSyncUtil.Integrations.GoogleDrive;
using CloudSyncUtil.Core.Integrations;
using CloudSyncUtil.Core.Files;
using CloudSyncUtil.App.Pipelines;
using CloudSyncUtil.App.Pipelines.Sync.GoogleDrive;

namespace CloudSyncUtil
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("");
            //var cid = ApiKeys.GoogleApiKey;
            //var csec = ApiKeys.GoogleApiSecret;

            //var auth = new GoogleAuthorizationProvider(SettingsManager.Instance);

            //var service = new GoogleCloudRepository(SettingsManager.Instance);

            //var f = service.UploadFile(FileFactory.Instance.GetFile(@"D:\RK.rar"));

            //var f = service.DownloadFile("RK.rar");

            var pipeline = PipelineFactory.GetGoogleSyncPipeline();

            pipeline.Run(PipelineFactory.ArgsFactory.GetGoogleSyncArgs()).Wait();

            Console.ReadLine();
        }
    }
}
