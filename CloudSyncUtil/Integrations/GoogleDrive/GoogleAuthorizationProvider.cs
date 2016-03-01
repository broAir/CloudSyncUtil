using System;
using System.Threading;
using CloudSyncUtil.Core.Configuration;
using CloudSyncUtil.Core.Integrations;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace CloudSyncUtil.Integrations.GoogleDrive
{
    public class GoogleAuthorizationProvider:IAuthorizationProvider
    {
        protected string fileDataStoreName;

        protected readonly SettingsManager SettingsManager;

        public GoogleAuthorizationProvider(SettingsManager settingsManager)
        {
            SettingsManager = settingsManager;

            fileDataStoreName = SettingsManager.GoogleFileDataStore();
            
        }

        public object Authorize(string userName, string apiKey, string apiSecret)
        {
            string[] scopes = { DriveService.Scope.Drive, DriveService.Scope.DriveFile, DriveService.Scope.DriveMetadata, DriveService.Scope.DriveAppdata };

            var clientId = apiKey; // From https://console.developers.google.com
            var clientSecret = apiSecret; // From https://console.developers.google.com
            // here is where we Request the user to give us access, or use the Refresh Token that was previously stored in %AppData%
            var credential =
                GoogleWebAuthorizationBroker.AuthorizeAsync(
                    new ClientSecrets {ClientId = clientId, ClientSecret = clientSecret},
                    scopes,
                    userName,
                    CancellationToken.None,
                    new FileDataStore(fileDataStoreName)).Result;


            var service = new DriveService(new BaseClientService.Initializer() {
                HttpClientInitializer = credential,
                ApplicationName = "Cloud Sync Utility",
            });

            return service;
        }
    }
}
