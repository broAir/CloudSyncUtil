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

        public string GoogleFileDataStore()
        {
            return ConfigurationManager.GetSettingValue<string>("Google.FileDataStore");
        }
    }
}
