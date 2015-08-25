namespace EcIDE.Internals
{
    using System.Collections.Generic;
    using System.Drawing;

    using FastColoredTextBoxNS;

    public class StyleManager
    {
        #region Static Fields

        public static readonly List<TextStyle> Styles = new List<TextStyle>();

        public static readonly Dictionary<string, TextStyle> patterns = new Dictionary<string, TextStyle>();

        #endregion

        #region Public Methods and Operators

        public static void Add(string pattern, Brush color, FontStyle style)
        {
            var s = new TextStyle(color, Brushes.White, style);
            Styles.Add(s);
            patterns.Add(pattern, s);
        }

        #endregion
    }
}