using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using FastColoredTextBoxNS;


namespace EcIDE.Internals.Packing
{
    public class PackageBuilder
    {
        public string EnginDLL = "./ECLang.dll";
        public Dictionary<string, string> CodeFiles = new Dictionary<string, string>();
        public Dictionary<string, byte[]> Files = new Dictionary<string, byte[]>();


        public void SavePackage(string pth)
        {
            File.Copy("Packer.exe","./Build/Run.exe");
            foreach (KeyValuePair<string, string> code in CodeFiles)
            {
                File.WriteAllText("./Build/" + code.Key +".ec",code.Value);
                Ziper.Excute("a", "", "./Build/Run.exe", "./Build/" + code.Key + ".ec", "-y");
            } 
            Ziper.Excute("a", "", "./Build/Run.exe", @".\Build\*.ec", "-y");
        }

        private string ConvertBytesToString(byte[] bytes)
        {
            return ASCIIEncoding.ASCII.GetString(bytes);
        }

        private byte[] ConvertStringToBytes(string str)
        {
            return ASCIIEncoding.ASCII.GetBytes(str);
        }
    }
}
