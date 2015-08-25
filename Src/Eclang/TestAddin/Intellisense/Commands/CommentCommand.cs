namespace EcIDE.Core.Intellisense.Commands
{
    using System.Drawing;

    using EcIDE.Addins;
    using EcIDE.Contracts;

    public class CommentCommand : IIntellisenseCommand
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
            return @"\#(.*)";
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
