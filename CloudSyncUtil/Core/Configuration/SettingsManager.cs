namespace CloudSyncUtil.Core.Configuration
{
    public class SettingsManager
    {
        private static readonly SettingsManager instance = new SettingsManager();
        public static SettingsManager Instance
        {
            get
            {
                return instance;
            }
        }

        private SettingsManager()
        {

        }

        public string GoogleUserName()
        {
            return ConfigurationManager.GetSettingValue<string>("Google.UserName");
        }

        public string GoogleFileList()
        {
            return ConfigurationManager.GetSettingValue<string>("Google.Files");
        }

        public string GoogleRootFolder()
        {
            return ConfigurationManager.GetSettingValue<string>("Google.DriveRootFolder");
        }

        public string GoogleFileDataStore()
        {
            return ConfigurationManager.GetSettingValue<string>("Advanced.Google.FileDataStore");
        }
        public string GoogleDefaultFetchFields()
        {
            return ConfigurationManager.GetSettingValue<string>("Advanced.Google.FileList.FieldsToInclude");
        }
    }
}
