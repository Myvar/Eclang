namespace EcIDE.Parser
{
    using System.Collections.Generic;

    using EcIDE.Properties;

    using ECLang.AST;

    public class DecParser
    {
        #region Public Methods and Operators

        public static Dictionary<string, int> Parse(string[] src)
        {
            var items = new Dictionary<string, int>();
            var gr = new Grammar(Resources.Grammar);
            for (int i = 0; i < src.Length; i++)
            {
                if (gr.GetPattern("vardec").IsValid(src[i]))
                {
                    string name = gr.GetPattern("vardec").Match(src[i]).Groups["Name"].Value;
                    if (!items.ContainsKey(name))
                    {
                        items.Add(name, i);
                    }
                }
            }
            return items;
        }

        #endregion
    }
}