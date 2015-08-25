using System.Diagnostics;
using EcIDE.Internals.UI;
using ECLang.Internal;
using ECLang.Internal.Binary;
using Telerik.WinControls.UI.Docking;

namespace EcIDE
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    using EcIDE.Addins;
    using EcIDE.Contracts;
    using EcIDE.Contracts.ServiceProviders;
    using EcIDE.Internals;
    using EcIDE.Internals.Console;
    using EcIDE.Internals.Exe;
    using EcIDE.Internals.UI.Properties;
    using EcIDE.Nodes;
    using EcIDE.PropertyPages;
    using EcIDE.UI;

    using ECLang;
    using ECLang.Internal.Tables;

    using FastColoredTextBoxNS;

    using updateSystemDotNet;

    using TabPage = EcIDE.Internals.UI.Properties.TabPage;

    public sealed partial class MainForm : Form
    {
        #region Static Fields

        public static Engine engine;

        public static string sndtxt = "";

        #endregion

        #region Fields

        private readonly Style RedTxt = new TextStyle(Brushes.DarkRed, Brushes.White, FontStyle.Regular);

        private readonly TextBoxReader rdtxt = new TextBoxReader();

        private bool notShowed;

        #endregion

        #region Constructors and Destructors

        public MainForm()
        {
            var items = new List<AutocompleteItem>
                        {
                            new SnippetAutocompleteItem(
                                "if ^[expression]\r\n\r\t#do something\nend if"),
                            new SnippetAutocompleteItem(
                                "try \r\n\r^#do something\n\rcatch ex\r\n#do something\n\nfinally\n#do something\nend try"),
                            new SnippetAutocompleteItem(
                                "switch ^parent \r\n\r#do something\ncase condition:\r\n#do something\nbreak;\ndefault:\n#do something\nend switch")
                        };
            //items.Add(new MethodAutocompleteItem2("Console.WriteLine"));

            foreach (ExtensionNode node in AddinManager.GetExtensionObjects("/EcIDE/Intellisense/Snippets"))
            {
                var cmd = node.CreateInstances<ISnippet>();

                cmd.ForEach(c => c.Init(new ServiceContainer()));
                cmd.ForEach(c => items.Add(new SnippetAutocompleteItem(c.GetSnippet())));
            }

            IntellisenseManager.PopulateClass(items, typeof(Console));
            IntellisenseManager.PopulateClass(items, typeof(MessageBox));

            foreach (ExtensionNode node in AddinManager.GetExtensionObjects("/EcIDE/Intellisense/Commands"))
            {
                var cmd = node.CreateInstances<IIntellisenseCommand>();

                cmd.ForEach(c => c.Init(new ServiceContainer()));

                foreach (IIntellisenseCommand intellisenseCommand in cmd)
                {
                    StyleManager.Add(
                        intellisenseCommand.GetPattern(),
                        intellisenseCommand.GetColor(),
                        intellisenseCommand.GetStyle());
                    InfoManager.Add(intellisenseCommand.GetPattern(), intellisenseCommand.GetDescription());

                    items.Add(new AutocompleteItem(intellisenseCommand.GetPattern(), 0));
                }
            }

            this.InitializeComponent();

            var menu = new AutocompleteMenu(this.fastColoredTextBox1) { SearchPattern = @"[\w\.]", AllowTabKey = true };
            menu.Items.SetAutocompleteItems(items);

            Console.SetOut(new ControlWriter(this.console));
            Console.SetIn(this.rdtxt);
            engine = new Engine { Flag = Engine.ExecutanFlags.RamOptimized };

            OptionsManager.Load();

            ServiceProviderContainer.AddService(new EditorService(this.fastColoredTextBox1));
            ServiceProviderContainer.AddService(new MenuService(this.MainMenu));
            ServiceProviderContainer.AddService(new AddinService(AddinManager.Registry));
            ServiceProviderContainer.AddService(new NotificationService(this.RadDesktopAlert));
            ServiceProviderContainer.AddService(new WindowService(this.dock));
            ServiceProviderContainer.AddService(new OptionsService());

            foreach (ExtensionNode node in AddinManager.GetExtensionObjects("/EcIDE/StartupCommands"))
            {
                var cmd = node.CreateInstances<ICommand>();

                cmd.ForEach(c => c.Init(new ServiceContainer()));
                cmd.ForEach(c => c.Run());

                var ecommand = node.GetCommand();

                foreach (var ec in ecommand)
                {
                    var ep = ec as window;
                    if (ep != null)
                    {
                        if (ep.title != "")
                            this.Text = ep.title;
                        if (ep.close != "")
                        {
                            cmd.ForEach(
                                c =>
                                {
                                    this.FormClosing += (sender, args) => c.GetType().GetMethod(ep.close).Invoke(c, null);
                                });
                        }
                    }
                }
            }

            foreach (ExtensionNode node in AddinManager.GetExtensionObjects("/EcIDE/Menu"))
            {
                foreach (var ec in node.GetCommand())
                {
                    var ep = ec as menuitem;
                    if (ep != null)
                    {
                        var target = node.CreateInstances<IMenu>()[0];
                        target.Init(new ServiceContainer());

                        MainMenu.Items.Add(
                            new ToolStripMenuItem(ep.text, null, (sender, args) => target.GetType().GetMethod(ep.click).Invoke(target, new[] { sender, args })));
                    }
                }
            }

            MenuBinder.Bind(MainMenu);

            explorerTree.ExpandAll();

            projectProperties1.AddCurrentTabPage(new GeneralPage());
            this.AddPropertyTabPage("General", new GeneralPage());
            
            dock.CloseWindow(propertiesWindow);

            fastColoredTextBox1.Refresh();
        }

        public void AddPropertyTabPage(string title, Control c)
        {
            var tp = new TabPage();
            c.Dock = DockStyle.Fill;
            tp.Controls.Add(c);

            projectProperties1.TabItems.Add(new TabItem(title, tp));
        }

        #endregion

        #region Public Methods and Operators

        public int GetLineFromTerm(string trm)
        {
            for (int index = 0; index < this.fastColoredTextBox1.Text.Replace("\r\n", "\n").Split('\n').Length; index++)
            {
                string s = this.fastColoredTextBox1.Text.Replace("\r\n", "\n").Split('\n')[index];
                if (s.Contains(trm))
                {
                    return index + 1;
                }
            }
            return 0;
        }

        #endregion

        #region Methods

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.radDock1.SaveToXml("dock.xml");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var startwindow = new DocumentWindow();
            startwindow.Text = "StartPage";
            startwindow.Controls.Add(new StartPageCtrl() {Dock = DockStyle.Fill});

            dock.AddDocument(startwindow);

            /*   var pf = new ProjectFile();

            pf.Body.Properties.Add("Version", "1.0.0.0");
            pf.ProjectHeader = new Header() { Name = "TestProject", Type = ProjectType.WindowsFormsApplication };

            ProjectFile.Save("test.ecproj", ref pf);*/

            if (File.Exists("dock.xml"))
            {
              //  this.radDock1.LoadFromXml("dock.xml");
            }

            
            engine = new Engine { Flag = Engine.ExecutanFlags.RamOptimized };
            engine.Evaluate(this.fastColoredTextBox1.Text);
            console.Clear();

            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                var updController = new updateController
                                    {
                                        updateUrl = "http://eclang.tk/updates/",
                                        projectId = "8ffc8e6d-93d9-4bc2-a48e-238f27efae9e",
                                        publicKey =
                                        "<RSAKeyValue><Modulus>z6FnsZcLX3Cl864s1x/8fR8/Mg1kIJIiFBouMUdRpMxe13t5J/B4S3obzr94oQgjiXR/09vjKUQdoAsUm1AwxjI+7TkR3TEnu2HHEw2O8e4gkbfnwHqODtSWuHzsIxFnhhYcmVWfY/eRniilfnUBb6bcVomFUxwQFfAqXl8vC58iVjIW+4Ir05qTTH3KIf24J+ADoLYuX0rQD6wCdfmWCII7QuqkN7NBfmoq1G2Ol5p366ILnANMdz+3n+u6lkkjl+RVEAoG/pDaRIbSnb52k0p517Cb1N4D3zfr3cftYLKQImDAc9xtC9V8F2nVdjTz05pooZuONrg8J7lmwkYER1+xDnzAg4hL0g2jefjsbrlUuvs0/nIff8DKGsqkAzg/Qg5ylYdQ/lrge6tdISrIql1PZY6qo6VlllCDn8yLhpdZfUuBMEdVrW0xLo7qWZ8Y9dHsO2It52BtvAtEpKwwPOLyL9PTU+A9DnbdSgVckdDye8dVgcZeApsrIf1qWRJyqcdXjP9Y4pKefYcBizCIjL4gGUQilR5I7WsqXfAwPkqEcWCPtaBrX8jb9JmGqY0aUH7FDYdoK0kmkaM2PGiSMaugTnfcs0HUFStj4Liaz7I0b3zM+sN7sx/dW/0KYDXCNZWVxFndcG9aZk/0umaA7q+ISITadaY+axa3DsVwelU=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>",    
                                        releaseFilter =
                                        {
                                            checkForFinal = true,
                                            checkForBeta = true,
                                            checkForAlpha = true
                                        },
                                        restartApplication = true,
                                        autoCloseHostApplication = true,
                                        retrieveHostVersion = true,
                                        Language = Languages.Auto
                                    };

                if (updController.checkForUpdates()) updController.updateInteractive(this);
                
            }
        }

        private void NotificationTimer_Tick(object sender, EventArgs e)
        {
            this.NumberOfNotsItem.Text =
                NotificationCenter.ToArray()
                    .Select(notification => notification.Read == false)
                    .ToArray()
                    .Length.ToString();
            this.NumberOfNotsItem.Visible = NotificationCenter.ToArray().Length != 0;
        }

        private void buildNoConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cp = new Compiler();
            cp.BuildExe("test.exe", this.fastColoredTextBox1.Text, false);
        }

        private void buildShowConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cp = new Compiler();
            cp.BuildExe("test.exe", this.fastColoredTextBox1.Text);
        }

        private void buildToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.fastColoredTextBox1.Copy();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.fastColoredTextBox1.Cut();
        }

        private void fastColoredTextBox1_AutoIndentNeeded(object sender, AutoIndentEventArgs args)
        {
            //end of block
            if (Regex.IsMatch(args.LineText, @"^\s*(End|EndIf|Next|Loop)\b", RegexOptions.IgnoreCase))
            {
                args.Shift = -args.TabLength;
                args.ShiftNextLines = -args.TabLength;
                return;
            }
            //start of declaration
            if (Regex.IsMatch(
                args.LineText,
                @"\b(Class|Property|Enum|Structure|Sub|Function|Namespace|Interface|Get)\b|(Set\s*\()",
                RegexOptions.IgnoreCase))
            {
                args.ShiftNextLines = args.TabLength;
                return;
            }
            //start of operator block
            if (Regex.IsMatch(args.LineText, @"^\s*(If|While|For|Do|Try|With|Using|Select)\b", RegexOptions.IgnoreCase))
            {
                args.ShiftNextLines = args.TabLength;
                return;
            }

            //Statements else, elseif, case etc
            if (Regex.IsMatch(args.LineText, @"^\s*(Else|ElseIf|Case|Catch|Finally)\b", RegexOptions.IgnoreCase))
            {
                args.Shift = -args.TabLength;
                return;
            }

            //Char _
            if (args.PrevLineText.TrimEnd().EndsWith("_"))
            {
                args.Shift = args.TabLength;
            }
        }

        private void fastColoredTextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            foreach (TextStyle textStyle in StyleManager.Styles)
            {
                e.ChangedRange.ClearStyle(textStyle);
            }
            foreach (var textStyle in StyleManager.patterns)
            {
                e.ChangedRange.SetStyle(textStyle.Value, textStyle.Key);
            }

            e.ChangedRange.ClearStyle(this.RedTxt);

           // e.ChangedRange.SetStyle(this.TealTxt, @"[Nn]ew (?<range>.*)\(\)");
            //e.ChangedRange.SetStyle(this.TealTxt, @"[Dd]ef (?<range>.*)\(\)");

            // e.ChangedRange.SetStyle(TealTxt, @"\= (.*)\;");

            e.ChangedRange.SetStyle(this.RedTxt, "\".*\"");

            e.ChangedRange.SetFoldingMarkers("if", "end if");
            e.ChangedRange.SetFoldingMarkers("while", "end while");
            e.ChangedRange.SetFoldingMarkers("for", "end for");
            e.ChangedRange.SetFoldingMarkers("def", "end def");
            e.ChangedRange.SetFoldingMarkers("try", "end try");
            e.ChangedRange.SetFoldingMarkers("switch", "end switch");

            this.map1.RefreshItems();
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

        private void findReplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.fastColoredTextBox1.ShowFindDialog();
        }

        private void goToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.fastColoredTextBox1.ShowGoToDialog();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlf = new OpenFileDialog { Filter = "Ec source File|*.ec" };
            if (dlf.ShowDialog() == DialogResult.OK)
            {
                this.fastColoredTextBox1.Text = File.ReadAllText(dlf.FileName);
            }
        }

        private void notificationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.notShowed = false;
            var np = new NotificationPopup { Location = new Point(181, 47) };

            if (this.NumberOfNotsItem.Text != "0")
            {
                np.Show();
                this.notShowed = true;
            }
            if (this.notShowed)
            {
                //np.Close();
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.fastColoredTextBox1.Paste();
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.fastColoredTextBox1.ShowReplaceDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dlg = new SaveFileDialog { Filter = "Ec source File|*.ec" };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(dlg.FileName, this.fastColoredTextBox1.Text);
            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.console.Clear();
            this.errorLb.Items.Clear();

            engine = new Engine { Flag = Engine.ExecutanFlags.RamOptimized | Engine.ExecutanFlags.Strict };
            Engine.InitDefaults();
            engine.Execute(this.fastColoredTextBox1.Text);

            foreach (Error error in engine.Errors)
            {
                const string pat = @"(?<Message>(.*))&&\[(?<Term>(.*))\]&&";
                Match mc = Regex.Match(error.Message, pat);
                this.errorLb.Items.Add(
                    mc.Groups["Message"].Value + " on Line: " + this.GetLineFromTerm(mc.Groups["Term"].Value));
            }
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            engine.Stop();
        }

        #endregion

        private void buildEcRuntimeFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter ="EcBinaryFile (*.ecb)|*.ecb";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                EcFileFormat eff = new EcFileFormat();
                eff.Filesystem.AddFile("main.ec", fastColoredTextBox1.Text);
                eff.Version = "A 1.0.4";

                using (var fs = new FileStream(dlg.FileName, FileMode.OpenOrCreate))
                {
                    Writer.Save(fs, eff);

                    fs.Close();
                }
            }
        }

        private void loadecbToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter ="EcBinaryFile (*.ecb)|*.ecb";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                using (var fs = new FileStream(dlg.FileName, FileMode.OpenOrCreate))
                {
                    EcFileFormat ecf = new EcFileFormat();

                    Reader.Load(fs, ref ecf);
                    fastColoredTextBox1.Text = ecf.Filesystem.GetFile<string>("main.ec");
                    fs.Close();
                }
            }

        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var of = new OptionsForm();
            of.ShowDialog(this);
        }

        private void projectExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dock.DisplayWindow(ProjectExplorerWindow);
        }

        private void consoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dock.DisplayWindow(ConsoleWindow);
        }

        private void mapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dock.DisplayWindow(MapWindow);
        }

        private void documentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dock.DisplayWindow(DocumentWindow);
        }

        private void errorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dock.DisplayWindow(errorsWindow);
        }

        private void explorerTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Properties")
            {
                dock.DisplayWindow(propertiesWindow);
            }
        }

        private void console_CommandEntered(object sender, Internals.UI.ShellControl.CommandEnteredEventArgs e)
        {
            sndtxt = e.Command;
            this.rdtxt.snd = true;
        }

        private void installToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "EC Addin Installer (*.ecai)|*.ecai";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var p = Process.Start("AddinInstaller.exe", "\"" + ofd.FileName + "\"");
                p.WaitForExit();
                
            }
        }
    }
}