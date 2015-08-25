using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ECLang;
using FastColoredTextBoxNS;


namespace EcIDE
{
    using System.Text.RegularExpressions;

    using EcIDE.Contracts;
    using EcIDE.Contracts.ServiceProviders;
    using EcIDE.Internals;
    using EcIDE.Internals.AddinFramework;
    using EcIDE.Internals.Console;

    public partial class Form1 : Form
    {
        public static Engine engine;
        public Boolean ShowConsole = false;
        private TextBoxReader rdtxt = new TextBoxReader();
       

        public Form1()
        {
            InitializeComponent();

            Console.SetOut(new ControlWriter(listBox1));
            Console.SetIn(rdtxt);
            engine = new Engine();
            engine.Flag = Engine.ExecutanFlags.RamOptimized;

            ServiceProviderContainer.AddService(new EditorService(fastColoredTextBox1));

            foreach (var node in AddinManager.GetExtensionObjects("/EcIDE/StartupCommands"))
            {
                var cmd = node.CreateInstances <ICommand>();

                Array.ForEach(cmd, c => c.Init(new ServiceContainer()));
                Array.ForEach(cmd, c => c.Run());
            }
           
        }

        private void debugToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Ec source File|*.ec";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(dlg.FileName, fastColoredTextBox1.Text);
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlf = new OpenFileDialog();
            dlf.Filter = "Ec source File|*.ec";
            if (dlf.ShowDialog() == DialogResult.OK)
            {
                fastColoredTextBox1.Text = File.ReadAllText(dlf.FileName);
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.Paste();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            engine = new Engine();
            engine.Flag = Engine.ExecutanFlags.RamOptimized | Engine.ExecutanFlags.Strict;
            engine.Evaluate(fastColoredTextBox1.Text);

            foreach (var error in engine.Errors)
            {
                Console.WriteLine(error.Message);
            }

            panel1.Visible = ShowConsole;

        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            panel1.Visible = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Application.DoEvents();
        }

        private void consoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (panel1.Visible)
            {
                panel1.Visible = false;
                ShowConsole = false;
            }
            else if (panel1.Visible == false)
            {
                panel1.Visible = true;
                ShowConsole = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.Visible = true;
            engine = new Engine();
            engine.Flag = Engine.ExecutanFlags.RamOptimized;
            engine.Evaluate(fastColoredTextBox1.Text);
            fastColoredTextBox1.Text =
                fastColoredTextBox1.Text.Replace(
                    "Console.WriteLine(\"hello world\"); #gets replaced by msg box in load event",
                    "MessageBox.Show(\"hello world\");");
            listBox1.Items.Clear();
            if (ShowConsole == false)
                panel1.Visible = false;

            var items = new List<AutocompleteItem>();
            items.Add(new MethodAutocompleteItem2("Console.WriteLine"));
            items.Add(new SnippetAutocompleteItem("if ^[expression]\r\n\r\t#do something\nend if"));
            items.Add(new SnippetAutocompleteItem("try \r\n\r^#do something\n\rcatch ex\r\n#do something\n\nfinally\n#do something\nend try"));
            items.Add(new SnippetAutocompleteItem("switch ^parent \r\n\r#do something\ncase condition:\r\n#do something\nbreak;\ndefault:\n#do something\nend switch"));

            foreach (var node in AddinManager.GetExtensionObjects("/EcIDE/Intellisense/Snippets"))
            {
                var cmd = node.CreateInstances<ISnippet>();

                Array.ForEach(cmd, c => items.Add(new SnippetAutocompleteItem(c.GetSnippet())));
            }

            foreach (var node in AddinManager.GetExtensionObjects("/EcIDE/Intellisense/Commands"))
            {
                var cmd = node.CreateInstances<IIntellisenseCommand>();

                foreach (var intellisenseCommand in cmd)
                {
                    StyleManager.Add(intellisenseCommand.GetPattern(), intellisenseCommand.GetColor(), intellisenseCommand.GetStyle());
                    InfoManager.Add(intellisenseCommand.GetPattern(), intellisenseCommand.GetDescription());

                    items.Add(new AutocompleteItem(intellisenseCommand.GetPattern(), 0));
                }
            }

            var menu = new AutocompleteMenu(fastColoredTextBox1);
            menu.SearchPattern = @"[\w\.]";
            menu.AllowTabKey = true;
            menu.ImageList = imageList1;
            menu.Items.SetAutocompleteItems(items);
        }

        public static string sndtxt = "";

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                sndtxt = textBox1.Text;
                rdtxt.snd = true;
                textBox1.Text = "";
            }
        }

 

        // set up syntax heilyting
        private Style TealTxt = new TextStyle(Brushes.Teal, Brushes.White, FontStyle.Regular);
        private Style BlueTxt = new TextStyle(Brushes.Blue, Brushes.White, FontStyle.Regular);
        private Style RedTxt = new TextStyle(Brushes.DarkRed, Brushes.White, FontStyle.Regular);
        private Style GreenTxt = new TextStyle(Brushes.Green, Brushes.White, FontStyle.Italic);
        private Style attributeGreenTxt = new TextStyle(Brushes.DarkSeaGreen, Brushes.White, FontStyle.Regular);
        private Style numberRed = new TextStyle(Brushes.IndianRed, Brushes.White, FontStyle.Regular);

        private void fastColoredTextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            foreach (var textStyle in StyleManager.Styles)
            {
                e.ChangedRange.ClearStyle(textStyle);
            }
            foreach (var textStyle in StyleManager.patterns)
            {
                e.ChangedRange.SetStyle(textStyle.Value, textStyle.Key);
            }

            //clear
            e.ChangedRange.ClearStyle(TealTxt);
            e.ChangedRange.ClearStyle(BlueTxt);
            e.ChangedRange.ClearStyle(RedTxt);
            e.ChangedRange.ClearStyle(GreenTxt);
            e.ChangedRange.ClearStyle(attributeGreenTxt);
            e.ChangedRange.ClearStyle(numberRed);
            //set
            e.ChangedRange.SetStyle(TealTxt, "(number|byte|regex|object|string|bool|array|null)");
            e.ChangedRange.SetStyle(TealTxt, @"[Nn]ew (?<range>.*)\(\)");
            e.ChangedRange.SetStyle(TealTxt, @"[Dd]ef (?<range>.*)\(\)");

            e.ChangedRange.SetStyle(numberRed, @"((([+-]?)[0-9]+)(\.[0-9]+)?)");
            // e.ChangedRange.SetStyle(TealTxt, @"\= (.*)\;");

            e.ChangedRange.SetStyle(BlueTxt, "(end (if|while|for|def|try|[Ss]witch))|(def)|(dec)|([Ii]mport)|(if|try|finally|catch|else|while|for|new|del|true|false|ref|([Mm]ode|[Uu]se)|[Tt]hrow|[Ss]witch|[Dd]efault|[Cc]ase|[Bb]reak)");
            e.ChangedRange.SetStyle(RedTxt, "\".*\"");
            e.ChangedRange.SetStyle(attributeGreenTxt, "@.*");
            e.ChangedRange.SetStyle(GreenTxt, @"\#(.*)");

            e.ChangedRange.SetFoldingMarkers("if", "end if");
            e.ChangedRange.SetFoldingMarkers("while", "end while");
            e.ChangedRange.SetFoldingMarkers("for", "end for");
            e.ChangedRange.SetFoldingMarkers("def", "end def");
            e.ChangedRange.SetFoldingMarkers("try", "end try");
            e.ChangedRange.SetFoldingMarkers("switch", "end switch");

            map1.RefreshItems();
        }

     

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(listBox1.SelectedItem.ToString());
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
            }
        }


        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            listBox1.SelectedIndex = listBox1.IndexFromPoint(e.X, e.Y);

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
                sndtxt = textBox1.Text;
                rdtxt.snd = true;
                textBox1.Text = "";
            
        }

        private void fastColoredTextBox1_ToolTipNeeded(object sender, ToolTipNeededEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.HoveredWord))
            {
                foreach (var d in InfoManager.data)
                {
                    if (d.Key == e.HoveredWord)
                    {
                        e.ToolTipTitle = e.HoveredWord;
                        e.ToolTipText = d.Value;
                    }
                }
            }
        }

    }
}
