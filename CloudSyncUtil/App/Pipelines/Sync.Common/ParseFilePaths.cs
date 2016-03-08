using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSyncUtil.Core.Configuration;

namespace CloudSyncUtil.App.Pipelines.Sync.Common
{
    public class ParseFilePaths:CommonSyncProcessor
    {
        protected override void Cancel(CloudSyncPipelineArgs args)
        {
            base.Cancel(args);
            args.ExitCode = 12;
        }

        protected override void DoProcess(CloudSyncPipelineArgs args)
        {
            var fileList = args.FilesSyncSettingValue;

            // return if no files provided
            if (string.IsNullOrEmpty(fileList))
            {
                this.Cancel(args);
                return;
            }

            var stringMap = fileList.Split(new[] {'|'}, StringSplitOptions.RemoveEmptyEntries);
            var fileMap = new Dictionary<string, string>();

            foreach (var fileString in stringMap)
            {
                var arr = fileString.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);

                var localPath = arr[0];
                var cloudPath = arr[1];

                fileMap.Add(cloudPath, localPath);
            }

            args.StringFileMap = fileMap;

        }
    }
}
