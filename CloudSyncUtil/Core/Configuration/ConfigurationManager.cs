using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudSyncUtil.Core.Configuration
{
    public static class ConfigurationManager
    {
        private static readonly NameValueCollection AppSettings;

        static ConfigurationManager()
        {
            AppSettings = System.Configuration.ConfigurationManager.AppSettings;
        }

        #region GetSettingValues

        public static T GetSettingValue<T>(string settingName, T defaultValue)
        {
            try
            {
                var val = AppSettings[settingName];
                return (T) Convert.ChangeType(val, typeof (T), CultureInfo.InvariantCulture);
            }
            catch (Exception e)
            {
                return defaultValue;
            }
        }

        public static T GetSettingValue<T>(string settingName, string defaultValue)
        {
            try
            {
                var defaultVal = (T) Convert.ChangeType(defaultValue, typeof (T), CultureInfo.InvariantCulture);

                return GetSettingValue(settingName, defaultVal);
            }
            catch (Exception e)
            {
                return default(T);
            }
        }

        public static T GetSettingValue<T>(string settingName)
        {
            return GetSettingValue(settingName, default(T));
        }

        #endregion


    }
}
