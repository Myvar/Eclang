namespace EcIDE.Contracts
{
    using System.Drawing;

    using EcIDE.Addins;

    public interface IIntellisenseCommand
    {
        #region Public Methods and Operators

        Brush GetColor();

        string GetDescription();

        string GetPattern();

        FontStyle GetStyle();

        void Init(ServiceContainer sp);

        #endregion
    }
}