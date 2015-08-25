namespace EcIDE.Contracts.ServiceProviders
{
    using EcIDE.Addins;

    using FastColoredTextBoxNS;

    public class EditorService : IServiceProvider
    {
        #region Constructors and Destructors

        public EditorService(FastColoredTextBox fctb)
        {
            this.Fctb = fctb;
        }

        #endregion

        #region Properties

        internal FastColoredTextBox Fctb { get; set; }

        #endregion

        #region Public Methods and Operators

        public FastColoredTextBox GetEditor()
        {
            return this.Fctb;
        }

        #endregion
    }
}