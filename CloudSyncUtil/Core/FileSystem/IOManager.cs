using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CloudSyncUtil.Core.FileSystem
{
    public static class IOManager
    {
        public static string GetMD5CheckSum(string path)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(path))
                {
                    return Encoding.Default.GetString(md5.ComputeHash(stream));
                }
            }
        }

        public static string[] ReadFileContents(string path)
        {
            try
            {
                return File.ReadAllLines(path);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static bool SaveToFile(string path, byte[] bytes)
        {
            try
            {
                File.WriteAllBytes(path, bytes);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool SaveToFile(string path, string contents)
        {
            try
            {
                File.WriteAllText(path, contents);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public static string[] ConvertToFileAndReadContents(byte[] bytes)
        {
            var fname = DateTime.Now.Ticks.ToString() + ".tmp";

            SaveToFile(fname, bytes);

            return ReadFileContents(fname);

        }

        public static bool Exists(string path)
        {
            return File.Exists(path);
        }

        public static DateTime GetLastUpdated(string path)
        {
            return File.GetLastWriteTime(path);
        }
        
    }
}
