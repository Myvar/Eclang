namespace EcIDE.Nodes
{
    using EcIDE.Addins;

    public class menuitem : ExtensionCommand
    {
        public string text { get; set; }
        public string click { get; set; }
        public string enabled { get; set; }
    }
}
