namespace EcIDE.CodeMap
{
    using System.Collections.Generic;
    using System.Windows.Forms;

    using EcIDE.Parser;
    using EcIDE.Properties;

    using FastColoredTextBoxNS;

    using Telerik.WinControls.UI;
    using Telerik.WinControls.UI.Data;

    using Range = FastColoredTextBoxNS.Range;

    public partial class Map : UserControl
    {
        #region Constructors and Destructors

        public Map()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Public Properties

        public FastColoredTextBox fctb { get; set; }

        #endregion

        #region Public Methods and Operators

        public void AddDec(string name, int line)
        {
            var i = new RadListDataItem { Text = name, Tag = line, Image = Resources.Properties2 };
            this.radListControl1.Items.Add(i);
        }

        public void AddDef(string name, int line)
        {
            var i = new RadListDataItem { Text = name, Tag = line, Image = Resources.VSObject_Method };
            this.radListControl1.Items.Add(i);
        }

        public void Clear()
        {
            this.radListControl1.Items.Clear();
        }

        public void Navigate(int line)
        {
            this.fctb.Selection = new Range(this.fctb, line);
            this.fctb.DoSelectionVisible();
        }

        public void RefreshItems()
        {
            this.Clear();

            string[] lines = this.fctb.Text.Split('\n');

            Dictionary<string, int> defs = DefParser.Parse(lines);
            foreach (var def in defs)
            {
                this.AddDef(def.Key, def.Value);
            }
            Dictionary<string, int> decs = DecParser.Parse(lines);
            foreach (var def in decs)
            {
                this.AddDec(def.Key, def.Value);
            }
        }

        #endregion

        #region Methods

        private void radListControl1_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
        {
            this.Navigate((int)this.radListControl1.SelectedItem.Tag);
        }

        #endregion
    }
}