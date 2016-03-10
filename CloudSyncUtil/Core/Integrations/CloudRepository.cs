using CloudSyncUtil.Core.FileSystem;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSyncUtil.Core.Integrations
{
    public abstract class CloudRepository
    {
        protected string ApiKey { get; set; }

        protected string ApiSecret { get; set; }

        protected string RepositoryMetadataFileName { get; set; }

        protected string UserName { get; set; }

        protected IFileMapper FileMapper;

        protected IAuthorizationProvider AuthorizationProvider;

        protected CloudRepository(IAuthorizationProvider authorizationProvider, IFileMapper fileMapper)
        {
            this.AuthorizationProvider = authorizationProvider;
            this.FileMapper = fileMapper;
        }

        public virtual object Authorize()
        {
            return AuthorizationProvider.Authorize(UserName, ApiKey, ApiSecret);
        }

        public virtual CloudFile GetRepositoryMetadata()
        {
            return GetFile(RepositoryMetadataFileName);
        }

        public abstract CloudFile GetFile(string fileName, CloudFile parent = null);

        public abstract CloudFile GetFolder(string folderName, CloudFile parent = null);

        public abstract bool HasFile(string fileName, CloudFile parent = null);

        public abstract string GetFileMetadata(string fileName);

        public abstract bool HasFolder(string folderName, CloudFile parent = null);

        public abstract CloudFile CreateFolder(string name, CloudFile parent = null);

        public abstract CloudFile CreateFolderStructure(string path);

        public abstract CloudFile UploadFile(LocalFile file, CloudFile parent = null);

        public abstract CloudFile UpdateFile(CloudFile fileOnCloud, LocalFile file, CloudFile parent = null);

        public abstract byte[] DownloadFile(string name);

        public abstract List<CloudFile> GetFiles(string search = "", int maxResults = 0);

    }
}
