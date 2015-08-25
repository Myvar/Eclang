namespace EcIDE.Contracts
{
    using EcIDE.Addins;

    public interface ICommand
    {
        #region Public Methods and Operators

        void Init(ServiceContainer sp);

        void Run();

        #endregion
    }
}