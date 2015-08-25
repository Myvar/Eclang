namespace EcIDE.Parser
{
    using System.Collections.Generic;

    using EcIDE.Properties;

    using ECLang.AST;

    public class DefParser
    {
        #region Public Methods and Operators

        public static Dictionary<string, int> Parse(string[] src)
        {
            var items = new Dictionary<string, int>();
            var gr = new Grammar(Resources.Grammar);
            for (int i = 0; i < src.Length; i++)
            {
                if (gr.GetPattern("defstart").IsValid(src[i]))
                {
                    string name = gr.GetPattern("defstart").Match(src[i]).Groups["funcName"].Value;
                    items.Add(name, i);
                }
            }
            return items;
        }

        #endregion
    }
}