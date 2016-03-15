using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSyncUtil.App.Pipelines.Sync.Common
{
    public class EnsureSyncFolder : CommonSyncProcessor
    {
        public EnsureSyncFolder(int priority = 200) : base(priority) { }

        protected override void DoProcess(CloudSyncPipelineArgs args)
        {
            var folderName = args.SyncRootFolderName;
            var repo = args.Repository;

            if (!string.IsNullOrEmpty(folderName))
            {
                args.SyncRootFolder = repo.CreateFolder(folderName);
            }
        }
    }
}
