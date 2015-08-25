namespace EcIDE.Contracts.ServiceProviders
{
    using System.Linq;
    using System.Windows.Forms;

    using EcIDE.Addins;

    public class ErrorService : IServiceProvider
    {
        #region Constructors and Destructors

        public ErrorService(ListBox fctb)
        {
            this.lb = fctb;
        }

        #endregion

        #region Properties

        internal ListBox lb { get; set; }

        #endregion

        #region Public Methods and Operators

        public string[] GetErrors()
        {
            return (from object item in this.lb.Items select item as string).ToArray();
        }

        #endregion
    }
}