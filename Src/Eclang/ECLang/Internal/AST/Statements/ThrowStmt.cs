namespace ECLang.Internal.AST.Statements
{
    using System.Text.RegularExpressions;

    using ECLang.AST;

    public class ThrowStmt : Statement
    {
        #region Public Properties

        public string Data { get; set; }

        #endregion

        #region Public Methods and Operators

        public override Statement Interprete(string src, int line)
        {
            var returns = new ThrowStmt();
            var regexp = new Regex(Parser.Grammar.GetPattern("throw").ToString());
            Match m = regexp.Match(src);
            returns.Line = line;
            returns.Data = m.Groups["Name"].Value;

            return returns;
        }

        public override bool IsStatement(string src)
        {
            return Parser.Grammar.GetPattern("throw").IsValid(src);
        }

        #endregion
    }
}