namespace Addin.Installer
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;

    public class AddinInstallerFile
    {
        public Dictionary<string, byte[]> Dependecies = new Dictionary<string, byte[]>();
        public KeyValuePair<string, byte[]> Assembly = new KeyValuePair<string, byte[]>();

        public string License;

        public byte[] Icon;

        public static AddinInstallerFile Build(string license, List<string> dependencies, string assembly, Icon icon)
        {
            var ret = new AddinInstallerFile();
            ret.License = license;

            if (icon != null)
            {
                var ims = new MemoryStream();
                icon.Save(ims);
                ret.Icon = ims.ToArray();
            }

            if (dependencies != null)
            {
                foreach (var dependency in dependencies)
                {
                    ret.Dependecies.Add(Path.GetFileName(dependency), File.ReadAllBytes(dependency));
                }
            }

            ret.Assembly = new KeyValuePair<string, byte[]>(Path.GetFileName(assembly), File.ReadAllBytes(assembly));

            return ret;
        }

        public static void Save(AddinInstallerFile aif, Stream strm)
        {
            var bw = new BinaryWriter(strm);

            bw.Write(aif.License);

            if (aif.Icon != null)
            {
                bw.Write(aif.Icon.Length);
                bw.Write(aif.Icon);
            }
            else
            {
                bw.Write(0);
            }

            bw.Write(aif.Assembly.Key);
            bw.Write(aif.Assembly.Value.Length);
            bw.Write(aif.Assembly.Value);

            bw.Flush();

            bw.Write(aif.Dependecies.Count);
            foreach (var dependecy in aif.Dependecies)
            {
                bw.Write(dependecy.Key);

                bw.Write(dependecy.Value.Length);
                bw.Write(dependecy.Value);
            }

            bw.Flush();
            bw.Close();
        }

        public static AddinInstallerFile Load(Stream strm)
        {
            var ret = new AddinInstallerFile();
            var br = new BinaryReader(strm);

            var lic = br.ReadString();

            var icc = br.ReadInt32();
            byte[] ico = null;
            if(icc == 0)
                ico = br.ReadBytes(icc);

            var assKey = br.ReadString();
            var assCount = br.ReadInt32();
            var ass = br.ReadBytes(assCount);

            var depCount = br.ReadInt32();
            for (int i = 0; i < depCount; i++)
            {
                var n = br.ReadString();
                var count = br.ReadInt32();
                var val = br.ReadBytes(count);

                ret.Dependecies.Add(n, val);
            }

            ret.License = lic;
            if(icc != 0)
                ret.Icon = ico;
            ret.Assembly = new KeyValuePair<string, byte[]>(assKey, ass);

            return ret;
        }
    }
}
