namespace EcIDE.Contracts.ServiceProviders
{
    using System.Linq;

    using EcIDE.Addins;

    public class AddinService : IServiceProvider
    {
        #region Fields

        private readonly AddinRegistry ad;

        #endregion

        #region Constructors and Destructors

        public AddinService(AddinRegistry ad)
        {
            this.ad = ad;
        }

        #endregion

        #region Public Methods and Operators

        public Addin GetAddin(AddinInstance ai)
        {
            return this.ad.FirstOrDefault(a => a.Name == ai.GetAddin().Name);
        }

        #endregion
    }
}