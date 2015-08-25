using System;

namespace EcIDE.Internals.Packing.vfs
{
    [Serializable]
    public class File : IEntry
    {
        public File()
        {
            Header = new Header();
        }

        public Header Header { get; set; }
        public string Content { get; set; }


    }
}
