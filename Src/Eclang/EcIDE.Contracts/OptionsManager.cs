namespace EcIDE.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Xaml;

    public class OptionsManager
    {
        private static Dictionary<string, object> data = new Dictionary<string, object>();

        public static void Add<T>(string k, T v)
        {
            data.Add(k, v);
        }

        public static bool Contains(string k)
        {
            return data.ContainsKey(k);
        }

        public static void Set<T>(string k, T v)
        {
            data[k] = v;
        }

        public static T Get<T>(string k)
        {
            return (T)data[k];
        }

        public static void Save()
        {
            var fs =
                new GZipStream(new FileStream(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\EcIDE\\options.xml",
                    FileMode.OpenOrCreate), CompressionMode.Compress);
            XamlServices.Save(fs, data);

            fs.Flush();
            fs.Close();
        }

        public static void Load()
        {
            var f = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\EcIDE\\options.xml";
            var fs = new GZipStream(new FileStream(f, FileMode.OpenOrCreate), CompressionMode.Decompress);

            if (File.Exists(f))
            {
                try
                {
                    data = (Dictionary<string, object>)XamlServices.Load(fs);
                }
                catch (Exception)
                {
                    
                }
            }
            fs.Close();
        }
    } 
}
