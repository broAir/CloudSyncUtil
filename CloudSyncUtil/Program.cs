using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudSyncUtil.Core.Configuration;
using CloudSyncUtil.Integrations.GoogleDrive;
using CloudSyncUtil.Core.Integrations;

namespace CloudSyncUtil
{
    class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("");
            var cid = ApiKeys.GoogleApiKey;
            var csec = ApiKeys.GoogleApiSecret;

            var auth = new GoogleAuthorizationProvider(SettingsManager.Instance);

            var service = new GoogleCloudRepository(SettingsManager.Instance);

            var f = service.CreateFolder("test shit");

            Console.WriteLine(f.Name);

            Console.ReadLine();
        }
    }
}
