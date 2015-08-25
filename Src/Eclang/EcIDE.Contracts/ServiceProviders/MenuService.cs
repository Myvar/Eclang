namespace EcIDE.Contracts.ServiceProviders
{
    using System.Windows.Forms;

    using EcIDE.Addins;

    public class MenuService : IServiceProvider
    {
        #region Constructors and Destructors

        public MenuService(MenuStrip fctb)
        {
            this.Fctb = fctb;
        }

        #endregion

        #region Properties

        internal MenuStrip Fctb { get; set; }

        #endregion

        #region Public Methods and Operators

        public MenuStrip GetMenu()
        {
            return this.Fctb;
        }

        #endregion
    }
}