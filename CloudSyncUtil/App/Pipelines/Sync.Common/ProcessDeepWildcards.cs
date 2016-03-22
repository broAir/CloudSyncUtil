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

                var files = Directory.GetFiles(fsPath);
                files.ToList().ForEach(x => ProcessSingleFile(cloudFolder, x));

                var folders = Directory.GetDirectories(fsPath);
                this.ProcessFolders(folders);
            }
            catch (Exception e)
            {
                // TODO: handle
                throw;
            }
        }

        protected void ProcessFolders(string[] folders)
        {
            folders
                .Select(x =>
                    new KeyValuePair<CloudFile, string>(cloudFolder, FileNameStringOperations.GetFolderName(x)))
                .ToList()
                .ForEach(x => ProcessFolder(x));
            var folderName = cloudToFsPath.Value;
            var parent = CloudRepository.CreateFolder(folderName, cloudToFsPath.Key)
        }

        
    }
}
