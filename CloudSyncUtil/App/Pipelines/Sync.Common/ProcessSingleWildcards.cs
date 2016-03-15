using CloudSyncUtil.Core.Files;
using CloudSyncUtil.Core.Integrations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSyncUtil.App.Pipelines.Sync.Common
{
    public class ProcessSingleWildcards : CommonSyncProcessor
    {
        protected CloudRepository CloudRepository;

        public ProcessSingleWildcards(int priority = 500) : base(priority) { }

        protected override void DoProcess(CloudSyncPipelineArgs args)
        {
            this.CloudRepository = args.Repository;

            var wildcards = args.CloudToStringMap.Where(x => x.Value.EndsWith("/*", StringComparison.InvariantCulture)).ToList();

            foreach (var wildcardPath in wildcards)
            {
                this.ProcessSingleWildcard(wildcardPath);
            }

        }

        protected void ProcessSingleWildcard(KeyValuePair<CloudFile, string> wildcardPath)
        {
            try
            {
                var fsPath = wildcardPath.Value.TrimEnd(new[] { '*' });
                var cloudFolder = wildcardPath.Key;

                var files = Directory.GetFiles(fsPath);

                files.ToList().ForEach(x => ProcessSingleFile(cloudFolder, x));
            }
            catch (Exception e)
            {
                // TODO: handle
                throw;
            }
        }

        protected CloudFile ProcessSingleFile(CloudFile parent, string path)
        {
            try
            {
                var file = FileFactory.Instance.GetFile(path);

                return CloudRepository.UploadFile(file, parent);
            }
            catch (Exception e)
            {
                // TODO: handle
                throw;
            }
        }
    }
}
