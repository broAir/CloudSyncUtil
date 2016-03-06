using System;
using System.Linq;
using System.Collections.Generic;
using CloudSyncUtil.Core.Integrations;
using Google.Apis.Drive.v3.Data;

namespace CloudSyncUtil.Integrations.GoogleDrive
{
    public class GoogleFileMapper : IFileMapper
    {
        public List<CloudFile> MapMany(List<object> inners)
        {
            var result = new List<CloudFile>();

            inners.ForEach(x => result.Add(this.MapToFile(x)));

            return result;
        }

        public CloudFile MapToFile(object innerFile)
        {
            var inner = innerFile as File;

            if (inner == null)
                return null;

            var result = new CloudFile(inner);

            result.Id = inner.Id;
            result.MD5Checksum = inner.Md5Checksum;
            result.Name = inner.Name;
            result.Size = (int) inner.Size.GetValueOrDefault();
            result.Updated = inner.ModifiedTime.GetValueOrDefault();

            return result;
        }
    }
}
