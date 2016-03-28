using CloudSyncUtil.Core.FileSystem;
using CloudSyncUtil.Core.Integrations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSyncUtil.App.Pipelines.Sync.Common
{
    public class ProcessDeepWildcards : CommonWildcardProcessor
    {
        public ProcessDeepWildcards(int priority = 600) : base("/**", priority) { }

        protected override void ProcessEntry(KeyValuePair<CloudFile, string> cloudToFsPath)
        {
            try
            {
                // clr will put this array init to the top and declare it only once. no worries
                var fsPath = cloudToFsPath.Value.TrimEnd(new[] { '*' });

                var cloudFolder = cloudToFsPath.Key;

                Directory.GetFiles(fsPath).ToList().ForEach(x => ProcessSingleFile(cloudFolder, x));

                Directory.GetDirectories(fsPath).ToList().ForEach(x => ProcessFolder(cloudFolder, x));

            }
            catch (Exception e)
            {
                // TODO: handle
                throw;
            }
        }

        protected void ProcessFolder(CloudFile parent, string fsFolderPath)
        {
            var cloudFolder = CloudRepository.CreateFolder(FileNameStringOperations.GetFolderName(fsFolderPath), parent);

            // Upload inner files
            Directory.GetFiles(fsFolderPath).ToList().ForEach(x => ProcessSingleFile(cloudFolder, x));

            Directory.GetDirectories(fsFolderPath).ToList().ForEach(x => ProcessFolder(cloudFolder, x));
        }
                
        
    }
}
