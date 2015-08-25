namespace EcIDE.Core.Intellisense.Commands
{
    using System.Drawing;

    using EcIDE.Addins;
    using EcIDE.Contracts;

    public class KeywordsCommand : IIntellisenseCommand
    {
        #region Public Methods and Operators

        public Brush GetColor()
        {
            return IntellisenseColors.CommandBlue;
        }

        public string GetDescription()
        {
            return null;
        }

        public string GetPattern()
        {
            return "(end (if|while|for|def|try|[Ss]witch))|(def)|(dec)|([Ii]mport)|(if|try|finally|catch|else|while|for|goto|label|foreach|new|del|true|false|ref|([Mm]ode|[Uu]se)|[Tt]hrow|[Ss]witch|[Dd]efault|[Cc]ase|[Bb]reak)";
        }

        public FontStyle GetStyle()
        {
            return FontStyle.Regular;
        }

        public void Init(ServiceContainer sp)
        {
        }

        #endregion
    }
}