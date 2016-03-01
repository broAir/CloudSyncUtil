using System;
using System.IO;

namespace CloudSyncUtil.Core.FileSystem
{
    public static class IOManager
    {
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
    }
}
