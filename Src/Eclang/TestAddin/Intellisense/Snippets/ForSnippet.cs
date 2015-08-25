namespace EcIDE.Core.Intellisense.Snippets
{
    using EcIDE.Addins;
    using EcIDE.Contracts;

    public class ForSnippet : ISnippet
    {
        #region Public Methods and Operators

        public string GetSnippet()
        {
            return "for index = 0, index < ^number, ++\n\nend for";
        }

        public void Init(ServiceContainer sp)
        {
        }

        #endregion
    }
}