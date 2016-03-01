using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSyncUtil.Core.Integrations
{
    //http://www.daimto.com/google-drive-authentication-c/
    public abstract class CloudRepository<TFile>
    {
        protected string ApiKey { get; set; }

        protected string ApiSecret { get; set; }

        protected string RepositoryMetadataFileName { get; set; }

        protected string UserName { get; set; }


        protected IAuthorizationProvider AuthorizationProvider;

        protected CloudRepository(IAuthorizationProvider authorizationProvider)
        {
            this.AuthorizationProvider = authorizationProvider;
        }

        public virtual object Authorize()
        {
            return AuthorizationProvider.Authorize(UserName, ApiKey, ApiSecret);
        }

        public virtual TFile GetRepositoryMetadata()
        {
            return GetFile(RepositoryMetadataFileName);
        }

        public abstract TFile GetFile(string fileName);

        public abstract TFile GetFolder(string folderName);

        public abstract bool HasFile(string fileName);

        public abstract string GetFileMetadata(string fileName);

        public abstract bool HasFolder(string folderName);
        
        public abstract TFile CreateFolder(string name, TFile parent = default(TFile));

        public abstract TFile CreateFolderStructure(string path);

        public abstract TFile UploadFile(string name, TFile parent = default (TFile));

        public abstract List<TFile> GetFiles(string search = "", int maxResults = 0);

    }
}
