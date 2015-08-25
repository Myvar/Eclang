namespace EcIDE.Core.Intellisense.Commands
{
    using System.Drawing;

    using EcIDE.Addins;
    using EcIDE.Contracts;

    public class ClassesCommand : IIntellisenseCommand
    {
        public Brush GetColor()
        {
            return IntellisenseColors.ClassTeal;
        }

        public string GetDescription()
        {
            return null;
        }

        public string GetPattern()
        {
            return "(number|regex|object|string|bool|array|null|lambda)";
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
