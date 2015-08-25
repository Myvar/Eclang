namespace EcIDE.Core.Intellisense.Commands
{
    using System.Drawing;

    using EcIDE.Addins;
    using EcIDE.Contracts;

    public class NumberCommand : IIntellisenseCommand
    {
        public Brush GetColor()
        {
            return IntellisenseColors.AttributeGreen;
        }

        public string GetDescription()
        {
            return null;
        }

        public string GetPattern()
        {
            return @"((([+-]?)[0-9]+)(\.[0-9]+)?)";
        }

        public FontStyle GetStyle()
        {
            return FontStyle.Regular;
        }

        public void Init(ServiceContainer sp)
        {
        }
    }
}
