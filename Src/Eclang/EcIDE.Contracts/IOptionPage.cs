namespace EcIDE.Contracts
{
    using EcIDE.Addins;
    using EcIDE.Contracts.UI.Options;

    public interface IOptionPage
    {
        void Init(ServiceContainer sp);

        OptionsPanel GetPage();

        void OnSave();
    }
}