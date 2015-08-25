namespace EcIDE.Internals
{
    using System.Collections.Generic;

    public class InfoManager
    {
        #region Static Fields

        public static readonly Dictionary<string, string> data = new Dictionary<string, string>();

        #endregion

        #region Public Methods and Operators

        public static void Add(string pattern, string text)
        {
            data.Add(pattern, text);
        }

        #endregion
    }
}