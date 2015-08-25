namespace EcIDE.Contracts
{
    using EcIDE.Addins;

    public interface ISnippet
    {
        #region Public Methods and Operators

        string GetSnippet();

        void Init(ServiceContainer sp);

        #endregion
    }
}