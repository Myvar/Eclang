namespace EcIDE.Internals
{
    using System;

    using FastColoredTextBoxNS;

    public class MethodAutocompleteItem2 : AutocompleteItem
    {
        #region Fields

        private readonly string lowercaseText;

        private string firstPart;

        #endregion

        #region Constructors and Destructors

        public MethodAutocompleteItem2(string text)
            : base(text)
        {
            this.lowercaseText = this.Text.ToLower();
            this.MenuText = text.Split('.')[1];
        }

        #endregion

        #region Public Methods and Operators

        public override CompareResult Compare(string fragmentText)
        {
            int length = fragmentText.LastIndexOf('.');
            if (length < 0)
            {
                return CompareResult.Hidden;
            }
            string str = fragmentText.Substring(length + 1);
            this.firstPart = fragmentText.Substring(0, length);
            if (str == "")
            {
                return CompareResult.Visible;
            }
            if (this.Text.StartsWith(str, StringComparison.InvariantCultureIgnoreCase))
            {
                return CompareResult.VisibleAndSelected;
            }
            return this.lowercaseText.Contains(str.ToLower()) ? CompareResult.Visible : CompareResult.Hidden;
        }

        public override string GetTextForReplace()
        {
            return this.Text;
        }

        #endregion
    }
}