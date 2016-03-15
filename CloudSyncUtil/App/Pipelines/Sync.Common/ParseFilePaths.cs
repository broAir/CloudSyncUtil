using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSyncUtil.Core.Configuration;

namespace CloudSyncUtil.App.Pipelines.Sync.Common
{
    public class ParseFilePaths : CommonSyncProcessor
    {
        public ParseFilePaths(int priority = 300) : base(priority) { }

        protected override void Cancel(CloudSyncPipelineArgs args, Exception e = null)
        {
            base.Cancel(args, e);
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

            var stringMap = fileList.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            var fileMap = new Dictionary<string, string>();

            foreach (var fileString in stringMap)
            {
                var arr = fileString.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                string localPath, cloudPath;

                // if we have specified a cloud folder name
                if (arr.Length > 1)
                {
                    localPath = arr[0];
                    cloudPath = arr[1];
                }
                else
                {
                    // enforce sam folder structure
                    localPath = fileString;
                    // assuming we have D://some_path/somepath/[name; *; **]
                    cloudPath = fileString.Substring(4, fileString.Length - 4 - fileString.LastIndexOfAny(new[] { '/', '\\' }));
                }

                fileMap.Add(cloudPath, localPath);
            }

            args.StringFileMap = fileMap;

        }
    }
}
