using CloudSyncUtil.Core.Files;
using CloudSyncUtil.Core.Integrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSyncUtil.App.Pipelines.Sync.Common
{
    public abstract class CommonWildcardProcessor : CommonSyncProcessor
    {
        protected CloudRepository CloudRepository;

        protected string pattern;

        public CommonWildcardProcessor(string pattern, int priority) : base(priority)
        {
            this.pattern = pattern;
        }

        protected override void DoProcess(CloudSyncPipelineArgs args)
        {
            this.CloudRepository = args.Repository;

            var listToProcess = args.CloudToStringMap.Where(x => x.Value.EndsWith(pattern, StringComparison.InvariantCulture));

            foreach (var entry in listToProcess)
            {
                this.ProcessEntry(entry);
            }
        }

        protected virtual CloudFile ProcessSingleFile(CloudFile parent, string path)
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

        protected abstract void ProcessEntry(KeyValuePair<CloudFile, string> cloudToFsPath);

    }
}
