﻿using CloudSyncUtil.Core.Files;
using CloudSyncUtil.Core.Integrations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSyncUtil.App.Pipelines.Sync.Common
{
    public class ProcessSingleWildcards : CommonWildcardProcessor
    {
        public ProcessSingleWildcards(int priority = 500) : base("/*", priority) { }
        
        protected override void ProcessEntry(KeyValuePair<CloudFile, string> cloudToFsPath)
        {
            try
            {
                // clr will put this array init to the top and declare it only once. no worries
                var fsPath = cloudToFsPath.Value.TrimEnd(new[] { '*' });
                var cloudFolder = cloudToFsPath.Key;

                var files = Directory.GetFiles(fsPath);

                files.ToList().ForEach(x => ProcessSingleFile(cloudFolder, x));
            }
            catch (Exception e)
            {
                // TODO: handle
                throw;
            }
        }
        
    }
}
